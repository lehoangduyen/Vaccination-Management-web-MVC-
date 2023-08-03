using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Covid19_Vaccination_Infogate_MVC.Helpers;
using Microsoft.AspNetCore.Http;

namespace Covid19_Vaccination_Infogate_MVC.Models
{
    public static class ModelLoader
    {
        public static void LoadPofileORG(this ISession session, string key, object value)
        {

            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
