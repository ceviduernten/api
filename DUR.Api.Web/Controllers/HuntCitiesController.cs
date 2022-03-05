using System;
using System.Linq;
using DUR.Api.Presentation.Interfaces.Presenter;
using DUR.Api.Presentation.ResourceModel;
using DUR.Api.Web.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Controllers;

public class HuntCitiesController : DefaultController
{
    private readonly IHuntCityPresenter _huntCityPresenter;

    public HuntCitiesController(IHuntCityPresenter huntCityPresenter)
    {
        _huntCityPresenter = huntCityPresenter;
    }

    [HttpGet]
    public JsonResult GetList()
    {
        var res = _huntCityPresenter.GetAll().OrderBy(x => x.Name).ToList();
        return Json(new DataJsonResult<HuntCityRM>(200, "hunt cities successfully returned", res));
    }

    [Authorize("Scouting")]
    [HttpPost]
    public JsonResult AddHuntCity(HuntCityRM city)
    {
        var success = _huntCityPresenter.Add(city);
        if (success)
            return Json(new InfoJsonResult(200, "successfully added hunt city"));
        return Json(new InfoJsonResult(500, "Error on adding hunt city"));
    }

    [Authorize("Scouting")]
    [HttpDelete("{city}")]
    public JsonResult DeleteHuntCity(Guid city)
    {
        var success = _huntCityPresenter.DeleteById(city);
        if (success)
            return Json(new InfoJsonResult(200, "successfully deleted hunt city"));
        return Json(new InfoJsonResult(500, "Error on deleting hunt city"));
    }

    [Authorize("Scouting")]
    [HttpPatch("{IdHuntCity}")]
    public JsonResult UpdateHuntCity(HuntCityRM city)
    {
        var success = _huntCityPresenter.Update(city);
        if (success)
            return Json(new InfoJsonResult(200, "successfully updated hunt city"));
        return Json(new InfoJsonResult(500, "Error on updating hunt city"));
    }

    [Authorize("Scouting")]
    [HttpGet("{city}")]
    public JsonResult GetHuntCity(Guid city)
    {
        var res = _huntCityPresenter.GetById(city);
        return Json(new SingleDataJsonResult<HuntCityRM>(200, "hunt city successfully returned", res));
    }
}