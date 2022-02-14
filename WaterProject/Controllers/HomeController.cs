using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterProjectRepo repo;

        public HomeController (IWaterProjectRepo temp)
        {
            repo = temp;
        }

        //As a perameter pageNum is default to 1
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Projects.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        //This is the lambda funciton for above
        //public IActionResult Index() => View();
    }
}
