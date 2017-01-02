using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Package")]
    public class PackageController : BaseController<IPackageService, PackageDTO, Package>
    {
        public PackageController(IPackageService service)
            : base(service)
        {
            this._service = service;
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task<PackageDTO> Post(PackageDTO dtoObject)
        {
            return base.Post(dtoObject);
        }

        [HttpPut]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task<PackageDTO> Put(PackageDTO dtoObject)
        {
            return base.Put(dtoObject);
        }

        [HttpDelete]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
