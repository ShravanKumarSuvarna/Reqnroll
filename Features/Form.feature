Feature: Form

This is a test form for tutorialpoint dum dum
  

  Scenario: Fill and submit the test form
    Given I am on the Student Registration Form page
    When I fill the form with:
      | Name      | Email                | Gender | Mobile      | DateOfBirth | Subjects | Hobbies        | PicturePath                                  | Address         | State     | City  |
      | John Cena | youcantseeme@wwe.com | Male   | 9876543210  | 04/06/2000 | Maths    | Sports,Reading  | C:\Users\shkum\Downloads\sampleFile (1).jpeg | 123 Elm Street  | Rajasthan | Agra  |
    And I submit the registration form
    Then the form should be submitted successfully
