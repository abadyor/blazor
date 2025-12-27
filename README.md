# Blazor WebAssembly Application

A modern Blazor WebAssembly application template with a complete project structure and VS Code integration.

## Features

- **Blazor WebAssembly**: Client-side web UI framework using C# instead of JavaScript
- **Component-Based Architecture**: Reusable Razor components for building interactive UIs
- **Routing**: Built-in navigation with multiple pages (Home, Counter, Fetch Data)
- **CSS Isolation**: Scoped styling for individual components
- **VS Code Integration**: Pre-configured launch and task configurations

## Project Structure

```
blazor/
├── BlazorApp/
│   ├── Pages/               # Razor page components
│   │   ├── Index.razor      # Home page
│   │   ├── Counter.razor    # Interactive counter demo
│   │   └── FetchData.razor  # Data fetching example
│   ├── Shared/              # Shared components
│   │   ├── MainLayout.razor # Main layout wrapper
│   │   ├── NavMenu.razor    # Navigation menu
│   │   └── SurveyPrompt.razor # Survey prompt component
│   ├── wwwroot/             # Static web assets
│   │   ├── css/             # Stylesheets
│   │   ├── sample-data/     # Sample JSON data
│   │   └── index.html       # Main HTML entry point
│   ├── App.razor            # Root component with routing
│   ├── Program.cs           # Application entry point
│   ├── _Imports.razor       # Global using directives
│   └── BlazorApp.csproj     # Project configuration
├── .vscode/                 # VS Code configuration
│   ├── launch.json          # Debug configuration
│   └── tasks.json           # Build tasks
├── .gitignore               # Git ignore rules
└── README.md                # This file
```

## Prerequisites

To run this application, you need:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio Code](https://code.visualstudio.com/) (recommended)
- [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for VS Code

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/abadyor/blazor.git
cd blazor
```

### 2. Build the Project

```bash
cd BlazorApp
dotnet build
```

### 3. Run the Application

```bash
dotnet run
```

The application will start and be available at `https://localhost:5001` (or the URL shown in the console).

### 4. Development with Hot Reload

For development with automatic reloading:

```bash
dotnet watch run
```

## VS Code Integration

This project includes VS Code configurations for debugging and building:

### Debug Configuration

Press `F5` or use the "Run and Debug" panel to launch the application with debugging support.

### Build Tasks

Access build tasks via `Ctrl+Shift+B` (Windows/Linux) or `Cmd+Shift+B` (Mac):

- **build**: Compile the project
- **publish**: Create a production build
- **watch**: Run with hot reload

## Pages Overview

### Home (`/`)
The landing page with a welcome message and survey prompt.

### Counter (`/counter`)
An interactive component demonstrating state management and event handling. Click the button to increment the counter.

### Fetch Data (`/fetchdata`)
Demonstrates asynchronous data fetching and display in a table format using sample weather data.

## Technologies Used

- **Blazor WebAssembly**: Framework for building interactive web UIs with C#
- **ASP.NET Core 8.0**: Modern web framework
- **Razor Components**: Component-based UI framework
- **CSS**: Styling with component isolation
- **Bootstrap**: CSS framework (referenced in index.html)

## Project Configuration

### Target Framework
- .NET 8.0

### Key NuGet Packages
- `Microsoft.AspNetCore.Components.WebAssembly` (8.0.0)
- `Microsoft.AspNetCore.Components.WebAssembly.DevServer` (8.0.0)

## Development Tips

### Adding a New Page

1. Create a new `.razor` file in the `Pages` folder
2. Add the `@page` directive with your route
3. Add a link in `Shared/NavMenu.razor`

Example:
```razor
@page "/mypage"

<PageTitle>My Page</PageTitle>

<h1>My New Page</h1>
```

### Component Communication

Use `[Parameter]` attributes for parent-to-child communication:

```csharp
@code {
    [Parameter]
    public string Title { get; set; }
}
```

### CSS Isolation

Create a `.razor.css` file with the same name as your component for scoped styles.

## Deployment

### Publish for Production

```bash
dotnet publish -c Release
```

The output will be in `bin/Release/net8.0/publish/wwwroot/` and can be deployed to any static web host.

### Hosting Options

- Azure Static Web Apps
- GitHub Pages
- Netlify
- Vercel
- Any web server that can serve static files

## Resources

- [Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- [Blazor Tutorial](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro)
- [Razor Component Syntax](https://docs.microsoft.com/aspnet/core/blazor/components/)
- [.NET API Browser](https://docs.microsoft.com/dotnet/api/)

## License

This project is open source and available under the MIT License.

## Support

For issues or questions:
- Create an issue in the repository
- Check the [Blazor documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- Visit the [.NET community](https://dotnet.microsoft.com/platform/community)
