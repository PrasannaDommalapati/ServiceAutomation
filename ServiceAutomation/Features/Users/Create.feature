Feature: Create User
	
@User
Scenario: Ceate an user using API
	When I create an user using POST
	Then the statuscode should be '200'