using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurnBuilder.Models
{
    /// <summary>
    /// These are all the fields in Deck Table in the database. 
    /// </summary>
    public class Deck
    {
        [Key]
        public int DeckId { get; set; }
        public int CreatorUserId { get; set; }
        [MaxLength(50)]
        public string DeckName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string DeckColor { get; set; }
    }

    public enum Color
    {
        Blue,
        Black,
        Colorless,
        Green,
        Multicolor,
        Red,
        White
    }
}
