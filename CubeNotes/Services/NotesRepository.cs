using SQLite;
using CubeNotes.Models;

namespace CubeNotes.Services;

public class NotesRepository
{
    private readonly SQLiteAsyncConnection _database;

    public NotesRepository()
    {
    var dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Note>().Wait();
    }

// Get all notes
    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _database.Table<Note>()
    .Where(n => !n.IsArchived)
            .OrderByDescending(n => n.IsPinned)
     .ThenByDescending(n => n.ModifiedDate)
        .ToListAsync();
    }

    // Get archived notes
    public async Task<List<Note>> GetArchivedNotesAsync()
    {
        return await _database.Table<Note>()
  .Where(n => n.IsArchived)
          .OrderByDescending(n => n.ModifiedDate)
       .ToListAsync();
    }

    // Get note by ID
    public async Task<Note?> GetNoteAsync(int id)
    {
 return await _database.Table<Note>()
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();
    }

    // Search notes
    public async Task<List<Note>> SearchNotesAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
   return await GetAllNotesAsync();

        query = query.ToLower();
    return await _database.Table<Note>()
            .Where(n => !n.IsArchived && 
              (n.Title.ToLower().Contains(query) || 
     n.Content.ToLower().Contains(query) ||
     n.Tags.ToLower().Contains(query)))
            .OrderByDescending(n => n.IsPinned)
   .ThenByDescending(n => n.ModifiedDate)
   .ToListAsync();
    }

    // Filter by tag
    public async Task<List<Note>> GetNotesByTagAsync(string tag)
    {
        return await _database.Table<Note>()
            .Where(n => !n.IsArchived && n.Tags.Contains(tag))
            .OrderByDescending(n => n.ModifiedDate)
.ToListAsync();
  }

    // Save note (insert or update)
    public async Task<int> SaveNoteAsync(Note note)
    {
        note.ModifiedDate = DateTime.Now;

      if (note.Id != 0)
   return await _database.UpdateAsync(note);
        else
        {
       note.CreatedDate = DateTime.Now;
 return await _database.InsertAsync(note);
 }
    }

    // Delete note
    public async Task<int> DeleteNoteAsync(Note note)
    {
 return await _database.DeleteAsync(note);
    }

    // Toggle pin
    public async Task<int> TogglePinAsync(Note note)
    {
    note.IsPinned = !note.IsPinned;
        return await SaveNoteAsync(note);
    }

  // Archive/Unarchive note
    public async Task<int> ToggleArchiveAsync(Note note)
    {
  note.IsArchived = !note.IsArchived;
  return await SaveNoteAsync(note);
    }

    // Get all unique tags
    public async Task<List<string>> GetAllTagsAsync()
    {
        var notes = await _database.Table<Note>().ToListAsync();
        var tags = notes
       .SelectMany(n => n.TagList)
         .Distinct()
          .OrderBy(t => t)
            .ToList();
        return tags;
    }

    // Get notes count
    public async Task<int> GetNotesCountAsync()
    {
        return await _database.Table<Note>()
       .Where(n => !n.IsArchived)
            .CountAsync();
    }
}
