# ?? CubeNotes - Beautiful Notes App

A modern, feature-rich notes-taking application built with .NET MAUI 9 following MVP (Model-View-Presenter) architecture.

## ? Features

### Core Functionality
- ? **Create, Edit, and Delete Notes**
- ? **Real-time Search** - Find notes instantly as you type
- ? **Tags System** - Organize notes with comma-separated tags
- ? **Color Coding** - 6 beautiful color options for notes
- ? **Pin Important Notes** - Keep important notes at the top
- ? **Archive Notes** - Archive old notes without deleting
- ? **Offline Storage** - SQLite database for local data persistence
- ? **Modern UI/UX** - Clean, intuitive interface with smooth animations

### UI/UX Highlights
- ?? **Modern Color Palette** - Purple/Blue gradient theme
- ?? **Dark Mode Support** - Automatic theme switching
- ?? **Responsive Design** - Optimized for all screen sizes
- ? **Accessibility** - Screen reader support
- ?? **Empty States** - Helpful illustrations and messages
- ? **Smooth Animations** - Polished user experience
- ?? **Material Design** - Following modern design principles

## ??? Architecture - MVP Pattern

The app follows the **Model-View-Presenter** pattern for clean separation of concerns:

```
CubeNotes/
??? Models/            # Data models
?   ??? Note.cs# Note entity with SQLite attributes
?
??? Views/      # XAML pages (View layer)
?   ??? NotesListPage.xaml    # Main notes list
?   ??? NoteEditorPage.xaml   # Note creation/editing
?
??? Presenters/     # Business logic (Presenter layer)
?   ??? NotesPresenter.cs   # Handles notes list logic
?   ??? NoteEditorPresenter.cs # Handles note editing logic
?
??? Interfaces/    # Contracts
?   ??? INotesView.cs         # Notes list view interface
?   ??? INoteEditorView.cs # Note editor view interface
?
??? Services/ # Data access layer
?   ??? NotesRepository.cs    # SQLite database operations
?
??? Converters/                # Value converters
?   ??? StringNotEmptyConverter.cs
?
??? Resources/        # App resources
    ??? Styles/   # Colors and styles
  ??? Images/  # Icons and images
```

### MVP Benefits
- ? **Testability** - Business logic separated from UI
- ? **Maintainability** - Clear separation of concerns
- ? **Reusability** - Presenters can work with different views
- ? **Scalability** - Easy to add new features

## ?? Design System

### Color Palette
- **Primary**: `#6366F1` (Indigo)
- **Accent**: `#8B5CF6` (Purple)
- **Success**: `#10B981` (Green)
- **Warning**: `#F59E0B` (Amber)
- **Danger**: `#EF4444` (Red)

### Note Colors
- White (`#FFFFFF`)
- Yellow (`#FEF3C7`)
- Green (`#D1FAE5`)
- Blue (`#DBEAFE`)
- Purple (`#EDE9FE`)
- Pink (`#FCE7F3`)

## ?? Dependencies

```xml
<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
<PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="9.0.10" />
<PackageReference Include="sqlite-net-pcl" Version="1.9.172" />
<PackageReference Include="SQLitePCLRaw.bundle_green" Version="2.1.10" />
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.3.2" />
```

## ?? Getting Started

### Prerequisites
- Visual Studio 2022 (17.8 or later)
- .NET 9 SDK
- Android SDK (for Android development)
- Xcode (for iOS development on Mac)

### Building the App

1. **Clone the repository**
```bash
git clone https://github.com/kaveer/CodeCube.git
cd CodeCube/CubeNotes
```

2. **Restore NuGet packages**
```bash
dotnet restore
```

3. **Build the project**
```bash
dotnet build
```

4. **Run on Android**
```bash
dotnet build -t:Run -f net9.0-android
```

5. **Run on iOS** (Mac only)
```bash
dotnet build -t:Run -f net9.0-ios
```

6. **Run on Windows**
```bash
dotnet build -t:Run -f net9.0-windows10.0.19041.0
```

## ?? Platform Support

- ? **Android** (API 21+)
- ? **iOS** (15.0+)
- ? **macOS** (Catalyst 15.0+)
- ? **Windows** (10.0.17763.0+)

## ?? Configuration

### Database Location
The SQLite database is stored at:
```
FileSystem.AppDataDirectory/notes.db3
```

### Changing Theme Colors
Edit `Resources/Styles/Colors.xaml` to customize the color scheme.

## ?? Usage

### Creating a Note
1. Tap the **+** button (bottom-right floating action button)
2. Enter a title and content
3. Optionally add tags (comma-separated)
4. Choose a color for the note
5. Tap the **?** checkmark to save

### Editing a Note
1. Tap on any note in the list
2. Make your changes
3. Tap the **?** checkmark to save

### Searching Notes
- Type in the search bar at the top
- Results update in real-time
- Searches through titles, content, and tags

### Deleting a Note
1. Open the note in edit mode
2. Tap the **??** trash icon
3. Confirm deletion

### Organizing Notes
- **Tags**: Add comma-separated tags to categorize notes
- **Colors**: Assign colors for visual organization
- **Pin**: Keep important notes at the top (coming soon)
- **Archive**: Move old notes to archive (coming soon)

## ?? Roadmap

### Planned Features
- [ ] Note pinning functionality
- [ ] Archive/unarchive notes
- [ ] Rich text formatting
- [ ] Image attachments
- [ ] Cloud sync
- [ ] Note sharing
- [ ] Reminders and notifications
- [ ] Note templates
- [ ] Export to PDF/Markdown
- [ ] Widget support

## ?? Testing

The MVP architecture makes unit testing straightforward:

```csharp
// Example: Testing NotesPresenter
var mockView = new Mock<INotesView>();
var mockRepository = new Mock<NotesRepository>();
var presenter = new NotesPresenter(mockView.Object, mockRepository.Object);

// Test methods
await presenter.LoadNotesAsync();
mockView.Verify(v => v.ShowLoading(true), Times.Once);
```

## ?? Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## ?? License

This project is licensed under the MIT License - see the LICENSE file for details.

## ????? Author

**CubeCode**
- GitHub: [@kaveer](https://github.com/kaveer)

## ?? Acknowledgments

- Built with [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
- SQLite database with [sqlite-net-pcl](https://github.com/praeclarum/sqlite-net)
- Icons and design inspiration from Material Design

## ?? Screenshots

### Light Mode
- Clean, modern interface
- Easy-to-read typography
- Colorful note cards

### Dark Mode
- Eye-friendly dark theme
- Consistent color scheme
- Automatic theme switching

## ?? Tips & Tricks

### Performance
- The app uses SQLite for fast, offline-first data storage
- Search results are indexed for quick retrieval
- UI updates are performed on the main thread for smooth animations

### Data Management
- Notes are automatically saved
- No manual sync required
- Database is backed up with app data

### Shortcuts
- Pull to refresh notes list (coming soon)
- Swipe actions for quick delete/archive (coming soon)

---

**Made with ?? using .NET MAUI 9**
