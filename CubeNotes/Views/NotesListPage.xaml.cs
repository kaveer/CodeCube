using CubeNotes.Interfaces;
using CubeNotes.Models;
using CubeNotes.Presenters;
using CubeNotes.Services;

namespace CubeNotes.Views;

public partial class NotesListPage : ContentPage, INotesView
{
    private readonly NotesPresenter _presenter;

    public NotesListPage()
    {
        InitializeComponent();
        
        var repository = new NotesRepository();
  _presenter = new NotesPresenter(this, repository);
    }

  protected override async void OnAppearing()
    {
  base.OnAppearing();
  await _presenter.LoadNotesAsync();
    }

    // INotesView Implementation
    public void ShowNotes(List<Note> notes)
    {
        MainThread.BeginInvokeOnMainThread(() =>
      {
        NotesCollectionView.ItemsSource = notes;
        });
    }

    public void ShowLoading(bool isLoading)
  {
  MainThread.BeginInvokeOnMainThread(() =>
      {
   LoadingIndicator.IsRunning = isLoading;
     LoadingIndicator.IsVisible = isLoading;
    NotesCollectionView.IsVisible = !isLoading;
 });
    }

    public void ShowError(string message)
 {
      MainThread.BeginInvokeOnMainThread(async () =>
        {
 await DisplayAlert("Error", message, "OK");
     });
    }

    public void ShowSuccess(string message)
    {
 MainThread.BeginInvokeOnMainThread(async () =>
    {
          await DisplayAlert("Success", message, "OK");
        });
    }

    public void NavigateToNoteEditor(Note? note = null)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
     {
  await Navigation.PushAsync(new NoteEditorPage(note?.Id));
  });
    }

    public void ShowEmptyState()
    {
    MainThread.BeginInvokeOnMainThread(() =>
        {
       NotesCollectionView.ItemsSource = new List<Note>();
     });
    }

    // Event Handlers
    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        await _presenter.SearchNotesAsync(e.NewTextValue);
    }

private void OnAddNoteTapped(object sender, TappedEventArgs e)
    {
   _presenter.CreateNewNote();
    }

    private void OnNoteTapped(object sender, TappedEventArgs e)
    {
  if (sender is Border border && border.BindingContext is Note note)
     {
     _presenter.EditNote(note);
  }
    }
}
