using diary.Models;
using diary.Utils;

namespace diary;

public partial class ListPage : ContentPage
{
    private readonly DatabaseHelper databaseHelper;

    public ListPage()
    {
        InitializeComponent();
        databaseHelper = DatabaseHelper.GetInstanceAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListPageView.ItemsSource = GenFakeData();
    }

    private List<ListItem> GenFakeData()
    {
        var list = new List<ListItem>();
        for (int i = 0; i < 12; i++)
        {
            list.Add(new ListItem(i, DateTime.Now, "This is content @" + i));
        }
        return list;
    }

    private void ListPageViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var alert = DisplayAlert("����", Constants.DatabasePath, "OK");
    }

    private async void NewItem(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync(AppShell.PageName.Edit.ToString());
    }

    private void ShowVersion(object sender, EventArgs e)
    {

    }

    private void Exit(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}