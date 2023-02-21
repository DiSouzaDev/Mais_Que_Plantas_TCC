
namespace cadastrarBotanica
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.txtCodFuncAltSenha = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.grpAlterarSenha = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.btnSairAltSenha = new System.Windows.Forms.Button();
            this.grpAlterarSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodFuncAltSenha
            // 
            this.txtCodFuncAltSenha.Enabled = false;
            this.txtCodFuncAltSenha.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodFuncAltSenha.Location = new System.Drawing.Point(391, 143);
            this.txtCodFuncAltSenha.Name = "txtCodFuncAltSenha";
            this.txtCodFuncAltSenha.Size = new System.Drawing.Size(92, 29);
            this.txtCodFuncAltSenha.TabIndex = 0;
            this.txtCodFuncAltSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovaSenha.Location = new System.Drawing.Point(363, 199);
            this.txtNovaSenha.MaxLength = 20;
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.PasswordChar = '*';
            this.txtNovaSenha.Size = new System.Drawing.Size(164, 29);
            this.txtNovaSenha.TabIndex = 1;
            this.txtNovaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovaSenha_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cód Funcionário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nova Senha";
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnAlterar.Location = new System.Drawing.Point(584, 157);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(114, 41);
            this.btnAlterar.TabIndex = 5;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // grpAlterarSenha
            // 
            this.grpAlterarSenha.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.grpAlterarSenha.Controls.Add(this.pictureBox4);
            this.grpAlterarSenha.Controls.Add(this.label59);
            this.grpAlterarSenha.Controls.Add(this.label60);
            this.grpAlterarSenha.Controls.Add(this.label61);
            this.grpAlterarSenha.Controls.Add(this.btnSairAltSenha);
            this.grpAlterarSenha.Controls.Add(this.label1);
            this.grpAlterarSenha.Controls.Add(this.btnAlterar);
            this.grpAlterarSenha.Controls.Add(this.label2);
            this.grpAlterarSenha.Controls.Add(this.txtNovaSenha);
            this.grpAlterarSenha.Controls.Add(this.txtCodFuncAltSenha);
            this.grpAlterarSenha.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAlterarSenha.Location = new System.Drawing.Point(12, 12);
            this.grpAlterarSenha.Name = "grpAlterarSenha";
            this.grpAlterarSenha.Size = new System.Drawing.Size(783, 339);
            this.grpAlterarSenha.TabIndex = 6;
            this.grpAlterarSenha.TabStop = false;
            this.grpAlterarSenha.Text = "Alterar Senha";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(711, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(66, 61);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 72;
            this.pictureBox4.TabStop = false;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(431, 45);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(267, 16);
            this.label59.TabIndex = 70;
            this.label59.Text = "Email: maisqueplantas.contato@gmail.com";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(481, 61);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(217, 16);
            this.label60.TabIndex = 69;
            this.label60.Text = "Celular/Whats\'App: (11) 977965487 ";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Calisto MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(270, 16);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(428, 24);
            this.label61.TabIndex = 68;
            this.label61.Text = "Mais que Plantas - Consultoria e Paisagismo";
            // 
            // btnSairAltSenha
            // 
            this.btnSairAltSenha.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSairAltSenha.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSairAltSenha.Location = new System.Drawing.Point(701, 297);
            this.btnSairAltSenha.Name = "btnSairAltSenha";
            this.btnSairAltSenha.Size = new System.Drawing.Size(76, 36);
            this.btnSairAltSenha.TabIndex = 7;
            this.btnSairAltSenha.Text = "Sair";
            this.btnSairAltSenha.UseVisualStyleBackColor = false;
            this.btnSairAltSenha.Click += new System.EventHandler(this.btnSairAltSenha_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(813, 366);
            this.Controls.Add(this.grpAlterarSenha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 405);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alteração de Senha";
            this.grpAlterarSenha.ResumeLayout(false);
            this.grpAlterarSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodFuncAltSenha;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.GroupBox grpAlterarSenha;
        private System.Windows.Forms.Button btnSairAltSenha;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
    }
}