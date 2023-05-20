using System.Threading.Tasks;
using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LoginOneTime.Drivers
{
    // Cách không cần json nhưng vẫn login 1 lần được nm ko đc close context
  
    public class Driver1
    {
        public static string Email => "//input[@id='email']";
        public static string Password => "//input[@id='password']";
        public static string LoginBtn => "//button[@id='login-button']";
        public static string Profile => "//a[@id='profile__dropdown']";

        private static IPage? _page;
        private static IBrowser? _browser;
        private static IBrowserContext? _context;
        public IPage Page => _page;



        
        public static async Task BeforeFeature()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                SlowMo = 2000

            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
            await _page.GotoAsync("https://accounts.lambdatest.com/login");

            await _page.FillAsync(Email, "tranxuanviet91@gmail.com");
            await _page.FillAsync(Password, "123!@#qwE");
            await _page.ClickAsync(LoginBtn);
            await _page.IsVisibleAsync(Profile);
            await _page.ClickAsync(Profile);
            await _page.CloseAsync();

        }
       
        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                SlowMo = 2000

            });
            _page = await _context.NewPageAsync();
        }

      
        public async Task AfterScenario()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
        }

        public static async Task AfterFeature()
        {

            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }

}
