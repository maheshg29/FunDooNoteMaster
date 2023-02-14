using RepositotryLayer.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositotryLayer.Interface
{
   public interface IcollabRL
    {
        public CollabEntity AddCollaborator(string collabEmail, long noteId, long userId);
        public IEnumerable<CollabEntity> ViewCollaborator(long userId, long noteId);
        public bool RemoveCollaborator(string collabEmail, long userId, long noteId);
    }
}
