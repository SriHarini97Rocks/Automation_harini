Feature: PhpTravelsProfileUpdateAndBooking

A short summary of the feature

@PhpTravelsProfileUpdateAndBooking
Scenario: PhpTravels User Profile Update
	Given Login to the Dashboard
	And Click the My Profile section
	Then Profile Page will appear
	Given New mobile number is entered
	When Update Profile button is clicked
	And Page is reloaded
	Then New mobile number should appear
	Given Click on the Filghts section
	And Choose origin as MAA-Chennai
	And Choose destination as BOM-Bombay
	And Choose Date 30-03-2022
	And Choose Adults as 2
	When The search button is clicked
	Then Flight page should appear
	When Nonstop flight checkbox is clicked
	Then Total flight count should be 20



