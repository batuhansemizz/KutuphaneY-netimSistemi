namespace KutuphaneYönetimSistemi
{
    partial class FormGiris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGiris = new Button();
            textBoxKullanıcıAdi = new TextBox();
            textBoxSifre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonGiris
            // 
            buttonGiris.Location = new Point(438, 290);
            buttonGiris.Name = "buttonGiris";
            buttonGiris.Size = new Size(125, 29);
            buttonGiris.TabIndex = 0;
            buttonGiris.Text = "Giriş Yap";
            buttonGiris.UseVisualStyleBackColor = true;
            buttonGiris.Click += buttonGiris_Click;
            // 
            // textBoxKullanıcıAdi
            // 
            textBoxKullanıcıAdi.Location = new Point(438, 144);
            textBoxKullanıcıAdi.Name = "textBoxKullanıcıAdi";
            textBoxKullanıcıAdi.Size = new Size(125, 27);
            textBoxKullanıcıAdi.TabIndex = 1;
            // 
            // textBoxSifre
            // 
            textBoxSifre.Location = new Point(438, 214);
            textBoxSifre.Name = "textBoxSifre";
            textBoxSifre.Size = new Size(125, 27);
            textBoxSifre.TabIndex = 2;
            textBoxSifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(314, 151);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 3;
            label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Rockwell", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(314, 221);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 4;
            label2.Text = "Şifre :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 353);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1002, 569);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxSifre);
            Controls.Add(textBoxKullanıcıAdi);
            Controls.Add(buttonGiris);
            Name = "Form1";
            Text = "Kütüphane Yönetim";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGiris;
        private TextBox textBoxKullanıcıAdi;
        private TextBox textBoxSifre;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}