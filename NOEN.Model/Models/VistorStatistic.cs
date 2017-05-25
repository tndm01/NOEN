using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOEN.Model.Models
{
    [Table("VistorStatistics")]
    public class VistorStatistic
    {
        [Key]
        public Guid ID { set; get; }

        [Required]
        public DateTime VistedDate { set; get; }

        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}