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
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.villalist);
        }

        // get the villa based on the id given 
        // will return only one set of result   
        [HttpGet("{id:int}" ,Name ="GetVillaByID")]
        // to document the possible status codes that a endpoint will return 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200 ,Type=typeof(VillaDto)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        public ActionResult<VillaDto> GetVillaById(int id)
        {
            if(id == 0)
            {
                // return a bad request 
                return BadRequest();// 400
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound(); // 404
            }
            return Ok(villa); // 200
        }

        // creating a new villa 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> createVilla([FromBody]VillaDto villaDTo)
        {
            if(villaDTo == null)
            {
                return BadRequest(villaDTo);
            }
            if(villaDTo.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // here we assign the villa id by getting the max id from the existing list and adding 1 to it
            villaDTo.Id = VillaStore.villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            // the new villa created to the villa store 
            VillaStore.villalist.Add(villaDTo);

            return CreatedAtRoute("GetVillaById",new{id= villaDTo.Id} ,villaDTo);//201


        }

    }
}
