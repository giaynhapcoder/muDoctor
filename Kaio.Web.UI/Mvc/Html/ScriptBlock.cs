using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Kaio.Web.UI
{

    public class ScriptBlock : IDisposable
    {

        private const string GLOBAL_SCRIPT_KEY = "__SCRIPTBLOCKS";
        public static IDictionary<string, string> PageScripts
        {
            get
            {
                if (HttpContext.Current.Items[GLOBAL_SCRIPT_KEY] == null)
                    HttpContext.Current.Items[GLOBAL_SCRIPT_KEY] = new Dictionary<string, string>();



                return (IDictionary<string, string>)HttpContext.Current.Items[GLOBAL_SCRIPT_KEY];
            }
        }

        public static void Register(string script, string key = null)
        {

            if (string.IsNullOrWhiteSpace(key))
            {
                key = Guid.NewGuid().ToString();
            }
            
            if (!PageScripts.ContainsKey(key))
                PageScripts.Add(key, script);


        }

        private WebViewPage Html { get; set; }

        private string ScriptKey { get; set; }

        public ScriptBlock(WebViewPage html, string key = null)
        {
            Html = html;
            ScriptKey = key;
          Html.OutputStack.Push(new StringWriter());
        }

        public void Dispose()
        {
            var _script = Html.OutputStack.Pop().ToString();

           if (Html.IsAjax)
            {
                Html.Write(new HtmlString(_script));
            }
            else
            {
                Register(_script, ScriptKey);    
            }
            
        }
    }

}
