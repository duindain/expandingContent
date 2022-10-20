namespace ExpandingContent;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		//Work around for button missing for some reason when the boxview is enlarged
		var vm = BindingContext as MainPageVM;
		vm?.ChangeHeightOfBoxViewCmd?.Execute(null);

    }
}


