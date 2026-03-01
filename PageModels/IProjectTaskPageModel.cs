using CommunityToolkit.Mvvm.Input;
using WebTest.Models;

namespace WebTest.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}