using System;
using System.Collections.Generic;
using System.Text;

namespace App.MinhaCDN.Interfaces
{
    public interface IResolve
    {
        public string CampoA();
        public string CampoB(string campo_d, string campo_b);
        public string CampoC(string campo_e); 
        public string CampoE(string campo_a);
        public string CampoD(string campo_c);
    }
}
