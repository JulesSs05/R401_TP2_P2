using ClientRestAvecEtat;
using ClientRestAvecEtat.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2P2_Client.ViewModels
{
    public abstract class SerieVM : ObservableObject
    {
        protected SerieVM()
        {
            BtnSetSerie = new RelayCommand(BtnActionSerie);
        }

        public RelayCommand BtnSetSerie { get; }

        public ServiceProvider Services { get; }

        public IService ObjWSService
        {
            get { return ((App)Application.Current).ObjWSService; }
        }

        public async Task<ContentDialog> ShowAsync(String title, String message, bool? closeBtn)
        {
            ContentDialog msgDialog = new ContentDialog();
            if (closeBtn == null)
            {
                msgDialog = new ContentDialog()
                {
                    Title = title,
                    Content = message,
                    CloseButtonText = "Ok"
                };
            } else if (closeBtn == false)
            {
                msgDialog = new ContentDialog()
                {
                    Title = title,
                    Content = message,
                };
            }



            msgDialog.XamlRoot = App.MainRoot.XamlRoot;
            await msgDialog.ShowAsync();
            return msgDialog;
        }

        internal abstract void BtnActionSerie();
    }
}
