using LoginOneTime.Drivers;
using LoginOneTime.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LoginOneTime.Steps
{


    [Binding]
    public class HomePageSteps
    {

        public static string DashboardSidebar => "//a[@id='dashboard_sidebar']";
        public static string Realtime => "//a[@id='realTime__ui__dropdown__toggle']";
        public static string RealDevice=> "//a[@id='realDevice__ui__dropdown__toggle']";
        public static string DropdownPlaform => "//div[@class='col-span-1 dropdowm-section']//ul[@class='header_inner header-icon']//a//div//h3";
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
            await homePage.IsElementVisible(Realtime);
            await homePage.ClickToButton(Realtime);
        }

        [Then(@"I click to Real Device")]
        public async Task ThenIClickToRealDevice()
        {
            await homePage.ClickToButton(RealDevice);
        }

        [Then(@"I hover over the ""([^""]*)"" tab")]
        public async void ThenIHoverOverTheTab(string platform)
        {
            await homePage.HoverToElement("//a[contains(text(),'" + platform + "')]");
        }
        [Then(@"the dropdown menu for ""([^""]*)"" displays information")]
        public async Task ThenTheDropdownMenuForDisplaysInformation(string p0, Table table)
        { 
            List<string> expected = table.Rows.Select(row => row[p0]).ToList();
            List<string> actual;
            if (p0.Equals("Platform")) {
                actual = await homePage.GetDropdownOptions(DropdownPlaform);
            }
            else
            {
                actual = await homePage.GetDropdownOptions("//button[contains(text(),'"+p0+"')]//following-sibling::div//h3");
            }
            expected.Sort();
            actual.Sort();
            for (int i = 0; i < actual.Count; i++)
            {
                actual[i] = actual[i].Trim();
            }

            Assert.AreEqual(expected, actual, "Dropdown menu platforms do not match the expected values");

        }

        [Then(@"I hover over the ""([^""]*)"" button")]
        public async Task ThenIHoverOverTheButton(string p0)
        {
            await homePage.HoverToElement("//button[contains(text(),'" + p0 + "')]");
        }

    }
}
