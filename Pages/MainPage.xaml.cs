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

    WebView _selectedLottie;
    WebView _selectedAnimation;

    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;

        Loaded += async (s, e) => {
            LottieViewLeft.Source = await GetModelAsync(BabylonModels.LottieModel);
            LottieViewMiddle.Source = await GetModelAsync(BabylonModels.LottieModel);
            LottieViewRight.Source = await GetModelAsync(BabylonModels.LottieModel);

            AnimationViewLeft.Source = await GetModelAsync(BabylonModels.PlaneModel);
            AnimationViewRight.Source = await GetModelAsync(BabylonModels.PlaneModel);
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

    void OnLottieFocused(object sender, FocusEventArgs e)
    {
        _selectedLottie = (WebView)sender;
        UpdateLottieFrameBorders();
    }

    void OnLottieUnfocused(object sender, FocusEventArgs e)
    {
        UpdateLottieFrameBorders();
    }

    void UpdateLottieFrameBorders()
    {
        LottieLeftFrame.Stroke = Colors.Transparent;
        LottieMiddleFrame.Stroke = Colors.Transparent;
        LottieRightFrame.Stroke = Colors.Transparent;

        if (_selectedLottie == LottieViewLeft)
            LottieLeftFrame.Stroke = Colors.Cyan;
        else if (_selectedLottie == LottieViewMiddle)
            LottieMiddleFrame.Stroke = Colors.Cyan;
        else if (_selectedLottie == LottieViewRight)
            LottieRightFrame.Stroke = Colors.Cyan;
    }

    private void OnPlayLottieClicked(object sender, EventArgs e)
    {
        PlaySelectedLottie();
    }

    private void OnPauseLottieClicked(object sender, EventArgs e)
    {
        PauseSelectedLottie();
    }

    private void OnStopLottieClicked(object sender, EventArgs e)
    {
        StopSelectedLottie();
    }

    public void PlaySelectedLottie()
    {
        if (_selectedLottie == null)
        {
            DisplayAlert("No Selection", "Please select a Lottie first by clicking on it", "OK");
            return;
        }
        _selectedLottie?.EvaluateJavaScriptAsync("window.play()");
    }

    public void PauseSelectedLottie()
    {
        if (_selectedLottie == null)
        {
            DisplayAlert("No Selection", "Please select a Lottie first by clicking on it", "OK");
            return;
        }
        _selectedLottie?.EvaluateJavaScriptAsync("window.pause()");
    }

    public void StopSelectedLottie()
    {
        if (_selectedLottie == null)
        {
            DisplayAlert("No Selection", "Please select a Lottie first by clicking on it", "OK");
            return;
        }
        _selectedLottie?.EvaluateJavaScriptAsync("window.stop()");
    }

    void OnAnimationFocused(object sender, FocusEventArgs e)
    {
        _selectedAnimation = (WebView)sender;
        UpdateAnimationFrameBorders();
    }

    void OnAnimationUnfocused(object sender, FocusEventArgs e)
    {
        UpdateAnimationFrameBorders();
    }

    void UpdateAnimationFrameBorders()
    {
        AnimationLeftFrame.Stroke = Colors.Transparent;
        AnimationRightFrame.Stroke = Colors.Transparent;

        if (_selectedAnimation == AnimationViewLeft)
            AnimationLeftFrame.Stroke = Colors.Cyan;
        else if (_selectedAnimation == AnimationViewRight)
            AnimationRightFrame.Stroke = Colors.Cyan;
    }

    private void OnPlayAnimationClicked(object sender, EventArgs e)
    {
        PlaySelectedAnimation();
    }

    private void OnPauseAnimationClicked(object sender, EventArgs e)
    {
        PauseSelectedAnimation();
    }

    private void OnStopAnimationClicked(object sender, EventArgs e)
    {
        StopSelectedAnimation();
    }

    public void PlaySelectedAnimation()
    {
        if (_selectedAnimation == null)
        {
            DisplayAlert("No Selection", "Please select an animation first by clicking on it", "OK");
            return;
        }
        _selectedAnimation?.EvaluateJavaScriptAsync("window.play()");
    }

    public void PauseSelectedAnimation()
    {
        if (_selectedAnimation == null)
        {
            DisplayAlert("No Selection", "Please select an animation first by clicking on it", "OK");
            return;
        }
        _selectedAnimation?.EvaluateJavaScriptAsync("window.pause()");
    }

    public void StopSelectedAnimation()
    {
        if (_selectedAnimation == null)
        {
            DisplayAlert("No Selection", "Please select an animation first by clicking on it", "OK");
            return;
        }
        _selectedAnimation?.EvaluateJavaScriptAsync("window.stop()");
    }
}
