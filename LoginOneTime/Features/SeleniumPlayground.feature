Feature: SeleniumPlayground

A short summary of the feature


Scenario: Verify download file
		Given I go to url "https://www.lambdatest.com/selenium-playground"
		Then I click to "File Download"
		And Enter data "Data entered in the below textarea " in the textbox
		Then I click to Generate File button
		Then I dowload file

Scenario: Verify Javascript Alert Box Demo
		Given I go to url "https://www.lambdatest.com/selenium-playground"
		Then I click to "Javascript Alerts"
		And I click to the CLick me button Java Script Confirm Box
		Then I cancel alert
		And I click to the CLick me button Java Script Promp Box
		Then I accept alert with "I am sad"
