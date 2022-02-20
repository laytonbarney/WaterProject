using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IWaterProjectRepo repo { get; set; }

        public TypesViewComponent (IWaterProjectRepo temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];

            var types = repo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
