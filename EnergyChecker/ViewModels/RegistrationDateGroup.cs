using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnergyChecker.ViewModels
{
    public class RegistrationDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; set; }

        public int UserCount { get; set; }
    }
}