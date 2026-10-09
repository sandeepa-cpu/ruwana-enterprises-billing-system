namespace Billing_Inventory_Management_System
{
    partial class frm_ProcessLogIn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProcessLogIn));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_LogIn = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.btn_LogIn);
            this.groupBox2.Controls.Add(this.txt_Password);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.Label2);
            this.groupBox2.Controls.Add(this.txt_User);
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 37);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(396, 196);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LogIn Secure Password";
            // 
            // btn_LogIn
            // 
            this.btn_LogIn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogIn.Location = new System.Drawing.Point(196, 128);
            this.btn_LogIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_LogIn.Name = "btn_LogIn";
            this.btn_LogIn.Size = new System.Drawing.Size(177, 45);
            this.btn_LogIn.TabIndex = 25;
            this.btn_LogIn.Text = "Log In";
            this.btn_LogIn.UseVisualStyleBackColor = true;
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(196, 81);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Password.MaxLength = 20;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '•';
            this.txt_Password.Size = new System.Drawing.Size(177, 23);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Password_KeyPress);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(65, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(125, 19);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Log In User Name";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(65, 83);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(125, 18);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "LogIn Password";
            // 
            // txt_User
            // 
            this.txt_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_User.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_User.Location = new System.Drawing.Point(196, 39);
            this.txt_User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_User.MaxLength = 20;
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(176, 23);
            this.txt_User.TabIndex = 2;
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Quit.BackgroundImage")));
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Quit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(365, 1);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(36, 35);
            this.btn_Quit.TabIndex = 26;
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label58.Location = new System.Drawing.Point(3, 4);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(195, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "PROCESS LOG IN";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_ProcessLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(403, 236);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ProcessLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ProcessLogIn_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_LogIn;
        internal System.Windows.Forms.TextBox txt_Password;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Timer timer1;
    }
}