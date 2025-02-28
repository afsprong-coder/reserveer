using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

public class AfsprongCalendarService
{
    private readonly CalendarService _calendarService;
    private const string RoomCalendarId = "49768b2c33342efb92c8afe9c8e637998bb0f630bb1d2292b1399fc0da937ce7@group.calendar.google.com"; // Replace with your calendar ID

    public AfsprongCalendarService()
    {
        string[] Scopes = { CalendarService.Scope.Calendar };
        string ApplicationName = "Room Reservation Checker";

        // Load the service account credentials
        var credential = GoogleCredential
            .FromFile("service-account-credentials.json")
            .CreateScoped(Scopes);

        _calendarService = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public async Task<bool> IsRoomAvailable(DateTime startTime, DateTime endTime)
    {
        var events = await GetEvents(startTime, endTime);
        return !events.Any();
    }

    private async Task<IList<Event>> GetEvents(DateTime startTime, DateTime endTime)
    {
        EventsResource.ListRequest request = _calendarService.Events.List(RoomCalendarId);
        request.TimeMin = startTime;
        request.TimeMax = endTime;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        Events events = await request.ExecuteAsync();
        return events.Items ?? new List<Event>();
    }
} 