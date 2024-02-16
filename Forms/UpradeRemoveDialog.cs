using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class UpradeRemoveDialog : Form
    {
        List<string> names;
        bool stopParsing;
        public UpradeRemoveDialog()
        {
            InitializeComponent();
            stopParsing = false;
            setupProgressBar();
        }

        void setupProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = names.Count * 10;
        }

        


        private void UpradeRemoveDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopParsing = true;
        }

        private async void UpradeRemoveDialog_Shown(object sender, EventArgs e)
        {
            MalInterface mal = new MalInterface();
            foreach (string name in names)
            {
                if (stopParsing) break;
                // await id call or remove
            }
            Close();
        }
    }
}
