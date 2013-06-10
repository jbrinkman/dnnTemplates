using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace dnnTemplates
{
    public abstract class WizardBase : IWizard
    {

        public virtual void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
        }

        public virtual void ProjectFinishedGenerating(EnvDTE.Project project)
        {
        }

        public virtual void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
        }

        public virtual void RunFinished()
        {
        }

        public virtual void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                // BOs can be only created when adding new item 
                //if (runKind == WizardRunKind.AsNewItem)
                //{
                //    String keyList = string.Empty; 
                //    foreach (var thiskey in replacementsDictionary.Keys)
                //    {
                //        keyList += thiskey + "; ";
                //    }
                //    MessageBox.Show("Keys: " + keyList);
                //    var key = "$templateType$";
                //    if (replacementsDictionary.ContainsKey(key))
                //    {
                //        MessageBox.Show("Has Key...");
                //        switch (replacementsDictionary[key])
                //        {
                //            case "DataLayer":
                //                MessageBox.Show("Is DataLayer...");
                //                ShowDataWizard(replacementsDictionary);
                //                break;
                //            case "ViewControl":
                //                MessageBox.Show("Is ViewControl...");
                //                break;
                //            default:
                //                break;
                //        }


                //    }
                //}
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

        public virtual bool ShouldAddProjectItem(string filePath)
        {
            return false;
        }


    }
}
