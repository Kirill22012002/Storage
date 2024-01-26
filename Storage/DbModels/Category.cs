#nullable disable

namespace Storage.DbModels
{
    public partial class Category : BaseModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
