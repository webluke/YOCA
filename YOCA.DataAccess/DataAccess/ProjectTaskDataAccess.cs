using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class ProjectTaskDataAccess
{
    private readonly ISqlDataAccess DB;

    public ProjectTaskDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public Task<IEnumerable<ProjectTaskModel>> GetAll()
    {
        var results = DB.LoadData<ProjectTaskModel, dynamic>("dbo.spProjectTasks_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetProjectTasks(string projectId)
    {
        var results = await DB.LoadData<ProjectTaskModel, dynamic>(
            "dbo.spProjectTasks_GetAllByProjectId",
            new { ProjectId = projectId });

        return results;
    }


    public async Task<ProjectTaskModel?> GetId(string id)
    {
        var results = await DB.LoadData<ProjectTaskModel, dynamic>(
            "dbo.spProjectTasks_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task Insert(ProjectTaskModel pt)
    {
        pt.Id = Ids.NewId();
        await DB.SaveData("dbo.spProjectTasks_Insert",
            new { pt });
    }

    public Task UpdatePost(ProjectTaskModel pt) =>
        DB.SaveData("dbo.spProjectTasks_Update", pt);

    public Task DeletePost(string id) =>
        DB.SaveData("dbo.spProjectTasks_Delete",
            new { Id = id });
}
