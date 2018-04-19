using System;
using System.Web.Mvc;

namespace Kaio.Web.UI.Mvc.Binders
{
    public class DoubleArrayBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrWhiteSpace(result.AttemptedValue))
            {

                var _words = result.AttemptedValue.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var ints = new double[_words.Length];
                for (int i = 0; i < _words.Length; i++)
                {
                    ints[i] = double.Parse(_words[i].Trim());
                }

                return ints;
            }

            return null;
        }
    }
}
