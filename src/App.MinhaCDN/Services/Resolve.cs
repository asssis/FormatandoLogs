using App.MinhaCDN.Interfaces;
using App.MinhaCDN.Services;
using System.Linq; 

namespace App.MinhaCDN
{
    public class Resolve : IResolve
    {
        public string CampoA()
        { 
            return $"\"MINHA CDN\"";
        } 
        public string CampoB(string campo_d, string campo_b)
        {
            string[] newCampo = campo_d.Split(" ");
            newCampo = newCampo.Select(x => x.Replace("\"", "")).ToArray();  
            return $" {newCampo[0]} {campo_b} {newCampo[1]}";
        } 
        public  string CampoC(string campo_e)
        { 
            return $" {campo_e.Substring(0, 3)}";
        }

        public string CampoE(string campo_a)
        {
            return $" {campo_a}";
        } 
        public string CampoD(string campo_c)
        {
            return $" {campo_c}\r\n";
        }
    }
}
