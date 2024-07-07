using log4net;
using log4net.Config;
using Microsoft.Playwright;

namespace PlaywrightApiTests.Clients
{
    internal abstract class ApiClientBase
    {
        protected IPlaywright? playwright;
        protected ILog logger;
        public abstract string BaseUrl { get; }

        public ApiClientBase()
        {
            BasicConfigurator.Configure();
            playwright = InitializePlaywright();
        }

        public IPlaywright InitializePlaywright() => Playwright.CreateAsync().Result;
    }
}
