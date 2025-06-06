 @UI
 Feature: About tab

Background: User navigate to EPAM and click on accept cookies
	Given the user navigates to EPAM
	And the user accepts cookies

@Files @UI
Scenario: Navigate to About tab and scroll to EPAM At A Glance Section to download a file
	Given the user navigates to the About page
	And the user scrolls to the 'EPAM At A Glance' Section
	When the user clicks on the download button from 'EPAM At A Glance' Section
	Then the file "EPAM_Corporate_Overview_Q4FY-2024.pdf" is downloaded
