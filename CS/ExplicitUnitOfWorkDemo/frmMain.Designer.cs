namespace ExplicitUnitOfWorkDemo {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.xpView1 = new DevExpress.Xpo.XPView();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRecreateAddress = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreatePerson = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreatePersons = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnClearDB = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.xpView1;
            this.gridControl1.Location = new System.Drawing.Point(12, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(798, 424);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xpView1
            // 
            this.xpView1.ObjectType = typeof(ExplicitUnitOfWorkDemo.Person);
            this.xpView1.Properties.AddRange(new DevExpress.Xpo.ViewProperty[] {
            new DevExpress.Xpo.ViewProperty("Oid", DevExpress.Xpo.SortDirection.Ascending, "[Oid]", false, true),
            new DevExpress.Xpo.ViewProperty("Name", DevExpress.Xpo.SortDirection.None, "[FirstName] + \' \' + [LastName]", false, true),
            new DevExpress.Xpo.ViewProperty("Age", DevExpress.Xpo.SortDirection.None, "[Age]", false, true),
            new DevExpress.Xpo.ViewProperty("Sex", DevExpress.Xpo.SortDirection.None, "[Sex]", false, true),
            new DevExpress.Xpo.ViewProperty("Address", DevExpress.Xpo.SortDirection.None, "ToStr([Address.Oid]) + \': \' + [Address.Country] + \', \' + [Address.Province] + \', " +
                    "\' + [Address.City] + \', \' + [Address.Address1] + \', \' + [Address.Address2]", false, true)});
            this.xpView1.Session = this.unitOfWork1;
            //
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colName,
            this.colAge,
            this.colSex,
            this.colAddress});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colOid
            // 
            this.colOid.Caption = "Oid";
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            this.colOid.OptionsColumn.FixedWidth = true;
            this.colOid.Visible = true;
            this.colOid.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.FixedWidth = true;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 176;
            // 
            // colAge
            // 
            this.colAge.FieldName = "Age";
            this.colAge.Name = "colAge";
            this.colAge.OptionsColumn.FixedWidth = true;
            this.colAge.OptionsColumn.ReadOnly = true;
            this.colAge.Visible = true;
            this.colAge.VisibleIndex = 2;
            this.colAge.Width = 61;
            // 
            // colSex
            // 
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.OptionsColumn.FixedWidth = true;
            this.colSex.OptionsColumn.ReadOnly = true;
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 3;
            this.colSex.Width = 66;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 477;
            // 
            // btnRecreateAddress
            // 
            this.btnRecreateAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecreateAddress.Location = new System.Drawing.Point(543, 477);
            this.btnRecreateAddress.Name = "btnRecreateAddress";
            this.btnRecreateAddress.Size = new System.Drawing.Size(267, 23);
            this.btnRecreateAddress.TabIndex = 1;
            this.btnRecreateAddress.Text = "Recreate address for the selected person";
            this.btnRecreateAddress.Click += new System.EventHandler(this.btnRecreateAddress_Click);
            // 
            // btnCreatePerson
            // 
            this.btnCreatePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreatePerson.Location = new System.Drawing.Point(224, 477);
            this.btnCreatePerson.Name = "btnCreatePerson";
            this.btnCreatePerson.Size = new System.Drawing.Size(206, 23);
            this.btnCreatePerson.TabIndex = 2;
            this.btnCreatePerson.Text = "Create person with a new address";
            this.btnCreatePerson.Click += new System.EventHandler(this.btnCreatePerson_Click);
            // 
            // btnCreatePersons
            // 
            this.btnCreatePersons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreatePersons.Location = new System.Drawing.Point(12, 477);
            this.btnCreatePersons.Name = "btnCreatePersons";
            this.btnCreatePersons.Size = new System.Drawing.Size(206, 23);
            this.btnCreatePersons.TabIndex = 3;
            this.btnCreatePersons.Text = "Create many persons";
            this.btnCreatePersons.Click += new System.EventHandler(this.btnCreatePersons_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(261, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(66, 15);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Size = new System.Drawing.Size(189, 20);
            this.spinEdit1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Top rows:";
            // 
            // btnClearDB
            // 
            this.btnClearDB.Location = new System.Drawing.Point(689, 13);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(121, 23);
            this.btnClearDB.TabIndex = 7;
            this.btnClearDB.Text = "Clear database";
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 512);
            this.Controls.Add(this.btnClearDB);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreatePersons);
            this.Controls.Add(this.btnCreatePerson);
            this.Controls.Add(this.btnRecreateAddress);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnRecreateAddress;
        private DevExpress.Xpo.XPView xpView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAge;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraEditors.SimpleButton btnCreatePerson;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.SimpleButton btnCreatePersons;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClearDB;
    }
}

