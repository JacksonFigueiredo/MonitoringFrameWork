using API.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("Capture")]
    public class Capture : BaseEntity
    {
        [Column("ComputerName")]
        public string ComputerName { get; set; }
        [Column("CaptureDate")]
        public DateTime CaptureDate { get; set; }
    }
}
