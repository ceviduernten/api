using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DUR.Api.Entities.Events;
using DUR.Api.Entities.Kool;
using DUR.Api.Infrastructure;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Settings;
using Ical.Net.CalendarComponents;
using Calendar = Ical.Net.Calendar;

namespace DUR.Api.Repo.Kool.Repositories;

public class KoolEventsRepo : RepoBase, IKoolEventsRepo
{
    private readonly GeneralSettings _settings;

    public KoolEventsRepo(IKoolApi api, GeneralSettings settings) : base(api)
    {
        _settings = settings;
    }

    public List<KoolEvent> GetEvents()
    {
        var reservations = new List<KoolReservation>();
        var client = _api.GetHttpClient();
        var url = BuildUrl(_settings.AllKoolEventsCalender);
        var response = client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        var calendar = Calendar.Load(result);
        ConvertCalenderEvents(reservations, calendar);
        return ParseEvents(reservations);
    }

    public List<KoolReservation> GetReservations()
    {
        var list = new List<KoolReservation>();
        var client = _api.GetHttpClient();
        var url = BuildUrl(_settings.ReservationEventsCalender);
        var response = client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        var calendar = Calendar.Load(result);
        ConvertCalenderEvents(list, calendar);
        return list;
    }

    private List<KoolEvent> ParseEvents(IEnumerable<KoolReservation> koolReservations)
    {
        var events = koolReservations.GroupBy(k => new {k.Summary, k.Start}).Select(group => new KoolEvent
        {
            Description = group.First().Description,
            Location = group.First().Location,
            Uid = group.First().Uid,
            Rooms = group.Select((x, index) => group.ToList()[index].Location + " " + x.Room).ToList(),
            Summary = group.Key.Summary,
            Start = group.Key.Start,
            End = group.First().End,
            Type = group.First().Type
        });
        return events.ToList();
    }

    private void ConvertCalenderEvents(List<KoolReservation> koolReservations, Calendar calendar)
    {
        foreach (var calenderEvent in calendar.Events) koolReservations.Add(ConvertToEvent(calenderEvent));
    }

    private string BuildUrl(string calendar)
    {
        var url = "https://" + _api.GetSettings().Host + _api.GetSettings().BaseUrl + calendar;
        return url;
    }

    private KoolReservation ConvertToEvent(CalendarEvent element)
    {
        var start = DateTime.ParseExact(element.Start.ToString(), "MM/dd/yyyy HH:mm:ss UTC",
            CultureInfo.InvariantCulture);
        var end = DateTime.ParseExact(element.End.ToString(), "MM/dd/yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture);
        var room = "";
        var location = "";
        var summary = element.Summary;

        if (element.Summary.Contains(';'))
        {
            location = summary.GetStringBetweenIndexes(0, element.Summary.IndexOf(";"));
            room = summary.GetStringBetweenIndexes(element.Summary.IndexOf(";") + 2, element.Summary.IndexOf(":"));
            summary = summary.GetStringBetweenIndexes(element.Summary.IndexOf(":") + 2, element.Summary.Length);
        }
        else
        {
            location = summary.GetStringBetweenIndexes(0, element.Summary.IndexOf(":"));
            summary = summary.GetStringBetweenIndexes(element.Summary.IndexOf(":") + 2, element.Summary.Length);
        }

        var e = new KoolReservation
        {
            Description = element.Description,
            Location = location,
            Uid = element.Uid,
            Room = room,
            Summary = summary,
            Start = start,
            End = end
        };
        e.Type = GetType(e);

        return e;
    }

    private KoolType GetType(KoolReservation koolEvent)
    {
        if (koolEvent != null && (koolEvent.Description.Contains(_settings.KoolUsername) ||
                                  koolEvent.Description.Contains("Cevi") ||
                                  koolEvent.Description.Contains("cevi"))) return KoolType.CEVI;

        return KoolType.ALL;
    }
}