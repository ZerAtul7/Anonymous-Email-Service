using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_mailSystem.Models
{
    public class Plan
    {
        
        public int Id { get; set; }
        public string PlanName { get; set; }

        public bool Watermark { get; set; }

        public bool Attachments { get; set; }

        public int Messages { get; set; }

        public int Symbols { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
