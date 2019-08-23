using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConFusion.Data
{
    public class Dishes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Label { get; set; }
        public string Price { get; set; }
        public bool Featured { get; set; }
        public string Description { get; set; }

        public Dishes()
        {
        }
    }
}
