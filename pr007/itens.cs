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
    public partial class itens : Form
    {
        conexao conexao = new conexao();
        SqlCommand comando = new SqlCommand();
        string codLinha;
        public itens()
        {
            InitializeComponent();
        }
        //abaixo a função que permite a passagem de valores entre forms
        public string fim { get; set; }
        void loadGrid()
        {
            comando.CommandText = "SELECT [idItem],[nome] Nome,[descricao] Descrição,[tempoMedio] Duração FROM [teste].[dbo].[item] where idAtividade=@a";
            comando.Parameters.AddWithValue("@a", this.fim);

            comando.Connection = conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
            conexao.desconectar();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns["idItem"].Visible = false;
            comando.Parameters.Clear();
        }
        private void itens_Load(object sender, EventArgs e)
        {


            loadGrid();
            

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
            txtNome.Clear();
            mkdTempo.Clear();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            if (mkdTempo.Text != "  :") { 
                if (txtNome.Text.Trim() != "")
                {

                    comando.CommandText = "insert into item (idAtividade,nome,descricao,tempoMedio) values (@idAtividade,@nome,@descricao,@tempoMedio)";
                    comando.Parameters.AddWithValue("@idAtividade", this.fim);
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@descricao", txtDesc.Text);
                    comando.Parameters.AddWithValue("@tempoMedio", mkdTempo.Text);
                    
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
                    comando.Parameters.Clear();
                }
                else
                {
                    errorProvider1.SetError(txtNome, "campo obrigatório");
                }
            }
            else
            {
                errorProvider1.SetError(mkdTempo, "campo obrigatório");
            }
            loadGrid();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {


            loadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resu == DialogResult.OK)
            {

                comando.CommandText = "delete from item where idItem=@a";

                comando.Parameters.AddWithValue("@a", int.Parse(codLinha));
                comando.Connection = conexao.conectar();
                comando.ExecuteNonQuery();
                MessageBox.Show("Linha excluida com sucesso");
                conexao.desconectar();
                comando.Parameters.Clear();
                loadGrid();
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                codLinha = row.Cells[0].Value.ToString();

            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editItens objEditItens = new editItens();
            objEditItens.fim = codLinha;
            objEditItens.ShowDialog();
        }
    }
}
