using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergyChecker.Models
{
    public class User : Person
    {
        public virtual ICollection<usersAppliances> usersAppliances { get; set; }
    }
}