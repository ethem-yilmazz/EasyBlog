﻿using Microsoft.AspNetCore.Mvc;

namespace EasyBlog.Areas.Admin.Controllers
{
	
	public class DashboardController : AdminBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
