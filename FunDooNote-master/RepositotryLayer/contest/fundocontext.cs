using Microsoft.EntityFrameworkCore;
using RepositotryLayer.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositotryLayer.contest
{
    public class fundocontext : DbContext
    {
        public fundocontext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<userentity> usertable{ get; set; }

        public DbSet<NoteEntity> NoteTable { get; set; }

        public DbSet<CollabEntity> CollabTable { get; set; }
        public DbSet<LableEntity> LableTable { get; set; }
        public DbSet<NoteLableEntity> NoteLableTable { get; set; }
       
    }
}
