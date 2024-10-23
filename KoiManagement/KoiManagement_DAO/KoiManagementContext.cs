using KoiManagement_BusinessObjects;
using KoiManagement_BusinessObjects.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiManagement_DAO;

public partial class KoiManagementContext : IdentityDbContext
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

	public virtual DbSet<Round> Rounds { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(GetConnectionString());
		}
	}

	private string GetConnectionString()
	{
		IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", true, true)
			.Build();
		return configuration.GetConnectionString("KoiManagementConnection");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<CriteriaPoint>(entity =>
		{
			entity.HasKey(cp => new { cp.RefereeMarkId, cp.CriteriaId });
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
		modelBuilder.Entity<IdentityRole>(entity =>
		{
			entity.HasData(
				new IdentityRole
				{
					Name = Role.Admin,
					NormalizedName = Role.Admin.ToUpper()
				},
				new IdentityRole
				{
					Name = Role.Constestant,
					NormalizedName = Role.Constestant.ToUpper()
				},
				new IdentityRole
				{
					Name = Role.Referee,
					NormalizedName = Role.Referee.ToUpper()
				},
				new IdentityRole
				{
					Name = Role.Manager,
					NormalizedName = Role.Manager.ToUpper()
				});
		});
	}
}
