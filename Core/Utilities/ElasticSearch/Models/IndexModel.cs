using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ElasticSearch.Models
{
   public class IndexModel
    {
        public string IndexName { get; set; }
        public string AliasName { get; set; }
        public int NumberOfReplicas { get; set; }
    }
}
