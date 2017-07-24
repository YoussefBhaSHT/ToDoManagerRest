using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManagerRest.Models
{
    public class Task
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public int Status { set; get; }

    }
}
