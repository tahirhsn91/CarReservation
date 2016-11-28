using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Mapping
{
    public class CreditCardMap : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardMap()
        {
            //this.HasRequired(t => t.Country).WithMany(t => t.CreditCard).HasForeignKey(t => t.CountryId);
        }
    }
}
