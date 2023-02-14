using CommonLayer.model;
using LogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace FunDoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : Controller
    {
        private readonly IcollabBL icollabBL;

        public CollabController(IcollabBL icollabBL)
        {
            this.icollabBL = icollabBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddCollaborator")]
        public IActionResult AddCollaborator(string collabEmail,long noteId)
        {
            try
            {
               var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = icollabBL.AddCollaborator(collabEmail,noteId,userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "New Collaborator Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Something went Wrong." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ViewCollaborator")]
        public IActionResult ViewCollaborator(long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var collabEntity = icollabBL.ViewCollaborator(userId, noteId);

                if (collabEntity != null)
                {
                    return Ok(new { success = true, message = "View All note", data = collabEntity });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Something went Wrong." });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveCollaborator")]
        public IActionResult RemoveCollaborator(string collabEmail, long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
               
                var collabEntity = icollabBL.RemoveCollaborator(collabEmail, userId, noteId);

                if (collabEntity != null)
                {
                    return Ok(new { success = true, message = "Collabration Remove successfully", data = collabEntity });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Something went Wrong." });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

   
  