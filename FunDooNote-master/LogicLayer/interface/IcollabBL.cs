using RepositotryLayer.entity;
using System.Collections.Generic;

namespace LogicLayer.Interface
{
    public interface IcollabBL
    {
        public CollabEntity AddCollaborator(string collabEmail, long noteId, long userId);
        public IEnumerable<CollabEntity> ViewCollaborator(long userId, long noteId);
        public bool RemoveCollaborator(string collabEmail, long userId, long noteId);
    }
}
