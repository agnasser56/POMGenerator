using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
namespace AFGCore
{
    public class DuplicatesComparer : IEqualityComparer<CustomHTMLNodeList>
    {
        public bool Equals(CustomHTMLNodeList x, CustomHTMLNodeList y)
        {
            
            return x.node.OuterHtml.Trim().Equals(y.node.OuterHtml.Trim());
        }
        public int GetHashCode(CustomHTMLNodeList obj)
        {
            return obj.node.OuterHtml.GetHashCode();
        }
    }
}