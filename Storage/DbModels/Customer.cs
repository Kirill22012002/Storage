#nullable disable

namespace Storage.DbModels
{
    public partial class Customer : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public short? Age { get; set; }
    }
}
