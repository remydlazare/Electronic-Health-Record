//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rehabilitation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Traces = new HashSet<Trace>();
        }

        [Display(Name = "Mã bệnh nhân")]
        public string PatientId { get; set; }
        [Display(Name = "Họ tên")]
        public string Name { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime Birth { get; set; }
        [Display(Name = "Giới tính")]
        public bool Sex { get; set; }
        [Display(Name = "Nghề nghiệp")]
        public string Job { get; set; }
        [Display(Name = "Dân tộc")]
        public string Ethnicity { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }
        [Display(Name = "Nơi làm việc")]
        public string Workplace { get; set; }
        [Display(Name = "Nhập viện")]
        //[DataType(DataType.Date)]
        public System.DateTime HospitalizedDate { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Ra viện/Tử vong")]
        public Nullable<System.DateTime> ReleasedOrDeath { get; set; }
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }
        [Display(Name = "Bác sĩ điều trị")]
        public string DoctorId { get; set; }
        [Display(Name = "Ăn")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Eating { get; set; }
        [Display(Name = "Vệ sinh đầu mặt")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Grooming { get; set; }
        [Display(Name = "Tắm")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Bathing { get; set; }
        [Display(Name = "Mặc áo")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> DressingUpperBody { get; set; }
        [Display(Name = "Mặc quần")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> DressingLowerBody { get; set; }
        [Display(Name = "Đi vệ sinh")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Toileting { get; set; }
        [Display(Name = "Kiểm soát bàng quang")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> BladderManagement { get; set; }
        [Display(Name = "Kiểm soát đường ruột")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> BowelManagement { get; set; }
        [Display(Name = "Dịch chuyển: giường sang ghế, xe lăn")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> TransferBedChairWheelchair { get; set; }
        [Display(Name = "Dịch chuyển: Ở phòng vệ sinh")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> TransferToilet { get; set; }
        [Display(Name = "Dịch chuyển: bồn tắm/buồng tắm với vòi sen")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> TransferTubShower { get; set; }
        [Display(Name = "Đi/Di chuyển bằng xe lăn")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> WalkOrWheelchair { get; set; }
        [Display(Name = "Lên xuống cầu thang")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Stairs { get; set; }
        [Display(Name = "Hiểu")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Compreshension { get; set; }
        [Display(Name = "Diễn đạt")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Expression { get; set; }
        [Display(Name = "Tương tác xã hội")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> SocialInteraction { get; set; }
        [Display(Name = "Giải quyết vấn đề")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> ProblemSolving { get; set; }
        [Display(Name = "Trí nhớ")]
        [Range(1, 7, ErrorMessage = "Mức độ cần trong khoảng từ 1 đến 7.")]
        public Nullable<int> Memory { get; set; }
        [Display(Name = "Điểm tiểu mục Vận động, di chuyển")]
        public Nullable<int> MotorDomain
        {
            get
            {
                return Eating + Grooming + Bathing + DressingLowerBody + DressingUpperBody + Toileting + BladderManagement + BowelManagement +
                    TransferBedChairWheelchair + TransferToilet + TransferTubShower + WalkOrWheelchair + Stairs;
            }
        }
        [Display(Name = "Điểm tiểu mục Nhận thức")]
        public Nullable<int> CognitiveDomain
        {
            get
            {
                return Compreshension + Expression + SocialInteraction + ProblemSolving + Memory;
            }
        }
        [Display(Name = "Tổng điểm FIM")]
        public Nullable<int> Total { get
        {
            return MotorDomain + CognitiveDomain;
        } }
        [Display(Name = "Khởi tạo")]
        public System.DateTime Created { get; set; }
        [Display(Name = "Chỉnh sửa gần nhất")]
        public System.DateTime LastModified { get; set; }

        public virtual Doctor Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trace> Traces { get; set; }

        public string SexToString { get
            {
                if (Sex) return "Nữ";
                else return "Nam";
            } }

        public static IEnumerable<string> DanToc = new List<string>
        {
            "Kinh",
            "Tày",
            "Thái",
            "Mường",
            "Khmer",
            "Hoa",
            "Nùng",
            "H'Mông",
            "Dao",
            "Jrai",
            "Ê Đê",
            "Ba Na",
            "Sán Chay",
            "Chăm",
            "Cơ Ho",
            "Xơ Đăng",
            "Sán Dìu",
            "Hrê",
            "Ra Giai",
            "Mnông",
            "Thổ",
            "Stiêng",
            "Khơ mú",
            "Vân Kiều",
            "Cơ Tu",
            "Giáy",
            "Tà Ôi",
            "Mạ",
            "Giẻ Triêng",
            "Co",
            "Chơ Ro",
            "Xinh Mun",
            "Hà Nhì",
            "Chu Ru",
            "Lào",
            "La Chí",
            "Kháng",
            "Phù Lá",
            "La Hủ",
            "La Ha",
            "Pà Thẻn",
            "Lự",
            "Ngái",
            "Chứt",
            "Lô Lô",
            "Mảng",
            "Cơ Lao",
            "Bố Y",
            "Cống",
            "Si La",
            "Pu Péo",
            "Rơ Măm",
            "Brâu",
            "Ơ Đu"
        };

        public static IEnumerable<string> TinhTrang = new List<string>
        {
            "Đang điều trị",
            "Đã xuất viện",
            "Đã tử vong"
        };
    }
}
