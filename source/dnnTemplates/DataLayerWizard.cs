using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using dnnTemplates.Dialogs;

namespace dnnTemplates
{
    public class DataLayerWizard : WizardBase
    {

        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                if (runKind == WizardRunKind.AsNewItem)
                {
                    ShowDataWizard(replacementsDictionary);
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
            return true;
        }

        private static void ShowDataWizard(Dictionary<string, string> replacementsDictionary)
        {
            var key = "$rootname$";
            if (replacementsDictionary.ContainsKey(key))
            {
                var itemName = replacementsDictionary[key];
                MessageBox.Show("Is Item: " + itemName);

                var window = new DataLayerWizardDialog();

                window.ShowDialog();

                window.Dispose();
            }
        }

    }
}
