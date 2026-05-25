using System.ComponentModel.DataAnnotations;

namespace _25_may.Areas.AdminPanel.ViewModel
{
    public class UpdateVM
    {
        [Required]
        public string ImageURL { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Descriiption { get; set; }

    }
}
