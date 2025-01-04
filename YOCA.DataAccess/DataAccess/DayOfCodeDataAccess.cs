using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class DayOfCodeDataAccess
{
    private readonly ISqlDataAccess DB;

    public DayOfCodeDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<DayOfCodeModel>> GetDays()
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>("dbo.spDayOfCode_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<DayOfCodeModel>> GetLatest(int limit)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetLatestByLimit",
            new { Limit = limit });

        return results;
    }

    public async Task<IEnumerable<DayOfCodeModel>> GetPageRange(int pageNumber, int perPage)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetByPageNumber",
            new { PageNumber = pageNumber, RowsPerPage = perPage });

        return results;
    }

    public async Task<IEnumerable<DayOfCodeModel>> GetDateRange(DateOnly start, DateOnly end)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetDateRange",
            new { Start = start, End = end });

        return results;
    }

    public async Task<DayOfCodeModel?> GetId(string id)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<DayOfCodeModel?> GetDay(int day)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetByDay",
            new { Day = day });

        return results.FirstOrDefault();
    }
    
    public async Task<DayOfCodeModel?> GetDate(DateOnly date)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetByDate",
            new { Date = date });

        return results.FirstOrDefault();
    }

    public async Task Insert(DayOfCodeModel doc)
    {
        doc.Id = Ids.NewId();
        await DB.SaveData("dbo.spDayOfCode_Insert",
            new { doc });
    }

    public async Task UpdatePost(DayOfCodeModel p) => await
        DB.SaveData("dbo.spDayOfCode_Update", p);

    public async Task DeletePost(string id) => await
        DB.SaveData("dbo.spDayOfCode_Delete",
            new { Id = id });
}
