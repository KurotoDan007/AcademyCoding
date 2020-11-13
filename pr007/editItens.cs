using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr007
{
    public partial class editItens : Form
    {
        public editItens()
        {
            InitializeComponent();
        }
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        public string fim { get; set; }

        private void btnCad_Click(object sender, EventArgs e)
        {
            if (mkdTempo.Text != "  :")
            {
                if (txtNome.Text.Trim() != "")
                {
                    var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resu == DialogResult.OK)
                    {
                        comando.CommandText = "update item set nome=@nome,descricao=@descricao,tempoMedio=@tempoMedio where idItem=@a";
                        comando.Parameters.AddWithValue("@nome", txtNome.Text);
                        comando.Parameters.AddWithValue("@descricao", txtDesc.Text);
                        comando.Parameters.AddWithValue("@tempoMedio", mkdTempo.Text);
                        comando.Parameters.AddWithValue("@a", fim);
                        try
                        {


                            comando.Connection = conexao.conectar();
                            comando.ExecuteNonQuery();
                            conexao.desconectar();
                            MessageBox.Show("editado!");
                        }
                        catch (SqlException erro)
                        {

                            MessageBox.Show("ERRO AO EDITAR:" + erro);
                        }
                        comando.Parameters.Clear();
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtNome.Clear();
            mkdTempo.Clear();
        }

        private void editItens_Load(object sender, EventArgs e)
        {
            try
            {
                comando.CommandText = "select nome from item where idItem=@a";
                comando.Parameters.AddWithValue("@a", fim);
                comando.Connection = conexao.conectar();
                txtNome.Text = comando.ExecuteScalar().ToString();
                conexao.desconectar();
                comando.Parameters.Clear();
            }
            catch (SqlException erro)
            {

                MessageBox.Show("Erro ao carregar textboxNome:" + erro);
            }

            try
            {
                comando.CommandText = "select descricao from item where idItem=@a";
                comando.Parameters.AddWithValue("@a", fim);
                comando.Connection = conexao.conectar();
                txtDesc.Text = comando.ExecuteScalar().ToString();
                conexao.desconectar();
                comando.Parameters.Clear();
            }
            catch (SqlException erro)
            {

                MessageBox.Show("Erro ao carregar textboxDescrição:" + erro);
            }
        }
    }
}
