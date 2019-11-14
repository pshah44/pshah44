using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using Task = TaskManager.Models.Task;



namespace TaskManager.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext>options):base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}
