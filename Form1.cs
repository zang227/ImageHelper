using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHelper
{
    public partial class Form1 : Form
    {
        public FolderBrowserDialog dialog = new FolderBrowserDialog();
        public Boolean Scaling = false;
        public ArrayList imageList = new ArrayList();
        public ArrayList directories = new ArrayList();
        public int pos = 0;
        public int dirPos = 0;
        public Image image;
        public string[] images;
        public Form1()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            panel1.Controls.Add(imgOriginal);
            panel1.Controls.Add(imgScaled);
            imgOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
            imgScaled.SizeMode = PictureBoxSizeMode.Zoom;
            imgOriginal.Visible = true;
            imgScaled.Visible = false;
            sourceDir.Click += SourceLoad;
            dir1.Click += dir1Click;
            dir2.Click += dir1Click;
            dir3.Click += dir1Click;
            dir4.Click += dir1Click;
            dir5.Click += dir1Click;
            dir6.Click += dir1Click;
            moveDirTxt.Click += moveDirClick;

        }

        public void imgLoad()
        {
            image = Image.FromFile((string)imageList[pos]);
            string s = (string)imageList[pos];
            string[] imgName = s.Split("\\");
            s = imgName[^1];
            string[] nextName;

            string s2;
            if (pos + 1 < imageList.Count)
            {
                s2 = (string)imageList[pos + 1];
                nextName = s2.Split("\\");
                s2 = nextName[^1];
            }
            else
            {
                s2 = "Current image is the last.";
            }

            imgOriginal.Image = image;
            imgScaled.Image = image;
            label1.Text = "Image Dimensions: " + image.Width + "x" +image.Height;
            label2.Text = "Image Name: " + s;
            label3.Text = "Next Image: " + s2;
            label4.Text = "Images Remaining: " + imageList.Count;
            label5.Text = "Position: " + (pos + 1);
        }

        public void srcLoad()
        {
            imageList.Clear();
            pos = 0;
            string source = sourceDir.Text;
            if (source != "")
            {
                images = Directory.GetFiles(source);
                if (images.Length > 0)
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        imageList.Add(images[i]);
                    }
                    imgLoad();
                }
            }
        }

        public void imgMove(int dest)
        {
            var destination = "";
            if (dest == 1)
            {
                destination = dir1.Text;
            }
            if (dest == 2)
            {
                destination = dir2.Text;
            }
            if (dest == 3)
            {
                destination = dir3.Text;
            }
            if (dest == 4)
            {
                destination = dir4.Text;
            }
            if (dest == 5)
            {
                destination = dir5.Text;
            }
            if (dest == 6)
            {
                destination = dir6.Text;
            }

            if (imageList.Count > 0)
            {

                var x = pos;
                var source = (string)imageList[pos];
                string s = (string)imageList[pos];
                string[] imgName = s.Split("\\");
                s = imgName[^1];
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                if (imageList.Count == 1)
                {
                    File.Move(source, destination + "\\" + s);
                    imageList.RemoveAt(x);
                    imgOriginal.Image = null;
                    imgScaled.Image = null;
                }
                else if (x + 1 == imageList.Count)
                {
                    pos--;
                    imgLoad();
                    File.Move(source, destination + "\\" + s);
                    imageList.RemoveAt(x);

                }
                else
                {
                    pos++;
                    imgLoad();
                    File.Move(source, destination + "\\" + s);
                    imageList.RemoveAt(x);
                    imgScaled.Image.Dispose();
                    imgOriginal.Image.Dispose();
                    image.Dispose();
                    pos--;
                    imgLoad();
                }
            }
        }

        private void SourceLoad(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            sourceDir.Text = dialog.SelectedPath;
        }

        private void dir1Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir1.Text = dialog.SelectedPath;
        }

        private void dir2Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir2.Text = dialog.SelectedPath;
        }

        private void dir3Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir3.Text = dialog.SelectedPath;
        }

        private void dir4Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir4.Text = dialog.SelectedPath;
        }

        private void dir5Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir5.Text = dialog.SelectedPath;
        }

        private void dir6Click(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            dir6.Text = dialog.SelectedPath;
        }

        private void moveDirClick(object sender, System.EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            moveDirTxt.Text = dialog.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Scaling == true)
            {
                imgOriginal.Visible = true;
                imgScaled.Visible = false;
                btnScale.Text = "Scaling OFF";
                Scaling = false;
            }
            else
            {
                imgOriginal.Visible = false;
                imgScaled.Visible = true;
                btnScale.Text = "Scaling ON";
                Scaling = true;
            }
        }

        private void loadSrcDir_Click(object sender, EventArgs e)
        {
            srcLoad();
        }

        private void dirsLoad_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            string parent = dialog.SelectedPath;
            if (parent != "") 
            { 
                var children = Directory.GetDirectories(parent);
                for (int i = 0; i < children.Length; i++)
                {
                    directories.Add(children[i]);
                }
                dirPos = 0;
                string s = ""; 
                s += directories.Count;
                label1.Text = s;
                sourceDir.Text = (string)directories[dirPos];
                srcLoad();
            }


        }

        private void nextDir_Click(object sender, EventArgs e)
        {
            if(dirPos < directories.Count - 1)
            {
                dirPos++;
                sourceDir.Text = (string)directories[dirPos];
                srcLoad();
            }
        }

        private void prevDir_Click(object sender, EventArgs e)
        {
            if (dirPos > 0)
            {
                dirPos--;
                sourceDir.Text = (string)directories[dirPos];
                srcLoad();
            }
        }

        private void moveDir_Click(object sender, EventArgs e)
        {
            string[] s = sourceDir.Text.Split("\\");
            string s2 = s[^1];
            try
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                Directory.Move(sourceDir.Text, moveDirTxt.Text +"\\"+s2);
                if (directories.Count > 0)
                {
                    directories.RemoveAt(dirPos);
                    Debug.WriteLine((string)directories[dirPos]);
                    sourceDir.Text = (string)directories[dirPos];
                    srcLoad();
                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.Message);
            }
            
            

        }

        private void prevImg_Click(object sender, EventArgs e)
        {
            if(pos > 0)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                pos--;
                imgLoad();
            }
        }

        private void nextImg_Click(object sender, EventArgs e)
        {
            if(pos < imageList.Count - 1)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                pos++;
                imgLoad();
            }
        }

        private void move1_Click(object sender, EventArgs e)
        {
            imgMove(1);
        }

        private void move2_Click(object sender, EventArgs e)
        {
            imgMove(2);
        }

        private void move3_Click(object sender, EventArgs e)
        {
            imgMove(3);
        }

        private void move4_Click(object sender, EventArgs e)
        {
            imgMove(4);
        }

        private void move5_Click(object sender, EventArgs e)
        {
            imgMove(5);
        }

        private void move6_Click(object sender, EventArgs e)
        {
            imgMove(6);
        }

    }
}
