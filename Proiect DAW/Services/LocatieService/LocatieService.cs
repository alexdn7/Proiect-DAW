using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Repositories;
using System;
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

        public async Task<bool> Update(Guid LocatieID, LocatieDto locatie)
        {
            var _locatie = await _unitOfWork.LocatieRepository.FindByIdAsync(LocatieID);
            if (_locatie == null)
            {
                return false;
            }
            _locatie.Tara = locatie.Tara;
            _locatie.Oras = locatie.Oras;
            _locatie.Strada = locatie.Strada;
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task Delete(Guid LocatieID)
        {
            var _locatie = await _unitOfWork.LocatieRepository.FindByIdAsync(LocatieID);
            await _unitOfWork.LocatieRepository.Delete(_locatie);
            await _unitOfWork.SaveAsync();
        }
    }
}
