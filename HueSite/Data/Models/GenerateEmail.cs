using HueSite.Data.IServices;
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
            return @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""https://www.w3.org/1999/xhtml"">
<head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                
    <style>
        a, a:visited, a:link, a:active{
            text-decoration: none;
        }

        .mail-container {
            width: 100%;
        }

        .header {
            text-align: center;
            border-bottom: 1px solid #cc3380;
            margin-bottom: 1rem;
        }

        .header-text {
            font-weight: bold;
            color: #33cccc;
            font-size: 16px;
        }

        .text {
            text-align: center;
            font-size: 14px;
        }

        .mail-button {
            border-radius: 15px;
            margin: auto;
            padding: 10px;
            width: 120px;
            background-color: #cc3380;
            color: white;
            text-align: center;
            font-size: 16px;
            transition: 0.5s;
        }

            .mail-button:hover {
                background-color: #33cccc;
                color: aliceblue;
            }
    </style>
</head>
<body>
    <div class=""mail-container"">
          <div class=""header"">
            <p class=""header-text"">
                Hello! Thanks for registering at HueSite!
            </p>
        </div>
        <div class=""text"">
            <p>
                This message is auto-generated so responding to it isn't needed
                Your verification link is here:
            </p>
        </div>
        <a href = """ + ActivationLink + @""">
            <div class=""mail-button"">
                Activation Link
            </div>
        </a>
        <div style = ""text-align:center;"">
            <img src= ""https://img.icons8.com/bubbles/2x/programming-flag.png"" alt= ""icon"" />
        </ div>
    </ div>
</body>
</html>
";

        }
    }
}
