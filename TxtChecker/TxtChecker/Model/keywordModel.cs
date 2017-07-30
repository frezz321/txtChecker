using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtChecker.keywordModel
{
    public class Document
    {
        public string id { get; set; }
        public List<string> keyPhrases { get; set; }
    }

    public class RootObject
    {
        public List<Document> documents { get; set; }
    }
}
