using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class PageDataAccess
{
    private readonly ISqlDataAccess DB;

    public PageDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<PageModel>> GetAll()
    {
        var results = await DB.LoadData<PageModel, dynamic>("dbo.spPage_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<PageModel>> GetAllMenu()
    {
        var results = await DB.LoadData<PageModel, dynamic>("dbo.spPage_GetAllMenu", new { });
        return results;
    }

    public async Task<IEnumerable<PageModel>> GetAllAdmin()
    {
        var results = await DB.LoadData<PageModel, dynamic>("dbo.spPage_GetAllAdmin", new { });
        return results;
    }

    public async Task<PageModel?> GetId(string id)
    {
        var results = await DB.LoadData<PageModel, dynamic>(
            "dbo.spPage_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<PageModel?> GetSlug(string slug)
    {
        var results = await DB.LoadData<PageModel, dynamic>(
            "dbo.spPage_GetBySlug",
            new { Slug = slug });

        return results.FirstOrDefault();
    }

    public async Task Insert(PageModel p)
    {
        p.Id = Ids.NewId();
        await DB.SaveData("dbo.spPage_Insert",
            new { Id = p.Id, Order = p.Order, Title = p.Title, Slug = p.Slug, MenuName = p.MenuName, Icon = p.Icon, Content = p.Content, IsPublished = p.IsPublished });
    }

    public async Task Update(PageModel p) => await
        DB.SaveData("dbo.spPage_Update",
            new { Id = p.Id, Order = p.Order, Title = p.Title, Slug = p.Slug, MenuName = p.MenuName, Icon = p.Icon, Content = p.Content, IsPublished = p.IsPublished });

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spPage_Delete",
            new { Id = id });
}
