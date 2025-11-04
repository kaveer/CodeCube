using CubeNotes.Models;

namespace CubeNotes.Interfaces;

public interface INotesView
{
    void ShowNotes(List<Note> notes);
    void ShowLoading(bool isLoading);
    void ShowError(string message);
    void ShowSuccess(string message);
    void NavigateToNoteEditor(Note? note = null);
    void ShowEmptyState();
}
