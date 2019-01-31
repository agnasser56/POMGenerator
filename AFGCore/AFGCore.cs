using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Reflection;
namespace AFGCore
{
    public class AFGCore
    {
        public IEnumerable<HtmlNode> GetItemsFromHTML(string filePath, string itemType)
        {
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.Load(filePath);


            // GenerateClasses(htmlDocument);

            IEnumerable<HtmlNode> items = htmlDocument.DocumentNode.Descendants(itemType);
            return items;

        }


        //This will return all abjects of common types
        public IEnumerable<HtmlNode> GetItemsFromHTML(string filePath)
        {
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");

            //   HtmlWeb htmlWeb = new HtmlWeb() { AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("Windows-1256") };

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            try
            {
                htmlDocument.OptionReadEncoding = false;
                htmlDocument.Load(filePath);

                // GenerateClasses(htmlDocument);
                IEnumerable<HtmlNode> items = htmlDocument.DocumentNode.Descendants();




                items = from node in htmlDocument.DocumentNode.Descendants()
                            //Add more object types here
                            //  where node.Name  == "input" || node.Name == "button" || node.Name == "select" 
                            //  ||   (node.Name == "a" ) || node.Name == "span" //|| node.Name == "label"
                            //&& node.Attributes["type"].Value == "button") //||  node.Name == "select" 
                        select node;

                items = items.Where(x => x.NodeType == HtmlNodeType.Element);
                return items;
            }
            catch { return null; }
        }


        //This will return all abjects of common types
        public IEnumerable<HtmlNode> GetItemsFromHTMLOnline(string URL)
        {
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");

            HtmlWeb htmlWeb = new HtmlWeb() { AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("Windows-1256") };

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            try
            {
                //    HtmlWeb htmlWeb = new HtmlWeb();
                htmlDocument.OptionReadEncoding = false;
                htmlDocument = htmlWeb.Load(URL);



                //htmlDocument.OptionReadEncoding = false;
                // htmlDocument.Load(URL);

                // GenerateClasses(htmlDocument);
                IEnumerable<HtmlNode> items = htmlDocument.DocumentNode.Descendants();




                items = from node in htmlDocument.DocumentNode.Descendants()
                            //Add more object types here
                            //  where node.Name  == "input" || node.Name == "button" || node.Name == "select" 
                            //  ||   (node.Name == "a" ) || node.Name == "span" //|| node.Name == "label"
                            //&& node.Attributes["type"].Value == "button") //||  node.Name == "select" 
                        select node;

                items = items.Where(x => x.NodeType == HtmlNodeType.Element);
                return items;
            }
            catch { return null; }
        }

        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string FormatLabels(string labelName)
        {

            return RemoveSpecialCharacters(labelName);
        }

        public string FormatVariable(string labelName)
        {
            string result = labelName;
            string fLetterToUpperCase = result[0].ToString();
            result = RemoveSpecialCharacters(labelName);
            fLetterToUpperCase = fLetterToUpperCase.ToString().ToUpper();
            result = result.Remove(0, 1);
            result = fLetterToUpperCase + result;
            return result;
        }

        public IEnumerable<Type> GetClassNamesInDll(string assemblyName)
        {
            IEnumerable<Type> classNames;
            string @namespace = assemblyName;
            classNames = Assembly.LoadFrom(assemblyName).GetTypes();
            //classNames = from t in Assembly.LoadFrom("Faker.NET4.dll").GetTypes()
            //        where t.IsClass && t.Namespace == @namespace
            //        select t;
            //q.ToList().ForEach(t => classNames.Add(t.Name));
            return classNames.Where(x => x.Namespace == assemblyName);
        }
        public List<MethodInfo> GetDataGenerationTypes(string ClassName)
        {
            List<string> dataTypes = new List<string>();
            List<MethodInfo> methodInfo = new List<MethodInfo>();
            // get all public static methods of MyClass type
            //Assembly.GetAssembly(Type.GetType(ClassName))
            //typeof(Faker.Address)
            //MessageBox.Show(Type.GetType(ClassName));
            methodInfo = Type.GetType(ClassName).GetMethods(BindingFlags.Public |
                                                                  BindingFlags.Static).ToList();
            // sort methods by name
            Array.Sort(methodInfo.ToArray(),
                    delegate (MethodInfo methodInfo1, MethodInfo methodInfo2)
                    { return methodInfo1.Name.CompareTo(methodInfo2.Name); });

            // write method names
            //foreach (MethodInfo methodInfo in methodInfos)
            //{
            //    dataTypes.Add(methodInfo.Name);
            //  //Console.WriteLine(methodInfo.Name);
            //}
            return methodInfo;
        }
        public IEnumerable<CustomHTMLNodeList> RemoveDuplicateItems(ref CustomHTMLNodeList custList)
        {
            bool filter = false;
            try
            {
                
                //  List<HtmlNode> myItems = custList.customItems;
                // int i = 0;
                foreach (var item in custList.customItems)
                {
                    foreach (var attribute in item.node.Attributes.ToList())
                    {

                        //filter the output attributes to exclude the unnesseccary ones

                        filter = (attribute.Name != "id" ? attribute.Name != "name" ? attribute.Name != "class" ? attribute.Name != "index" ? attribute.Name != "type" ? true : false : false : false : false : false);
                        if (filter)
                            attribute.Remove();

                    }

                }
                DuplicatesComparer comp = new DuplicatesComparer();
                var unique_items = custList.customItems.Distinct(comp);

                return unique_items;
            }
            catch (Exception e) { //MessageBox.Show(e.Message); 
                return null; 
            }

        }
        public void IndexList(IEnumerable<HtmlNode> list)
        {
            int i = 0;
            foreach (HtmlNode n in list.ToList())
            {
                n.Attributes.Add("index", i.ToString());
                i++;
            }
        }
        public string GetControlName(HtmlNode item)
        {

            string objPrefixSpecialCase = "";
            string variableName = "";
            string objPrefix = "";
            bool linkIsButton = false;
            bool inputIsCheckBox = false;
            bool inputIsRadio = false;
            bool itemIsButton = false;
            bool itemIsText = false;
            bool itemIsList = false;
            bool itemIsCheckBox = false;
            bool itemIsRadio = false;

            linkIsButton = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "button" : item.Attributes["class"] != null ? item.Attributes["class"].Value.Contains("btn") || item.Attributes["class"].Value.Contains("button") : false);
            inputIsCheckBox = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "checkbox" : false);
            inputIsRadio = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "radio" : false);

            itemIsButton = (item.Name == "button" || (item.Name == "a" && linkIsButton) ? true : false);
            itemIsCheckBox = (item.Name == "input" && inputIsCheckBox);
            itemIsRadio = (item.Name == "input" && inputIsRadio);
            itemIsText = (item.Name == "input" || item.Name == "textarea");
            itemIsList = (item.Name == "select");



            objPrefix = (itemIsCheckBox ? "chk" : itemIsRadio ? "rdb" : itemIsText ? "txt" : itemIsButton ? "btn" : itemIsList ? "ddl" : item.Name == "span" ? "spn" : item.Name == "label" ? "lbl" : item.Name == "div" ? "div" : item.Name == "a" ? "lnk" : "");
            variableName = objPrefix + objPrefixSpecialCase + ((item.Id != null ? (item.Id != "" ? FormatVariable(item.Id) : FormatVariable(item.Name)) : ""));
            return variableName;
        }

        public string GetIdentificationProperty(HtmlNode item)
        {

            string FindsByClause = "";
            foreach (var attribute in item.Attributes)
            {

                //filter the output attributes to exclude the unnesseccary ones

                //if (customList.customItems.ElementAt(i ).ItemType == "Text")
                //itemAttributes += "\t\t" + (attribute.Value != "" && !(attribute.Name == "value" || attribute.Name == "type" || attribute.Name == "onchange" || attribute.Name == "onclick" || attribute.Name == "dir" || attribute.Name == "style" || attribute.Name == "href" || attribute.Name == "onblur" || attribute.Name == "path" || attribute.Name == "multiple" || attribute.Name == "target") ? variableName + "Desc(\"" + (attribute.Name == "id" ? "html id" : attribute.Name) + "\").Value = \"" + attribute.Value.Replace(' ', '.') + "\"\n" : "");

                //If Html ID exist, ignore other attributes
                if (item.Attributes.Contains("name"))
                {

                    FindsByClause = attribute.Name + ";" + attribute.Value;
                    break;
                }
                if (item.Attributes.Contains("id"))
                {

                    FindsByClause = attribute.Name + ";" + attribute.Value;
                    break;
                }
               
                if (item.Attributes.Contains("type"))
                {

                    FindsByClause = "CssSelector" + ";" + item.Name + "[type='" + attribute.Value + "']\")]";
                    break;
                }
                else
                {
                    if (item.InnerText.Trim() != "")
                        FindsByClause = "Xpath" + ";" + "(//" + item.Name + "[text()[contains(.,'" + item.InnerText + "')]])[1]";
                    else
                        FindsByClause = "TagName" + ";" + item.Name;
                }
            }
            
            return FindsByClause;

        }

        public string GetLeanFTElementType(string s)
        {
            char[] charsToTrim = { '\t', ' ', '\n' };
            string eleType = "";
            if (s.Trim(charsToTrim).StartsWith("txt"))
            {
                eleType = "IEditField";

            }
            else if (s.Trim(charsToTrim).StartsWith("ddl"))
            {
                eleType = "IListBox";

            }
            else if (s.Trim(charsToTrim).StartsWith("btn"))
            {
                eleType = "IButton";

            }
            else
            {
                eleType = "IWebElement";

            }
            return eleType;
        }


    }
}
