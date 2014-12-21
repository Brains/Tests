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
    public class WindowViewModel : INotifyPropertyChanged
    {
        private readonly Model model;
        private CommandDelegate <string> buttonClickCommandDelegate;

        //------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;

        //------------------------------------------------------------------
        public string Filter { get; set; }

        public CommandDelegate <string> ButtonClickCommandDelegate
        {
            get { return buttonClickCommandDelegate; }
            set { buttonClickCommandDelegate = value; }
        }

        public List <DataEntry> Data { get; private set; }

        //------------------------------------------------------------------
        public SortedSet <string> UniqueSet
        {
            get { return GetUniqueList(); }
        }

        //------------------------------------------------------------------
        public WindowViewModel()
        {
            model = new Model();
            Data = model.Data;

            ButtonClickCommandDelegate = new CommandDelegate<string>(key => SortList());
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
//          if (Data == null) return null;
            
            ICollectionView view = CollectionViewSource.GetDefaultView(Data);

            // Show all entries in Grid
            if (Filter.ToString() == "All")
            {
                view.Filter = null;
                return;
            }

           
            view.Filter = o => (o as DataEntry).Name == Filter;
        }

        //-------------------------------------------------------------------
        private void SortList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Data);
            
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("Color", ListSortDirection.Ascending));
        }


        //-------------------------------------------------------------------
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}