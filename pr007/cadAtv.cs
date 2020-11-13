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
    public partial class cadAtv : Form
    {
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        public cadAtv()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cadAtv_Load(object sender, EventArgs e)
        {
            comando.CommandText = "select nome,idNivel from nivel";
            //preenchendo a combobox nivel
            try
            {
                comando.Connection = conexao.conectar();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                conexao.desconectar();
                da.Fill(ds, "atividade");
                cmbNivel.DisplayMember = "nome";
                cmbNivel.ValueMember = "idNivel";
                cmbNivel.DataSource = ds.Tables["atividade"];
                

            }
            catch(SqlException erro)
            {
                MessageBox.Show("Erro ao carregar cmb:" + erro);
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtNome.Clear();
            
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
           
            comando.CommandText = "insert into atividades(nome,descricao,idNivel,prazoMax) values(@nome,@descricao,@idNivel,@prazoMax)";
            comando.Parameters.AddWithValue("@nome", txtNome.Text);
            comando.Parameters.AddWithValue("@descricao", txtDesc.Text);
            comando.Parameters.AddWithValue("@idNivel",cmbNivel.SelectedValue);
            comando.Parameters.AddWithValue("@prazoMax", dtpPrazo.Value);
            if (txtNome.Text.Trim() != "")
            {
                try
                {


                    comando.Connection = conexao.conectar();
                    comando.ExecuteNonQuery();
                    conexao.desconectar();
                    MessageBox.Show("Cadastrado!");
                }
                catch (SqlException erro)
                {

                    MessageBox.Show("ERRO AO CADASTRAR:" + erro);
                }
                

            }
            else
            {
                //uso do erro provider para evidênciar erros
                errorProvider1.SetError(txtNome, "campo obrigatório");
            }
            comando.Parameters.Clear();
        }
    }
}
