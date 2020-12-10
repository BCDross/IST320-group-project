using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurnBuilder.Models
{
    /// <summary>
    /// These are all the fields in User Table in the database. 
    /// </summary>
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}
