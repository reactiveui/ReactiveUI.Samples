namespace WinForms.Reactive.Client.Views
{
    partial class ItemsView
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
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.prgItems = new System.Windows.Forms.ProgressBar();
            this.lblEndsWith = new System.Windows.Forms.Label();
            this.lblStartsWith = new System.Windows.Forms.Label();
            this.txtSearchEndsWith = new System.Windows.Forms.TextBox();
            this.txtSearchStartsWith = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ckHasItems = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems.ColumnWidth = 200;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 41;
            this.lstItems.Location = new System.Drawing.Point(47, 122);
            this.lstItems.MultiColumn = true;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(1083, 742);
            this.lstItems.TabIndex = 2;
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDetail.Location = new System.Drawing.Point(1339, 122);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(188, 58);
            this.btnShowDetail.TabIndex = 4;
            this.btnShowDetail.Text = "Show detail";
            this.btnShowDetail.UseVisualStyleBackColor = true;
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.ColumnWidth = 200;
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 41;
            this.lstDetails.Location = new System.Drawing.Point(1136, 204);
            this.lstDetails.MultiColumn = true;
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(391, 660);
            this.lstDetails.TabIndex = 5;
            // 
            // prgItems
            // 
            this.prgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prgItems.Location = new System.Drawing.Point(1136, 31);
            this.prgItems.Name = "prgItems";
            this.prgItems.Size = new System.Drawing.Size(197, 58);
            this.prgItems.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgItems.TabIndex = 6;
            this.prgItems.Visible = false;
            // 
            // lblEndsWith
            // 
            this.lblEndsWith.AutoSize = true;
            this.lblEndsWith.Location = new System.Drawing.Point(490, 40);
            this.lblEndsWith.Name = "lblEndsWith";
            this.lblEndsWith.Size = new System.Drawing.Size(145, 41);
            this.lblEndsWith.TabIndex = 11;
            this.lblEndsWith.Text = "Ends with";
            // 
            // lblStartsWith
            // 
            this.lblStartsWith.AutoSize = true;
            this.lblStartsWith.Location = new System.Drawing.Point(47, 40);
            this.lblStartsWith.Name = "lblStartsWith";
            this.lblStartsWith.Size = new System.Drawing.Size(155, 41);
            this.lblStartsWith.TabIndex = 10;
            this.lblStartsWith.Text = "Starts with";
            // 
            // txtSearchEndsWith
            // 
            this.txtSearchEndsWith.Location = new System.Drawing.Point(641, 37);
            this.txtSearchEndsWith.Name = "txtSearchEndsWith";
            this.txtSearchEndsWith.Size = new System.Drawing.Size(250, 47);
            this.txtSearchEndsWith.TabIndex = 9;
            // 
            // txtSearchStartsWith
            // 
            this.txtSearchStartsWith.Location = new System.Drawing.Point(208, 37);
            this.txtSearchStartsWith.Name = "txtSearchStartsWith";
            this.txtSearchStartsWith.Size = new System.Drawing.Size(250, 47);
            this.txtSearchStartsWith.TabIndex = 8;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(1339, 31);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(188, 58);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // ckHasItems
            // 
            this.ckHasItems.AutoSize = true;
            this.ckHasItems.Enabled = false;
            this.ckHasItems.Location = new System.Drawing.Point(1136, 130);
            this.ckHasItems.Name = "ckHasItems";
            this.ckHasItems.Size = new System.Drawing.Size(185, 45);
            this.ckHasItems.TabIndex = 12;
            this.ckHasItems.Text = "Has items";
            this.ckHasItems.UseVisualStyleBackColor = true;
            // 
            // ItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckHasItems);
            this.Controls.Add(this.lblEndsWith);
            this.Controls.Add(this.lblStartsWith);
            this.Controls.Add(this.txtSearchEndsWith);
            this.Controls.Add(this.txtSearchStartsWith);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.prgItems);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.btnShowDetail);
            this.Controls.Add(this.lstItems);
            this.Name = "ItemsView";
            this.Size = new System.Drawing.Size(1543, 906);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
		private ListBox lstItems;
		private Button btnShowDetail;
		private ListBox lstDetails;
		private ProgressBar prgItems;
		private Label lblEndsWith;
		private Label lblStartsWith;
		private TextBox txtSearchEndsWith;
		private TextBox txtSearchStartsWith;
		private Button btnLoad;
		private CheckBox ckHasItems;
	}
}
