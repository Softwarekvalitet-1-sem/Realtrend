Feature: Get BFE number from a address

As a user I want to get the BFE number from a address,
so i'm able to use the BFE number,
to see information about the address.

Scenario: User types in a address and address id
	Given the user types in a address
	When the user clicks on the submit button
	Then the user will get address id
