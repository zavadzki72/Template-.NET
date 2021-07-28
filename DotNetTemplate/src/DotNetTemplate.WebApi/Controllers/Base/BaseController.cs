using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.Enumerators;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetTemplate.WebApi.Controllers.Base {

    public class BaseController : ControllerBase {

        protected ActionResult ProcessResponse<T>(ServiceResult<T> result) {

            return result.Status switch {
                ServiceResultStatus.OK => Ok(new {
                    Data = result.Model,
                    Notifications = result.Notifications.Select(n => new {
                        Key = n.Key.ToString(),
                        Code = n.Message
                    })
                }),
                ServiceResultStatus.ERROR => BadRequest(new {
                    Data = "error",
                    Notifications = result.Notifications.Select(n => new {
                        Key = n.Key.ToString(),
                        Code = n.Message
                    })
                }),
                ServiceResultStatus.NOT_FOUND => NotFound(new {
                    Data = "not_found",
                    Notifications = result.Notifications.Select(n => new {
                        Key = n.Key.ToString(),
                        Code = n.Message
                    })
                }),
                _ => Problem(detail: "Caso não mapeado", statusCode: 500),
            };
        }

    }
}
