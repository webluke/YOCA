using Microsoft.AspNetCore.Mvc;
using YOCA.DataAccess.DataAccess;

namespace YOCA.Fluent.Components.Streaming;

public class StreamingController : Controller
{
    private readonly DayOfCodeDataAccess DayData;
    public StreamingController(DayOfCodeDataAccess dayData)
    {
        DayData = dayData;
    }

    [Route("tomorrow")]
    public async Task<IActionResult> TomorrowAsync()
    {
        var day = await DayData.GetTomorrow();
        return View("TomorrowGoal", day);
    }

}
