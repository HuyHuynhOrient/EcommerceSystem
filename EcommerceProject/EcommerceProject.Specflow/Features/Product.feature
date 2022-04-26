Feature: Product

A short summary of the feature

@Create
Scenario: Create product
	Given the name is "Apple watch"
	And the moneyvalue value is 100
	And the moneyvalue currency is "USA"
	And the trademark is "Apple"
	And the origin is "VietNam"
	And the discription is "This is an apple watch"
	When the product is created
	Then the command result is success

