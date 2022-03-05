using System;
using System.Collections.Generic;
using System.Linq;
using DUR.Api.Entities;
using DUR.Api.Entities.Events;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DUR.Api.Repo.Nextcloud.Repositories;

public class EventsRepo : RepoBase, IEventsRepo
{
    private readonly GeneralSettings _settings;

    public EventsRepo(INextcloudApi api, GeneralSettings settings) : base(api)
    {
        _settings = settings;
    }

    public List<Event> GetEvents()
    {
        var list = new List<Event>();
        var client = _api.GetHttpClient();
        var url = BuildUrl();
        var response = client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        var s = (JArray) JsonConvert.DeserializeObject(result);
        if (s != null)
        {
            var events = s[2];
            foreach (JArray item in events)
            {
                var type = (string) item[0];
                if (type != "vevent") continue;
                var element = (JArray) item[1];
                var resEvent = ConvertToEvent(element);
                if (resEvent.End > DateTime.Now.AddDays(-1)) list.Add(ConvertToEvent(element));
            }
        }

        return list;
    }

    private string BuildUrl()
    {
        var parameters = _api.GetSettings().Parameters;
        var url = "https://" + _api.GetSettings().Host + _api.GetSettings().BaseUrl + _settings.EventsCalendar +
                  parameters;
        return url;
    }

    private Event ConvertToEvent(JArray element)
    {
        var temp = JArrayToObject(element);

        string location, uid, summary, descrption;

        var locationProperty = temp.FirstOrDefault(x => x.Property == "location");
        var uidProperty = temp.FirstOrDefault(x => x.Property == "uid");
        var summaryProperty = temp.FirstOrDefault(x => x.Property == "summary");
        var descriptionProperty = temp.FirstOrDefault(x => x.Property == "description");
        var startProperty = temp.FirstOrDefault(x => x.Property == "dtstart");
        var endProperty = temp.FirstOrDefault(x => x.Property == "dtend");

        location = locationProperty == null ? "" : locationProperty.Value;
        uid = uidProperty == null ? "" : uidProperty.Value;
        summary = summaryProperty == null ? "" : summaryProperty.Value;
        descrption = descriptionProperty == null ? "" : descriptionProperty.Value;
        var start = DateTime.Parse(startProperty.Value);
        var end = DateTime.Parse(endProperty.Value);


        var e = new Event
        {
            Description = descrption,
            Location = location,
            Uid = uid,
            Summary = summary,
            Start = start,
            End = end,
            Type = GetType(summary)
        };

        return e;
    }

    private EventType GetType(string name)
    {
        switch (name)
        {
            case string a when a.ToLower().Contains("fröschli"): return EventType.FROESCHLI;
            case string b when b.ToLower().Contains("cevi"): return EventType.JUNGSCHAR;
            case string c when c.ToLower().Contains("ferien"): return EventType.HOLIDAY;
            case string d when d.ToLower().Contains("jungschar"): return EventType.JUNGSCHAR;
        }

        return EventType.GENERAL;
    }

    private List<EventProperty> JArrayToObject(JArray array)
    {
        var list = new List<EventProperty>();
        foreach (JArray item in array)
        {
            var property = (string) item[0];
            var type = (string) item[2];
            var value = (string) item[3];
            var tempObject = new EventProperty
            {
                Type = type,
                Value = value,
                Property = property
            };
            list.Add(tempObject);
        }

        return list;
    }
}