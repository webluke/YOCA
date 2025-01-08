using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class ClipboardDataAccess
{
    private readonly ISqlDataAccess DB;

    public ClipboardDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<ClipboardModel>> GetAll()
    {
        var results = await DB.LoadData<ClipboardModel, dynamic>("dbo.spClipboard_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<ClipboardModel>> GetAllAdmin()
    {
        IEnumerable<ClipboardModel> results = await DB.LoadData<ClipboardModel, dynamic>("dbo.spClipboard_GetAllAdmin", new { });
        return results;
    }

    public async Task<ClipboardModel?> GetId(string id)
    {
        var results = await DB.LoadData<ClipboardModel, dynamic>(
            "dbo.spClipboard_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task Insert(ClipboardModel cb)
    {
        cb.Id = Ids.NewId();
        await DB.SaveData("dbo.spClipboard_Insert",
            new { Id = cb.Id, Order = cb.Order, Status = cb.Status, Title = cb.Title, Note = cb.Note });
    }

    public async Task Update(ClipboardModel cb) => await
        DB.SaveData("dbo.spClipboard_Update",
            new { Id = cb.Id, Order = cb.Order, Status = cb.Status, Title = cb.Title, Note = cb.Note });

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spClipboard_Delete",
            new { Id = id });

}
