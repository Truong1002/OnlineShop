namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tài Khoản")]
        public string UserName { get; set; }
        [DisplayName("Mật Khẩu")]
        [StringLength(32)]
        public string Password { get; set; }
        [DisplayName("Họ Tên")]
        [StringLength(50)]
        public string Name { get; set; }
        [DisplayName("Địa Chỉ")]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]

        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Điện Thoại")]
        public string Phone { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        public int? PrecinctID { get; set; }    

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng Thái")]
        public bool Status { get; set; }
    }
}
