using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergyChecker.Models
{
    public enum Tariff
    {
        ESB = 18, Energia = 14, SSE = 17, ElectricIreland = 16
    }
    public class usersAppliances
    {
        public int usersAppliancesID { get; set; }
        public int ApplianceID { get; set; }
        public int UserID { get; set; }
        public Tariff? Tariff { get; set; }

        public virtual Appliance Appliance { get; set; }
        public virtual User User { get; set; }
    }
}