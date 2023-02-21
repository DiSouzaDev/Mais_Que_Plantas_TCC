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


// inclusão da biblioteca do SQLServer
using System.Data.SqlClient;
using System.IO;
using cadastrarBotanica.consultoriaPlantasTCCDataSetTableAdapters;

namespace cadastrarBotanica
{
    public partial class Form2: Form
    {
        LoginDaoComando dataFunc = new LoginDaoComando();
        int codFuncio;
        public Form2(int codFuncionario, bool adm)
        {
            InitializeComponent();
            Console.WriteLine(cmbStatusClie.Text);
            txtFuncFAQ.Text = codFuncionario.ToString();
            txtFuncPlanta.Text = codFuncionario.ToString();
            txtFuncDoenca.Text = codFuncionario.ToString();
            codFuncio = codFuncionario;
            limparCaracClientes();
            //admAcesso = adm;
        }

        // string de conexão declarando e instanciando um objeto
        SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-UC8GBJH9\SQLEXPRESS;Initial Catalog=consultoriaPlantasTCC;User ID=sa;Password=etesp");

        string imgLocation = "";
        string imgLocationDoenca = "";
        string imgLocationProd = "";
        // string de comandos, para receber os comandos sql
        SqlCommand comando = new SqlCommand();
        // leitor de dados sql, o data reader, que lê os dados do BDsql por meio do comando select 
        //SqlDataReader leitor;


        // início das variaveis
        // limpa todos os caracteres do cadastro e volta o foco para o código do Produto


        void limparCaracPlantas()
        {
            txtCodPlanta.Clear();
            txtNomePlanta.Clear();
            txtNomCientPlanta.Clear();
            txtDescPlanta.Clear();
            txtConsPlanta.Clear();
            dgvPlanta.DataSource = null;
            dgvPlanta.Rows.Clear();
            txtNomePlanta.Focus();
            txtFuncCadPlanta.Clear();
            picPlanta.Image = null;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }
        void limparCaracDoencas()
        {
            txtCodigoDoenca.Clear();
            txtNomeDoenca.Clear();
            txtNomeCientDoenca.Clear();
            txtDescricaoDoenca.Clear();
            dgvDoencas.ClearSelection();
            txtNomeDoenca.Focus();
            dgvDoencas.DataSource = null;
            dgvDoencas.Rows.Clear();
            txtDoencaFuncCad.Clear();
            txtCodConsultaDoenca.Clear();
            picDoenca.Image = null;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }

        void limparCaracClientes()
        {
            txtCodigoCliente.Clear();
            txtNomeLoginCliente.Clear();
            txtSenhaLoginCliente.Clear();
            txtNomeCompletoCliente.Clear();
            txtEnderecoCliente.Clear();
            txtNumeroCliente.Clear();
            txtComplementoCliente.Clear();
            txtBairroCliente.Clear();
            txtCepCliente.Clear();
            txtEmailCliente.Clear();
            txtCelularCliente.Clear();
            dgvClientes.ClearSelection();
            cmbStatusClie.SelectedIndex = -1;
            txtCPFCliente.Clear();
            txtNomeCompletoCliente.Focus();
            cmbEstadoCli.SelectedIndex = -1;
            cmbMuncClie.SelectedIndex = -1;
            cmbTermClie.SelectedIndex = -1;
            dgvClientes.DataSource = null;
            dgvClientes.Rows.Clear();
            txtCodConsultaCliente.Clear();
            cmbStatClie.SelectedIndex = -1;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }

        void limparCaracProd()
        {
            txtCodProduto.Clear();
            txtNomeProd.Clear();
            txtEstProd.Clear();
            txtCustProd.Clear();
            txtVendProd.Clear();
            txtDescProd.Clear();
            txtConsProd.Clear();
            dgvProduto.DataSource = null;
            dgvProduto.Rows.Clear();
            cmbStatusProd.SelectedIndex = -1;
            cmbConsProd.SelectedIndex = -1;
            txtConsProd.Clear();
            cmbConsProd.SelectedIndex = -1;
            picProduto.Image = null;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }


        void limparPedCli()
        {
            txtConsPed.Clear();
            txtConsCPFClie.Clear();
            dgvDetPed.DataSource = null;
            dgvDetPed.Rows.Clear();
        }

        void limparPedProd()
        {
            dgvDetProd.DataSource = null;
            dgvDetProd.Rows.Clear();
        }

        void limparCaracFAQ()
        {
            txtCodFAQ.Clear();
            txtPerguntaFAQ.Clear();
            txtRespostaFAQ.Clear();
            dgvFAQ.ClearSelection();
            txtFAQFunCad.Clear();
            cmbStatusFAQ.SelectedIndex = -1;
            cbmConsStatusFAQ.SelectedIndex = -1;
            dgvFAQ.DataSource = null;
            dgvFAQ.Rows.Clear();
            cbmConsStatusFAQ.SelectedIndex = -1;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }


        // fim das variáveis

        private void tabPlantas_Click(object sender, EventArgs e)
        {
            comando.Connection = conexao;

            // código para que o foco do cursor inicie na caixa de texto desejada
            txtNomePlanta.Select();
            this.ActiveControl = txtNomePlanta;
            txtNomePlanta.Focus();
        }

        private void tabDoencas1_Click(object sender, EventArgs e)
        {
            comando.Connection = conexao;

            // código para que o foco do cursor inicie na caixa de texto desejada
            txtNomeDoenca.Select();
            this.ActiveControl = txtNomeDoenca;
            txtNomeDoenca.Focus();
        }

        private void tabClientes_Click(object sender, EventArgs e)
        {
            comando.Connection = conexao;

            // código para que o foco do cursor inicie na caixa de texto desejada
            txtNomeCompletoCliente.Select();
            this.ActiveControl = txtNomeCompletoCliente;
            txtNomeCompletoCliente.Focus();
        }

        private void tabProdutos_Click(object sender, EventArgs e)
        {
            comando.Connection = conexao;

            // código para que o foco do cursor inicie na caixa de texto desejada
            txtNomeProd.Select();
            this.ActiveControl = txtNomeProd;
            txtNomeProd.Focus();
        }

        private void tabFAQ_Click(object sender, EventArgs e)
        {
            comando.Connection = conexao;
            txtPerguntaFAQ.Select();
            this.ActiveControl = txtPerguntaFAQ;
            txtPerguntaFAQ.Focus();
        }


        private void btnTotalConsultasPlantas_Click_1(object sender, EventArgs e)
        {
            { // chama a tabela para o dgv, como se fosse um select*all
                conexao.Open();
                comando.CommandType = CommandType.Text;
                tblPlantaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblPlanta);
                conexao.Close();
            }
        }


        private void btnLimparPlantas_Click_1(object sender, EventArgs e)
        {
            limparCaracPlantas();
        }

        private void btnSairPlantas_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        // início dos eventos keypress

        private void txtPrecoCustoPlantas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            //  permite colocar apenas uma "," vírgula no campo de texto
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtPrecoVendaPlantas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ','
               && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            //  permite colocar apenas uma "," vírgula no campo de texto
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtCodConsultaPlantas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        // fim da tab de plantas

        // início da tab de doenças

        private void btnIncluirDoenca_Click_1(object sender, EventArgs e)
        {
            if (txtNomeDoenca.Text != "" && txtNomeCientDoenca.Text != "" && txtDescricaoDoenca.Text != "" && picDoenca.Image != null)
            {
                try
                {
                    byte[] images_doencas = null;
                    FileStream stream = new FileStream(imgLocationDoenca, FileMode.Open, FileAccess.Read);
                    BinaryReader brs_doenca = new BinaryReader(stream);
                    images_doencas = brs_doenca.ReadBytes((int)stream.Length);


                    conexao.Open();

                    comando.CommandText = "INSERT INTO tblDoenca (nome_doenca, nomeCient_doenca, desc_doenca, foto_doenca, cod_func)"
                        + "VALUES (@nome_doenca, @nomeCient_doenca, @desc_doenca, @images_doencas, @cod_func)";
                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@nome_doenca", txtNomeDoenca.Text);
                    comando.Parameters.AddWithValue("@nomeCient_doenca", txtNomeCientDoenca.Text);
                    comando.Parameters.AddWithValue("@desc_doenca", txtDescricaoDoenca.Text);
                    comando.Parameters.Add(new SqlParameter("@images_doencas", images_doencas));
                    comando.Parameters.AddWithValue("@cod_func", codFuncio);


                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblDoencaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblDoenca);
                    conexao.Close();

                    limparCaracDoencas();
                    MessageBox.Show("Cadastro de doenças e pragas realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarDoenca_Click_1(object sender, EventArgs e)
        {
            if (txtNomeDoenca.Text != "" && txtNomeCientDoenca.Text != "" && txtDescricaoDoenca.Text != "")
            {
                try
                {
                    //byte[] images_doencas;
                    //FileStream stream = new FileStream(imgLocationDoenca, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs_doenca = new BinaryReader(stream);
                    //images_doencas = brs_doenca.ReadBytes((int)stream.Length);

                    conexao.Open();

                    comando.CommandText = "UPDATE tblDoenca SET nome_doenca=@nome_doenca, nomeCient_doenca=@nomeCient_doenca, desc_doenca=@desc_doenca WHERE cod_doenca=@cod_doenca";
                    

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_doenca", txtCodigoDoenca.Text);
                    comando.Parameters.AddWithValue("@nome_doenca", txtNomeDoenca.Text);
                    comando.Parameters.AddWithValue("@nomeCient_doenca", txtNomeCientDoenca.Text);
                    comando.Parameters.AddWithValue("@desc_doenca", txtDescricaoDoenca.Text);
                    //comando.Parameters.Add(new SqlParameter("@images_doencas", images_doencas));
                    comando.Parameters.AddWithValue("@cod_func", txtFuncDoenca.Text);


                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblDoencaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblDoenca);
                    conexao.Close();

                    limparCaracDoencas();
                    MessageBox.Show("Atualização realizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirDoenca_Click(object sender, EventArgs e)
        {
            if (txtCodigoDoenca.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "DELETE FROM tblDoencas WHERE codigo_doenca=@codigo_doenca";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@codigo_doenca", txtCodigoDoenca.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblDoencaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblDoenca);
                    conexao.Close();

                    limparCaracDoencas();
                    MessageBox.Show("Dado excluído com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDoencas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDoencas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtDoencaFuncCad.Text = dgvDoencas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNomeDoenca.Text = dgvDoencas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCodigoDoenca.Text = dgvDoencas.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNomeCientDoenca.Text = dgvDoencas.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDescricaoDoenca.Text = dgvDoencas.Rows[e.RowIndex].Cells[4].Value.ToString();
                byte[] bytesDoenca = (byte[])dgvDoencas.Rows[e.RowIndex].Cells[5].Value;
                MemoryStream msDoenca = new MemoryStream(bytesDoenca);
                picDoenca.Image = Image.FromStream(msDoenca);

            }

        }

        private void btnBuscarDoencas_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQuery = "SELECT * FROM tblDoenca WHERE nome_doenca like '%" + txtCodConsultaDoenca.Text + "%' ORDER BY nome_doenca";
                using (SqlDataAdapter daProd = new SqlDataAdapter(sqlQuery, conexao))
                {
                    using (DataTable dtProd = new DataTable())
                    {
                        daProd.Fill(dtProd);
                        dgvDoencas.DataSource = dtProd;
                    }
                }
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                conexao.Close();
            }

        }

        private void btnTotalConsultaDoencas_Click_1(object sender, EventArgs e)
        {
            txtCodConsultaDoenca.Clear();
            {
                conexao.Open();
                var sqlQueryDoenTod = "SELECT * FROM tblDoenca";
                using (SqlDataAdapter daDoenTod = new SqlDataAdapter(sqlQueryDoenTod, conexao))
                {
                    using (DataTable dtDoenTod = new DataTable())
                    {
                        daDoenTod.Fill(dtDoenTod);
                        dgvDoencas.DataSource = dtDoenTod;
                    }
                }
                conexao.Close();
            }
        }


        private void btnLimparDoenca_Click_1(object sender, EventArgs e)
        {
            limparCaracDoencas();
        }

        private void btnSairDoenca_Click(object sender, EventArgs e)
        {
            Close();
        }

        // início dos eventos keypress
        private void txtCodConsultaDoenca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void btnIncluirCliente_Click_1(object sender, EventArgs e)
        { //quando se usa identity no código no banco de dados, não pode citar o txtcódigo nos () do if

            if (txtNomeLoginCliente.Text != "" && txtSenhaLoginCliente.Text != "" && txtNomeCompletoCliente.Text != "" && txtEnderecoCliente.Text != "" && txtCepCliente.Text != "" && txtNumeroCliente.Text != "" && txtBairroCliente.Text != "" && txtEmailCliente.Text != "" && txtCelularCliente.Text != "" && txtCPFCliente.Text != "" && txtComplementoCliente.Text != "" && cmbEstadoCli.Text != "" && cmbMuncClie.Text != "" && cmbStatusClie.Text != "" && cmbTermClie.Text != "")
            {
                try
                {
                    conexao.Open();

                    //comando.CommandText = "OPEN SYMMETRIC KEY" + "DECRYPTION BY CERTIFICATE Certificado WITH PASSWORD = 'SENHA@123'" + "DECLARE @GUID UNIQUEIDENTIFIER = (SELECT KEY_GUID('ChaveSenha'))" + "INSERT INTO tblCliente (nomeLogin_cli, senha_cli, nome_cli, cpf_cli, email_cli, celular_cli, status_cli, endereco_cli, numEnd_cli, complemento_cli, cep_cli, termoSeg_cli, cidade_cli, estado_cli, bairro_cli)"
                    //   + "VALUES (@nomeLogin_cli, ENCRYPTBYKEY(@GUID, (@senha_cli)), @nome_cli, @cpf_cli, @email_cli, @celular_cli, @status_cli, @endereco_cli, @numEnd_cli, @complemento_cli, @cep_cli, @termoSeg_cli, @cidade_cli, @estado_cli, @bairro_cli)" + "CLOSE SYMMETRIC KEY";
                    comando.CommandText = "INSERT INTO tblCliente (nomeLogin_cli, senha_cli, nome_cli, cpf_cli, email_cli, celular_cli, status_cli, endereco_cli, numEnd_cli, complemento_cli, cep_cli, termoSeg_cli, cidade_cli, estado_cli, bairro_cli)"
                       + "VALUES (@nomeLogin_cli, @senha_cli, @nome_cli, @cpf_cli, @email_cli, @celular_cli, @status_cli, @endereco_cli, @numEnd_cli, @complemento_cli, @cep_cli, @termoSeg_cli, @cidade_cli, @estado_cli, @bairro_cli)";
                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@nomeLogin_cli", txtNomeLoginCliente.Text);
                    comando.Parameters.AddWithValue("@senha_cli", txtSenhaLoginCliente.Text);
                    comando.Parameters.AddWithValue("@nome_cli", txtNomeCompletoCliente.Text);
                    comando.Parameters.AddWithValue("@cpf_cli", txtCPFCliente.Text);
                    comando.Parameters.AddWithValue("@endereco_cli", txtEnderecoCliente.Text);
                    comando.Parameters.AddWithValue("@cep_cli", txtCepCliente.Text);
                    comando.Parameters.AddWithValue("@numEnd_cli", txtNumeroCliente.Text);
                    comando.Parameters.AddWithValue("@bairro_cli", txtBairroCliente.Text);
                    comando.Parameters.AddWithValue("@complemento_cli", txtComplementoCliente.Text);
                    comando.Parameters.AddWithValue("@email_cli", txtEmailCliente.Text);
                    comando.Parameters.AddWithValue("@celular_cli", txtCelularCliente.Text);
                    comando.Parameters.AddWithValue("@status_cli", cmbStatusClie.Text);
                    comando.Parameters.AddWithValue("@cidade_cli", cmbMuncClie.SelectedValue);
                    comando.Parameters.AddWithValue("@estado_cli", cmbEstadoCli.SelectedValue);
                    comando.Parameters.AddWithValue("@termoSeg_cli", cmbTermClie.Text);
                    
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblClienteTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblCliente);
                    conexao.Close();

                    limparCaracClientes();
                    MessageBox.Show("Cadastro de clientes realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarCliente_Click_1(object sender, EventArgs e)
        {
            if (txtNomeLoginCliente.Text != "" && txtSenhaLoginCliente.Text != "" && txtNomeCompletoCliente.Text != "" && txtEnderecoCliente.Text != "" && txtCepCliente.Text != "" && txtNumeroCliente.Text != "" && txtBairroCliente.Text != "" && txtEmailCliente.Text != "" && txtCelularCliente.Text != "" && txtCPFCliente.Text != "" && txtComplementoCliente.Text != "" && cmbEstadoCli.Text != "" && cmbMuncClie.Text != "" && cmbStatusClie.Text != "" && cmbTermClie.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "UPDATE tblCliente SET nomeLogin_cli=@nomeLogin_cli, senha_cli=@senha_cli, nome_cli=@nome_cli, cpf_cli=@cpf_cli, email_cli=@email_cli, celular_cli=@celular_cli, status_cli=@status_cli, endereco_cli=@endereco_cli, numEnd_cli=@numEnd_cli, complemento_cli=@complemento_cli, bairro_cli=@bairro_cli, cidade_cli=@cidade_cli, estado_cli=@estado_cli, cep_cli=@cep_cli, termoSeg_cli=@termoSeg_cli WHERE cod_cli=@cod_cli";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_cli", txtCodigoCliente.Text);
                    comando.Parameters.AddWithValue("@nomeLogin_cli", txtNomeLoginCliente.Text);
                    comando.Parameters.AddWithValue("@senha_cli", txtSenhaLoginCliente.Text);
                    comando.Parameters.AddWithValue("@nome_cli", txtNomeCompletoCliente.Text);
                    comando.Parameters.AddWithValue("@cpf_cli", txtCPFCliente.Text);
                    comando.Parameters.AddWithValue("@endereco_cli", txtEnderecoCliente.Text);
                    comando.Parameters.AddWithValue("@cep_cli", txtCepCliente.Text);
                    comando.Parameters.AddWithValue("@numEnd_cli", txtNumeroCliente.Text);
                    comando.Parameters.AddWithValue("@bairro_cli", txtBairroCliente.Text);
                    comando.Parameters.AddWithValue("@complemento_cli", txtComplementoCliente.Text);
                    comando.Parameters.AddWithValue("@email_cli", txtEmailCliente.Text);
                    comando.Parameters.AddWithValue("@celular_cli", txtCelularCliente.Text);
                    comando.Parameters.AddWithValue("@status_cli", cmbStatusClie.Text);
                    comando.Parameters.AddWithValue("@cidade_cli", cmbMuncClie.SelectedValue);
                    comando.Parameters.AddWithValue("@estado_cli", cmbEstadoCli.SelectedValue);
                    comando.Parameters.AddWithValue("@termoSeg_cli", cmbTermClie.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblClienteTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblCliente);
                    conexao.Close();

                    limparCaracClientes();
                    MessageBox.Show("Cadastro de clientes atualizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    //MessageBox.Show(ee.Message);
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "DELETE FROM tblCadastroCliente WHERE codigo_cliente=@codigo_cliente";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@codigo_cliente", txtCodigoCliente.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblClienteTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblCliente);
                    conexao.Close();

                    limparCaracDoencas();
                    MessageBox.Show("Dado excluído com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_cliente = "SELECT codigo_cliente, usuaLogin_cliente, senhaLogin_cliente, nome_cliente, cpf_cliente, endereco_cliente, cep_cliente, numero_cliente, bairro_cliente, complemento_cliente, cidade_cliente, estado_cliente, email_cliente, celular_cliente, status FROM tblCadastroCliente WHERE codigo_cliente = '" + Convert.ToInt32(txtCodConsultaCliente.Text) + "'";
                if (conexao.State != ConnectionState.Open)
                {
                    conexao.Open();
                    comando = new SqlCommand(sql_cliente, conexao);

                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        txtCodigoCliente.Text = reader[0].ToString();
                        txtNomeLoginCliente.Text = reader[1].ToString();
                        txtSenhaLoginCliente.Text = reader[2].ToString();
                        txtNomeCompletoCliente.Text = reader[3].ToString();
                        txtCPFCliente.Text = reader[4].ToString();
                        txtEnderecoCliente.Text = reader[5].ToString();
                        txtNumeroCliente.Text = reader[7].ToString();
                        txtComplementoCliente.Text = reader[9].ToString();
                        txtBairroCliente.Text = reader[8].ToString();
                        txtCepCliente.Text = reader[6].ToString();
                        txtEmailCliente.Text = reader[12].ToString();
                        txtCelularCliente.Text = reader[13].ToString();
                        cmbStatusClie.Text = reader[14].ToString();

                    }
                    conexao.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void txtNumeroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtCepCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtCelularCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtCodConsultaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                picPlanta.ImageLocation = imgLocation;
            }
        }

        private void btnSelecionarDoen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocationDoenca = dialog.FileName.ToString();
                picDoenca.ImageLocation = imgLocationDoenca;
            }
        }



        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblClienteTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblCliente);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void btnSelecProd_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocationProd = dialog.FileName.ToString();
                picProduto.ImageLocation = imgLocationProd;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluitFAQ_Click_1(object sender, EventArgs e)
        {
            
            if (txtPerguntaFAQ.Text != "" && txtRespostaFAQ.Text != "" && cmbStatusFAQ.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "INSERT INTO tblFaq (pergunta_faq, resposta_faq, status_faq, cod_func)"
                        + "VALUES (@pergunta_faq, @resposta_faq, @status_faq, @cod_func)";
                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@pergunta_faq", txtPerguntaFAQ.Text);
                    comando.Parameters.AddWithValue("@resposta_faq", txtRespostaFAQ.Text);
                    comando.Parameters.AddWithValue("@status_faq", cmbStatusFAQ.Text);
                    comando.Parameters.AddWithValue("@cod_func", codFuncio);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblFaqTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblFaq);
                    conexao.Close();

                    limparCaracFAQ();
                    MessageBox.Show("Cadastro do FAQ realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFAQ_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvFAQ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtCodFAQ.Text = dgvFAQ.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbStatusFAQ.Text = dgvFAQ.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFAQFunCad.Text = dgvFAQ.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPerguntaFAQ.Text = dgvFAQ.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtRespostaFAQ.Text = dgvFAQ.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void btnTotalConsultasFAQ_Click_1(object sender, EventArgs e)
        {
            {
                conexao.Open();
                var sqlQueryFaqTod = "SELECT * FROM tblFaq";
                using (SqlDataAdapter daFaqTod = new SqlDataAdapter(sqlQueryFaqTod, conexao))
                {
                    using (DataTable dtFaqTod = new DataTable())
                    {
                        daFaqTod.Fill(dtFaqTod);
                        dgvFAQ.DataSource = dtFaqTod;
                    }
                }
                conexao.Close();
            }
        }

        private void btnAtualizarFAQ_Click_1(object sender, EventArgs e)
        {
            if (txtPerguntaFAQ.Text != "" && txtRespostaFAQ.Text != "" && cmbStatusFAQ.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "UPDATE tblFaq SET pergunta_faq=@pergunta_faq, resposta_faq=@resposta_faq, status_faq=@status_faq WHERE cod_faq=@cod_faq";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_faq", txtCodFAQ.Text);
                    comando.Parameters.AddWithValue("@pergunta_faq", txtPerguntaFAQ.Text);
                    comando.Parameters.AddWithValue("@resposta_faq", txtRespostaFAQ.Text);
                    comando.Parameters.AddWithValue("@status_faq", cmbStatusFAQ.Text);
                    comando.Parameters.AddWithValue("@cod_func", txtFAQFunCad.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblFaqTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblFaq);
                    conexao.Close();

                    limparCaracFAQ();
                    MessageBox.Show("Atualização realizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }


        private void btnLimparFAQ_Click_1(object sender, EventArgs e)
        {
            limparCaracFAQ();
        }

        private void btnBuscFAQ_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryFAQ = "SELECT * FROM tblFaq WHERE status_faq LIKE '" + cbmConsStatusFAQ.Text + "'";
                using (SqlDataAdapter daFaq = new SqlDataAdapter(sqlQueryFAQ, conexao))
                {
                    using (DataTable dtFaq = new DataTable())
                    {
                        daFaq.Fill(dtFaq);
                        dgvFAQ.DataSource = dtFaq;
                    }
                }
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                conexao.Close();
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet.tblPedido_Produto'. Você pode movê-la ou removê-la conforme necessário.
            this.tblPedido_ProdutoTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblPedido_Produto);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet.tblPedido'. Você pode movê-la ou removê-la conforme necessário.
            this.tblPedidoTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblPedido);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet1.tblMunicipio'. Você pode movê-la ou removê-la conforme necessário.
            this.tblMunicipioTableAdapter.Fill(this.consultoriaPlantasTCCDataSet1.tblMunicipio);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet1.tblCliente'. Você pode movê-la ou removê-la conforme necessário.
            //this.tblClienteTableAdapter.Fill(this.consultoriaPlantasTCCDataSet1.tblCliente);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet1.tblFuncionario'. Você pode movê-la ou removê-la conforme necessário.
            this.tblFuncionarioTableAdapter.Fill(this.consultoriaPlantasTCCDataSet1.tblFuncionario);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet.tblMunicipio'. Você pode movê-la ou removê-la conforme necessário.
            this.tblMunicipioTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblMunicipio);
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet.tblEstado'. Você pode movê-la ou removê-la conforme necessário.
            this.tblEstadoTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblEstado);

            carregaMunicipio();
            carregaEstado();
            limparCaracClientes();
            carregaPlanta();
            carregaDoenca();
            carregaCliente();
            carregaProduto();
            carregaFaq();
            carregaFunc();
            carregaProdAtiv();
            carregaProdInativ();
            carregaFaqAtiv();
            carregaFaqInat();
            carregaClieAtiv();
            carregaClieInat();
            topVendas();
        }

        private void carregaMunicipio()
        {
            DataTable tb = new DataTable("tblMunicipio");
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT cod_municipio, nome_municipio FROM tblMunicipio ORDER BY nome_municipio", conexao);
            SqlDataReader dr = comando.ExecuteReader();
            tb.Load(dr);
            cmbMuncClie.DisplayMember = "nome_municipio";
            cmbMuncClie.ValueMember = "cod_municipio";
            cmbMuncClie.DataSource = tb;

            conexao.Close();
        }

        private void carregaEstado()
        {
            DataTable tbl = new DataTable("tblEstado");
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT cod_estado, nome_estado FROM tblEstado ORDER BY nome_estado", conexao);
            SqlDataReader dr1 = comando.ExecuteReader();
            tbl.Load(dr1);
            cmbEstadoCli.DisplayMember = "nome_estado";
            cmbEstadoCli.ValueMember = "cod_estado";
            cmbEstadoCli.DataSource = tbl;

            conexao.Close();
        }

        private void carregaPlanta()
        {
            conexao.Open();
            SqlCommand contPlanta = new SqlCommand("SELECT COUNT(cod_planta) FROM tblPlanta", conexao);
            var countPlanta = contPlanta.ExecuteScalar();
            txtTotPlantas.Text = countPlanta.ToString();
            conexao.Close();
        }

        private void carregaDoenca()
        {
            conexao.Open();
            SqlCommand contDoenca = new SqlCommand("SELECT COUNT(cod_doenca) FROM tblDoenca", conexao);
            var countDoenca = contDoenca.ExecuteScalar();
            txtDoenca.Text = countDoenca.ToString();
            conexao.Close();
        }

        private void carregaCliente()
        {
            conexao.Open();
            SqlCommand contClie = new SqlCommand("SELECT COUNT(cod_cli) FROM tblCliente", conexao);
            var countClie = contClie.ExecuteScalar();
            txtTotClie.Text = countClie.ToString();
            conexao.Close();
        }

        private void carregaProduto()
        {
            conexao.Open();
            SqlCommand contProd = new SqlCommand("SELECT COUNT(cod_prod) FROM tblProduto", conexao);
            var countProd = contProd.ExecuteScalar();
            txtTotProd.Text = countProd.ToString();
            conexao.Close();
        }

        private void carregaFaq()
        {
            conexao.Open();
            SqlCommand contFaq = new SqlCommand("SELECT COUNT(cod_faq) FROM tblFaq", conexao);
            var countFaq = contFaq.ExecuteScalar();
            txtTotFAQ.Text = countFaq.ToString();
            conexao.Close();
        }

        private void carregaFunc()
        {
            conexao.Open();
            SqlCommand contFunc = new SqlCommand("SELECT COUNT(cod_func) FROM tblFuncionario", conexao);
            var countFunc = contFunc.ExecuteScalar();
            txtTotFunc.Text = countFunc.ToString();
            conexao.Close();
        }


        private void carregaProdAtiv()
        {
            conexao.Open();
            SqlCommand contProdAtiv = new SqlCommand("SELECT COUNT(cod_prod) FROM tblProduto WHERE status_prod = 'Disponível'", conexao);
            var countProdAtiv = contProdAtiv.ExecuteScalar();
            txtProdAtivo.Text = countProdAtiv.ToString();
            conexao.Close();
        }

        private void carregaProdInativ()
        {
            conexao.Open();
            SqlCommand contProdInat = new SqlCommand("SELECT COUNT(cod_prod) FROM tblProduto WHERE status_prod = 'Indisponível'", conexao);
            var countProdInat = contProdInat.ExecuteScalar();
            txtProdInat.Text = countProdInat.ToString();
            conexao.Close();
        }

        private void carregaFaqAtiv()
        {
            conexao.Open();
            SqlCommand contFaqAtiv = new SqlCommand("SELECT COUNT(cod_faq) FROM tblFaq WHERE status_faq = 'Ativo'", conexao);
            var countFaqAtiv = contFaqAtiv.ExecuteScalar();
            txtFaqAtiv.Text = countFaqAtiv.ToString();
            conexao.Close();
        }

        private void carregaFaqInat()
        {
            conexao.Open();
            SqlCommand contFaqInat = new SqlCommand("SELECT COUNT(cod_faq) FROM tblFaq WHERE status_faq = 'Inativo'", conexao);
            var countFaqInat = contFaqInat.ExecuteScalar();
            txtFaqInat.Text = countFaqInat.ToString();
            conexao.Close();
        }

        private void carregaClieAtiv()
        {
            conexao.Open();
            SqlCommand contClieAtiv = new SqlCommand("SELECT COUNT(cod_cli) FROM tblCliente WHERE status_cli = 'Ativo'", conexao);
            var countClieAtiv = contClieAtiv.ExecuteScalar();
            txtClieAtiv.Text = countClieAtiv.ToString();
            conexao.Close();
        }

        private void carregaClieInat()
        {
            conexao.Open();
            SqlCommand contClieInat = new SqlCommand("SELECT COUNT(cod_cli) FROM tblCliente WHERE status_cli = 'Inativo'", conexao);
            var countClieInat = contClieInat.ExecuteScalar();
            txtClieInat.Text = countClieInat.ToString();
            conexao.Close();
        }

        private void topVendas()
        {
            conexao.Open();
            SqlCommand cmdTopVendas = new SqlCommand("SELECT TOP 10  PP.cod_prod, P.nome_prod, SUM(PP.qtd_prod) AS TOTAL, P.status_prod FROM tblPedido_Produto PP INNER JOIN tblPedido AS PE ON PE.cod_ped = PP.cod_ped AND PE.status_ped = 'Enviado' OR PE.cod_ped = PP.cod_ped AND PE.status_ped = 'Pago' OR PE.cod_ped = PP.cod_ped AND PE.status_ped = 'Aguardando Envio' INNER JOIN tblProduto AS P ON PP.cod_prod = P.cod_prod GROUP BY PP.cod_prod, P.status_prod, P.nome_prod ORDER BY TOTAL DESC", conexao);
            SqlDataAdapter daVendas = new SqlDataAdapter();
            daVendas.SelectCommand = cmdTopVendas;
            DataTable dtVendas = new DataTable();
            daVendas.Fill(dtVendas);
            dgvTopVendas.DataSource = dtVendas;
            dgvTopVendas.Columns[0].HeaderText = "Cód Produto";
            dgvTopVendas.Columns[0].Width = 100;
            dgvTopVendas.Columns[1].HeaderText = "Nome Produto";
            dgvTopVendas.Columns[1].Width = 260;
            dgvTopVendas.Columns[2].HeaderText = "Quantidade Vendida";
            dgvTopVendas.Columns[2].Width = 150;
            dgvTopVendas.Columns[3].HeaderText = "Status Produto";
            dgvTopVendas.Columns[3].Width = 200;
            conexao.Close();
        }


        private void btnIncluirPlanta_Click(object sender, EventArgs e)
        {
            if (txtNomePlanta.Text != "" && txtNomCientPlanta.Text != "" && txtDescPlanta.Text != "" && picPlanta.Image != null && txtFuncPlanta.Text != "")
            {
                try
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    images = brs.ReadBytes((int)stream.Length);

                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "INSERT INTO tblPlanta(nome_planta, nomeCient_planta, desc_planta, foto_planta, cod_func)" + "VALUES(@nome_planta, @nomeCient_planta, @desc_planta, @images, @cod_func)";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nome_planta", txtNomePlanta.Text);
                    comando.Parameters.AddWithValue("@nomeCient_planta", txtNomCientPlanta.Text);
                    comando.Parameters.AddWithValue("@desc_planta", txtDescPlanta.Text);
                    comando.Parameters.Add(new SqlParameter("@images", images));
                    comando.Parameters.AddWithValue("@cod_func", codFuncio);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblPlantaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblPlanta);
                    conexao.Close();

                    limparCaracPlantas();
                    MessageBox.Show("Cadastro de plantas realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImgPlanta_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                picPlanta.ImageLocation = imgLocation;
            }
        }

        private void btnAtualizarPlanta_Click(object sender, EventArgs e)
        {
            if (txtNomePlanta.Text != "" && txtNomCientPlanta.Text != "" && txtDescPlanta.Text != "")
            {
                try
                {
                    //byte[] images = null;
                    //FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs = new BinaryReader(stream);
                    //images = brs.ReadBytes((int)stream.Length);

                    comando.Connection = conexao;
                    conexao.Open();

                    //comando.CommandText = "UPDATE tblPlanta SET nome_planta=@nome_planta, nomeCient_planta=@nomeCient_planta, desc_planta=@desc_planta, foto_planta=@images WHERE cod_planta=@cod_planta";
                    comando.CommandText = "UPDATE tblPlanta SET nome_planta=@nome_planta, nomeCient_planta=@nomeCient_planta, desc_planta=@desc_planta WHERE cod_planta=@cod_planta";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_planta", txtCodPlanta.Text);
                    comando.Parameters.AddWithValue("@nome_planta", txtNomePlanta.Text);
                    comando.Parameters.AddWithValue("@nomeCient_planta", txtNomCientPlanta.Text);
                    comando.Parameters.AddWithValue("@desc_planta", txtDescPlanta.Text);
                    //comando.Parameters.Add(new SqlParameter("@images", images));
                    comando.Parameters.AddWithValue("@cod_func", txtFuncCadPlanta.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblPlantaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblPlanta);
                    conexao.Close();

                    limparCaracPlantas();
                    MessageBox.Show("Atualização realizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPlanta_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPlanta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtCodPlanta.Text = dgvPlanta.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescPlanta.Text = dgvPlanta.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNomePlanta.Text = dgvPlanta.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNomCientPlanta.Text = dgvPlanta.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtFuncCadPlanta.Text = dgvPlanta.Rows[e.RowIndex].Cells[1].Value.ToString();
                byte[] bytes = (byte[])dgvPlanta.Rows[e.RowIndex].Cells[5].Value;
                MemoryStream ms = new MemoryStream(bytes);
                picPlanta.Image = Image.FromStream(ms);

            }

        }

        private void btnTodRegPlanta_Click(object sender, EventArgs e)
        {
            txtConsPlanta.Clear();
            {
                conexao.Open();
                var sqlQueryPlantTod = "SELECT * FROM tblPlanta";
                using (SqlDataAdapter daPlantTod = new SqlDataAdapter(sqlQueryPlantTod, conexao))
                {
                    using (DataTable dtPlanTod = new DataTable())
                    {
                        daPlantTod.Fill(dtPlanTod);
                        dgvPlanta.DataSource = dtPlanTod;
                    }
                }
                conexao.Close();
            }
        }

        private void btnLimparPlanta_Click_1(object sender, EventArgs e)
        {
            limparCaracPlantas();
        }

        private void btnSairPlanta_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluirProd_Click_1(object sender, EventArgs e)
        {
            if (txtNomeProd.Text != "" && txtDescProd.Text != "" && txtCustProd.Text != "" && txtVendProd.Text != "" && txtEstProd.Text != "" && cmbStatusProd.Text != "" && picProduto.Image != null)
            {
                try
                {
                    byte[] images_prod = null;
                    FileStream stream_prod = new FileStream(imgLocationProd, FileMode.Open, FileAccess.Read);
                    BinaryReader brs_prod = new BinaryReader(stream_prod);
                    images_prod = brs_prod.ReadBytes((int)stream_prod.Length);

                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "INSERT INTO tblProduto (nome_prod, precoCusto_prod, precoVenda_prod, desc_prod, estoq_prod, foto_prod, status_prod)" + "VALUES (@nome_prod, @precoCusto_prod, @precoVenda_prod, @desc_prod, @estoq_prod, @images_prod, @status_prod)";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nome_prod", txtNomeProd.Text);
                    comando.Parameters.AddWithValue("@precoCusto_prod", Convert.ToDecimal(txtCustProd.Text));  //usar o replace aqui para não dar erro na hora de realizar o uptade por conta dos valores e diferença entre vírgula e ponto
                    comando.Parameters.AddWithValue("@precoVenda_prod", Convert.ToDecimal(txtVendProd.Text));  //usar o replace aqui para não dar erro na hora de realizar o uptade por conta dos valores e diferença entre vírgula e ponto
                    comando.Parameters.AddWithValue("@desc_prod", txtDescProd.Text);
                    comando.Parameters.AddWithValue("@estoq_prod", txtEstProd.Text);
                    comando.Parameters.Add(new SqlParameter("@images_prod", images_prod));
                    comando.Parameters.AddWithValue("@status_prod", cmbStatusProd.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblProdutoTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblProduto);
                    conexao.Close();

                    limparCaracProd();
                    MessageBox.Show("Cadastro de plantas realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImgProd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocationProd = dialog.FileName.ToString();
                picProduto.ImageLocation = imgLocationProd;
            }
        }

        private void btnSairProd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscPlanta_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQuery = "SELECT * FROM tblPlanta WHERE nome_planta like '%" + txtConsPlanta.Text + "%' ORDER BY nome_planta";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexao))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dgvPlanta.DataSource = dt;
                    }
                }
                conexao.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }
        }

        private void btnSairFAQ_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimparCliente_Click_1(object sender, EventArgs e)
        {
            limparCaracClientes();
        }

        private void btnSairCliente_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) 
            { 
                txtNomeProd.Text = dgvProduto.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCustProd.Text = dgvProduto.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtVendProd.Text = dgvProduto.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDescProd.Text = dgvProduto.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEstProd.Text = dgvProduto.Rows[e.RowIndex].Cells[4].Value.ToString();
                byte[] bytesProd = (byte[])dgvProduto.Rows[e.RowIndex].Cells[5].Value;
                MemoryStream msProd = new MemoryStream(bytesProd);
                picProduto.Image = Image.FromStream(msProd);
                cmbStatusProd.Text = dgvProduto.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCodProduto.Text = dgvProduto.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        //UPDATE tblPlanta SET nome_planta=@nome_planta, nomeCient_planta=@nomeCient_planta, desc_planta=@desc_planta, foto_planta=@images WHERE cod_planta=@cod_planta

        private void btnAtualProd_Click(object sender, EventArgs e)
        {
            if (txtNomeProd.Text != "" && txtDescProd.Text != "" && txtCustProd.Text != "" && txtVendProd.Text != "" && txtEstProd.Text != "" && cmbStatusProd.Text != "")
            {
                try
                {
                    //byte[] images_prod = null;
                    //FileStream stream_prod = new FileStream(imgLocationProd, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs_prod = new BinaryReader(stream_prod);
                    //images_prod = brs_prod.ReadBytes((int)stream_prod.Length);

                    comando.Connection = conexao;
                    conexao.Open();
                    //comando.CommandText = "UPDATE tblProduto SET nome_prod=@nome_prod, precoCusto_prod=@precoCusto_prod, precoVenda_prod=@precoVenda_prod, desc_prod=@desc_prod, estoq_prod=@estoq_prod, foto_prod=@images_prod, status_prod=@status_prod WHERE cod_prod=@cod_prod";

                    comando.CommandText = "UPDATE tblProduto SET nome_prod=@nome_prod, precoCusto_prod=@precoCusto_prod, precoVenda_prod=@precoVenda_prod, desc_prod=@desc_prod, estoq_prod=@estoq_prod, status_prod=@status_prod WHERE cod_prod=@cod_prod";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@cod_prod", txtCodProduto.Text);
                    comando.Parameters.AddWithValue("@nome_prod", txtNomeProd.Text);
                    comando.Parameters.AddWithValue("@precoCusto_prod", Convert.ToDecimal(txtCustProd.Text));  //usar o replace aqui para não dar erro na hora de realizar o uptade por conta dos valores e diferença entre vírgula e ponto
                    comando.Parameters.AddWithValue("@precoVenda_prod", Convert.ToDecimal(txtVendProd.Text));  //usar o replace aqui para não dar erro na hora de realizar o uptade por conta dos valores e diferença entre vírgula e ponto
                    comando.Parameters.AddWithValue("@desc_prod", txtDescProd.Text);
                    comando.Parameters.AddWithValue("@estoq_prod", txtEstProd.Text);
                    //comando.Parameters.Add(new SqlParameter("@images_prod", images_prod));
                    comando.Parameters.AddWithValue("@status_prod", cmbStatusProd.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblProdutoTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblProduto);
                    conexao.Close();

                    limparCaracProd();
                    MessageBox.Show("Atualização realizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSairDoenca_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsCPFCliente_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryCli = "SELECT C.cod_cli, C.nomeLogin_cli, C.senha_cli, C.nome_cli, C.cpf_cli, C.email_cli, C.celular_cli, C.status_cli, C.endereco_cli, C.numEnd_cli, C.complemento_cli, C.bairro_cli, E.nome_estado, M.nome_municipio, C.cep_cli, C.termoSeg_cli, C.dtCad_cli FROM tblCliente AS C INNER JOIN tblMunicipio AS M ON C.cidade_cli = M.cod_municipio INNER JOIN tblEstado AS E ON C.estado_cli = E.cod_estado WHERE cpf_cli = " + txtCodConsultaCliente.Text;
                using (SqlDataAdapter daCli = new SqlDataAdapter(sqlQueryCli, conexao))
                {
                    using (DataTable dtCli = new DataTable())
                    {
                        daCli.Fill(dtCli);
                        dgvClientes.DataSource = dtCli;
                        dgvClientes.Columns[0].HeaderText = "COD";
                        dgvClientes.Columns[1].HeaderText = "Nome Login";
                        dgvClientes.Columns[2].HeaderText = "Senha Cliente";
                        dgvClientes.Columns[2].Visible = false;
                        dgvClientes.Columns[3].HeaderText = "Nome Cliente";
                        dgvClientes.Columns[4].HeaderText = "CPF Cliente";
                        dgvClientes.Columns[5].HeaderText = "Email Cliente";
                        dgvClientes.Columns[6].HeaderText = "Celular Cliente";
                        dgvClientes.Columns[7].HeaderText = "Status Cliente";
                        dgvClientes.Columns[8].HeaderText = "Endereço Cliente";
                        dgvClientes.Columns[9].HeaderText = "Núm Cliente";
                        dgvClientes.Columns[10].HeaderText = "Compl Cliente";
                        dgvClientes.Columns[11].HeaderText = "Bairro";
                        dgvClientes.Columns[12].HeaderText = "Estado";
                        dgvClientes.Columns[13].HeaderText = "Múnicipio";
                        dgvClientes.Columns[14].HeaderText = "CEP";
                        dgvClientes.Columns[15].HeaderText = "Termo";
                        dgvClientes.Columns[16].HeaderText = "Dt Cadastro";
                    }
                }
                conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }
        }

        private void btnConsultaTotalClientes_Click_1(object sender, EventArgs e)
        {
            conexao.Open();
            SqlCommand cmd = new SqlCommand("SELECT C.cod_cli, C.nomeLogin_cli, C.senha_cli, C.nome_cli, C.cpf_cli, C.email_cli, C.celular_cli, C.status_cli, C.endereco_cli, C.numEnd_cli, C.complemento_cli, C.bairro_cli, E.nome_estado, M.nome_municipio, C.cep_cli, C.termoSeg_cli, C.dtCad_cli FROM tblCliente AS C INNER JOIN tblMunicipio AS M ON C.cidade_cli = M.cod_municipio INNER JOIN tblEstado AS E ON C.estado_cli = E.cod_estado", conexao);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvClientes.DataSource = dt;
            dgvClientes.Columns[0].HeaderText = "COD";
            dgvClientes.Columns[1].HeaderText = "Nome Login";
            dgvClientes.Columns[2].HeaderText = "Senha Cliente";
            dgvClientes.Columns[2].Visible = false;
            dgvClientes.Columns[3].HeaderText = "Nome Cliente";
            dgvClientes.Columns[4].HeaderText = "CPF Cliente";
            dgvClientes.Columns[5].HeaderText = "Email Cliente";
            dgvClientes.Columns[6].HeaderText = "Celular Cliente";
            dgvClientes.Columns[7].HeaderText = "Status Cliente";
            dgvClientes.Columns[8].HeaderText = "Endereço Cliente";
            dgvClientes.Columns[9].HeaderText = "Núm Cliente";
            dgvClientes.Columns[10].HeaderText = "Compl Cliente";
            dgvClientes.Columns[11].HeaderText = "Bairro";
            dgvClientes.Columns[12].HeaderText = "Estado";
            dgvClientes.Columns[13].HeaderText = "Múnicipio";
            dgvClientes.Columns[14].HeaderText = "CEP";
            dgvClientes.Columns[15].HeaderText = "Termo";
            dgvClientes.Columns[16].HeaderText = "Dt Cadastro";
            conexao.Close();
        }

        private void btnTodRegProd_Click(object sender, EventArgs e)
        {
            txtConsProd.Clear();
            {
                conexao.Open();
                var sqlQueryProdTod = "SELECT * FROM tblProduto";
                using (SqlDataAdapter daProdTod = new SqlDataAdapter(sqlQueryProdTod, conexao))
                {
                    using (DataTable dtProdTod = new DataTable())
                    {
                        daProdTod.Fill(dtProdTod);
                        dgvProduto.DataSource = dtProdTod;
                    }
                }
                conexao.Close();
            }
        }

        private void btnConsProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryProd = "SELECT * FROM tblProduto WHERE nome_prod LIKE '%" + txtConsProd.Text + "%'";
                using (SqlDataAdapter daProd = new SqlDataAdapter(sqlQueryProd, conexao))
                {
                    using (DataTable dtProd = new DataTable())
                    {
                        daProd.Fill(dtProd);
                        dgvProduto.DataSource = dtProd;
                    }
                }
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                conexao.Close();
            }
        }

        private void BtnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryClie = "SELECT C.cod_cli, C.nomeLogin_cli, C.senha_cli, C.nome_cli, C.cpf_cli, C.email_cli, C.celular_cli, C.status_cli, C.endereco_cli, C.numEnd_cli, C.complemento_cli, C.bairro_cli, E.nome_estado, M.nome_municipio, C.cep_cli, C.termoSeg_cli, C.dtCad_cli FROM tblCliente AS C INNER JOIN tblMunicipio AS M ON C.cidade_cli = M.cod_municipio INNER JOIN tblEstado AS E ON C.estado_cli = E.cod_estado WHERE status_cli LIKE '" + cmbStatClie.Text + "'";
                using (SqlDataAdapter daClie = new SqlDataAdapter(sqlQueryClie, conexao))
                {
                    using (DataTable dtClie = new DataTable())
                    {
                        daClie.Fill(dtClie);
                        dgvClientes.DataSource = dtClie;
                        dgvClientes.Columns[0].HeaderText = "COD";
                        dgvClientes.Columns[1].HeaderText = "Nome Login";
                        dgvClientes.Columns[2].HeaderText = "Senha Cliente";
                        dgvClientes.Columns[2].Visible = false;
                        dgvClientes.Columns[3].HeaderText = "Nome Cliente";
                        dgvClientes.Columns[4].HeaderText = "CPF Cliente";
                        dgvClientes.Columns[5].HeaderText = "Email Cliente";
                        dgvClientes.Columns[6].HeaderText = "Celular Cliente";
                        dgvClientes.Columns[7].HeaderText = "Status Cliente";
                        dgvClientes.Columns[8].HeaderText = "Endereço Cliente";
                        dgvClientes.Columns[9].HeaderText = "Núm Cliente";
                        dgvClientes.Columns[10].HeaderText = "Compl Cliente";
                        dgvClientes.Columns[11].HeaderText = "Bairro";
                        dgvClientes.Columns[12].HeaderText = "Estado";
                        dgvClientes.Columns[13].HeaderText = "Múnicipio";
                        dgvClientes.Columns[14].HeaderText = "CEP";
                        dgvClientes.Columns[15].HeaderText = "Termo";
                        dgvClientes.Columns[16].HeaderText = "Dt Cadastro";
                    }
                }
                conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }
        }

        private void BtnBuscProd_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryProd = "SELECT * FROM tblProduto WHERE status_prod LIKE '" + cmbConsProd.Text + "'";
                using (SqlDataAdapter daProd = new SqlDataAdapter(sqlQueryProd, conexao))
                {
                    using (DataTable dtProd = new DataTable())
                    {
                        daProd.Fill(dtProd);
                        dgvProduto.DataSource = dtProd;
                    }
                }
                conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }
        }

        private void DgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetPed_Click(object sender, EventArgs e)
        {
            conexao.Open();
            SqlCommand cmd = new SqlCommand ("SELECT P.cod_ped, P.status_ped, C.nome_cli, C.cpf_cli, C.endereco_cli, C.bairro_cli, C.numEnd_cli, M.nome_municipio, E.nome_estado, C.complemento_cli, C.cep_cli, P.dtCad_ped FROM tblPedido AS P INNER JOIN tblCliente AS C ON P.cod_cli = C.cod_cli INNER JOIN tblMunicipio AS M ON M.cod_municipio = C.cidade_cli INNER JOIN tblEstado AS E ON E.cod_estado = C.estado_cli", conexao);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDetPed.DataSource = dt;
            dgvDetPed.Columns[0].HeaderText = "Cód Ped";
            dgvDetPed.Columns[1].HeaderText = "Status";
            dgvDetPed.Columns[2].HeaderText = "Nome Cliente";
            dgvDetPed.Columns[3].HeaderText = "CPF Cliente";
            dgvDetPed.Columns[4].HeaderText = "Endereço";
            dgvDetPed.Columns[5].HeaderText = "Bairro";
            dgvDetPed.Columns[6].HeaderText = "Número";
            dgvDetPed.Columns[7].HeaderText = "Múnicipio";
            dgvDetPed.Columns[8].HeaderText = "Estado";
            dgvDetPed.Columns[9].HeaderText = "Complemento";
            dgvDetPed.Columns[10].HeaderText = "CEP";
            dgvDetPed.Columns[11].HeaderText = "Dt Pedido";
            conexao.Close();

        }

        private void btnConsPed_Click(object sender, EventArgs e)
        {
            try
            {
                
                conexao.Open();
                SqlCommand cmdConsPedCli = new SqlCommand("SELECT  P.cod_ped, P.status_ped, C.nome_cli, C.cpf_cli, C.endereco_cli, C.bairro_cli, C.numEnd_cli, M.nome_municipio, E.nome_estado, C.complemento_cli, C.cep_cli, P.dtCad_ped FROM tblPedido AS P INNER JOIN tblCliente AS C ON P.cod_cli = C.cod_cli AND cod_ped = '" + txtConsPed.Text + "' INNER JOIN tblMunicipio AS M ON M.cod_municipio = C.cidade_cli INNER JOIN tblEstado AS E ON E.cod_estado = C.estado_cli", conexao);
                SqlDataAdapter daConsPedCli = new SqlDataAdapter();
                daConsPedCli.SelectCommand = cmdConsPedCli;
                DataTable dtConsPedCli = new DataTable();
                daConsPedCli.Fill(dtConsPedCli);
                dgvDetPed.DataSource = dtConsPedCli;
                dgvDetPed.Columns[0].HeaderText = "Cód Ped";
                dgvDetPed.Columns[1].HeaderText = "Status";
                dgvDetPed.Columns[1].Width = 250;
                dgvDetPed.Columns[2].HeaderText = "Nome Cliente";
                dgvDetPed.Columns[2].Width = 200;
                dgvDetPed.Columns[3].HeaderText = "CPF Cliente";
                dgvDetPed.Columns[3].Width = 200;
                dgvDetPed.Columns[4].HeaderText = "Endereço";
                dgvDetPed.Columns[4].Width = 200;
                dgvDetPed.Columns[5].HeaderText = "Bairro";
                dgvDetPed.Columns[5].Width = 200;
                dgvDetPed.Columns[6].HeaderText = "Número";
                dgvDetPed.Columns[6].Width = 200;
                dgvDetPed.Columns[7].HeaderText = "Múnicipio";
                dgvDetPed.Columns[7].Width = 200;
                dgvDetPed.Columns[8].HeaderText = "Estado";
                dgvDetPed.Columns[8].Width = 200;
                dgvDetPed.Columns[9].HeaderText = "Complemento";
                dgvDetPed.Columns[9].Width = 200;
                dgvDetPed.Columns[10].HeaderText = "CEP";
                dgvDetPed.Columns[10].Width = 200;
                dgvDetPed.Columns[11].HeaderText = "Dt Pedido";
                dgvDetPed.Columns[11].Width = 200;
                conexao.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }

            try
            {

                conexao.Open();
                SqlCommand cmdConsPedProd = new SqlCommand("SELECT P.cod_ped, PP.cod_prod, PR.nome_prod, PP.qtd_prod, PP.precoItem_ped FROM tblPedido AS P  INNER JOIN tblPedido_Produto AS PP ON P.cod_ped = PP.cod_ped AND P.cod_ped = '" + txtConsPed.Text + "' INNER JOIN tblProduto AS PR ON PP.cod_prod = PR.cod_prod ", conexao);
                SqlDataAdapter daConsPedProd = new SqlDataAdapter();
                daConsPedProd.SelectCommand = cmdConsPedProd;
                DataTable dtConsPedProd = new DataTable();
                daConsPedProd.Fill(dtConsPedProd);
                dgvDetProd.DataSource = dtConsPedProd;
                dgvDetProd.Columns[0].HeaderText = "Cód Ped";
                dgvDetProd.Columns[1].HeaderText = "Código Produto";
                dgvDetProd.Columns[1].Width = 150;
                dgvDetProd.Columns[2].HeaderText = "Nome Produto";
                dgvDetProd.Columns[2].Width = 300;
                dgvDetProd.Columns[3].HeaderText = "Quantidade Produto";
                dgvDetProd.Columns[3].Width = 175;
                dgvDetProd.Columns[4].HeaderText = "Preço Produto";
                dgvDetProd.Columns[4].Width = 175;
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                conexao.Close();
            }

        }

        private void btnConsCPFClie_Click(object sender, EventArgs e)
        {
            try
            {
                limparPedProd();
                conexao.Open();
                SqlCommand cmdConsCPFCli = new SqlCommand("SELECT  P.cod_ped, P.status_ped, C.nome_cli, C.cpf_cli, C.endereco_cli, C.bairro_cli, C.numEnd_cli, M.nome_municipio, E.nome_estado, C.complemento_cli, C.cep_cli, P.dtCad_ped FROM tblPedido AS P INNER JOIN tblCliente AS C ON P.cod_cli = C.cod_cli AND cpf_cli = '" + txtConsCPFClie.Text + "' INNER JOIN tblMunicipio AS M ON M.cod_municipio = C.cidade_cli INNER JOIN tblEstado AS E ON E.cod_estado = C.estado_cli", conexao);
                SqlDataAdapter daConsCPFCli = new SqlDataAdapter();
                daConsCPFCli.SelectCommand = cmdConsCPFCli;
                DataTable dtConsCPFCli = new DataTable();
                daConsCPFCli.Fill(dtConsCPFCli);
                dgvDetPed.DataSource = dtConsCPFCli;
                dgvDetPed.Columns[0].HeaderText = "Cód Ped";
                dgvDetPed.Columns[1].HeaderText = "Status";
                dgvDetPed.Columns[1].Width = 250;
                dgvDetPed.Columns[2].HeaderText = "Nome Cliente";
                dgvDetPed.Columns[2].Width = 200;
                dgvDetPed.Columns[3].HeaderText = "CPF Cliente";
                dgvDetPed.Columns[3].Width = 200;
                dgvDetPed.Columns[4].HeaderText = "Endereço";
                dgvDetPed.Columns[4].Width = 200;
                dgvDetPed.Columns[5].HeaderText = "Bairro";
                dgvDetPed.Columns[5].Width = 200;
                dgvDetPed.Columns[6].HeaderText = "Número";
                dgvDetPed.Columns[6].Width = 200;
                dgvDetPed.Columns[7].HeaderText = "Múnicipio";
                dgvDetPed.Columns[7].Width = 200;
                dgvDetPed.Columns[8].HeaderText = "Estado";
                dgvDetPed.Columns[8].Width = 200;
                dgvDetPed.Columns[9].HeaderText = "Complemento";
                dgvDetPed.Columns[9].Width = 200;
                dgvDetPed.Columns[10].HeaderText = "CEP";
                dgvDetPed.Columns[10].Width = 200;
                dgvDetPed.Columns[11].HeaderText = "Dt Pedido";
                dgvDetPed.Columns[11].Width = 200;
                conexao.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.Close();
            }

            try
            {

                conexao.Open();
                SqlCommand cmdConsPedProd = new SqlCommand("SELECT P.cod_ped, PP.cod_prod, PR.nome_prod, PP.qtd_prod, PP.precoItem_ped, C.cpf_cli FROM tblPedido AS P INNER JOIN tblPedido_Produto AS PP ON P.cod_ped = PP.cod_ped INNER JOIN tblProduto AS PR ON PP.cod_prod = PR.cod_prod INNER JOIN tblCliente AS C ON P.cod_cli = C.cod_cli AND C.cpf_cli = " + txtConsCPFClie.Text, conexao);
                SqlDataAdapter daConsPedProd = new SqlDataAdapter();
                daConsPedProd.SelectCommand = cmdConsPedProd;
                DataTable dtConsPedProd = new DataTable();
                daConsPedProd.Fill(dtConsPedProd);
                dgvDetProd.DataSource = dtConsPedProd;
                dgvDetProd.Columns[0].HeaderText = "Cód Ped";
                dgvDetProd.Columns[1].HeaderText = "Código Produto";
                dgvDetProd.Columns[1].Width = 150;
                dgvDetProd.Columns[2].HeaderText = "Nome Produto";
                dgvDetProd.Columns[2].Width = 300;
                dgvDetProd.Columns[3].HeaderText = "Quantidade Produto";
                dgvDetProd.Columns[3].Width = 175;
                dgvDetProd.Columns[4].HeaderText = "Preço Produto";
                dgvDetProd.Columns[4].Width = 175;
                dgvDetProd.Columns[5].HeaderText = "CPF Cliente";
                dgvDetProd.Columns[5].Visible = false;
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                conexao.Close();
            }


        }

        private void btnTodPedProd_Click(object sender, EventArgs e)
        {
            conexao.Open();
            SqlCommand cmdPedProd = new SqlCommand("SELECT P.cod_ped, PP.cod_prod, PR.nome_prod, PP.qtd_prod, PP.precoItem_ped FROM tblPedido AS P INNER JOIN tblPedido_Produto AS PP ON P.cod_ped = PP.cod_ped INNER JOIN tblProduto AS PR ON PP.cod_prod = PR.cod_prod", conexao);
            SqlDataAdapter daPedProd = new SqlDataAdapter();
            daPedProd.SelectCommand = cmdPedProd;
            DataTable dtPedProd = new DataTable();
            daPedProd.Fill(dtPedProd);
            dgvDetProd.DataSource = dtPedProd;
            dgvDetProd.Columns[0].HeaderText = "Cód Ped";
            dgvDetProd.Columns[0].Width = 100;
            dgvDetProd.Columns[1].HeaderText = "Código Produto";
            dgvDetProd.Columns[1].Width = 100;
            dgvDetProd.Columns[2].HeaderText = "Nome Produto";
            dgvDetProd.Columns[2].Width = 200;
            dgvDetProd.Columns[3].HeaderText = "Quantidade Produto";
            dgvDetProd.Columns[3].Width = 150;
            dgvDetProd.Columns[4].HeaderText = "Preço Produto";
            dgvDetProd.Columns[4].Width = 100;
            conexao.Close();
        }

        //private void btnConsPedProd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //
        //        conexao.Open();
        //        SqlCommand cmdConsPedProd = new SqlCommand("SELECT P.cod_ped, PP.cod_prod, PR.nome_prod, PP.qtd_prod, PP.precoItem_ped FROM tblPedido AS P  INNER JOIN tblPedido_Produto AS PP ON P.cod_ped = PP.cod_ped AND P.cod_ped = '" + txtConsPedProd.Text + "' INNER JOIN tblProduto AS PR ON PP.cod_prod = PR.cod_prod ", conexao);
        //        SqlDataAdapter daConsPedProd = new SqlDataAdapter();
        //        daConsPedProd.SelectCommand = cmdConsPedProd;
        //        DataTable dtConsPedProd = new DataTable();
        //        daConsPedProd.Fill(dtConsPedProd);
        //        dgvDetProd.DataSource = dtConsPedProd;
        //        dgvDetProd.Columns[0].HeaderText = "Cód Ped";
        //        dgvDetProd.Columns[1].HeaderText = "Código Produto";
        //        dgvDetProd.Columns[2].HeaderText = "Nome Produto";
        //        dgvDetProd.Columns[3].HeaderText = "Quantidade Produto";
        //        dgvDetProd.Columns[4].HeaderText = "Preço Produto";
        //        conexao.Close();
        //
        //    }
        //    catch (Exception erro)
        //    {
        //        MessageBox.Show(erro.Message);
        //        conexao.Close();
        //    }
        //}

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtCodigoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNomeLoginCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSenhaLoginCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNomeCompletoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCPFCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEnderecoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtNumeroCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtComplementoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtBairroCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtCepCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtEmailCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCelularCliente.Text = dgvClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
                cmbStatusClie.SelectedItem = dgvClientes.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbMuncClie.Text = dgvClientes.Rows[e.RowIndex].Cells[13].Value.ToString();
                cmbEstadoCli.Text = dgvClientes.Rows[e.RowIndex].Cells[12].Value.ToString();
                cmbTermClie.SelectedItem = dgvClientes.Rows[e.RowIndex].Cells[15].Value.ToString();
            }
        }

        private void btnLimparPedCli_Click(object sender, EventArgs e)
        {
            limparPedCli();
            limparPedProd();
            txtNumPedido.Clear();
            cmbStatPed.SelectedIndex = -1;
        }

        private void btnSairPed_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSenhaLoginCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("Campo senha não aceita espaço", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCPFCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo CPF aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCelularCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo celular aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNumeroCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo número aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCepCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo CEP aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodConsultaCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo de consulta CPF aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNomeLoginCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("Campo nome do login não aceita espaço", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEstProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar !=(char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo estoque aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtConsPed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo consulta número do pedido aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtConsCPFClie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo consulta CPF do cliente aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtVendProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
                MessageBox.Show("O campo preço de venda aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //  permite colocar apenas uma "," vírgula no campo de texto
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("O campo preço de venda aceita somente uma vírgula", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            // para bloquear que se use "." ponto no textbox
            if (e.KeyChar == (char)46)
            {
                e.Handled = true;
                MessageBox.Show("O campo preço de venda não aceita ponto", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCustProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
                MessageBox.Show("O campo preço de custo aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //  permite colocar apenas uma "," vírgula no campo de texto
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("O campo preço de custo aceita somente uma vírgula", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // para bloquear que se use "." ponto no textbox
            //if (e.KeyChar == (char)46)
            //{
            //    e.Handled = true;
            //    MessageBox.Show("O campo preço de custo não aceita ponto", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            carregaPlanta();
            carregaDoenca();
            carregaCliente();
            carregaProduto();
            carregaFaq();
            carregaFunc();
            carregaProdAtiv();
            carregaProdInativ();
            carregaFaqAtiv();
            carregaFaqInat();
            carregaClieAtiv();
            carregaClieInat();
            topVendas();
        }

        private void btnLimpProd_Click(object sender, EventArgs e)
        {
            limparCaracProd();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDetPed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetPed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtNumPedido.Text = dgvDetPed.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNumPedido.Text != "" && cmbStatPed.Text != "")
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "UPDATE tblPedido SET status_ped=@status_ped WHERE cod_ped=@cod_ped";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_ped", txtNumPedido.Text);
                    comando.Parameters.AddWithValue("@status_ped", cmbStatPed.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    conexao.Close();

                    limparPedCli();
                    limparPedProd();
                    MessageBox.Show("Atualização realizada com sucesso!", "Alteração Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro inesperado. Por favor, comunicar o suporte técnico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualImg_Click(object sender, EventArgs e)
        {
            if (picPlanta.Image != null)
            {
                try
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    images = brs.ReadBytes((int)stream.Length);

                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "UPDATE tblPlanta SET foto_planta=@images WHERE cod_planta=@cod_planta";
                    //comando.CommandText = "UPDATE tblPlanta SET nome_planta=@nome_planta, nomeCient_planta=@nomeCient_planta, desc_planta=@desc_planta WHERE cod_planta=@cod_planta";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_planta", txtCodPlanta.Text);
                    comando.Parameters.Add(new SqlParameter("@images", images));

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblPlantaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblPlanta);
                    conexao.Close();

                    limparCaracPlantas();
                    MessageBox.Show("Imagem atualizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Verificar o caminho da imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualImgDoe_Click(object sender, EventArgs e)
        {
            if (picDoenca.Image != null)
            {
                try
                {
                    byte[] images_doencas;
                    FileStream stream = new FileStream(imgLocationDoenca, FileMode.Open, FileAccess.Read);
                    BinaryReader brs_doenca = new BinaryReader(stream);
                    images_doencas = brs_doenca.ReadBytes((int)stream.Length);

                    conexao.Open();

                    comando.CommandText = "UPDATE tblDoenca SET foto_doenca=@images_doencas WHERE cod_doenca=@cod_doenca";


                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_doenca", txtCodigoDoenca.Text);
                    comando.Parameters.Add(new SqlParameter("@images_doencas", images_doencas));


                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblDoencaTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblDoenca);
                    conexao.Close();

                    limparCaracDoencas();
                    MessageBox.Show("Imagem atualizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show("Verificar o caminho da imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtuaImgProd_Click(object sender, EventArgs e)
        {
            if (picProduto.Image != null)
            {
                try
                {
                    byte[] images_prod = null;
                    FileStream stream_prod = new FileStream(imgLocationProd, FileMode.Open, FileAccess.Read);
                    BinaryReader brs_prod = new BinaryReader(stream_prod);
                    images_prod = brs_prod.ReadBytes((int)stream_prod.Length);

                    comando.Connection = conexao;
                    conexao.Open();
                    comando.CommandText = "UPDATE tblProduto SET foto_prod=@images_prod WHERE cod_prod=@cod_prod";

                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@cod_prod", txtCodProduto.Text);
                    comando.Parameters.Add(new SqlParameter("@images_prod", images_prod));

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblProdutoTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblProduto);
                    conexao.Close();

                    limparCaracProd();
                    MessageBox.Show("Imagem atualizada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Verificar o caminho da imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
