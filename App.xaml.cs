namespace cguambaS2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establecer el tema de la aplicación a claro
            //Application.Current.UserAppTheme = AppTheme.Light;

            //MainPage = new vistas.vPrincipal();
            MainPage = new NavigationPage(new vistas.Login());
        }
    }
}
