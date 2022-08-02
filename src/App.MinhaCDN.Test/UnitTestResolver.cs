using App.MinhaCDN.Interfaces;
using App.MinhaCDN.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;
using Xunit;

namespace App.MinhaCDN.Test
{
    public class UnitTestResolver
    {
        public readonly IResolve Resolve;
        public UnitTestResolver()
        {
            Resolve = new Resolve();
        }
        [Fact]
        public void TestandoLinnhaA()
        { 
            string Result = Resolve.CampoA(); 
            Assert.Equal(Result, $"\"MINHA CDN\"");
        }

        [Theory(DisplayName = "Testando Campo B")] 
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2")]
        public void TestandoLinnhaB(string Linha)
        {  
            string[] Campos = Linha.Split("|");
            string Result = Resolve.CampoB(Campos[3], Campos[1]);
            string ResultEsperado = " GET 200 /robots.txt";
            Assert.Equal(Result, ResultEsperado);
        }


        [Theory(DisplayName = "Testando Campo C")] 
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2")]
        public void TestandoLinnhaC(string Linha)
        {
            string[] Campos = Linha.Split("|");
            string Result = Resolve.CampoC(Campos[4]);
            string ResultEsperado = " 100";
            Assert.Equal(Result, ResultEsperado);
        }

        [Theory(DisplayName = "Testando Campo D")]
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2")]
        public void TestandoLinnhaD(string Linha)
        {
            string[] Campos = Linha.Split("|");
            string Result = Resolve.CampoD(Campos[2]);
            string ResultEsperado = " HIT\r\n";
            Assert.Equal(Result, ResultEsperado);
        }
        [Theory(DisplayName = "Testando Campo E")]
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2")]
        public void TestandoLinnhaE(string Linha)
        {
            string[] Campos = Linha.Split("|");
            string Result = Resolve.CampoD(Campos[0]);
            string ResultEsperado = " 312\r\n";
            Assert.Equal(Result, ResultEsperado);
        }
    } 
}
