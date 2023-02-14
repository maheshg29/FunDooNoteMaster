using Microsoft.Extensions.Configuration;
using RepositotryLayer.contest;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositotryLayer.service
{
    
   public class CollabRL: IcollabRL
   {
        private readonly fundocontext _fundocontext;
       private readonly IConfiguration iconfiguration;
        public CollabRL(fundocontext _fundocontext, IConfiguration iconfiguration)
        {
            this._fundocontext = _fundocontext;
            this.iconfiguration = iconfiguration;
            // this.iconfiguration = iconfiguration;
        }

        public CollabEntity AddCollaborator(string collabEmail,long noteId, long userId)
        {
            try
            {
                
                var usercheck= _fundocontext.NoteTable.Where(x=> x.NoteId==noteId && x.UserId==userId).FirstOrDefault();
                var collabcheck= _fundocontext.usertable.Where(x => x.Email==collabEmail).FirstOrDefault();

                if (usercheck != null&& collabcheck != null)
                {
                    CollabEntity collabEntity = new CollabEntity();
                    collabEntity.CollabEmail = collabcheck.Email;
                    collabEntity.NoteId = usercheck.NoteId;
                    //collabEntity.UserId= usercheck.UserId;
                 

                    _fundocontext.CollabTable.Add(collabEntity);
                    _fundocontext.SaveChanges();
                    return collabEntity;
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
        public IEnumerable<CollabEntity> ViewCollaborator(long userId, long noteId)
        {
            try
            {
                var collabEntity = _fundocontext.CollabTable.Where(x =>  x.NoteId == noteId).ToList();
                if (collabEntity != null)
                {
                    return collabEntity;
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

        public bool RemoveCollaborator(string collabEmail, long userId, long noteId)
        {
            try
            {
                var collabEntity = _fundocontext.CollabTable.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (collabEntity != null)
                {
                    _fundocontext.CollabTable.Remove(collabEntity);
                    _fundocontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
