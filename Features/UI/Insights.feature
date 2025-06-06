 @UI
 Feature: Insights tab

Background: User navigate to EPAM and click on accept cookies
	Given the user navigates to EPAM
	And the user accepts cookies

Scenario Outline: User navigates through carousel and validate titles from carousel and from article
	Given the user navigates to the Insights page
	And the user clicks on the right arrow from carousel <carouselClicks> times
	And the user validates the carousel title is "<title>"
	When the user clicks on 'Read More' from the carousel active item
	Then the title from the displayed article is "<title>"

Examples:
	| carouselClicks | title                                                              |
	| 1              | Data Literacy in the Age of Generative AI                          |
	| 2              | Evolving into Agentic AI: Turning Theory into Action               |
	| 3              | Mastering Cloud Security: Navigating Today’s Threat Landscape      |
	| 4              | The Complex Path of Generative AI Adoption in Software Development |
