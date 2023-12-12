using UGamer.Models;

namespace UGamer.Services
{
	public class GamesService : IGamesService
	{
		private readonly ApplicationDbContext _context;

		//to know the place where the cover photo will be saved in the server 
		private readonly IWebHostEnvironment _webHostEnvironment;

		private readonly string _imagesPath;

		public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			//pointing at the folder in wwwroot
			_imagesPath = $"{_webHostEnvironment.WebRootPath}/assets/gamesImages/games";
		}
		public IEnumerable<Game> GetAll()
		{
			//to stop the default behavior of tracking use asnotracking
			//eager loading category using Include so when we load home view u the category is loaded
			var games = _context.Games
				.Include(g => g.Category)
				.Include(g => g.Devices)
				.ThenInclude(d => d.Device)
				.AsNoTracking()
				.ToList();
			return games;
		}
		public Game? GetById(int id)
		{
			return _context.Games
				.Include(g => g.Category)
				.Include(g => g.Devices)
				.ThenInclude(d => d.Device)
				.AsNoTracking()
				.SingleOrDefault(g => g.Id == id);
		}


		public async Task Create(CreateGameFormViewModel model)
		{

			//saving the cover in sever

			var coverName = await SaveCover(model.Cover);


			//saving the  rest of the prop of game in db
			Game game = new()
			{
				Name = model.Name,
				Description = model.Description,
				CategoryId = model.CategoryId,
				Cover = coverName,
				Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
			};

			_context.Add(game);
			_context.SaveChanges();
		}

		public async Task<Game?> Update(EditGameFormViewModel model)
		{
			var game = _context.Games
				.Include(g=>g.Devices)
				.SingleOrDefault(g=>g.Id == model.Id);
			if (game is null)
				return null;

			game.Name = model.Name;
			game.Description = model.Description;
			game.CategoryId = model.CategoryId;
			game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

			var hasNewCover = model.Cover is not null;
			var oldCover = game.Cover;

			if (hasNewCover)
			{
				game.Cover = await SaveCover(model.Cover);	
			}

			var effectedRows = _context.SaveChanges();

			if(effectedRows>0)
			{
				if(hasNewCover)
				{
					var cover = Path.Combine(_imagesPath, oldCover);
					File.Delete(cover);
				}
				return game;
			}
			else
			{
				var cover = Path.Combine(_imagesPath, game.Cover);
				File.Delete(cover);
				return null;	
			}


		}

		public bool Delete(int id)
		{
			var isDeleted = false;
			var game = _context.Games.Find(id);

			if (game is null)
				return isDeleted;

			_context.Remove(game);

			var effectedRows = _context.SaveChanges();

			if (effectedRows>0) 
			{
				isDeleted = true;
				var cover = Path.Combine(_imagesPath, game.Cover);
				File.Delete(cover);
			}

            return isDeleted;
		}

		private async Task<string> SaveCover(IFormFile cover)
		{
			//saving the cover in sever

			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

			var path = Path.Combine(_imagesPath, coverName);

			using var stream = File.Create(path);

			await cover.CopyToAsync(stream);

			return coverName;

			//stream.Dispose(); no need because we used using
		}

	}
}