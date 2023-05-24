
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Drawing;

namespace LoginOneTime.Page
{
    public class SeleniumPlayground
    {

        private readonly IPage page;

        public SeleniumPlayground(IPage page) => this.page = page;


        public IPage GetPage() => this.page;

        public async Task NavigatePage(string url)
        {
            await this.GetPage().GotoAsync(url);

        }
        public async Task ClickToButton(string locator)
        {
            await this.GetPage().Locator(locator).ClickAsync();

        }
        public async Task ClickByText(string text)
        {
            await page.GetByText(text).ClickAsync();

        }

        public async Task FillTextBox(string locator, string value)
        {
            try
            {
                await this.GetPage().Locator(locator).FillAsync(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"your message here: {ex.Message}");
            }

        }


        public async Task<string> GetText(string locator)
        {
            try
            {
                var element = await this.GetPage().QuerySelectorAsync(locator);
                var text = await element!.TextContentAsync();
                return text!.TrimEnd();
            }
            catch (Exception ex)
            {
                throw new Exception($"your message here: {ex.Message}");

            }
        }
        public async Task TypeTextBox(string locator, string value)
        {
            try
            {
                await this.GetPage().Locator(locator).TypeAsync(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"your message here: {ex.Message}");
            }

        }
        public async Task<bool> IsElementVisible(string locator)
        {
            try
            {
                await GetPage().WaitForSelectorAsync(locator);
                var element = await GetPage().QuerySelectorAsync(locator);
                if (element == null)
                {
                    throw new Exception($"Element with locator '{locator}' not found.");
                }
                return await element.IsVisibleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"your message here: {ex.Message}");
            }

        }

        public async Task DownloadFile(string locator, string file)
        {
            var waitForDownloadTask = GetPage().WaitForDownloadAsync();
            await ClickToButton(locator);
            var download = await waitForDownloadTask;
            var stateFilePath = Path.Combine(Directory.GetCurrentDirectory(), file + DateTime.Now.ToString("yyyyMMdd")+ ".txt");
            Console.WriteLine(await download.PathAsync());
            await download.SaveAsAsync(stateFilePath);
            
        }
        public async Task<bool> IsContainText(string locator, string text)
        {
            try
            {
                await GetPage().WaitForSelectorAsync(locator);
                var element = await GetPage().QuerySelectorAsync(locator);
                if (element == null)
                {
                    throw new Exception($"Element with locator '{locator}' not found.");
                }

                string elementText = await element.InnerTextAsync();
                return elementText.Contains(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"your message here: {ex.Message}");
            }
        }
        public void AcceptAlert()
        {
            GetPage().Dialog += async (_, dialog) =>
            {
                await dialog.AcceptAsync();
            };

        }

        public void DismissAlert()
        {
            GetPage().Dialog += async (_, dialog) =>
            { 
                await dialog.DismissAsync();
            };

        }
        public void AcceptAlert(string value)
        {
            GetPage().Dialog += async (_, dialog) =>
            {
                await dialog.AcceptAsync(value);
            };
        }

    }

}