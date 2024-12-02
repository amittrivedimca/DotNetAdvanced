using Application;
using Application.CategoryAL;
using Application.ProductAL;
using HelperUtils;
using Microsoft.AspNetCore.Mvc;

namespace CatalogRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IApplicationManager _appManager;
        public ProductController(IApplicationManager applicationManager)
        {
            _appManager = applicationManager;
        }

        [HttpGet("{categoryID}/{pageNumber?}/{pageSize?}")]

        public async Task<ActionResult<PagedList<ProductDTO>>> GetAll([FromRoute]int categoryID, 
            [FromRoute] int pageNumber=0, [FromRoute] int pageSize=0)
        {
            ProductsFilter filter = new ProductsFilter()
            {
                CategoryID = categoryID,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(await _appManager.ProductProvider.GetAllAsync(filter));
        }

        [HttpGet()]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var result = await _appManager.CategoryProvider.GetById(id);
            if (result.Item1 == DBOperationStatus.NotFound)
            {
                return NotFound(result.Item1.ToString());
            }
            return Ok(result.Item2);
        }

        [HttpPost()]
        public async Task<ActionResult<string>> Add(ProductDTO product)
        {
            try
            {
                return (await _appManager.ProductProvider.AddAsync(product)).ToString();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        public async Task<ActionResult<string>> Update(ProductDTO product)
        {
            try
            {
                var status = await _appManager.ProductProvider.UpdateAsync(product);
                if (status == DBOperationStatus.NotFound)
                {
                    return NotFound(status.ToString());
                }
                return status.ToString();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var status = await _appManager.ProductProvider.DeleteAsync(id);
                if (status == DBOperationStatus.NotFound)
                {
                    return NotFound(status.ToString());
                }
                return status.ToString();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
