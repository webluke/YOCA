using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class IdeaDataAccess
{
    private readonly ISqlDataAccess DB;

    public IdeaDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<IdeaModel>> GetAll()
    {
        var results = await DB.LoadData<IdeaModel, dynamic>("dbo.spIdeas_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<IdeaModel>> GetAllAdmin()
    {
        IEnumerable<IdeaModel> results = await DB.LoadData<IdeaModel, dynamic>("dbo.spIdeas_GetAllAdmin", new { });
        return results;
    }

    public async Task<IdeaModel?> GetId(string id)
    {
        var results = await DB.LoadData<IdeaModel, dynamic>(
            "dbo.spIdeas_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task Insert(IdeaModel cb)
    {
        cb.Id = Ids.NewId();
        await DB.SaveData("dbo.spIdeas_Insert",
            new { Id = cb.Id, Order = cb.Order, Status = cb.Status, Title = cb.Title, Content = cb.Content });
    }

    public async Task Update(IdeaModel cb) => await
        DB.SaveData("dbo.spIdeas_Update",
            new { Id = cb.Id, Order = cb.Order, Status = cb.Status, Title = cb.Title, Content = cb.Content });

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spIdeas_Delete",
            new { Id = id });

}
