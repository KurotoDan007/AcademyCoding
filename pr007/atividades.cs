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
    public partial class atividades : Form
    {
        SqlCommand comando = new SqlCommand();
        public atividades()
        {
            InitializeComponent();
        }
        conexao conexao = new conexao();
        string codLinha;
        void loadGrid()
        {
            comando.CommandText = "select a.idAtv,a.nome Nome,a.descricao Descrição,a.prazoMax Término,n.nome Nivel,n.tempo Dias from atividades a inner join nivel n on n.idNivel = a.idNivel; ";

            comando.Connection = conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;

            dataGridView1.Columns["idAtv"].Visible = false;


            conexao.desconectar();

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            
        }
        private void atividades_Load(object sender, EventArgs e)
        {

            loadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
            

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView1,e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                codLinha = row.Cells[0].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            itens objItens = new itens();
            //evento que traz o form contendo os itens atrelados a atividade que foi clicada com o botão esquerdo
            
            objItens.fim = row.Cells[0].Value.ToString();
            objItens.ShowDialog();
            conexao.desconectar();
            comando.Parameters.Clear();
            dataGridView1.Rows[e.RowIndex].Selected = true;
            
        }

        private void cmbsExcluir_Click(object sender, EventArgs e)
        {
            var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resu == DialogResult.OK)
            {

                comando.CommandText = "delete from atividades where idAtv=@a";

                comando.Parameters.AddWithValue("@a", int.Parse(codLinha));
                comando.Connection = conexao.conectar();
                comando.ExecuteNonQuery();
                MessageBox.Show("Linha excluida com sucesso");
                conexao.desconectar();
                comando.Parameters.Clear();
                loadGrid();
            }

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            editAtv objEditAtv = new editAtv();
            objEditAtv.fim = codLinha;
            objEditAtv.ShowDialog();
            
            
        }
    }
}
