Feature: Login

@Smoke
Scenario Outline: Test that user can sign up successfully
Given a user is not logged in
And the user selects signUp on the homepage
When the user signs up with details <username>, <email>, <password>
Then the user is logged in
And the users name <username> is displayed

Examples: 
| username | email           | password |
| john13   | john13@test.com | john0987 |


@Smoke
Scenario: Test registered user can successfully sign in
Given a user is not logged in
When the user selects signIn on the homepage
And the user enters username "john@test.com" and password "john0987"
Then the user is logged in
And the users name john09 is displayed