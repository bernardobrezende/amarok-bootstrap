using Coypu;
using TechTalk.SpecFlow;

namespace Amarok.Bootstrap.Specs.Home
{
    [Binding]
    public class EntrarNaHomeComSucesso
    {
        private BrowserSession browser;
        
        [BeforeScenario]
        public void Before()
        {
            browser = new BrowserSession(new SessionConfiguration { AppHost = "localhost", Port = 6660 });
        }

        [AfterScenario]
        public void AfterScenario()
        {
            browser.Dispose();
        }

        [When(@"eu acessar a home do site")]
        public void QuandoEuAcessarAHomeDoSite()
        {
            browser.Visit("/");            
        }

        [Then(@"preciso ver o texto ""(.*)""")]
        public void EntaoPrecisoVerOTexto(string p0)
        {
            browser.ShouldHaveContent(p0);            
        }
    }
}
