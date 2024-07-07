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
            Setup();
            playwright = InitializePlaywright();
        }

        public static void Setup()
        {
            BasicConfigurator.Configure();
        }

        public IPlaywright InitializePlaywright() => Playwright.CreateAsync().Result;
    }
}
