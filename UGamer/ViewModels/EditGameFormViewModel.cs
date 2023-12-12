
namespace UGamer.ViewModels
{
    public class EditGameFormViewModel:GameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        // validate extension and size 
        //[Extension] good with api not with MVC
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSizeAttribute(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; }

    }
}