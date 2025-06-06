Feature: Services tab

Background: Accept cookies
	Given the user navigates to EPAM
	And the user accepts cookies

Scenario Outline: User navigates to Services AI related link and validates "Our Related Expertise" section 
	When the user navigates to the "<subItem>" sub link from "Services"
	Then the page title is "<pageTitle>"
	And the user is able to locate the section "Our Related Expertise"

Examples:
	| subItem        | pageTitle                                    |
	| Generative AI  | Generative AI \| EPAM                        |
	| Responsible AI | Responsible AI Assessment & Services \| EPAM |
