Feature: 計算運費
	In order to 算出運費
	As a PM
	I want to be 根據商品類型算出運費


Scenario Outline: 計算運費
	Given 計算運費頁面
	When 商品規格為
	| Length | Width | Height | Weight | Name                 |
	| 30     | 20    | 10     | 10     | ASP.NET MVC 4 網站開發美學 |
	And 選擇<shipper>
	And 點選計算運費
	Then 運費結果應為 <fee>
	Examples: 
	| shipper | fee |
	| 黑貓      | 200 |
	| 新竹貨運    | 254.16 |
	| 郵局      | 180    |