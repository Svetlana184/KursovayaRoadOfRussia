using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class Response
    {
        public string? access_token { get; set; }
        public string? mail { get; set; }
        public Response(string? access_token, string? mail)
        {
            this.access_token = access_token;
            this.mail = mail;
        }
    }
}
