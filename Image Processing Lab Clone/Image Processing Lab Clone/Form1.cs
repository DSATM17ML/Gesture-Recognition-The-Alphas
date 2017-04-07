using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.Filters;

namespace Image_Processing_Lab_Clone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openDialog.FileName);
               // Bitmap sampleImage = new Bitmap(openDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bitmap sampleImage = new Bitmap(pictureBox1.ImageLocation);
            //sampleImage = (Bitmap)pictureBox2.Image;
            //sampleImage.Image.Save(@"Path",System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramEqualization histObject = new HistogramEqualization();
            pictureBox2.Image = histObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void levelOfCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelsLinear levelObject = new LevelsLinear();
            pictureBox2.Image = levelObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepia threshObject = new Sepia();
            pictureBox2.Image = threshObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void saturationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaturationCorrection satObject = new SaturationCorrection();
            pictureBox2.Image = satObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void fourierTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HueModifier thresheuObject = new HueModifier();
            pictureBox2.Image = thresheuObject.Apply((Bitmap)pictureBox1.Image);
        }

        private void detectSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0,Max=0,Min=0;
            pictureBox2.InitialImage = null;
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(openDialog.FileName);
                Bitmap skinTest = new Bitmap(openDialog.FileName);
                for (x = 1; x < skinTest.Width - 1; x++)
                {
                    for (y = 1; y < skinTest.Height - 1; y++)
                    {
                        System.Drawing.Color skinTestColor = skinTest.GetPixel(x, y);
                        Max = Math.Max(skinTestColor.R, Math.Max(skinTestColor.G, skinTestColor.B));
                        Min = Math.Min(skinTestColor.R, Math.Min(skinTestColor.G, skinTestColor.B));
                        if (!((skinTestColor.R > 95 && skinTestColor.G > 40 && skinTestColor.B > 20 && (Max - Min) > 15 && Math.Abs(skinTestColor.R - skinTestColor.G) > 15 && skinTestColor.R > skinTestColor.G && skinTestColor.R > skinTestColor.B)))
                        {
                            skinTest.SetPixel(x, y, Color.Black);
                        }

                    }
                    
                }
                pictureBox2.Image = skinTest;
              
            }
            //Bitmap skinTest = new Bitmap(pictureBox1.ImageLocation);
            

        }
        
    }
}
