using System;
using System.Web.Mvc;


namespace Kaio.Web.UI.Mvc.Binders
{
    public class StringArrayBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrWhiteSpace(result.AttemptedValue))
            {
                var _words = result.AttemptedValue.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < _words.Length; i++)
                {
                    _words[i] = _words[i].Trim();
                }
/*
                Array.Sort(_words);*/

                return _words;
            }

            return null;
        }
    }
}
