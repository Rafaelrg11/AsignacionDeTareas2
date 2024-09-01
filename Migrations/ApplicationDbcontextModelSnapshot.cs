using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AsignacionDeTareas2.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]

    public class ApplicationDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.AuxiliarT", b =>
            {
                b.Property<int>("idAuxiliar")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idAuxiliar"));

                b.Property<int>("idProyect")
                    .HasColumnType("integer");

                b.Property<int>("idUser")
                    .HasColumnType("integer");

                b.HasKey("idAuxiliar")
                    .HasName("PK_Auxiliar");

                b.HasIndex("idProyect");

                b.HasIndex("idUser");

                b.ToTable("auxiliarT", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Comments", b =>
            {
                b.Property<int>("idComment")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idComment");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idComment"));

                b.Property<string>("descriptionCommet")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("descriptionCommet");

                b.Property<int>("idTask")
                    .HasColumnType("integer");

                b.HasKey("idComment")
                    .HasName("PK_Comment");

                b.HasIndex("idTask");

                b.ToTable("comments", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Module", b =>
            {
                b.Property<int>("IdMod")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMod"));

                b.Property<string>("NameMod")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nameModule");

                b.HasKey("IdMod")
                    .HasName("PK_Module");

                b.ToTable("module", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Notifications", b =>
            {
                b.Property<int>("idNotification")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idNotification");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idNotification"));

                b.Property<string>("descriptionNotification")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descriptionNotification");

                b.Property<int>("idUSer")
                    .HasColumnType("integer");

                b.Property<string>("nameNotification")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nameNotification");

                b.HasKey("idNotification")
                    .HasName("PK_Notification");

                b.HasIndex("idUSer");

                b.ToTable("notifications", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.OperationsXd", b =>
            {
                b.Property<int>("IdOperaciones")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdOperaciones"));

                b.Property<int>("IdOperationRol")
                    .HasColumnType("integer");

                b.Property<int>("IdRol")
                    .HasColumnType("integer");

                b.HasKey("IdOperaciones")
                    .HasName("PK_Operaciones");

                b.HasIndex("IdOperationRol");

                b.HasIndex("IdRol");

                b.ToTable("operaciones", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Operations_Rol", b =>
            {
                b.Property<int>("IdOperationsRol")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdOperationsRol"));

                b.Property<int>("IdModulo")
                    .HasColumnType("integer");

                b.Property<string>("NameOperationRol")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("NameOperationRol");

                b.HasKey("IdOperationsRol")
                    .HasName("PK_OperationRol");

                b.HasIndex("IdModulo");

                b.ToTable("operation_rol", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Proyects", b =>
            {
                b.Property<int>("idProyect")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idProyect");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idProyect"));

                b.Property<string>("nameProyect")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nameProyect");

                b.HasKey("idProyect")
                    .HasName("PK_proyects");

                b.ToTable("proyects", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Rol", b =>
            {
                b.Property<int>("IdRol")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idRol");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRol"));

                b.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");

                b.HasKey("IdRol")
                    .HasName("PK_Rol");

                b.ToTable("rol", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Tasks", b =>
            {
                b.Property<int>("idTask")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idTask");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idTask"));

                b.Property<DateTime>("dateTask")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dateTask");

                b.Property<DateTime>("dateTaskCompletion")
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dateTaskCompletion");

                b.Property<string>("descriptionTask")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("descriptionTask");

                b.Property<int>("idProyect")
                    .HasColumnType("integer");

                b.Property<string>("nameTask")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nameTask");

                b.Property<string>("state")
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("state");

                b.HasKey("idTask")
                    .HasName("PK_Task");

                b.HasIndex("idProyect");

                b.ToTable("tasks", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Users", b =>
            {
                b.Property<int>("idUser")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("idUser");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idUser"));

                b.Property<int>("IdRol")
                    .HasColumnType("integer");

                b.Property<string>("emailUser")
                    .HasColumnType("character varying")
                    .HasColumnName("emailUser");

                b.Property<string>("nameUser")
                    .HasColumnType("character varying")
                    .HasColumnName("nameUser");

                b.Property<int>("password")
                    .HasColumnType("integer")
                    .HasColumnName("password");

                b.HasKey("idUser")
                    .HasName("PK_users");

                b.HasIndex("IdRol");

                b.ToTable("users", (string)null);
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.AuxiliarT", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Proyects", "Proyect")
                    .WithMany("AuxiliarT")
                    .HasForeignKey("idProyect")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Auxiliart_Proyect");

                b.HasOne("P_Asignación_de_Tareas.Models.Users", "User")
                    .WithMany("AuxiliarT")
                    .HasForeignKey("idUser")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Auxiliart_User");

                b.Navigation("Proyect");

                b.Navigation("User");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Comments", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Tasks", "Tasks")
                    .WithMany("Comment")
                    .HasForeignKey("idTask")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Tasks_Comments");

                b.Navigation("Tasks");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Notifications", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Users", "User")
                    .WithMany("Notification")
                    .HasForeignKey("idUSer")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Notification_User");

                b.Navigation("User");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.OperationsXd", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Operations_Rol", "OperationsRol")
                    .WithMany("Operaciones")
                    .HasForeignKey("IdOperationRol")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Operaciones_OperationRol");

                b.HasOne("P_Asignación_de_Tareas.Models.Rol", "Rol")
                    .WithMany("Operacion")
                    .HasForeignKey("IdRol")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Operaciones_Rol");

                b.Navigation("OperationsRol");

                b.Navigation("Rol");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Operations_Rol", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Module", "Module")
                    .WithMany("OperationsRol")
                    .HasForeignKey("IdModulo")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_OperationRol_Module");

                b.Navigation("Module");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Tasks", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Proyects", "Proyects")
                    .WithMany("Tasks")
                    .HasForeignKey("idProyect")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_Tasks_Comments");

                b.Navigation("Proyects");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Users", b =>
            {
                b.HasOne("P_Asignación_de_Tareas.Models.Rol", "Rol")
                    .WithMany("Users")
                    .HasForeignKey("IdRol")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired()
                    .HasConstraintName("FK_users_rol_RolIdRol");

                b.Navigation("Rol");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Module", b =>
            {
                b.Navigation("OperationsRol");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Operations_Rol", b =>
            {
                b.Navigation("Operaciones");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Proyects", b =>
            {
                b.Navigation("AuxiliarT");

                b.Navigation("Tasks");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Rol", b =>
            {
                b.Navigation("Operacion");

                b.Navigation("Users");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Tasks", b =>
            {
                b.Navigation("Comment");
            });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Users", b =>
            {
                b.Navigation("AuxiliarT");

                b.Navigation("Notification");
            });
#pragma warning restore 612, 618
        }
    }
}
