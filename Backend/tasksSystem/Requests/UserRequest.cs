using static Azure.Core.HttpHeader;
using System;
using tasksSystem.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace tasksSystem.Requests
{
    public class TaskRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public string taskStateId { get; set; }
    }
}
