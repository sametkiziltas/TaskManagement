using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DataLayer.Base
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

    }
}
