using FactorFinder.Model;
using FactorFinder.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace FactorFinder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDerivePrimes, DirectSearch>();
            container.RegisterType<IPrimeModel, PrimeFactorsModel>();
            PrimeFactorsViewModel viewModel = container.Resolve<PrimeFactorsViewModel>();
            FactorFinder.MainWindow view = new FactorFinder.MainWindow();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
