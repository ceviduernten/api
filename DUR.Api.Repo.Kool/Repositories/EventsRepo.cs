using DUR.Api.Entities;
using DUR.Api.Entities.Events;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Settings;
using Ical.Net;
using Ical.Net.CalendarComponents;
using DUR.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DUR.Api.Repo.Kool.Repositories
{
    public class KoolEventsRepo : RepoBase, IKoolEventsRepo
    {
        private readonly GeneralSettings _settings;

        public KoolEventsRepo(IKoolApi api, GeneralSettings settings) : base(api)
        {
            _settings = settings;
        }

        public List<KoolEvent> GetEvents()
        {
            List<KoolEvent> list = new List<KoolEvent>();
            HttpClient client = _api.GetHttpClient();
            var url = BuildUrl(_settings.AllKoolEventsCalender);
            HttpResponseMessage response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var calendar = Calendar.Load(result);
            ConvertCalenderEvents(list, calendar);
            return list;
        }

        public List<KoolEvent> GetReservations()
        {
            List<KoolEvent> list = new List<KoolEvent>();
            HttpClient client = _api.GetHttpClient();
            var url = BuildUrl(_settings.ReservationEventsCalender);
            HttpResponseMessage response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var calendar = Calendar.Load(result);
            ConvertCalenderEvents(list, calendar);
            return list;
        }

        private void ConvertCalenderEvents(List<KoolEvent> koolEvents, Calendar calendar)
        {
            foreach(var calenderEvent in calendar.Events)
            {
                koolEvents.Add(ConvertToEvent(calenderEvent));
            }
        }

        private string BuildUrl(string calendar)
        {
            string url = "https://" + _api.GetSettings().Host + _api.GetSettings().BaseUrl + calendar;
            return url;
        }

        private KoolEvent ConvertToEvent(CalendarEvent element)
        {
            DateTime start = DateTime.ParseExact(element.Start.ToString(), "MM/dd/yyyy HH:mm:ss UTC", System.Globalization.CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(element.End.ToString(), "MM/dd/yyyy HH:mm:ss UTC", System.Globalization.CultureInfo.InvariantCulture);
            string room = "";
            string location = "";
            string summary = element.Summary;

            if (element.Summary.Contains(';'))
            {
                location = summary.GetStringBetweenIndexes(0, element.Summary.IndexOf(";"));
                room = summary.GetStringBetweenIndexes(element.Summary.IndexOf(";") + 2, element.Summary.IndexOf(":"));
                summary = summary.GetStringBetweenIndexes(element.Summary.IndexOf(":") + 2, element.Summary.Length);
            } else
            {
                location = summary.GetStringBetweenIndexes(0, element.Summary.IndexOf(":"));
                summary = summary.GetStringBetweenIndexes(element.Summary.IndexOf(":") + 2, element.Summary.Length);
            }

            KoolEvent e = new KoolEvent
            {
                Description = element.Description,
                Location = location,
                Uid = element.Uid,
                Room = room,
                Summary = summary,
                Start = start,
                End = end,
            };
            e.Type = GetType(e);

            return e;
        }

        private KoolEventType GetType(KoolEvent koolEvent)
        {
            if (koolEvent != null && (koolEvent.Description.Contains(_settings.KoolUsername) || koolEvent.Description.Contains("Cevi") || koolEvent.Description.Contains("cevi")))
            {
                return KoolEventType.CEVI;
            }

            return KoolEventType.ALL;
        }
    }
}
