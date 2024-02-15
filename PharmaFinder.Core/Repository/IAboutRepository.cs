using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IAboutRepository
    {
        List<About> GetAllAbouts();
        About GetAboutById(decimal aboutId);
        void CreateAbout(About aboutData);
        void UpdateAbout(About aboutData);
        void DeleteAbout(decimal aboutId);
    }
}
