Feature: LoginOneTime

A short summary of the feature

Feature: AnimatedGiftCardsCartTotalAmountValidation
Simple test cases for validation of total amount value
Fill invalid email >>> verify warning message under field
Fill valid email + Incorrect password >>> click login

Fill valid email and password >>> click login >>> verify content


Scenario: Verify homepage
		Given I go to url "https://accounts.lambdatest.com/"
		Then I click Dashboard
		Then I click to Real Time Testing
		And I click to Real Device

Scenario: Verify homepage2
		Given I go to url "https://accounts.lambdatest.com/"
		Then I click Dashboard
		Then I click to Real Time Testing
		And I click to Real Device