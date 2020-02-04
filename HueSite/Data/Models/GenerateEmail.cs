using HueSite.Data.IServices;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.Models
{
    public class GenerateEmail : IGenerateEmail
    {
        public GenerateEmail() { }

        public string Generate(string ActivationLink)
        {
            string mail = File.ReadAllText($"{Directory.GetCurrentDirectory()}/MailTemplates/AuthEmail.html");
            return mail.Replace("<ActivationLink>", ActivationLink);
        }
    }
}
