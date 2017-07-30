using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtChecker.Model
{

    public class Document
    {
        public string language { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class RootObject
    {
        public List<Document> documents { get; set; }
    }
}
