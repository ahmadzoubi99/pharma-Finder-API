using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public List<Home> GetAllHomes()
        {
            return _homeRepository.GetAllHomes();
        }

        public Home GetHomeById(decimal homeId)
        {
            return _homeRepository.GetHomeById(homeId);
        }

        public void CreateHome(Home homeData)
        {
            if (homeData == null)
            {
                throw new ArgumentNullException(nameof(homeData));
            }

            _homeRepository.CreateHome(homeData);
        }

        public void UpdateHome(Home homeData)
        {
            if (homeData == null)
            {
                throw new ArgumentNullException(nameof(homeData));
            }

            _homeRepository.UpdateHome(homeData);
        }

        public void DeleteHome(decimal homeId)
        {
            _homeRepository.DeleteHome(homeId);
        }
    }
}
