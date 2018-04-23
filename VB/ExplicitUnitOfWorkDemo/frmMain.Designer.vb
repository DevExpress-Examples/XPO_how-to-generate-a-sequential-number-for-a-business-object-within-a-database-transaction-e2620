Imports Microsoft.VisualBasic
Imports System
Namespace ExplicitUnitOfWorkDemo
	Partial Public Class frmMain
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.xpView1 = New DevExpress.Xpo.XPView()
			Me.unitOfWork1 = New DevExpress.Xpo.UnitOfWork()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colOid = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colAge = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colSex = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colAddress = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.btnRecreateAddress = New DevExpress.XtraEditors.SimpleButton()
			Me.btnCreatePerson = New DevExpress.XtraEditors.SimpleButton()
			Me.btnCreatePersons = New DevExpress.XtraEditors.SimpleButton()
			Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
			Me.spinEdit1 = New DevExpress.XtraEditors.SpinEdit()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.btnClearDB = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xpView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.unitOfWork1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.spinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.gridControl1.DataSource = Me.xpView1
			Me.gridControl1.Location = New System.Drawing.Point(12, 42)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(798, 424)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' xpView1
			' 
			Me.xpView1.ObjectType = GetType(ExplicitUnitOfWorkDemo.Person)
			Me.xpView1.Properties.AddRange(New DevExpress.Xpo.ViewProperty() { New DevExpress.Xpo.ViewProperty("Oid", DevExpress.Xpo.SortDirection.Ascending, "[Oid]", False, True), New DevExpress.Xpo.ViewProperty("Name", DevExpress.Xpo.SortDirection.None, "[FirstName] + ' ' + [LastName]", False, True), New DevExpress.Xpo.ViewProperty("Age", DevExpress.Xpo.SortDirection.None, "[Age]", False, True), New DevExpress.Xpo.ViewProperty("Sex", DevExpress.Xpo.SortDirection.None, "[Sex]", False, True), New DevExpress.Xpo.ViewProperty("Address", DevExpress.Xpo.SortDirection.None, "ToStr([Address.Oid]) + ': ' + [Address.Country] + ', ' + [Address.Province] + ', " & "' + [Address.City] + ', ' + [Address.Address1] + ', ' + [Address.Address2]", False, True)})
			Me.xpView1.Session = Me.unitOfWork1
			'
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colOid, Me.colName, Me.colAge, Me.colSex, Me.colAddress})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsView.ShowFooter = True
			' 
			' colOid
			' 
			Me.colOid.Caption = "Oid"
			Me.colOid.FieldName = "Oid"
			Me.colOid.Name = "colOid"
			Me.colOid.OptionsColumn.FixedWidth = True
			Me.colOid.Visible = True
			Me.colOid.VisibleIndex = 0
			' 
			' colName
			' 
			Me.colName.FieldName = "Name"
			Me.colName.Name = "colName"
			Me.colName.OptionsColumn.FixedWidth = True
			Me.colName.OptionsColumn.ReadOnly = True
			Me.colName.Visible = True
			Me.colName.VisibleIndex = 1
			Me.colName.Width = 176
			' 
			' colAge
			' 
			Me.colAge.FieldName = "Age"
			Me.colAge.Name = "colAge"
			Me.colAge.OptionsColumn.FixedWidth = True
			Me.colAge.OptionsColumn.ReadOnly = True
			Me.colAge.Visible = True
			Me.colAge.VisibleIndex = 2
			Me.colAge.Width = 61
			' 
			' colSex
			' 
			Me.colSex.FieldName = "Sex"
			Me.colSex.Name = "colSex"
			Me.colSex.OptionsColumn.FixedWidth = True
			Me.colSex.OptionsColumn.ReadOnly = True
			Me.colSex.Visible = True
			Me.colSex.VisibleIndex = 3
			Me.colSex.Width = 66
			' 
			' colAddress
			' 
			Me.colAddress.FieldName = "Address"
			Me.colAddress.Name = "colAddress"
			Me.colAddress.OptionsColumn.ReadOnly = True
			Me.colAddress.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
			Me.colAddress.Visible = True
			Me.colAddress.VisibleIndex = 4
			Me.colAddress.Width = 477
			' 
			' btnRecreateAddress
			' 
			Me.btnRecreateAddress.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRecreateAddress.Location = New System.Drawing.Point(543, 477)
			Me.btnRecreateAddress.Name = "btnRecreateAddress"
			Me.btnRecreateAddress.Size = New System.Drawing.Size(267, 23)
			Me.btnRecreateAddress.TabIndex = 1
			Me.btnRecreateAddress.Text = "Recreate address for the selected person"
'			Me.btnRecreateAddress.Click += New System.EventHandler(Me.btnRecreateAddress_Click);
			' 
			' btnCreatePerson
			' 
			Me.btnCreatePerson.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCreatePerson.Location = New System.Drawing.Point(224, 477)
			Me.btnCreatePerson.Name = "btnCreatePerson"
			Me.btnCreatePerson.Size = New System.Drawing.Size(206, 23)
			Me.btnCreatePerson.TabIndex = 2
			Me.btnCreatePerson.Text = "Create person with a new address"
'			Me.btnCreatePerson.Click += New System.EventHandler(Me.btnCreatePerson_Click);
			' 
			' btnCreatePersons
			' 
			Me.btnCreatePersons.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCreatePersons.Location = New System.Drawing.Point(12, 477)
			Me.btnCreatePersons.Name = "btnCreatePersons"
			Me.btnCreatePersons.Size = New System.Drawing.Size(206, 23)
			Me.btnCreatePersons.TabIndex = 3
			Me.btnCreatePersons.Text = "Create many persons"
'			Me.btnCreatePersons.Click += New System.EventHandler(Me.btnCreatePersons_Click);
			' 
			' btnUpdate
			' 
			Me.btnUpdate.Location = New System.Drawing.Point(261, 13)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New System.Drawing.Size(121, 23)
			Me.btnUpdate.TabIndex = 4
			Me.btnUpdate.Text = "Update"
'			Me.btnUpdate.Click += New System.EventHandler(Me.btnUpdate_Click);
			' 
			' spinEdit1
			' 
			Me.spinEdit1.EditValue = New Decimal(New Integer() { 0, 0, 0, 0})
			Me.spinEdit1.Location = New System.Drawing.Point(66, 15)
			Me.spinEdit1.Name = "spinEdit1"
			Me.spinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.spinEdit1.Size = New System.Drawing.Size(189, 20)
			Me.spinEdit1.TabIndex = 5
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(12, 18)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(48, 13)
			Me.labelControl1.TabIndex = 6
			Me.labelControl1.Text = "Top rows:"
			' 
			' btnClearDB
			' 
			Me.btnClearDB.Location = New System.Drawing.Point(689, 13)
			Me.btnClearDB.Name = "btnClearDB"
			Me.btnClearDB.Size = New System.Drawing.Size(121, 23)
			Me.btnClearDB.TabIndex = 7
			Me.btnClearDB.Text = "Clear database"
'			Me.btnClearDB.Click += New System.EventHandler(Me.btnClearDB_Click);
			' 
			' Form1
			' 
			Me.AcceptButton = Me.btnUpdate
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(822, 512)
			Me.Controls.Add(Me.btnClearDB)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.spinEdit1)
			Me.Controls.Add(Me.btnUpdate)
			Me.Controls.Add(Me.btnCreatePersons)
			Me.Controls.Add(Me.btnCreatePerson)
			Me.Controls.Add(Me.btnRecreateAddress)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xpView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.unitOfWork1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.spinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private WithEvents btnRecreateAddress As DevExpress.XtraEditors.SimpleButton
		Private xpView1 As DevExpress.Xpo.XPView
		Private colName As DevExpress.XtraGrid.Columns.GridColumn
		Private colAge As DevExpress.XtraGrid.Columns.GridColumn
		Private colSex As DevExpress.XtraGrid.Columns.GridColumn
		Private colAddress As DevExpress.XtraGrid.Columns.GridColumn
		Private colOid As DevExpress.XtraGrid.Columns.GridColumn
		Private WithEvents btnCreatePerson As DevExpress.XtraEditors.SimpleButton
		Private unitOfWork1 As DevExpress.Xpo.UnitOfWork
		Private WithEvents btnCreatePersons As DevExpress.XtraEditors.SimpleButton
		Private WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
		Private spinEdit1 As DevExpress.XtraEditors.SpinEdit
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private WithEvents btnClearDB As DevExpress.XtraEditors.SimpleButton
	End Class
End Namespace

