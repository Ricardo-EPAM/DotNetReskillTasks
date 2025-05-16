Feature: About tab

Background: User navigate to EPAM and click on accept cookies
	Given the user accepts cookies

@Files
Scenario Outline: Debug tiest
	Given the user navigates to the Careers page
	When the user searches for a career with "<searchText>", in "b", and with "c" modality
	And the user applies and views the job from the last section
	Then the job details should contain "<searchText>"

Examples:
	| searchText |
	| b          |
	| a          |

