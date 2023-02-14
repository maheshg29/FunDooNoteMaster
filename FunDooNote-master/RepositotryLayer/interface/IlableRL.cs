using RepositotryLayer.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositotryLayer.Interface
{
    public interface IlableRL
    {
        public LableEntity AddLable(long userId, string lableName);
        public LableEntity EditLable(long userId, long lableId, string newName);
        public IEnumerable<LableEntity> ViewLable(long userId);
        public bool DeleteLable(long userId, long lableId);
        public bool AddNoteInLable(long userId, long lableId, long noteId);
    }
}
