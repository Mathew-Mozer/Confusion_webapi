using System;
namespace ConFusion.Data
{
    public class Comments
    {

        public int Id { get; set; }
        public int DishId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        public Comments()
        {
        }
    }
}
