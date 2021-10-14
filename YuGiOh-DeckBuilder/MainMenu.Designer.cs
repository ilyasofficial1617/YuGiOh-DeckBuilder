
namespace YuGiOh_DeckBuilder
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.CreateDeckButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BrowseCardsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditDeckCards = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateDeckButton
            // 
            this.CreateDeckButton.Location = new System.Drawing.Point(233, 39);
            this.CreateDeckButton.Name = "CreateDeckButton";
            this.CreateDeckButton.Size = new System.Drawing.Size(133, 48);
            this.CreateDeckButton.TabIndex = 1;
            this.CreateDeckButton.Text = "Create New Deck";
            this.CreateDeckButton.UseVisualStyleBackColor = true;
            this.CreateDeckButton.Click += new System.EventHandler(this.CreateDeckButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(215, 249);
            this.dataGridView1.TabIndex = 2;
            // 
            // BrowseCardsButton
            // 
            this.BrowseCardsButton.Location = new System.Drawing.Point(233, 256);
            this.BrowseCardsButton.Name = "BrowseCardsButton";
            this.BrowseCardsButton.Size = new System.Drawing.Size(133, 48);
            this.BrowseCardsButton.TabIndex = 3;
            this.BrowseCardsButton.Text = "Browse All Cards";
            this.BrowseCardsButton.UseVisualStyleBackColor = true;
            this.BrowseCardsButton.Click += new System.EventHandler(this.BrowseCardsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "YuGiOh! Deck Builder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description can be hovered.";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(233, 93);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(133, 48);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "Edit Deck Info";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(233, 202);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(133, 48);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete Deck";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditDeckCards
            // 
            this.EditDeckCards.Location = new System.Drawing.Point(233, 147);
            this.EditDeckCards.Name = "EditDeckCards";
            this.EditDeckCards.Size = new System.Drawing.Size(133, 48);
            this.EditDeckCards.TabIndex = 8;
            this.EditDeckCards.Text = "Edit Deck Cards";
            this.EditDeckCards.UseVisualStyleBackColor = true;
            this.EditDeckCards.Click += new System.EventHandler(this.EditDeckCards_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 311);
            this.Controls.Add(this.EditDeckCards);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseCardsButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CreateDeckButton);
            this.Name = "MainMenu";
            this.Text = "YuGiOh! Deck Builder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateDeckButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BrowseCardsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditDeckCards;
    }
}

