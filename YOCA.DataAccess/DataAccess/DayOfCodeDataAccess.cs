﻿using YOCA.DataAccess.Models;
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

    public async Task<TomorrowModel?> GetTomorrow()
    {
        var results = await DB.LoadData<TomorrowModel, dynamic>("dbo.spDayOfCode_GetTomorrow", new { });
        return results.FirstOrDefault();
    }


    public async Task<IEnumerable<DayOfCodeModel>> GetLatest(int limit)
    {
        var results = await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetLatestByLimit",
            new { Limit = limit });

        return results;
    }

    public async Task<(IEnumerable<DayOfCodeModel>, int Count)> GetPageRange(int pageNumber, int perPage)
    {
        var results = await DB.LoadCountData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetByPageNumber",
            new { PageNumber = pageNumber, PageSize = perPage });

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
            new { Id = doc.Id, Day = doc.Day, Date = doc.Date, Goal = doc.Goal, Result = doc.Result, Tomorrow = doc.Tomorrow, Summary = doc.Summary });
    }

    public async Task Update(DayOfCodeModel doc) {
        await DB.SaveData("dbo.spDayOfCode_Update", 
            new { Id = doc.Id, Day = doc.Day, Date = doc.Date, Goal = doc.Goal, Result = doc.Result, Tomorrow = doc.Tomorrow, Summary = doc.Summary });
    } 

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spDayOfCode_Delete",
            new { Id = id });
}
