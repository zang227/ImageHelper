using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace ImageHelper
{
    public partial class MainForm : Form
    {
        public readonly FolderBrowserDialog _dialog = new();
        public bool _overWrite;
        public bool _scaling;
        public readonly List<string> _imageList = new();
        public readonly List<string> _directories = new();
        public string _parentDirectory;
        public int _pos;
        public int _dirPos;
        public Image _image;
        public readonly string[] _keys = { "q", "w", "s", "e", "d", "a", "1", "2", "3", "4", "5", "6", "x", "u" };
        public readonly List<Action> _actions = new();
        public FileInfo _saveFile;
        public bool _isPanning;
        public Point _panStartPoint;
        public readonly Stack<Action> _redoActions = new();


        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            LoadHotkeys();

            panel1.AutoScroll = true;
            panel1.Controls.Add(imgOriginal);
            panel1.Controls.Add(imgScaled);
            imgOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
            imgScaled.SizeMode = PictureBoxSizeMode.Zoom;

            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            sourceDir.Click += (_, _) => LoadDirectory(sourceDir);
            dir1.Click += (_, _) => LoadDirectory(dir1);
            dir2.Click += (_, _) => LoadDirectory(dir2);
            dir3.Click += (_, _) => LoadDirectory(dir3);
            dir4.Click += (_, _) => LoadDirectory(dir4);
            dir5.Click += (_, _) => LoadDirectory(dir5);
            dir6.Click += (_, _) => LoadDirectory(dir6);
            moveDirTxt.Click += (_, _) => LoadDirectory(moveDirTxt);

            panel1.KeyPress += HotKeyHandler;
            imgOriginal.MouseDown += PictureBox_MouseDown;
            imgOriginal.MouseMove += PictureBox_MouseMove;
            imgOriginal.MouseUp += PictureBox_MouseUp;

            // Additional button event handlers
            btnScale.Click += (_, _) => ToggleScaling();
            dirsLoad.Click += (_, _) => LoadDirectories();
            nextDir.Click += (_, _) => NextDirectory();
            prevDir.Click += (_, _) => PreviousDirectory();
            moveDir.Click += (_, _) => MoveCurrentDirectory();
            loadSrcDir.Click += (_, _) => LoadImages();
            nextImg.Click += (_, _) => NextImage();
            prevImg.Click += (_, _) => PreviousImage();
            move1.Click += (_, _) => MoveImage(1);
            move2.Click += (_, _) => MoveImage(2);
            move3.Click += (_, _) => MoveImage(3);
            move4.Click += (_, _) => MoveImage(4);
            move5.Click += (_, _) => MoveImage(5);
            move6.Click += (_, _) => MoveImage(6);

            saveToolStripMenuItem.Click += (_, _) => Save();
            saveAsToolStripMenuItem.Click += (_, _) => SaveAs();
            loadToolStripMenuItem.Click += (_, _) => LoadSettings();
            hotkeysToolStripMenuItem.Click += (_, _) => OpenHotkeyConfig();
            overwriteToolStripMenuItem.Click += (_, _) => _overWrite = true;
            renameToolStripMenuItem.Click += (_, _) => _overWrite = false;
            undoImageMoveToolStripMenuItem.Click += (_, _) => Undo();
            redoToolStripMenuItem.Click += (_, _) => Redo();
        }

        private void LoadHotkeys()
        {
            var savedHotkeys = Properties.Settings.Default.Hotkeys.Split(',');
            for (int i = 0; i < savedHotkeys.Length; i++)
            {
                _keys[i] = savedHotkeys[i];
            }
        }

        private void LoadDirectory(TextBox targetTextBox)
        {
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                targetTextBox.Text = _dialog.SelectedPath;
            }
        }

        private void HotKeyHandler(object sender, KeyPressEventArgs e)
        {
            int actionIndex = Array.IndexOf(_keys, e.KeyChar.ToString());
            if (actionIndex >= 0)
            {
                ExecuteAction(actionIndex);
            }
        }

        private void ExecuteAction(int actionIndex)
        {
            switch (actionIndex)
            {
                case 0: ToggleScaling(); break;
                case 1: NextDirectory(); break;
                case 2: PreviousDirectory(); break;
                case 3: MoveCurrentDirectory(); break;
                case 4: NextImage(); break;
                case 5: PreviousImage(); break;
                case 6: MoveImage(1); break;
                case 7: MoveImage(2); break;
                case 8: MoveImage(3); break;
                case 9: MoveImage(4); break;
                case 10: MoveImage(5); break;
                case 11: MoveImage(6); break;
                case 12: Save(); break;
                case 13: Undo(); break;
                default: break;
            }
        }

        private void ToggleScaling()
        {
            panel1.Focus();
            _scaling = !_scaling;
            imgOriginal.Visible = !_scaling;
            imgScaled.Visible = _scaling;
            btnScale.Text = _scaling ? "Scaling ON" : "Scaling OFF";
        }

        public void LoadImages()
        {
            _imageList.Clear();
            _pos = 0;
            if (!string.IsNullOrEmpty(sourceDir.Text))
            {
                var images = Directory.GetFiles(sourceDir.Text);
                if (images.Any())
                {
                    _imageList.AddRange(images.Reverse());
                    DisplayCurrentImage();
                }
            }
        }

        public void DisplayCurrentImage()
        {
            if (_pos < 0 || _pos >= _imageList.Count) return;

            _image = Image.FromFile(_imageList[_pos]);
            imgOriginal.Image = imgScaled.Image = _image;

            string currentImageName = Path.GetFileName(_imageList[_pos]);
            string nextImageName = (_pos + 1 < _imageList.Count) ? Path.GetFileName(_imageList[_pos + 1]) : "Current image is the last.";

            label1.Text = $"Image Dimensions: {_image.Width}x{_image.Height}";
            label2.Text = $"Image Name: {currentImageName}";
            label3.Text = $"Next Image: {nextImageName}";
            label4.Text = $"Images Remaining: {_imageList.Count}";
            label5.Text = $"Position: {_pos + 1}";
        }

        private void MoveImage(int destIndex)
        {
            var destination = GetDestinationDirectory(destIndex);
            if (string.IsNullOrEmpty(destination)) return;

            var currentImage = _imageList[_pos];
            var fileName = Path.GetFileName(currentImage);
            var newImagePath = Path.Combine(destination, fileName);

            DisposeCurrentImage();

            if (_overWrite || !File.Exists(newImagePath))
            {
                File.Move(currentImage, newImagePath);
            }
            else
            {
                newImagePath = GetUniqueFilePath(newImagePath);
                File.Move(currentImage, newImagePath);
            }

            var action = new Action(currentImage, newImagePath, ActionType.Image, this);
            _actions.Add(action);
            _redoActions.Clear();

            _imageList.RemoveAt(_pos);
            if (_pos >= _imageList.Count) _pos--;

            if (_pos >= 0) DisplayCurrentImage();
        }

        private string GetUniqueFilePath(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var extension = Path.GetExtension(filePath);

            int count = 1;
            string newFilePath;
            do
            {
                newFilePath = Path.Combine(directory, $"{fileName} ({count++}){extension}");
            } while (File.Exists(newFilePath));

            return newFilePath;
        }

        public void DisposeCurrentImage()
        {
            if (imgScaled.Image != null)
            {
                imgScaled.Image.Dispose();
                imgScaled.Image = null;
            }
            if (imgOriginal.Image != null)
            {
                imgOriginal.Image.Dispose();
                imgOriginal.Image = null;
            }
            if (_image != null)
            {
                _image.Dispose();
                _image = null;
            }
        }

        private string GetDestinationDirectory(int index)
        {
            return index switch
            {
                1 => dir1.Text,
                2 => dir2.Text,
                3 => dir3.Text,
                4 => dir4.Text,
                5 => dir5.Text,
                6 => dir6.Text,
                _ => string.Empty
            };
        }

        public void LoadDirectories()
        {
            if (!string.IsNullOrEmpty(_parentDirectory))
            {
                _directories.Clear();
                _directories.AddRange(Directory.GetDirectories(_parentDirectory));
                _dirPos = 0;
                if (_directories.Any())
                {
                    sourceDir.Text = _directories[_dirPos];
                    LoadImages();
                }
            }
        }

        private void NextDirectory()
        {
            panel1.Focus();
            if (_dirPos < _directories.Count - 1)
            {
                DisposeCurrentImage();
                _dirPos++;
                sourceDir.Text = _directories[_dirPos];
                LoadImages();
            }
        }

        private void PreviousDirectory()
        {
            panel1.Focus();
            if (_dirPos > 0)
            {
                DisposeCurrentImage();
                _dirPos--;
                sourceDir.Text = _directories[_dirPos];
                LoadImages();
            }
        }

        private void MoveCurrentDirectory()
        {
            panel1.Focus();
            var action = new Action(sourceDir.Text, moveDirTxt.Text, ActionType.Directory, this);
            if (!string.IsNullOrEmpty(action.Destination))
            {
                try
                {
                    var dirName = Path.GetFileName(sourceDir.Text);
                    FileSystem.MoveDirectory(action.Source, Path.Combine(action.Destination, dirName), true);
                    _directories.RemoveAt(_dirPos);
                    if (_directories.Any())
                    {
                        sourceDir.Text = _directories[_dirPos];
                        LoadImages();
                    }
                    else
                    {
                        ClearImages();
                    }
                    _actions.Add(action);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void ClearImages()
        {
            imgScaled.Image = null;
            imgOriginal.Image = null;
            _imageList.Clear();
        }

        private void NextImage()
        {
            panel1.Focus();
            if (_pos < _imageList.Count - 1)
            {
                DisposeCurrentImage();
                _pos++;
                DisplayCurrentImage();
            }
            else
            {
                MessageBox.Show("You've reached the end of the images in this directory.", "Image Helper Notice");
            }
        }

        private void PreviousImage()
        {
            panel1.Focus();
            if (_pos > 0)
            {
                DisposeCurrentImage();
                _pos--;
                DisplayCurrentImage();
            }
        }

        private void Save()
        {
            if (_saveFile != null)
            {
                SaveToFile(_saveFile.FullName);
            }
            else
            {
                SaveAs();
            }
        }

        private void SaveAs()
        {
            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "ImageHelper Saves | *.ihs",
                DefaultExt = "ihs"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(saveFileDialog.FileName);
                _saveFile = new FileInfo(saveFileDialog.FileName);
            }
        }

        private void SaveToFile(string filePath)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(_directories.Any() ? "M" : "S");

            TextBox[] moveDirs = { dir1, dir2, dir3, dir4, dir5, dir6 };
            foreach (var dir in moveDirs)
            {
                sw.WriteLine(string.IsNullOrEmpty(dir.Text) ? "null" : dir.Text);
            }

            sw.WriteLine(_pos);
            sw.WriteLine(string.IsNullOrEmpty(sourceDir.Text) ? "null" : sourceDir.Text);

            if (_directories.Any())
            {
                sw.WriteLine(_parentDirectory);
                sw.WriteLine(_dirPos);
                sw.WriteLine(string.IsNullOrEmpty(moveDirTxt.Text) ? "null" : moveDirTxt.Text);
            }
        }

        private void LoadSettings()
        {
            using OpenFileDialog open = new()
            {
                Filter = "ImageHelper Saves | *.ihs"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                var lines = File.ReadAllLines(open.FileName);
                LoadFromSettings(lines);
                _saveFile = new FileInfo(open.FileName);
            }
        }

        private void LoadFromSettings(string[] lines)
        {
            TextBox[] moveDirs = { dir1, dir2, dir3, dir4, dir5, dir6 };

            for (int i = 0; i < moveDirs.Length; i++)
            {
                moveDirs[i].Text = lines[i + 1] != "null" ? lines[i + 1] : string.Empty;
            }

            _pos = int.Parse(lines[7]);
            sourceDir.Text = lines[8] != "null" ? lines[8] : string.Empty;

            if (lines[0] == "M")
            {
                _parentDirectory = lines[9];
                moveDirTxt.Text = lines[11] != "null" ? lines[11] : string.Empty;
                LoadDirectories();
                _dirPos = int.Parse(lines[10]);
                sourceDir.Text = _directories[_dirPos];
                LoadImages();
            }
            else if (lines[0] == "S" && !string.IsNullOrEmpty(sourceDir.Text))
            {
                LoadImages();
            }

            DisplayCurrentImage();
        }

        private void OpenHotkeyConfig()
        {
            using HotKeyConfig popup = new();
            for (int i = 0; i < popup._buttons.Count; i++)
            {
                popup._buttons[i].Text = _keys[i].ToUpper();
                popup.Hotkeys[i] = _keys[i];
            }

            var dialogResult = popup.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                for (int i = 0; i < _keys.Length; i++)
                {
                    _keys[i] = popup.Hotkeys[i];
                }
                SaveHotkeys();
            }
        }

        private void SaveHotkeys()
        {
            Properties.Settings.Default.Hotkeys = string.Join(",", _keys);
            Properties.Settings.Default.Save();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPanning = true;
                _panStartPoint = new Point(e.X, e.Y);
                Cursor = Cursors.Hand;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPanning)
            {
                Point newPos = imgOriginal.PointToScreen(new Point(e.X, e.Y));
                newPos.Offset(-_panStartPoint.X, -_panStartPoint.Y);
                imgOriginal.Location = imgOriginal.Parent.PointToClient(newPos);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPanning = false;
                Cursor = Cursors.Default;
            }
        }

        private void Undo()
        {
            if (_actions.Any())
            {
                var lastAction = _actions.Last();
                lastAction.Undo();
                _actions.RemoveAt(_actions.Count - 1);
                _redoActions.Push(lastAction);
            }
        }

        private void Redo()
        {
            if (_redoActions.Any())
            {
                var lastUndoneAction = _redoActions.Pop();
                lastUndoneAction.Redo();
                _actions.Add(lastUndoneAction);
            }
        }
    }

    public enum ActionType { Image, Directory }

    public class Action
    {
        private readonly MainForm _form;
        public string Source { get; }
        public string Destination { get; }
        public ActionType Type { get; }

        public Action(string src, string dest, ActionType actionType, MainForm form)
        {
            Source = src;
            Destination = dest;
            Type = actionType;
            _form = form;
        }

        public void Undo()
        {
            if (Type == ActionType.Image)
            {
                _form.DisposeCurrentImage();
                ForceGarbageCollection();
                var fileName = Path.GetFileName(Source);
                File.Move(Destination, Source);
                _form.DisposeCurrentImage();
                _form.LoadImages();
                _form.DisplayCurrentImage();
            }
            else if (Type == ActionType.Directory)
            {
                _form.DisposeCurrentImage();
                var dirName = Path.GetFileName(Source);
                Directory.Move(Path.Combine(Destination, dirName), Source);
                _form.LoadDirectories();
                _form._dirPos = _form._directories.IndexOf(Source);
                _form.LoadImages();
            }
        }

        public void Redo()
        {
            if (Type == ActionType.Image)
            {
                _form.DisposeCurrentImage();
                ForceGarbageCollection();
                var fileName = Path.GetFileName(Source);
                File.Move(Source, Destination);
                _form.DisposeCurrentImage();
                _form.LoadImages();
                _form.DisplayCurrentImage();
            }
            else if (Type == ActionType.Directory)
            {
                _form.DisposeCurrentImage();
                var dirName = Path.GetFileName(Source);
                Directory.Move(Source, Path.Combine(Destination, dirName));
                _form.LoadDirectories();
                _form._dirPos = _form._directories.IndexOf(Source);
                _form.LoadImages();
            }
        }
        //we need this because even though we dispose the image for some reason it keeps a file lock on it
        private void ForceGarbageCollection()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }


    }
}
