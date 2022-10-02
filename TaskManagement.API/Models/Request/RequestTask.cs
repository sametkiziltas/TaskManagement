using System;

namespace TaskManagement.API.Models.Request
{
    public class RequestTask
    {
        public string TaskDescription { get; set; }
        public int? StatusOfTask { get; set; }        
        public int? TypeOfTask { get; set; }
        public string? AssignedTo { get; set; }
        public DateTime? NextActionDate { get; set; }
    }
}
