using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_mailSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DefaultValue(30)]
        public int PlanExpireDays { get; set; }


        [DefaultValue(0)]
        public int MessagesSent { get; set; }

        public int PlanId { get; set; }
       
    }
}
