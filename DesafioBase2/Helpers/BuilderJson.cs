using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesafioBase2.Helpers
{
    public class BuilderJson
    {
        public static IConfigurationRoot configuration { get; set; } = null;
       
        //Metodo para retornar o valor do parametro no arquivo appsettings.json
        public static string ReturnParameterAppSettings(string param)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\Anderson da Silva\Source\Repos\DesafioBase2\DesafioBase2")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();

            return configuration[param].ToString();
        }

        public static void UpdateParameterAppSettings(string parameter, string newValue)
        {
            string json = File.ReadAllText(Directory.GetCurrentDirectory() + "/appsettings.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj[parameter] = newValue;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Directory.GetCurrentDirectory() + "/appsettings.json", output);
        }




      
    }
}
