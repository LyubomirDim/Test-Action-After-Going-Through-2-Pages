Feature: SuccessfulLogin
	As an owner of an email account
	I want to be able to login

@positive
Scenario: Login successfully with valid username and password
	Given I navigate to google homepage
	And I search for "abv.bg" in the search field
	And I press the Google search button
	And I select abv site
	When I enter "mytestemail008@abv.bg" as username
	And I enter "!@#$%67890" as password 
	And I press the Enter button 
	Then I will see a Write button 
