Feature: Get BFE number from a address

As a user I want to get the BFE number from a address,
so i'm able to use the BFE number,
to see information about the address.

Scenario: User types in a address and get address id
	Given the user types in a address
	When the user clicks on the submit button
	Then the user will get the correct address id

Scenario: System is able to find the jordstykke number from address id
	Given the system has a address id
	When the system sends a GET jordstykke request to the api
	Then the system will retrieve the correct jordstykke number

Scenario: System is able to find the BFE number from jordstykke number
	Given the system has jordstykke number "436266"
	When the system sends the GET BFE request to the api
	Then the system will retrieve the BFE number