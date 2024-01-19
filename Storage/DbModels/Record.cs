using System;
using System.Collections.Generic;

#nullable disable

namespace Storage.DbModels
{
    public partial class Record
    {
        public long? IdCell { get; set; }
        public long? IdPart { get; set; }

        public virtual Cell IdCellNavigation { get; set; }
        public virtual Part IdPartNavigation { get; set; }
    }
}
