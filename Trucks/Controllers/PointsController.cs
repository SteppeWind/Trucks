using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using Trucks.Common.Extensions;
using Trucks.Data.Repositories;
using Trucks.Services;
using Trucks.Web.Common.App.Extensions;
using Trucks.Web.Models.Points;

namespace Trucks.Web.Controllers
{
    public class PointsController : Controller
    {
        public IPointService PointService { get; set; }
        public IPointRepository PointRepository { get; set; }

        [HttpGet]
        public ActionResult List()
        {
            var points = PointRepository.GetAll(p => new PointModel
            {
                Id = p.Id,
                Address = p.Address,
                City = new PointModel.CityModel
                {
                    Name = p.City.Name,
                    Id = p.CityId
                }                
            }).ToArray();

            return View(new ListModel
            {
                Points = points
            });
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView("~/Views/Points/Create.cshtml");
        }

        [HttpPost, AjaxOnly]
        public ActionResult Create(CreateModel model)
        {
            return Redirect(this.BuildUrlFromExpression(c => c.Details(1)));
        }        

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return this.Ok();
        }
    }
}