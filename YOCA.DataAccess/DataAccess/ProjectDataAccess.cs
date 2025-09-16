using YOCA.DataAccess.Models;
using YOCA.DataAccess.Tools;

namespace YOCA.DataAccess.DataAccess;

public class ProjectDataAccess
{
    private readonly ISqlDataAccess DB;
    private readonly ProjectBoardDataAccess BoardDB;

    public ProjectDataAccess(ISqlDataAccess db, ProjectBoardDataAccess boardDb)
    {
        DB = db;
        BoardDB = boardDb;
    }

    public async Task<IEnumerable<ProjectModel>> GetAll()
    {
        var results = await DB.LoadData<ProjectModel, dynamic>("dbo.spProjects_GetAll", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllAdmin()
    {
        var results = await DB.LoadData<ProjectModel, dynamic>("dbo.spProjects_GetAllAdmin", new { });
        return results;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllAdminWithTasks()
    {
        return await DB.LoadMultipleData("dbo.spProject_GetAllAdminWithTasks", new { }, async (reader) =>
        {
            var projects = (await reader.ReadAsync<ProjectModel>()).ToList();
            var boards = (await reader.ReadAsync<ProjectBoardModel>()).ToList();
            var tasks = (await reader.ReadAsync<ProjectTaskModel>()).ToList();

            foreach (var project in projects)
            {
                project.Boards = boards.Where(b => b.ProjectId == project.Id).ToList();
                foreach (var board in project.Boards)
                {
                    board.Tasks = tasks.Where(t => t.BoardId == board.Id).ToList();
                }
            }

            return projects;
        });
    }

    public async Task<IEnumerable<ProjectModel>> GetAllWithTasks()
    {
        return await DB.LoadMultipleData("dbo.spProject_GetAllWithTasks", new { }, async (reader) =>
        {
            var projects = (await reader.ReadAsync<ProjectModel>()).ToList();
            var boards = (await reader.ReadAsync<ProjectBoardModel>()).ToList();
            var tasks = (await reader.ReadAsync<ProjectTaskModel>()).ToList();

            foreach (var project in projects)
            {
                project.Boards = boards.Where(b => b.ProjectId == project.Id).ToList();
                foreach (var board in project.Boards)
                {
                    board.Tasks = tasks.Where(t => t.BoardId == board.Id).ToList();
                }
            }

            return projects;
        });
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
            //result.Tasks = (await DB.LoadData<ProjectTaskModel, dynamic>(
            //    "dbo.spProjectTasks_GetAllByProjectId",
            //    new { ProjectId = result.Id })).ToList();
        }

        return result;
    }

    public async Task Insert(ProjectModel p)
    {
        p.Id = Ids.NewId();
        await DB.SaveData("dbo.spProjects_Insert",
            new { Id = p.Id, Order = p.Order, Status = p.Status, StartDate = p.StartDate, EndDate = p.EndDate, Title = p.Title, Description = p.Description });

        await BoardDB.InitBoards(p.Id);
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
