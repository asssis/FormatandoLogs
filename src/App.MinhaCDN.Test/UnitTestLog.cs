using App.MinhaCDN.Interfaces;
using App.MinhaCDN.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;
using Xunit;

namespace App.MinhaCDN.Test
{
    public class UnitTestLog
    {
       readonly ILog Log;
        public UnitTestLog()
        {
            Log = Program.InjecaoDepdencia();        
        }
        [Fact]
        public void TestandoLog()
        { 
            string ResultEsprado = File.ReadAllText(@"./LogsTest/ResultadLogs.txt");
            string Logs = File.ReadAllText(@"./LogsTest/Logs.txt");
            string Result = Log.ConverterLog(Logs);

            Assert.Equal(Result, ResultEsprado);

        }
        [Theory(DisplayName = "Testando Linha")] 
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2")] 
        public void TestandoLinha(string Linha)
        {
            string Result = Log.SepararCampos(Linha);
            string ResultEsperado = "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT\r\n";
            Assert.Equal(Result, ResultEsperado);
        }
    }
}
