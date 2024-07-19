﻿using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PriceHistoryService : IPriceHistoryService
    {
        private readonly IPriceHistoryRepository iPriceHistoryRepository;
        public PriceHistoryService() => iPriceHistoryRepository = new PriceHistoryRepository();
        public void DeletePriceHistory(ProductPriceHistory priceHistory)
        {
            iPriceHistoryRepository.DeletePriceHistory(priceHistory);
        }

        public List<ProductPriceHistory> GetAllPriceHistories()
        {
            return iPriceHistoryRepository.GetAllPriceHistories();
        }

        public ProductPriceHistory? GetPriceHistoryById(int id)
        {
            return iPriceHistoryRepository.GetPriceHistoryById(id);
        }

        public void InsertPriceHistory(ProductPriceHistory priceHistory)
        {
            iPriceHistoryRepository.InsertPriceHistory(priceHistory);
        }

        public void UpdatePriceHistory(ProductPriceHistory priceHistory)
        {
            iPriceHistoryRepository.UpdatePriceHistory(priceHistory);
        }
    }
}
