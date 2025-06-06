 @UI
 Feature: Global Search

Background:
	Given the user navigates to EPAM
	And the user accepts cookies

Scenario Outline: Search using a keyword
	Given the user clicks on the magnifier icon
	And the user enters the keyword "<searchCriteria>" in the global search
	When the user initiates the search
	Then all displayed search result links should contain the keyword "<searchCriteria>"

Examples:
	| searchCriteria |
	| BLOCKCHAIN     |
	| Cloud          |
	| Automation     |
