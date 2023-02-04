﻿using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProducatorService
{
    public class ProducatorService: IProducatorService
    {
        public IUnitOfWork _unitOfWork;

        public ProducatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public async Task AddProducator(Producator newProducator)
        {
            await _unitOfWork.ProducatorRepository.CreateAsync(newProducator);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Producator>> GetAll()
        {
            var prod = await _unitOfWork.ProducatorRepository.GetAllAsync();
            return prod;
        }

        public async Task DeleteProducator(Guid ProducatorId)
        {
            var prod = await _unitOfWork.ProducatorRepository.FindByIdAsync(ProducatorId);

            if(prod != null)
                _unitOfWork.ProducatorRepository.Delete(prod);
            
            await _unitOfWork.SaveAsync();
        }
    }
}
