using OpenQA.Selenium;
using SpecFlowTestSuite.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.Support
{
    [Binding]
    public sealed class PhpTravelsHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _context;
        public PhpTravelsHooks(ScenarioContext context) => _context= context;
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            SeleniumDriver driver = new SeleniumDriver(_context);
            _context.Set(driver, "driver");
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _context.Get<IWebDriver>("WebDriver").Quit();
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}