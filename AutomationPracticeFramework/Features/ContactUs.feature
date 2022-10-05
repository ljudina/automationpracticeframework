Feature: ContactUs
	As a user
	I want to be able to use contact us form
	So I can contact customer service

@mytag @smoke
Scenario: User can contact customer service
	Given User opens contact us page
	When User fill in all required fields with "Webmaster" heading and "QA kurs" message
	And User submits form
	Then message "Your message has been successfully sent to our team." is present to the team