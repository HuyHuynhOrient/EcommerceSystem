Feature: Product

A short summary of the feature

@GetAll
Scenario: [Get products]
	Given the name is null
	And the trademark is null
	And the origin is  null
	And the currency is null
	And the maxvalue is null
	And the minvalue is null
	When the products list is provided
	Then the products count should be 1

@GetsDetails
Scenario: [Get product details]
	Given the productIs is 1
	When the product details is provided
	Then the name is "Macbook"
	And the price value is 1000
	And the price currency is "USA
	And the trademark is "Apple"
	And the origin is "China"
	And the discription is "This is a macbook" 

@Add
Scenario: [Create product]
	Given the name is "Apple watch"
	And the moneyvalue value is 100
	And the moneyvalue currency is "USA"
	And the trademark is "Apple"
	And the origin is "VietNam"
	And the discription is "This is an apple watch"
	When the product is created
	Then the command result is success

@Update
Scenario: [Update product]
	Given the name is "Apple watch"
	And the moneyvalue value is 100
	And the moneyvalue currency is "USA"
	And the trademark is "Apple"
	And the origin is "China"
	And the discription is "This is an apple watch"
	When the product is updated
	Then the command result is success

@Delete
Scenario: [Delete product]
	Given the productIs is 1
	When the product is deleted
	Then the command result is success