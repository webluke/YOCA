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
    public Task<IEnumerable<ProjectTaskModel>> GetAllAdmin()
    {
        var results = DB.LoadData<ProjectTaskModel, dynamic>("dbo.spProjectTasks_GetAllAdmin", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetProjectTasks(string projectId)
    {
        var results = await DB.LoadData<ProjectTaskModel, dynamic>(
            "dbo.spProjectTasks_GetAllByProjectId",
            new { ProjectId = projectId });

        return results;
    }
    public async Task<IEnumerable<ProjectTaskModel>> GetProjectTasksAdmin(string projectId)
    {
        var results = await DB.LoadData<ProjectTaskModel, dynamic>(
            "dbo.spProjectTasks_GetAllAdminByProjectId",
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
            new { Id = pt.Id, ProjectId = pt.ProjectId, BoardId = pt.BoardId, Order = pt.Order, Status = pt.Status, Title = pt.Title, Description = pt.Description });
    }

    public async Task Update(ProjectTaskModel pt)
    {
        await DB.SaveData("dbo.spProjectTasks_Update",
            new { Id = pt.Id, ProjectId = pt.ProjectId, BoardId = pt.BoardId, Order = pt.Order, Status = pt.Status, Title = pt.Title, Description = pt.Description });
    }

    public Task Delete(string id) =>
        DB.SaveData("dbo.spProjectTasks_Delete",
            new { Id = id });
}
