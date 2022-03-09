namespace WinForms.Reactive.Client.Views
{
    partial class ItemsDDView
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtSearchStartsWith = new System.Windows.Forms.TextBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.txtSearchEndsWith = new System.Windows.Forms.TextBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.lblStartsWith = new System.Windows.Forms.Label();
            this.lblEndsWith = new System.Windows.Forms.Label();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(1344, 53);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(188, 58);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // txtSearchStartsWith
            // 
            this.txtSearchStartsWith.Location = new System.Drawing.Point(182, 59);
            this.txtSearchStartsWith.Name = "txtSearchStartsWith";
            this.txtSearchStartsWith.Size = new System.Drawing.Size(250, 47);
            this.txtSearchStartsWith.TabIndex = 1;
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.ColumnWidth = 200;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 41;
            this.lstItems.Location = new System.Drawing.Point(21, 163);
            this.lstItems.MultiColumn = true;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(1511, 701);
            this.lstItems.TabIndex = 2;
            // 
            // txtSearchEndsWith
            // 
            this.txtSearchEndsWith.Location = new System.Drawing.Point(615, 59);
            this.txtSearchEndsWith.Name = "txtSearchEndsWith";
            this.txtSearchEndsWith.Size = new System.Drawing.Size(250, 47);
            this.txtSearchEndsWith.TabIndex = 3;
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Location = new System.Drawing.Point(1028, 57);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(302, 49);
            this.cmbSortBy.TabIndex = 4;
            // 
            // lblStartsWith
            // 
            this.lblStartsWith.AutoSize = true;
            this.lblStartsWith.Location = new System.Drawing.Point(21, 62);
            this.lblStartsWith.Name = "lblStartsWith";
            this.lblStartsWith.Size = new System.Drawing.Size(155, 41);
            this.lblStartsWith.TabIndex = 5;
            this.lblStartsWith.Text = "Starts with";
            // 
            // lblEndsWith
            // 
            this.lblEndsWith.AutoSize = true;
            this.lblEndsWith.Location = new System.Drawing.Point(464, 62);
            this.lblEndsWith.Name = "lblEndsWith";
            this.lblEndsWith.Size = new System.Drawing.Size(145, 41);
            this.lblEndsWith.TabIndex = 6;
            this.lblEndsWith.Text = "Ends with";
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(909, 62);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(113, 41);
            this.lblSortBy.TabIndex = 7;
            this.lblSortBy.Text = "Sort by";
            // 
            // ItemsDDView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.lblEndsWith);
            this.Controls.Add(this.lblStartsWith);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.txtSearchEndsWith);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.txtSearchStartsWith);
            this.Controls.Add(this.btnLoad);
            this.Name = "ItemsDDView";
            this.Size = new System.Drawing.Size(1556, 906);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private Button btnLoad;
		private TextBox txtSearchStartsWith;
		private ListBox lstItems;
		private TextBox txtSearchEndsWith;
		private ComboBox cmbSortBy;
		private Label lblStartsWith;
		private Label lblEndsWith;
		private Label lblSortBy;
	}
}
