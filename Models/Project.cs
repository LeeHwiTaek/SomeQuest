using SomeQuest.ViewModels;

namespace SomeQuest.Models {
    public class Project : ViewModelBase {
        private int _id;
        private string _name;

        public int Id {
            get => _id;
            set {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Project() {
            _name = "";
        }
    }
}
