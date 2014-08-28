using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ch06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 調整ViewEngine順序
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine());

            // 以上省略

            //加上String-->Decimal的轉換函數
            //ModelBinders.Binders.Add(
            //    typeof(decimal),
            //    new FlexModelBinder(
            //        s => Convert.ToDecimal(s, CultureInfo.CurrentCulture)));

            //加上JSON-->List<ScoreRecord>的轉換函數
            // using System.Web.Script.Serialization;
            //ModelBinders.Binders.Add(
            //    typeof(List<ScoreRecord>),
            //    new FlexModelBinder(
            //        s => (new JavaScriptSerializer()).Deserialize<List<ScoreRecord>>(s)));

            //加上JSON-->List<ScoreRecord>的轉換函數
            // using Newtonsoft.Json;
            //ModelBinders.Binders.Add(
            //    typeof(List<ScoreRecord>),
            //    new FlexModelBinder(
            //        s => JsonConvert.DeserializeObject<List<ScoreRecord>>(s)));

            //ValueProviderFactories.Factories.Add(new CookieValueProviderFactory());
        }
    }

    public class FlexModelBinder : IModelBinder
    {
        // 將轉換核心抽出來變成Func<string, object>當成初始化參數
        // 傳入不同轉換函數，就可以變成不同型別的ModelBinder
        Func<string, object> _convFn = null;
        public FlexModelBinder(Func<string, object> convFunc)
        {
            _convFn = convFunc;
        }

        // 實作IModelBinder介面
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // ValueProviderResult
            // 表示將值 (例如從表單張貼或查詢字串) 繫結至動作方法引數屬性或繫結至引數本身的結果。
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                //valueResult：取得或設定轉換為顯示字串之未經處理的值。
                //_convFn委派進行轉換
                actualValue = _convFn(valueResult.AttemptedValue);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}
