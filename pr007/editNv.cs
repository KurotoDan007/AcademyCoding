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
    public partial class editNv : Form
    {
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        public editNv()
        {
            InitializeComponent();
            
            
        }

        public string fim { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtDias.Clear();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            if (txtDias.Text.Trim() != "" && txtNome.Text.Trim() != "")
            {
                var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resu == DialogResult.OK)
                {
                    comando.CommandText = "update nivel set nome=@nome,tempo=@tempo where idNivel=@a";
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@tempo", txtDias.Text);
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

        private void editNv_Load(object sender, EventArgs e)
        {
            try
            {
                comando.CommandText = "select nome from nivel where idNivel=@a";
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
