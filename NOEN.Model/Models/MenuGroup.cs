using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEN.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]//Thuộc tính ID.
        public int ID { set; get; }

        [Required]//Thuộc tính bắt buộc nhập dữ liệu.
        public string Name { set; get; }

        public virtual IEnumerable<Menu> Menus { set; get; } //Khóa ngoại
    }
}
