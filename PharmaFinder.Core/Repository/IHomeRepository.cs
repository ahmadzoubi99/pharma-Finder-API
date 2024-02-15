using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IHomeRepository
    {
        List<Home> GetAllHomes();
        Home GetHomeById(decimal homeId);
        void CreateHome(Home homeData);
        void UpdateHome(Home homeData);
        void DeleteHome(decimal homeId);
    }
}
