Feature: Product

A short summary of the feature

@getproductdetails
Scenario: GetTheDetailsThatDoNotExist
	Given Product id is 3
	When Customer want to get product details
	Then The product repository should return status is NotFound

@getproductdetails
Scenario: GetTheDetailsOfAnExistingProduct
	Given Product id is 1
	When Customer want to get product details
	Then The product repository should return product data:
	|	Id	| Name      | MoneyValue.Value | MoneyValue.Currency | TradeMark | Origin   | Discription         |
	|	1	| Product 1 | 100              | USA                 | Viet Nam  | Viet Nam | This is a product 1 |

@getproducts
Scenario: GetAllProducts
	When get all product in the product repository
	Then the product repository should contain the following products:
	|	Id	| Name      | MoneyValue.Value | MoneyValue.Currency | TradeMark | Origin   | Discription         |
	|	1	| Product 1 | 100              | USA                 | Viet Nam  | Viet Nam | This is a product 1 |
	|	2	| Product 2 | 200              | USA                 | Viet Nam  | Viet Nam | This is a product 2 |
