using TechTalk.SpecFlow;

namespace Amarok.Bootstrap.Specs.Home
{
    [Binding]
    public class EntrarNaHomeComSucesso
    {
        [When(@"eu acessar a home do site")]
        public void QuandoEuAcessarAHomeDoSite()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"preciso ver o texto ""(.*)""")]
        public void EntaoPrecisoVerOTexto(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
