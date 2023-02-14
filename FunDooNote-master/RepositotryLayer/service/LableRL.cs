using RepositotryLayer.contest;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositotryLayer.service
{
    public class LableRL: IlableRL
    {
        private readonly fundocontext fundocontext;

        public LableRL(fundocontext fundocontext)
        {
            this.fundocontext = fundocontext;
        }

        public LableEntity AddLable(long userId, string lableName)
        {
            var checkuser = fundocontext.usertable.Where(x => x.UserId == userId).FirstOrDefault();
            try
            {
                if (checkuser != null)
                {
                    LableEntity lableEntity = new LableEntity();
                    lableEntity.UserId = checkuser.UserId;
                    lableEntity.LableName = lableName;
                    
                    fundocontext.LableTable.Add(lableEntity);
                    fundocontext.SaveChanges();
                    return lableEntity;
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

        public LableEntity EditLable(long userId, long lableId, string newName)
        {
            try
            {
                var checkLable = fundocontext.LableTable.Where(x => x.LableId == lableId && x.UserId == userId).FirstOrDefault();
                if (checkLable != null)
                {
                    checkLable.LableName = newName;
                   // fundocontext.LableTable.Add(checkLable);
                    fundocontext.SaveChanges();
                    return checkLable;
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
        public IEnumerable<LableEntity> ViewLable(long userId)
        {
            try
            {
                var checkuser = fundocontext.LableTable.Where(x => x.UserId == userId).ToList();
                if (checkuser != null)
                {
                    return checkuser;
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
        public bool DeleteLable(long userId, long lableId)
        {
            try
            {
                var checklable = fundocontext.LableTable.Where(x => x.UserId == userId && x.LableId == lableId).FirstOrDefault();
                if (checklable != null)
                {
                    fundocontext.LableTable.Remove(checklable);
                    fundocontext.SaveChanges();
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

        public bool AddNoteInLable(long userId,long lableId, long noteId)
        {
            try
            {
                var checklable = fundocontext.LableTable.Where(x => x.LableId == lableId && x.UserId==userId).FirstOrDefault();
                if (checklable != null)
                {
                    NoteLableEntity noteLableEntity = new NoteLableEntity();
                    noteLableEntity.LableId = lableId;
                    noteLableEntity.NoteId = noteId;
                    fundocontext.NoteLableTable.Add(noteLableEntity);
                    fundocontext.SaveChanges();
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
