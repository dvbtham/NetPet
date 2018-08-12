using System.Collections.Generic;
using System.Linq;
using PetNet.Common.ViewModels;
using PetNet.Data.Infrastructure;
using PetNet.Data.Repositories;

namespace PetNet.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class StatisticService : IStatisticService
    {
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;

        public StatisticService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            return _orderRepository.GetRevenueStatistic(fromDate, toDate).ToList();
        }
    }
}