using System;
using System.Collections.Generic;
using TaskManagement.API.DataLayer.Entities;

namespace TaskManagement.API.Models.Response
{
    public class ResponseCreateTask
    {
        public DateTime CreatedDate { get; set; }
        public string TaskDescription { get; set; }
        public string StatusOfTask { get; set; }        
        public string TypeOfTask { get; set; }        
        public List<Comment> Comments{ get; set; }
        public string AssignedTo{ get; set; }
        public DateTime NextActionDate { get; set; }
    }
}
