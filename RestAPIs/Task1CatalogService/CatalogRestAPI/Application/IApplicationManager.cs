using Application.CategoryAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IApplicationManager
    {
        ICategoryProvider CategoryProvider { get; }
    }
}
