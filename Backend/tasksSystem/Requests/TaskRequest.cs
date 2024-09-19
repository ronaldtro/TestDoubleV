using static Azure.Core.HttpHeader;
using System;
using tasksSystem.Models;

namespace tasksSystem.Requests
{
    public class UserRequest
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string names { get; set; }
        public string lastNames { get; set; }
        public string dateOfBirth { get; set; }
    }
}
