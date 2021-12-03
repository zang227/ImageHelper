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
    public partial class MainForm : Form
    {
        public FolderBrowserDialog dialog = new FolderBrowserDialog();
        public Boolean Scaling = false;
        public ArrayList imageList = new ArrayList();
        public ArrayList directories = new ArrayList();
        public string parentDirectory;
        public int pos = 0;
        public int dirPos = 0;
        public Image image;
        public string[] images;
        public string[] keys = { "q", "w", "s", "e", "d", "a", "1", "2", "3", "4", "5", "6","x","u"};
        public ArrayList actions = new ArrayList();
        public FileInfo saveFile = null;
        public int movedPos = -1;
        //public string source, destination;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //Load Hotkey Settings
            var s = Properties.Settings.Default.Hotkeys;
            string[] split = s.Split(',');
            for(int i = 0; i < split.Length; i++)
            {
                keys[i] = split[i];
            }
            //Initialize Controls
            panel1.AutoScroll = true;
            panel1.Controls.Add(imgOriginal);
            panel1.Controls.Add(imgScaled);
            imgOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
            imgScaled.SizeMode = PictureBoxSizeMode.Zoom;
            imgOriginal.Visible = true;
            imgScaled.Visible = false;
            sourceDir.Click += SourceLoad;
            dir1.Click += dir1Click;
            dir2.Click += dir2Click;
            dir3.Click += dir3Click;
            dir4.Click += dir4Click;
            dir5.Click += dir5Click;
            dir6.Click += dir6Click;
            panel1.KeyPress += HotKey;
            moveDirTxt.Click += moveDirClick;

        }

        private void HotKey(object sender, System.Windows.Forms.KeyPressEventArgs e)
        { 
            switch (HKSwitch(e))
            {
                case 0:
                    ScaleToggle();
                    break;
                case 1:
                    NextDirectory();
                    break;
                case 2:
                    PreviousDirectory();
                    break;
                case 3:
                    MoveDirectory();
                    break;
                case 4:
                    NextImage();
                    break;
                case 5:
                    PreviousImage();
                    break;
                case 6:
                    imgMove(1);
                    break;
                case 7:
                    imgMove(2);
                    break;
                case 8:
                    imgMove(3);
                    break;
                case 9:
                    imgMove(4);
                    break;
                case 10:
                    imgMove(5);
                    break;
                case 11:
                    imgMove(6);
                    break;
                case 12:
                    Save();
                    break;
                case 13:
                    Undo();
                    break;
                case -1: //Key pressed does not correspond to a hotkey.
                    break;
            }
        }


        public int HKSwitch(KeyPressEventArgs e)
        {
            string s = e.KeyChar.ToString();
            for(int i = 0; i < keys.Length; i++)
            {
                if(s == keys[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void SaveHotkeys()
        {
            string s = "";
            for(int i = 0; i < keys.Length; i++)
            {
                if (i < keys.Length - 1)
                    s += keys[i] + ",";
                else
                    s += keys[i];
            }
            Properties.Settings.Default.Hotkeys = s;
            Properties.Settings.Default.Save();
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
                    imageList.Reverse();
                    imgLoad();
                }
            }
        }

        public void imgMove(int dest)
        {
            Action move = new Action("","",Type.Image,this);
            panel1.Focus();
            if (dest == 1)
            {
                move.destination = dir1.Text;
            }
            if (dest == 2)
            {
                move.destination = dir2.Text;
            }
            if (dest == 3)
            {
                move.destination = dir3.Text;
            }
            if (dest == 4)
            {
                move.destination = dir4.Text;
            }
            if (dest == 5)
            {
                move.destination = dir5.Text;
            }
            if (dest == 6)
            {
                move.destination = dir6.Text;
            }
            if (!String.IsNullOrEmpty(move.destination))
            {
                if (imageList.Count > 0)
                {

                    movedPos = pos;
                    move.source = (string)imageList[pos];
                    string s = (string)imageList[pos];
                    string[] imgName = s.Split("\\");
                    s = imgName[^1];
                    imgScaled.Image.Dispose();
                    imgOriginal.Image.Dispose();
                    image.Dispose();
                    if (imageList.Count == 1)
                    {
                        File.Move(move.source, move.destination + "\\" + s);
                        imageList.RemoveAt(movedPos);
                        imgOriginal.Image = null;
                        imgScaled.Image = null;
                    }
                    else if (movedPos + 1 == imageList.Count)
                    {
                        pos--;
                        imgLoad();
                        File.Move(move.source, move.destination + "\\" + s);
                        imageList.RemoveAt(movedPos);

                    }
                    else
                    {
                        pos++;
                        imgLoad();
                        File.Move(move.source, move.destination + "\\" + s);
                        imageList.RemoveAt(movedPos);
                        imgScaled.Image.Dispose();
                        imgOriginal.Image.Dispose();
                        image.Dispose();
                        pos--;
                        imgLoad();
                    }

                    actions.Add(move);
                }
            }
        }

        public void DirectoriesLoad()
        {
            var children = Directory.GetDirectories(parentDirectory);
            directories.Clear();
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

        public void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ImageHelper Saves | *.ihs";
            saveFileDialog.DefaultExt = "ihs";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream fileStream = saveFileDialog.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                if (directories.Count == 0)
                    sw.WriteLine("S");
                else
                    sw.WriteLine("M");
                TextBox[] moveDirs = { dir1, dir2, dir3, dir4, dir5, dir6 };
                for (int i = 0; i < moveDirs.Length; i++)
                {
                    if (moveDirs[i].Text == "")
                        sw.WriteLine("null");
                    else
                        sw.WriteLine(moveDirs[i].Text);
                }
                sw.WriteLine(pos);
                if (sourceDir.Text == "")
                    sw.WriteLine("null");
                else
                    sw.WriteLine(sourceDir.Text);
                if (directories.Count > 0)
                {
                    sw.WriteLine(parentDirectory);
                    sw.WriteLine(dirPos);
                    if (moveDirTxt.Text == "")
                        sw.WriteLine("null");
                    else
                        sw.WriteLine(moveDirTxt.Text);
                }
                sw.Flush();
                sw.Close();
                saveFile = new FileInfo(saveFileDialog.FileName);
            }
        }

        public void Save()
        {
            if (saveFile != null)
            {
                System.IO.File.WriteAllText(saveFile.FullName, string.Empty);
                System.IO.StreamWriter sw = saveFile.AppendText();
                if (directories.Count == 0)
                    sw.WriteLine("S");
                else
                    sw.WriteLine("M");
                TextBox[] moveDirs = { dir1, dir2, dir3, dir4, dir5, dir6 };
                for (int i = 0; i < moveDirs.Length; i++)
                {
                    if (moveDirs[i].Text == "")
                        sw.WriteLine("null");
                    else
                        sw.WriteLine(moveDirs[i].Text);
                }
                sw.WriteLine(pos);
                if (sourceDir.Text == "")
                    sw.WriteLine("null");
                else
                    sw.WriteLine(sourceDir.Text);
                if (directories.Count > 0)
                {
                    sw.WriteLine(parentDirectory);
                    sw.WriteLine(dirPos);
                    if (moveDirTxt.Text == "")
                        sw.WriteLine("null");
                    else
                        sw.WriteLine(moveDirTxt.Text);
                }
                sw.Flush();
                sw.Close();
            }
            else
                SaveAs();
            
        }

        public void Undo()
        {
            Action action = (Action)actions[(actions.Count - 1)];
            action.Undo();

            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            *  0   S/M
            *  1   1
            *  2   2
            *  3   3
            *  4   4
            *  5   5
            *  6   6
            *  7   pos
            *  8   SrcDirectory
            *  9   Parent
            *  10  dirPos
            *  11  Move Directory         
            */
            TextBox[] moveDirs = { dir1, dir2, dir3, dir4, dir5, dir6 };
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "ImageHelper Saves | *.ihs";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(open.FileName);
                if (lines[0] == "S")
                {
                    for (int i = 0; i < moveDirs.Length; i++)
                    {
                        if (lines[i + 1] != "null")
                            moveDirs[i].Text = lines[i + 1];
                    }
                    if (lines[8] != "null")
                    {
                        sourceDir.Text = lines[8];
                        srcLoad();
                        pos = Int32.Parse(lines[7]);
                        imgScaled.Image.Dispose();
                        imgOriginal.Image.Dispose();
                        image.Dispose();
                        imgLoad();
                    }
                }
                else //Multi Case
                {
                    for (int i = 0; i < moveDirs.Length; i++)
                    {
                        if (lines[i + 1] != "null")
                            moveDirs[i].Text = lines[i + 1];
                    }
                    if (lines[8] != "null")
                        sourceDir.Text = lines[8];
                    parentDirectory = lines[9];
                    if (lines[11] != "null")
                        moveDirTxt.Text = lines[11];
                    DirectoriesLoad();
                    dirPos = Int32.Parse(lines[10]);
                    sourceDir.Text = (string)directories[dirPos];
                    imgScaled.Image.Dispose();
                    imgOriginal.Image.Dispose();
                    image.Dispose();
                    srcLoad();
                    pos = Int32.Parse(lines[7]);
                    imgScaled.Image.Dispose();
                    imgOriginal.Image.Dispose();
                    image.Dispose();
                    imgLoad();
                }
                saveFile = new FileInfo(open.FileName);
            }
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyConfig popup = new HotKeyConfig();
            for (int i = 0; i < popup.buttons.Length; i++)
            {
                popup.buttons[i].Text = keys[i].ToUpper();
                popup.Hotkeys[i] = keys[i];
            }


            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    keys[i] = popup.Hotkeys[i];
                }
                SaveHotkeys();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
        }
        public void ScaleToggle()
        {
            panel1.Focus();
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

        public void NextDirectory()
        {
            panel1.Focus();
            if (dirPos < directories.Count - 1)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                dirPos++;
                sourceDir.Text = (string)directories[dirPos];
                srcLoad();
            }
        }

        public void PreviousDirectory()
        {
            panel1.Focus();
            if (dirPos > 0)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                dirPos--;
                sourceDir.Text = (string)directories[dirPos];
                srcLoad();
            }
        }

        public void MoveDirectory()
        {
            panel1.Focus();
            Action action = new Action(sourceDir.Text, moveDirTxt.Text, Type.Directory, this);
            if (!String.IsNullOrEmpty(action.destination))
            {
                string[] s = sourceDir.Text.Split("\\");
                string s2 = s[^1];
                try
                {
                    imgScaled.Image.Dispose();
                    imgOriginal.Image.Dispose();
                    image.Dispose();
                    Directory.Move(action.source, action.destination + "\\" + s2);
                    actions.Add(action);
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
        }

        public void PreviousImage()
        {
            panel1.Focus();
            if (pos > 0)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                pos--;
                imgLoad();
            }
        }

        public void NextImage()
        {
            panel1.Focus();
            if (pos < imageList.Count - 1)
            {
                imgScaled.Image.Dispose();
                imgOriginal.Image.Dispose();
                image.Dispose();
                pos++;
                imgLoad();
            }
            else
            {
                MessageBox.Show("You've reached the end of the images in this directory.", "Image Helper Notice");
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
            ScaleToggle();
        }

        private void loadSrcDir_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            srcLoad();
        }

        private void dirsLoad_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            dialog.ShowDialog();
            parentDirectory = dialog.SelectedPath;
            if (parentDirectory != "") 
            {
                DirectoriesLoad();
            }
        }

        private void nextDir_Click(object sender, EventArgs e)
        {
            NextDirectory();
        }

        private void prevDir_Click(object sender, EventArgs e)
        {
            PreviousDirectory();
        }

        private void moveDir_Click(object sender, EventArgs e)
        {
            MoveDirectory();
        }

        private void prevImg_Click(object sender, EventArgs e)
        {
            PreviousImage();
        }

        private void nextImg_Click(object sender, EventArgs e)
        {
            NextImage();
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

        private void undoImageMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void move6_Click(object sender, EventArgs e)
        {
            imgMove(6);
        }
    }
    public enum Type { Image, Directory };

    public class Action
    {
        MainForm form;
        public string source, destination;
        public Type type;
        

        public Action(string src, string dest, Type ActionType, MainForm main)
        {
            source = src;
            destination = dest;
            type = ActionType;
            form = main;
            
        }

        public void Undo()
        {
            if(type == Type.Image)
            {
                if (form.movedPos > -1)
                {
                    string s = source;
                    string[] imgName = s.Split("\\");
                    s = imgName[^1];
                    form.imgScaled.Image.Dispose();
                    form.imgOriginal.Image.Dispose();
                    form.image.Dispose();
                    File.Move(destination + "\\" + s, source);
                    form.srcLoad();
                    form.imgScaled.Image.Dispose();
                    form.imgOriginal.Image.Dispose();
                    form.image.Dispose();
                    form.pos = form.movedPos;
                    form.imgLoad();
                    form.actions.RemoveAt(form.actions.Count - 1);
                }
                
            }
            else
            {
                form.panel1.Focus();
                if (!String.IsNullOrEmpty(destination))
                {
                    string[] s = source.Split("\\");
                    string s2 = s[^1];
                    try
                    {
                        form.imgScaled.Image.Dispose();
                        form.imgOriginal.Image.Dispose();
                        form.image.Dispose();
                        Directory.Move(destination + "\\" + s2, source);
                        var pos = form.dirPos;
                        form.DirectoriesLoad();
                        form.imgScaled.Image.Dispose();
                        form.imgOriginal.Image.Dispose();
                        form.image.Dispose();
                        form.dirPos = pos;
                        form.srcLoad();
                        form.actions.RemoveAt(form.actions.Count - 1);
                    }
                    catch (Exception x)
                    {
                        Debug.WriteLine(x.Message);
                    }
                }
            }
           
        }
    }
}
