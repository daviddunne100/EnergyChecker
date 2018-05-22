using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnergyChecker.Models
{
    public class Appliance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Appliance ID")]
        public int ApplianceID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string ApplianceTitle { get; set; }

        [Required(ErrorMessage = "Required field")]
        public String Make { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(0, 2500)]
        public int Watts { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(0, 1440)]
        public int MinutesUsedPerDay { get; set; }


        public virtual ICollection<usersAppliances> usersAppliances { get; set; }
    }
}