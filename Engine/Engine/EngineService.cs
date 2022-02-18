using Microsoft.CodeAnalysis.CSharp.Scripting;
using ServicesEngine.utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesEngine.Engine
{
    public class EngineService : EngineBase, IEngineService
    {
        public async Task<object> ExecuteOnlyFuntion(string SciptTxt)
        {
            var user = new User();
            var option = Options();

            var nameMethod = GetNameMethod(SciptTxt);

            var script = CSharpScript.Create(SciptTxt, option, typeof(User));
                script = script.ContinueWith(@"
                public object getUser()
                {

                    var result = new List<string>();
                    var usersObject = User.GetUsers();
                    var userText = User.GetUsersText();

                    for (var i = 0; i < userText.Count; i++)
                    {
                        if (!"+ nameMethod + @"(usersObject, userText[i]))
                             result.Add(userText[i]);

                    }
                    return result;
                }");

            script = script.ContinueWith("return getUser();");
            var complie = script.Compile();

            if (complie.Length > 0)
                return new { ReturnValue = complie.Select(x => x.GetMessage()).Aggregate((current, value) => $"{current},{value}") };
            
                var result = await script.RunAsync(user);

            return new { result.ReturnValue };
        }

        public async Task<object> Execute(string SciptTxt)
        {
            var option = Options();
            var script = CSharpScript.Create(SciptTxt, option);
            var complie = script.Compile();
            if (complie.Length > 0)
                return new { ReturnValue = complie.Select(x => x.GetMessage()).Aggregate((current, value) => $"{current},{value}") };

            var result = await script.RunAsync();
            return new { result.ReturnValue };
        }

        public object getUser()
        {

            var result = new List<string>();
            var usersObject = User.GetUsers();
            var userText = User.GetUsersText();

            for (var i = 0; i < userText.Count; i++)
            {
                if (!Convertir1(usersObject, userText[i]))
                     result.Add(userText[i]);

            }
            return result;
        }

        public bool Convertir1(List<User> user,string lu1) => (user.Any(x => ($"{x.name[0].ToString().ToLower()}{x.lastname.ToLower()}") == lu1));

        private static string GetNameMethod(string SciptTxt) {
            int first = SciptTxt.IndexOf("bool") + "bool".Length;
            int last = SciptTxt.LastIndexOf("}");
            return  SciptTxt.Substring(first, last - first).Split('(')[0];
        }

    }
}
