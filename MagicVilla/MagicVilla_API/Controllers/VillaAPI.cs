using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    //[Route("api/controller")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPI : ControllerBase
    {
        //[HttpGet]
        //public ActionResult <IEnumerable<VillaDTO>> GetVillas()
        //{
        //    //return new List<VillaDTO>
        //    //{
        //    //    new VillaDTO {Id = 1, Name = "abc"},
        //    //    new VillaDTO {Id = 2, Name = "abc"}
        //    //};
        //    return Ok(VillaStore.villaList);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        //[HttpGet("{id:int}")]
        //passing the parameter id and the name of the method - get villa
        [HttpGet("id", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return NotFound();

            }
            
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);

            if(villa  == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
        {
            //model validation
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //custom model validation - i.e adding custom error message for teh model state
            if(VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                                      //key (key can be anything), error message
                ModelState.AddModelError("Error", "Villa already exists");
                return BadRequest(ModelState);
            }
            if(villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            else if(villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);

            //return Ok(villaDTO);
            return CreatedAtRoute("GetVilla" , new {id = villaDTO.Id}, villaDTO);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> DeleteVilla(int id)
        {
            if( id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }

            VillaStore.villaList.Remove(villa);
            return NoContent();
        }
    }
}
