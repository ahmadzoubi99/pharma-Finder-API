using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaFinder.Core.Data;


namespace PharmaFinder.Core.Service
{
    public interface IJWTService
    {

        string Auth(User user);
    }
}
