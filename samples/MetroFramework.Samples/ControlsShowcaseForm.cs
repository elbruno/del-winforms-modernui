using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace MetroFramework.Samples
{
    public class ControlsShowcaseForm : MetroForm
    {
        private MetroStyleManager styleManager;
        private MetroTabControl tabControl;
        private MetroComboBox themeComboBox;
        private MetroComboBox styleComboBox;

        public ControlsShowcaseForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "MetroFramework Controls Showcase";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Style Manager
            styleManager = new MetroStyleManager();
            styleManager.OwnerForm = this;
            styleManager.Style = MetroColorStyle.Blue;
            styleManager.Theme = MetroThemeStyle.Light;
            this.StyleManager = styleManager;

            // Theme selector
            var themeLabel = new MetroLabel();
            themeLabel.Text = "Theme:";
            themeLabel.Location = new Point(20, 70);
            themeLabel.AutoSize = true;
            this.Controls.Add(themeLabel);

            themeComboBox = new MetroComboBox();
            themeComboBox.Location = new Point(80, 65);
            themeComboBox.Size = new Size(100, 29);
            themeComboBox.Items.AddRange(new object[] { "Light", "Dark" });
            themeComboBox.SelectedIndex = 0;
            themeComboBox.SelectedIndexChanged += ThemeComboBox_SelectedIndexChanged;
            this.Controls.Add(themeComboBox);

            // Style selector
            var styleLabel = new MetroLabel();
            styleLabel.Text = "Style:";
            styleLabel.Location = new Point(200, 70);
            styleLabel.AutoSize = true;
            this.Controls.Add(styleLabel);

            styleComboBox = new MetroComboBox();
            styleComboBox.Location = new Point(250, 65);
            styleComboBox.Size = new Size(120, 29);
            foreach (MetroColorStyle style in Enum.GetValues(typeof(MetroColorStyle)))
            {
                styleComboBox.Items.Add(style.ToString());
            }
            styleComboBox.SelectedIndex = (int)MetroColorStyle.Blue;
            styleComboBox.SelectedIndexChanged += StyleComboBox_SelectedIndexChanged;
            this.Controls.Add(styleComboBox);

            // Tab Control
            tabControl = new MetroTabControl();
            tabControl.Location = new Point(20, 110);
            tabControl.Size = new Size(860, 450);
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            tabControl.StyleManager = styleManager;

            // Create tabs
            CreateButtonsTab();
            CreateInputTab();
            CreateProgressTab();
            CreateTilesTab();

            this.Controls.Add(tabControl);

            this.ResumeLayout(false);
        }

        private void CreateButtonsTab()
        {
            var tabPage = new MetroTabPage();
            tabPage.Text = "Buttons & Links";

            // Buttons section
            var buttonLabel = new MetroLabel();
            buttonLabel.Text = "MetroButton";
            buttonLabel.Location = new Point(25, 25);
            buttonLabel.AutoSize = true;
            tabPage.Controls.Add(buttonLabel);

            var normalButton = new MetroButton();
            normalButton.Text = "Normal Button";
            normalButton.Location = new Point(25, 50);
            normalButton.Size = new Size(130, 40);
            tabPage.Controls.Add(normalButton);

            var highlightedButton = new MetroButton();
            highlightedButton.Text = "Highlighted";
            highlightedButton.Location = new Point(165, 50);
            highlightedButton.Size = new Size(130, 40);
            highlightedButton.Highlight = true;
            tabPage.Controls.Add(highlightedButton);

            var disabledButton = new MetroButton();
            disabledButton.Text = "Disabled";
            disabledButton.Location = new Point(305, 50);
            disabledButton.Size = new Size(130, 40);
            disabledButton.Enabled = false;
            tabPage.Controls.Add(disabledButton);

            // Links section
            var linkLabel = new MetroLabel();
            linkLabel.Text = "MetroLink";
            linkLabel.Location = new Point(25, 110);
            linkLabel.AutoSize = true;
            tabPage.Controls.Add(linkLabel);

            var normalLink = new MetroLink();
            normalLink.Text = "Normal Link";
            normalLink.Location = new Point(25, 135);
            normalLink.Size = new Size(100, 23);
            tabPage.Controls.Add(normalLink);

            var styledLink = new MetroLink();
            styledLink.Text = "Styled Link";
            styledLink.Location = new Point(135, 135);
            styledLink.Size = new Size(100, 23);
            styledLink.UseStyleColors = true;
            tabPage.Controls.Add(styledLink);

            var disabledLink = new MetroLink();
            disabledLink.Text = "Disabled Link";
            disabledLink.Location = new Point(245, 135);
            disabledLink.Size = new Size(100, 23);
            disabledLink.Enabled = false;
            tabPage.Controls.Add(disabledLink);

            tabControl.Controls.Add(tabPage);
        }

        private void CreateInputTab()
        {
            var tabPage = new MetroTabPage();
            tabPage.Text = "Input Controls";

            // TextBox section
            var textBoxLabel = new MetroLabel();
            textBoxLabel.Text = "MetroTextBox";
            textBoxLabel.Location = new Point(25, 25);
            textBoxLabel.AutoSize = true;
            tabPage.Controls.Add(textBoxLabel);

            var normalTextBox = new MetroTextBox();
            normalTextBox.Text = "Normal TextBox";
            normalTextBox.Location = new Point(25, 50);
            normalTextBox.Size = new Size(200, 23);
            tabPage.Controls.Add(normalTextBox);

            var styledTextBox = new MetroTextBox();
            styledTextBox.Text = "Styled TextBox";
            styledTextBox.Location = new Point(235, 50);
            styledTextBox.Size = new Size(200, 23);
            styledTextBox.UseStyleColors = true;
            tabPage.Controls.Add(styledTextBox);

            var multilineTextBox = new MetroTextBox();
            multilineTextBox.Text = "Multiline TextBox\nLine 2\nLine 3";
            multilineTextBox.Location = new Point(445, 50);
            multilineTextBox.Size = new Size(200, 80);
            multilineTextBox.Multiline = true;
            tabPage.Controls.Add(multilineTextBox);

            // CheckBox section
            var checkBoxLabel = new MetroLabel();
            checkBoxLabel.Text = "MetroCheckBox";
            checkBoxLabel.Location = new Point(25, 140);
            checkBoxLabel.AutoSize = true;
            tabPage.Controls.Add(checkBoxLabel);

            var normalCheckBox = new MetroCheckBox();
            normalCheckBox.Text = "Normal CheckBox";
            normalCheckBox.Location = new Point(25, 165);
            normalCheckBox.AutoSize = true;
            tabPage.Controls.Add(normalCheckBox);

            var styledCheckBox = new MetroCheckBox();
            styledCheckBox.Text = "Styled CheckBox";
            styledCheckBox.Location = new Point(175, 165);
            styledCheckBox.AutoSize = true;
            styledCheckBox.UseStyleColors = true;
            tabPage.Controls.Add(styledCheckBox);

            // RadioButton section
            var radioLabel = new MetroLabel();
            radioLabel.Text = "MetroRadioButton";
            radioLabel.Location = new Point(25, 200);
            radioLabel.AutoSize = true;
            tabPage.Controls.Add(radioLabel);

            var radioButton1 = new MetroRadioButton();
            radioButton1.Text = "Option 1";
            radioButton1.Location = new Point(25, 225);
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            tabPage.Controls.Add(radioButton1);

            var radioButton2 = new MetroRadioButton();
            radioButton2.Text = "Option 2";
            radioButton2.Location = new Point(125, 225);
            radioButton2.AutoSize = true;
            tabPage.Controls.Add(radioButton2);

            var radioButton3 = new MetroRadioButton();
            radioButton3.Text = "Option 3";
            radioButton3.Location = new Point(225, 225);
            radioButton3.AutoSize = true;
            tabPage.Controls.Add(radioButton3);

            // Toggle section
            var toggleLabel = new MetroLabel();
            toggleLabel.Text = "MetroToggle";
            toggleLabel.Location = new Point(25, 260);
            toggleLabel.AutoSize = true;
            tabPage.Controls.Add(toggleLabel);

            var normalToggle = new MetroToggle();
            normalToggle.Text = "Normal";
            normalToggle.Location = new Point(25, 285);
            normalToggle.DisplayStatus = true;
            tabPage.Controls.Add(normalToggle);

            var styledToggle = new MetroToggle();
            styledToggle.Text = "Styled";
            styledToggle.Location = new Point(125, 285);
            styledToggle.UseStyleColors = true;
            tabPage.Controls.Add(styledToggle);

            // ComboBox section
            var comboLabel = new MetroLabel();
            comboLabel.Text = "MetroComboBox";
            comboLabel.Location = new Point(350, 140);
            comboLabel.AutoSize = true;
            tabPage.Controls.Add(comboLabel);

            var comboBox = new MetroComboBox();
            comboBox.Location = new Point(350, 165);
            comboBox.Size = new Size(200, 29);
            comboBox.Items.AddRange(new object[] { "Option 1", "Option 2", "Option 3", "Option 4" });
            comboBox.SelectedIndex = 0;
            tabPage.Controls.Add(comboBox);

            tabControl.Controls.Add(tabPage);
        }

        private void CreateProgressTab()
        {
            var tabPage = new MetroTabPage();
            tabPage.Text = "Progress & Sliders";

            // ProgressBar section
            var progressLabel = new MetroLabel();
            progressLabel.Text = "MetroProgressBar";
            progressLabel.Location = new Point(25, 25);
            progressLabel.AutoSize = true;
            tabPage.Controls.Add(progressLabel);

            var progressBar1 = new MetroProgressBar();
            progressBar1.Location = new Point(25, 50);
            progressBar1.Size = new Size(400, 23);
            progressBar1.Value = 25;
            tabPage.Controls.Add(progressBar1);

            var progressBar2 = new MetroProgressBar();
            progressBar2.Location = new Point(25, 80);
            progressBar2.Size = new Size(400, 23);
            progressBar2.Value = 50;
            tabPage.Controls.Add(progressBar2);

            var progressBar3 = new MetroProgressBar();
            progressBar3.Location = new Point(25, 110);
            progressBar3.Size = new Size(400, 23);
            progressBar3.Value = 75;
            tabPage.Controls.Add(progressBar3);

            var marqueeProgressBar = new MetroProgressBar();
            marqueeProgressBar.Location = new Point(25, 140);
            marqueeProgressBar.Size = new Size(400, 23);
            marqueeProgressBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            tabPage.Controls.Add(marqueeProgressBar);

            // Spinner section
            var spinnerLabel = new MetroLabel();
            spinnerLabel.Text = "MetroProgressSpinner";
            spinnerLabel.Location = new Point(450, 25);
            spinnerLabel.AutoSize = true;
            tabPage.Controls.Add(spinnerLabel);

            var spinner1 = new MetroProgressSpinner();
            spinner1.Location = new Point(450, 50);
            spinner1.Size = new Size(40, 40);
            tabPage.Controls.Add(spinner1);

            var spinner2 = new MetroProgressSpinner();
            spinner2.Location = new Point(500, 50);
            spinner2.Size = new Size(30, 30);
            spinner2.Value = 50;
            tabPage.Controls.Add(spinner2);

            var spinner3 = new MetroProgressSpinner();
            spinner3.Location = new Point(540, 50);
            spinner3.Size = new Size(20, 20);
            spinner3.Value = 75;
            tabPage.Controls.Add(spinner3);

            // TrackBar section
            var trackBarLabel = new MetroLabel();
            trackBarLabel.Text = "MetroTrackBar";
            trackBarLabel.Location = new Point(25, 180);
            trackBarLabel.AutoSize = true;
            tabPage.Controls.Add(trackBarLabel);

            var trackBar = new MetroTrackBar();
            trackBar.Location = new Point(25, 205);
            trackBar.Size = new Size(400, 23);
            trackBar.Value = 50;
            tabPage.Controls.Add(trackBar);

            // ScrollBar section
            var scrollBarLabel = new MetroLabel();
            scrollBarLabel.Text = "MetroScrollBar";
            scrollBarLabel.Location = new Point(25, 245);
            scrollBarLabel.AutoSize = true;
            tabPage.Controls.Add(scrollBarLabel);

            var scrollBar = new MetroScrollBar();
            scrollBar.Location = new Point(25, 270);
            scrollBar.Size = new Size(400, 10);
            scrollBar.Orientation = MetroScrollOrientation.Horizontal;
            scrollBar.UseBarColor = true;
            tabPage.Controls.Add(scrollBar);

            tabControl.Controls.Add(tabPage);
        }

        private void CreateTilesTab()
        {
            var tabPage = new MetroTabPage();
            tabPage.Text = "Tiles";

            // Tiles section
            var tilesLabel = new MetroLabel();
            tilesLabel.Text = "MetroTile";
            tilesLabel.Location = new Point(25, 25);
            tilesLabel.AutoSize = true;
            tabPage.Controls.Add(tilesLabel);

            var tile1 = new MetroTile();
            tile1.Text = "Tile 1";
            tile1.Location = new Point(25, 50);
            tile1.Size = new Size(150, 100);
            tile1.TileCount = 5;
            tabPage.Controls.Add(tile1);

            var tile2 = new MetroTile();
            tile2.Text = "Tile 2";
            tile2.Location = new Point(185, 50);
            tile2.Size = new Size(150, 100);
            tile2.TileCount = 12;
            tabPage.Controls.Add(tile2);

            var tile3 = new MetroTile();
            tile3.Text = "Tile 3";
            tile3.Location = new Point(345, 50);
            tile3.Size = new Size(150, 100);
            tabPage.Controls.Add(tile3);

            var disabledTile = new MetroTile();
            disabledTile.Text = "Disabled";
            disabledTile.Location = new Point(505, 50);
            disabledTile.Size = new Size(150, 100);
            disabledTile.Enabled = false;
            tabPage.Controls.Add(disabledTile);

            // Large tiles
            var largeTile1 = new MetroTile();
            largeTile1.Text = "Large Tile";
            largeTile1.Location = new Point(25, 160);
            largeTile1.Size = new Size(310, 150);
            largeTile1.TileCount = 99;
            tabPage.Controls.Add(largeTile1);

            var largeTile2 = new MetroTile();
            largeTile2.Text = "Wide Tile";
            largeTile2.Location = new Point(345, 160);
            largeTile2.Size = new Size(310, 75);
            tabPage.Controls.Add(largeTile2);

            tabControl.Controls.Add(tabPage);
        }

        private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            styleManager.Theme = themeComboBox.SelectedIndex == 0 ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
        }

        private void StyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse<MetroColorStyle>(styleComboBox.SelectedItem.ToString(), out var style))
            {
                styleManager.Style = style;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                styleManager?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
