using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AMS_FP
{
    public partial class ArchivedForm : Form
    {
        public int? RestoredApplicantId { get; private set; }
        private readonly string connectionString;

        public ArchivedForm(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;

            this.Load += ArchivedForm_Load;
            btnSearchArchived.Click += btnSearchArchived_Click;
            btnRestore.Click += btnRestore_Click;
            btnPermanentDelete.Click += btnPermanentDelete_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ArchivedForm_Load(object sender, EventArgs e)
        {
            dgvArchived.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchived.MultiSelect = false;
            dgvArchived.ReadOnly = true;
            dgvArchived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadArchived();
        }


        private void LoadArchived(string search = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT ApplicantId,
                           LastName,
                           FirstName,
                           ContactNo,
                           Position,
                           Status,
                           HiredDate,
                           DeletedBy,
                           DeleteReason,
                           DeletedAt
                    FROM DeletedApplicants
                    WHERE (LastName LIKE @search
                           OR FirstName LIKE @search
                           OR ContactNo LIKE @search)
                    ORDER BY DeletedAt DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvArchived.DataSource = dt;
                }
            }
        }

        private void btnSearchArchived_Click(object sender, EventArgs e)
        {
            LoadArchived(txtSearchArchived.Text.Trim());
        }

        private int? GetSelectedApplicantId()
        {
            if (dgvArchived.SelectedRows.Count == 0)
                return null;

            object value = dgvArchived.SelectedRows[0].Cells["ApplicantId"].Value;
            if (value == null || value == DBNull.Value)
                return null;

            return Convert.ToInt32(value);
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicantId();
            if (id == null)
            {
                MessageBox.Show("Please select an applicant to restore.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Restore this applicant back to the main list?",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_RestoreApplicant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ArchivedApplicantId", id.Value);

                    var outParam = new SqlParameter("@RestoredApplicantId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    object o = outParam.Value;
                    int restoredId = (o != DBNull.Value) ? Convert.ToInt32(o) : -1;

                    MessageBox.Show("Applicant restored successfully (ID: " + restoredId + ").");

                    this.RestoredApplicantId = restoredId;

                    this.DialogResult = DialogResult.OK;

                    LoadArchived(txtSearchArchived.Text.Trim());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error restoring applicant:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error restoring applicant:\n" + ex.Message);
            }
        }


        private void btnPermanentDelete_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicantId();
            if (id == null)
            {
                MessageBox.Show("Please select an applicant to delete permanently.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "This will permanently delete this archived applicant.\nThis action cannot be undone.\n\nContinue?",
                "Permanent Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM DeletedApplicants WHERE ApplicantId = @ApplicantId";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicantId", id.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Archived applicant permanently deleted.");
                LoadArchived(txtSearchArchived.Text.Trim());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error deleting applicant:\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
