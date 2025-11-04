using CubeNotes.Models;

namespace CubeNotes.Interfaces;

public interface INoteEditorView
{
    void ShowNote(Note note);
    void ShowSaving(bool isSaving);
    void ShowError(string message);
    void NavigateBack();
    void ShowDeleteConfirmation();
}
