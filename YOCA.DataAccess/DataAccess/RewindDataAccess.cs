using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class RewindDataAccess
{
    private readonly ISqlDataAccess DB;

    public RewindDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<RewindModel>> GetAll()
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<RewindModel>> GetAllPreview()
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetAllPreview", new { });
        return results;
    }

    public async Task<IEnumerable<RewindModel>> GetAllAdmin()
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetAllAdmin", new { });
        return results;
    }

    public async Task<RewindModel?> GetId(string id)
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<RewindModel?> GetIdAdmin(string id)
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetByIdAdmin",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<RewindModel?> GetSlug(string slug)
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetBySlug",
            new { Slug = slug });

        return results.FirstOrDefault();
    }

    public async Task<RewindModel?> GetDate(DateOnly date)
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetByDate",
            new { Date = date });

        return results.FirstOrDefault();
    }

    public async Task<RewindModel?> GetYearMonth(int year, int month)
    {
        var results = await DB.LoadData<RewindModel, dynamic>(
            "dbo.spRewind_GetByYearMonth",
            new { Year = year, Month = month });

        return results.FirstOrDefault();
    }

    public async Task Insert(RewindModel rewind)
    {
        rewind.Id = Ids.NewId();
        await DB.SaveData("dbo.spRewind_Insert",
            new {
                Id = rewind.Id,
                Date = rewind.Date,
                Year = rewind.Year,
                Month = rewind.Month,
                Title = rewind.Title,
                Slug = rewind.Slug,
                Content = rewind.Content,
                IsPublished = rewind.IsPublished
            });
    }

    public async Task Update(RewindModel rewind) => await
        DB.SaveData("dbo.spRewind_Update",
            new
            {
                Id = rewind.Id,
                Date = rewind.Date,
                Year = rewind.Year,
                Month = rewind.Month,
                Title = rewind.Title,
                Slug = rewind.Slug,
                Content = rewind.Content,
                IsPublished = rewind.IsPublished
            });

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spRewind_Delete",
            new { Id = id });
}
