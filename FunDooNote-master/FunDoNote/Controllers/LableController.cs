using LogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FunDoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LableController : Controller
    {
        private readonly IlableBL ilableBL;
        
        public LableController(IlableBL ilableBL)
        {
            this.ilableBL = ilableBL;
        }
        [Authorize]
        [HttpPost]
        [Route("AddLable")]
        public IActionResult AddLable(string lableName)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = ilableBL.AddLable(userId,lableName);
                if (result != null)
                {
                    return Ok(new { success = true, message = "New Lable Added", data = result });
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
        [HttpPut]
        [Route("EditLable")]
        public IActionResult EditLable(long lableId,string lableName)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = ilableBL.EditLable(userId,lableId,lableName);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Lable Edit Successfully", data = result });
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
        [Route("ViewLable")]
        public IActionResult ViewLable()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = ilableBL.ViewLable(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "View All Lable", data = result });
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
        [HttpDelete]
        [Route("DeleteLable")]
        public IActionResult DeleteLable(long lableId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = ilableBL.DeleteLable(userId,lableId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Lable Delete Successfully", data = result });
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
        [HttpPost]
        [Route("AddNoteInLable")]
        public IActionResult AddNoteInLable(long lableId, long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = ilableBL.AddNoteInLable(userId, lableId, noteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Note Link with Lable Successfully", data = result });
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

    }
}
