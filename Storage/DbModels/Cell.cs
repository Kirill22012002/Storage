#nullable disable

namespace Storage.DbModels
{
    public partial class Cell : BaseModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
