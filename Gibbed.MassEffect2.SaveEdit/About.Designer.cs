namespace Gibbed.MassEffect2.SaveEdit {
    partial class About {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contributorsLabel = new System.Windows.Forms.Label();
            this.bannerPictureBox = new System.Windows.Forms.PictureBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.contributorsTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.contributorsLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.bannerPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.productLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.contributorsTextBox, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.okButton, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(416, 295);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // contributorsLabel
            // 
            this.contributorsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contributorsLabel.Location = new System.Drawing.Point(6, 146);
            this.contributorsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.contributorsLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.contributorsLabel.Name = "contributorsLabel";
            this.contributorsLabel.Size = new System.Drawing.Size(407, 17);
            this.contributorsLabel.TabIndex = 25;
            this.contributorsLabel.Text = "Contributors:";
            this.contributorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bannerPictureBox
            // 
            this.bannerPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bannerPictureBox.Image = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.Banner;
            this.bannerPictureBox.Location = new System.Drawing.Point(3, 3);
            this.bannerPictureBox.Name = "bannerPictureBox";
            this.bannerPictureBox.Size = new System.Drawing.Size(410, 120);
            this.bannerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bannerPictureBox.TabIndex = 12;
            this.bannerPictureBox.TabStop = false;
            // 
            // productLabel
            // 
            this.productLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productLabel.Location = new System.Drawing.Point(6, 126);
            this.productLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.productLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(407, 17);
            this.productLabel.TabIndex = 19;
            this.productLabel.Text = "Mass Effect 2 Save Editor";
            this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contributorsTextBox
            // 
            this.contributorsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contributorsTextBox.Location = new System.Drawing.Point(6, 169);
            this.contributorsTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.contributorsTextBox.Multiline = true;
            this.contributorsTextBox.Name = "contributorsTextBox";
            this.contributorsTextBox.ReadOnly = true;
            this.contributorsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contributorsTextBox.Size = new System.Drawing.Size(407, 94);
            this.contributorsTextBox.TabIndex = 23;
            this.contributorsTextBox.TabStop = false;
            this.contributorsTextBox.Text = resources.GetString("contributorsTextBox.Text");
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(338, 269);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // About
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 313);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Mass Effect 2 Save Editor";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox bannerPictureBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.TextBox contributorsTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label contributorsLabel;
    }
}
