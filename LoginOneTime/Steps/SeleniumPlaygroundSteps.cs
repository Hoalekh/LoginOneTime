using LoginOneTime.Drivers;
using LoginOneTime.Page;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LoginOneTime.Steps
{


    [Binding]
    public class SeleniumPlaygroundSteps
    {

        public static string TextBoxDowload => "//textarea[@id='textbox']";
        public static string GenerateFile => "//button[text()='Generate File']";
        public static string DownloadFile => "//a[@id='link-to-download']";
        public static string MsgPromptSuccess => "//p[@id='prompt-demo']";
        public static string SingleAlert => "//div[text()='Java Script Alert Box']/following-sibling::button[text()='Click Me']";
        public static string ComfirmAlert => "//div[text()='Java Script Confirm Box']/following-sibling::div//button[text()='Click Me']";
        public static string PrompAlert => "//div[text()='Java Script Alert Box']/following-sibling::p//button[text()='Click Me']";
    

        private readonly Driver _driver;
        private readonly SeleniumPlayground seleniumPlayground;

        public SeleniumPlaygroundSteps(Driver driver)
        {
            _driver = driver;
            seleniumPlayground = new SeleniumPlayground(_driver.Page);
        }

        [Then(@"I click to ""([^""]*)""")]
        public async Task ThenIClickTo(string p0)
        {
            await seleniumPlayground.ClickByText(p0);
        }

        [Then(@"Enter data ""([^""]*)"" in the textbox")]
        public async Task ThenEnterDataInTheTextbox(string p0)
        {
            await seleniumPlayground.TypeTextBox(TextBoxDowload, p0);
        }
        [Then(@"I click to Generate File button")]
        public async Task ThenIClickToGenerateFileButton()
        {
            await seleniumPlayground.ClickToButton(GenerateFile);
        }
        [Then(@"I go to url ""([^""]*)""")]
        public async Task ThenIGoToUrl(string p0)
        {
            await seleniumPlayground.NavigatePage(p0);
        }

        [Then(@"I dowload file")]
        public async Task ThenIDowloadFile()
        {
            await seleniumPlayground.DownloadFile(DownloadFile, "file");
        }
    
        [Then(@"I click to the CLick me button Java Script Confirm Box")]
        public async Task ThenIClickToTheCLickMeButtonJavaScriptConfirmBox()
        {
            await seleniumPlayground.ClickToButton(ComfirmAlert);
        }

        [Then(@"I cancel alert")]
        public void ThenICancelAlert()
        {
            seleniumPlayground.DismissAlert();
        }

        [Then(@"I click to the CLick me button Java Script Promp Box")]
        public async Task ThenIClickToTheCLickMeButtonJavaScriptPrompBox()
        {
            await seleniumPlayground.ClickToButton(PrompAlert);
        }

     
        [Then(@"I accept alert with ""([^""]*)""")]
        public void ThenIAcceptAlertWith(string p0)
        {
            seleniumPlayground.AcceptAlert(p0);
           // Assert.IsTrue(await seleniumPlayground.IsContainText(MsgPromptSuccess, p0));
        }


    }
}
