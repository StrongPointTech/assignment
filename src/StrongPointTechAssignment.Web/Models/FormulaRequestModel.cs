using System.ComponentModel.DataAnnotations;

namespace StrongPointTechAssignment.Web.Models
{   
    public class FormulaRequestModel
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Mass { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Velocity { get; set; }
    }
}
