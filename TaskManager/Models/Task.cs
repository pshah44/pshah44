using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TaskManager.Models
{
    public class Task
    {
       public int TaskId { get; set; }        
       [Required, StringLength(240,ErrorMessage ="Description Should not be more then 240 characters")]
        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }

    }
}
