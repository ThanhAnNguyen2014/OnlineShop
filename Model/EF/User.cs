namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
		[Display(Name ="User name:")]
        public string UserName { get; set; }

        [StringLength(32)]
		[Display(Name = "Mật Khẩu:")]
		public string Password { get; set; }

        [StringLength(20)]
		[Display(Name = "GroupID:")]
		public string GroupID { get; set; }

        [StringLength(50)]
		[Display(Name = "Tên:")]
		public string Name { get; set; }

        [StringLength(50)]
		[Display(Name = "Địa Chỉ:")]
		public string Address { get; set; }

        [StringLength(50)]
		[Display(Name = "Email:")]
		public string Email { get; set; }

        [StringLength(50)]
		[Display(Name = "Phone:")]
		public string Phone { get; set; }

		[Display(Name = "ProvinceID:")]
		public int? ProvinceID { get; set; }

		[Display(Name = "DistrictID:")]
		public int? DistrictID { get; set; }

		[Display(Name = "Ngày Tạo:")]
		public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
		[Display(Name = "Người Tạo:")]
		public string CreatedBy { get; set; }

		[Display(Name = "Ngày Sửa:")]
		public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
		[Display(Name = "Người Sửa:")]
		public string ModifiedBy { get; set; }

		[Display(Name = "Trạng Thái:")]
		public bool Status { get; set; }
    }
}
