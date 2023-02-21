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
using System.Data.SqlClient;
using System.IO;
using cadastrarBotanica.consultoriaPlantasTCCDataSetTableAdapters;

namespace cadastrarBotanica
{
    public partial class Form5 : Form
    {
        LoginDaoComando dataFunc = new LoginDaoComando();
        int codFuncio;

        public Form5(int codFuncionario, bool adm)
        {
            InitializeComponent();
            txtCodFuncAltSenha.Text = codFuncionario.ToString();
            codFuncio = codFuncionario;
        }

        SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-UC8GBJH9\SQLEXPRESS;Initial Catalog=consultoriaPlantasTCC;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNovaSenha.Text != "")
            {
                try
                {
                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "UPDATE tblFuncionario SET senha_func=@senha_func WHERE cod_func=@cod_func";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_func", codFuncio);
                    comando.Parameters.AddWithValue("@senha_func", txtNovaSenha.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    conexao.Close();

                    MessageBox.Show("Senha alterada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSairAltSenha_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("Campo senha não aceita espaço", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
