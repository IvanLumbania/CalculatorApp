namespace CalculatorApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Calculator),typeof(Calculator));
        }
    }
}
