using CommonLayer.model;
using RepositotryLayer.contest;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace RepositotryLayer.service
{
    public class NoteRL : INoteRL
    {
        private readonly fundocontext _fundocontext;

        public NoteRL(fundocontext fundocontext)
        {
           _fundocontext = fundocontext;
        }

        public NoteEntity AddNote(NoteModel note, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = note.Title;
                noteEntity.Description = note.Description;
                noteEntity.Archive = note.Archive;
                noteEntity.Reminder= note.Reminder;
                noteEntity.Color= note.Color;
                noteEntity.Image= note.Image;
                noteEntity.Trash = note.Trash;
                noteEntity.Pin = note.Pin;
                noteEntity.Created = DateTime.Now;
                noteEntity.Edited=DateTime.Now;
                noteEntity.UserId=userId;

                _fundocontext.NoteTable.Add(noteEntity);
                _fundocontext.SaveChanges();
                return noteEntity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NoteEntity> ViewNote(long userId)
        {
            try
            {
                // List<NoteEntity> noteEntities = new List<NoteEntity>();
                // noteEntities = _fundocontext.NoteTable.Where(x => x.UserId == userId);
                //return noteEntities;

                var result = _fundocontext.NoteTable.Where(x => x.UserId == userId);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public NoteEntity ViewByNoteId(long userId, long noteId)
        {
            try
            {
                NoteEntity noteEntity= new NoteEntity();
                noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();
                if (noteEntity != null)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        public bool DeleteNoteByNoteId(long userId, long noteId)
        {
            try
            {
                //NoteEntity noteEntity = new NoteEntity();
                var noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();

                if (noteEntity != null)
                {
                    _fundocontext.NoteTable.Remove(noteEntity);
                    _fundocontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Trash(long userId, long noteId)
        {
            try
            {
                var noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();

                if (noteEntity != null)
                {
                    if (noteEntity.Trash)
                    {
                        noteEntity.Trash = false;
                        _fundocontext.SaveChanges();

                        return false;
                    }
                    else
                    {
                        noteEntity.Trash = true;
                        _fundocontext.SaveChanges();
                        return true;
                    }
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Pin(long userId, long noteId)
        {
            try
            {
                var noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();

                if (noteEntity != null)
                {
                    if (noteEntity.Pin)
                    {
                         noteEntity.Pin = false;
                        _fundocontext.SaveChanges();

                        return false;
                    }
                    else
                    {
                        noteEntity.Pin = true;
                        _fundocontext.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public bool Archive(long userId, long noteId)
        {
            try
            {
                var noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();

                if (noteEntity != null)
                {
                    if (noteEntity.Archive)
                    {
                         noteEntity.Archive = false;
                        _fundocontext.SaveChanges();
                        return false;
                    }
                    else
                    {
                       noteEntity.Archive = true;
                        _fundocontext.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public NoteEntity AddColor(long userId, long noteId, string color)
        {
            try
            {
                var noteEntity = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).First();

                if (noteEntity != null)
                {
                    noteEntity.Color = color;
                    _fundocontext.SaveChanges();
                    return noteEntity;                               
                }               
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public NoteEntity UpdateNote(long userId, long noteId, NoteModel noteModel)
        {

            try
            {
                var noteEntityUpdate = _fundocontext.NoteTable.Where(x => x.UserId == userId && x.NoteId == noteId).FirstOrDefault();
                
                if (noteEntityUpdate != null)
                {
                   
                    noteEntityUpdate.Title= noteModel.Title;
                    noteEntityUpdate.Description= noteModel.Description;
                    noteEntityUpdate.Edited = DateTime.Now;
                    noteEntityUpdate.Archive= noteModel.Archive;
                    noteEntityUpdate.Pin= noteModel.Pin;
                    noteEntityUpdate.Trash= noteModel.Trash;
                    noteEntityUpdate.Color = noteModel.Color;
                    noteEntityUpdate.Reminder= noteModel.Reminder;
                    noteEntityUpdate.Image= noteModel.Image;
                   // _fundocontext.NoteTable.Update(noteEntityUpdate);
                    _fundocontext.SaveChanges();
                    return noteEntityUpdate;
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
                



        }

    }
}
