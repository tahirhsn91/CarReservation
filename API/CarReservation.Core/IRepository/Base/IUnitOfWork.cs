using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository.Base
{
    public interface IUnitOfWork
    {
        ApplicationDbContext DBContext { get; }
        IRequestInfo RequestInfo { get; }

        IColorRepository ColorRepository { get; }
        IRideStatusRepository RideStatusRepository { get; }

        ICountryRepository CountryRepository { get; }
        IStateRepository StateRepository { get; }
        ICityRepository CityRepository { get; }

        IVehicleMakerRepository VehicleMakerRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        IVehicleBodyTypeRepository VehicleBodyTypeRepository { get; }
        IVehicleFeatureRepository VehicleFeatureRepository { get; }
        IVehicleTransmissionRepository VehicleTransmissionRepository { get; }
        IVehicleAssemblyRepository VehicleAssemblyRepository { get; }

        ITravelUnitRepository TravelUnitRepository { get; }
        IDistanceUnitRepository DistanceUnitRepository { get; }
        IDriverStatusRepository DriverStatusRepository { get; }

        ICreditCardRepository CreditCardRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        ICurrencyLogRepository CurrencyLogRepository { get; }

        Task<int> SaveAsync();
        int Save();
        DbContextTransaction BeginTransaction();
    }
}
