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
        //sitas pabaigtas
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

        //sitas pabaigtas
        [Test]
        public void ZinutesPasirodymoTestas()
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

        //sitas pabaigtas
        [Test]
        public void PopUpPasirodymoTestas()
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

        //NEVEIKIA sitas neranda button "apmoketi" ir nerando klaidos zinutes boxo
        [Test]
        public void KlaidosTekstoTest()
        {
            _homePage.NavigateToDefaultPage()
                .FocusOnFrame()
                .NewsLetterClose()
                .SwitchBack()
                .ButtonLunaClick()
                .ButtonKrepselisClick()
                .AtsiskaitymasButtonClick()
                .LaukelisClick()
                .ButtonToWait()
                .ApmoketiButtonClick()
                .BoxToWait()
                .ZinutesTekstoTikrinimas();

        }

    }
}
