using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public interface IWaterProjectRepo
    {
        IQueryable<Project> Projects { get; }

    }
}
