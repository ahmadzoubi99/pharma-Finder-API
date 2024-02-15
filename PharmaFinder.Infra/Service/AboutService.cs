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
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public List<About> GetAllAbouts()
        {
            return _aboutRepository.GetAllAbouts();
        }

        public About GetAboutById(decimal aboutId)
        {
            return _aboutRepository.GetAboutById(aboutId);
        }

        public void CreateAbout(About aboutData)
        {
            if (aboutData == null)
            {
                throw new ArgumentNullException(nameof(aboutData));
            }

            _aboutRepository.CreateAbout(aboutData);
        }

        public void UpdateAbout(About aboutData)
        {
            if (aboutData == null)
            {
                throw new ArgumentNullException(nameof(aboutData));
            }

            _aboutRepository.UpdateAbout(aboutData);
        }

        public void DeleteAbout(decimal aboutId)
        {
            _aboutRepository.DeleteAbout(aboutId);
        }
    }
}
