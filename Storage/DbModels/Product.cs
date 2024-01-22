using System.Collections.Generic;

#nullable disable

namespace Storage.DbModels
{
    public partial class Product
    {
        public Product()
        {
            Parts = new HashSet<Part>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
