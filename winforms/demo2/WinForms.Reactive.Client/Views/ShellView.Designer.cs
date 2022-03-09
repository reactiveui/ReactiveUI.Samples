namespace WinForms.Reactive.Client
{
	partial class ShellView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellView));
            this.routedControlHost = new ReactiveUI.Winforms.RoutedControlHost();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnMainItems = new System.Windows.Forms.ToolStripButton();
            this.btnMainItemsDD = new System.Windows.Forms.ToolStripButton();
            this.mnuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // routedControlHost
            // 
            this.routedControlHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routedControlHost.DefaultContent = null;
            this.routedControlHost.Location = new System.Drawing.Point(-9, 103);
            this.routedControlHost.Name = "routedControlHost";
            this.routedControlHost.Router = null;
            this.routedControlHost.Size = new System.Drawing.Size(1624, 867);
            this.routedControlHost.TabIndex = 0;
            this.routedControlHost.ViewLocator = null;
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1627, 49);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuMainFile
            // 
            this.mnuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileClose});
            this.mnuMainFile.Name = "mnuMainFile";
            this.mnuMainFile.Size = new System.Drawing.Size(87, 45);
            this.mnuMainFile.Text = "File";
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.Size = new System.Drawing.Size(257, 54);
            this.mnuFileClose.Text = "Close";
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMainItems,
            this.btnMainItemsDD});
            this.tsMain.Location = new System.Drawing.Point(0, 49);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1627, 51);
            this.tsMain.TabIndex = 2;
            // 
            // btnMainItems
            // 
            this.btnMainItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMainItems.Image = ((System.Drawing.Image)(resources.GetObject("btnMainItems.Image")));
            this.btnMainItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMainItems.Name = "btnMainItems";
            this.btnMainItems.Size = new System.Drawing.Size(58, 44);
            this.btnMainItems.Text = "Items";
            // 
            // btnMainItemsDD
            // 
            this.btnMainItemsDD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMainItemsDD.Image = ((System.Drawing.Image)(resources.GetObject("btnMainItemsDD.Image")));
            this.btnMainItemsDD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMainItemsDD.Name = "btnMainItemsDD";
            this.btnMainItemsDD.Size = new System.Drawing.Size(58, 44);
            this.btnMainItemsDD.Text = "ItemsDD";
            // 
            // ShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 982);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.routedControlHost);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "ShellView";
            this.Text = "ShellView";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ReactiveUI.Winforms.RoutedControlHost routedControlHost;
		private MenuStrip mnuMain;
		private ToolStripMenuItem mnuMainFile;
		private ToolStripMenuItem mnuFileClose;
		private ToolStrip tsMain;
		private ToolStripButton btnMainItems;
		private ToolStripButton btnMainItemsDD;
	}
}
