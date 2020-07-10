Feature: Digital Networks Login
	In order to see my Digital Networks and Events
	As a Digital Network and Events user
	I want to have Digital Network and Events page open after entering my credentials

Scenario: Not valid credentials
	Given I'm on Digital Networks Login page
	And I have entered test as Email and test as Password
	When I press Log in
	Then the alert message User name and password do not match should be displayed
