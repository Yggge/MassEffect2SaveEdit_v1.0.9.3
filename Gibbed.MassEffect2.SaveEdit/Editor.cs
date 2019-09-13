using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Gibbed.MassEffect2.SaveEdit
{
    public partial class Editor : Form
    {
        private FileFormats.SaveFile SaveFile
        {
            get { return (FileFormats.SaveFile)this.rawPropertyGrid.SelectedObject; }
            set
            {
                this.rawPropertyGrid.SelectedObject = value;
                this.saveFileBindingSource.DataSource = value;
            }
        }

        //private AppearanceGrid PlayerAppearanceGrid
        //{
        //    get { return (AppearanceGrid)this.playerAppearanceGrid.SelectedObject; }
        //    set { this.playerAppearanceGrid.SelectedObject = value; }
        //}

        //private FileFormats.Save.Appearance PlayerAppearance
        //{
        //    get
        //    {
        //        return (FileFormats.Save.Appearance)this.appearancePropertyGrid.SelectedObject;
        //    }
        //    set
        //    {
        //        this.appearancePropertyGrid.SelectedObject = value;
        //    }
        //}

        private List<CheckedListBox> PlotLists = new List<CheckedListBox>();
        private List<NumericUpDown> PlotNumerics = new List<NumericUpDown>();

        private string titleText;

        public Editor()
        {
            this.InitializeComponent();
            this.titleText = String.Format("Mass Effect 2 Save Editor [PC/Xbox] (v{0})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = this.titleText;

            string savePath;
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            savePath = Path.Combine(savePath, "BioWare");
            savePath = Path.Combine(savePath, "Mass Effect 2");
            savePath = Path.Combine(savePath, "Save");

            if (Directory.Exists(savePath) == true)
            {
                this.openFileDialog.InitialDirectory = savePath;
                this.saveFileDialog.InitialDirectory = savePath;
            }

            this.AddPlotEditors();

            this.playerPlayerClassNameComboBox.ValueMember = "Type";
            this.playerPlayerClassNameComboBox.DisplayMember = "Name";
            this.playerPlayerClassNameComboBox.DataSource = PlayerClass.GetClasses();

            this.playerOriginComboBox.ValueMember = "Type";
            this.playerOriginComboBox.DisplayMember = "Name";
            this.playerOriginComboBox.DataSource = PlayerOrigin.GetOrigins();

            this.playerNotorietyComboBox.ValueMember = "Type";
            this.playerNotorietyComboBox.DisplayMember = "Name";
            this.playerNotorietyComboBox.DataSource = PlayerNotoriety.GetNotorieties();

            this.playerGenderComboBox.ValueMember = "Type";
            this.playerGenderComboBox.DisplayMember = "Name";
            this.playerGenderComboBox.DataSource = PlayerGender.GetGenders();

            this.comboBox_ToolboxHeadMorphFunType.SelectedIndex = 0;

            // load default male on startup
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            this.LoadSaveFromStream(memory);
            memory.Close();
        }

        private void AddPlotEditors() {
            var reader = new StringReader(Properties.Resources.Plots);
            var doc = new XPathDocument(reader);
            var nav = doc.CreateNavigator();

            List<int> me1FlagIds = new List<int>();
            List<int> me2FlagIds = new List<int>();
            List<int> me1ValueIds = new List<int>();
            List<int> me2ValueIds = new List<int>();

            var categories = nav.Select("/categories/category");
            while (categories.MoveNext() == true) {
                string category = categories.Current.GetAttribute("name", "");
                string slegacy = categories.Current.GetAttribute("legacy", "");
                bool legacy = slegacy == "" ? false : bool.Parse(slegacy);

                bool multicolumn = false;

                var notes = categories.Current.SelectSingleNode("notes");
                List<Plot> flags = new List<Plot>();
                List<Plot> values = new List<Plot>();

                // bools
                var bools = categories.Current.SelectSingleNode("bools");
                if (bools != null) {
                    string smulticolumn = bools.GetAttribute("multicolumn", "");
                    multicolumn = smulticolumn == "" ? true : bool.Parse(smulticolumn);

                    var plots = bools.Select("plot");
                    while (plots.MoveNext() == true) {
                        int id = int.Parse(plots.Current.GetAttribute("id", ""));

                        if (legacy == true && me1FlagIds.Contains(id) == true) {
                            throw new Exception();
                        } else if (legacy == false && me2FlagIds.Contains(id) == true) {
                            throw new Exception();
                        }

                        flags.Add(new Plot(id, plots.Current.Value.Trim(), legacy));

                        if (legacy == true) {
                            me1FlagIds.Add(id);
                        } else {
                            me2FlagIds.Add(id);
                        }
                    }
                }

                // ints
                var ints = categories.Current.SelectSingleNode("ints");
                if (ints != null) {
                    var plots = ints.Select("plot");
                    while (plots.MoveNext() == true) {
                        int id = int.Parse(plots.Current.GetAttribute("id", ""));

                        if (legacy == true && me1ValueIds.Contains(id) == true) {
                            throw new Exception();
                        } else if (legacy == false && me2ValueIds.Contains(id) == true) {
                            throw new Exception();
                        }

                        values.Add(new Plot(id, plots.Current.Value.Trim(), legacy));

                        if (legacy == true) {
                            me1ValueIds.Add(id);
                        } else {
                            me2ValueIds.Add(id);
                        }
                    }
                }

                if (notes != null || flags.Count > 0 || values.Count > 0) {
                    TabPage masterTabPage = new TabPage();
                    masterTabPage.Text = category;
                    masterTabPage.UseVisualStyleBackColor = true;
                    this.plotTabControl.TabPages.Add(masterTabPage);

                    TabControl masterTabControl = new TabControl();
                    masterTabControl.Dock = DockStyle.Fill;
                    masterTabPage.Controls.Add(masterTabControl);

                    if (notes != null) {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Notes";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        TextBox textBox = new TextBox();
                        textBox.Dock = DockStyle.Fill;
                        textBox.Multiline = true;
                        textBox.Text = notes.Value.Trim();
                        tabPage.Controls.Add(textBox);
                    }

                    if (flags.Count > 0) {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Flags";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        CheckedListBox listBox = new CheckedListBox();
                        listBox.Dock = DockStyle.Fill;
                        listBox.MultiColumn = multicolumn;
                        listBox.ColumnWidth = 225;
                        listBox.Sorted = true;
                        listBox.ItemCheck += this.OnPlotFlagChange;
                        listBox.IntegralHeight = false;

                        foreach (var plot in flags) {
                            listBox.Items.Add(plot);
                        }

                        this.PlotLists.Add(listBox);
                        tabPage.Controls.Add(listBox);
                    }

                    if (values.Count > 0) {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Values";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                        tableLayoutPanel.Dock = DockStyle.Fill;

                        tableLayoutPanel.ColumnCount = 2;
                        tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
                        tableLayoutPanel.RowCount = values.Count + 1;

                        foreach (var value in values) {
                            Label label = new Label();
                            label.Text = value.Name + ":";
                            label.Dock = DockStyle.Fill;
                            label.AutoSize = true;
                            label.TextAlign = ContentAlignment.MiddleRight;
                            tableLayoutPanel.Controls.Add(label);

                            // I am a terrible person and this is a terrible
                            // way to do it. BUT OH WELL :)
                            NumericUpDown numericUpDown = new NumericUpDown();
                            numericUpDown.Minimum = int.MinValue;
                            numericUpDown.Maximum = int.MaxValue;
                            numericUpDown.Increment = 1;
                            numericUpDown.Tag = value;
                            numericUpDown.ValueChanged += this.OnPlotValueChange;
                            tableLayoutPanel.Controls.Add(numericUpDown);

                            this.PlotNumerics.Add(numericUpDown);
                        }

                        tabPage.Controls.Add(tableLayoutPanel);
                    }

                    if (legacy == true) {
                        Label label = new Label();
                        label.Dock = DockStyle.Bottom;
                        label.AutoSize = true;
                        label.Text = "Editing these values will only affect anything if you import this save as a new game.";
                        masterTabPage.Controls.Add(label);
                    }
                }
            }

            reader.Close();
        }

        private void UpdatePlotEditors()
        {
            foreach (var list in this.PlotLists)
            {
                for (int i = 0; i < list.Items.Count; i++)
                {
                    var plot = list.Items[i] as Plot;
                    if (plot == null)
                    {
                        continue;
                    }

                    bool value;

                    if (plot.Legacy == false)
                    {
                        value = this.SaveFile.ME2PlotRecord.GetBoolVariable(plot.Id);
                    }
                    else
                    {
                        value = this.SaveFile.ME1PlotRecord.GetBoolVariable(plot.Id);
                    }

                    list.SetItemChecked(i, value);
                }
            }

            foreach (var numericUpDown in this.PlotNumerics)
            {
                var plot = numericUpDown.Tag as Plot;
                if (plot == null)
                {
                    continue;
                }

                if (plot.Legacy == false)
                {
                    numericUpDown.Value = this.SaveFile.ME2PlotRecord.GetIntVariable(plot.Id);
                }
                else
                {
                    numericUpDown.Value = this.SaveFile.ME1PlotRecord.GetIntVariable(plot.Id);
                }
            }
        }

        private void OnPlotFlagChange(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox list = sender as CheckedListBox;

            if (list == null)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            Plot plot = list.Items[e.Index] as Plot;

            if (plot == null)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            if (plot.Legacy == true)
            {
                this.SaveFile.ME1PlotRecord.SetBoolVariable(plot.Id, e.NewValue == CheckState.Checked);
            }
            else
            {
                this.SaveFile.ME2PlotRecord.SetBoolVariable(plot.Id, e.NewValue == CheckState.Checked);
            }
        }

        private void OnPlotValueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            if (numericUpDown == null)
            {
                return;
            }

            Plot plot = numericUpDown.Tag as Plot;

            if (plot == null)
            {
                return;
            }

            if (plot.Legacy == true)
            {
                this.SaveFile.ME1PlotRecord.SetIntVariable(plot.Id, (int)numericUpDown.Value);
            }
            else
            {
                this.SaveFile.ME2PlotRecord.SetIntVariable(plot.Id, (int)numericUpDown.Value);
            }
        }

        //Synchronize all PropertyGrids
        private void syncAllPropertyGrids(object sender, EventArgs e) {
            this.rawPropertyGrid.Refresh();           //.Validate(false);
            this.appearancePropertyGrid.Refresh();    //.Validate();
            this.playerAppearanceGrid.Refresh();
        }

        // Summary:
        //  Decide if the Endian-ness of the stream needs to be swapped and set
        //  the state in the StreamHelpers. Decision based on file extension.
        //  Default assumes Little Endian stream.
        private void SetStreamSwapState(string fileExtension) {
            if (fileExtension.Equals(".xbsav", StringComparison.OrdinalIgnoreCase)) {
                Helpers.StreamHelpers.forceBigEndian = true;
            } else if (fileExtension.Equals(".pcsav", StringComparison.OrdinalIgnoreCase)) {
                Helpers.StreamHelpers.forceBigEndian = false;
            } else if (fileExtension.Equals(".me2headmorph", StringComparison.OrdinalIgnoreCase)) {
                // Always store HeadMorphs in Little Endian so they are compatible.
                Helpers.StreamHelpers.forceBigEndian = false;
            } else {
                MessageBox.Show(
                    "File extension not recognized. Assuming .pcsav file (Little-Endian).",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Helpers.StreamHelpers.forceBigEndian = false;
            }
        }

        private void LoadSaveFromStream(Stream stream)
        {
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(stream);
            this.SaveFile = saveFile;
            //this.PlayerAppearance = this.SaveFile.PlayerRecord.Appearance;
            //this.playerAppearanceGrid.SaveFile = saveFile;
            this.playerSkillsGrid.SaveFile = saveFile;
            this.UpdatePlotEditors();
        }

        private void OnNewMale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            this.SetStreamSwapState(".pcsav");  // Default saves are Little-Endian pcsav's
            this.LoadSaveFromStream(memory);
            this.Text = String.Format("{0} - {1}", this.titleText, "Default_Male.pcsav");
            this.saveFileDialog.FilterIndex = 1;
            this.saveFileDialog.FileName = "Default_Male.pcsav";
            memory.Close();
        }

        private void OnNewFemale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultFemale);
            this.SetStreamSwapState(".pcsav");  // Default saves are Little-Endian pcsav's
            this.LoadSaveFromStream(memory);
            this.Text = String.Format("{0} - {1}", this.titleText, "Default_Female.pcsav");
            this.saveFileDialog.FilterIndex = 1;
            this.saveFileDialog.FileName = "Default_Female.pcsav";
            memory.Close();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            this.openFileDialog.Title = "Open";
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FileInfo file = new FileInfo(this.openFileDialog.FileName);
            Stream input = file.Open(FileMode.Open);
            this.SetStreamSwapState(Path.GetExtension(file.Name));
            this.openFileDialog.InitialDirectory = file.DirectoryName;
            this.openFileDialog.FileName = file.Name;

            try {
                this.LoadSaveFromStream(input);
                this.Text = String.Format("{0} - {1}", this.titleText, file.Name);
                this.saveFileDialog.InitialDirectory = file.DirectoryName;
                this.saveFileDialog.FilterIndex = (file.Extension == ".xbsav") ? 2 : 1;
                this.saveFileDialog.FileName = file.Name;

                this.EasterEgg();
            } catch (FormatException ex) {
                if (ex.Message.Equals("byte order swapped")) {
                    if (MessageBox.Show(
                            String.Format(
                            "The file you are loading seems to have the byte order swapped from what is expected. " +
                            "It matches the expected save version if we swap Endian-ness.\n\n" +
                            "Is it possible the file extension is wrong? .pcsav files are expected to be in little-" +
                            "endian format, and .xbsav files to be in big-endian format. Any other extension is " +
                            "assumed to be little-endian like the .pcsav files.\n\n" +
                            "It is probably safe to proceed, however please backup anything important first.\n\n" +
                            "Proceed with the import by swapping byte order (Endian-ness)?"),
                            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        // We will try to proceed by swapping Endian-ness and re-reading
                        Helpers.StreamHelpers.forceBigEndian = !Helpers.StreamHelpers.forceBigEndian;
                        input.Position = 0L;
                        this.LoadSaveFromStream(input);
                        this.Text = String.Format("{0} - {1}", this.titleText, file.Name);
                        this.saveFileDialog.InitialDirectory = file.DirectoryName;
                        this.saveFileDialog.FilterIndex = (file.Extension == ".xbsav") ? 2 : 1;
                        this.saveFileDialog.FileName = file.Name;

                        this.EasterEgg();
                    } else
                        return;
                } else {
                    MessageBox.Show("Unhandled Exception: \n" + ex.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } finally {
                input.Close();
            }
        }

        private void OnSave(object sender, EventArgs e) {
            this.saveFileDialog.Title = "Save As";
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            FileInfo file = new FileInfo(this.saveFileDialog.FileName);
            Stream output = file.Open(FileMode.Create, FileAccess.Write, FileShare.None);
            this.saveFileDialog.InitialDirectory = file.DirectoryName;
            this.saveFileDialog.FileName = file.Name;
            this.SetStreamSwapState(Path.GetExtension(file.Name));

            this.SaveFile.Save(output);
            output.Close();

            this.EasterEgg();
        }

        private void OnCompare(object sender, EventArgs e) {
            StringBuilder stringBuilder = new StringBuilder();
            FileFormats.SaveFile[] saves = new FileFormats.SaveFile[2];
            for (int i = 0; i < saves.Length; ++i) {
                this.openFileDialog.Title = "Compare";
                if (this.openFileDialog.ShowDialog() != DialogResult.OK) {
                    return;
                }
                FileInfo file = new FileInfo(this.openFileDialog.FileName);
                Stream input = file.Open(FileMode.Open);
                this.SetStreamSwapState(Path.GetExtension(file.Name));
                this.openFileDialog.InitialDirectory = file.DirectoryName;
                this.openFileDialog.FileName = file.Name;
                stringBuilder.AppendFormat("{0} {1}\n", file.FullName, file.LastWriteTime);

                try {
                    saves[i] = FileFormats.SaveFile.Load(input);
                } catch (FormatException ex) {
                    if (ex.Message.Equals("byte order swapped")) {
                        if (MessageBox.Show(
                                String.Format(
                                "The file you are loading seems to have the byte order swapped from what is expected. " +
                                "It matches the expected save version if we swap Endian-ness.\n\n" +
                                "Is it possible the file extension is wrong? .pcsav files are expected to be in little-" +
                                "endian format, and .xbsav files to be in big-endian format. Any other extension is " +
                                "assumed to be little-endian like the .pcsav files.\n\n" +
                                "It is probably safe to proceed, however please backup anything important first.\n\n" +
                                "Proceed with the import by swapping byte order (Endian-ness)?"),
                                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            // We will try to proceed by swapping Endian-ness and re-reading
                            Helpers.StreamHelpers.forceBigEndian = !Helpers.StreamHelpers.forceBigEndian;
                            input.Position = 0L;
                            saves[i] = FileFormats.SaveFile.Load(input);
                        } else
                            return;
                    } else {
                        MessageBox.Show("Unhandled Exception: \n" + ex.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                } finally {
                    input.Close();
                }
            }

            Type[] validTypes = new Type[] { typeof(uint), typeof(bool), typeof(byte), typeof(int), typeof(string), typeof(float), typeof(Guid) };
            HashSet<object> processed = new HashSet<object>();
            FileFormats.SaveFile.CompareObjects(saves[0], saves[1], "", validTypes, processed, stringBuilder);
            File.WriteAllText(Application.StartupPath + "/compare_result.txt", stringBuilder.ToString());
            MessageBox.Show("Raw compare results were saved to \"compare_result.txt\"", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnHeadMorphDelete(object sender, EventArgs e) {
            if (MessageBox.Show(
                    String.Format(
                    "Are you sure you want to delete your custom head morph.\n" +
                    "This will give your character the default appearance."),
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.SaveFile.DeleteHeadMorph();
            } else
                return;
        }

        private void OnHeadMorphImport(object sender, EventArgs e) {
            this.importHeadMorphDialog.Title = "Import";
            if (this.importHeadMorphDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            FileInfo file = new FileInfo(this.importHeadMorphDialog.FileName);
            Stream input = file.Open(FileMode.Open);
            this.SetStreamSwapState(Path.GetExtension(file.Name));
            this.importHeadMorphDialog.InitialDirectory = file.DirectoryName;
            this.importHeadMorphDialog.FileName = file.Name;

            try {
                this.SaveFile.LoadHeadMorph(input, false);
                this.exportHeadMorphDialog.InitialDirectory = file.DirectoryName;
                this.exportHeadMorphDialog.FileName = file.Name;
            } catch (FormatException ex) {
                if (ex.Message.Equals("no valid headmorph file")) {
                    MessageBox.Show(
                        "The selected file does not appear to be a valid head morph.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (ex.Message.Equals("unsupported headmorph version")) {
                    MessageBox.Show(
                        "Unsupported head morph version.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (ex.Message.Equals("byte order swapped")) {
                    if (MessageBox.Show(
                            String.Format(
                            "The head morph you are importing seems to have the byte order swapped from what is expected." +
                            "It matches the expected save version if we swap Endian-ness.\n\n" +
                            "This is a known problem with earlier saved Headmorphs for the " +
                            "Xbox. Now Headmorphs are all saved in pc-style format so they should be " +
                            "interchangeable between the pc and the Xbox.\n" +
                            "It is probably safe to proceed, however please backup anything important first.\n\n" +
                            "Proceed with the import by swapping byte order (Endian-ness)?"),
                            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        // We will try to proceed by swapping Endian-ness and re-reading
                        Helpers.StreamHelpers.forceBigEndian = !Helpers.StreamHelpers.forceBigEndian;
                        input.Position = 0L;
                        this.SaveFile.LoadHeadMorph(input, false);
                    } else
                        return;
                } else if (ex.Message.Equals("unsupported save version")) {
                    if (MessageBox.Show(
                            String.Format(
                            "The head morph you are importing has a different " +
                            "version than your current save file.\n\n" +
                            "Import anyway?"),
                            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        input.Position = 0L;
                        this.SaveFile.LoadHeadMorph(input, true);
                    } else
                        return;
                }else if (ex.Message.Equals("no custom headmorph present")) {
                    MessageBox.Show(
                        String.Format(
                        "This is a partial head morph import. You need an existing non-default " + 
                        "head morph for this to work."),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else {
                    MessageBox.Show("Unhandled Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } finally {
                input.Close();
            }
        }

        private void OnHeadMorphFullExport(object sender, EventArgs e) {
            HeadMorphExportDialog(0);
        }

        private void OnHeadMorphLOD0Export(object sender, EventArgs e) {
            HeadMorphExportDialog(1);
        }

        private void OnHeadMorphCosmeticsExport(object sender, EventArgs e) {
            HeadMorphExportDialog(2);
        }

        private void HeadMorphExportDialog(byte type) {
            if (this.SaveFile.PlayerRecord.Appearance.HasMorphHead == false || this.SaveFile.PlayerRecord.Appearance.MorphHead == null) {
                MessageBox.Show(
                    "This save does not have a non-default head morph.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.exportHeadMorphDialog.Title = "Export";
            if (this.exportHeadMorphDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            FileInfo file = new FileInfo(this.exportHeadMorphDialog.FileName);
            Stream output = file.Open(FileMode.Create, FileAccess.Write, FileShare.None);
            this.exportHeadMorphDialog.InitialDirectory = file.DirectoryName;
            this.exportHeadMorphDialog.FileName = file.Name;
            this.SetStreamSwapState(Path.GetExtension(file.Name));

            this.SaveFile.SaveHeadMorph(output, type);
            output.Close();
        }

        private void OnHeadMorphFun(object sender, EventArgs e) {
            if (this.SaveFile.PlayerRecord.Appearance.HasMorphHead == false || this.SaveFile.PlayerRecord.Appearance.MorphHead == null) {
                MessageBox.Show(
                    "This save does not have a non-default head morph.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(
                   "Are you sure you want to apply this head morph transformation.",
                   "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }

            float changeValue = (float)trackBar_ToolboxHeadMorphFunValue.Value;
            string selected = (string)this.comboBox_ToolboxHeadMorphFunType.SelectedItem;
            switch (selected) {
                case "Head Size": {
                        if (changeValue == 0) // results in flat head
                            return;
                        else if (changeValue < 0) // results in inverted head
                            changeValue = 1 / -changeValue;

                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.X *= changeValue;
                            vertice.Y *= changeValue;
                            vertice.Z = ((vertice.Z - 160) * changeValue) + 160;
                        }
                        break;
                    }

                case "X Pos": {
                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.X += changeValue;
                        }
                        break;
                    }

                case "Y Pos": {
                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.Y += changeValue;
                        }
                        break;
                    }

                case "Z Pos": {
                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.Z += changeValue;
                        }

                        break;
                    }

                case "X Size": {
                        if (changeValue == 0) // results in flat head
                            return;
                        else if (changeValue < 0) // results in inverted head
                            changeValue = 1 / -changeValue;

                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.X *= changeValue;
                        }

                        break;
                    }

                case "Y Size": {
                        if (changeValue == 0) // results in flat head
                            return;
                        else if (changeValue < 0) // results in inverted head
                            changeValue = 1 / -changeValue;

                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.Y *= changeValue;
                        }

                        break;
                    }

                case "Z Size": {
                        if (changeValue == 0) // results in flat head
                            return;
                        else if (changeValue < 0) // results in inverted head
                            changeValue = 1 / -changeValue;

                        foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices) {
                            vertice.Z = ((vertice.Z - 160) * changeValue) + 160;
                        }

                        break;
                    }

                default: {
                        MessageBox.Show(
                            String.Format("Unhandled fun [{0}]!", selected),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void OnFunValueChange(object sender, EventArgs e) {
            generalToolTip.SetToolTip(trackBar_ToolboxHeadMorphFunValue, trackBar_ToolboxHeadMorphFunValue.Value.ToString());
        }

        private void OnHenchmenResetPowers(object sender, EventArgs e) {
            if (MessageBox.Show(
                    String.Format(
                    "Are you sure you want to reset all henchmen powers\n" +
                    "and refund all their talent points."),
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }

            int[] costs = new int[] { 1, 2, 3, 4 };
            foreach (var henchman in this.SaveFile.HenchmanRecords) {
                int refund = 0;
                foreach (var power in henchman.Powers.Where(p =>
                    p.PowerName != "LoyaltyRequirement")) {
                    for (int i = 0; i < Math.Min(power.CurrentRank, 4); i++) {
                        refund += costs[i];
                    }
                    power.CurrentRank = 0;
                }
                henchman.TalentPoints += refund;
            }
        }

        private void OnAbout(object sender, EventArgs e) {
            About aboutWindow = new About();
            aboutWindow.ShowDialog(this);
        }

        // just a little easter egg :)
        private void EasterEgg() {
            if (this.SaveFile.ME2PlotRecord._helper_RenegadePoints > this.SaveFile.ME2PlotRecord._helper_ParagonPoints)
                this.Icon = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.Renegade;
            else
                this.Icon = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.Paragon;
        }
    }
}
