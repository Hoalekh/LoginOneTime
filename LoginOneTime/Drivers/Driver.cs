﻿using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LoginOneTime.Drivers
{
    [TestFixture]
    [Binding]
  
    public class Driver
    {
        public static string Email => "//input[@id='email']";
        public static string Password => "//input[@id='password']";
        public static string LoginBtn => "//button[@id='login-button']";
        public static string Profile => "//a[@id='profile__dropdown']";

        private static IPage? _page;
        private static IBrowser? _browser;
        private static IBrowserContext? _context;
        public IPage Page => _page!;

        [BeforeFeature]
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
            await _page.WaitForSelectorAsync(Profile);
            await _page.ClickAsync(Profile);

            var stateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "state.json");

            await _context.StorageStateAsync(new()
            {
                Path = stateFilePath
            });

            await _page.CloseAsync();
            await _browser.CloseAsync();
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                SlowMo = 2000
            });
            var stateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "state.json");
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = stateFilePath
            });

            _page = await _context.NewPageAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _page!.CloseAsync();
            await _browser!.CloseAsync();
        }

        [AfterFeature]
        public static async Task AfterFeature()
        {
            await _context!.CloseAsync();
            await _browser!.CloseAsync();
        }
    }
}
