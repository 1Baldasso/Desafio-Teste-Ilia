using Desafio_Teste_Ilia.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Testes
{
    [TestClass]
    public class AlocacaoTest
    {
        [TestMethod]
        public void AlocacaoVMShouldValidateTimeInputString()
        {
            string Input = "PT69H35M5S";
            string Input2 = "PT22D69H35M5S";
            AlocacaoVM vm = new AlocacaoVM { Tempo = Input };
            AlocacaoVM vm2 = new AlocacaoVM { Tempo = Input2 };
            Assert.AreEqual(new TimeSpan(69, 35, 05), vm.Transform().Tempo);
            Assert.AreEqual(new TimeSpan(22,69, 35, 05), vm2.Transform().Tempo);
        }
    }
}
