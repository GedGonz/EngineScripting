using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesEngine.Engine;
//using ServicesEngine;
using System.Threading.Tasks;

namespace EngineScriptingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineService _engine;
        public EngineController(IEngineService engine)
        {
            _engine = engine;
        }
        [HttpPost]
        [Route("ExcuteScriptFunction")]
        public async Task<object> ExcuteOnlyFuntionScript([FromBody] string script) => await _engine.ExecuteOnlyFuntion(script);

        [HttpPost]
        [Route("ExcuteScript")]
        public async Task<object> ExcuteScript([FromBody] string script) => await _engine.Execute(script);

    }
}
