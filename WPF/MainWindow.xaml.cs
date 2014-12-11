using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
    //-------------------------------------------------------------------
    public class DataEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }

    //-------------------------------------------------------------------
    public partial class MainWindow : Window
    {
        public DataEntry[] Data;

        //-------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            Grid.ColumnWidth = 100;

            Loaded += OnLoaded;
        }

        //-------------------------------------------------------------------
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            FillGrid();
            FillComboBox();
        }

        //-------------------------------------------------------------------
        private void FillComboBox()
        {
            SortedSet<string> set = new SortedSet<string>();

            // Get list of unique names
            foreach (var entry in Data)
                set.Add(entry.Name);

            // Put them all into ComboBox
            foreach (var entry in set)
                Name.Items.Add(entry);
        }

        //-------------------------------------------------------------------
        public void FillGrid()
        {
            Data = new DataEntry[]
            {
                new DataEntry {Id = 1, Name = "Johny", Color = "White"},
                new DataEntry {Id = 2, Name = "Merry", Color = "Red"},
                new DataEntry {Id = 3, Name = "Sindi", Color = "Green"},
                new DataEntry {Id = 4, Name = "Johny", Color = "Red"},
                new DataEntry {Id = 5, Name = "Morrow", Color = "Yellow"},
                new DataEntry {Id = 6, Name = "Johny", Color = "Red"},
                new DataEntry {Id = 7, Name = "Sindi", Color = "Blue"}
            };

            this.Grid.ItemsSource = Data;
        }

        //-------------------------------------------------------------------
        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data == null) return;

            var filter = Name.SelectedValue;

            // Show all entries in Grid
            if (filter.ToString() == "All")
            {
                Grid.ItemsSource = Data;
                return;
            }

            // Or filter entries by selection in the ComboBox
            Grid.ItemsSource = from entry in Data
                               where entry.Name == filter.ToString()
                               select entry;
        }

        //-------------------------------------------------------------------
        private void OnSortButtonClick(object sender, RoutedEventArgs e)
        {
            Grid.ItemsSource = from entry in Data
                               orderby entry.Color
                               select entry;

        }


    }
}
