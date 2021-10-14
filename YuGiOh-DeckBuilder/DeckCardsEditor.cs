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
    public partial class DeckCardsEditor : Form
    {
        SqlConnection conn;

        private int deck_id;

        public DeckCardsEditor(int deck_id, string deck_name) {
            InitializeComponent();
            this.deck_id = deck_id;
            this.conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true");
            this.UpdatePicture();
            this.Text = "Deck "+deck_name;
            LoadFromDatabase();
        }

        private void LoadFromDatabase() {
            // get command
            SqlCommand cmd = new SqlCommand("SELECT [card].* FROM[yugioh_db].[dbo].[data] card, [yugioh_db].[dbo].[deck_cards] cardlist WHERE card.[id] = cardlist.[card_id] AND cardlist.[deck_id] = "+this.deck_id,this.conn);
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
            dataGridView1.Columns["card_image"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            // selection mode
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // selection handler
            dataGridView1.SelectionChanged += new EventHandler(DataGridView1_SelectionChanged);

            // close connection
            this.conn.Close();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
            this.UpdatePicture();
        }

        private void UpdatePicture() {
            string image_link = "";
            if (dataGridView1.CurrentRow == null || dataGridView1.Rows.Count == 0) {
                image_link = "https://drive.google.com/uc?export=download&id=1a95KgCqXTHLlYIJM1mC9eJ2bxJNyOW4w";
            } else {
                // change displayed image 
                image_link = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["card_image"].Value.ToString();
            }
            pictureBox1.Load(image_link);
        }

        private void AddCard(int card_id) {
            using (SqlConnection conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true")) {
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [yugioh_db].[dbo].[deck_cards] ([deck_id],[card_id]) VALUES ("+this.deck_id+","+card_id+");";
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
        }

        private void AddCardButton_Click(object sender, EventArgs e) {
            using (var winform = new CardBrowser(true)) {
                var result = winform.ShowDialog();
                if (result == DialogResult.OK) {
                    this.AddCard(winform.selectedCard);
                    LoadFromDatabase();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            int card_id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            using (SqlConnection conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true")) {
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM [yugioh_db].[dbo].[deck_cards] WHERE [deck_id]="+this.deck_id+" AND [card_id]=" +card_id;
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        this.LoadFromDatabase();
                    }
                    catch (SqlException exc) {
                        MessageBox.Show(exc.Message.ToString(), "Error Message");
                    }
                    // close connection
                    this.conn.Close();
                }
            }
            this.UpdatePicture();
        }

        private void SearchButton_Click(object sender, EventArgs e) {
        }
    }
}
