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
    public partial class cadNv : Form
    {
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        public cadNv()
        {
            InitializeComponent();
            
            
        }

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
            
            comando.CommandText = "insert into nivel (nome,tempo) values(@nome,@tempo)";
            comando.Parameters.AddWithValue("@nome", txtNome.Text);
            comando.Parameters.AddWithValue("@tempo", txtDias.Text);
            if (txtNome.Text.Trim() != "" && txtDias.Text.Trim() != "")
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
                
            }else{
                errorProvider1.SetError(btnCad, "Todos os campos são obrigatórios");
            }
            comando.Parameters.Clear();
        }

        private void cadNv_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
