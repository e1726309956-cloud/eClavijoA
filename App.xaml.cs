using eClavijoA.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eClavijoA
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository _personRepo { get; private set; }
        public App(PersonRepository repo)
        {
            InitializeComponent();
            _personRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}