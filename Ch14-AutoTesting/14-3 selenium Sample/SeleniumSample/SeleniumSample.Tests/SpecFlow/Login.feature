Feature: Login
	In order to 避免非法使用者使用系統
	As a 系統管理者
	I want to be 檢查帳號密碼是否合法

Scenario: 登入失敗，顯示錯誤訊息
	Given Login的頁面	
	When 在帳號輸入"joey"
	And 在密碼輸入"abc"
	And 按下登入
	Then 顯示"帳號或密碼有誤"

	#尚未實作
Scenario: 登入成功，導到首頁
	Given Login的頁面	
	When 在帳號輸入"joey"
	And 在密碼輸入"1234"
	And 按下登入
	Then 導到首頁