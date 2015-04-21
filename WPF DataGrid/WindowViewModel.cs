using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using WPF.Annotations;

namespace WPF
{
    //-------------------------------------------------------------------
    public class WindowViewModel
    {
        private readonly Model model;
        private string filter;

        //------------------------------------------------------------------
        public CommandDelegate <string> ClickCommand { get; set; }
        public List <DataEntry> Data { get; private set; }

        //------------------------------------------------------------------
        public SortedSet <string> UniqueSet
        {
            get { return GetUniqueList(); }
        }

        //------------------------------------------------------------------
        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                FilterList();
            }
        }

        //------------------------------------------------------------------
        public WindowViewModel()
        {
            model = new Model();
            Data = model.Data;

            ClickCommand = new CommandDelegate <string>(key => SortList());
        }

        //-------------------------------------------------------------------
        public SortedSet <string> GetUniqueList()
        {
            SortedSet <string> set = new SortedSet <string> {"All"};

            // Get list of unique names
            foreach (var entry in model.Data)
                set.Add(entry.Name);

            return set;
        }

        //-------------------------------------------------------------------
        public void FilterList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Data);

            // Show all entries in Grid
            if (Filter == "All")
            {
                view.Filter = null;
                return;
            }

            view.Filter = entry => (entry as DataEntry).Name == filter;
        }

        //-------------------------------------------------------------------
        private void SortList()
        {
            const string key = "Id";

            ICollectionView view = CollectionViewSource.GetDefaultView(Data);

            var descriptions = view.SortDescriptions;

            if (descriptions.Count > 0 && 
                descriptions[0].Direction == ListSortDirection.Ascending)
            {
                // Already sorted ascending, replace to descending
                descriptions.Clear();
                descriptions.Add(new SortDescription(key, ListSortDirection.Descending));
            }
            else
            {
                // Sort ascending
                descriptions.Clear();
                descriptions.Add(new SortDescription(key, ListSortDirection.Ascending));
            }
        }
    }
}