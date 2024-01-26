#nullable disable

namespace Storage.DbModels
{
    public partial class CustomersProduct : BaseModel
    {
        public long? IdCustomer { get; set; }
        public long? IdProduct { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
