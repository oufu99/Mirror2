using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Models
{
    public class JsonBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {

            return new JsonBinder();
        }
    }

    public class JsonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var stream = controllerContext.HttpContext.Request.InputStream;
                StreamReader s = new StreamReader(stream);
                var str = s.ReadToEnd();

                return JsonConvert.DeserializeObject(str, bindingContext.ModelType);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}