using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dnnTemplates.Extensions;
using dnnTemplates.Dialogs;
using dnnTemplates.Templating;
using dnnTemplates.Models;

namespace dnnTemplates
{
    public class ViewControlWizard : WizardBase
    {
        private bool ShouldAddItems = false;

        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                if (runKind == WizardRunKind.AsNewItem)
                {
                    ShowViewControlWizard(replacementsDictionary);
                }
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine("");
                sb.AppendLine(ex.StackTrace);
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool ShouldAddProjectItem(string filePath)
        {
            return ShouldAddItems;
        }

        private void ShowViewControlWizard(Dictionary<string, string> replacementsDictionary)
        {
            try
            {
                const string t4Key = "$T4templates$";
                List<Template> templates;

                if (replacementsDictionary.ContainsKey(t4Key))
                    templates = replacementsDictionary[t4Key].FromJson<List<Template>>();
                else
                    templates = null;

                if (templates != null)
                {
                    var data = new ViewControlModel() { 
                        NameSpace = replacementsDictionary["$rootnamespace$"],
                        ItemName = replacementsDictionary["$safeitemname$"]
                    };
                    using (var window = new ViewControlDialog(templates, data))
                    {
                        window.ShowDialog();
                        ShouldAddItems = (window.DialogResult == DialogResult.OK);
                        if (ShouldAddItems)
                        {
                            var TokenReplacements = window.TokenReplacements;
                            if (TokenReplacements != null)
                            {
                                var sb = new StringBuilder();
                                foreach (string key in TokenReplacements.Keys)
                                {
                                    replacementsDictionary[key] = TokenReplacements[key];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine("");
                sb.AppendLine(ex.StackTrace);
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

//var keyList = "";
//foreach (string key in replacementsDictionary.Keys)
//{
//    keyList += String.Format("{0}: {1}\r\n ", key, replacementsDictionary[key]);
//}
//MessageBox.Show(keyList);

//var key = "$rootname$";
//if (replacementsDictionary.ContainsKey(key))
//{
//    var itemName = replacementsDictionary[key];
//    MessageBox.Show("View Control Wizard. \r\nIs Item: " + itemName);

//}

//Dictionary<string, string> temp = new Dictionary<string,string>();
//temp.Add("test", "value");
//var json = temp.ToJson();
//MessageBox.Show("JSON: " + json);

//var temp2 = json.FromJson<Dictionary<string, string>>();

//MessageBox.Show("test: " + temp2["test"]);