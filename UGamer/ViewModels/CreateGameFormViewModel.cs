namespace UGamer.ViewModels
{
	public class CreateGameFormViewModel : GameFormViewModel
    {
        // validate extension and size 
        //[Extension] good with api not with MVC
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSizeAttribute(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; }
    }
}
