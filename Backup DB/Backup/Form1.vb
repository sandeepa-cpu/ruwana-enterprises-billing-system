Imports SQLDMO
Public Class frm_Backup
    Inherits System.Windows.Forms.Form

    Private Svr As SQLDMO.SQLServer
    Private Dbs As SQLDMO.Database
    Private DName As String = ""
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
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EditID As System.Windows.Forms.TextBox
    Friend WithEvents EditPW As System.Windows.Forms.TextBox
    Friend WithEvents EditName As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents EditFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents EditServer As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_Backup))
        Me.lblPercent = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.EditID = New System.Windows.Forms.TextBox
        Me.EditPW = New System.Windows.Forms.TextBox
        Me.EditFile = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.EditName = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.EditServer = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPercent
        '
        Me.lblPercent.Location = New System.Drawing.Point(8, 336)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(40, 16)
        Me.lblPercent.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 18)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(254, 9)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(8, 320)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(208, 14)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Visible = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(275, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Backup Database"
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ListBox1.Location = New System.Drawing.Point(233, 36)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(184, 184)
        Me.ListBox1.TabIndex = 6
        '
        'EditID
        '
        Me.EditID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditID.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditID.Location = New System.Drawing.Point(120, 136)
        Me.EditID.MaxLength = 25
        Me.EditID.Name = "EditID"
        Me.EditID.Size = New System.Drawing.Size(96, 21)
        Me.EditID.TabIndex = 9
        Me.EditID.Text = "sa"
        '
        'EditPW
        '
        Me.EditPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditPW.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditPW.Location = New System.Drawing.Point(120, 160)
        Me.EditPW.MaxLength = 25
        Me.EditPW.Name = "EditPW"
        Me.EditPW.PasswordChar = Microsoft.VisualBasic.ChrW(8226)
        Me.EditPW.Size = New System.Drawing.Size(96, 21)
        Me.EditPW.TabIndex = 10
        Me.EditPW.Text = "sa"
        '
        'EditFile
        '
        Me.EditFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditFile.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditFile.Location = New System.Drawing.Point(135, 236)
        Me.EditFile.MaxLength = 25
        Me.EditFile.Name = "EditFile"
        Me.EditFile.Size = New System.Drawing.Size(281, 21)
        Me.EditFile.TabIndex = 11
        Me.EditFile.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "SQL Server"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "LogIn Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(40, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Password"
        '
        'EditName
        '
        Me.EditName.Location = New System.Drawing.Point(16, 240)
        Me.EditName.Name = "EditName"
        Me.EditName.Size = New System.Drawing.Size(112, 16)
        Me.EditName.TabIndex = 19
        Me.EditName.Text = "Backup File Name"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(234, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Select the Database"
        '
        'RadioButton1
        '
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(24, 88)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(184, 16)
        Me.RadioButton1.TabIndex = 25
        Me.RadioButton1.Text = "Use Windows authentication"
        '
        'RadioButton2
        '
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(24, 112)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(196, 16)
        Me.RadioButton2.TabIndex = 26
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Use SQL Server authentication"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(96, 194)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 22)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Connect to SQL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 57)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect to SQL Server"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 160)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(8, 223)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(414, 41)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.ProgressBar1)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 263)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(415, 39)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(120, 308)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(304, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "2007 Copyright © Ekamuthu Tea Leaf Society™   "
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(229, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(193, 216)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        '
        'EditServer
        '
        Me.EditServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditServer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditServer.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EditServer.Location = New System.Drawing.Point(120, 31)
        Me.EditServer.MaxLength = 25
        Me.EditServer.Name = "EditServer"
        Me.EditServer.Size = New System.Drawing.Size(98, 21)
        Me.EditServer.TabIndex = 8
        Me.EditServer.Text = "(local)"
        '
        'frm_Backup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(428, 327)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.EditName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EditFile)
        Me.Controls.Add(Me.EditPW)
        Me.Controls.Add(Me.EditID)
        Me.Controls.Add(Me.EditServer)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Backup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Backup Database"
        Me.TopMost = True
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Cursor = Cursors.WaitCursor

        'Svr = New SQLDMO.SQLServer
        'Svr.Connect(EditServer.Text, EditID.Text, EditPW.Text)
        'Dbs = New SQLDMO.Database

        'For Each Dbs In Svr.Databases
        '    If Dbs.SystemObject = False Then
        '        ListBox1.Items.Add(Dbs.Name.ToString())
        '    End If
        'Next

        'If ListBox1.Items.Count > 0 Then
        '    ListBox1.SelectedIndex = 0
        '    DName = ListBox1.Items(ListBox1.SelectedIndex)
        'End If

        'Me.Cursor = Cursors.Default

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

        showStatus(0)
        Bstatus()

        Svr.Databases.Item(DName).Shrink(0, SQLDMO_SHRINK_TYPE.SQLDMOShrink_Default)
        Dim SqlScript As String = ""

        If EditFile.Text = "" Then
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                        "TO DISK = 'D:\SQLChequeWrter\Backups\" & DName & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                        "WITH FORMAT,NAME = 'Full Backup of " & DName & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        Else
            SqlScript = "BACKUP DATABASE " & DName & " " & _
                                    "TO DISK = 'D:\SQLChequeWrter\Backups\" & EditFile.Text & " on " & Date.Today.ToString("dd-MMMM-yyyy") & ".Bak' " & _
                                    "WITH FORMAT,NAME = 'Full Backup of " & EditFile.Text & "'"

            Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        End If

        'Svr.ExecuteImmediate(SqlScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError Or SQLDMO_EXEC_TYPE.SQLDMOExec_Default)

        MessageBox.Show("Backup Process Completed!", "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ProgressBar1.Visible = False
        lblMessage.Visible = False
        lblPercent.Visible = False

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        DName = ListBox1.Items(ListBox1.SelectedIndex)
    End Sub
    Private Sub showStatus(ByVal percent As Integer)
        Dim intValue As Integer

        'Me.ProgressBar1.Value = percent
        'Me.ProgressBar1.Refresh()
        'Me.lblPercent.Text = percent & "%"
        'Me.lblPercent.Refresh()

        Me.ProgressBar1.Maximum = 10000
        Do While Not intValue = 10000
            ProgressBar1.Value = intValue
            intValue = intValue + 1
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
    End Sub

 
End Class

