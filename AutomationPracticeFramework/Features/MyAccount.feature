Feature: MyAccount
	As a user
	I want to be able to login to my account

Background: 
	Given User opens sign in page 

@MyAccount
Scenario: User can login to account
	And user enters credentials
	When user submits sign in
	Then user is logged in to my account section

@MyAccount
Scenario: User can create an account
	And user enters email in create account section and submits
	And user enters all required fields for account creation
	When user submits registration
	And users full name is displayed

Scenario: User can open wishlist
	Given user is logged in
	And user goes to My Wishlist page
	And user enters whishlist name
	When user submits whishlist name
	Then whishlist name is displayed

Scenario: User can change last name
	Given user is logged in
	And user goes to My personal information page
	And user changes last name
	When user submits personal information name
	Then new last name is shown
	