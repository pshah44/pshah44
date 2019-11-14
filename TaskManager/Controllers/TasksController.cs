using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;
using Task = TaskManager.Models.Task;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
       private  TasksDbContext taskDBContext;

        public TasksController(TasksDbContext _tasksDbContext)
        {
            taskDBContext = _tasksDbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskDBContext.Tasks);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = taskDBContext.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (task == null)
            {
                return NotFound("No Records Found...");
            }
           return Ok(task);
          // return taskDBContext.Tasks.FirstOrDefault(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            taskDBContext.Tasks.Add(task);
            taskDBContext.SaveChanges(true);
            return Ok(StatusCodes.Status201Created);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           if (id!= task.TaskId) {
                BadRequest();                
            }
            try
            {
                taskDBContext.Tasks.Update(task);
                taskDBContext.SaveChanges(true);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record found against this Id...");
            }
            return Ok("Task updated");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = taskDBContext.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (task == null)
            {
                return NotFound("No Records Found...");
            }
            taskDBContext.Tasks.Remove(task);
            taskDBContext.SaveChanges();
            return Ok("Product Deleted...");

        }
    }
}
