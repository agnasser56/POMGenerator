using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
//using Faker;
//using Faker.Extensions;
namespace AFGCore
{
    public enum ItemTypes
    {
         Link,Text , RadioButton , CheckBox , DropDownList, Button 
    }
    public class CustomHTMLNodeList
    {
        
        public HtmlNode node ;
        public int OriginalIndex;
        public string varName;
        public string uftVarName;
        public string leanftVarName;
        public string ItemType;
        public string Caption;
        public string ValueType;
        public bool AutoGenerate;
        public bool Active;

        public List<CustomHTMLNodeList> customItems ;

        public CustomHTMLNodeList()
        {
            
            OriginalIndex = 0;
        }

        public static string RemoveSpecialCharacters(string str)
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

        private string FormatVariable(string ctrName)
        {
            string result = ctrName;
            
            string fLetterToUpperCase = result[0].ToString();
            result = RemoveSpecialCharacters(ctrName);
            fLetterToUpperCase = fLetterToUpperCase.ToString().ToUpper();
            result = result.Remove(0, 1);
            result = fLetterToUpperCase + result;
            return result;
        }

        private List<string> GetControlName(HtmlNode item, string browserPrefix)
        {
            List<string> result = new List<string>();
            string objPrefixSpecialCase = "";
            string itemCaption = "";
            string itemType = "";
            string variableName = "";
            string uftObjPrefix = "";
            string leanFTObjPrefix = "";
            string objPrefix = "";
            bool linkIsButton = false;
            bool inputIsCheckBox = false;
            bool inputIsRadio = false;
            bool itemIsButton = false;
            bool itemIsText = false;
            bool itemIsList = false;
            bool itemIsCheckBox = false;
            bool itemIsRadio = false;
            bool inputIsButton = false;
            bool itemHasPrefix = false;
            //Object Prefix
            linkIsButton = (item.Attributes["type"] != null ? item.Attributes["type"].Value.ToLower() == "button" || item.Attributes["type"].Value.ToLower() == "submit" : item.Attributes["class"] != null ? item.Attributes["class"].Value.Contains("btn") || item.Attributes["class"].Value.Contains("button") : false);
            inputIsButton = item.Name == "input" ? (item.Attributes["class"] != null ? item.Attributes["class"].Value.Contains("button") || item.Attributes["class"].Value.ToLower().Contains("btn") : false) : false;
            inputIsCheckBox = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "checkbox" : false);
            inputIsRadio = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "radio" : false);

            itemIsButton = (item.Name == "button" || linkIsButton || inputIsButton || (item.Name == "a" && linkIsButton) ? true : false);
            itemIsCheckBox = (item.Name == "input" && inputIsCheckBox);
            itemIsRadio = (item.Name == "input" && inputIsRadio);
            itemIsText = ((item.Name == "input" && !itemIsButton && !itemIsCheckBox && !itemIsRadio) || item.Name == "textarea");
            itemIsList = (item.Name == "select");
           

            

            objPrefix = (itemIsCheckBox ? "chk" : itemIsRadio ? "rdb" : itemIsText ? "txt" : itemIsButton ? "btn" : itemIsList ? "ddl" : item.Name == "span" ? "spn" : item.Name == "label" ? "lbl" : item.Name == "div" ? "div" : item.Name == "a" ? "lnk" : "");
            variableName = objPrefix + objPrefixSpecialCase + ((item.Id != null ? (item.Id != "" ? FormatVariable(item.Id) : FormatVariable(item.Name)) : ""));
            //1 item is variable name
            result.Add(variableName);
            uftObjPrefix =browserPrefix+"." + (itemIsCheckBox ? "WebCheckBox" : itemIsList ? "WebList" : itemIsRadio ? "WebElement" : itemIsText ? "WebEdit" : itemIsButton ? "WebElement" : "WebElement");
            leanFTObjPrefix = (itemIsCheckBox ? "ICheckBox" : itemIsList ? "IListBox" : itemIsRadio ? "IRadioGroup" : itemIsText ? "IEditField" : itemIsButton ? "IButton" : "WebElement");
            //2nd item is uftvarname
            result.Add(uftObjPrefix);
            
            itemCaption = ((item.Id != null ? (item.Id != "" ? FormatVariable(item.Id) : FormatVariable(item.Name)) : ""));
            //3rd item is item caption
            result.Add(itemCaption);
            //4th item is item type
            itemType = (itemIsButton ? "Button" : itemIsCheckBox ? "CheckBox" : itemIsText ? "Text" : itemIsRadio ? "RadioButton" : itemIsList ? "DropDownList" : item.Name == "a" ? "Link" : "");
            result.Add(itemType);
            result.Add(leanFTObjPrefix);
            return result;
        }

        public string GetItemCaption(HtmlNode item )
        {
             return ((item.Id != null ? (item.Id != "" ? FormatVariable(item.Id) : FormatVariable(item.Name)) : "")); 
        }

        
        // variableCaption = ((item.Id != null ? (item.Id != "" ? FormatVariable(item.Id) : FormatVariable(item.Name)) : ""));
        public CustomHTMLNodeList(IEnumerable<HtmlNode> orgList)
        {
            try
            {
                List<string> itemDesc = new List<string>();
                customItems = new List<CustomHTMLNodeList>(orgList.Count());

                int i = 0;
                foreach (HtmlNode item in orgList)
                {
                    CustomHTMLNodeList newItem = new CustomHTMLNodeList();
                    newItem.node = item;
                    newItem.OriginalIndex = i;
                    itemDesc = GetControlName(item,"WebPage");
                    newItem.varName = itemDesc.ElementAt(0);
                    newItem.uftVarName = itemDesc.ElementAt(1);
                    newItem.Caption = itemDesc.ElementAt(2);
                    newItem.ItemType = itemDesc.ElementAt(3);
                    newItem.leanftVarName = itemDesc.ElementAt(4);
                    customItems.Add(newItem);

                    ////= new CustomHTMLNodeList();
                    //customItems.ElementAt(i).node = new HtmlNode(HtmlNodeType.Element, null, i);
                    //customItems.ElementAt(i).node = item;
                    //customItems.ElementAt(i).OriginalIndex = i;
                    //customItems.ElementAt(i).Caption = GetItemCaption(item);
                    i++;
                }
            }
            catch { }
        }
        
        
    }
}