using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("FavouriteLocation")]
    public class FavouriteLocationController : BaseController<IFavouriteLocationService, FavouriteLocationDTO, FavouriteLocation>
    {
        public FavouriteLocationController(IFavouriteLocationService service)
            : base(service)
        {
            this._service = service;
        }

        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async override Task<FavouriteLocationDTO> Post(FavouriteLocationDTO dtoObject)
        {
            dtoObject.User = await this.GetCurrentUser();
            return await base.Post(dtoObject);
        }

        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async override Task<FavouriteLocationDTO> Put(FavouriteLocationDTO dtoObject)
        {
            dtoObject.User = await this.GetCurrentUser();
            return await base.Put(dtoObject);
        }
    }
}
