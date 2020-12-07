using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2013.Models
{
    public class sol_Registration
    {
        public int sol_RegistrationId { get; set; }
        [Required]
        public string DepotName { get; set; }
        public string DepotAddress { get; set; }
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string ComputerName { get; set; }
        public string ProgramName { get; set; }
        public string ProgramVersion { get; set; } 
    }
}