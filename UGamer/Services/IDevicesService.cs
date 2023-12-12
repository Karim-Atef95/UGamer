namespace UGamer.Services
{
	public interface IDevicesService
	{
		IEnumerable<SelectListItem> GetSelectList();
	}
}
