using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    public partial class ListProviderConfDialog : Form
    {
        public ListTranslationOptions Options;
        public ListProviderConfDialog(ListTranslationOptions options)
        {
            Options = options;
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            this.dlg_OpenFile.ShowDialog();
            string fileName = this.dlg_OpenFile.FileName;

            if (fileName != "")
            {
                txt_ListFile.Text = fileName;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Options.Delimiter = this.combo_delimiter.Text;
            Options.ListFileName = this.txt_ListFile.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ListProviderConfDialog_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
