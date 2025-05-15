Feature: EPAM web page

Background: the user accepts cookies

  Scenario Outline: User performs a career search and verifies job details
    Given the user navigates to the Careers page
    When the user searches for a career with "<searchText>", in "<locationValue>", and with "<locationModality>" modality
    And the user applies and views the job from the last section
    Then the job details should contain "<searchText>"

    Examples:
      | searchText | locationValue | locationModality |
      | Golang     | all_locations | Remote           |
      | Python     | all_Poland    | Relocation       |
      | .NET       | Warsaw        | Office           |
      | Java       | Buenos Aires  | Office           |