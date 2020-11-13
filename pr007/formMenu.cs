using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr007
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void btnCadNv_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNv_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCadAtv_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAtv_Click(object sender, EventArgs e)
        {
            
        }

        private void atividadeEItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            cadAtv objCadAtv = new cadAtv();
            //botão do menu strip que faz o panel assumir o form cadastro de atividades
            objCadAtv.TopLevel = false;
            panel1.Controls.Add(objCadAtv);
            objCadAtv.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objCadAtv.Dock = DockStyle.Fill;
            objCadAtv.Show();
            Size = new Size(526, 366);

        }

        private void nivelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            cadNv objCadNv = new cadNv();
            //botão do menu strip que faz o panel assumir o form cadastro de niveis
            objCadNv.TopLevel = false;
            panel1.Controls.Add(objCadNv);
            objCadNv.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objCadNv.Dock = DockStyle.Fill;
            objCadNv.Show();
            Size = new Size(398, 178);


        }

        private void niveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            niveis objNv = new niveis();

            objNv.TopLevel = false;
            panel1.Controls.Add(objNv);
            objNv.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objNv.Dock = DockStyle.Fill;
            objNv.Show();
            Size = new Size(526, 366);
        }

        private void atividadesEItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            atividades objAtv = new atividades();

            objAtv.TopLevel = false;
            panel1.Controls.Add(objAtv);
            objAtv.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objAtv.Dock = DockStyle.Fill;
            objAtv.Show();
            Size = new Size(526, 366);
        }

        
    }
}
