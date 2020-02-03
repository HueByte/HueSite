using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueSite.Data.IServices
{
    public interface IGenerateEmail
    {
        public string Generate(string ActivationLink);
    }
}
