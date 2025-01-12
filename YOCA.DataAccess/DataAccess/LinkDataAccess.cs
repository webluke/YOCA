using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class LinkDataAccess
{
    private readonly ISqlDataAccess DB;

    public LinkDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<LinkModel>> GetAll()
    {
        var results = await DB.LoadData<LinkModel, dynamic>("dbo.spLinks_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<MenuLinksModel>> GetAllMenu()
    {
        IEnumerable<MenuLinksModel> results = await DB.LoadData<MenuLinksModel, dynamic>("dbo.spLinks_GetAllLinksPagesMenu", new { });
        return results;
    }

    public async Task<IEnumerable<LinkModel>> GetAllAdmin()
    {
        IEnumerable<LinkModel> results = await DB.LoadData<LinkModel, dynamic>("dbo.spLinks_GetAllAdmin", new { });
        return results;
    }

    public async Task<LinkModel?> GetId(string id)
    {
        var results = await DB.LoadData<LinkModel, dynamic>(
            "dbo.spLinks_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<LinkModel?> GetSlug(string slug)
    {
        var results = await DB.LoadData<LinkModel, dynamic>(
            "dbo.spLinks_GetBySlug",
            new { Slug = slug });

        return results.FirstOrDefault();
    }

    public async Task Insert(LinkModel link)
    {
        link.Id = Ids.NewId();
        await DB.SaveData("dbo.spLinks_Insert",
            new { Id = link.Id, Order = link.Order, Type = link.Type, Title = link.Title, URL = link.URL, MenuName = link.MenuName, Icon = link.Icon, IsPublished = link.IsPublished });
    }

    public async Task Update(LinkModel link) => await
        DB.SaveData("dbo.spLinks_Update",
            new { Id = link.Id, Order = link.Order, Type = link.Type, Title = link.Title, URL = link.URL, MenuName = link.MenuName, Icon = link.Icon, IsPublished = link.IsPublished });

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spLinks_Delete",
            new { Id = id });
}
