using System;
using System.IO;
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
            selectallToolStripMenuItem.Click += (s, e) => richTextBox.SelectAll();
        }

        private void WriteTofile(string fileName)
        {
            var output = new StreamWriter(File.OpenWrite(saveFileDialog.FileName));
            output.Write(richTextBox.Text);
            output.Close();
            filePath = fileName;
            needSaving = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newFileDialog = new newFileForm();
            if (newFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox.Enabled = true;
                filePath = newFileDialog.fileName;
                needSaving = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.LoadFile(openFileDialog.FileName);
                richTextBox.Enabled = true;
                needSaving = false;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(needSaving)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string s = saveFileDialog.Filter;
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox.CanUndo)
            {
                richTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (richTextBox.CanRedo)
            {
                richTextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog.ShowDialog() == DialogResult.OK)
                richTextBox.SelectionFont = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
                richTextBox.SelectionColor = colorDialog.Color;
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
