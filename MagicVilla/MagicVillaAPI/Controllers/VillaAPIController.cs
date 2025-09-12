using MagicVillaAPI.Data;
using MagicVillaAPI.Model;
using MagicVillaAPI.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch; // nuget package
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        // logger is already configured in the program.cs file
        // implementing the logger in the controller using dependency injection
        private readonly ILogger<VillaAPIController> _logger;
        public VillaAPIController(ILogger<VillaAPIController> logger)
        {
            _logger = logger;
        }
        // create an endpoint
        // get - used to get all the villas info
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // this is used to when we have to remove undocumented 

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");
            return Ok(VillaStore.villalist);
        }

        // get the villa based on the id given 
        // Name is used for createdatroute 
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
                _logger.LogError("Get villa error with id " + id);
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
            // used for cecking the data annotations it used when    [ApiController] this is not enabled
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if(VillaStore.villalist.FirstOrDefault(u => u.Name.ToLower() == villaDTo.Name.ToLower()) != null)
            {
                // this means the villa name already exists 
                ModelState.AddModelError("","Villa already exists!");
                return BadRequest(ModelState);
            }
            if (villaDTo == null)
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

            //return CreatedAtRoute("GetVillaById",new{id= villaDTo.Id} ,villaDTo);//201
            //content-type: application/json; charset=utf-8 
            //date: Sun,07 Sep 2025 19:12:20 GMT
            //location: https://localhost:7183/api/VillaAPI/3 
            //server: Kestrel

            return Ok(villaDTo);

        }


        // to the update all properties  the villa  
        [HttpPut("{id:int}",Name ="updatevilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villadto)
        {
            if(villadto == null || id != villadto.Id)
            {
                // if the id is not same then it is a bad request
                // and villa is null then also bad request
                return BadRequest();
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            //update the values
            villa.Name = villadto.Name;
            villa.Occupancy = villadto.Occupancy;
            villa.Sqft = villadto.Sqft;

            //return NoContent(); // 204 
            return Ok(villa);


        }

        // to update a single property of the villa
        [HttpPatch("{id:int}", Name = "updatepartialvilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchdto)
        {
            if (patchdto == null || id == 0)
            {
                return BadRequest();//400
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();//404
            }
            patchdto.ApplyTo(villa,ModelState);// apply the changes to the villa object and store errors in model state
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //return NoContent();//204
            return Ok(villa); // 200


        }



        // to delete a villa
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            VillaStore.villalist.Remove(villa);
            return NoContent();

        }


    }
}
