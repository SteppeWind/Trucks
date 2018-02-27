using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Trucks.Common.Extensions;

namespace Trucks.Web.Common.App.ActionResults
{
    public interface IJsonResult
    {
        object GetModel();
    }

    public class JsonResult : ActionResult, IJsonResult
    {
        private readonly object _data;

        public JsonResult(object data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public object GetModel()
        {
            return _data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var contentResult = new ContentResult
            {
                Content = _data.ToJson(),
                ContentType = "application/json"
            };

            contentResult.ExecuteResult(context);
        }
    }
}