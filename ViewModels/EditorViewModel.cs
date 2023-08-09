using SomeQuest.Commands;
using SomeQuest.Stores;
using System.Windows.Input;

namespace SomeQuest.ViewModels {
    public class EditorViewModel : ViewModelBase {
        public ICommand NavigateProjectsCommand { get; }
        public EditorViewModel(NavigationStore navigationStore) {
            NavigateProjectsCommand = new NavigateCommand<ProjectsViewModel>(navigationStore, () => new ProjectsViewModel(navigationStore));
        }
    }
}
