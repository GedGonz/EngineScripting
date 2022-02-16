using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesEngine.Engine
{
    public interface IEngineService
    {
        Task<object> ExecuteOnlyFuntion(string SciptTxt);
        Task<object> Execute(string SciptTxt);
    }
}
