namespace AMS_FP
{
    partial class Form1
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
            lvApplicants = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbFilterStatus = new ComboBox();
            btnRefresh = new Button();
            txtLastName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtFirstName = new TextBox();
            label4 = new Label();
            txtContact = new TextBox();
            cmbStatus = new ComboBox();
            dtpHiredDate = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            label5 = new Label();
            cmbPosition = new ComboBox();
            btnArchived = new Button();
            SuspendLayout();
            // 
            // lvApplicants
            // 
            lvApplicants.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader10, columnHeader11, columnHeader12, columnHeader1 });
            lvApplicants.FullRowSelect = true;
            lvApplicants.GridLines = true;
            lvApplicants.Location = new Point(21, 66);
            lvApplicants.Name = "lvApplicants";
            lvApplicants.Size = new Size(811, 254);
            lvApplicants.TabIndex = 0;
            lvApplicants.UseCompatibleStateImageBehavior = false;
            lvApplicants.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "ID";
            columnHeader6.Width = 50;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Last Name";
            columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "First Name";
            columnHeader8.Width = 150;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Contact No.";
            columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Position";
            columnHeader11.Width = 150;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Status";
            columnHeader12.Width = 100;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Hired Date";
            columnHeader1.Width = 100;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(21, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(231, 23);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search Applicants";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(258, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Interviewed", "Hired", "Rejected" });
            cmbFilterStatus.Location = new Point(483, 29);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(168, 23);
            cmbFilterStatus.TabIndex = 3;
            cmbFilterStatus.Text = "Filter";
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(657, 28);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 25);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(111, 342);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(166, 23);
            txtLastName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 348);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 6;
            label1.Text = "Last Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 349);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 7;
            label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(375, 344);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(166, 23);
            txtFirstName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(595, 353);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 11;
            label4.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(666, 346);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(165, 23);
            txtContact.TabIndex = 12;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Interviewed", "Hired", "Rejected" });
            cmbStatus.Location = new Point(330, 384);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(211, 23);
            cmbStatus.TabIndex = 13;
            cmbStatus.Text = "Status";
            // 
            // dtpHiredDate
            // 
            dtpHiredDate.Location = new Point(619, 386);
            dtpHiredDate.Name = "dtpHiredDate";
            dtpHiredDate.ShowCheckBox = true;
            dtpHiredDate.Size = new Size(212, 23);
            dtpHiredDate.TabIndex = 14;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(56, 448);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 35);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(234, 448);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(117, 35);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(424, 448);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(117, 35);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(599, 448);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 35);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 392);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 21;
            label5.Text = "Position";
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Items.AddRange(new object[] { "Network Administrator", "IT Intern", "Cybersecurity Analyst", "IT Assistant", "Junior Software Developer", "QA Tester", " Database Administrator" });
            cmbPosition.Location = new Point(111, 385);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(166, 23);
            cmbPosition.TabIndex = 22;
            // 
            // btnArchived
            // 
            btnArchived.Location = new Point(749, 28);
            btnArchived.Name = "btnArchived";
            btnArchived.Size = new Size(82, 25);
            btnArchived.TabIndex = 23;
            btnArchived.Text = "Archived";
            btnArchived.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 509);
            Controls.Add(btnArchived);
            Controls.Add(cmbPosition);
            Controls.Add(label5);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dtpHiredDate);
            Controls.Add(cmbStatus);
            Controls.Add(txtContact);
            Controls.Add(label4);
            Controls.Add(txtFirstName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(btnRefresh);
            Controls.Add(cmbFilterStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lvApplicants);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvApplicants;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader1;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbFilterStatus;
        private Button btnRefresh;
        private TextBox txtLastName;
        private Label label1;
        private Label label2;
        private TextBox txtFirstName;
        private Label label4;
        private TextBox txtContact;
        private ComboBox cmbStatus;
        private DateTimePicker dtpHiredDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label label5;
        private ComboBox cmbPosition;
        private Button btnArchived;
    }
}
