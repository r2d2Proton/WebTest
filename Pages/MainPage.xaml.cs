using WebTest.Models;
using WebTest.PageModels;
using Microsoft.Maui.Controls;

namespace WebTest.Pages;

public partial class MainPage : ContentPage
{
    enum BabylonModels
    {
        PlaneModel,
        LottieModel
    };

    HtmlWebViewSource babylonPlaneModel = new HtmlWebViewSource
    {
        Html = "<html>" +
               "<body>" +
               "<script type=\"module\" src=\"https://cdn.jsdelivr.net/npm/@babylonjs/viewer/dist/babylon-viewer.esm.min.js\"></script>" +
               "<babylon-viewer source=\"https://assets.babylonjs.com/meshes/Demos/optimized/acrobaticPlane_variants.glb\" environment=\"auto\"></babylon-viewer>" +
               "</body>" +
               "</html>"
    };

    HtmlWebViewSource babylonLottieModel = new HtmlWebViewSource
    {
    };

    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;

        Loaded += async (s, e) => {
            MainWebView.Source = await GetModelAsync(BabylonModels.LottieModel);
        };
    }

    async Task<HtmlWebViewSource> GetModelAsync(BabylonModels model)
    {
        switch (model)
        {
            case BabylonModels.PlaneModel:
                return babylonPlaneModel;

            case BabylonModels.LottieModel:
                string txt = await AssetLoader.LoadTextFileAsync("babylonView.txt");
                babylonLottieModel.Html = txt;
                return babylonLottieModel;

            default:
                return babylonPlaneModel;
        }
    }
}
