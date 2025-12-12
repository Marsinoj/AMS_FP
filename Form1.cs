using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AMS_FP
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            @"Server=DESKTOP-08NV7BO\SQLEXPRESS;Database=ApplicantDB;Trusted_Connection=True;";

        private int? selectedApplicantId = null;

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            lvApplicants.SelectedIndexChanged += lvApplicants_SelectedIndexChanged;
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnArchived.Click += btnArchived_Click;


            cmbFilterStatus.SelectionChangeCommitted += cmbFilterStatus_SelectionChangeCommitted;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            lvApplicants.FullRowSelect = true;
            lvApplicants.View = View.Details;

            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");         
            cmbFilterStatus.Items.Add("Pending");
            cmbFilterStatus.Items.Add("Interviewed");
            cmbFilterStatus.Items.Add("Hired");
            cmbFilterStatus.Items.Add("Rejected");


            cmbFilterStatus.SelectedIndex = 0;

            LoadApplicants();
        }

        private void LoadApplicants(string statusFilter = "All", string search = "")
        {
            lvApplicants.Items.Clear();

            string query = @"SELECT ApplicantId, LastName, FirstName, MiddleName, ContactNo, Position, Status, HiredDate
                             FROM Applicants";

            var whereClauses = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(search))
                {
                    whereClauses.Add("(LastName LIKE @search OR FirstName LIKE @search OR ContactNo LIKE @search)");
                    cmd.Parameters.AddWithValue("@search", "%" + search.Trim() + "%");
                }

                if (!string.Equals(statusFilter, "All", StringComparison.OrdinalIgnoreCase))
                {
                    whereClauses.Add("Status = @status");
                    cmd.Parameters.AddWithValue("@status", statusFilter);
                }

                if (whereClauses.Count > 0)
                    query += " WHERE " + string.Join(" AND ", whereClauses);

                query += " ORDER BY ApplicantId";

                cmd.CommandText = query;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Get ordinals - use the real DB column names
                    int ordApplicantId = reader.GetOrdinal("ApplicantId");
                    int ordLastName = reader.GetOrdinal("LastName");
                    int ordFirstName = reader.GetOrdinal("FirstName");
                    int ordMiddleName = reader.GetOrdinal("MiddleName");
                    int ordContact = reader.GetOrdinal("ContactNo");
                    int ordPosition = reader.GetOrdinal("Position");
                    int ordStatus = reader.GetOrdinal("Status");
                    int ordHiredDate = reader.GetOrdinal("HiredDate");

                    while (reader.Read())
                    {

                        string SafeGet(int ord) => (!reader.IsDBNull(ord)) ? reader.GetValue(ord).ToString() : "";

                        ListViewItem item = new ListViewItem(SafeGet(ordApplicantId)); // [0]
                        item.SubItems.Add(SafeGet(ordLastName));                       // [1]
                        item.SubItems.Add(SafeGet(ordFirstName));                      // [2]
                        item.SubItems.Add(SafeGet(ordContact));                        // [3] <-- ContactNo
                        item.SubItems.Add(SafeGet(ordPosition));                       // [4] <-- Position
                        item.SubItems.Add(SafeGet(ordStatus));                         // [5]
                        item.SubItems.Add(SafeGet(ordHiredDate));                      // [6]

                        lvApplicants.Items.Add(item);
                    }
                }
            }
        }

        private void cmbFilterStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            string searchText = txtSearch.Text.Trim(); // keep current search text if present
            LoadApplicants(status, searchText);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            // Use the currently selected status filter too (so search can be combined with status)
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            LoadApplicants(status, searchText);
        }

        private void btnApplyBoth_Click(object sender, EventArgs e)
        {
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            string searchText = txtSearch.Text.Trim();
            LoadApplicants(status, searchText);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset combobox to All and clear search
            cmbFilterStatus.SelectedIndex = 0;
            txtSearch.Text = "";
            LoadApplicants();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO Applicants
                               (LastName, FirstName, ContactNo,
                                Position, Status, HiredDate)
                               VALUES (@LastName, @FirstName, @ContactNo,
                                       @Position, @Status, @HiredDate)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Position", cmbPosition.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    if (cmbStatus.Text == "Hired")
                        cmd.Parameters.AddWithValue("@HiredDate", dtpHiredDate.Value.Date);
                    else
                        cmd.Parameters.AddWithValue("@HiredDate", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Applicant added successfully.");
            ClearFields();
            LoadApplicants();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedApplicantId == null)
            {
                MessageBox.Show("Please select an applicant to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE Applicants SET
                               LastName=@LastName,
                               FirstName=@FirstName,
                               ContactNo=@ContactNo,
                               Position=@Position,
                               Status=@Status,
                               HiredDate=@HiredDate
                               WHERE ApplicantId=@ApplicantId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantId", selectedApplicantId.Value);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Position", cmbPosition.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    if (cmbStatus.Text == "Hired")
                        cmd.Parameters.AddWithValue("@HiredDate", dtpHiredDate.Value.Date);
                    else
                        cmd.Parameters.AddWithValue("@HiredDate", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Applicant updated.");
            LoadApplicants();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedApplicantId == null)
            {
                MessageBox.Show("Select an applicant first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Move this applicant to archived list?",
                "Archive Applicant",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ArchiveApplicant", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicantId", selectedApplicantId.Value);
                        cmd.Parameters.AddWithValue("@DeletedBy", Environment.UserName);
                        cmd.Parameters.AddWithValue("@DeleteReason", "Archived from system");
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Applicant archived.");
                ClearFields();
                LoadApplicants();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error archiving applicant:\n" + ex.Message);
            }
        }


        private void lvApplicants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApplicants.SelectedItems.Count == 0)
            {
                selectedApplicantId = null;
                return;
            }

            ListViewItem item = lvApplicants.SelectedItems[0];

            string SubText(int idx) => (item.SubItems.Count > idx) ? item.SubItems[idx].Text : "";

            if (!string.IsNullOrWhiteSpace(SubText(0)) && int.TryParse(SubText(0), out int id))
                selectedApplicantId = id;
            else
                selectedApplicantId = null;

            txtLastName.Text = SubText(1);
            txtFirstName.Text = SubText(2);
            txtContact.Text = SubText(3);  
            cmbPosition.Text = SubText(4); 
            cmbStatus.Text = SubText(5);   

            if (!string.IsNullOrWhiteSpace(SubText(6)) && DateTime.TryParse(SubText(6), out DateTime hd))
            {
                dtpHiredDate.Value = hd;
            }
            else
            {
                dtpHiredDate.Value = DateTime.Today;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedApplicantId = null;
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtContact.Text = "";
            cmbPosition.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpHiredDate.Value = DateTime.Today;
        }

        private void btnArchived_Click(object sender, EventArgs e)
        {
            using (ArchivedForm frm = new ArchivedForm(connectionString))
            {
                frm.ShowDialog();
            }

            LoadApplicants();
        }
    }
}
