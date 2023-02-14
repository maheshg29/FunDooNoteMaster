using CommonLayer.model;
using LogicLayer.Interface;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.service
{
   public class NoteBL : INoteBL
    {
        private readonly INoteRL inoteRL;
        public NoteBL(INoteRL inoteRL)
        {
            this.inoteRL = inoteRL;
        }
        public NoteEntity AddNote(NoteModel noteModel, long userId)
        {
            try
            {
                return inoteRL.AddNote(noteModel,userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<NoteEntity> ViewNote(long userId)
        {
            try
            {
                return inoteRL.ViewNote(userId);
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
                return inoteRL.ViewByNoteId(userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteNoteByNoteId(long userId, long noteId)
        {
            try
            {
                return inoteRL.DeleteNoteByNoteId(userId, noteId);
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public bool Trash(long userId, long noteId)
        {
            try
            {
                return inoteRL.Trash(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Pin(long userId, long noteId)
        {
            try
            {
                return inoteRL.Pin(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Archive(long userId, long noteId)
        {
            try
            {
                return inoteRL.Archive(userId, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NoteEntity AddColor(long userId, long noteId, string color)
        {
            try
            {
                return inoteRL.AddColor(userId, noteId, color);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NoteEntity UpdateNote(long userId, long noteId, NoteModel noteEntity)
        {
            try
            {
                return inoteRL.UpdateNote(userId, noteId, noteEntity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
