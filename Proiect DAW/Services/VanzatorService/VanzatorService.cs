using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.VanzatorService
{
    public class VanzatorService: IVanzatorService
    {
        public IUnitOfWork _unitOfWork;
        public VanzatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Vanzator newVanzator)
        {
            await _unitOfWork.VanzatorRepository.CreateAsync(newVanzator);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Vanzator>> GetAll()
        {
            return await _unitOfWork.VanzatorRepository.GetAllAsync();
        }
    }
}
