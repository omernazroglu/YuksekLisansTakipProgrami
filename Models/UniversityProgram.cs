using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateAppTracker.Models
{
    public class UniversityProgram
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Üniversite adı zorunludur.")]
        [MaxLength(200)]
        [Display(Name = "Üniversite Adı")]
        public string UniversityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bölüm/Program adı zorunludur.")]
        [MaxLength(200)]
        [Display(Name = "Bölüm / Program Adı")]
        public string DepartmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Minimum ALES puanı zorunludur.")]
        [Range(0, 100, ErrorMessage = "ALES puanı 0-100 arasında olmalıdır.")]
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Minimum ALES Puanı")]
        public decimal MinAlesScore { get; set; }

        [Display(Name = "Yabancı Dil Puanı Gerekiyor mu?")]
        public bool RequiresLanguage { get; set; }

        [Range(0, 100, ErrorMessage = "Yabancı dil puanı 0-100 arasında olmalıdır.")]
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Minimum Yabancı Dil Puanı")]
        public decimal? MinLanguageScore { get; set; }

        [Required(ErrorMessage = "Son başvuru tarihi zorunludur.")]
        [Display(Name = "Son Başvuru Tarihi")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Display(Name = "İlan Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? AnnouncementDate { get; set; }

        [Display(Name = "Kontenjan Sayısı")]
        [Range(1, 1000, ErrorMessage = "Geçerli bir kontenjan giriniz.")]
        public int? Quota { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Computed helper properties (not mapped to DB)
        [NotMapped]
        public bool IsExpired => ApplicationDate < DateTime.Today;

        [NotMapped]
        public bool IsUrgent => !IsExpired && (ApplicationDate - DateTime.Today).TotalDays <= 7;

        [NotMapped]
        public int DaysRemaining => IsExpired ? -1 : (int)(ApplicationDate - DateTime.Today).TotalDays;
    }
}
