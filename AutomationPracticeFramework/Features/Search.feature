Feature: Search
	In order to find products as a user
	I want to be able to search for a term

@mytag
Scenario: User can search for a term
	Given user enters 'dress' search term
	When user submits a search
	Then results for 'DRESS' search term are displayed