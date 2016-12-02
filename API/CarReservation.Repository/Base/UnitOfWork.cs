using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace CarReservation.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRequestInfo _requestInfo;

        private readonly IColorRepository _colorRepository;
        private readonly IRideStatusRepository _rideStatusRepository;

        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        private readonly IVehicleMakerRepository _vehicleMakerRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleBodyTypeRepository _vehicleBodyTypeRepository;
        private readonly IVehicleFeatureRepository _vehicleFeatureRepository;
        private readonly IVehicleTransmissionRepository _vehicleTransmissionRepository;
        private readonly IVehicleAssemblyRepository _vehicleAssemblyRepository;

        private readonly ITravelUnitRepository _travelUnitRepository;
        private readonly IDistanceUnitRepository _distanceUnitRepository;
        private readonly IDriverStatusRepository _driverStatusRepository;

        private readonly ICreditCardRepository _creditCardRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyLogRepository _currencyLogRepository;

        private readonly IAccountRepository _accountRepository;
        private readonly IAccountLogRepository _accountLogRepository;

        private readonly IFavouriteLocationRepository _favouriteLocationRepository;
        private readonly ILocationLagLonRepository _locationLagLonRepository;



        public ApplicationDbContext DBContext { get { return this._requestInfo.Context; } }
        public IRequestInfo RequestInfo { get { return this._requestInfo; } }

        public IColorRepository ColorRepository { get { return this._colorRepository; } }
        public IRideStatusRepository RideStatusRepository { get { return this._rideStatusRepository; } }

        public ICountryRepository CountryRepository { get { return _countryRepository; } }
        public IStateRepository StateRepository { get { return _stateRepository; } }
        public ICityRepository CityRepository { get { return _cityRepository; } }

        public IVehicleMakerRepository VehicleMakerRepository { get { return _vehicleMakerRepository; } }
        public IVehicleModelRepository VehicleModelRepository { get { return _vehicleModelRepository; } }
        public IVehicleBodyTypeRepository VehicleBodyTypeRepository { get { return _vehicleBodyTypeRepository; } }
        public IVehicleFeatureRepository VehicleFeatureRepository { get { return _vehicleFeatureRepository; } }
        public IVehicleTransmissionRepository VehicleTransmissionRepository { get { return _vehicleTransmissionRepository; } }
        public IVehicleAssemblyRepository VehicleAssemblyRepository { get { return _vehicleAssemblyRepository; } }

        public ITravelUnitRepository TravelUnitRepository { get { return _travelUnitRepository; } }
        public IDistanceUnitRepository DistanceUnitRepository { get { return _distanceUnitRepository; } }
        public IDriverStatusRepository DriverStatusRepository { get { return _driverStatusRepository; } }

        public ICreditCardRepository CreditCardRepository { get { return _creditCardRepository; } }

        public ICurrencyRepository CurrencyRepository { get { return _currencyRepository; } }
        public ICurrencyLogRepository CurrencyLogRepository { get { return _currencyLogRepository; } }

        public IAccountRepository AccountRepository { get { return _accountRepository; } }
        public IAccountLogRepository AccountLogRepository { get { return _accountLogRepository; } }

        public IFavouriteLocationRepository FavouriteLocationRepository { get { return _favouriteLocationRepository; } }
        public ILocationLagLonRepository LocationLagLonRepository { get { return _locationLagLonRepository; } }

        public UnitOfWork(
            IRequestInfo requestInfo,

            IColorRepository colorRepository,
            IRideStatusRepository rideStatusRepository,

            ICountryRepository countryRepository,
            IStateRepository stateRepository,
            ICityRepository cityRepository,

            IVehicleMakerRepository vehicleMakerRepository,
            IVehicleModelRepository vehicleModelRepository,
            IVehicleBodyTypeRepository vehicleBodyTypeRepository,
            IVehicleFeatureRepository vehicleFeatureRepository,
            IVehicleTransmissionRepository vehicleTransmissionRepository,
            IVehicleAssemblyRepository vehicleAssemblyRepository,

            ITravelUnitRepository travelUnitRepository,
            IDistanceUnitRepository distanceUnitRepository,
            IDriverStatusRepository driverStatusRepository,

            ICreditCardRepository creditCardRepository,
            ICurrencyRepository currencyRepository,
            ICurrencyLogRepository currencyLogRepository,

            IAccountRepository accountRepository,
            IAccountLogRepository accountLogRepository,

            IFavouriteLocationRepository favouriteLocationRepository,
            ILocationLagLonRepository locationLagLonRepository
            )
        {
            this._requestInfo = requestInfo;

            this._colorRepository = colorRepository;
            this._rideStatusRepository = rideStatusRepository;

            this._countryRepository = countryRepository;
            this._stateRepository = stateRepository;
            this._cityRepository = cityRepository;

            this._vehicleMakerRepository = vehicleMakerRepository;
            this._vehicleModelRepository = vehicleModelRepository;
            this._vehicleBodyTypeRepository = vehicleBodyTypeRepository;
            this._vehicleFeatureRepository = vehicleFeatureRepository;
            this._vehicleTransmissionRepository = vehicleTransmissionRepository;
            this._vehicleAssemblyRepository = vehicleAssemblyRepository;

            this._travelUnitRepository = travelUnitRepository;
            this._distanceUnitRepository = distanceUnitRepository;
            this._driverStatusRepository = driverStatusRepository;

            this._creditCardRepository = creditCardRepository;
            this._currencyRepository = currencyRepository;
            this._currencyLogRepository = currencyLogRepository;

            this._accountRepository = accountRepository;
            this._accountLogRepository = accountLogRepository;

            this._favouriteLocationRepository = favouriteLocationRepository;
            this._locationLagLonRepository = locationLagLonRepository;
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await DBContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(e.EntityValidationErrors.First().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        public int Save()
        {
            try
            {
                return DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.Entity.DbContextTransaction BeginTransaction()
        {
            return DBContext.Database.BeginTransaction();
        }
    }
}
