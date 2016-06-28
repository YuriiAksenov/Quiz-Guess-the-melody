using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GuessMelody
{
    public partial class fParam : Form
    {
        public fParam()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Victorina.allDirectories = cbAllDirectories.Checked;
            Victorina.gameDuration = Convert.ToInt32(cbGameDuration.Text);
            Victorina.musicDuration = Convert.ToInt32(cbMusicDuration.Text);
            Victorina.randomStart = cbRandomStart.Checked;
            Victorina.WriteParam();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetParam();
            this.Hide();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog()==DialogResult.OK)
            {
                string[] music_list = System.IO.Directory.GetFiles(folderBrowserDialog.SelectedPath,"*.mp3", cbAllDirectories.Checked? System.IO.SearchOption.AllDirectories: System.IO.SearchOption.TopDirectoryOnly);
                Victorina.lastFolder = folderBrowserDialog.SelectedPath;
                Victorina.list.Clear();
                Victorina.list.AddRange(music_list);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(music_list);
            }
        }

        private void fParam_Load(object sender, EventArgs e)
        {
            SetParam();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Victorina.list.ToArray());
        }
        void SetParam()
        {
            cbAllDirectories.Checked = Victorina.allDirectories;
            cbRandomStart.Checked = Victorina.randomStart;
            cbGameDuration.Text = Victorina.gameDuration.ToString();
            cbMusicDuration.Text = Victorina.musicDuration.ToString();
        }
    }
}
