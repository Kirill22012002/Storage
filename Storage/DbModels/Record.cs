#nullable disable

namespace Storage.DbModels
{
    public partial class Record : BaseModel
    {
        public long? IdCell { get; set; }
        public long? IdPart { get; set; }

        public virtual Cell IdCellNavigation { get; set; }
        public virtual Part IdPartNavigation { get; set; }
    }
}