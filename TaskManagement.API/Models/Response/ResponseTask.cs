using System;
using System.Collections.Generic;
using TaskManagement.API.DataLayer.Entities;

namespace TaskManagement.API.Models.Response
{
    public class ResponseTask
    {
        public string TaskDescription { get; set; }
        public string CreatedDate { get; set; }
        public string? StatusOfTask { get; set; }        
        public string? TypeOfTask { get; set; }
    }
}
