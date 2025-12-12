namespace AMS_FP
{
    partial class ArchivedForm
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
            dgvArchived = new DataGridView();
            txtSearchArchived = new TextBox();
            btnSearchArchived = new Button();
            btnRestore = new Button();
            btnPermanentDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArchived).BeginInit();
            SuspendLayout();
            // 
            // dgvArchived
            // 
            dgvArchived.AllowUserToAddRows = false;
            dgvArchived.AllowUserToDeleteRows = false;
            dgvArchived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchived.Location = new Point(12, 23);
            dgvArchived.MultiSelect = false;
            dgvArchived.Name = "dgvArchived";
            dgvArchived.ReadOnly = true;
            dgvArchived.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchived.Size = new Size(756, 288);
            dgvArchived.TabIndex = 0;
            // 
            // txtSearchArchived
            // 
            txtSearchArchived.Location = new Point(14, 338);
            txtSearchArchived.Name = "txtSearchArchived";
            txtSearchArchived.Size = new Size(175, 23);
            txtSearchArchived.TabIndex = 1;
            txtSearchArchived.Text = "Search Applicant";
            // 
            // btnSearchArchived
            // 
            btnSearchArchived.Location = new Point(205, 332);
            btnSearchArchived.Name = "btnSearchArchived";
            btnSearchArchived.Size = new Size(89, 32);
            btnSearchArchived.TabIndex = 2;
            btnSearchArchived.Text = "Search";
            btnSearchArchived.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(505, 332);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(89, 32);
            btnRestore.TabIndex = 3;
            btnRestore.Text = "Restore";
            btnRestore.UseVisualStyleBackColor = true;
            // 
            // btnPermanentDelete
            // 
            btnPermanentDelete.Location = new Point(627, 332);
            btnPermanentDelete.Name = "btnPermanentDelete";
            btnPermanentDelete.Size = new Size(141, 32);
            btnPermanentDelete.TabIndex = 4;
            btnPermanentDelete.Text = "Permanent Delete";
            btnPermanentDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(679, 391);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(89, 32);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ArchivedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 454);
            Controls.Add(btnClose);
            Controls.Add(btnPermanentDelete);
            Controls.Add(btnRestore);
            Controls.Add(btnSearchArchived);
            Controls.Add(txtSearchArchived);
            Controls.Add(dgvArchived);
            Name = "ArchivedForm";
            Text = "ArchivedForm";
            ((System.ComponentModel.ISupportInitialize)dgvArchived).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvArchived;
        private TextBox txtSearchArchived;
        private Button btnSearchArchived;
        private Button btnRestore;
        private Button btnPermanentDelete;
        private Button btnClose;
    }
}