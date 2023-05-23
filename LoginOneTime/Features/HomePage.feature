Feature: LoginOneTime

Scenario: Verify homepage
		Given I go to url "https://accounts.lambdatest.com/"
		Then The left menu displays information
		| Menu              |
		| Dashboard         |
		| Real Time Testing |
		| Real Device       |
		| Settings          |
		Then I click Dashboard
		Then I verify Color "Realtime Sessions" is "rgb(224, 233, 248)"
		Then I verify Color "Automation Sessions" is "rgb(248, 224, 224)"
		Then I click to Real Time Testing
		And I click to Real Device

Scenario: Verify homepagelist
		Given I go to url "https://www.lambdatest.com/"
		Then I hover over the "Platform" tab
		And the dropdown menu for "Platform" displays information
		| Platform					|
		| Online Browser Testing	|
		| Selenium Testing			|
		| Cypress Testing			|
		| Playwright Testing		|
		| HyperExecute				|
		| On-Premise Selenium Grid	|
		| Native Mobile App Testing	|
		| Real Devices Cloud		|
		| Visual Regression Cloud	|
		| Test Intelligence 		|
		| Automation Testing Cloud	|
		| Smart TV Testing Cloud	|
		Then I hover over the "Enterprise" button
		And the dropdown menu for "Enterprise" displays information
		| Enterprise								|
		| Digital Experience Testing				|
		| Enterprise Execution Environment			|
		Then I hover over the "Resources" button
		And the dropdown menu for "Resources" displays information
		| Resources 			|
		| Blog					|
		| Webinars				|
		| Learning Hub			|
		| Videos				|
		| Documentation			|
		| API					|
		| Newsletter			|
		| Community				|
		| Certifications		|
		| Write for Us			|
		| Customer Stories		|
		| Community & Support	|
		Then I hover over the "Developers" button
		And the dropdown menu for "Developers" displays information
		| Developers 					|
		| Selenium						|
		| Cypress						|
		| Mobile App Testing			|
		| Real Time Web Testing			|
		| Changelog						|
		| Documentation					|
		| API							|
		| GitHub Repositories			|
		| FAQs							|
		| Selenium Guide				|
		| Cypress Guide					|
		| Mobile Testing Advisor		|
		| Automation Testing Advisor	|
		| Web Technologies Compatibility|
		