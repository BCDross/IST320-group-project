using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurnBuilder.Models
{   
    /// <summary>
    /// These are all the fields in DeckCard Table in the database. 
    /// </summary>
    public class DeckCard
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; } 
        public int DeckId { get; set; }
        public int CardQuantity { get; set; }
    }
}
