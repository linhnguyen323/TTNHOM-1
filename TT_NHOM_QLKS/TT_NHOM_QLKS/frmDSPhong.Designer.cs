namespace TT_NHOM_QLKS
{
    partial class frmDSPhong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSPhong));
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.contextMenuStripDangKy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dangKyPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripDangKy.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.ContextMenuStrip = this.contextMenuStripDangKy;
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx1.LargeImageList = this.imageList1;
            this.listViewEx1.Location = new System.Drawing.Point(0, 0);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(512, 343);
            this.listViewEx1.TabIndex = 1;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStripDangKy
            // 
            this.contextMenuStripDangKy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangKyPhongToolStripMenuItem,
            this.traPhongToolStripMenuItem});
            this.contextMenuStripDangKy.Name = "contextMenuStripDangKy";
            this.contextMenuStripDangKy.Size = new System.Drawing.Size(156, 70);
            // 
            // dangKyPhongToolStripMenuItem
            // 
            this.dangKyPhongToolStripMenuItem.Name = "dangKyPhongToolStripMenuItem";
            this.dangKyPhongToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dangKyPhongToolStripMenuItem.Text = "Dang ky phong";
            this.dangKyPhongToolStripMenuItem.Click += new System.EventHandler(this.dangKyPhongToolStripMenuItem_Click);
            // 
            // traPhongToolStripMenuItem
            // 
            this.traPhongToolStripMenuItem.Name = "traPhongToolStripMenuItem";
            this.traPhongToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.traPhongToolStripMenuItem.Text = "Tra phong";
            this.traPhongToolStripMenuItem.Click += new System.EventHandler(this.traPhongToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "NhaCungUng.png");
            this.imageList1.Images.SetKeyName(1, "CaNhan.png");
            this.imageList1.Images.SetKeyName(2, "CaNhan2.png");
            // 
            // frmDSPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 343);
            this.Controls.Add(this.listViewEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDSPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.contextMenuStripDangKy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDangKy;
        private System.Windows.Forms.ToolStripMenuItem dangKyPhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traPhongToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}