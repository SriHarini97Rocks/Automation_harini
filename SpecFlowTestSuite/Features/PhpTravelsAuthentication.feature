Feature: PhpTravels authentication

@PhpTravelsAuthentication
Scenario: Login into PhpTravels
	Given Navigate to the site of the PhpTravels login page
	And Enter the username as user@phptravels.com
	And Enter the password as demouser
	When the login button is clicked after entering username and password
	Then the page should be redirected to dashboard page



