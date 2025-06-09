@API
Feature: User API Validation

Scenario: Validate that the list of users can be received successfully
	Given I create a GET request to the "users" endpoint
	When I send the request
	Then the response status code is OK
	And the response should contain a list of users with the following fields:
		| Field    |
		| Id       |
		| Name     |
		| Username |
		| Email    |
		| Address  |
		| Phone    |
		| Website  |
		| Company  |

Scenario: Validate response Content-type from Users enpoint
	Given I create a GET request to the "users" endpoint
	When I send the request
	Then the response status code is OK
	And the response header should contain content-type as "application/json; charset=utf-8"


Scenario: Validate response body from Users enpoint
	Given I create a GET request to the "users" endpoint
	When I send the request
	Then the response status code is OK
	And the response should contain an array of 10 users
	And each user should have a unique id
	And each user should have non-empty name and username
	And each user should contain a company with a non-empty name


Scenario Outline: Validate that a user can be created
	Given I create a POST request to the "users" endpoint
	And I add the following data to the request body in JSON format:
		| Field    | Value      |
		| name     | <name>     |
		| username | <username> |
	When I send the request
	Then the response status code is Created
	And the response contains the field "id"


Examples:
	| name    | username |
	| Manuel  | ManuelM  |
	| Ricardo | RicardoA |

Scenario: Validate that error is displayed when an invalid endpoint is called
	Given I create a GET request to the "invalid" endpoint
	When I send the request
	Then the response status code is NotFound

