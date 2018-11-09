using System;
using System.Collections.Generic;
using System.Text;
using Material_Sharing.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Material_Sharing.DAL.Data
{
    public class ApplicationDataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options)
            : base(options){}

        public DbSet<LectureNote> LectureNotes {get;set;}
        public DbSet<LectureNoteRating> LectureNoteRatings {get;set;}
        public DbSet<LectureNoteTag> LectureNoteTags {get;set;}
        public DbSet<Comment> Comments {get;set;}
        public DbSet<CommentLike> CommentLikes {get;set;}
        public DbSet<Tag> Tags {get;set;}
        public DbSet<SpecialtyNumber> SpecialtyNumbers {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CommentLike>().HasOne(t => t.Comment).WithMany(k => k.CommentLikes).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<LectureNoteRating>().HasOne(t => t.User).WithMany(k => k.Ratings).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>().HasOne(t => t.LectureNote).WithMany(k => k.Comments).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}
