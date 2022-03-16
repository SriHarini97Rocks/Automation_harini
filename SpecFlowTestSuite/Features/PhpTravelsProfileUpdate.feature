Feature: PhpTravelsProfileUpdate

A short summary of the feature

@PhpTravelsProfileUpdate
Scenario: PhpTravels User Profile Update
	Given Login to the Dashboard
	And Click the My Profile section
	Then Profile Page will appear
	Given New mobile number is entered
	When Update Profile button is clicked
	And Page is reloaded
	Then New mobile number should appear

