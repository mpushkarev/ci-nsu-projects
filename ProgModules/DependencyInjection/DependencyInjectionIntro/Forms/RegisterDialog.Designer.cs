namespace DependencyInjectionIntro {
    partial class RegisterDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            textBoxPasswordRepeat = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            textBoxPassword = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            textBoxLogin = new TextBox();
            buttonRegister = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonRegister, 0, 3);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(219, 286);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(textBoxPasswordRepeat);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 145);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(126, 53);
            flowLayoutPanel3.TabIndex = 7;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Margin = new Padding(3, 3, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 5;
            label3.Text = "Повтор пароля:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPasswordRepeat
            // 
            textBoxPasswordRepeat.Anchor = AnchorStyles.None;
            textBoxPasswordRepeat.Location = new Point(3, 23);
            textBoxPasswordRepeat.Margin = new Padding(3, 0, 3, 3);
            textBoxPasswordRepeat.Name = "textBoxPasswordRepeat";
            textBoxPasswordRepeat.Size = new Size(120, 27);
            textBoxPasswordRepeat.TabIndex = 5;
            textBoxPasswordRepeat.UseSystemPasswordChar = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(textBoxPassword);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 74);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(126, 53);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 3);
            label2.Margin = new Padding(3, 3, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 5;
            label2.Text = "Пароль:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.Location = new Point(3, 23);
            textBoxPassword.Margin = new Padding(3, 0, 3, 3);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(120, 27);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBoxLogin);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(126, 53);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 5;
            label1.Text = "Логин:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Anchor = AnchorStyles.None;
            textBoxLogin.Location = new Point(3, 23);
            textBoxLogin.Margin = new Padding(3, 0, 3, 3);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(120, 27);
            textBoxLogin.TabIndex = 5;
            // 
            // buttonRegister
            // 
            buttonRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRegister.Location = new Point(82, 257);
            buttonRegister.Margin = new Padding(3, 3, 3, 0);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(134, 29);
            buttonRegister.TabIndex = 10;
            buttonRegister.Text = "Регистрация";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += ButtonRegister_Click;
            // 
            // RegisterDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 310);
            Controls.Add(tableLayoutPanel1);
            Name = "RegisterDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegisterDialog";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private TextBox textBoxPasswordRepeat;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private TextBox textBoxPassword;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox textBoxLogin;
        private Button buttonRegister;
    }
}