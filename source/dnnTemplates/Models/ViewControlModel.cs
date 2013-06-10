using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dnnTemplates.Models
{
    [Serializable]
    public class ViewControlModel
    {
        public bool IncludeMenu { get; set; }
        public string NameSpace { get; set; }
        public string ItemName { get; set; }
    }
}
