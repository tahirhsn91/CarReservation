using CarReservation.Core.Model.Base;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class ApplicationUser : IdentityUser, IAuditModel<string>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public virtual string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
