namespace ColorPickerMobile;

public partial class Picker : ContentPage
{
	public Picker()
	{
		InitializeComponent();
	}
    string hexColor = "#000000";
    int red = 0;
    int green = 0;
    int blue = 0;
    private void sliderRed(object sender, ValueChangedEventArgs e)
	{
		red = (int)redSlider.Value;
        colorChange();
    }
    private void sliderGreen(object sender, ValueChangedEventArgs e)
    {
        green = (int)greenSlider.Value;
        colorChange();
    }
    private void sliderBlue(object sender, ValueChangedEventArgs e)
    {
        blue = (int)blueSlider.Value;
        colorChange();
    }
    private void colorChange()
    {
        niggaColor.BackgroundColor = new Color(red, green, blue);
        ButtonColor.BackgroundColor = new Color(red, green, blue);
        hexColor = RGBToHexConverter.ConvertRgbToHex(red, green, blue);
        Hexd.Text = hexColor;
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {
        var random = new Random();
        redSlider.Value = random.Next(0, 255);
        greenSlider.Value = random.Next(0, 255);
        blueSlider.Value = random.Next(0, 255);
    }
    private async void copyButtonClicked(object sender, EventArgs e) =>
    await Clipboard.Default.SetTextAsync($"{hexColor}");
}
public class RGBToHexConverter
{
    public static string ConvertRgbToHex(int red, int green, int blue)
    {
        return $"#{red:X2}{green:X2}{blue:X2}";
    }
}