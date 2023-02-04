using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProdusService
{
    public class ProdusService: IProdusService
    {
        public IUnitOfWork _unitOfWork;

        public ProdusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProdus(Produs produs)
        {
            await _unitOfWork.ProdusRepository.CreateAsync(produs);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProdus(Guid id)
        {
            var prod = await _unitOfWork.ProdusRepository.FindByIdAsync(id);  
            
            if(prod != null) 
            {
                _unitOfWork.ProdusRepository.Delete(prod);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
