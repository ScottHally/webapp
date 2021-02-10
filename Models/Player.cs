using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Player
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z A-Z]*$", ErrorMessage = "Team name must begin with a capital letter")]
        [Required]
        [StringLength(30, ErrorMessage = "Team name must begin with a capital letter and be no more than 30 characters")]
        public string Team { get; set; }

        [Range(1,100000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        //refine this expression later?
        [RegularExpression(@"^[A-F][+-]?$", ErrorMessage = "Rating must be a in the form of a letter grade from A+ to F")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }

    }
}
