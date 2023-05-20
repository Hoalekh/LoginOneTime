using LoginOneTime.Drivers;
using LoginOneTime.Page;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
namespace LoginOneTime.Steps
{


    [Binding]
    public class HomePageSteps
    {

        public static string DashboardSidebar => "//a[@id='dashboard_sidebar']";
        public static string Realtime => "//a[@id='realTime__ui__dropdown__toggle']";
        public static string RealDevice=> "//a[@id='realDevice__ui__dropdown__toggle']";
        private readonly Driver _driver;
        private readonly HomePage homePage;

        public HomePageSteps(Driver driver)
        {
            _driver = driver;
            homePage = new HomePage(_driver.Page);
        }

        [Given(@"I go to url ""([^""]*)""")]
        public async void GivenIGoToUrl(string p0)
        {
            await homePage.NavigatePage(p0);
        }

        [Then(@"I click Dashboard")]
        public async Task ThenIClickDashboard()
        {
            await homePage.ClickToButton(DashboardSidebar);
        }

        [Then(@"I click to Real Time Testing")]
        public async Task ThenIClickToRealTimeTesting()
        {
            await homePage.ClickToButton(Realtime);
        }

        [Then(@"I click to Real Device")]
        public async Task ThenIClickToRealDevice()
        {
            await homePage.ClickToButton(RealDevice);
        }


    }
}
