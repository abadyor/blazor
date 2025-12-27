# Task Manager - Blazor WebAssembly Application

A modern, standalone task management application built with Blazor WebAssembly. This application runs entirely in the browser with local storage persistence - no backend server required.

## Features

- **Task Management**: Create, read, update, and delete tasks
- **Priority Levels**: Assign Low, Medium, High, or Urgent priority to tasks
- **Categories**: Organize tasks with customizable color-coded categories
- **Due Dates**: Set due dates and track overdue tasks
- **Filtering**: Filter tasks by status, priority, category, and search terms
- **Dashboard**: Overview with task statistics and quick access to today's and overdue tasks
- **Offline Support**: Works offline using browser local storage
- **Responsive Design**: Mobile-friendly interface using Bootstrap 5

## Screenshots

The application includes three main pages:

1. **Dashboard**: Overview with stats, quick add form, and today's/overdue tasks
2. **Tasks**: Full task list with filtering and CRUD operations
3. **Categories**: Manage task categories with custom colors

## Technology Stack

- **.NET 8** - Latest LTS version
- **Blazor WebAssembly** - Client-side web framework
- **Blazored.LocalStorage** - Type-safe local storage access
- **Bootstrap 5** - CSS framework for responsive design
- **Bootstrap Icons** - Icon library

## Prerequisites

To run this application, you need:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio Code](https://code.visualstudio.com/) (recommended)
- [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for VS Code
- A modern web browser (Chrome, Firefox, Edge, Safari)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/abadyor/blazor.git
cd blazor
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Run the Application

```bash
dotnet run --project TaskManager.Client
```

The application will start and be available at `https://localhost:5001` or `http://localhost:5000`

### 4. Development with Hot Reload

For development with automatic reloading:

```bash
dotnet watch run --project TaskManager.Client
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

## Project Structure

```
blazor/
├── TaskManager.Client/
│   ├── wwwroot/              # Static files
│   │   ├── css/              # Stylesheets
│   │   └── index.html        # Entry point
│   ├── Layout/               # Layout components
│   │   ├── MainLayout.razor  # Main layout wrapper
│   │   └── NavMenu.razor     # Navigation menu
│   ├── Pages/                # Routable pages
│   │   ├── Home.razor        # Dashboard page
│   │   ├── Tasks.razor       # Task list page
│   │   └── Categories.razor  # Category management
│   ├── Components/           # Reusable UI components
│   │   ├── TaskItem.razor    # Individual task display
│   │   ├── TaskList.razor    # Task list container
│   │   ├── TaskForm.razor    # Task create/edit form
│   │   ├── TaskFilter.razor  # Filter controls
│   │   └── ...               # Other components
│   ├── Models/               # Data models
│   │   ├── TodoTask.cs       # Task entity
│   │   ├── Category.cs       # Category entity
│   │   ├── Priority.cs       # Priority enum
│   │   └── TaskFilter.cs     # Filter criteria
│   ├── Services/             # Business logic services
│   │   ├── ITaskService.cs   # Task service interface
│   │   ├── TaskService.cs    # Task service implementation
│   │   └── ...               # Category services
│   ├── App.razor             # Root component
│   └── Program.cs            # Application entry point
├── .vscode/                  # VS Code configuration
├── .gitignore                # Git ignore rules
└── README.md                 # This file
```

## Data Models

### TodoTask
- `Id`: Unique identifier
- `Title`: Task title
- `Description`: Optional description
- `IsCompleted`: Completion status
- `CreatedAt`: Creation timestamp
- `DueDate`: Optional due date
- `CompletedAt`: Completion timestamp
- `Priority`: Low, Medium, High, or Urgent
- `CategoryIds`: Associated category IDs

### Category
- `Id`: Unique identifier
- `Name`: Category name
- `Color`: Hex color code for display

## Local Storage

Data is persisted in the browser's local storage under these keys:
- `taskmanager_tasks`: Task data
- `taskmanager_categories`: Category data

## Pages Overview

### Dashboard (`/`)
The landing page with task statistics, quick add form, and views for today's and overdue tasks.

### Tasks (`/tasks`)
Full task management with filtering, sorting, and CRUD operations.

### Categories (`/categories`)
Manage task categories with custom names and colors.

## Development Tips

### Adding a New Page

1. Create a new `.razor` file in the `Pages` folder
2. Add the `@page` directive with your route
3. Add a link in `Layout/NavMenu.razor`

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

## Building for Production

```bash
dotnet publish -c Release -o ./publish
```

The published files can be hosted on any static file server (GitHub Pages, Azure Static Web Apps, Netlify, etc.)

## Future Enhancements

- [ ] PWA support (offline capability, installable)
- [ ] Data export/import (JSON backup)
- [ ] Dark mode theme
- [ ] Recurring tasks
- [ ] Subtasks/checklists
- [ ] Drag-and-drop reordering
- [ ] Kanban board view
- [ ] Cloud sync integration

## Resources

- [Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- [Blazor Tutorial](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro)
- [Razor Component Syntax](https://docs.microsoft.com/aspnet/core/blazor/components/)
- [.NET API Browser](https://docs.microsoft.com/dotnet/api/)

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is open source and available under the MIT License.

## Support

For issues or questions:
- Create an issue in the repository
- Check the [Blazor documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- Visit the [.NET community](https://dotnet.microsoft.com/platform/community)
