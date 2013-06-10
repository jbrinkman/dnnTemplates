using Microsoft.VisualStudio.TextTemplating;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnnTemplates.Templating
{
    public static class TemplatingHelper
    {
        public static string GenerateArtifact(string resource, object data)
        {
            TemplatingHost host = null;
            try
            {
                var contents = GetTemplateResource(resource);
                var path = Path.ChangeExtension(Path.GetTempFileName(), "txt");
                File.WriteAllText(path, contents);
                host = new TemplatingHost(path, data);
                var result = new Engine().ProcessTemplate(contents, host);
                if (host.Errors.Cast<CompilerError>().Where(c => !c.IsWarning).Count() > 0)
                {
                    throw new Exception();
                }
                return result;
            }
            catch 
            {
                if (host != null)
                {
                    var sb = new StringBuilder();
                    foreach (CompilerError error in host.Errors)
                    {
                        sb.AppendLine(error.ErrorText);
                    }
                    throw new Exception(sb.ToString());
                }
                else
                {
                    throw;
                }
            }
        }

        public static string GetTemplateResource(string resource)
        {
            var assembly = typeof(TemplatingHelper).Assembly;

            var sb = new StringBuilder();

            string stringFormat = String.Format("{0}.Resources.T4.{1}", typeof(WizardBase).Namespace, resource);

            using (var stream = assembly.GetManifestResourceStream(stringFormat))
            {
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        sb.AppendLine(sr.ReadToEnd());
                    }
                }
                else
                { 
                    //TODO: Log Error
                }
            }

            return sb.ToString();
        }
    }
}
