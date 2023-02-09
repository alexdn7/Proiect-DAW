using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(Produs produs)
        {
            await _unitOfWork.ProdusRepository.CreateAsync(produs);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Produs>> GetAll()
        {
            return await _unitOfWork.ProdusRepository.GetAllAsync();
        }

        public async Task DeleteProdus(Guid id)
        {
            var prod = await _unitOfWork.ProdusRepository.FindByIdAsync(id);  
            
            if(prod != null) 
            {
                await _unitOfWork.ProdusRepository.Delete(prod);
            }

            await _unitOfWork.SaveAsync();
        }

        public List<Produs> GetAllProdusesWithPriceUnder(double pret)
        {
            return _unitOfWork.ProdusRepository.GetAllProdusesWithPriceUnder(pret);
        }

        public IEnumerable<IGrouping<Producator, Produs>> GroupByProducator()
        {
            return _unitOfWork.ProdusRepository.GroupByProducator();
        }
    }
}
