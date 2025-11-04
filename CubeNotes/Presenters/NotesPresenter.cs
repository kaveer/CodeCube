using CubeNotes.Interfaces;
using CubeNotes.Models;
using CubeNotes.Services;

namespace CubeNotes.Presenters;

public class NotesPresenter
{
 private readonly INotesView _view;
    private readonly NotesRepository _repository;
    private List<Note> _allNotes = new();

    public NotesPresenter(INotesView view, NotesRepository repository)
    {
     _view = view;
      _repository = repository;
    }

    public async Task LoadNotesAsync()
    {
        try
        {
   _view.ShowLoading(true);
            _allNotes = await _repository.GetAllNotesAsync();
            
        if (_allNotes.Count == 0)
  {
    _view.ShowEmptyState();
            }
    else
       {
        _view.ShowNotes(_allNotes);
       }
        }
        catch (Exception ex)
        {
          _view.ShowError($"Failed to load notes: {ex.Message}");
 }
        finally
        {
            _view.ShowLoading(false);
        }
    }

    public async Task SearchNotesAsync(string query)
    {
        try
    {
            _view.ShowLoading(true);
     var notes = await _repository.SearchNotesAsync(query);
          
       if (notes.Count == 0)
       {
      _view.ShowEmptyState();
            }
            else
        {
      _view.ShowNotes(notes);
         }
        }
        catch (Exception ex)
        {
       _view.ShowError($"Search failed: {ex.Message}");
      }
        finally
     {
      _view.ShowLoading(false);
        }
    }

    public async Task DeleteNoteAsync(Note note)
    {
        try
        {
            await _repository.DeleteNoteAsync(note);
       _view.ShowSuccess("Note deleted");
      await LoadNotesAsync();
        }
        catch (Exception ex)
        {
       _view.ShowError($"Failed to delete note: {ex.Message}");
        }
    }

    public async Task TogglePinAsync(Note note)
  {
        try
        {
            await _repository.TogglePinAsync(note);
            await LoadNotesAsync();
    }
catch (Exception ex)
      {
   _view.ShowError($"Failed to pin note: {ex.Message}");
        }
    }

    public async Task ToggleArchiveAsync(Note note)
    {
        try
        {
         await _repository.ToggleArchiveAsync(note);
     _view.ShowSuccess(note.IsArchived ? "Note archived" : "Note unarchived");
            await LoadNotesAsync();
        }
        catch (Exception ex)
   {
            _view.ShowError($"Failed to archive note: {ex.Message}");
        }
    }

    public void CreateNewNote()
    {
        _view.NavigateToNoteEditor(null);
    }

    public void EditNote(Note note)
    {
        _view.NavigateToNoteEditor(note);
    }
}
