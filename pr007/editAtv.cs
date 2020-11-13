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
    public partial class editAtv : Form
    {
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        public editAtv()
        {
            InitializeComponent();
        }
        public string fim { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void editAtv_Load(object sender, EventArgs e)
        {
            comando.CommandText = "select nome,idNivel from nivel";
            
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
           
            
            try
            {
                comando.CommandText = "select nome from atividades where idAtv=@a";
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
                comando.CommandText = "select descricao from atividades where idAtv=@a";
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtNome.Clear();
            
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() != "")
            {
                var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resu == DialogResult.OK)
                {
                    comando.CommandText = "update atividades set nome=@nome,descricao=@descricao,idNivel=@idNivel,prazoMax=@prazoMax where idAtv=@a";
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@descricao", txtDesc.Text);
                    comando.Parameters.AddWithValue("@idNivel", cmbNivel.SelectedValue);
                    comando.Parameters.AddWithValue("@prazoMax", dtpPrazo.Value);
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

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
