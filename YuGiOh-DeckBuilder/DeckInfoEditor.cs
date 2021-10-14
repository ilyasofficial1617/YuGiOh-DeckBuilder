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
    public partial class DeckInfoEditor : Form
    {
        private bool editExistingDeck = true;
        private int id;
        
        public DeckInfoEditor(int id, string name, string desc) {
            InitializeComponent();
            // when editing existing deck
            CreateButton.Visible = false;
            this.id = id;
            this.textBox1.Text = name;
            this.richTextBox1.Text = desc;

        }

        public DeckInfoEditor(bool a) {
            InitializeComponent();
            // when creating new deck
            if (!a) {
                editExistingDeck = false;
                SaveButton.Visible = false;
            }
        }



        private void label2_Click(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void CreateButton_Click(object sender, EventArgs e) {
            using (SqlConnection conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true")) {
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [yugioh_db].[dbo].[deck] ([name],[desc]) VALUES('"
                                      + textBox1.Text
                                      + "','"
                                      + richTextBox1.Text
                                      + "')";

                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        // return ok
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (SqlException exc) {
                        MessageBox.Show(exc.Message.ToString(), "Error Message");
                    }
                    // close 
                    this.Close();


                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            using (SqlConnection conn = new SqlConnection("server=DESKTOP-ALPCPUC\\SQLEXPRESS;database=yugioh_db;trusted_connection=true")) {
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [yugioh_db].[dbo].[deck] SET name='"
                        +this.textBox1.Text
                        + "', [desc]='"
                        +this.richTextBox1.Text
                        +"' WHERE id="
                        +this.id.ToString();

                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        // return ok
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (SqlException exc) {
                        MessageBox.Show(exc.Message.ToString(), "Error Message");
                    }
                    // close 
                    this.Close();
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
