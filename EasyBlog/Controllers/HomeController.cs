using EasyBlog.Data;
using EasyBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _db;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index(int cid)
		{
			if(cid != 0)
			{
				var category = _db.Categories.FirstOrDefault(x => x.Id == cid);
				if(category == null)
					return NotFound();
				ViewBag.CategoryName = category.Name;
				return View(_db.Posts.Where(x => x.CategoryId == cid).OrderByDescending(x => x.Id).ToList());
			}
			return View(_db.Posts.OrderByDescending(x => x.Id).ToList());
		}
		

		public IActionResult Privacy()
		{
			return View();
		}

		[Route("Post/{id}")]
		public IActionResult ShowPost(int id)
		{
			var post = _db.Posts.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

			return View(post);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
