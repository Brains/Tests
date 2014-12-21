using System.Collections.Generic;

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
    public class Model
    {
        public List <DataEntry> Data { get; private set; }

        //-------------------------------------------------------------------
        public Model()
        {
            FillGrid();
        }


        //-------------------------------------------------------------------
        private void FillGrid()
        {
            Data = new List <DataEntry>
            {
                new DataEntry {Id = 1, Name = "Johny", Color = "White"},
                new DataEntry {Id = 2, Name = "Merry", Color = "Red"},
                new DataEntry {Id = 3, Name = "Sindi", Color = "Green"},
                new DataEntry {Id = 4, Name = "Johny", Color = "Red"},
                new DataEntry {Id = 5, Name = "Morrow", Color = "Yellow"},
                new DataEntry {Id = 6, Name = "Johny", Color = "Red"},
                new DataEntry {Id = 7, Name = "Sindi", Color = "Blue"}
            };
        }
    }
}