using dnnTemplates.Models;
using dnnTemplates.Templating;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dnnTemplates.Dialogs
{
    public partial class ViewControlDialog : Form
    {
        private Dictionary<string, string> _TokenReplacements = new Dictionary<string, string>();
        private List<Template> _Templates = new List<Template>();
        private readonly ViewControlModel _Data;

        public ViewControlDialog()
        {
            InitializeComponent();
        }

        public ViewControlDialog(List<Template> templates, ViewControlModel data)
        {
            InitializeComponent();
            Templates = templates;
            _Data = data;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string token;
            Data.IncludeMenu = CreateMenu.Checked;

            foreach (Template t in Templates)
            {
                token = String.Format("${0}$", t.Token.Trim('$'));
                
                TokenReplacements[token] = TemplatingHelper.GenerateArtifact(t.FileName, Data);
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public ViewControlModel Data
        {
            get
            {
                return _Data;
            }
        }

        public List<Template> Templates
        {
            get
            {
                return _Templates;
            }
            set
            {
                _Templates = value;
            }
        }

        public Dictionary<string, string> TokenReplacements
        {
            get
            {
                return _TokenReplacements;
            }
            set
            {
                _TokenReplacements = value;
            }
        } 
    }
}
