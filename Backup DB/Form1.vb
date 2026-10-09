Imports SQLDMO
Public Class frm_Backup
    Inherits System.Windows.Forms.Form

    Private Svr As SQLDMO.SQLServer
    Private Dbs As SQLDMO.Database
    Private DName As String = ""
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents EditFileB As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private RName As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EditID As System.Windows.Forms.TextBox
    Friend WithEvents EditPW As System.Windows.Forms.TextBox
    Friend WithEvents EditName As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Private WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents EditFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EditServer As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Backup))
        Me.lblPercent = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.EditID = New System.Windows.Forms.TextBox
        Me.EditPW = New System.Windows.Forms.TextBox
        Me.EditFile = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.EditName = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.EditServer = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.EditFileB = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPercent
        '
        Me.lblPercent.Location = New System.Drawing.Point(8, 336)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(40, 16)
        Me.lblPercent.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(9, 275)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(108, 14)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ListBox1.ItemHeight = 18
        Me.ListBox1.Location = New System.Drawing.Point(6, 21)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(263, 128)
        Me.ListBox1.TabIndex = 6
        '
        'EditID
        '
        Me.EditID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditID.Enabled = False
        Me.EditID.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditID.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditID.Location = New System.Drawing.Point(292, 105)
        Me.EditID.MaxLength = 25
        Me.EditID.Name = "EditID"
        Me.EditID.Size = New System.Drawing.Size(201, 23)
        Me.EditID.TabIndex = 9
        Me.EditID.Text = "AUTO_ADMIN"
        Me.EditID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EditPW
        '
        Me.EditPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditPW.Enabled = False
        Me.EditPW.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditPW.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditPW.Location = New System.Drawing.Point(292, 135)
        Me.EditPW.MaxLength = 25
        Me.EditPW.Name = "EditPW"
        Me.EditPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.EditPW.Size = New System.Drawing.Size(201, 23)
        Me.EditPW.TabIndex = 10
        Me.EditPW.Text = "147852369"
        Me.EditPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EditFile
        '
        Me.EditFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditFile.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditFile.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditFile.Location = New System.Drawing.Point(148, 37)
        Me.EditFile.MaxLength = 25
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(180, 25)
        Me.EditFile.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(36, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "SQL Server"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(156, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "LogIn Name"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(156, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Password"
        '
        'EditName
        '
        Me.EditName.Location = New System.Drawing.Point(29, 42)
        Me.EditName.Name = "EditName"
        Me.EditName.Size = New System.Drawing.Size(112, 16)
        Me.EditName.TabIndex = 19
        Me.EditName.Text = "Backup File Name"
        '
        'RadioButton1
        '
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(139, 55)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(297, 18)
        Me.RadioButton1.TabIndex = 25
        Me.RadioButton1.Text = "Use Windows Authentication"
        '
        'RadioButton2
        '
        Me.RadioButton2.Checked = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(139, 79)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(328, 18)
        Me.RadioButton2.TabIndex = 26
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Use SQL Server Authentication"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Teal
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(292, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(258, 39)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Connect to SQL Server"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(452, 679)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 20)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "2025 ©"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EditServer
        '
        Me.EditServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditServer.Enabled = False
        Me.EditServer.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditServer.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditServer.Location = New System.Drawing.Point(139, 26)
        Me.EditServer.MaxLength = 25
        Me.EditServer.Name = "EditServer"
        Me.EditServer.Size = New System.Drawing.Size(184, 23)
        Me.EditServer.TabIndex = 8
        Me.EditServer.Text = "DESKTOP-U7JEPVD\HOME"
        Me.EditServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(19, 169)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(578, 13)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Teal
        Me.Button1.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(349, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(248, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Backup Database to PC"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.EditFileB)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.EditFile)
        Me.GroupBox3.Controls.Add(Me.EditName)
        Me.GroupBox3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 430)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(617, 201)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "File Name"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Teal
        Me.Button4.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(349, 81)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(248, 44)
        Me.Button4.TabIndex = 41
        Me.Button4.Text = "Backup Database to USB PEN"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'EditFileB
        '
        Me.EditFileB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditFileB.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditFileB.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditFileB.Location = New System.Drawing.Point(148, 91)
        Me.EditFileB.MaxLength = 25
        Me.EditFileB.Name = "EditFileB"
        Me.EditFileB.Size = New System.Drawing.Size(180, 25)
        Me.EditFileB.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(29, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Backup File Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(248, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 18)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Backup in Progress ...."
        Me.Label6.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.MediumAquamarine
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.EditID)
        Me.GroupBox2.Controls.Add(Me.EditPW)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.EditServer)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(620, 213)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connect to SQL Server"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ListBox1)
        Me.GroupBox5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(181, 275)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(274, 156)
        Me.GroupBox5.TabIndex = 37
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Select the Database ""AUTO_ICS"""
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(141, 256)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(354, 10)
        Me.ProgressBar2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(193, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 18)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Automatically Connecting to SQL Server ...."
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(8, 675)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(573, 29)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Developed by - LOGICAL DATA SOFTWARE SOLUTIONS™"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(610, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 29)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "X"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.ProgressBar2)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(3, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 642)
        Me.Panel1.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(65, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(529, 29)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "RUWANA ENTERPRISES - HORANA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Backup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(645, 702)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.Label7)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Backup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        showStatus(0)
        Me.Cursor = Cursors.WaitCursor

        Svr = New SQLDMO.SQLServer
        Svr.Connect(EditServer.Text, EditID.Text, EditPW.Text)
        Dbs = New SQLDMO.Database

        For Each Dbs In Svr.Databases
            If Dbs.SystemObject = False Then
                ListBox1.Items.Add(Dbs.Name.ToString())
            End If
        Next

        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
            DName = ListBox1.Items(ListBox1.SelectedIndex)
        End If

        Me.Cursor = Cursors.Default
        EditFile.Focus()

        AUTO()
    End Sub

    Sub AUTO()
        Me.Cursor = Cursors.WaitCursor

        Svr = New SQLDMO.SQLServer
        Svr.Connect(EditServer.Text, EditID.Text, EditPW.Text)
        Dbs = New SQLDMO.Database

        For Each Dbs In Svr.Databases
            If Dbs.SystemObject = False Then
                ListBox1.Items.Add(Dbs.Name.ToString())
            End If
        Next

        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
            DName = ListBox1.Items(ListBox1.SelectedIndex)
        End If

        Me.Cursor = Cursors.Default
        Button2.Enabled = False
        Button1.Enabled = True
        EditFile.Focus()
    End Sub
    Sub Bstatus()
        lblMessage.Text = "Backup in Prograss..... Please wait."
        ProgressBar1.Visible = True
    End Sub

    Sub Rstatus()
        lblMessage.Text = "Restoration in Prograss..... Please wait."
        ProgressBar1.Visible = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Cursor = Cursors.WaitCursor

        If DName = "" Then
            MessageBox.Show("Select Database, Before Taking Backup", "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Label6.Visible = True
        showStatus(0)
        Bstatus()

        Svr.Databases.Item(DName).Shrink(0, SQLDMO_SHRINK_TYPE.SQLDMOShrink_Default)
        Dim SqlScript As String = ""

        If EditFile.Text = "" Then
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                        "TO DISK = 'G:\System Files\DATABASE BACKUPS\" & DName & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                        "WITH FORMAT,NAME = 'Full Backup of " & DName & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        Else
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                                    "TO DISK = 'G:\System Files\DATABASE BACKUPS\" & EditFile.Text & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                                    "WITH FORMAT,NAME = 'Full Backup of " & EditFile.Text & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        End If

        'Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        MessageBox.Show("Backup Process Completed!", "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ProgressBar1.Visible = False
        lblMessage.Visible = False
        lblPercent.Visible = False

        Me.Cursor = Cursors.Default
        Label6.Visible = False

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        DName = ListBox1.Items(ListBox1.SelectedIndex)

    End Sub
    Private Sub showStatus(ByVal percent As Integer)
        Dim intValue As Integer
        Dim intValue1 As Integer

        'Me.ProgressBar1.Value = percent
        'Me.ProgressBar1.Refresh()
        'Me.lblPercent.Text = percent & "%"
        'Me.lblPercent.Refresh()

        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar2.Maximum = 100
        Do While Not intValue = 100
            ProgressBar1.Value = intValue
            intValue = intValue + 1
            ProgressBar2.Value = intValue1
            intValue1 = intValue1 + 1

        Loop
        'System.Threading.Thread.Sleep(2000)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = Cursors.WaitCursor

        Svr = New SQLDMO.SQLServer
        Svr.Connect(EditServer.Text, EditID.Text, EditPW.Text)
        Dbs = New SQLDMO.Database

        For Each Dbs In Svr.Databases
            If Dbs.SystemObject = False Then
                ListBox1.Items.Add(Dbs.Name.ToString())
            End If
        Next

        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
            DName = ListBox1.Items(ListBox1.SelectedIndex)
        End If

        Me.Cursor = Cursors.Default
        Button2.Enabled = False
        Button1.Enabled = True
        EditFile.Focus()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Button2.Focus()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub EditID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditID.TextChanged

    End Sub

    Private Sub EditPW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedValueChanged

    End Sub

    Private Sub ListBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.Enter
        ProgressBar2.Visible = False
        Label5.Text = "Successfully Connected to SQL Server ...."
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DName = "" Then
            MessageBox.Show("Select Database, Before Taking Backup", "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Label6.Visible = True
        showStatus(0)
        Bstatus()

        Svr.Databases.Item(DName).Shrink(0, SQLDMO_SHRINK_TYPE.SQLDMOShrink_Default)
        Dim SqlScript As String = ""

        If EditFile.Text = "" Then
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                        "TO DISK = 'E:\" & DName & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                        "WITH FORMAT,NAME = 'Full Backup of " & DName & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        Else
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                                    "TO DISK = 'E:\" & EditFile.Text & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                                    "WITH FORMAT,NAME = 'Full Backup of " & EditFile.Text & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        End If

        'Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        MessageBox.Show("Backup Process Completed!", "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ProgressBar1.Visible = False
        lblMessage.Visible = False
        lblPercent.Visible = False

        Me.Cursor = Cursors.Default
        Label6.Visible = False
    End Sub
End Class

