using System;
using System.ComponentModel.DataAnnotations;

namespace ApiNET.Models
{
    public interface IModel<T>
    {
        T Id { get; set; }
    }

    public interface IModel
     : IModel<long>
    {
    }

    public abstract class BaseModel
       : IModel
    {
        [Key]
        public long Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        [MaxLength(100)]
        public string CreateUser { get; set; }

        [MaxLength(100)]
        public string ModifyUser { get; set; }
    }
}