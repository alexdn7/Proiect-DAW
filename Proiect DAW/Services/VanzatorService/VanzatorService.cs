using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Repositories;
using System;
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

        public async Task<bool> Update(Guid VanzatorID, VanzatorDto vanzator)
        {
            var _vanzator = await _unitOfWork.VanzatorRepository.FindByIdAsync(VanzatorID);
            if (_vanzator == null)
            {
                return false;
            }
            _vanzator.Nume = vanzator.Nume;
            _vanzator.Telefon = vanzator.Telefon;
            await _unitOfWork.SaveAsync();
            return true; 
        }

        public async Task Delete(Guid VanzatorID)
        {
            var vanzator = await _unitOfWork.LocatieRepository.FindByIdAsync(VanzatorID);
            await _unitOfWork.LocatieRepository.Delete(vanzator);
            await _unitOfWork.SaveAsync();
        }
    }
}
