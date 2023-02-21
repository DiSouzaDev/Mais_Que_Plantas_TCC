using atvBD_PlantasEstoque.Modelo;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atvBD_PlantasEstoque.DAL;


using System.Data.SqlClient;
using System.IO;
using cadastrarBotanica.consultoriaPlantasTCCDataSetTableAdapters;

namespace cadastrarBotanica
{
    public partial class Form1 : Form
    {
        int codFunc { get; set; }
        bool admAcesso { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try { 
            Controle controle = new Controle();
            ArrayList funcionario = controle.acessar(txtLogin.Text, txtSenha.Text);
            codFunc = (int)funcionario[0];
            admAcesso = (bool) funcionario[1];

            if (funcionario.Count > 0)
            {
                //this.Hide();
                Form3 bv = new Form3(codFunc, admAcesso);
                bv.Show();
                txtLogin.Clear();
                txtSenha.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Login não encontrado, verificar login e senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                txtLogin.Clear();
                txtSenha.Clear();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
