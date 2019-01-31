using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;
using System.Reflection;
using AFGCore;
namespace AFG
{
    public partial class frmDesign : Form
    {
        AFGCore.AFGCore afgCore = new AFGCore.AFGCore();
        public string htmlFileName = "";
        string sourceCodeFilePath = "";
        public bool onlineMode = false;
        public IEnumerable<HtmlNode> items;
        public IEnumerable<HtmlNode> newList;
        public CustomHTMLNodeList customList;
        public frmDesign()
        {
            InitializeComponent();
        }
        //Fill the check list 
        public void FillCheckBoxList(CustomHTMLNodeList htmlNodes)
        {
            int i = 0;
            foreach (CustomHTMLNodeList t in htmlNodes.customItems)
            {
                if (!checkedListBox1.Items.Contains(t.node.Name))
                {
                    checkedListBox1.Items.Add(t.node.Name);
                    if (t.node.Name == "input" || t.node.Name == "button" || t.node.Name == "select" || t.node.Name == "a" || t.node.Name == "textarea")
                    {
                        checkedListBox1.SetItemChecked(i, true);

                    }
                    i++;
                }
            }
        }


        private void rdOffline_CheckedChanged(object sender, EventArgs e)
        {
            txtURL.Enabled = false;
        }

        private void rdOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOnline.Checked == true)
            {
                txtURL.Enabled = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdOffline.Checked == true)
                {

                    //openFileDialog1.ShowDialog();
                    //htmlFileName = (openFileDialog1.FileName != "" ? openFileDialog1.FileName : "");
                    if (htmlFileName == "")

                        MessageBox.Show("Please provide valid HTML file");
                    else
                    {
                        items = afgCore.GetItemsFromHTML(htmlFileName);
                        customList = new CustomHTMLNodeList(items);

                        label3.Text = items.Count().ToString();
                        FillCheckBoxList(customList);
                    }

                }
                if (rdOnline.Checked == true)
                {
                    txtURL.Enabled = true;
                    try
                    {
                        items = afgCore.GetItemsFromHTMLOnline(txtURL.Text);
                        customList = new CustomHTMLNodeList(items);

                        label3.Text = items.Count().ToString();
                        FillCheckBoxList(customList);
                        onlineMode = true;

                    }
                    catch { MessageBox.Show("URL is not Valid"); }
                }
                // IndexList(items);
            }
            catch { }
        }
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            FilterHTMLNodes();
            label3.Text = customList.customItems.Count().ToString();
        }

        private void GenerateLeanFTClasses(string filePath, IEnumerable<HtmlNode> items)
        {
            string returnClsObj = "";
            string clsName = "";
            string clsDef = "";
            string intializeMethodDef = "";
            string InitVarName = "";

            string uftObjPrefix = "";
            string ItemType = "";
            string variableName = "";
            string objectNames = "";
            string webBrowserDef = "";
            string itemAttributes = "";
            string assignObjDesc = "";
            string classTerminator = "";
            string FillFormFunction = "";
            string valueSource = "";
            string nextItemName = "";
            string waitNextItem = "";
            bool ClickableItems = false;

            string valueSourceName = "";
            // IEnumerable<HtmlNode> inputs = htmlDocument.DocumentNode.Descendants("inputs");
            clsName = filePath.Split(new char[] { '\\' }).Last().Split(new char[] { '.' }).First();
            clsDef = "using HP.LFT.SDK.Web;\nusing System.Data;\nnamespace Framework.ObjectRepositories\n{\n\tpublic class " + clsName + "{\n";//1


            //Return class object function
            //string funcName = "";
            //funcName += "New" + clsName;

            //returnClsObj += "Public Function " + funcName + "()\n set " + funcName + " = new " + clsName + "\n End Function\n\t";
            FillFormFunction += "public void FillForm(DataRow dr)\n\t{";

            int i = 0;
            try
            {
                Random r = new Random();
                string captilizedItemName = "";
                //Members definition
                intializeMethodDef = "\tpublic " + clsName + "() \n\t{";//2 {
                webBrowserDef += "\tpublic IBrowser testBrowser;\n";
                //Web page definction
                //webBrowserDef += "\tBrowserDescription browserDesc = new BrowserDescription();\n\t  browserDesc.Title=\".*\" \n\t testBrowser = BrowserFactory.Attach(browserDesc);";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (i == dataGridView1.Rows.Count - 1)
                        break;
                    HtmlNode item = customList.customItems.ElementAt(i).node;
                    ItemType = customList.customItems.ElementAt(i).ItemType;
                    ClickableItems = (ItemType == "Button" || ItemType == "CheckBox" || ItemType == "RadioButton");



                    InitVarName = "\tpublic ";

                    //variableName = objPrefix + (item.Id != "" ? item.Id : item.Name)+(item.Attributes["value"]!= null?item.Attributes["value"].Value:"") ;


                    variableName = row.Cells["clmControlName"].Value.ToString();
                    uftObjPrefix = customList.customItems.ElementAt(i).leanftVarName;
                    //Generate fillForm function 
                    valueSourceName = (dataGridView1.Rows[i].Cells["clmValueSource"].Value != null ? dataGridView1.Rows[i].Cells["clmValueSource"].Value.ToString() : "");

                    valueSource = " dr[\"" + valueSourceName + "\"].ToString()";

                    FillFormFunction += variableName + (ClickableItems ? ".Click();" : ItemType == "Text" ? ".SetValue(" + valueSource + ");" : ItemType == "DropDownList" ? ".Select(" + valueSource + ");" : "");
                    FillFormFunction += "\n\t";

                    if (i < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[i + 1].Cells["clmControlName"].Value != null)
                        nextItemName = dataGridView1.Rows[i + 1].Cells["clmControlName"].Value.ToString();

                    //int.Parse(dataGridView1.Rows[i].Cells["Index"].Value.ToString())

                    //Generate wait property statement
                    // waitNextItem = (ClickableItems || ItemType == "DropDownList" ? nextItemName + ".waitProperty \"visible\",\"true\"," + "30000" + "\n\t" : "");
                    FillFormFunction += waitNextItem;
                    //commentVarName = " '"+item.Name+ " "+ (item.Name != "select"?item.InnerText:"") + "\n";
                    objectNames += InitVarName + uftObjPrefix + " " + (objectNames.Contains(variableName) ? (variableName + (r.Next().ToString())) : variableName) + ";";

                    objectNames += "\n";

                    //html tag
                    //itemAttributes += "\t\t" + variableName + "Desc(\"html tag\").Value = \"" + item.Name + "\"\n";

                    //inertext
                    itemAttributes += "\t\t" + variableName + " = testBrowser.Describe<" + uftObjPrefix + ">(new WebElementDescription" + "\n\t{";
                    itemAttributes += (item.Name.ToLower() != "select" ? (item.InnerText != "" ? "\t\t" + variableName + "Desc(\"innertext\").Value = \".*" + item.InnerText + ".*\"\n" : "") : "");

                    foreach (var attribute in item.Attributes)
                    {
                        //filter the output attributes to exclude the unnesseccary ones

                        //if (customList.customItems.ElementAt(i ).ItemType == "Text")

                        captilizedItemName = (attribute.Name == "class" ? "ClassName" : attribute.Name.ElementAt(0).ToString().ToUpper() + attribute.Name.Substring(1));
                        itemAttributes += "\t\t" + (attribute.Value != "" && !(attribute.Name == "value" || attribute.Name == "type" || attribute.Name == "onchange" || attribute.Name == "onclick" || attribute.Name == "dir" || attribute.Name == "style" || attribute.Name == "href" || attribute.Name == "onblur" || attribute.Name == "path" || attribute.Name == "multiple" || attribute.Name == "target") ?
                             captilizedItemName + " = \"" + attribute.Value.Replace(' ', '.') + "\",\n" : "");
                        //(attribute.Name == "id" ? "Id" : attribute.Name) + " = \"" + attribute.Value.Replace(' ', '.') + "\",\n" : "");
                        //If Html ID exist, ignore other attributes
                        if (attribute.Name == "id" && attribute.Value != "")
                            break;
                    }
                    assignObjDesc = "\t\t});\n";
                    itemAttributes += assignObjDesc + "\n";
                    i++;
                }
                classTerminator = "";
                clsDef += webBrowserDef + objectNames + intializeMethodDef + itemAttributes + "\n" + "\t} \n" + classTerminator +

                    FillFormFunction
                    +
                    "\n\t} \n\t}}";

                richTextBox1.Text += returnClsObj + clsDef;

            }


            catch (Exception ex) { Console.WriteLine(ex.InnerException); }

        }


        private void GenerateClasses(string filePath, IEnumerable<HtmlNode> items)
        {
            string returnClsObj = "";
            string clsName = "";
            string clsDef = "";
            string intializeMethodDef = "";
            string InitVarName = "";

            string uftObjPrefix = "";
            string ItemType = "";
            string variableName = "";
            string objectNames = "";
            string webBrowserDef = "";
            string itemAttributes = "";
            string assignObjDesc = "";
            string classTerminator = "";
            string FillFormFunction = "";
            string valueSource = "";
            string nextItemName = "";
            string waitNextItem = "";
            bool ClickableItems = false;

            string valueSourceName = "";
            // IEnumerable<HtmlNode> inputs = htmlDocument.DocumentNode.Descendants("inputs");
            clsName = filePath.Split(new char[] { '\\' }).Last().Split(new char[] { '.' }).First();
            clsDef = "Class " + clsName + "\n";


            //Return class object function
            string funcName = "";
            funcName += "New" + clsName;

            returnClsObj += "Public Function " + funcName + "()\n set " + funcName + " = new " + clsName + "\n End Function\n\t";
            FillFormFunction += "Public Function FillForm(Data)\n\t";

            int i = 0;
            try
            {
                Random r = new Random();
                //Members definition
                intializeMethodDef = "\tPrivate Sub Class_Initialize(  ) \n";
                webBrowserDef += "\tDim WebBrowserDesc\n \tSet  WebBrowserDesc=description.Create \n \tWebBrowserDesc(\"micclass\").value=\"Browser\" \n\t WebBrowserDesc(\"title\").value=\".*\" \n\t Set WebBrowser = Browser(WebBrowserDesc)\n";
                //Web page definction
                webBrowserDef += "\tDim WebPageDesc\n\t Set  WebPageDesc=description.Create\n\t  WebPageDesc(\"micclass\").value=\"Page\"\n\t WebPageDesc(\"title\").value=\".*\" \n\tSet WebPage= Browser(WebBrowserDesc).Page(WebPageDesc)\n";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (i == dataGridView1.Rows.Count - 1)
                        break;
                    HtmlNode item = customList.customItems.ElementAt(i).node;
                    ItemType = customList.customItems.ElementAt(i).ItemType;
                    ClickableItems = (ItemType == "Button" || ItemType == "CheckBox" || ItemType == "RadioButton");



                    InitVarName = "\tDim ";

                    //variableName = objPrefix + (item.Id != "" ? item.Id : item.Name)+(item.Attributes["value"]!= null?item.Attributes["value"].Value:"") ;


                    variableName = row.Cells["clmControlName"].Value.ToString();
                    uftObjPrefix = customList.customItems.ElementAt(i).uftVarName;
                    //Generate fillForm function 
                    valueSourceName = (dataGridView1.Rows[i].Cells["clmValueSource"].Value != null ? dataGridView1.Rows[i].Cells["clmValueSource"].Value.ToString() : "");

                    valueSource = " Data(\"" + valueSourceName + "\")\n\t";

                    FillFormFunction += "\t" + variableName + (ClickableItems ? ".Click\n\t" : ItemType == "Text" ? ".Set" + valueSource : ItemType == "DropDownList" ? ".Select" + valueSource : "");

                    if (i < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[i + 1].Cells["clmControlName"].Value != null)
                        nextItemName = dataGridView1.Rows[i + 1].Cells["clmControlName"].Value.ToString();

                    //int.Parse(dataGridView1.Rows[i].Cells["Index"].Value.ToString())

                    //Generate wait property statement
                    waitNextItem = (ClickableItems || ItemType == "DropDownList" ? nextItemName + ".waitProperty \"visible\",\"true\"," + "30000" + "\n\t" : "");
                    FillFormFunction += waitNextItem;
                    //commentVarName = " '"+item.Name+ " "+ (item.Name != "select"?item.InnerText:"") + "\n";
                    objectNames += InitVarName + (objectNames.Contains(variableName) ? (variableName + (r.Next().ToString())) : variableName);

                    objectNames += "\n";

                    //html tag
                    //itemAttributes += "\t\t" + variableName + "Desc(\"html tag\").Value = \"" + item.Name + "\"\n";

                    //inertext
                    itemAttributes += "\t\t" + "Set " + variableName + "Desc = Description.Create" + "\n";
                    itemAttributes += (item.Name.ToLower() != "select" ? (item.InnerText != "" ? "\t\t" + variableName + "Desc(\"innertext\").Value = \".*" + item.InnerText + ".*\"\n" : "") : "");

                    foreach (var attribute in item.Attributes)
                    {

                        //filter the output attributes to exclude the unnesseccary ones

                        //if (customList.customItems.ElementAt(i ).ItemType == "Text")
                        itemAttributes += "\t\t" + (attribute.Value != "" && !(attribute.Name == "value" || attribute.Name == "type" || attribute.Name == "onchange" || attribute.Name == "onclick" || attribute.Name == "dir" || attribute.Name == "style" || attribute.Name == "href" || attribute.Name == "onblur" || attribute.Name == "path" || attribute.Name == "multiple" || attribute.Name == "target") ? variableName + "Desc(\"" + (attribute.Name == "id" ? "html id" : attribute.Name) + "\").Value = \"" + attribute.Value.Replace(' ', '.') + "\"\n" : "");

                        //If Html ID exist, ignore other attributes
                        if (attribute.Name == "id" && attribute.Value != "")
                            break;
                    }
                    assignObjDesc = "\t\tSet " + variableName + " = " + uftObjPrefix + "(" + variableName + "Desc) \n";
                    itemAttributes += assignObjDesc + "\n";
                    i++;
                }
                classTerminator = " \tPrivate Sub Class_Terminate(  ) \n" +
                                "\t'This event is called when a class instnce is destroyed either explicitly (Set objClassInstance = Nothing) or   'implicitly (it goes out of scope) \n" +
                                "\tEnd Sub \n\t";
                clsDef += objectNames + intializeMethodDef + webBrowserDef + itemAttributes + "\n" + "\tEnd Sub \n" + classTerminator +

                    FillFormFunction
                    +
                    "\n\tEnd Function \n\tEnd Class";

                richTextBox1.Text += returnClsObj + clsDef;

            }


            catch (Exception ex) { Console.WriteLine(ex.InnerException); }

        }

        private void GenerateSeleniumClasses(string filePath, IEnumerable<HtmlNode> items)
        {

            string clsName = "";
            string clsDef = "";
            string InitVarName = "";
            string FindsBy = "";
            string FindsByClause = "";
            string ItemType = "";
            string variablePrefix = "";
            string variableName = "";
            string objectNames = "";
            string FillFormFunction = "";
            string valueSource = "";
            HtmlNode nextItemName;
            string waitNextItem = "";
            string SelectElement = "";
            bool ClickableItems = false;
            string IdentificationProperty = "";
            string valueSourceName = "";
            // IEnumerable<HtmlNode> inputs = htmlDocument.DocumentNode.Descendants("inputs");
            clsName = filePath.Split(new char[] { '\\' }).Last().Split(new char[] { '.' }).First();
            clsDef = "using System;\nusing System.Data;\nusing OpenQA.Selenium;\nusing OpenQA.Selenium.Support.PageObjects;\nusing System.IO;\nusing OpenQA.Selenium.Support.UI;\nnamespace BATDemoFramework\n{\n\tpublic class "
                + clsName + "\n\t{\n\t";

            FillFormFunction += "\tpublic void FillForm(DataRow dr)\n\t{\n\t//Default waiting \n\tWebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));\n\t ";

            int i = 0;
            try
            {
                Random r = new Random();

                //Members definition

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (i == dataGridView1.Rows.Count - 1)
                        break;
                    HtmlNode item = customList.customItems.ElementAt(i).node;
                    ItemType = customList.customItems.ElementAt(i).ItemType;
                    ClickableItems = (ItemType == "Button" || ItemType == "CheckBox" || ItemType == "RadioButton");



                    foreach (var attribute in item.Attributes)
                    {

                        //filter the output attributes to exclude the unnesseccary ones

                        //if (customList.customItems.ElementAt(i ).ItemType == "Text")
                        //itemAttributes += "\t\t" + (attribute.Value != "" && !(attribute.Name == "value" || attribute.Name == "type" || attribute.Name == "onchange" || attribute.Name == "onclick" || attribute.Name == "dir" || attribute.Name == "style" || attribute.Name == "href" || attribute.Name == "onblur" || attribute.Name == "path" || attribute.Name == "multiple" || attribute.Name == "target") ? variableName + "Desc(\"" + (attribute.Name == "id" ? "html id" : attribute.Name) + "\").Value = \"" + attribute.Value.Replace(' ', '.') + "\"\n" : "");

                        //If Html ID exist, ignore other attributes
                        if (item.Attributes.Contains("name"))
                        {
                            FindsBy = "Name, Using = \"" + attribute.Value + "\")]";
                            FindsByClause = attribute.Name + ";" + item.Attributes["name"].Value;
                            break;
                        }
                        if (item.Attributes.Contains("id"))
                        {
                            FindsBy = "Id, Using = \"" + item.Attributes["id"].Value + "\")]";
                            FindsByClause = attribute.Name + ";" + attribute.Value;
                            break;
                        }

                        if (item.Attributes.Contains("type"))
                        {
                            FindsBy = "CssSelector, Using = \"" + item.Name + "[type='" + item.Attributes["type"].Value + "']\")]";
                            FindsByClause = "CssSelector" + ";" + item.Name + "[type='" + item.Attributes["type"].Value + "']\")]";
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
                    InitVarName = "[FindsBy(How = How." + FindsBy + "\n";
                    //variableName = objPrefix + (item.Id != "" ? item.Id : item.Name)+(item.Attributes["value"]!= null?item.Attributes["value"].Value:"") ;

                    variablePrefix = "\tprivate IWebElement ";

                    variableName = row.Cells["clmControlName"].Value.ToString();




                    //uftObjPrefix = customList.customItems.ElementAt(i).uftVarName;
                    //Generate fillForm function 
                    valueSourceName = (dataGridView1.Rows[i].Cells["clmValueSource"].Value != null ? dataGridView1.Rows[i].Cells["clmValueSource"].Value.ToString() : "");

                    valueSource = " dt.Rows[0][\"" + valueSourceName + "\"].ToString()";
                    //In case item is ddl we choose from the selector 
                    SelectElement = "SelectElement " + row.Cells["clmControlName"].Value.ToString() + "Selector = new SelectElement(" + row.Cells["clmControlName"].Value.ToString() + ");";
                    FillFormFunction += "\t" + (ItemType != "DropDownList" ? variableName : SelectElement + "\n\t" + variableName + "Selector") + (ClickableItems ? ".Click();\n\t" : ItemType == "Text" ? ".SendKeys(" + valueSource + ");\n\t" : ItemType == "DropDownList" ? ".SelectByText(" + valueSource + ");\n\t" : "");

                    if (i < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[i + 1].Cells["clmControlName"].Value != null)
                    {
                        nextItemName = customList.customItems.ElementAt(i + 1).node;
                        FindsByClause = afgCore.GetIdentificationProperty(nextItemName);
                        if (FindsByClause != "")
                        {
                            //Capitilize the first character
                            IdentificationProperty = FindsByClause.Split(';')[0];
                            IdentificationProperty = IdentificationProperty.Replace(IdentificationProperty.ElementAt(0), IdentificationProperty.ElementAt(0).ToString().ToUpper().ToCharArray().ElementAt(0));
                            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id(txtMainFormusername.GetAttribute("id"))));
                            waitNextItem = "\t" + (ClickableItems || ItemType == "DropDownList" ? "wait.Until(ExpectedConditions.ElementIsVisible(By." + IdentificationProperty + "(\"" + FindsByClause.Split(';')[1] + "\")));" + "\n\t" : "");
                        }
                    }

                    FillFormFunction += waitNextItem;
                    //commentVarName = " '"+item.Name+ " "+ (item.Name != "select"?item.InnerText:"") + "\n";
                    objectNames += InitVarName + variablePrefix + (objectNames.Contains(variableName) ? (variableName + (r.Next().ToString())) : variableName) + ";";

                    objectNames += "\n\t";

                    if (item.Name == "select")
                    {
                        //SelectElement selector = new SelectElement(ddlMainFormissueType);
                        objectNames += "private SelectElement " + row.Cells["clmControlName"].Value.ToString() + "Selector = new SelectElement(" + row.Cells["clmControlName"].Value.ToString() + ");";
                    }
                    objectNames += "\n\t";
                    i++;
                }

                clsDef += objectNames //+ intializeMethodDef + webBrowserDef + itemAttributes + "\n" + "\tEnd Sub \n" + classTerminator +
                    +
                    FillFormFunction
                    +
                    " \n\t} \n\t} \n}";

                richTextBox1.Text += clsDef;

            }


            catch (Exception ex) { Console.WriteLine(ex.InnerException); }


        }

        public void FilterHTMLNodes()
        {
            //customList.customItems;


            foreach (object item in checkedListBox1.Items)
            {
                if (!checkedListBox1.CheckedItems.Contains(item))
                {

                    customList.customItems.RemoveAll(y => y.node.Name == item.ToString());

                }
            }
            //customList.customItems.AsEnumerable();
            //return items;
        }


        private void btnGenerateClasses_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            try
            {
                List<HtmlNode> newList1 = new List<HtmlNode>();

                //openFileDialog1.ShowDialog();
                if (htmlFileName == "" && onlineMode == false)
                {
                    MessageBox.Show("You have to choose one HTML file");
                    return;
                }

                GenerateClasses(htmlFileName, items);
                label3.Text = items.Count().ToString();
            }
            catch { }
        }

        private void AddLabelsToGrid()
        {

            string fileName = "";
            string ctrName = "";
            bool linkIsButton = false;
            fileName += (openFileDialog1.FileName != "" ? openFileDialog1.FileName : "");
            try
            {
                IEnumerable<HtmlNode> items = afgCore.GetItemsFromHTML(htmlFileName);
                int i = 0;

                foreach (var item in items)
                {

                    if ((item.Name == "label" || (item.Name == "td" && (item.Attributes["class"] != null ? item.Attributes["class"].Value == "label" : false))) && item.InnerText != "")
                    {
                        ctrName = afgCore.GetControlName(item);
                        dataGridView1.Rows[i].Cells[1].Value = afgCore.FormatLabels(item.InnerText);

                        i++;
                    }
                    else
                    {
                        linkIsButton = (item.Attributes["type"] != null ? item.Attributes["type"].Value == "button" : item.Attributes["class"] != null ? item.Attributes["class"].Value.Contains("btn") || item.Attributes["class"].Value.Contains("button") : false);
                        if (item.Name == "button" || linkIsButton)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = afgCore.FormatLabels(item.InnerText) + "Btn";

                            i++;
                        }

                    }

                }

            }
            catch { }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                string output = "";
                string fileName = "";
                string valueSrc = "";
                string idProperty = "";
                HtmlNode currentItem;
                fileName += (openFileDialog1.FileName != "" ? openFileDialog1.FileName : "");
                if (htmlFileName != "")
                {
                    ExcelUtiltiy excel = new ExcelUtiltiy();

                    // IEnumerable<HtmlNode> items = GetItemsFromHTML(htmlFileName);
                    int i = 1;
                    int j = 2;
                    int index = 0;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {

                        if (r.Cells[0].Value == null) break;

                        //Generate the id columns
                        idProperty = customList.customItems.ElementAt(i - 1).node.Attributes["id"] != null ? customList.customItems.ElementAt(i - 1).node.Attributes["id"].Value : "//xpath";
                        excel.addData(1, i, idProperty, "", "", "");
                        valueSrc = r.Cells["clmValueSource"].Value.ToString();
                        excel.addData(2, i, valueSrc, "", "", "");

                        //Get the corresponding elements associated with a select element
                        currentItem = customList.customItems.ElementAt(i - 1).node;

                        if (currentItem != null ? currentItem.ChildNodes != null ? currentItem.Name == "select" : false : false)
                        {
                            j = 1;
                            foreach (var subItem in currentItem.ChildNodes)
                            {
                                if (subItem.Name == "option")
                                {
                                    excel.addData(j + 2, i, subItem.InnerText, "", "", "");
                                    output += subItem.InnerText;
                                    j++;
                                }
                            }

                        }
                        i++;

                        output += currentItem.InnerText;
                        index++;
                    }

                    // richTextBox1.Text = output;
                    //excel.SaveExcelFile(@"Excel Pages\test.xlsx");
                }
                else
                {
                    MessageBox.Show("File not found");
                    return;
                }
            }
            catch { MessageBox.Show("File not found"); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string clsFileName = "";

                clsFileName = openFileDialog1.FileName.Split(new char[] { '\\' }).Last().Split(new char[] { '.' }).First();
                saveFileDialog1.FileName = clsFileName + ".qfl";
                saveFileDialog1.ShowDialog();

                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
            catch
            { }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (rdOffline.Checked == true)
            {

                openFileDialog1.ShowDialog();
                htmlFileName = (openFileDialog1.FileName != "" ? openFileDialog1.FileName : "");
                if (htmlFileName == "")
                {
                    MessageBox.Show("Please provide valid HTML file");
                }
                else
                {
                    txtURL.Text = htmlFileName;
                }

            }
        }
        private void AddNodesToGrid(string filePath, CustomHTMLNodeList uniqueItems)
        {
            List<string> FullDataTypeNames = new List<string>();
            List<MethodInfo> dataTypes = new List<MethodInfo>();

            IEnumerable<Type> classTypes;

            classTypes = afgCore.GetClassNamesInDll("Faker.dll");
            foreach (Type t in classTypes)
            {

                dataTypes = afgCore.GetDataGenerationTypes(t.Name + ", Faker.NET4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                foreach (MethodInfo s in dataTypes)
                {
                    FullDataTypeNames.Add(s.Name);
                }
            }

            object[] param = new object[10];

            int i = 0;
            try
            {

                Random r = new Random();
                //Members definition


                foreach (var item in uniqueItems.customItems)
                {
                    i++;

                    //variableName = objPrefix + objPrefixSpecialCase + ((item.Id != null ? (item.Id != "" ? item.Id : item.Name) : ""));
                    param[0] = item.varName;
                    //Add the same var name to the grid
                    param[1] = item.Caption;

                    param[5] = "Delete";

                    dataGridView1.Rows.Add(param);



                    foreach (Type s in classTypes)
                    {
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i - 1].Cells["clmDataClass"]).Items.Add(s.Name);
                    }

                    foreach (string s in FullDataTypeNames)
                    {
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i - 1].Cells["clmDataType"]).Items.Add(s);
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.InnerException); }
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                //openFileDialog1.ShowDialog();
                if (htmlFileName == "" && onlineMode == false)
                {
                    MessageBox.Show("You have to choose one HTML file");
                    return;
                }

                //Apply filters on your string
                if (chkRemoveHidden.Checked)
                {
                    customList.customItems = customList.customItems.Where(x => (x.node.Attributes["type"] != null ? (x.node.Attributes["type"].Value != "hidden") : true)).ToList();
                    customList.customItems = customList.customItems.Where(x => (x.node.Attributes["class"] != null ? (!x.node.Attributes["class"].Value.Contains("invissible")) : true)).ToList();
                }
                if (chkRemoveDuplicates.Checked)
                    afgCore.RemoveDuplicateItems(ref customList);

                AddNodesToGrid(htmlFileName, customList);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == this.dataGridView1.Columns["clmControlName"].Index) && e.Value != null)
                {
                    DataGridViewCell cell =
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = customList.customItems.ElementAt(e.RowIndex).node.OuterHtml;

                }
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    customList.customItems.RemoveAt(e.RowIndex);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //List<string> dataTypes = new List<string>();
                //string ClassType = "";
                //if (e.RowIndex < 0)
                //    return;
                //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["clmAutoGenerate"];

                //if (chk.Selected == false)
                //{
                //    dataGridView1.Rows[e.RowIndex].Cells["clmDataClass"].ReadOnly = true;
                //}
                //else
                //{
                //    dataGridView1.Rows[e.RowIndex].Cells["clmDataClass"].ReadOnly = false;
                //    ClassType = dataGridView1.Rows[e.RowIndex].Cells["clmDataClass"].Value.ToString();
                //    dataTypes = GetDataGenerationTypes(ClassType+", Faker.NET4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

                //    foreach (string s in dataTypes)
                //    {
                //        ((DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells["clmDataType"]).Items.Add(s);
                //    }

                //}
            }
            catch { }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;

            //dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["clmAutoGenerate"];

            //if (chk.Selected == false)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells["clmDataClass"].ReadOnly = true;
            //}
            //else
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells["clmDataClass"].ReadOnly = false;
            //}

        }

        private void btnGenerateSeleniumClasses_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            try
            {
                List<HtmlNode> newList1 = new List<HtmlNode>();

                //openFileDialog1.ShowDialog();
                if (htmlFileName == "" && onlineMode == false)
                {
                    MessageBox.Show("You have to choose one HTML file");
                    return;
                }

                GenerateSeleniumClasses(htmlFileName, items);
                label3.Text = items.Count().ToString();
            }
            catch { }
        }

        private void btnGenerateLeanFT_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            try
            {
                List<HtmlNode> newList1 = new List<HtmlNode>();

                //openFileDialog1.ShowDialog();
                if (htmlFileName == "" && onlineMode == false)
                {
                    MessageBox.Show("You have to choose one HTML file");
                    return;
                }

                GenerateLeanFTClasses(htmlFileName, items);
                label3.Text = items.Count().ToString();
            }
            catch { }
        }

        private void btnUFTToLeanFT_Click(object sender, EventArgs e)
        {
            string output = "";
            string finalOutput = "";
            string clsName = "";
            string clsDefinition = "using HP.LFT.SDK.Web;\nusing System.Data;\nnamespace Framework.TestFunctions\n{\n\tpublic class <clsName>\n\t{\npublic IBrowser testBrowser;";
            string clsConstructor = "public <clsName>(IBrowser bro)\n\t{\n\ttestBrowser = bro;\n";
            string output1 = "";
            string output2 = "";
            string eleType = "";

            string UFTFileText = File.ReadAllText(htmlFileName);

            Regex pattern1 = new Regex(@"(?:Class.)(?<clsName>.*)");
            Match match1 = pattern1.Match(UFTFileText);
            clsName = match1.Groups["clsName"].Value;

            char[] charsToTrim = { '\t', ' ', '\n' };
            UFTFileText = UFTFileText.Replace('\r', ';');
            foreach (string s in UFTFileText.Split(';'))
            {

                if (s.TrimStart(charsToTrim).StartsWith("Dim"))
                {
                    //output1 += GetLeanFTElementType(s.Trim(charsToTrim).Substring(4));
                    if (s.Trim(charsToTrim).Substring(4).StartsWith("txt"))
                    {
                        eleType = "IEditField";
                        output1 += s.Replace("Dim", "public " + eleType + " ");
                    }
                    else if (s.Trim(charsToTrim).Substring(4).StartsWith("ddl"))
                    {
                        eleType = "IListBox";
                        output1 += s.Replace("Dim", "public " + eleType + " ");
                    }
                    else if (s.Trim(charsToTrim).Substring(4).StartsWith("btn"))
                    {
                        eleType = "IButton";
                        output1 += s.Replace("Dim", "public " + eleType + " ");
                    }
                    else
                    {
                        eleType = "IWebElement";
                        output1 += s.Replace("Dim", "public " + eleType + " ");
                    }
                    output1 += ";";
                }

                string text = "";
                text = s + ";";

                //   Regex pattern = new Regex(@"(?<varName>\w+)Desc(?:.\"")(?<idenPropName>.*)(?:\""..Value.=.\"")(?<idenPropValue>.*)(?:\"");");

                Regex pattern = new Regex(@"(?<varName>\w+)Desc.*(?:.\"")(?<idenPropName>.*)(?:\"").*(?:alue.=.)(?<idenPropValue>.*)");

                Match match = pattern.Match(text);
                string varName = match.Groups["varName"].Value;
                string IdenPropName = match.Groups["idenPropName"].Value;


                if (IdenPropName == "html id")
                    IdenPropName = "Id";
                else
                {
                    //IdenPropName = IdenPropName.Replace(IdenPropName.ElementAt(0), IdenPropName.ElementAt(0).ToString().ToUpper()[0]);
                    //IdenPropName = IdenPropName.ElementAt(0).ToString().ToUpper() + IdenPropName.Substring(1);
                }
                string IdenPropValue = match.Groups["idenPropValue"].Value;
                if (varName != "")
                    output2 += varName + " = testBrowser.Describe<" + afgCore.GetLeanFTElementType(varName) + ">(new WebElementDescription\n\t{\n\t" + IdenPropName + " = \"" + IdenPropValue + "\",\n\t});\n";

            }
            clsDefinition = clsDefinition.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            clsConstructor = clsConstructor.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            finalOutput = clsDefinition + output1 + clsConstructor + output2 + "}\n}\n}";
            richTextBox1.Text = finalOutput;

        }

        private void btnUploadSrcCode_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            sourceCodeFilePath = (openFileDialog1.FileName != "" ? openFileDialog1.FileName : "");
            if (sourceCodeFilePath == "")
            {
                MessageBox.Show("Please provide valid Source file");
            }
            else
            {
                txtSrcCodeFileName.Text = sourceCodeFilePath;
            }
        }

        private void btnConvertCode_Click(object sender, EventArgs e)
        {
            try
            {
                char[] splitChars = { '\r', '\n' };
                string InputSrcCode = "";
                string OutputSrcCode = "";
                string OutputSrcCode2 = "";
                string OutputSrcCode3 = "";
                string line2 = "";


                string tobereplaced = "";
                InputSrcCode = File.ReadAllText(sourceCodeFilePath);
                Regex pattern1;
                Match match;
                //Replace the Browser prefix with the value from textBox

                string pattern = txtRegEx.Text;
                string replacement = txtAppModObjName.Text.Trim();
                Regex rgx = new Regex(pattern);

                OutputSrcCode = rgx.Replace(InputSrcCode, replacement);

                string pageName = "";
                string fullPagePattern = "";
                string[] srcCodeLines = OutputSrcCode.Split(splitChars);
                foreach (string line in srcCodeLines)
                {
                    // pattern = txtPageRegEx.Text;
                    if (line.ToLower().Contains("page(\""))
                    {
                        pattern1 = new Regex(txtPageRegEx.Text);
                        match = pattern1.Match(line);
                        replacement = match.Groups["pageName"].Value;


                        rgx = new Regex(txtFullPage.Text);
                        OutputSrcCode2 = rgx.Replace(line, replacement) + "\n";



                        pattern1 = new Regex(txtObjName.Text);
                        match = pattern1.Match(OutputSrcCode2);
                        replacement = match.Groups["objName"].Value;

                        rgx = new Regex(txtFullObj.Text);
                        match = rgx.Match(OutputSrcCode2);
                        tobereplaced = match.Groups["fullObjName"].Value;
                        if (tobereplaced != "" && replacement != "")
                            line2 = OutputSrcCode2.Replace(tobereplaced, replacement);

                        OutputSrcCode3 += line2 + "\n";
                    }


                }
                rtbPreviewCode.Text = OutputSrcCode3;
            }
            catch (Exception ex)
            {


            }
        }

        private void btnFromUFTToSelenium_Click(object sender, EventArgs e)
        {
            string finalOutput = "";
            string clsName = "";
            string clsDefinition = "using System;\nusing OpenQA.Selenium;\nusing OpenQA.Selenium.Support.PageObjects;\nusing System.Configuration;\nusing OpenQA.Selenium.Support.UI;\nusing System.Threading;\nusing Framework.CommonLib;\nusing System.Data;\nnamespace Framework.TestFunctions\n{\n\tpublic class <clsName>\n\t{\n\t";
            string clsConstructor = "public <clsName>()\n\t{\n\ttry\n\t{\n\t//Detault Waiting\n\tWebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings[\"Browser.DefaultTimeout\"])));\n\t";

            clsConstructor += "PageFactory.InitElements(GlobalVars.Test.Browser, this);\n\t";
            clsConstructor += "}\n\t";
            clsConstructor += "catch (Exception ex){}}\n\t";
            string output2 = "";

            string UFTFileText = File.ReadAllText(htmlFileName);

            Regex pattern1 = new Regex(@"(?:Class.)(?<clsName>.*)");
            Match match1 = pattern1.Match(UFTFileText);
            clsName = match1.Groups["clsName"].Value;

            char[] charsToTrim = { '\t', ' ', '\n' };
            UFTFileText = UFTFileText.Replace('\r', ';');
            foreach (string s in UFTFileText.Split(';'))
            {



                //         public ResourceManagment()
                //{
                //    try
                //    {
                //        //Default waiting 
                //        WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["Browser.DefaultTimeout"])));
                //        PageFactory.InitElements(GlobalVars.Test.Browser, this);

                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
                string text = "";
                text = s + ";";

                //   Regex pattern = new Regex(@"(?<varName>\w+)Desc(?:.\"")(?<idenPropName>.*)(?:\""..Value.=.\"")(?<idenPropValue>.*)(?:\"");");

                Regex pattern = new Regex(@"(?<varName>\w+)Desc.*(?:.\"")(?<idenPropName>.*)(?:\"").*(?:alue.=.)(?<idenPropValue>.*)");

                Match match = pattern.Match(text);
                string varName = match.Groups["varName"].Value;
                string IdenPropName = match.Groups["idenPropName"].Value;
                if (IdenPropName == "html id")
                    IdenPropName = "Id";
                if (IdenPropName == "html tag")
                    IdenPropName = "TagName";
                if (IdenPropName == "xpath")
                    IdenPropName = "XPath";
                if (IdenPropName == "class")
                    IdenPropName = "ClassName";

                string IdenPropValue = match.Groups["idenPropValue"].Value;
                IdenPropValue = IdenPropValue.Replace(";", "");
                if (varName != "")
                {
                    output2 += "[FindsBy(How = How." + IdenPropName + ",Using =" + IdenPropValue + ")]\n\t";
                    output2 += "private IWebElement " + varName + ";\n\t";
                }

            }
            clsDefinition = clsDefinition.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            clsConstructor = clsConstructor.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            finalOutput = clsDefinition + clsConstructor + output2 + "}\n}\n}";
            richTextBox1.Text = finalOutput;

        }

        private void btnLFTtoSelenium_Click(object sender, EventArgs e)
        {
            string finalOutput = "";
            string clsName = "";
            string clsDefinition = "using System;\nusing OpenQA.Selenium;\nusing OpenQA.Selenium.Support.PageObjects;\nusing System.Configuration;\nusing OpenQA.Selenium.Support.UI;\nusing System.Threading;\nusing Framework.CommonLib;\nusing System.Data;\nnamespace Framework.TestFunctions\n{\n\tpublic class <clsName>\n\t{\n\t";
            string clsConstructor = "public <clsName>()\n\t{\n\ttry\n\t{\n\t//Detault Waiting\n\tWebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings[\"Browser.DefaultTimeout\"])));\n\t";

            clsConstructor += "PageFactory.InitElements(GlobalVars.Test.Browser, this);\n\t";
            clsConstructor += "}\n\t";
            clsConstructor += "catch (Exception ex){}}\n\t";
            string output2 = "";

            string UFTFileText = File.ReadAllText(htmlFileName);

            Regex pattern1 = new Regex(@"(?:class.)(?<clsName>.*)");
            Match match1 = pattern1.Match(UFTFileText);
            clsName = match1.Groups["clsName"].Value;

            char[] charsToTrim = { '\t', ' ', '\n' };
            //UFTFileText = UFTFileText.Replace('\r', ';');
            // foreach (string s in UFTFileText.Split(';'))
            //{
            string text = "";
            // text = s + ";";
            //(?<varName>\w+).=.testBrowser.*WebElementDescription\n.*\n(?<idenPropName>.*)
            //Regex pattern = new Regex(@"(?<varName>\w+)Desc.*(?:.\"")(?<idenPropName>.*)(?:\"").*(?:alue.=.)(?<idenPropValue>.*)");
            string searchPattern ="";
            searchPattern = File.ReadAllText("Regex.txt");
            //  Regex pattern = new Regex(@"(?<varName>\w+).=.testBrowser.*WebElementDescription\n.*\n(?<idenPropName>.*\"")");
            MatchCollection matches = Regex.Matches(UFTFileText, searchPattern,RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string varName = match.Groups["varName"].Value;

                string IdenPropName = match.Groups["idenPropName"].Value;

                string[] props = IdenPropName.Split('=');

                if (IdenPropName == "html id")
                    IdenPropName = "Id";
                if (IdenPropName == "html tag")
                    IdenPropName = "TagName";
                if (IdenPropName == "xpath")
                    IdenPropName = "XPath";
                if (IdenPropName == "class")
                    IdenPropName = "ClassName";

                string IdenPropValue = match.Groups["idenPropValue"].Value;
                IdenPropValue = IdenPropValue.Replace(";", "");
                if (varName != "")
                {
                    output2 += "[FindsBy(How = How." + props[0] + ",Using =" + props[1] + ")]\n\t";
                    output2 += "private IWebElement " + varName + ";\n\t";
                }
                // match = match.NextMatch();
            }
            //}
            clsDefinition = clsDefinition.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            clsConstructor = clsConstructor.Replace("<clsName>", clsName.TrimEnd(charsToTrim));
            finalOutput = clsDefinition + clsConstructor + output2 + "}\n}\n}";
            richTextBox1.Text = finalOutput;
        }
    }
}
