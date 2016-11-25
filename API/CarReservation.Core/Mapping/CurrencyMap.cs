using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Mapping
{
    public abstract class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        //public CurrencyMap()
        //{
        //    this.HasRequired(t => t.Country)
        //        .WithMany(t=>t.Name)
        //        .HasForeignKey(t => t.CountryId);
        //}
    }
}
