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
    public partial class niveis : Form
    {
        public niveis()
        {
            InitializeComponent();
        }
        SqlCommand comando = new SqlCommand();
        conexao conexao = new conexao();
        string codLinha;

        void loadGrid()
        {
            comando.CommandText = "SELECT [idNivel],[nome] Nome,[tempo] Dias FROM[teste].[dbo].[nivel]";

            comando.Connection = conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
            conexao.desconectar();
            dataGridView1.Columns["idNivel"].Visible = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void niveis_Load(object sender, EventArgs e)
        {

            loadGrid();

        }

        private void niveis_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resu = MessageBox.Show("Tem certeza que quer fazer isso?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resu == DialogResult.OK)
            {

                comando.CommandText = "delete from nivel where idNivel=@a";
                //botão excluir do context menu strip
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
                //evento que trás o context menu strip ao click com o botão direito
                contextMenuStrip1.Show(dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
                codLinha = row.Cells[0].Value.ToString();//variavel string que irá receber o código da linha

            }
            
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //botão editar que chama um formulário que ira receber o código da linha selecionada para efetuar a edição
            editNv objEditNv = new editNv();
            objEditNv.fim = codLinha;
            objEditNv.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
