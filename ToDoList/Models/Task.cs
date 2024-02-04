using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{

    enum Priority
    {
        low,
        normal,
        high,
    }

    internal class Task
    {
        private string _userID { get; }
        private string _taskID { get; }



        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Priority TaskPriority { get; set; }


    }
}
