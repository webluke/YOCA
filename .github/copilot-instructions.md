# YOCA - Year of Code Application

## Architecture Overview

YOCA is a .NET 9 Blazor Server application with a three-layer architecture:

- **YOCA.Fluent**: Web UI layer using Blazor Server + Fluent UI components
- **YOCA.DataAccess**: Business logic and data access layer using Dapper ORM
- **YOCA.Db**: SQL Server database project with stored procedures

## Key Patterns & Conventions

### Data Access Pattern
```csharp
// Data access classes follow this pattern:
public class DayOfCodeDataAccess
{
    private readonly ISqlDataAccess DB;
    
    public async Task<IEnumerable<DayOfCodeModel>> GetDays()
    {
        return await DB.LoadData<DayOfCodeModel, dynamic>(
            "dbo.spDayOfCode_GetAll", new { });
    }
}
```

### Stored Procedure Naming
All stored procedures follow: `sp{Entity}_{Action}`
- `spDayOfCode_GetAll`, `spDayOfCode_Insert`, `spDayOfCode_Update`
- Located in `YOCA.Db/dbo/Stored Procedures/{Entity}/`

### ID Generation
Use `Ids.NewId()` for generating 10-character NanoIDs instead of GUIDs:
```csharp
string newId = Ids.NewId(); // Returns 10-char NanoID like "abc123defg"
```

### Dependency Injection
Services registered as singletons in `Program.cs`:
```csharp
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<DayOfCodeDataAccess>();
```

### Markdown Processing
Use `IMarkdownService` for rendering markdown with syntax highlighting:
```csharp
@inject IMarkdownService MarkdownService
@((MarkupString)MarkdownService.Parse(day.Summary))
```

## Development Workflow

### Running the Application
```bash
# From YOCA.Fluent directory
dotnet run
# Runs on http://localhost:5186 and https://localhost:7074
```

### Database Setup
- Development: Uses LocalDB (`(localdb)\MSSQLLocalDB`)
- Production: Configure connection string in `appsettings.json`
- Database name: `YoC`

### Authentication
- Auth0 integration configured in `Program.cs`
- Requires `Auth0:Domain` and `Auth0:ClientId` in configuration

## Component Patterns

### Blazor Components
- Use `@rendermode InteractiveServer` for interactive components
- Fluent UI components: `FluentCard`, `FluentButton`, `FluentStack`
- Parameter binding: `[Parameter] public DayOfCodeModel day { get; set; }`

### File Structure
```
YOCA.Fluent/Components/
├── Pages/          # Route components (@page directives)
├── Views/          # Reusable view components
├── Layout/         # Layout components
└── Admin/          # Admin-specific components
```

## Configuration

### Connection Strings
```json
{
  "ConnectionStrings": {
    "Default": "Data Source=(localdb)\\MSSQLLocalDB;..."
  }
}
```

### External Dependencies
- **Auth0**: Authentication
- **Markdig**: Markdown processing with Prism syntax highlighting
- **ToastUI Editor**: Rich text editing
- **Fluent UI**: Component library

## Common Tasks

### Adding New Entity
1. Create model in `YOCA.DataAccess/Models/`
2. Create stored procedures in `YOCA.Db/dbo/Stored Procedures/{Entity}/`
3. Create data access class in `YOCA.DataAccess/DataAccess/`
4. Register service in `YOCA.Fluent/Program.cs`
5. Create UI components in `YOCA.Fluent/Components/`

### Database Changes
1. Modify stored procedures in `YOCA.Db/`
2. Update models if schema changes
3. Test with LocalDB first

### UI Components
- Use Fluent UI components for consistency
- Follow existing patterns in `Views/` and `Pages/`
- Inject services at component level when needed</content>
<parameter name="filePath">d:\Code\YearOfCode\Website\YOCA\.github\copilot-instructions.md