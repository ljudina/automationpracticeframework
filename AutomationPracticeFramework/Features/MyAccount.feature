Feature: MyAccount
	As a user
	I want to be able to login to my account

@mytag
Scenario: User can login to account
	Given User opens sign in page 
	And user enters 'test+12345@test.com' for username
	And user enters 'QAKurs' for password 
	When user submits sign in
	Then user is logged in to my account section