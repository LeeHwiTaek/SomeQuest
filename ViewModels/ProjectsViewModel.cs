using CommunityToolkit.Mvvm.Input;
using SomeQuest.Commands;
using SomeQuest.Models;
using SomeQuest.Stores;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace SomeQuest.ViewModels {
    public class ProjectsViewModel : ViewModelBase {

        private Project selectedProject = new();
        public Project SelectedProject {
            get => selectedProject;
            set {
                selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public ICommand RunProjectCommand { get; }
        private void RunProject() {
            File.Copy(SelectedProject.Name + "\\script.rpy", "engine\\game\\script.rpy", true);
            File.Copy(SelectedProject.Name + "\\options.rpy", "engine\\game\\options.rpy", true);
            System.Diagnostics.Process.Start("engine\\SomeQuest.exe");
        }

        public ICommand NavigateEditorCommand { get; }

        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
        public ProjectsViewModel(NavigationStore navigationStore) {
            var directories = Directory.GetDirectories("projects");
            for(int i = 0; i < directories.Length; i++) {
                Projects.Add(new Project() {
                    Id = i + 1, Name = directories[i]
                });
            }

            RunProjectCommand = new RelayCommand(RunProject);

            NavigateEditorCommand = new NavigateCommand<EditorViewModel>(navigationStore, () => new EditorViewModel(navigationStore));
        }
    }
}
