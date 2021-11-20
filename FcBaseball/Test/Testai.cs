using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcBaseball.Test
{
    public class Testai : BaseTest
    {
        [Test]
        public void KrepselioSumosTestas()
        {
            _homePage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .ButtonVoraiClick()
                .ButtonMaisasClick()
                .ButtonLunaClick()
                .TextToWait()
                .ButtonKrepselisClick();
            _krepselisPage.NavigateToDefaultPage()
                .Lyginimas("63.98");
        }

        [Test]
        public void ZinutesPasirodymoTest()
        {
            _homePage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .Marskineliai();
            _productPage.NavigateToDefaultPage()
                .PasirinktiDydiPagalValue("S")
                .MarskineliaiPirkti()
                .CheckText();
        }

        [Test]
        public void AlertPasirodymoTest()
        {
            _homePage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .Marskineliai();
            _productPage.NavigateToDefaultPage()
                .MarskineliaiPirkti()
                .CheckAlert();
        }

        [Test]
        public void KlaidosTekstoTest()
        {
            _homePage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .ButtonLunaClick()
                .ButtonKrepselisClick()
                .AtsiskaitymasButtonClick();
            _atsiskaitymasPage.NavigateToDefaultPage()
                .Wait()
                .WaitForButton()
                .ApmoketiButtonClick()
                .ZinutesTekstoTikrinimas();
        }

        [TestCase("vardasETApavyzdys.lt", TestName = "Netinkamas email formatas")]
        public void TinkamoEmailTest(string elpastas)
        {
            _productPage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .PasirinktiDydiPagalValue("M")
                .MarskineliaiPirkti();
            _atsiskaitymasPage.NavigateToDefaultPage()
                .IvestiEmail(elpastas)
                .Wait()
                .WaitForButton()
                .ApmoketiButtonClick()
                .Wait()
                .PatikrintiEmail();
        }

    }
}
