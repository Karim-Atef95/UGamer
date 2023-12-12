namespace UGamer.Services
{
	public interface ICategoriesService
	{
		IEnumerable<SelectListItem> GetSelectList();
	}
}
