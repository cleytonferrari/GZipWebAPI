using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using GZipWebAPI.Helpers;
using GZipWebAPI.Models;

namespace GZipWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        //Use o atributo ZipResult para comparctar o retorno da action
        [ZipResult]
        public IEnumerable<Pessoa> Get()
        {
            var retorno = new List<Pessoa>();
            for (var i = 0; i < 100; i++)
            {
                retorno.Add(new Pessoa()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Nome = RandomString(30)
                });
            }

            return retorno;
        }

        //http://stackoverflow.com/questions/1122483/random-string-generator-returning-same-string
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
