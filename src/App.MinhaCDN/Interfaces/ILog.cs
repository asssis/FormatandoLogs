using System;
using System.Collections.Generic;
using System.Text;

namespace App.MinhaCDN.Interfaces
{
    public interface ILog
    {
        public string ConverterLog(string Logs);
        public string SepararCampos(string Campos);
    }
}
