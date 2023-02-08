using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.LocatieService
{
    public class LocatieService: ILocatieService
    {
        public IUnitOfWork _unitOfWork;
        public LocatieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Locatie newLocatie)
        {
            await _unitOfWork.LocatieRepository.CreateAsync(newLocatie);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Locatie>> GetAll()
        {
            return await _unitOfWork.LocatieRepository.GetAllAsync();
        }

    }
}
