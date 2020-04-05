Feature: FailedLogin
	As an owner of an email address 
	I don't want to be logged in if I provide wrong credentials

@negative
Scenario: Login fails when invalid password is provided
	Given I navigate to google 
	And I search for "abv.bg"
	And I press the search button
	And I select abv.bg website
	When I enter "<username>" in the username field
	And I enter "<password>" in the password field
	And I press the button Enter
	Then I will see an error message
	Examples: 
	| username              | password |
	| mytestemail008@abv.bg | oiuyfkdl |
	| mytestemail008@abv.bg | 95lr;lf9 |

