using System;
using TaskManagement.API.DataLayer.Base;

namespace TaskManagement.API.DataLayer.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public DateTime DateAdded { get; set; }
        public string CommentDescription { get; set; }
        public CommentType CommentType { get; set; }
        public DateTime ReminderDate { get; set; }
    }

    public enum CommentType
    {
        
    }
}
