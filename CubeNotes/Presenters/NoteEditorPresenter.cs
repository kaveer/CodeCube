using CubeNotes.Interfaces;
using CubeNotes.Models;
using CubeNotes.Services;

namespace CubeNotes.Presenters;

public class NoteEditorPresenter
{
    private readonly INoteEditorView _view;
    private readonly NotesRepository _repository;
    private Note _currentNote;

    public NoteEditorPresenter(INoteEditorView view, NotesRepository repository)
    {
 _view = view;
        _repository = repository;
 _currentNote = new Note();
    }

    public async Task LoadNoteAsync(int? noteId)
    {
        if (noteId.HasValue)
        {
            var note = await _repository.GetNoteAsync(noteId.Value);
            if (note != null)
            {
      _currentNote = note;
           _view.ShowNote(_currentNote);
     }
     }
        else
        {
      _currentNote = new Note();
            _view.ShowNote(_currentNote);
        }
    }

    public async Task SaveNoteAsync(string title, string content, string tags, string color)
    {
        try
      {
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(content))
            {
    _view.ShowError("Note cannot be empty");
          return;
   }

    _view.ShowSaving(true);

  _currentNote.Title = title;
   _currentNote.Content = content;
      _currentNote.Tags = tags;
  _currentNote.Color = color;

     await _repository.SaveNoteAsync(_currentNote);
       _view.NavigateBack();
  }
        catch (Exception ex)
        {
       _view.ShowError($"Failed to save note: {ex.Message}");
        }
        finally
        {
    _view.ShowSaving(false);
        }
    }

    public void DeleteNote()
    {
        _view.ShowDeleteConfirmation();
    }

    public async Task ConfirmDeleteAsync()
    {
        try
        {
      if (_currentNote.Id != 0)
        {
  await _repository.DeleteNoteAsync(_currentNote);
    }
            _view.NavigateBack();
   }
   catch (Exception ex)
      {
          _view.ShowError($"Failed to delete note: {ex.Message}");
     }
    }

    public void Cancel()
    {
    _view.NavigateBack();
    }
}
