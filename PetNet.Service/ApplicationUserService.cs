﻿using System.Collections.Generic;
using PetNet.Data.Infrastructure;
using PetNet.Data.Repositories;
using PetNet.Model.Models;

namespace PetNet.Service
{
    public interface IApplicationUserService
    {
        ApplicationUser GetUserById(string userId);

        void UpdateCoin(string userId, int coin);

        ApplicationUser TransactionHistory(string userId);

        IEnumerable<string> GetUserIdByGroupId(int id);

        void SetViewed(string id);

        void IsDeleted(string id);

        void SaveChanges();
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;

        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(
            IApplicationUserRepository applicationUserRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationUserRepository = applicationUserRepository;
            _unitOfWork = unitOfWork;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _applicationUserRepository.GetSingleById(userId);
        }

        public IEnumerable<string> GetUserIdByGroupId(int id)
        {
            return _applicationUserRepository.GetUserIdByGroupId(id);
        }

        public void IsDeleted(string id)
        {
            var user = _applicationUserRepository.GetSingleById(id);
            user.IsDeleted = true;
            _applicationUserRepository.Update(user);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


        public void SetViewed(string id)
        {
            var user = _applicationUserRepository.GetSingleById(id);
            user.IsViewed = true;
            _applicationUserRepository.Update(user);
            SaveChanges();
        }

        public ApplicationUser TransactionHistory(string userId)
        {
            var query = _applicationUserRepository.GetSingleByCondition(x => x.Id == userId, new[] { "TransactionHistory" });

            return query;
        }

        public void UpdateCoin(string userId, int coin)
        {
            var user = GetUserById(userId);
            user.Coin += coin;
        }
    }
}