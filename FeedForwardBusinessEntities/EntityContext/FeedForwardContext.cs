using FeedForwardBusinessEntities.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FeedForwardBusinessEntities.EntityContext
{
    public class FeedForwardContext:DbContext
    {
        public DbSet<UserDetail> UserDetailInfo { get; set; }
        public DbSet<RoleDetail> RoleDetailInfo { get; set; }
        public DbSet<DesignationLevel> DesignationLevelInfo { get; set; }
        public DbSet<QuestionDetail> QuestionDetailInfo { get; set; }
        public DbSet<LevelDetail> LevelDetailInfo { get; set; }
        public DbSet<FeedBackCategoryLevel> FeedBackCategoryLevelInfo { get; set; }
        public DbSet<FeedbackSchedulingDetail> FeedBackSchedulingDetailInfo { get; set; }
        public DbSet<FeedbackSession> FeedbackSessionInfo { get; set; }
        public DbSet<FeedBackCaption> FeedbackInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-8JOUCH8\\MSSQLSERVER01;Database=FeedForward;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
