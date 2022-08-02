using App.MinhaCDN.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App.MinhaCDN.Services
{
    public class Log : ILog
    { 
        private readonly IResolve Resolve;
        Validation Validation = new Validation();
        public Log(IResolve _Resolve)
        {
            Resolve = _Resolve;
        }
        public string ConverterLog(string Logs)
        { 
            //SEPARANDO AS LINHAS DO LOGS
            string[] linhas = Logs.Split("\r\n");

            //USANDO O AGGREGATE AO INVÊS DO FOR PARA PECORRER TODAS LINHAS
            //ESSE METODO ESTÁ SENDO AUXILIDADO PELO SEPARAR CAMPOS, DESSA FORMA
            //O METODO FAZ APENAS O QUE É DE ESPECIALIDADE DELE
            Logs = linhas.Aggregate(
                            seed: "",
                            func: (acc, x) => acc + SepararCampos(x));
            return Logs;
        }
        public string SepararCampos(string Campos)
        {
            //AQUI SEPARAMOS OS CAMPOS TRANSFORMANDO EM ARRAY PARA DEPOIS FAZER O TRATAMENTO
            string[] CpArr = Campos.Split("|");
            string linha = string.Empty;

            //NESSA ETAPA O SISTEMA VALIDA OS CAMPOS INCOPATIVEL
            // OBS PARA NÃO ENCHER MUITO, EU FIZ APENAS DE DOIS, MAIS A IDEIA É VALIDAR O MAXIMO POSSIVEL
            //E TODA VEZ QUE ENCONTRAR ALGUM ERRO, COLOCAR PARA O LOG NÃO TRANSMITIR O ERRO PARA FRENTE
            Validation.CampoA(CpArr[0]);
            Validation.CampoB(CpArr[3]);

            //ESSE METODO SERÁ AUXILIADO PELA INTERFACE RESOLVER, E DENTRE DELAS CRIAMOS METODOS
            //FAZENDO COM QUE O METODO CADA METODO TENHA SUA ESPECIALIDADE, E SEJA BLOQUEADA PELO CONTRATO IRESOLVE
            linha += Resolve.CampoA();
            linha += Resolve.CampoB(CpArr[3], CpArr[1]);
            linha += Resolve.CampoC(CpArr[4]);
            linha += Resolve.CampoE(CpArr[0]);
            linha += Resolve.CampoD(CpArr[2]);
            return linha;
        }
    }
}
