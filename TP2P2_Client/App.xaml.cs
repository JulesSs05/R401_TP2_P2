// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TP2P2_Client.Service;
using TP2P2_Client.ViewModels;
using TP2P2_Client.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TP2P2_Client
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static FrameworkElement MainRoot { get; private set; }

        public AjoutSerieVM AjoutSerie
        {
            get { return Ioc.Default.GetService<AjoutSerieVM>(); }
        }

        public RUD RUD
        {
            get { return Ioc.Default.GetService<RUD>(); }
        }
        public IService ObjWSService
        {
            get { return new WSService("https://apiseriesjulsil.azurewebsites.net"); }
        } 

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<AjoutSerieVM>()
                .AddSingleton<RUD>()
                .AddSingleton<IService, WSService>()
                .BuildServiceProvider());
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            Frame rootFrame = new Frame();

            this.m_window.Content = rootFrame;

            MainRoot = m_window.Content as FrameworkElement;


            m_window.Activate();

            rootFrame.Navigate(typeof(RUDPage));
        }

        private Window m_window;
    }
}
