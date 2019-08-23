using System;
namespace ConFusion.Data
{
    public class Leaders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
        public string Abbr { get; set; }
        public bool Featured { get; set; }
        public string Description { get; set; }

        public Leaders()
        {
        }
    }
}
