namespace WinForms.Reactive.Client.Views
{
	partial class ItemTagsView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnShow = new System.Windows.Forms.Button();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblIds = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(762, 43);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(188, 58);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show info";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // lstTags
            // 
            this.lstTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 41;
            this.lstTags.Location = new System.Drawing.Point(34, 43);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(722, 455);
            this.lstTags.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(851, 114);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(99, 41);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIds
            // 
            this.lblIds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIds.Location = new System.Drawing.Point(34, 515);
            this.lblIds.Name = "lblIds";
            this.lblIds.Size = new System.Drawing.Size(722, 41);
            this.lblIds.TabIndex = 3;
            this.lblIds.Text = "Ids";
            // 
            // ItemTagsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 565);
            this.Controls.Add(this.lblIds);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.btnShow);
            this.Name = "ItemTagsView";
            this.Text = "ItemTagsView";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Button btnShow;
		private ListBox lstTags;
		private Label lblCount;
		private Label lblIds;
	}
}
