using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Operations
{
    public class TasksOperations
    {
        public ApplicationDbcontext _dbcontext;
        public TasksOperations(ApplicationDbcontext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var tasks = await _dbcontext.Tasks.AsNoTracking().ToListAsync();

            return tasks;
        }

        public async Task<Tasks> GetTask(int iduser)
        {
            var tasks = await _dbcontext.Tasks.FindAsync(iduser);

            return tasks;
        }

        public async Task<Tasks> CreateTask(Tasks task)
        {
            var tasks = await _dbcontext.Tasks.AddAsync(task);

            var tasks1 = _dbcontext.Tasks.Where(a => a.idTask == a.idTask).FirstOrDefault();

            if (task.dateTask == task.dateTaskCompletion)
            {
                task.state = "Terminada";
            }

            int maxTasksForUser = 5;

            var userTaskAcount = await _dbcontext.Tasks.CountAsync(a => a.idUser == task.idUser);
            if (userTaskAcount > maxTasksForUser)
            {

                if (tasks1 != null)
                {
                    tasks1.idUser = tasks1.idUser;
                }
            }

            await _dbcontext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateTask(TasksDto2 tasksDto)
        {
            Tasks? tasks = await _dbcontext.Tasks.FindAsync(tasksDto.idTask);

            if (tasks != null)
            {
                tasks.dateTaskCompletion = tasksDto.dateTaskCompletion;
                tasks.dateTask = tasksDto.dateTask;
                tasks.descriptionTask = tasksDto.descriptionTask;
                tasks.nameTask = tasksDto.nameTask;
                tasks.idProyect = tasksDto.idProyect;
                tasks.state = tasksDto.state;

                await _dbcontext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteTask(int idtask)
        {
            var result = await _dbcontext.Tasks.FindAsync(idtask);
            if (result == null)
            {
                return false;
            }

            _dbcontext.Tasks.Remove(result);

            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
