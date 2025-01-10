using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Display> Displays { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobRole> JobRoles { get; set; }

    public virtual DbSet<JobSystem> JobSystems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleDisplay> RoleDisplays { get; set; }

    public virtual DbSet<System> Systems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=127.0.0.1;database=demo_api_net_core;user=root;password=", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_vietnamese_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Display>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("display");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jobs");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Decription)
                .HasMaxLength(255)
                .HasColumnName("decription");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<JobRole>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.RoleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("job_role");

            entity.Property(e => e.JobId)
                .HasColumnType("int(11)")
                .HasColumnName("jobId");
            entity.Property(e => e.RoleId)
                .HasColumnType("int(11)")
                .HasColumnName("roleId");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
        });

        modelBuilder.Entity<JobSystem>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.SystemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("job_system");

            entity.Property(e => e.JobId)
                .HasColumnType("int(11)")
                .HasColumnName("jobId");
            entity.Property(e => e.SystemId)
                .HasColumnType("int(11)")
                .HasColumnName("systemId");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
        });

        modelBuilder.Entity<RoleDisplay>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.DisplayId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("role_display");

            entity.Property(e => e.RoleId)
                .HasColumnType("int(11)")
                .HasColumnName("roleId");
            entity.Property(e => e.DisplayId)
                .HasColumnType("int(11)")
                .HasColumnName("displayId");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("systems");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .HasColumnName("create_by");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasColumnType("int(11)")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(255)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
