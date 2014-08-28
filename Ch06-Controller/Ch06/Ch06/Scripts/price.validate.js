/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

// 第一個參數必須是伺服器端ValidationType的值;
// 第二個參數必須是伺服器端ValidationParameters.Add()的值
$.validator.unobtrusive.adapters.addSingleVal("price", "minprice");

// 增加處理 data-val-* 方法
// value：取得欄位輸入值
// element：取得input元素
// param：取得限制值
$.validator.addMethod("price", function(value, element, param) {
    if (value) {
        var inputValue = parseInt(value, 10);
        var validateValue = parseInt(param, 10);
        if (inputValue < validateValue) {
            return false;
        }
    }
    return true;
});