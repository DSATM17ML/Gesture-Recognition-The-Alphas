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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Accord.Imaging;
using AForge.Imaging.Textures;

namespace Image_Processing_Lab_Clone
{
    public partial class Form1 : Form
    {
        public Bitmap srcImg, dstImg;
        IntPoint blobCor;
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap resize(Bitmap image, Size size)
        {
            return (Bitmap)(new Bitmap(image, size));
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openDialog.FileName);
                srcImg = new Bitmap(openDialog.FileName);
                dstImg = new Bitmap(openDialog.FileName);
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Image Files (*.jpg)|*.jpg";
            saveDialog.DefaultExt = "jpg";
            try
            {
                Bitmap saveImg = new Bitmap(pictureBox2.Image);
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    saveImg.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("No Valid Image");
            }

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramEqualization histObject = new HistogramEqualization();
            pictureBox2.Image = histObject.Apply((Bitmap)pictureBox1.Image);
            dstImg = histObject.Apply(dstImg);
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
            dstImg = grayObject.Apply(dstImg);
        }

        private void levelOfCorrectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelsLinear levelObject = new LevelsLinear();
            pictureBox2.Image = levelObject.Apply((Bitmap)pictureBox1.Image);
            dstImg = levelObject.Apply(dstImg);
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
            dstImg = threshObject.Apply(dstImg);
        }

        private void saturationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaturationCorrection satObject = new SaturationCorrection();
            pictureBox2.Image = satObject.Apply((Bitmap)pictureBox1.Image);
            dstImg = satObject.Apply(dstImg);
        }

        private void fourierTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HueModifier thresheuObject = new HueModifier();
                pictureBox2.Image = thresheuObject.Apply((Bitmap)pictureBox1.Image);
                dstImg = thresheuObject.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Not Possible");
            }
        }

        private void detectSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap sampleImage = new Bitmap(pictureBox1.Image);
            var rect = new Rectangle(0, 0, sampleImage.Width, sampleImage.Height);
            var data = sampleImage.LockBits(rect, ImageLockMode.ReadWrite, sampleImage.PixelFormat);
            var depth = Bitmap.GetPixelFormatSize(data.PixelFormat) / 8; //bytes per pixel

            var buffer = new byte[data.Width * data.Height * depth];

            //copy pixels to buffer
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

            System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    //upper-left
                    Process(buffer, 0, 0, data.Width / 2, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //upper-right
                    Process(buffer, data.Width / 2, 0, data.Width, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //lower-left
                    Process(buffer, 0, data.Height / 2, data.Width / 2, data.Height, data.Width, depth);
                },
                () =>
                {
                    //lower-right
                    Process(buffer, data.Width / 2, data.Height / 2, data.Width, data.Height, data.Width, depth);
                }
            );

            //Copy the buffer back to image
            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);

            sampleImage.UnlockBits(data);
            pictureBox2.Image = sampleImage;
            dstImg = sampleImage;
        }

        void Process(byte[] buffer, int x, int y, int endx, int endy, int width, int depth)
        {
            for (int i = x; i < endx; i++)
            {
                for (int j = y; j < endy; j++)
                {
                    var offset = ((j * width) + i) * depth;
                    var B = buffer[offset + 0];
                    var G = buffer[offset + 1];
                    var R = buffer[offset + 2];
                    var a = Math.Max(R, Math.Max(B, G));
                    var b = Math.Min(R, Math.Min(B, G));
                    if (!(((R > 95) && (G > 40) && (B > 20) && ((a - b) > 15) && (Math.Abs(R - G) > 15) && (R > G) && (R > B)) || ((R > 220) && (G > 210) && (B > 170) && ((a - b) > 15) && (Math.Abs(R - G) > 15) && (R > G) && (G > B))))
                    {
                        buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = 0;
                    }
                    else
                    {
                        buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = 255;
                    }
                }
            }

            /*int x = 0, y = 0, Max = 0, Min = 0;
            pictureBox2.InitialImage = null;
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openDialog.FileName);
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
            }*/


            //Bitmap skinTst = new Bitmap(pictureBox1.ImageLocation);


            /*            
                  int x = 0, y = 0, Max = 0, Min = 0, R = 0, G = 0, B = 0,D = 0, DR, DG, DB;
                  double H = 0, S = 0, V = 0, Y = 0, Cr = 0, Cb = 0;
                  OpenFileDialog openDialog = new OpenFileDialog();
                  if (openDialog.ShowDialog() == DialogResult.OK)
                  {
                      pictureBox1.Image = new Bitmap(openDialog.FileName);
                      Bitmap skinTest = new Bitmap(openDialog.FileName);
                      for (x = 1; x < skinTest.Width - 1; x++)
                      {
                          for (y = 1; y < skinTest.Height - 1; y++)
                          {
                              System.Drawing.Color skinTestColor = skinTest.GetPixel(x, y);
                            Max = Math.Max(skinTestColor.R, Math.Max(skinTestColor.G, skinTestColor.B));
                            Min = Math.Min(skinTestColor.R, Math.Min(skinTestColor.G, skinTestColor.B));
                            R = (skinTestColor.R / 255);
                            G = (skinTestColor.G / 255);
                            B = (skinTestColor.B / 255);
                            D = Max - Min;
                            V = Max;
                            if(D==0)
                            {
                                H = 0;
                                S = 0;
                            }
                            else
                            {
                                S = D / Max;
                                DR = (((Max - R) / 6) + (Max / 2)) / Max;
                                DG = (((Max - G) / 6) + (Max / 2)) / Max;
                                DB = (((Max - B) / 6) + (Max / 2)) / Max;
                                if (R == Max)
                                    H = DB - DG;
                                else if (G == Max)
                                    H = (1 / 3) + DR - DB;
                                else if (B == Max)
                                    H = (2 / 3) + DG - DR;
                                if (H < 0)
                                    H += 1;
                                if (H > 1)
                                    H -= 1;
                                R = skinTestColor.R;
                                B = skinTestColor.B;
                                G = skinTestColor.G;
                                Y = (0.299 * R) + (0.587 * G) + (0.114 * B);
                                Cb = (128 - (0.168736 * R) + (0.331264 * G) + (0.5 * B));
                                Cr = (128 + (0.5 * R) + (0.418688 * G) + (0.081312 * B));
                                //H = skinTestColor.GetHue();
                                //S = skinTestColor.GetSaturation();
                                //V = skinTestColor.GetBrightness();
                                if ((((skinTestColor.R > 95 && skinTestColor.G > 40 && skinTestColor.B > 20 && (Max - Min) > 15 && Math.Abs(skinTestColor.R - skinTestColor.G) > 15 && skinTestColor.R > skinTestColor.B && skinTestColor.R > skinTestColor.G) || ((skinTestColor.R > 220 && skinTestColor.G > 210 && skinTestColor.B > 170 && Math.Abs(skinTestColor.R - skinTestColor.G) <= 15 && skinTestColor.R > skinTestColor.B && skinTestColor.G > skinTestColor.B)) && ((Cr <= -2.2857 * Cb + 432.85) && (Cr <= -1.15 * Cb + 301.75) && (Cr >= -4.5652 * Cb + 234.5652) && (Cr >= 0.3448 * Cb + 76.2069) && (Cr <= 1.5862 * Cb + 20)) && (H >=0.05 && H<=0.17))
                                {
                                    skinTest.SetPixel(x, y, Color.Black);
                                }
                                else
                                {
                                    skinTest.SetPixel(x, y, Color.White);
                                }
                            }
                          }

                      }
                      pictureBox2.Image = skinTest;
                  }
             */

            /*
              int x = 0, y = 0, R = 0, G = 0, B = 0;
              double Y = 0, Cr = 0, Cb = 0;
              OpenFileDialog openDialog = new OpenFileDialog();
              if (openDialog.ShowDialog() == DialogResult.OK)
              {
                  pictureBox1.Image = new Bitmap(openDialog.FileName);
                  Bitmap skinTest = new Bitmap(openDialog.FileName);
                  for (x = 1; x < skinTest.Width - 1; x++)
                  {
                      for (y = 1; y < skinTest.Height - 1; y++)
                      {
                          System.Drawing.Color skinTestColor = skinTest.GetPixel(x, y);
                          R = skinTestColor.R;
                          B = skinTestColor.B;
                          G = skinTestColor.G;
                          Y = (0.299 * R) + (0.587 * G) + (0.114 * B);
                          Cb = (128 - (0.168736 * R) + (0.331264 * G) + (0.5 * B));
                          Cr = (128 + (0.5 * R) + (0.418688 * G) + (0.081312 * B));
                          if(Cr>150 && Cr<200 && Cb>100 && Cb<150)
                          {
                              skinTest.SetPixel(x, y, Color.Black);
                          }
                      }
                  }
                  pictureBox2.Image = skinTest;
              }
              */

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void morphologyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void morphologyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Opening filter = new Opening();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Closing filter = new Closing();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void loopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loopToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Dilatation filter = new Dilatation();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Erosion filter = new Erosion();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //create filter
                TopHat filter = new TopHat();
                // apply the filter
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Apply Grayscale");
            }

        }

        private void bottomHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //create filter
                BottomHat filter = new BottomHat();
                // apply the filter
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Apply Grayscale");
            }
        }

        private void loopToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //create filter
            Erosion filter = new Erosion();
            // apply the filter
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);

        }

        private void loopToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Dilatation filter = new Dilatation();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void blobsFilteringToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reApplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractBiggestBlob filter = new ExtractBiggestBlob();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
            dstImg = filter.Apply(dstImg);
            blobCor = filter.BlobPosition;
            //dstImg.BlobPosition;
        }

        private void homogenitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
            HomogenityEdgeDetector filter = new HomogenityEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
            DifferenceEdgeDetector filter = new DifferenceEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void cobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
            SobelEdgeDetector filter = new SobelEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayObject = new GrayscaleBT709();
            pictureBox2.Image = grayObject.Apply((Bitmap)pictureBox1.Image);
            CannyEdgeDetector filter = new CannyEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 filter = new GrayscaleBT709();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            HomogenityEdgeDetector filter = new HomogenityEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DifferenceEdgeDetector filter = new DifferenceEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SobelEdgeDetector filter = new SobelEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CannyEdgeDetector filter = new CannyEdgeDetector();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox2.Image);
            Opening filter = new Opening();
            pictureBox2.Image = filter.Apply(img);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Closing filter = new Closing();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            TopHat filter = new TopHat();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            BottomHat filter = new BottomHat();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            ExtractBiggestBlob filter = new ExtractBiggestBlob();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
            blobCor = filter.BlobPosition;
        }

        private void blobCounterBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConnectedComponentsLabeling filter = new ConnectedComponentsLabeling();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void reApplyToolStripMenuItem7_Click_1(object sender, EventArgs e)
        {

            ConnectedComponentsLabeling filter = new ConnectedComponentsLabeling();
            pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
            dstImg = filter.Apply(dstImg);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //image.Save(@"C:\Users\SAI SRUJAN\Documents\Visual Studio 2017\Projects\demo\demo\test\test.jpg");
        }

        private void reApplyToolStripMenuItem9_Click_1(object sender, EventArgs e)
        {
            try
            {
                Closing filter = new Closing();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }

        private void blobCounterBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // create an instance of blob counter algorithm
            BlobCounterBase bc = new BlobCounter();
            // set filtering options
            bc.FilterBlobs = true;
            bc.MinWidth = 5;
            bc.MinHeight = 5;
            // set ordering options
            bc.ObjectsOrder = ObjectsOrder.Size;
            // process binary image
            bc.ProcessImage((Bitmap)pictureBox1.Image);
            Blob[] blobs = bc.GetObjectsInformation();
            // extract the biggest blob
            if (blobs.Length > 0)
            {
                bc.ExtractBlobsImage((Bitmap)pictureBox1.Image, blobs[0], true);
            }
        }

        private void reApplyToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // create an instance of blob counter algorithm
            BlobCounterBase bc = new BlobCounter();
            // set filtering options
            bc.FilterBlobs = true;
            bc.MinWidth = 100;
            bc.MinHeight = 100;
            // set ordering options
            bc.ObjectsOrder = ObjectsOrder.Size;
            // process binary image
            bc.ProcessImage((Bitmap)pictureBox2.Image);
            Blob[] blobs = bc.GetObjectsInformation();
            // extract the biggest blob
            if (blobs.Length > 0)
            {
                bc.ExtractBlobsImage((Bitmap)pictureBox2.Image, blobs[0], true);
            }
            dstImg = (Bitmap)pictureBox2.Image;
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*TexturedMerge filter = new TexturedMerge(new TextileTexture());
            filter.OverlayImage = new Bitmap(pictureBox2.Image.Width, pictureBox2.Image.Height);
            PointedColorFloodFill fillFilter = new PointedColorFloodFill(Color.DarkKhaki);
            fillFilter.ApplyInPlace(filter.OverlayImage);
            filter.ApplyInPlace((Bitmap)pictureBox2.Image);
            filter.ApplyInPlace(dstImg);
            */
            //srcImg = resize(srcImg, new Size(200, 200));
            //dstImg = resize(dstImg, new Size(200, 200));
            /*Bitmap newBmp = new Bitmap(dstImg.Width, dstImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(dstImg, 0, 0);
            }
            //newBmp = dstImg;
            */
            Bitmap srcImage = new Bitmap(pictureBox1.Image);
            Bitmap dstImage = new Bitmap(pictureBox2.Image);
            for (int i = 0; i<dstImage.Width; i++)
            {
                for(int j = 0; j<dstImage.Height; j++)
                {
                    System.Drawing.Color srcColor = srcImg.GetPixel(i+blobCor.X, j+blobCor.Y);
                    System.Drawing.Color dstColor = dstImg.GetPixel(i, j);
                    if(!(dstColor.R>=0 && dstColor.R<=10 && dstColor.G >= 0 && dstColor.G <= 10 && dstColor.B >= 0 && dstColor.B <= 10))
                    {
                        dstImage.SetPixel(i, j, System.Drawing.Color.FromArgb(255, srcColor.R, srcColor.G, srcColor.B));
                    }
                }
            }
            dstImg = dstImage;
            pictureBox2.Image = dstImage;
           
            /*
            Bitmap srcImage = new Bitmap(pictureBox1.Image);
            Bitmap dstImage = new Bitmap(pictureBox2.Image);
            var srcrect = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            var dstrect = new Rectangle(0, 0, dstImage.Width, dstImage.Height);
            var srcdata = srcImage.LockBits(srcrect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var dstdata = dstImage.LockBits(dstrect, ImageLockMode.ReadWrite, dstImage.PixelFormat);
            var srcdepth = Bitmap.GetPixelFormatSize(srcdata.PixelFormat) / 8;
            var dstdepth = Bitmap.GetPixelFormatSize(dstdata.PixelFormat) / 8;
            //bytes per pixel
            var srcbuffer = new byte[srcdata.Width * srcdata.Height * srcdepth];
            var dstbuffer = new byte[dstdata.Width * dstdata.Height * dstdepth];

            //copy pixels to buffer
            Marshal.Copy(srcdata.Scan0, srcbuffer, 0, srcbuffer.Length);
            Marshal.Copy(dstdata.Scan0, dstbuffer, 0, dstbuffer.Length);

            System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    //upper-left
                    Process1(srcbuffer, dstbuffer, 0, 0, 0, 0, srcdata.Width / 2, dstdata.Width / 2, srcdata.Height / 2, dstdata.Height / 2, srcdata.Width, dstdata.Width, srcdepth, dstdepth);
                },
                () =>
                {
                    //upper-right
                    Process1(srcbuffer, dstbuffer, srcdata.Width / 2, dstdata.Width / 2, 0, 0, srcdata.Width, dstdata.Width, srcdata.Height / 2, dstdata.Height / 2, srcdata.Width, dstdata.Width, srcdepth, dstdepth);
                },
                () =>
                {
                    //lower-left
                    Process1(srcbuffer, dstbuffer, 0, 0, srcdata.Height / 2, dstdata.Height / 2, srcdata.Width / 2, dstdata.Width / 2, srcdata.Height, srcdata.Height, srcdata.Width, dstdata.Width, srcdepth, dstdepth);
                },
                () =>
                {
                    //lower-right
                    Process1(srcbuffer, dstbuffer, srcdata.Width / 2, dstdata.Width / 2, srcdata.Height / 2, dstdata.Height / 2, srcdata.Width, dstdata.Width, srcdata.Height, dstdata.Height, srcdata.Width, dstdata.Width, srcdepth, dstdepth);
                }
            );

            //Copy the buffer back to image
            Marshal.Copy(srcbuffer, 0, srcdata.Scan0, srcbuffer.Length);
            Marshal.Copy(dstbuffer, 0, dstdata.Scan0, dstbuffer.Length);

            srcImage.UnlockBits(srcdata);
            dstImage.UnlockBits(dstdata);
            pictureBox2.Image = dstImage;
            dstImg = dstImage;


            void Process1(byte[] srbuffer, byte[] dsbuffer, int srcx, int dstx, int srcy, int dsty, int srcendx, int dstendx, int srcendy, int dstendy, int srcwidth, int dstwidth, int srdepth, int dsdepth)
            {

                for (int i = srcx; i < srcendx; i++)
                {
                    for (int j = srcy; j < srcendy; j++)
                    {
                        var offset = ((j * srcwidth) + i) * srdepth;
                        var srcB = srbuffer[offset + 0];
                        var srcG = srbuffer[offset + 1];
                        var srcR = srbuffer[offset + 2];
                        var dstB = dsbuffer[offset + 0];
                        var dstG = dsbuffer[offset + 1];
                        var dstR = dsbuffer[offset + 2];
                        if (!(dstR >= 0 && dstR <= 10 && dstG >= 0 && dstG <= 10 && dstB >= 0 && dstB <= 10))
                        {
                            dsbuffer[offset + 0] = srbuffer[offset + 0];
                            dsbuffer[offset + 1] = srbuffer[offset + 1];
                            dsbuffer[offset + 2] = srbuffer[offset + 2];
                        }
                    }
                }

            }
            */
        }

        private void fillHolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // create and configure the filter
                FillHoles filter = new FillHoles();
                filter.MaxHoleHeight = 20;
                filter.MaxHoleWidth = 20;
                filter.CoupledSizeFiltering = false;
                // apply the filter
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox1.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Convert to Binary Image");
            }
        }

        private void reApplyToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                // create and configure the filter
                FillHoles filter = new FillHoles();
                filter.MaxHoleHeight = 20;
                filter.MaxHoleWidth = 20;
                filter.CoupledSizeFiltering = false;
                // apply the filter
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Convert to Binary Image");
            }
        }

        private void binarizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // create and configure the filter
                Threshold filter = new Threshold(10);
                // apply the filter
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                MessageBox.Show("Apply Grayscale");
            }
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            srcImg = resize(srcImg, new Size(200, 200));
            pictureBox1.Image = srcImg;
        }

        private void destinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dstImg = resize(dstImg, new Size(200, 200));
            pictureBox2.Image = dstImg;
        }

        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            srcImg = resize(srcImg, new Size(200, 200));
            dstImg = resize(dstImg, new Size(200, 200));
            pictureBox1.Image = srcImg;
            pictureBox2.Image = dstImg;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }

        private void resizeAndSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox2.Image);
            image = resize(image, new Size(200, 200));
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Jpg (*.jpg) | *.jpg";
            saveDialog.DefaultExt = "Jpg";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveDialog.FileName);
            }
        }

        private void hOGToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<double> edgeCount = new List<double>();
            int pixelCount = 0;
            Bitmap hoefImage = new Bitmap(pictureBox2.Image);
            GrayscaleBT709 grayFilter = new GrayscaleBT709();
            hoefImage = grayFilter.Apply((Bitmap)pictureBox2.Image);
            CannyEdgeDetector cannyFilter = new CannyEdgeDetector();
            hoefImage = cannyFilter.Apply(hoefImage);
            pictureBox2.Image = hoefImage;
            /* int rectHeight =5, rectWidth = 5;
             for (int i =0; i< rectWidth; i++)
             {
                 for (int j=0; j<rectHeight; j++)
                 {
                     int offset=
                 }
             }
             */
            var imgarray = new System.Drawing.Image[25];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    pixelCount++;
                    var index = i * 5 + j;
                    imgarray[index] = new Bitmap(40, 40);
                    var graphics = Graphics.FromImage(imgarray[index]);
                    graphics.DrawImage(hoefImage, new Rectangle(0, 0, 40, 40), new Rectangle(i * 40, j * 40, 40, 40), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
            for(int n = 0; n< 25; n++)
            {
                int counter = 0;
                Bitmap bufferImage = new Bitmap(imgarray[n]);
                for (int i = 0; i < 40; i++)
                {
                    for(int j = 0; j < 40; j++)
                    {
                        System.Drawing.Color hoefColor = bufferImage.GetPixel(i, j);
                        //if(hoefColor.R<=255 && hoefColor.R>=230 && hoefColor.G <= 255 && hoefColor.G >= 230 && hoefColor.B <= 255 && hoefColor.B >= 230)
                        if(!(hoefColor.R== 0 && hoefColor.G == 0 && hoefColor.B == 0))
                        {

                            counter++;
                        }
                    }
                }
                edgeCount.Add(counter);
            }
        }

        private void reApplyToolStripMenuItem8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Opening filter = new Opening();
                pictureBox2.Image = filter.Apply((Bitmap)pictureBox2.Image);
                dstImg = filter.Apply(dstImg);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Apply Grayscale");
            }
        }
    }
}