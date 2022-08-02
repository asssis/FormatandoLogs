using App.MinhaCDN.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.MinhaCDN.Services
{
    public class Validation : IValidation
    {
        public void CampoA(string newCampo)
        {
            int number;
            if (!Int32.TryParse(newCampo, out number))
                new Exception($"Campo Não Validado, era para ser apenas números {newCampo}");
        }
        public void CampoB(string newCampo)
        {
            string[] checkCampo = newCampo.Split(" ");
            if (checkCampo.Length < 3)
                new Exception($"Campo Não Validado {newCampo}");
        }
    }
}
