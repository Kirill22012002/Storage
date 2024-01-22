#nullable disable

namespace Storage.DbModels
{
    public partial class ProductCategory
    {
        public long? IdCategory { get; set; }
        public long? IdProduct { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
