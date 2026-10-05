using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class ReparationService :IReparationService
    {
        private readonly IReparationRepository _ReparationRepository;

        public ReparationService(IReparationRepository ReparationRepository)
        {
            _ReparationRepository = ReparationRepository;
        }


        public IList<Reparation> GetAllReparations()
        {

            return _ReparationRepository.GetAllReparations();
        }
        public void SaveReparation(Reparation Reparation)
        {
            _ReparationRepository.SaveReparation(Reparation);
        }

        public int GetReparationId(Reparation Reparation)
        {
            return Reparation.Id;
        }
        public void DeleteReparation(int id)
        {
            _ReparationRepository.DeleteReparation(id);

        }
    }
}
