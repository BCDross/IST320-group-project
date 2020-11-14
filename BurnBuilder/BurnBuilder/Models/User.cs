using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurnBuilder.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(500)]
        public string FirstName { get; set; }
        [StringLength(500)]
        public string LastName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

    }
}
