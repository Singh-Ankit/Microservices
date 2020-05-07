using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityContext
{
    public class SFeedbackDbContext: DbContext
    {
        public SFeedbackDbContext(DbContextOptions<SFeedbackDbContext> options) : base(options)
        {

        }

        public DbSet<LiveSession>  liveSessions { get; set; }
        public DbSet<SessionFeedback> sessionFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<SessionFeedback>()
            //.HasOne(p => p.liveSession)
            //.WithMany(b => b.)
            //.HasForeignKey(p => p.BlogForeignKey);
        }
    }
}
