using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositotryLayer.entity
{
    public class NoteLableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteLableId { get; set;}

        [ForeignKey("lable")]
        public long LableId { get; set; }
        [JsonIgnore]
        public virtual LableEntity lable { get; set; }

        [ForeignKey("note")]
        public long NoteId { get; set; }
        [JsonIgnore]
        public virtual NoteEntity note { get; set; }
        

    }
}
