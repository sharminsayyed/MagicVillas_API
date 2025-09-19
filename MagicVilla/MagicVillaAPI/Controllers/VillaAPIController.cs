using MagicVillaAPI.Data;
using MagicVillaAPI.Logging;
using MagicVillaAPI.Model;
using MagicVillaAPI.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    [Produces("application/json")] // forces JSON as the default response format
    public class VillaAPIController : ControllerBase
    {
        

        // using the self implemented logging 
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        //// using DI to implement the Ilogging interface 
        public VillaAPIController(ILogging logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        

        // create an endpoint
        // get - used to get all the villas info
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // this is used to when we have to remove undocumented 

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            //_logger.LogInformation("Getting all villas"); 
            //_logger.Log("Getting all villas","");
            
            return Ok(_db.Villas.ToList()); //EFcore

        }

        // get the villa based on the id given 
       
        [HttpGet("{id:int}" )]
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
                //_logger.LogError("Get villa error with id " + id);
                //_logger.Log("Get villa error with id " + id,"error");
                return BadRequest();// 400
            }
            //var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);//EFcore

            if (villa == null)
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
            if(_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTo.Name.ToLower()) != null)
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
            //villaDTo.Id = VillaStore.villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            // the new villa created to the villa store 
            

            //EFcore
            Villa model = new Villa()
            {
                Id = villaDTo.Id,
                Name = villaDTo.Name,
                Sqft = villaDTo.Sqft,
                Occupancy = villaDTo.Occupancy,
                Rate = villaDTo.Rate,
                Amenity = villaDTo.Amenity,
                ImageUrl = villaDTo.ImageUrl,
                Details = villaDTo.Details
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            

            return Ok(model);

        }


        // to the update all properties  the villa  
        [HttpPut("{id:int}")]
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
            
            //EFcore
            Villa model = new Villa()
            {
                Id = villadto.Id,
                Name = villadto.Name,
                Sqft = villadto.Sqft,
                Occupancy = villadto.Occupancy,
                Rate = villadto.Rate,
                Amenity = villadto.Amenity,
                ImageUrl = villadto.ImageUrl,
                Details = villadto.Details
            };
            _db.Villas.Update(model);
            _db.SaveChanges();

            //return NoContent(); // 204 
            return Ok(model);


        }

        //// to update a single property of the villa
        //[HttpPatch("{id:int}", Name = "updatepartialvilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status200OK)]

        //public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchdto)
        //{
        //    if (patchdto == null || id == 0)
        //    {
        //        return BadRequest();//400
        //    }
        //    //var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);

        //    // Efcore
        //    var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id); 
        //    VillaDto villadto = new VillaDto()
        //    {
        //        Id = villa.Id,
        //        Name = villa.Name,
        //        Sqft = villa.Sqft,
        //        Occupancy = villa.Occupancy,
        //        Rate = villa.Rate,
        //        Amenity = villa.Amenity,
        //        ImageUrl = villa.ImageUrl,
        //        Details = villa.Details
        //    };
        //    if (villa == null)
        //    {
        //        return NotFound();//404
        //    }

        //    patchdto.ApplyTo(villadto,ModelState);// apply the changes to the villa object and store errors in model state
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    Villa model = new Villa()
        //    {
        //        Id = villadto.Id,
        //        Name = villadto.Name,
        //        Sqft = villadto.Sqft,
        //        Occupancy = villadto.Occupancy,
        //        Rate = villadto.Rate,
        //        Amenity = villadto.Amenity,
        //        ImageUrl = villadto.ImageUrl,
        //        Details = villadto.Details
        //    };
            
        //    _db.Villas.Update(model);
        //    _db.SaveChanges();

        //    //return NoContent();//204
        //    return Ok(model); // 200


        //}



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
            //var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            //EFcore
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();

        }


    }
}
