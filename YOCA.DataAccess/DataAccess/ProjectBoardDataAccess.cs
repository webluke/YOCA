using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class ProjectBoardDataAccess
{
    private readonly ISqlDataAccess DB;

    public ProjectBoardDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public Task<IEnumerable<ProjectBoardModel>> GetAll()
    {
        var results = DB.LoadData<ProjectBoardModel, dynamic>("dbo.spProjectBoards_GetAll", new { });
        return results;
    }
    public Task<IEnumerable<ProjectBoardModel>> GetAllAdmin()
    {
        var results = DB.LoadData<ProjectBoardModel, dynamic>("dbo.spProjectBoards_GetAllAdmin", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectBoardModel>> GetProjectBoards(string projectId)
    {
        var results = await DB.LoadData<ProjectBoardModel, dynamic>(
            "dbo.spProjectBoards_GetAllByProjectId",
            new { ProjectId = projectId });

        return results;
    }
    public async Task<IEnumerable<ProjectBoardModel>> GetProjectBoardssAdmin(string projectId)
    {
        var results = await DB.LoadData<ProjectBoardModel, dynamic>(
            "dbo.spProjectBoards_GetAllAdminByProjectId",
            new { ProjectId = projectId });

        return results;
    }

    public async Task<ProjectBoardModel?> GetId(string id)
    {
        var results = await DB.LoadData<ProjectBoardModel, dynamic>(
            "dbo.spProjectBoards_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task Insert(ProjectBoardModel model)
    {
        model.Id = Ids.NewId();
        await DB.SaveData("dbo.spProjectBoards_Insert",
            new { Id = model.Id, ProjectId = model.ProjectId, Order = model.Order, Title = model.Title });
    }

    public async Task Update(ProjectBoardModel model)
    {
        await DB.SaveData("dbo.spProjectBoards_Update",
            new { Id = model.Id, ProjectId = model.ProjectId, Order = model.Order, Title = model.Title });
    }

    public Task Delete(string id) =>
        DB.SaveData("dbo.spProjectBoards_Delete",
            new { Id = id });

    public Task InitBoards(string projectId) =>
        DB.SaveData("dbo.spProjectBoards_Init",
            new { ProjectId = projectId, BoardIdNew = Ids.NewId(), BoardIdInProgress = Ids.NewId(), BoardIdDone = Ids.NewId() });
}