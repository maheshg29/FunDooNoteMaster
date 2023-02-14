using CommonLayer.model;
using RepositotryLayer.entity;
using System.Collections.Generic;

namespace RepositotryLayer.Interface
{
    public interface INoteRL
    {
        public NoteEntity AddNote(NoteModel noteModel, long userId);

        public IEnumerable<NoteEntity> ViewNote(long userId);

        public NoteEntity ViewByNoteId(long userId, long noteId);

        public bool DeleteNoteByNoteId(long userId, long noteId);

        public bool Trash(long userId, long noteId);

        public bool Pin(long userId, long noteId);

        public bool Archive(long userId, long noteId);

        public NoteEntity AddColor(long userId, long noteId, string color);

        public NoteEntity UpdateNote(long userId, long noteId, NoteModel noteEntity);
    }
}
