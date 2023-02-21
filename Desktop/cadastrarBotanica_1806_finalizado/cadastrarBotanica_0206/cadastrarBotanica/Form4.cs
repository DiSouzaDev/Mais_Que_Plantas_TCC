using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using atvBD_PlantasEstoque.DAL;
using System.IO;
using cadastrarBotanica.consultoriaPlantasTCCDataSetTableAdapters;

namespace cadastrarBotanica
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-UC8GBJH9\SQLEXPRESS;Initial Catalog=consultoriaPlantasTCC;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();


        void limparCaracFunc()
        {
            txtCodFunc.Clear();
            txtNomeFunc.Clear();
            txtSenhaFunc.Clear();
            txtNomCompFunc.Clear();
            txtEndFunc.Clear();
            txtNumFunc.Clear();
            txtCompFunc.Clear();
            txtBairroFunc.Clear();
            cmbCargFunc.SelectedIndex = -1;
            txtCEPFunc.Clear();
            txtEmailFunc.Clear();
            txtCelFunc.Clear();
            txtCPFFunc.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            cmbEstFunc.SelectedIndex = -1;
            cmbMunFunc.SelectedIndex = -1;
            cmbStatusFunc.SelectedIndex = -1;
            cmbCargFunc.SelectedIndex = -1;
            txtCPFFunc.Clear();
            txtConsFunc.Clear();
            cbxFuncAdm.Checked = false;
            cmbStatFunc.SelectedIndex = -1;
            conexao.Close(); //caso haja algum erro no cadastro e quiser fechar a conexão ao limpar para pode fazer novo cadastro
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'consultoriaPlantasTCCDataSet.tblFuncionario'. Você pode movê-la ou removê-la conforme necessário.
            // this.tblFuncionarioTableAdapter.Fill(this.consultoriaPlantasTCCDataSet.tblFuncionario);
            carregaMuncFun();
            carregaEstFun();
            limparCaracFunc();
        }

        private void carregaMuncFun()
        {
            DataTable tb = new DataTable("tblMunicipio");
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT cod_municipio, nome_municipio FROM tblMunicipio ORDER BY nome_municipio", conexao);
            SqlDataReader dr = comando.ExecuteReader();
            tb.Load(dr);
            cmbMunFunc.DisplayMember = "nome_municipio";
            cmbMunFunc.ValueMember = "cod_municipio";
            cmbMunFunc.DataSource = tb;
            conexao.Close();
        }


        private void carregaEstFun()
        {
            DataTable tbl = new DataTable("tblEstado");
            conexao.Open();
            SqlCommand comando = new SqlCommand("SELECT cod_estado, nome_estado FROM tblEstado ORDER BY nome_estado", conexao);
            SqlDataReader dr1 = comando.ExecuteReader();
            tbl.Load(dr1);
            cmbEstFunc.DisplayMember = "nome_estado";
            cmbEstFunc.ValueMember = "cod_estado";
            cmbEstFunc.DataSource = tbl;

            conexao.Close();
        }

        private void cbxFuncAdm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFuncAdm.Checked)
            {
                cbxFuncAdm.Checked = Convert.ToBoolean(1);
            }
            else
            {
                cbxFuncAdm.Checked = Convert.ToBoolean(0);
            }
        }

        private void btnSairFunc_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncFunc_Click_1(object sender, EventArgs e)
        {
            if (txtNomeFunc.Text != "" && txtSenhaFunc.Text != "" && txtNomCompFunc.Text != "" && txtCPFFunc.Text != "" && txtEndFunc.Text != "" && txtNumFunc.Text != "" && txtCompFunc.Text != "" && txtBairroFunc.Text != "" && txtCEPFunc.Text != "" && txtEmailFunc.Text != "" && txtCelFunc.Text != "" && cmbStatusFunc.Text != "" && cmbCargFunc.Text != "" && cmbEstFunc.Text != "" && cmbMunFunc.Text != "")
            {
                try
                {
                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "INSERT INTO tblFuncionario (nomeLogin_func, senha_func, nome_func, cpf_func, email_func, celular_func, adm_func, cargo_func, status_func, endereco_func, numEnd_func, complemento_func, bairro_func, cod_municipio, cod_estado, cep_func)"
                        + "VALUES (@nomeLogin_func, @senha_func, @nome_func, @cpf_func, @email_func, @celular_func, @adm_func, @cargo_func, @status_func, @endereco_func, @numEnd_func, @complemento_func, @bairro_func, @cod_municipio, @cod_estado, @cep_func)";
                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@nomeLogin_func", txtNomeFunc.Text);
                    comando.Parameters.AddWithValue("@senha_func", txtSenhaFunc.Text);
                    comando.Parameters.AddWithValue("@nome_func", txtNomCompFunc.Text);
                    comando.Parameters.AddWithValue("@cpf_func", txtCPFFunc.Text);
                    comando.Parameters.AddWithValue("@endereco_func", txtEndFunc.Text);
                    comando.Parameters.AddWithValue("@cep_func", txtCEPFunc.Text);
                    comando.Parameters.AddWithValue("@numEnd_func", txtNumFunc.Text);
                    comando.Parameters.AddWithValue("@bairro_func", txtBairroFunc.Text);
                    comando.Parameters.AddWithValue("@complemento_func", txtCompFunc.Text);
                    comando.Parameters.AddWithValue("@cod_municipio", cmbMunFunc.SelectedValue);
                    comando.Parameters.AddWithValue("@cod_estado", cmbEstFunc.SelectedValue);
                    comando.Parameters.AddWithValue("@email_func", txtEmailFunc.Text);
                    comando.Parameters.AddWithValue("@celular_func", txtCelFunc.Text);
                    comando.Parameters.AddWithValue("@cargo_func", cmbCargFunc.Text);
                    comando.Parameters.AddWithValue("@status_func", cmbStatusFunc.Text);
                    comando.Parameters.AddWithValue("@adm_func", cbxFuncAdm.Checked);


                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblFuncionarioTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblFuncionario);
                    conexao.Close();

                    limparCaracFunc();
                    MessageBox.Show("Cadastro de clientes realizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            else
            {
                MessageBox.Show("Verificar se todos os campos estão preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparFunc_Click(object sender, EventArgs e)
        {
            limparCaracFunc();

        }

        private void btnAtualizarFunc_Click(object sender, EventArgs e)
        {
            if (txtNomeFunc.Text != "" && txtSenhaFunc.Text != "" && txtNomCompFunc.Text != "" && txtCPFFunc.Text != "" && txtEndFunc.Text != "" && txtCEPFunc.Text != "" && txtNumFunc.Text != "" && txtCompFunc.Text != "" && txtBairroFunc.Text != "" && txtCEPFunc.Text != "" && txtEmailFunc.Text != "" && txtCelFunc.Text != "" && cmbStatusFunc.Text != "" && cmbCargFunc.Text != "" && cmbMunFunc.Text != "" && cmbEstFunc.Text != "")
            {
                try
                {
                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "UPDATE tblFuncionario SET nomeLogin_func=@nomeLogin_func, senha_func=@senha_func, nome_func=@nome_func, cpf_func=@cpf_func, email_func=@email_func, celular_func=@celular_func, cargo_func=@cargo_func, status_func=@status_func, endereco_func=@endereco_func, numEnd_func=@numEnd_func, complemento_func=@complemento_func, bairro_func=@bairro_func, cod_municipio=@cod_municipio, cod_estado=@cod_estado, cep_func=@cep_func WHERE cod_func=@cod_func";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_func", txtCodFunc.Text);
                    comando.Parameters.AddWithValue("@nomeLogin_func", txtNomeFunc.Text);
                    comando.Parameters.AddWithValue("@senha_func", txtSenhaFunc.Text);
                    comando.Parameters.AddWithValue("@nome_func", txtNomCompFunc.Text);
                    comando.Parameters.AddWithValue("@cpf_func", txtCPFFunc.Text);
                    comando.Parameters.AddWithValue("@endereco_func", txtEndFunc.Text);
                    comando.Parameters.AddWithValue("@cep_func", txtCEPFunc.Text);
                    comando.Parameters.AddWithValue("@numEnd_func", txtNumFunc.Text);
                    comando.Parameters.AddWithValue("@bairro_func", txtBairroFunc.Text);
                    comando.Parameters.AddWithValue("@complemento_func", txtCompFunc.Text);
                    comando.Parameters.AddWithValue("@cod_municipio", cmbMunFunc.SelectedValue);
                    comando.Parameters.AddWithValue("@cod_estado", cmbEstFunc.SelectedValue);
                    comando.Parameters.AddWithValue("@email_func", txtEmailFunc.Text);
                    comando.Parameters.AddWithValue("@celular_func", txtCelFunc.Text);
                    comando.Parameters.AddWithValue("@cargo_func", cmbCargFunc.Text);
                    comando.Parameters.AddWithValue("@status_func", cmbStatusFunc.Text);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblFuncionarioTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblFuncionario);
                    conexao.Close();

                    limparCaracFunc();
                    MessageBox.Show("Funcionário atualizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnConsCPFFunc_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryFunc = "SELECT F.cod_func, F.nomeLogin_func, F.senha_func, F.nome_func, F.cpf_func, F.email_func, F.celular_func, F.adm_func, F.cargo_func, F.status_func, F.endereco_func, F.numEnd_func, F.complemento_func, F.bairro_func, M.nome_municipio, E.nome_estado, F.cep_func, F.dtCad_func FROM tblFuncionario AS F INNER JOIN tblMunicipio AS M ON F.cod_municipio = M.cod_municipio INNER JOIN tblEstado AS E ON F.cod_estado = E.cod_estado WHERE cpf_func = " + txtConsFunc.Text;
                using (SqlDataAdapter daFunc = new SqlDataAdapter(sqlQueryFunc, conexao))
                {
                    using (DataTable dtFunc = new DataTable())
                    {
                        daFunc.Fill(dtFunc);
                        dataGridView1.DataSource = dtFunc;
                        dataGridView1.Columns[0].HeaderText = "COD";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Nome Login";
                        dataGridView1.Columns[2].HeaderText = "Senha";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Nome";
                        dataGridView1.Columns[4].HeaderText = "CPF";
                        dataGridView1.Columns[5].HeaderText = "Email";
                        dataGridView1.Columns[6].HeaderText = "Celular";
                        dataGridView1.Columns[7].HeaderText = "ADM Func";
                        dataGridView1.Columns[8].HeaderText = "Cargo";
                        dataGridView1.Columns[9].HeaderText = "Status";
                        dataGridView1.Columns[10].HeaderText = "Endereço";
                        dataGridView1.Columns[11].HeaderText = "Número";
                        dataGridView1.Columns[12].HeaderText = "Compl";
                        dataGridView1.Columns[13].HeaderText = "Bairro";
                        dataGridView1.Columns[14].HeaderText = "Município";
                        dataGridView1.Columns[15].HeaderText = "Estado";
                        dataGridView1.Columns[16].HeaderText = "CEP";
                        dataGridView1.Columns[17].HeaderText = "Dt Cadastro";
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

        private void btnConsultaTotalFunc_Click(object sender, EventArgs e)
        {
            conexao.Open();
            SqlCommand cmdFunc = new SqlCommand("SELECT F.cod_func, F.nomeLogin_func, F.senha_func, F.nome_func, F.cpf_func, F.email_func, F.celular_func, F.adm_func, F.cargo_func, F.status_func, F.endereco_func, F.numEnd_func, F.complemento_func, F.bairro_func, M.nome_municipio, E.nome_estado, F.cep_func, F.dtCad_func FROM tblFuncionario AS F INNER JOIN tblMunicipio AS M ON F.cod_municipio = M.cod_municipio INNER JOIN tblEstado AS E ON F.cod_estado = E.cod_estado", conexao);
            SqlDataAdapter daFunc = new SqlDataAdapter();
            daFunc.SelectCommand = cmdFunc;
            DataTable dtFunc = new DataTable();
            daFunc.Fill(dtFunc);
            dataGridView1.DataSource = dtFunc;
            dataGridView1.Columns[0].HeaderText = "COD";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nome Login";
            dataGridView1.Columns[2].HeaderText = "Senha";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Nome";
            dataGridView1.Columns[4].HeaderText = "CPF";
            dataGridView1.Columns[5].HeaderText = "Email";
            dataGridView1.Columns[6].HeaderText = "Celular";
            dataGridView1.Columns[7].HeaderText = "ADM Func";
            dataGridView1.Columns[8].HeaderText = "Cargo";
            dataGridView1.Columns[9].HeaderText = "Status";
            dataGridView1.Columns[10].HeaderText = "Endereço";
            dataGridView1.Columns[11].HeaderText = "Número";
            dataGridView1.Columns[12].HeaderText = "Compl";
            dataGridView1.Columns[13].HeaderText = "Bairro";
            dataGridView1.Columns[14].HeaderText = "Município";
            dataGridView1.Columns[15].HeaderText = "Estado";
            dataGridView1.Columns[16].HeaderText = "CEP";
            dataGridView1.Columns[17].HeaderText = "Dt Cadastro";
            conexao.Close();
        }

        private void BtnConsStatusFunc_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                var sqlQueryFuncStat = "SELECT F.cod_func, F.nomeLogin_func, F.senha_func, F.nome_func, F.cpf_func, F.email_func, F.celular_func, F.adm_func, F.cargo_func, F.status_func, F.endereco_func, F.numEnd_func, F.complemento_func, F.bairro_func, M.nome_municipio, E.nome_estado, F.cep_func, F.dtCad_func FROM tblFuncionario AS F INNER JOIN tblMunicipio AS M ON F.cod_municipio = M.cod_municipio INNER JOIN tblEstado AS E ON F.cod_estado = E.cod_estado WHERE status_func LIKE '" + cmbStatFunc.Text + "'";
                using (SqlDataAdapter daFuncStat = new SqlDataAdapter(sqlQueryFuncStat, conexao))
                {
                    using (DataTable dtFuncStat = new DataTable())
                    {
                        daFuncStat.Fill(dtFuncStat);
                        dataGridView1.DataSource = dtFuncStat;
                        dataGridView1.Columns[0].HeaderText = "COD";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderText = "Nome Login";
                        dataGridView1.Columns[2].HeaderText = "Senha";
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].HeaderText = "Nome";
                        dataGridView1.Columns[4].HeaderText = "CPF";
                        dataGridView1.Columns[5].HeaderText = "Email";
                        dataGridView1.Columns[6].HeaderText = "Celular";
                        dataGridView1.Columns[7].HeaderText = "ADM Func";
                        dataGridView1.Columns[8].HeaderText = "Cargo";
                        dataGridView1.Columns[9].HeaderText = "Status";
                        dataGridView1.Columns[10].HeaderText = "Endereço";
                        dataGridView1.Columns[11].HeaderText = "Número";
                        dataGridView1.Columns[12].HeaderText = "Compl";
                        dataGridView1.Columns[13].HeaderText = "Bairro";
                        dataGridView1.Columns[14].HeaderText = "Município";
                        dataGridView1.Columns[15].HeaderText = "Estado";
                        dataGridView1.Columns[16].HeaderText = "CEP";
                        dataGridView1.Columns[17].HeaderText = "Dt Cadastro";
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtCodFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbCargFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtNomeFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSenhaFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCPFFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCompFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                cmbStatusFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                cmbMunFunc.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtNomCompFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmailFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCelFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtEndFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtNumFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtBairroFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                cmbMunFunc.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                txtCEPFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                cmbMunFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                cmbEstFunc.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            }
        }

        private void txtNomeFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("Campo nome do login não aceita espaço", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSenhaFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("Campo senha não aceita espaço", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCPFFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo CPF aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNumFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo número aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCEPFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo CEP aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCelFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo celular aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtConsFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
                MessageBox.Show("O campo consultar CPF do funcionário aceita somente números", "Restrições", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualADM_Click(object sender, EventArgs e)
        {
            if (txtCodFunc.Text != "" && txtNomeFunc.Text != "")
            {
                try
                {
                    comando.Connection = conexao;
                    conexao.Open();

                    comando.CommandText = "UPDATE tblFuncionario SET nomeLogin_func=@nomeLogin_func, adm_func=@adm_func WHERE cod_func=@cod_func";

                    comando.Parameters.Clear(); // realiza a limpeza antes de serem inseridos dados novamente, evita o erro ao se fazer o mesmo comando em sequência (usar logo após o comando insert, delete etc)
                    comando.Parameters.AddWithValue("@cod_func", txtCodFunc.Text);
                    comando.Parameters.AddWithValue("@nomeLogin_func", txtNomeFunc.Text);
                    comando.Parameters.AddWithValue("@adm_func", cbxFuncAdm.Checked);

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    tblFuncionarioTableAdapter.Fill(consultoriaPlantasTCCDataSet.tblFuncionario);
                    conexao.Close();

                    limparCaracFunc();
                    MessageBox.Show("Funcionário atualizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}