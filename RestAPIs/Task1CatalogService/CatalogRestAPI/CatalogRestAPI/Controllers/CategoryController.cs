using Application;
using Application.CategoryAL;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationManager _appManager;
        public CategoryController(IApplicationManager applicationManager)
        {
            _appManager = applicationManager;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<CategoryDTO>> GetAll()
        {
            return Ok(_appManager.CategoryProvider.GetAll());
        }

        [HttpGet(Name = "GetById")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var result = await _appManager.CategoryProvider.GetById(id);
            if (result.Item1 == DBOperationStatus.NotFound)
            {
                return NotFound(result.Item1.ToString());
            }
            return Ok(result.Item2);
        }

        [HttpPost(Name = "AddAsync")]
        public async Task<ActionResult<string>> AddAsync(CategoryDTO category)
        {
            try
            {
                return (await _appManager.CategoryProvider.AddAsync(category)).ToString();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut(Name = "UpdateAsync")]
        public async Task<ActionResult<string>> UpdateAsync(CategoryDTO category)
        {
            try
            {
                var status = await _appManager.CategoryProvider.UpdateAsync(category);
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

        [HttpDelete(Name = "DeleteAsync")]
        public async Task<ActionResult<string>> DeleteAsync(int id)
        {
            try
            {
                var status = await _appManager.CategoryProvider.DeleteAsync(id);
                if(status == DBOperationStatus.NotFound)
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
