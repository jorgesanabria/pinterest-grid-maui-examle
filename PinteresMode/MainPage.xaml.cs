using System.Collections.ObjectModel;

namespace PinteresMode;

public partial class MainPage : ContentPage
{
    private bool isLeft = true;
    public ObservableCollection<ImageContent> CollectionLeft { get; set; }
    public ObservableCollection<ImageContent> CollectionRight { get; set; }
    public MainPage()
    {
        InitializeComponent();
        CollectionLeft = new();
        CollectionRight = new();

        BindingContext = this;
    }

    private void Agregar_OnClicked(object sender, EventArgs e)
    {
        var height = new Random().Next(100, 301);
        if (isLeft)
        {
            var lastIndex = CollectionLeft.Count() -1;
            var element = left.Children.ElementAtOrDefault(lastIndex);
            if (element is VisualElement v)
            {
                var posY = v.Y;
                scroll.ScrollToAsync(0, posY, true);
            }
            CollectionLeft.Add(new ImageContent
            {
                Url = $"https://picsum.photos/200/{height}",
                Width = 200,
                Height = height
            });
            isLeft = false;
        }
        else
        {
            var lastIndex = CollectionRight.Count() - 1;
            var element = right.Children.ElementAtOrDefault(lastIndex);
            if (element is VisualElement v)
            {
                var posY = v.Y;
                scroll.ScrollToAsync(0, posY, true);
            }
            CollectionRight.Add(new ImageContent
            {
                Url = $"https://picsum.photos/200/{height}",
                Width = 200,
                Height = height
            });
            isLeft = true;
        }
    }
}

public class ImageContent
{
    public string Url { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}