namespace UGamer.ViewModels
{
    public class GameFormViewModel
    {

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(2500)]
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }

        public IEnumerable<SelectListItem>? Devices { get; set; }

    }
}