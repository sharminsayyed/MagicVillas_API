using MagicVillaAPI.Data;
using MagicVillaAPI.Model;
using MagicVillaAPI.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        // create an endpoint
        // get - used to get all the villas info
        [HttpGet]
        public IEnumerable<VillaDto> GetVillas()
        {
            return VillaStore.villalist;
        }

        // get the villa based on the id given 
        // will return only one set of result   
        [HttpGet("id")]
        public VillaDto GetVillaById(int id)
        {
            return VillaStore.villalist.FirstOrDefault(u => u.Id == id);
        }

    }
}
