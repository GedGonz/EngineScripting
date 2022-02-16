using Microsoft.CodeAnalysis.Scripting;
using ServicesEngine.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesEngine.Engine
{
    public class EngineBase
    {
        public ScriptOptions Options() {

            var scriptOptions = ScriptOptions.Default;

            var mscorlib = typeof(object).GetTypeInfo().Assembly;
            var systemCore = typeof(System.Linq.Enumerable).GetTypeInfo().Assembly;
            var Base = typeof(User).Assembly;
            var references = new[] { mscorlib, systemCore, Base };
            scriptOptions = scriptOptions.AddReferences(references);
            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Linq");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");
            scriptOptions = scriptOptions.AddImports("ServicesEngine.utils");
            return scriptOptions;
        }
    }
}
