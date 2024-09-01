using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Models
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext()
        {
        }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Proyects> Proyects { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<AuxiliarT> AuxiliarTs { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Operaciones> Operations { get; set; }
        public virtual DbSet<Operations_Rol> OperationRols { get; set; }
        public virtual DbSet<Module> Modules { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {

                entity.HasKey(e => e.idUser).HasName("PK_users");

                entity.ToTable("users");

                entity.Property(e => e.idUser).HasColumnName("idUser");
                entity.Property(e => e.password)
                .HasColumnType("integer")
                .HasColumnName("password");
                entity.Property(e => e.emailUser)
                .HasColumnType("character varying")
                .HasColumnName("emailUser");
                entity.Property(e => e.nameUser)
                .HasColumnType("character varying")
                .HasColumnName("nameUser");

                entity.HasOne(d => d.Rol).WithMany(d => d.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_users_rol_RolIdRol");

            });

            modelBuilder.Entity<Proyects>(entity =>
            {
                entity.HasKey(e => e.idProyect).HasName("PK_proyects");

                entity.ToTable("proyects");

                entity.Property(e => e.idProyect).HasColumnName("idProyect");
                entity.Property(e => e.nameProyect)
                .HasColumnType("character varying")
                .HasColumnName("nameProyect");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.idTask).HasName("PK_Task");

                entity.ToTable("tasks");

                entity.Property(e => e.idTask).HasColumnName("idTask");
                entity.Property(e => e.nameTask)
                .HasColumnType("character varying")
                .HasColumnName("nameTask");
                entity.Property(e => e.descriptionTask)
                .HasColumnType("character varying")
                .HasColumnName("descriptionTask");
                entity.Property(e => e.dateTask).HasColumnName("dateTask");
                entity.Property(e => e.dateTaskCompletion).HasColumnName("dateTaskCompletion");
                entity.Property(e => e.state).HasColumnType("character varying").HasColumnName("state");

                entity.HasOne(d => d.Proyects).WithMany(d => d.Tasks)
                .HasForeignKey(d => d.idProyect)
                .HasConstraintName("FK_Tasks_Comments");

                entity.HasOne(d => d.User).WithMany(d => d.tasks)
                .HasForeignKey(d => d.idUser)
                .HasConstraintName("FK_Tasks_User");

            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.idNotification).HasName("PK_Notification");

                entity.ToTable("notifications");

                entity.Property(e => e.idNotification).HasColumnName("idNotification");
                entity.Property(e => e.nameNotification)
                .HasColumnType("character varying")
                .HasColumnName("nameNotification");
                entity.Property(e => e.descriptionNotification).HasColumnName("descriptionNotification");

                entity.HasOne(d => d.User).WithMany(d => d.Notification)
                .HasForeignKey(d => d.idUSer)
                .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.idComment).HasName("PK_Comment");

                entity.ToTable("comments");

                entity.Property(e => e.idComment).HasColumnName("idComment");
                entity.Property(e => e.descriptionCommet)
                .HasColumnType("character varying")
                .HasColumnName("descriptionCommet");

                entity.HasOne(d => d.Tasks).WithMany(d => d.Comment)
                .HasForeignKey(d => d.idTask)
                .HasConstraintName("FK_Tasks_Comments");
            });
            modelBuilder.Entity<AuxiliarT>(entity =>
            {
                entity.HasKey(e => e.idAuxiliar).HasName("PK_Auxiliar");

                entity.ToTable("auxiliarT");

                entity.HasOne(e => e.User).WithMany(e => e.AuxiliarT)
                .HasForeignKey(e => e.idUser)
                .HasConstraintName("FK_Auxiliart_User");

                entity.HasOne(e => e.Proyect).WithMany(e => e.AuxiliarT)
                .HasForeignKey(e => e.idProyect)
                .HasConstraintName("FK_Auxiliart_Proyect");
            });
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol).HasName("PK_Rol");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");
                entity.Property(e => e.nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            });
            modelBuilder.Entity<Operaciones>(entity =>
            {
                entity.HasKey(e => e.IdOperaciones).HasName("PK_Operaciones");

                entity.ToTable("operaciones");

                entity.HasOne(e => e.Rol).WithMany(e => e.Operacion)
                .HasForeignKey(e => e.IdRol)
                .HasConstraintName("FK_Operaciones_Rol");

                entity.HasOne(e => e.OperationsRol).WithMany(e => e.Operaciones)
                .HasForeignKey(e => e.IdOperationRol)
                .HasConstraintName("FK_Operaciones_OperationRol");
            });
            modelBuilder.Entity<Operations_Rol>(entity =>
            {
                entity.HasKey(e => e.IdOperationsRol).HasName("PK_OperationRol");

                entity.ToTable("operation_rol");

                entity.Property(e => e.NameOperationRol)
                .HasColumnName("NameOperationRol");
                entity.HasOne(e => e.Module).WithMany(e => e.OperationsRol)
                .HasForeignKey(e => e.IdModulo)
                .HasConstraintName("FK_OperationRol_Module");
            });
            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.IdMod).HasName("PK_Module");

                entity.ToTable("module");

                entity.Property(e => e.NameMod)
                .HasColumnType("character varying")
                .HasColumnName("nameModule");
            });
        }
    }
}
