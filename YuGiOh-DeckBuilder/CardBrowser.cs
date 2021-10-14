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
    public partial class CardBrowser : Form
    {
        // selecting card so they can return the card info
        private bool selectingCard;
        public int selectedCard { get; set; }

        public CardBrowser(bool a) {
            DefaultInit();
            // if not selecting card
            if (!a) { 
                this.selectingCard = false;
                this.button1.Visible = false;
            } else {
                // if selecting a card
                this.selectingCard = true;
                this.button1.Visible = true;
                this.Text = "Choose a card!";
            }
            this.Text = "Card Browser";
        }

        private void DefaultInit() {
            // init component
            InitializeComponent();
            // load from db
            LoadFromDatabase();
        }

        private void LoadFromDatabase() {
            using (SqlConnection conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true")) {
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [card_image] ,[id] ,[name] ,[description] ,[race] ,[type] FROM [yugioh_db].[dbo].[data]";
                    Debug.WriteLine("processing load from db");
                    // init data table for displaying data
                    DataTable dt = new DataTable();
                    conn.Open();
                    // data reader to read from sql response
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // sql data into datatable
                    dt.Load(rdr);

                    // load into datagrid
                    dataGridView1.DataSource = dt;
                    // hide some column
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["card_image"].Visible = false;
                    // selection mode
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    // selection handler
                    dataGridView1.SelectionChanged += new EventHandler(DataGridView1_SelectionChanged);

                    // close connection
                    conn.Close();
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
            // change displayed image 
            string image_link = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["card_image"].Value.ToString();
            Debug.WriteLine(image_link);
            pictureBox1.Load(image_link);
            this.UpdateSelectedId();

        }

        private void UpdateSelectedId() {
            this.selectedCard = int.Parse( dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString() );
        }
        private void button1_Click(object sender, EventArgs e) {
            // return ok
            this.DialogResult = DialogResult.OK;
            // close 
            this.Close();
        }
    }
}
