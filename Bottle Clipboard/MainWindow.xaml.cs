using Bottle_Clipboard.Services;
using ClipTagger.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bottle_Clipboard
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ClipboardItem> Items { get; set; }
        private ObservableCollection<ClipboardItem> AllItems;

        public MainWindow()
        {
            InitializeComponent();

            ClipboardStore.Instance.Items.Clear(); // Optional clear on load
            AllItems = ClipboardStore.Instance.Items;
            Items = AllItems;
            ClipboardList.ItemsSource = Items;
        }

        private void ClipboardList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ClipboardList.SelectedItem is ClipboardItem item)
            {
                System.Windows.Clipboard.SetText(item.Content);
                System.Windows.MessageBox.Show("Copied to clipboard!", "Bottle Clipboard", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Show or hide placeholder
            PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(SearchBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;

            // Filter
            string query = SearchBox.Text?.ToLower() ?? "";
            ClipboardList.ItemsSource = string.IsNullOrWhiteSpace(query)
                ? AllItems
                : new ObservableCollection<ClipboardItem>(
                    AllItems.Where(item =>
                        item.Content.ToLower().Contains(query) ||
                        item.Tags.ToLower().Contains(query)
                    ));
        }
    }
}
