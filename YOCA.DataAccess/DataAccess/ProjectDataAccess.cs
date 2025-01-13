using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class ProjectDataAccess
{
    private readonly ISqlDataAccess DB;

    public ProjectDataAccess(ISqlDataAccess db)
    {
        DB = db;
    }

    public async Task<IEnumerable<ProjectModel>> GetAll()
    {
        var results = await DB.LoadData<ProjectModel, dynamic>("dbo.spProjects_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllWithTasks()
    {
        IEnumerable<ProjectModel> results = await DB.LoadData<ProjectModel, dynamic>("dbo.spProjects_GetAll", new { });
        foreach (var project in results)
        {
            project.Tasks = (await DB.LoadData<ProjectTaskModel, dynamic>(
                "dbo.spProjectTasks_GetAllByProjectId",
                new { ProjectId = project.Id })).ToList();
        }
        return results;
    }

    public async Task<ProjectModel?> GetId(string id)
    {
        var results = await DB.LoadData<ProjectModel, dynamic>(
            "dbo.spProjects_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task<ProjectModel?> GetIdWithTasks(string id)
    {
        var results = await DB.LoadData<ProjectModel, dynamic>(
            "dbo.spProjects_GetById",
            new { Id = id });

        var result = results.FirstOrDefault();

        if (result != null)
        {
            result.Tasks = (await DB.LoadData<ProjectTaskModel, dynamic>(
                "dbo.spProjectTasks_GetAllByProjectId",
                new { ProjectId = result.Id })).ToList();
        }

        return result;
    }

    public async Task Insert(ProjectModel p)
    {
        p.Id = Ids.NewId();
        await DB.SaveData("dbo.spProjects_Insert",
            new { Id = p.Id, Order = p.Order, Status = p.Status, StartDate = p.StartDate, EndDate = p.EndDate, Title = p.Title, Description = p.Description });
    }

    public async Task Update(ProjectModel p)
    {
        await DB.SaveData("dbo.spProjects_Update",
            new { Id = p.Id, Order = p.Order, Status = p.Status, StartDate = p.StartDate, EndDate = p.EndDate, Title = p.Title, Description = p.Description });
    }

    public async Task Delete(string id) => await
        DB.SaveData("dbo.spProjects_Delete",
            new { Id = id });
}
