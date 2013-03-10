using System.Web.Http;
using Longsor.Data.Contracts;

namespace Longsor.Api.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ILongsorUow Uow { get; set; }
    }
}
