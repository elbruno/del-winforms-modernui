using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace MetroFramework.ApiClient
{
    public class ApiClientForm : MetroForm
    {
        private readonly ProductApiClient _apiClient;
        private MetroStyleManager styleManager;
        private MetroProgressSpinner loadingSpinner;
        private MetroLabel statusLabel;
        private MetroButton loadProductsButton;
        private MetroButton loadStatsButton;
        private MetroComboBox themeComboBox;
        private ListView productsListView;
        private MetroPanel statsPanel;
        private MetroLabel totalProductsLabel;
        private MetroLabel totalCategoriesLabel;
        private MetroLabel avgPriceLabel;
        private MetroLabel lastUpdatedLabel;

        public ApiClientForm(ProductApiClient apiClient)
        {
            _apiClient = apiClient;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "MetroFramework API Client";
            this.Size = new Size(1000, 700);
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

            // Load Products Button
            loadProductsButton = new MetroButton();
            loadProductsButton.Text = "Load Products";
            loadProductsButton.Location = new Point(200, 65);
            loadProductsButton.Size = new Size(130, 30);
            loadProductsButton.Click += LoadProductsButton_Click;
            this.Controls.Add(loadProductsButton);

            // Load Stats Button
            loadStatsButton = new MetroButton();
            loadStatsButton.Text = "Load Stats";
            loadStatsButton.Location = new Point(340, 65);
            loadStatsButton.Size = new Size(130, 30);
            loadStatsButton.Click += LoadStatsButton_Click;
            this.Controls.Add(loadStatsButton);

            // Loading Spinner
            loadingSpinner = new MetroProgressSpinner();
            loadingSpinner.Location = new Point(490, 65);
            loadingSpinner.Size = new Size(30, 30);
            loadingSpinner.Visible = false;
            this.Controls.Add(loadingSpinner);

            // Status Label
            statusLabel = new MetroLabel();
            statusLabel.Text = "Ready";
            statusLabel.Location = new Point(530, 70);
            statusLabel.AutoSize = true;
            this.Controls.Add(statusLabel);

            // Products ListView
            var productsLabel = new MetroLabel();
            productsLabel.Text = "Products from API";
            productsLabel.Location = new Point(20, 110);
            productsLabel.AutoSize = true;
            this.Controls.Add(productsLabel);

            productsListView = new ListView();
            productsListView.Location = new Point(20, 135);
            productsListView.Size = new Size(700, 300);
            productsListView.View = View.Details;
            productsListView.FullRowSelect = true;
            productsListView.GridLines = true;
            productsListView.Columns.Add("ID", 50);
            productsListView.Columns.Add("Name", 200);
            productsListView.Columns.Add("Description", 250);
            productsListView.Columns.Add("Price", 80);
            productsListView.Columns.Add("Category", 100);
            this.Controls.Add(productsListView);

            // Stats Panel
            var statsLabel = new MetroLabel();
            statsLabel.Text = "Statistics";
            statsLabel.Location = new Point(740, 110);
            statsLabel.AutoSize = true;
            this.Controls.Add(statsLabel);

            statsPanel = new MetroPanel();
            statsPanel.Location = new Point(740, 135);
            statsPanel.Size = new Size(220, 180);
            this.Controls.Add(statsPanel);

            totalProductsLabel = new MetroLabel();
            totalProductsLabel.Text = "Total Products: -";
            totalProductsLabel.Location = new Point(10, 20);
            totalProductsLabel.AutoSize = true;
            statsPanel.Controls.Add(totalProductsLabel);

            totalCategoriesLabel = new MetroLabel();
            totalCategoriesLabel.Text = "Total Categories: -";
            totalCategoriesLabel.Location = new Point(10, 50);
            totalCategoriesLabel.AutoSize = true;
            statsPanel.Controls.Add(totalCategoriesLabel);

            avgPriceLabel = new MetroLabel();
            avgPriceLabel.Text = "Avg Price: -";
            avgPriceLabel.Location = new Point(10, 80);
            avgPriceLabel.AutoSize = true;
            statsPanel.Controls.Add(avgPriceLabel);

            lastUpdatedLabel = new MetroLabel();
            lastUpdatedLabel.Text = "Last Updated: -";
            lastUpdatedLabel.Location = new Point(10, 110);
            lastUpdatedLabel.AutoSize = true;
            statsPanel.Controls.Add(lastUpdatedLabel);

            // Info tiles
            var infoTile = new MetroTile();
            infoTile.Text = "Aspire Orchestrated";
            infoTile.Location = new Point(20, 450);
            infoTile.Size = new Size(200, 100);
            infoTile.TileCount = 1;
            this.Controls.Add(infoTile);

            var apiTile = new MetroTile();
            apiTile.Text = "Web API Backend";
            apiTile.Location = new Point(230, 450);
            apiTile.Size = new Size(200, 100);
            apiTile.TileCount = 5;
            this.Controls.Add(apiTile);

            var clientTile = new MetroTile();
            clientTile.Text = "WinForms Client";
            clientTile.Location = new Point(440, 450);
            clientTile.Size = new Size(200, 100);
            this.Controls.Add(clientTile);

            this.ResumeLayout(false);
        }

        private async void LoadProductsButton_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async void LoadStatsButton_Click(object sender, EventArgs e)
        {
            await LoadStatsAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                SetLoading(true, "Loading products...");
                productsListView.Items.Clear();

                var products = await _apiClient.GetProductsAsync();

                foreach (var product in products)
                {
                    var item = new ListViewItem(product.Id.ToString());
                    item.SubItems.Add(product.Name);
                    item.SubItems.Add(product.Description);
                    item.SubItems.Add($"${product.Price:F2}");
                    item.SubItems.Add(product.Category);
                    productsListView.Items.Add(item);
                }

                SetLoading(false, $"Loaded {products.Count} products");
            }
            catch (Exception ex)
            {
                SetLoading(false, $"Error: {ex.Message}");
            }
        }

        private async Task LoadStatsAsync()
        {
            try
            {
                SetLoading(true, "Loading statistics...");

                var stats = await _apiClient.GetStatsAsync();

                if (stats != null)
                {
                    totalProductsLabel.Text = $"Total Products: {stats.TotalProducts}";
                    totalCategoriesLabel.Text = $"Total Categories: {stats.TotalCategories}";
                    avgPriceLabel.Text = $"Avg Price: ${stats.AveragePrice:F2}";
                    lastUpdatedLabel.Text = $"Last Updated: {stats.LastUpdated:g}";
                }

                SetLoading(false, "Statistics loaded");
            }
            catch (Exception ex)
            {
                SetLoading(false, $"Error: {ex.Message}");
            }
        }

        private void SetLoading(bool isLoading, string message)
        {
            loadingSpinner.Visible = isLoading;
            loadProductsButton.Enabled = !isLoading;
            loadStatsButton.Enabled = !isLoading;
            statusLabel.Text = message;
        }

        private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            styleManager.Theme = themeComboBox.SelectedIndex == 0 ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
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
