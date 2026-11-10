using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework02.Models
{
    [Table("EventOrganizers")]
    public class Organizer
    {
        [Key] public int OrganizerId { get; set; }
        [Required, MaxLength(100)] public string Name { get; set; }
        [MaxLength(150)] public string CompanyName { get; set; }
        public bool IsVerified { get; set; }
        public OrganizerProfile Profile { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
