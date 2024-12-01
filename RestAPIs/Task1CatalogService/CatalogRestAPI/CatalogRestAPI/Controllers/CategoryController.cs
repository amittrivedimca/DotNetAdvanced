using Application;
using Application.CategoryProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationManager _appManager;
        public CategoryController(IApplicationManager applicationManager)
        {
            _appManager = applicationManager;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _appManager.CategoryProvider.GetAll();
        }
    }
}
