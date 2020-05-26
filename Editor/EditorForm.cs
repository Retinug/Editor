using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class EditorForm : Form
    {
        string filePath = "";
        private bool needSaving = false;

        public EditorForm()
        {
            InitializeComponent();
            saveFileDialog.FileOk += (s,e) => WriteTofile(saveFileDialog.FileName);
            selectallToolStripMenuItem.Click += (s, e) => richTextBox1.SelectAll();
        }

        private void WriteTofile(string fileName)
        {
            var output = new StreamWriter(File.OpenWrite(saveFileDialog.FileName));
            output.Write(richTextBox1.Text);
            output.Close();
            filePath = fileName;
            needSaving = false;
        }

        private void newStripButton_Click(object sender, EventArgs e)
        {
            var newFileDialog = new newFileForm();
            if(newFileDialog.ShowDialog(this)==DialogResult.OK)
            {
                richTextBox1.Enabled = true;
                filePath = newFileDialog.fileName;
                needSaving = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var input = File.OpenText(openFileDialog.FileName);
                richTextBox1.Text = input.ReadToEnd();
                input.Close();
                richTextBox1.Enabled = true;
                needSaving = false;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(needSaving)
            {
                saveFileDialog.FileName = filePath;
                saveFileDialog.ShowDialog();
            }
            saveFileDialog.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog.Color;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
