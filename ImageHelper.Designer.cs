﻿
namespace ImageHelper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnScale = new System.Windows.Forms.Button();
            this.dirsLoad = new System.Windows.Forms.Button();
            this.nextDir = new System.Windows.Forms.Button();
            this.prevDir = new System.Windows.Forms.Button();
            this.nextImg = new System.Windows.Forms.Button();
            this.prevImg = new System.Windows.Forms.Button();
            this.moveDir = new System.Windows.Forms.Button();
            this.loadSrcDir = new System.Windows.Forms.Button();
            this.move1 = new System.Windows.Forms.Button();
            this.move2 = new System.Windows.Forms.Button();
            this.move3 = new System.Windows.Forms.Button();
            this.move4 = new System.Windows.Forms.Button();
            this.move5 = new System.Windows.Forms.Button();
            this.move6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dir2 = new System.Windows.Forms.TextBox();
            this.dir3 = new System.Windows.Forms.TextBox();
            this.dir4 = new System.Windows.Forms.TextBox();
            this.dir5 = new System.Windows.Forms.TextBox();
            this.dir6 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgScaled = new System.Windows.Forms.PictureBox();
            this.imgOriginal = new System.Windows.Forms.PictureBox();
            this.dir1 = new System.Windows.Forms.TextBox();
            this.sourceDir = new System.Windows.Forms.TextBox();
            this.moveDirTxt = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoImageMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgScaled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOriginal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(12, 58);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(116, 33);
            this.btnScale.TabIndex = 3;
            this.btnScale.Text = "Scaling OFF";
            this.btnScale.UseVisualStyleBackColor = true;
            // 
            // dirsLoad
            // 
            this.dirsLoad.Location = new System.Drawing.Point(134, 58);
            this.dirsLoad.Name = "dirsLoad";
            this.dirsLoad.Size = new System.Drawing.Size(116, 33);
            this.dirsLoad.TabIndex = 4;
            this.dirsLoad.Text = "Load Directories";
            this.dirsLoad.UseVisualStyleBackColor = true;
            // 
            // nextDir
            // 
            this.nextDir.Location = new System.Drawing.Point(378, 58);
            this.nextDir.Name = "nextDir";
            this.nextDir.Size = new System.Drawing.Size(116, 33);
            this.nextDir.TabIndex = 5;
            this.nextDir.Text = "Next Directory";
            this.nextDir.UseVisualStyleBackColor = true;
            // 
            // prevDir
            // 
            this.prevDir.Location = new System.Drawing.Point(256, 58);
            this.prevDir.Name = "prevDir";
            this.prevDir.Size = new System.Drawing.Size(116, 33);
            this.prevDir.TabIndex = 6;
            this.prevDir.Text = "Previous Directory";
            this.prevDir.UseVisualStyleBackColor = true;
            // 
            // nextImg
            // 
            this.nextImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextImg.Location = new System.Drawing.Point(1383, 47);
            this.nextImg.MaximumSize = new System.Drawing.Size(140, 40);
            this.nextImg.MinimumSize = new System.Drawing.Size(140, 40);
            this.nextImg.Name = "nextImg";
            this.nextImg.Size = new System.Drawing.Size(140, 40);
            this.nextImg.TabIndex = 8;
            this.nextImg.Text = "Next";
            this.nextImg.UseVisualStyleBackColor = true;
            // 
            // prevImg
            // 
            this.prevImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prevImg.Location = new System.Drawing.Point(1237, 47);
            this.prevImg.MaximumSize = new System.Drawing.Size(140, 40);
            this.prevImg.MinimumSize = new System.Drawing.Size(140, 40);
            this.prevImg.Name = "prevImg";
            this.prevImg.Size = new System.Drawing.Size(140, 40);
            this.prevImg.TabIndex = 9;
            this.prevImg.Text = "Back";
            this.prevImg.UseVisualStyleBackColor = true;
            // 
            // moveDir
            // 
            this.moveDir.Location = new System.Drawing.Point(500, 58);
            this.moveDir.Name = "moveDir";
            this.moveDir.Size = new System.Drawing.Size(116, 33);
            this.moveDir.TabIndex = 10;
            this.moveDir.Text = "Move Directory";
            this.moveDir.UseVisualStyleBackColor = true;
            // 
            // loadSrcDir
            // 
            this.loadSrcDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadSrcDir.Location = new System.Drawing.Point(1539, 46);
            this.loadSrcDir.Name = "loadSrcDir";
            this.loadSrcDir.Size = new System.Drawing.Size(131, 41);
            this.loadSrcDir.TabIndex = 12;
            this.loadSrcDir.Text = "Load Directory";
            this.loadSrcDir.UseVisualStyleBackColor = true;
            // 
            // move1
            // 
            this.move1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move1.Location = new System.Drawing.Point(1539, 125);
            this.move1.Name = "move1";
            this.move1.Size = new System.Drawing.Size(131, 41);
            this.move1.TabIndex = 13;
            this.move1.Text = "Move Image";
            this.move1.UseVisualStyleBackColor = true;
            // 
            // move2
            // 
            this.move2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move2.Location = new System.Drawing.Point(1539, 172);
            this.move2.Name = "move2";
            this.move2.Size = new System.Drawing.Size(131, 41);
            this.move2.TabIndex = 14;
            this.move2.Text = "Move Image";
            this.move2.UseVisualStyleBackColor = true;
            // 
            // move3
            // 
            this.move3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move3.Location = new System.Drawing.Point(1539, 219);
            this.move3.Name = "move3";
            this.move3.Size = new System.Drawing.Size(131, 41);
            this.move3.TabIndex = 15;
            this.move3.Text = "Move Image";
            this.move3.UseVisualStyleBackColor = true;
            // 
            // move4
            // 
            this.move4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move4.Location = new System.Drawing.Point(1539, 266);
            this.move4.Name = "move4";
            this.move4.Size = new System.Drawing.Size(131, 41);
            this.move4.TabIndex = 16;
            this.move4.Text = "Move Image";
            this.move4.UseVisualStyleBackColor = true;
            // 
            // move5
            // 
            this.move5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move5.Location = new System.Drawing.Point(1539, 313);
            this.move5.Name = "move5";
            this.move5.Size = new System.Drawing.Size(131, 41);
            this.move5.TabIndex = 17;
            this.move5.Text = "Move Image";
            this.move5.UseVisualStyleBackColor = true;
            // 
            // move6
            // 
            this.move6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.move6.Location = new System.Drawing.Point(1539, 360);
            this.move6.Name = "move6";
            this.move6.Size = new System.Drawing.Size(131, 41);
            this.move6.TabIndex = 18;
            this.move6.Text = "Move Image";
            this.move6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1539, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Image Dimensions:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1539, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Image Name:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1539, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Next Image:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1539, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Images Remaining:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1539, 554);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Position:";
            // 
            // dir2
            // 
            this.dir2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir2.Location = new System.Drawing.Point(1676, 182);
            this.dir2.Name = "dir2";
            this.dir2.Size = new System.Drawing.Size(173, 23);
            this.dir2.TabIndex = 25;
            // 
            // dir3
            // 
            this.dir3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir3.Location = new System.Drawing.Point(1676, 229);
            this.dir3.Name = "dir3";
            this.dir3.Size = new System.Drawing.Size(173, 23);
            this.dir3.TabIndex = 26;
            // 
            // dir4
            // 
            this.dir4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir4.Location = new System.Drawing.Point(1676, 276);
            this.dir4.Name = "dir4";
            this.dir4.Size = new System.Drawing.Size(173, 23);
            this.dir4.TabIndex = 27;
            // 
            // dir5
            // 
            this.dir5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir5.Location = new System.Drawing.Point(1676, 323);
            this.dir5.Name = "dir5";
            this.dir5.Size = new System.Drawing.Size(173, 23);
            this.dir5.TabIndex = 28;
            // 
            // dir6
            // 
            this.dir6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir6.Location = new System.Drawing.Point(1676, 370);
            this.dir6.Name = "dir6";
            this.dir6.Size = new System.Drawing.Size(173, 23);
            this.dir6.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.imgScaled);
            this.panel1.Controls.Add(this.imgOriginal);
            this.panel1.Location = new System.Drawing.Point(12, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1511, 932);
            this.panel1.TabIndex = 30;
            // 
            // imgScaled
            // 
            this.imgScaled.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.imgScaled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgScaled.Location = new System.Drawing.Point(0, 0);
            this.imgScaled.Name = "imgScaled";
            this.imgScaled.Size = new System.Drawing.Size(1511, 932);
            this.imgScaled.TabIndex = 1;
            this.imgScaled.TabStop = false;
            // 
            // imgOriginal
            // 
            this.imgOriginal.Location = new System.Drawing.Point(0, 0);
            this.imgOriginal.Name = "imgOriginal";
            this.imgOriginal.Size = new System.Drawing.Size(1511, 932);
            this.imgOriginal.TabIndex = 0;
            this.imgOriginal.TabStop = false;
            // 
            // dir1
            // 
            this.dir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dir1.Location = new System.Drawing.Point(1676, 135);
            this.dir1.Name = "dir1";
            this.dir1.Size = new System.Drawing.Size(173, 23);
            this.dir1.TabIndex = 24;
            // 
            // sourceDir
            // 
            this.sourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceDir.Location = new System.Drawing.Point(1676, 56);
            this.sourceDir.Name = "sourceDir";
            this.sourceDir.Size = new System.Drawing.Size(173, 23);
            this.sourceDir.TabIndex = 11;
            // 
            // moveDirTxt
            // 
            this.moveDirTxt.Location = new System.Drawing.Point(622, 64);
            this.moveDirTxt.Name = "moveDirTxt";
            this.moveDirTxt.Size = new System.Drawing.Size(170, 23);
            this.moveDirTxt.TabIndex = 31;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1864, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.undoImageMoveToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // undoImageMoveToolStripMenuItem
            // 
            this.undoImageMoveToolStripMenuItem.Name = "undoImageMoveToolStripMenuItem";
            this.undoImageMoveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoImageMoveToolStripMenuItem.Text = "Undo";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotkeysToolStripMenuItem,
            this.overwriteFileToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            // 
            // overwriteFileToolStripMenuItem
            // 
            this.overwriteFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overwriteToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.overwriteFileToolStripMenuItem.Name = "overwriteFileToolStripMenuItem";
            this.overwriteFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1864, 1041);
            this.Controls.Add(this.moveDirTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dir6);
            this.Controls.Add(this.dir5);
            this.Controls.Add(this.dir4);
            this.Controls.Add(this.dir3);
            this.Controls.Add(this.dir2);
            this.Controls.Add(this.dir1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.move6);
            this.Controls.Add(this.move5);
            this.Controls.Add(this.move4);
            this.Controls.Add(this.move3);
            this.Controls.Add(this.move2);
            this.Controls.Add(this.move1);
            this.Controls.Add(this.loadSrcDir);
            this.Controls.Add(this.sourceDir);
            this.Controls.Add(this.moveDir);
            this.Controls.Add(this.prevImg);
            this.Controls.Add(this.nextImg);
            this.Controls.Add(this.prevDir);
            this.Controls.Add(this.nextDir);
            this.Controls.Add(this.dirsLoad);
            this.Controls.Add(this.btnScale);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Image Helper";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgScaled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOriginal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.Button dirsLoad;
        private System.Windows.Forms.Button nextDir;
        private System.Windows.Forms.Button prevDir;
        private System.Windows.Forms.Button nextImg;
        private System.Windows.Forms.Button prevImg;
        private System.Windows.Forms.Button moveDir;
        private System.Windows.Forms.Button loadSrcDir;
        private System.Windows.Forms.Button move1;
        private System.Windows.Forms.Button move2;
        private System.Windows.Forms.Button move3;
        private System.Windows.Forms.Button move4;
        private System.Windows.Forms.Button move5;
        private System.Windows.Forms.Button move6;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox dir6;
        private System.Windows.Forms.TextBox sourceDir;
        private System.Windows.Forms.TextBox moveDirTxt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoImageMoveToolStripMenuItem;
        public System.Windows.Forms.PictureBox imgOriginal;
        public System.Windows.Forms.PictureBox imgScaled;
        public System.Windows.Forms.TextBox dir2;
        public System.Windows.Forms.TextBox dir3;
        public System.Windows.Forms.TextBox dir4;
        public System.Windows.Forms.TextBox dir1;
        public System.Windows.Forms.TextBox dir5;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem overwriteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

