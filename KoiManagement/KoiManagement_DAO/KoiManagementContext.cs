using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO;

public partial class KoiManagementContext : DbContext
{
    public KoiManagementContext()
    {
    }

    public KoiManagementContext(DbContextOptions<KoiManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionCategory> CompetitionCategories { get; set; }

    public virtual DbSet<CompetitionRound> CompetitionRounds { get; set; }

    public virtual DbSet<CriteriaPoint> CriteriaPoints { get; set; }

    public virtual DbSet<Criteria> Criteria { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Prediction> Predictions { get; set; }

    public virtual DbSet<RefereeMark> RefereeMarks { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345678;database=KoiManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CriteriaPoint>(entity =>
        {
            entity.HasKey(cp => new { cp.RefereeMarkId, cp.CriteriaId });
        });
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });
        });
        modelBuilder.Entity<Prediction>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.User)
                  .WithMany(u => u.Predictions)
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.NoAction); 

            entity.HasOne(p => p.CompetitionRound)
                  .WithMany(cr => cr.Predictions)
                  .HasForeignKey(p => p.CompetitionRoundId)
                  .OnDelete(DeleteBehavior.Cascade); 
        });
        modelBuilder.Entity<RefereeMark>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.User)
                  .WithMany(u => u.RefereeMarks)
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.CompetitionRound)
                  .WithMany(u => u.RefereeMarks)
                  .HasForeignKey(p => p.CompetitionRoundId)
                  .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(p => p.Mark)
                  .WithMany(u => u.RefereeMarks)
                  .HasForeignKey(p => p.MarkId)
                  .OnDelete(DeleteBehavior.NoAction);
        });
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Result)
                  .WithMany(u => u.Achievements)
                  .HasForeignKey(p => p.ResultId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Koi)
                  .WithMany(cr => cr.Achievements)
                  .HasForeignKey(p => p.KoiId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.CompetitionRound)
                  .WithMany(u => u.Marks)
                  .HasForeignKey(p => p.CompetitionRoundId)
                  .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
