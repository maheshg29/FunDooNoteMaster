using LogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using CommonLayer.model;
using System.Security.Claims;
using LogicLayer.service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using RepositotryLayer.entity;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace FunDoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly INoteBL iNoteBL;
        private readonly IDistributedCache distributedCache;

        public NoteController(INoteBL iNoteBL, IDistributedCache distributedCache)
        {
            this.iNoteBL = iNoteBL;
            this.distributedCache = distributedCache;
        }
        [Authorize]
        [HttpPost]
        [Route("AddNote")]
        public IActionResult AddNote(NoteModel noteModel)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.AddNote(noteModel, userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "New Note Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not Added." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("ViewNote")]
        public IActionResult ViewNote()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.ViewNote(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "View All Note", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not View" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ViewByNoteId")]
        public IActionResult ViewByNoteId(long noteId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.ViewByNoteId(userId, noteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "View Note For Given NoteID", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not View" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteByNoteId")]
        public IActionResult DeleteNoteByNoteId(long noteId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.DeleteNoteByNoteId(userId, noteId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Given Note ID Deleted Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not Delete" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Trash")]
        public IActionResult Trash(long noteId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.Trash(userId, noteId);
                if (result != null)
                {
                    if (result)
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Move to Trash ", data = result });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Remove From Trash ", data = result });
                    }
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not Move in Trash" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Pin")]
        public IActionResult Pin(long noteId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.Pin(userId, noteId);
                if (result != null)
                {
                    if (result)
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Pin ", data = result });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Unpin ", data = result });
                    }
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not Changes" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Archive")]
        public IActionResult Archive(long noteId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.Archive(userId, noteId);
                if (result != null)
                {
                    if (result)
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Archive", data = result });
                    }
                    else
                    {
                        return Ok(new { success = true, message = "Given NoteID's Note Undo", data = result });
                    }
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not Archive" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("AddColor")]
        public IActionResult AddColor(long noteId, string color)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.AddColor(userId, noteId, color);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Given NoteID's color change Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note color not change" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote(long noteId, NoteModel noteEntity)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBL.UpdateNote(userId, noteId, noteEntity);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Given Data updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note Not change" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("cachNote")]
        public async Task<IActionResult> ViewNoteCach()
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                IEnumerable<NoteEntity> cachNotes;
                string SerializeData;
                string key = userId.ToString();
                var EncodedData= await distributedCache.GetAsync(key);

                if (EncodedData != null)
                {
                    SerializeData = Encoding.UTF8.GetString(EncodedData);
                    cachNotes = JsonConvert.DeserializeObject<IEnumerable<NoteEntity>>(SerializeData);
                }
                else 
                {
                    cachNotes = iNoteBL.ViewNote(userId);
                    if (cachNotes != null)
                    {
                        SerializeData = JsonConvert.SerializeObject(cachNotes);
                        EncodedData = Encoding.UTF8.GetBytes(SerializeData);
                        var option=new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(2)).SetAbsoluteExpiration(DateTime.Now.AddMinutes(10));
                        await distributedCache.SetAsync(key, EncodedData, option);
                    }

                }
                if (cachNotes != null)
                {
                    return Ok(new { success = true, message = "View All Note", data = cachNotes });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Note not View" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
