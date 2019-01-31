namespace AFG
{
    partial class frmDesign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFromUFTToSelenium = new System.Windows.Forms.Button();
            this.btnUFTToLeanFT = new System.Windows.Forms.Button();
            this.btnGenerateSeleniumClasses = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmControlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValueSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAutoGenerate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmDataClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGenerateLeanFT = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnGenerateClasses = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRemoveDuplicates = new System.Windows.Forms.CheckBox();
            this.chkRemoveHidden = new System.Windows.Forms.CheckBox();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.rdOnline = new System.Windows.Forms.RadioButton();
            this.rdOffline = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtObjName = new System.Windows.Forms.TextBox();
            this.txtFullObj = new System.Windows.Forms.TextBox();
            this.txtFullPage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPageRegEx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.btnConvertCode = new System.Windows.Forms.Button();
            this.btnSaveCode = new System.Windows.Forms.Button();
            this.rtbPreviewCode = new System.Windows.Forms.RichTextBox();
            this.btnUploadSrcCode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSrcCodeFileName = new System.Windows.Forms.TextBox();
            this.txtAppModObjName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLFTtoSelenium = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1092, 720);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLFTtoSelenium);
            this.tabPage1.Controls.Add(this.btnFromUFTToSelenium);
            this.tabPage1.Controls.Add(this.btnUFTToLeanFT);
            this.tabPage1.Controls.Add(this.btnGenerateSeleniumClasses);
            this.tabPage1.Controls.Add(this.btnPreview);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnGenerateLeanFT);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Controls.Add(this.btnGenerateClasses);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1084, 694);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HTML Converters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFromUFTToSelenium
            // 
            this.btnFromUFTToSelenium.Location = new System.Drawing.Point(643, 415);
            this.btnFromUFTToSelenium.Name = "btnFromUFTToSelenium";
            this.btnFromUFTToSelenium.Size = new System.Drawing.Size(159, 23);
            this.btnFromUFTToSelenium.TabIndex = 26;
            this.btnFromUFTToSelenium.Text = "From UFT to Selenium";
            this.btnFromUFTToSelenium.UseVisualStyleBackColor = true;
            this.btnFromUFTToSelenium.Click += new System.EventHandler(this.btnFromUFTToSelenium_Click);
            // 
            // btnUFTToLeanFT
            // 
            this.btnUFTToLeanFT.Location = new System.Drawing.Point(478, 415);
            this.btnUFTToLeanFT.Name = "btnUFTToLeanFT";
            this.btnUFTToLeanFT.Size = new System.Drawing.Size(159, 23);
            this.btnUFTToLeanFT.TabIndex = 25;
            this.btnUFTToLeanFT.Text = "From UFT to LeanFT";
            this.btnUFTToLeanFT.UseVisualStyleBackColor = true;
            this.btnUFTToLeanFT.Click += new System.EventHandler(this.btnUFTToLeanFT_Click);
            // 
            // btnGenerateSeleniumClasses
            // 
            this.btnGenerateSeleniumClasses.Location = new System.Drawing.Point(311, 415);
            this.btnGenerateSeleniumClasses.Name = "btnGenerateSeleniumClasses";
            this.btnGenerateSeleniumClasses.Size = new System.Drawing.Size(159, 23);
            this.btnGenerateSeleniumClasses.TabIndex = 23;
            this.btnGenerateSeleniumClasses.Text = "Generate Selenium C# Script";
            this.btnGenerateSeleniumClasses.UseVisualStyleBackColor = true;
            this.btnGenerateSeleniumClasses.Click += new System.EventHandler(this.btnGenerateSeleniumClasses_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(14, 223);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmControlName,
            this.clmValueSource,
            this.clmAutoGenerate,
            this.clmDataClass,
            this.clmDataType,
            this.btnDelete});
            this.dataGridView1.Location = new System.Drawing.Point(14, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(656, 150);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // clmControlName
            // 
            this.clmControlName.HeaderText = "ControlName";
            this.clmControlName.Name = "clmControlName";
            // 
            // clmValueSource
            // 
            this.clmValueSource.HeaderText = "ParameterName";
            this.clmValueSource.Name = "clmValueSource";
            // 
            // clmAutoGenerate
            // 
            this.clmAutoGenerate.HeaderText = "AutoGenerate";
            this.clmAutoGenerate.Name = "clmAutoGenerate";
            this.clmAutoGenerate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAutoGenerate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAutoGenerate.TrueValue = "Auto";
            this.clmAutoGenerate.Visible = false;
            // 
            // clmDataClass
            // 
            this.clmDataClass.DataPropertyName = "Name";
            this.clmDataClass.HeaderText = "DataClass";
            this.clmDataClass.Name = "clmDataClass";
            this.clmDataClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDataClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmDataClass.Visible = false;
            // 
            // clmDataType
            // 
            this.clmDataType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clmDataType.HeaderText = "ValueType";
            this.clmDataType.Name = "clmDataType";
            this.clmDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmDataType.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnGenerateLeanFT
            // 
            this.btnGenerateLeanFT.Location = new System.Drawing.Point(144, 415);
            this.btnGenerateLeanFT.Name = "btnGenerateLeanFT";
            this.btnGenerateLeanFT.Size = new System.Drawing.Size(159, 23);
            this.btnGenerateLeanFT.TabIndex = 24;
            this.btnGenerateLeanFT.Text = "Generate LeanFT Script";
            this.btnGenerateLeanFT.UseVisualStyleBackColor = true;
            this.btnGenerateLeanFT.Click += new System.EventHandler(this.btnGenerateLeanFT_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(456, 671);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 441);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1076, 224);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(937, 415);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(143, 23);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Generate Excel Sheet";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnGenerateClasses
            // 
            this.btnGenerateClasses.Location = new System.Drawing.Point(14, 415);
            this.btnGenerateClasses.Name = "btnGenerateClasses";
            this.btnGenerateClasses.Size = new System.Drawing.Size(123, 23);
            this.btnGenerateClasses.TabIndex = 17;
            this.btnGenerateClasses.Text = "Generate QTP Script";
            this.btnGenerateClasses.UseVisualStyleBackColor = true;
            this.btnGenerateClasses.Click += new System.EventHandler(this.btnGenerateClasses_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRemoveDuplicates);
            this.groupBox1.Controls.Add(this.chkRemoveHidden);
            this.groupBox1.Controls.Add(this.btnUploadFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnApplyFilter);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.rdOnline);
            this.groupBox1.Controls.Add(this.rdOffline);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 217);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // chkRemoveDuplicates
            // 
            this.chkRemoveDuplicates.AutoSize = true;
            this.chkRemoveDuplicates.Checked = true;
            this.chkRemoveDuplicates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveDuplicates.Location = new System.Drawing.Point(246, 188);
            this.chkRemoveDuplicates.Name = "chkRemoveDuplicates";
            this.chkRemoveDuplicates.Size = new System.Drawing.Size(142, 17);
            this.chkRemoveDuplicates.TabIndex = 13;
            this.chkRemoveDuplicates.Text = "Remove Duplicate Items";
            this.chkRemoveDuplicates.UseVisualStyleBackColor = true;
            // 
            // chkRemoveHidden
            // 
            this.chkRemoveHidden.AutoSize = true;
            this.chkRemoveHidden.Checked = true;
            this.chkRemoveHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveHidden.Location = new System.Drawing.Point(72, 188);
            this.chkRemoveHidden.Name = "chkRemoveHidden";
            this.chkRemoveHidden.Size = new System.Drawing.Size(131, 17);
            this.chkRemoveHidden.TabIndex = 12;
            this.chkRemoveHidden.Text = "Remove Hidden Items";
            this.chkRemoveHidden.UseVisualStyleBackColor = true;
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(604, 114);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 14;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 10;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(775, 172);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(123, 23);
            this.btnApplyFilter.TabIndex = 9;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(680, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(364, 154);
            this.checkedListBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Of Objects:";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(213, 143);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Enabled = false;
            this.txtURL.Location = new System.Drawing.Point(97, 117);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(501, 20);
            this.txtURL.TabIndex = 2;
            // 
            // rdOnline
            // 
            this.rdOnline.AutoSize = true;
            this.rdOnline.Location = new System.Drawing.Point(51, 84);
            this.rdOnline.Name = "rdOnline";
            this.rdOnline.Size = new System.Drawing.Size(116, 17);
            this.rdOnline.TabIndex = 1;
            this.rdOnline.Text = "Online HTML Page";
            this.rdOnline.UseVisualStyleBackColor = true;
            // 
            // rdOffline
            // 
            this.rdOffline.AutoSize = true;
            this.rdOffline.Checked = true;
            this.rdOffline.Location = new System.Drawing.Point(52, 40);
            this.rdOffline.Name = "rdOffline";
            this.rdOffline.Size = new System.Drawing.Size(116, 17);
            this.rdOffline.TabIndex = 0;
            this.rdOffline.TabStop = true;
            this.rdOffline.Text = "Offline HTML Page";
            this.rdOffline.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtObjName);
            this.tabPage2.Controls.Add(this.txtFullObj);
            this.tabPage2.Controls.Add(this.txtFullPage);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtPageRegEx);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtRegEx);
            this.tabPage2.Controls.Add(this.btnConvertCode);
            this.tabPage2.Controls.Add(this.btnSaveCode);
            this.tabPage2.Controls.Add(this.rtbPreviewCode);
            this.tabPage2.Controls.Add(this.btnUploadSrcCode);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtSrcCodeFileName);
            this.tabPage2.Controls.Add(this.txtAppModObjName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1084, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Code Converters";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtObjName
            // 
            this.txtObjName.Location = new System.Drawing.Point(849, 115);
            this.txtObjName.Name = "txtObjName";
            this.txtObjName.Size = new System.Drawing.Size(133, 20);
            this.txtObjName.TabIndex = 29;
            this.txtObjName.Text = "(?:\\w+\\.\\w+\\.\\w+\\(\")(?<objName>\\w+)";
            // 
            // txtFullObj
            // 
            this.txtFullObj.Location = new System.Drawing.Point(849, 89);
            this.txtFullObj.Name = "txtFullObj";
            this.txtFullObj.Size = new System.Drawing.Size(133, 20);
            this.txtFullObj.TabIndex = 28;
            this.txtFullObj.Text = "(?:\\w+\\.\\w+\\.)(?<fullObjName>\\w+\\(\"\\w+\"\\))";
            // 
            // txtFullPage
            // 
            this.txtFullPage.Location = new System.Drawing.Point(849, 63);
            this.txtFullPage.Name = "txtFullPage";
            this.txtFullPage.Size = new System.Drawing.Size(133, 20);
            this.txtFullPage.TabIndex = 27;
            this.txtFullPage.Text = "[P|p]age\\(\"\\w+\"\\)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(779, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "PageRegEx";
            // 
            // txtPageRegEx
            // 
            this.txtPageRegEx.Location = new System.Drawing.Point(849, 37);
            this.txtPageRegEx.Name = "txtPageRegEx";
            this.txtPageRegEx.Size = new System.Drawing.Size(133, 20);
            this.txtPageRegEx.TabIndex = 25;
            this.txtPageRegEx.Text = "(?:[P|p]age.\")(?<pageName>\\w+)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "BrowserRegEx";
            // 
            // txtRegEx
            // 
            this.txtRegEx.Location = new System.Drawing.Point(616, 38);
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.Size = new System.Drawing.Size(133, 20);
            this.txtRegEx.TabIndex = 23;
            this.txtRegEx.Text = "[B|b]rowser\\(\"\\w+\"\\)";
            // 
            // btnConvertCode
            // 
            this.btnConvertCode.Location = new System.Drawing.Point(457, 220);
            this.btnConvertCode.Name = "btnConvertCode";
            this.btnConvertCode.Size = new System.Drawing.Size(109, 22);
            this.btnConvertCode.TabIndex = 22;
            this.btnConvertCode.Text = "Convert Code";
            this.btnConvertCode.UseVisualStyleBackColor = true;
            this.btnConvertCode.Click += new System.EventHandler(this.btnConvertCode_Click);
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.Location = new System.Drawing.Point(447, 651);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCode.TabIndex = 21;
            this.btnSaveCode.Text = "Save";
            this.btnSaveCode.UseVisualStyleBackColor = true;
            // 
            // rtbPreviewCode
            // 
            this.rtbPreviewCode.Location = new System.Drawing.Point(6, 278);
            this.rtbPreviewCode.Name = "rtbPreviewCode";
            this.rtbPreviewCode.Size = new System.Drawing.Size(1072, 367);
            this.rtbPreviewCode.TabIndex = 18;
            this.rtbPreviewCode.Text = "";
            // 
            // btnUploadSrcCode
            // 
            this.btnUploadSrcCode.Location = new System.Drawing.Point(760, 176);
            this.btnUploadSrcCode.Name = "btnUploadSrcCode";
            this.btnUploadSrcCode.Size = new System.Drawing.Size(63, 23);
            this.btnUploadSrcCode.TabIndex = 17;
            this.btnUploadSrcCode.Text = "...";
            this.btnUploadSrcCode.Click += new System.EventHandler(this.btnUploadSrcCode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Source Code File";
            // 
            // txtSrcCodeFileName
            // 
            this.txtSrcCodeFileName.Enabled = false;
            this.txtSrcCodeFileName.Location = new System.Drawing.Point(253, 179);
            this.txtSrcCodeFileName.Name = "txtSrcCodeFileName";
            this.txtSrcCodeFileName.Size = new System.Drawing.Size(501, 20);
            this.txtSrcCodeFileName.TabIndex = 15;
            // 
            // txtAppModObjName
            // 
            this.txtAppModObjName.Location = new System.Drawing.Point(253, 41);
            this.txtAppModObjName.Name = "txtAppModObjName";
            this.txtAppModObjName.Size = new System.Drawing.Size(250, 20);
            this.txtAppModObjName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "App Model Obj Name";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLFTtoSelenium
            // 
            this.btnLFTtoSelenium.Location = new System.Drawing.Point(808, 415);
            this.btnLFTtoSelenium.Name = "btnLFTtoSelenium";
            this.btnLFTtoSelenium.Size = new System.Drawing.Size(123, 23);
            this.btnLFTtoSelenium.TabIndex = 27;
            this.btnLFTtoSelenium.Text = "From LFT to Selenium";
            this.btnLFTtoSelenium.UseVisualStyleBackColor = true;
            this.btnLFTtoSelenium.Click += new System.EventHandler(this.btnLFTtoSelenium_Click);
            // 
            // frmDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 733);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDesign";
            this.Text = "Automation Script Generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rdOffline;
        private System.Windows.Forms.RadioButton rdOnline;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.CheckBox chkRemoveHidden;
        private System.Windows.Forms.CheckBox chkRemoveDuplicates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerateClasses;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGenerateLeanFT;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmDataType;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmDataClass;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAutoGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValueSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmControlName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnGenerateSeleniumClasses;
        private System.Windows.Forms.Button btnUFTToLeanFT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveCode;
        private System.Windows.Forms.RichTextBox rtbPreviewCode;
        private System.Windows.Forms.Button btnUploadSrcCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSrcCodeFileName;
        private System.Windows.Forms.TextBox txtAppModObjName;
        private System.Windows.Forms.Button btnConvertCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegEx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPageRegEx;
        private System.Windows.Forms.TextBox txtFullPage;
        private System.Windows.Forms.TextBox txtObjName;
        private System.Windows.Forms.TextBox txtFullObj;
        private System.Windows.Forms.Button btnFromUFTToSelenium;
        private System.Windows.Forms.Button btnLFTtoSelenium;
    }
}