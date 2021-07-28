using DotNetTemplate.Domain.Model;
using DotNetTemplate.Domain.Model.ViewModels.Team;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Interfaces.Services {
    public interface ITeamApplicationService {

        Task<ServiceResult<List<TeamResponse>>> GetAll();

    }
}
