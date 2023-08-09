using SomeQuest.Stores;
using SomeQuest.ViewModels;
using System.Windows;

namespace SomeQuest {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            NavigationStore navigationStore = new();
            navigationStore.CurrentViewModel = new ProjectsViewModel(navigationStore);
            DataContext = new MainViewModel(navigationStore);
        }
    }
}
