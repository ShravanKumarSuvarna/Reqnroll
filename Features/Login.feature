Feature: Login

A short summary of the feature


Background: 
	Given User is on the orangehrm login page
 
@Regression,@Functional
Scenario: Verify login with valid credentails
	When User enters the username "Admin" and password "admin123" in the text fields
	When User clicks on submit button
	Then User is navigated to home page


@sanity
Scenario Outline: Verify login with test parameters
	When User enters the "<username>" and "<password>"
	And  User clicks on submitt button
	Then User is navigated to home page
	Then User selected city and country information
	| city      | county |
	| Mangalore | India  |
	| Seattle   | USA    |

	Examples: 
	| username | password |
	| Admin    | admin123 |
	| Sudo     | sudo123  |