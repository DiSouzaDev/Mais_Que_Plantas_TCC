using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atvBD_PlantasEstoque.DAL;
using cadastrarBotanica;

namespace cadastrarBotanica
{
    public partial class Form3 : Form
    {
        int codFunc { get; set; }
        bool admAcesso { get; set; }

        public Form3(int codFuncionario, bool adm)
        {
            InitializeComponent();
            codFunc = codFuncionario;
            admAcesso = adm;
            if (!adm)
            {
                button2.Visible = false;
            }
        }

       
        private void btnCadGeral_Click(object sender, EventArgs e)
        {
            Form2 bv = new Form2(codFunc, admAcesso);
            bv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 bv = new Form4();
            bv.Show();
        }

        private void btnAltSenha_Click(object sender, EventArgs e)
        {
            Form5 bvForm5 = new Form5(codFunc, admAcesso);
            bvForm5.Show();
        }
    }
}
