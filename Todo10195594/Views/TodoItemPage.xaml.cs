using Todo10195594.Data;
using Todo10195594.Models;
namespace Todo10195594.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
    TodoItem item;
    public TodoItem Item
    { 
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }
    TodoItemDatabase databae;
	public TodoItemPage(TodoItemDatabase todoItemDatabase)
	{
		InitializeComponent();
        databae = todoItemDatabase;
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item", "OK");
            return;
        }
        await databae.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await databae.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}