using CubeNotes.Interfaces;
using CubeNotes.Models;
using CubeNotes.Presenters;
using CubeNotes.Services;

namespace CubeNotes.Views;

public partial class NoteEditorPage : ContentPage, INoteEditorView
{
    private readonly NoteEditorPresenter _presenter;
    private readonly int? _noteId;
 private string _selectedColor = "#FFFFFF";

    public NoteEditorPage(int? noteId = null)
    {
  InitializeComponent();
  
   _noteId = noteId;
 var repository = new NotesRepository();
  _presenter = new NoteEditorPresenter(this, repository);
    }

    protected override async void OnAppearing()
    {
    base.OnAppearing();
  await _presenter.LoadNoteAsync(_noteId);
    }

    // INoteEditorView Implementation
    public void ShowNote(Note note)
    {
   MainThread.BeginInvokeOnMainThread(() =>
      {
    TitleEntry.Text = note.Title;
  ContentEditor.Text = note.Content;
      TagsEntry.Text = note.Tags;
  _selectedColor = note.Color;
  UpdateColorSelection();
    });
    }

    public void ShowSaving(bool isSaving)
    {
 MainThread.BeginInvokeOnMainThread(() =>
      {
     SavingIndicator.IsRunning = isSaving;
  SavingIndicator.IsVisible = isSaving;
        });
 }

    public void ShowError(string message)
    {
  MainThread.BeginInvokeOnMainThread(async () =>
  {
    await DisplayAlert("Error", message, "OK");
    });
    }

    public void NavigateBack()
 {
  MainThread.BeginInvokeOnMainThread(async () =>
   {
         await Navigation.PopAsync();
  });
    }

    public void ShowDeleteConfirmation()
    {
    MainThread.BeginInvokeOnMainThread(async () =>
      {
     var result = await DisplayAlert("Delete Note", 
  "Are you sure you want to delete this note?", 
 "Delete", "Cancel");
 
  if (result)
        {
await _presenter.ConfirmDeleteAsync();
      }
        });
    }

    // Event Handlers
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await _presenter.SaveNoteAsync(
            TitleEntry.Text ?? string.Empty,
 ContentEditor.Text ?? string.Empty,
  TagsEntry.Text ?? string.Empty,
  _selectedColor
        );
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
  await Navigation.PopAsync();
    }

private void OnDeleteClicked(object sender, EventArgs e)
    {
  _presenter.DeleteNote();
    }

    private void OnColorSelected(object sender, TappedEventArgs e)
    {
   if (sender is Border border && border.StyleId != null)
    {
     _selectedColor = border.StyleId switch
      {
  "ColorWhite" => "#FFFFFF",
 "ColorYellow" => "#FEF3C7",
"ColorGreen" => "#D1FAE5",
           "ColorBlue" => "#DBEAFE",
     "ColorPurple" => "#EDE9FE",
          "ColorPink" => "#FCE7F3",
    _ => "#FFFFFF"
    };
 
      UpdateColorSelection();
      }
    }

    private void UpdateColorSelection()
    {
 // Reset all borders
  ColorWhite.Stroke = Colors.Transparent;
 ColorYellow.Stroke = Colors.Transparent;
        ColorGreen.Stroke = Colors.Transparent;
   ColorBlue.Stroke = Colors.Transparent;
      ColorPurple.Stroke = Colors.Transparent;
     ColorPink.Stroke = Colors.Transparent;

      // Highlight selected color
  var selectedBorder = _selectedColor switch
   {
 "#FFFFFF" => ColorWhite,
       "#FEF3C7" => ColorYellow,
  "#D1FAE5" => ColorGreen,
      "#DBEAFE" => ColorBlue,
      "#EDE9FE" => ColorPurple,
   "#FCE7F3" => ColorPink,
_ => ColorWhite
    };

  selectedBorder.Stroke = Color.FromArgb("#6366F1");
   selectedBorder.StrokeThickness = 3;
    }
}
