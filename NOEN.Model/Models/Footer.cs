using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEN.Model.Models
{
    [Table("Footers")]// Thuộc tính gen ra tên bảng trong SQL
    public class Footer
    {
        [Key]//Khóa chính của bảng
        public string ID { set; get; }

        [Required]//Điều kiện bắt buộc phải nhật dữ liệu
        public string Content { set; get; }
    }
}
