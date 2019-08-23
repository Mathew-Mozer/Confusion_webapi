using System;
namespace ConFusion.Data
{
    public class Promotions
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Label { get; set; }
        public string Price { get; set; }
        public bool Featured { get; set; }
        public string Description { get; set; }

        public Promotions()
        {
        }
    }
}
