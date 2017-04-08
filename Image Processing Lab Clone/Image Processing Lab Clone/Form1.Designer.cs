namespace Image_Processing_Lab_Clone
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelOfCorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourierTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.morphologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomHatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blobsFilteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homogenitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.reApplyToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.morphologyToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.greyscaleToolStripMenuItem,
            this.levelOfCorrectionToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.saturationToolStripMenuItem,
            this.fourierTransformToolStripMenuItem,
            this.detectSkinToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem5});
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.greyscaleToolStripMenuItem.Text = "Greyscale";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.greyscaleToolStripMenuItem_Click);
            // 
            // levelOfCorrectionToolStripMenuItem
            // 
            this.levelOfCorrectionToolStripMenuItem.Name = "levelOfCorrectionToolStripMenuItem";
            this.levelOfCorrectionToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.levelOfCorrectionToolStripMenuItem.Text = "Level of Correction";
            this.levelOfCorrectionToolStripMenuItem.Click += new System.EventHandler(this.levelOfCorrectionToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.thresholdToolStripMenuItem.Text = "Sepia";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // saturationToolStripMenuItem
            // 
            this.saturationToolStripMenuItem.Name = "saturationToolStripMenuItem";
            this.saturationToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.saturationToolStripMenuItem.Text = "Saturation";
            this.saturationToolStripMenuItem.Click += new System.EventHandler(this.saturationToolStripMenuItem_Click);
            // 
            // fourierTransformToolStripMenuItem
            // 
            this.fourierTransformToolStripMenuItem.Name = "fourierTransformToolStripMenuItem";
            this.fourierTransformToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.fourierTransformToolStripMenuItem.Text = "Hue Modifier";
            this.fourierTransformToolStripMenuItem.Click += new System.EventHandler(this.fourierTransformToolStripMenuItem_Click);
            // 
            // detectSkinToolStripMenuItem
            // 
            this.detectSkinToolStripMenuItem.Name = "detectSkinToolStripMenuItem";
            this.detectSkinToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.detectSkinToolStripMenuItem.Text = "Detect Skin";
            this.detectSkinToolStripMenuItem.Click += new System.EventHandler(this.detectSkinToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 386);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(410, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(401, 380);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 380);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // morphologyToolStripMenuItem
            // 
            this.morphologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openingToolStripMenuItem,
            this.closingToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem,
            this.topHatToolStripMenuItem,
            this.bottomHatToolStripMenuItem,
            this.blobsFilteringToolStripMenuItem});
            this.morphologyToolStripMenuItem.Name = "morphologyToolStripMenuItem";
            this.morphologyToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.morphologyToolStripMenuItem.Text = "Morphology";
            // 
            // openingToolStripMenuItem
            // 
            this.openingToolStripMenuItem.Name = "openingToolStripMenuItem";
            this.openingToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openingToolStripMenuItem.Text = "Opening";
            this.openingToolStripMenuItem.Click += new System.EventHandler(this.openingToolStripMenuItem_Click);
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.closingToolStripMenuItem.Text = "Closing";
            this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loopToolStripMenuItem1});
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loopToolStripMenuItem});
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.dilationToolStripMenuItem.Text = "Dilatation";
            this.dilationToolStripMenuItem.Click += new System.EventHandler(this.dilationToolStripMenuItem_Click);
            // 
            // topHatToolStripMenuItem
            // 
            this.topHatToolStripMenuItem.Name = "topHatToolStripMenuItem";
            this.topHatToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.topHatToolStripMenuItem.Text = "Top Hat";
            this.topHatToolStripMenuItem.Click += new System.EventHandler(this.topHatToolStripMenuItem_Click);
            // 
            // bottomHatToolStripMenuItem
            // 
            this.bottomHatToolStripMenuItem.Name = "bottomHatToolStripMenuItem";
            this.bottomHatToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.bottomHatToolStripMenuItem.Text = "Bottom Hat";
            this.bottomHatToolStripMenuItem.Click += new System.EventHandler(this.bottomHatToolStripMenuItem_Click);
            // 
            // loopToolStripMenuItem
            // 
            this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
            this.loopToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loopToolStripMenuItem.Text = "Re-Apply";
            this.loopToolStripMenuItem.Click += new System.EventHandler(this.loopToolStripMenuItem_Click_1);
            // 
            // loopToolStripMenuItem1
            // 
            this.loopToolStripMenuItem1.Name = "loopToolStripMenuItem1";
            this.loopToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.loopToolStripMenuItem1.Text = "Re-Apply";
            this.loopToolStripMenuItem1.Click += new System.EventHandler(this.loopToolStripMenuItem1_Click_1);
            // 
            // blobsFilteringToolStripMenuItem
            // 
            this.blobsFilteringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem});
            this.blobsFilteringToolStripMenuItem.Name = "blobsFilteringToolStripMenuItem";
            this.blobsFilteringToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.blobsFilteringToolStripMenuItem.Text = "Blobs Filtering";
            this.blobsFilteringToolStripMenuItem.Click += new System.EventHandler(this.blobsFilteringToolStripMenuItem_Click);
            // 
            // reApplyToolStripMenuItem
            // 
            this.reApplyToolStripMenuItem.Name = "reApplyToolStripMenuItem";
            this.reApplyToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem.Text = "Re-Apply";
            this.reApplyToolStripMenuItem.Click += new System.EventHandler(this.reApplyToolStripMenuItem_Click);
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homogenitToolStripMenuItem,
            this.differenceToolStripMenuItem,
            this.cobelToolStripMenuItem,
            this.cannyToolStripMenuItem});
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
            // 
            // homogenitToolStripMenuItem
            // 
            this.homogenitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem3});
            this.homogenitToolStripMenuItem.Name = "homogenitToolStripMenuItem";
            this.homogenitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.homogenitToolStripMenuItem.Text = "Homogenity";
            this.homogenitToolStripMenuItem.Click += new System.EventHandler(this.homogenitToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem4});
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // cobelToolStripMenuItem
            // 
            this.cobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem2});
            this.cobelToolStripMenuItem.Name = "cobelToolStripMenuItem";
            this.cobelToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cobelToolStripMenuItem.Text = "Sobel";
            this.cobelToolStripMenuItem.Click += new System.EventHandler(this.cobelToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reApplyToolStripMenuItem1});
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
            // 
            // reApplyToolStripMenuItem1
            // 
            this.reApplyToolStripMenuItem1.Name = "reApplyToolStripMenuItem1";
            this.reApplyToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem1.Text = "Re-Apply";
            this.reApplyToolStripMenuItem1.Click += new System.EventHandler(this.reApplyToolStripMenuItem1_Click);
            // 
            // reApplyToolStripMenuItem2
            // 
            this.reApplyToolStripMenuItem2.Name = "reApplyToolStripMenuItem2";
            this.reApplyToolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem2.Text = "Re-Apply";
            this.reApplyToolStripMenuItem2.Click += new System.EventHandler(this.reApplyToolStripMenuItem2_Click);
            // 
            // reApplyToolStripMenuItem3
            // 
            this.reApplyToolStripMenuItem3.Name = "reApplyToolStripMenuItem3";
            this.reApplyToolStripMenuItem3.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem3.Text = "Re-Apply";
            this.reApplyToolStripMenuItem3.Click += new System.EventHandler(this.reApplyToolStripMenuItem3_Click);
            // 
            // reApplyToolStripMenuItem4
            // 
            this.reApplyToolStripMenuItem4.Name = "reApplyToolStripMenuItem4";
            this.reApplyToolStripMenuItem4.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem4.Text = "Re-Apply";
            this.reApplyToolStripMenuItem4.Click += new System.EventHandler(this.reApplyToolStripMenuItem4_Click);
            // 
            // reApplyToolStripMenuItem5
            // 
            this.reApplyToolStripMenuItem5.Name = "reApplyToolStripMenuItem5";
            this.reApplyToolStripMenuItem5.Size = new System.Drawing.Size(181, 26);
            this.reApplyToolStripMenuItem5.Text = "Re-Apply";
            this.reApplyToolStripMenuItem5.Click += new System.EventHandler(this.reApplyToolStripMenuItem5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 414);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Image Processing Lab Clone";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelOfCorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourierTransformToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem detectSkinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morphologyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topHatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomHatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blobsFilteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homogenitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reApplyToolStripMenuItem1;
    }
}

