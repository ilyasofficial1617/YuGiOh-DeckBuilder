using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOh_DeckBuilder
{
    public partial class MainMenu : Form
    {
        SqlConnection conn;
        public MainMenu() {
            InitializeComponent();
            this.conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true");
            LoadFromDatabase();
        }

        private void BrowseCardsButton_Click(object sender, EventArgs e) {
            using (var winform = new CardBrowser(false)) {
                winform.ShowDialog();
            }
        }

        private void CreateDeckButton_Click(object sender, EventArgs e) {
            using (var winform = new DeckInfoEditor(false)) {
                var result = winform.ShowDialog();
                if (result == DialogResult.OK) {
                    LoadFromDatabase();
                }
            }
        }

        private void LoadFromDatabase() {
            // get command
            SqlCommand cmd = new SqlCommand("SELECT [name] ,[id] ,[desc] FROM [yugioh_db].[dbo].[deck] ORDER BY id DESC", this.conn);
            // open connection
            this.conn.Open();
            // init data table for displaying data
            DataTable dt = new DataTable();
            // data reader to read from sql response
            SqlDataReader rdr = cmd.ExecuteReader();

            // sql data into datatable
            dt.Load(rdr);

            // load into datagrid
            dataGridView1.DataSource = dt;
            // hide some column
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            // selection mode
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // selection id variable
            // int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());

            // close connection
            this.conn.Close();
        }

        private int GetCurrentId() {
            return(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString()));
        }
        private string GetCurrentName() {
            return (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["name"].Value.ToString());
        }

        private void EditButton_Click(object sender, EventArgs e) {
            int id = GetCurrentId();
            string name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["name"].Value.ToString();
            string desc = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["desc"].Value.ToString();
            using (var winform = new DeckInfoEditor(id, name, desc)) {
                var result = winform.ShowDialog();
                if (result == DialogResult.OK) {
                    LoadFromDatabase();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            // delete selected id
            DeleteDeck(  int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString())  );
            // update data again 
            LoadFromDatabase();
        }

        private void DeleteDeck(int id) {
            using (SqlCommand cmd = new SqlCommand()) {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM [yugioh_db].[dbo].[deck] WHERE id=" + id.ToString();
                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exc) {
                    MessageBox.Show(exc.Message.ToString(), "Error Message");
                }
                // close connection
                this.conn.Close();
            }

            
        }

        private void EditDeckCards_Click(object sender, EventArgs e) {
            using (var winform = new DeckCardsEditor( GetCurrentId(), GetCurrentName() )) {
                // show and not waiting for result
                winform.ShowDialog();
            }
        }
    }
}
