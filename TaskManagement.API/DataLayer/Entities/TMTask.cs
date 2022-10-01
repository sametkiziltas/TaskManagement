using System;
using System.Collections.Generic;
using TaskManagement.API.DataLayer.Base;

namespace TaskManagement.API.DataLayer.Entities
{
    public class TMTask: BaseEntity<Guid>
    {
        public DateTime CreatedDate { get; set; }
        public string TaskDescription { get; set; }
        public StatusOfTask StatusOfTask { get; set; }        
        public TypeOfTask TypeOfTask { get; set; }        
        public List<Comment> Comments{ get; set; }
        public string AssignedTo{ get; set; }
        public DateTime NextActionDate { get; set; }
        
    }
    

    public enum TypeOfTask
    {
        Story = 1,
        Bug = 2,
        Epic = 3
    }

    public enum StatusOfTask
    {
        Todo = 1,
        InDevelopment = 2,
        Test = 3,
        Done = 4
    }
}
