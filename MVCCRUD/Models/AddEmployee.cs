using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Models
{
    public class AddEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter Name of the Employee")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Address of the Employee")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Designation of the Employee")]
        public string Designation { get; set; }

    }
}
