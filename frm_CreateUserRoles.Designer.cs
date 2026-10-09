namespace Billing_Inventory_Management_System
{
    partial class frm_CreateUserRoles
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Administration");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Edit Mode");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tools");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Reports");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CreateUserRoles));
            this.cmb_User = new System.Windows.Forms.ComboBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tv_UserRole = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_User
            // 
            this.cmb_User.BackColor = System.Drawing.Color.LightBlue;
            this.cmb_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_User.FormattingEnabled = true;
            this.cmb_User.Location = new System.Drawing.Point(93, 21);
            this.cmb_User.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_User.Name = "cmb_User";
            this.cmb_User.Size = new System.Drawing.Size(369, 26);
            this.cmb_User.TabIndex = 9;
            this.cmb_User.SelectedValueChanged += new System.EventHandler(this.cmb_User_SelectedValueChanged);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(363, 707);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(117, 36);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // tv_UserRole
            // 
            this.tv_UserRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_UserRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tv_UserRole.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_UserRole.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tv_UserRole.Location = new System.Drawing.Point(4, 106);
            this.tv_UserRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tv_UserRole.Name = "tv_UserRole";
            treeNode1.Checked = true;
            treeNode1.ForeColor = System.Drawing.Color.Maroon;
            treeNode1.Name = "tvAdmin";
            treeNode1.Text = "Administration";
            treeNode2.Checked = true;
            treeNode2.ForeColor = System.Drawing.Color.Maroon;
            treeNode2.Name = "tvEditMode";
            treeNode2.Text = "Edit Mode";
            treeNode3.ForeColor = System.Drawing.Color.Maroon;
            treeNode3.Name = "tvProcess";
            treeNode3.Text = "Process";
            treeNode4.Checked = true;
            treeNode4.ForeColor = System.Drawing.Color.Maroon;
            treeNode4.Name = "tvTools";
            treeNode4.Text = "Tools";
            treeNode5.ForeColor = System.Drawing.Color.Maroon;
            treeNode5.Name = "tvReports";
            treeNode5.Text = "Reports";
            this.tv_UserRole.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.tv_UserRole.Size = new System.Drawing.Size(476, 597);
            this.tv_UserRole.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(236, 707);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(123, 36);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_User);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(475, 61);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Name";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Firebrick;
            this.label58.Location = new System.Drawing.Point(2, 7);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(243, 29);
            this.label58.TabIndex = 265;
            this.label58.Text = "CREATE USER ROLES";
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Brown;
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(444, 1);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(38, 36);
            this.button32.TabIndex = 348;
            this.button32.TabStop = false;
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // frm_CreateUserRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(484, 747);
            this.ControlBox = false;
            this.Controls.Add(this.button32);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.tv_UserRole);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CreateUserRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_CreateUserRoles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_User;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TreeView tv_UserRole;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button32;
    }
}