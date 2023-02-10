using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Service;

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

        internal async void ShowAsync(String title, String message, bool closeBtn)
        {
            ContentDialog msgDialog = new ContentDialog();
            if (closeBtn == true)
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
        }

        internal async Task<ContentDialogResult> ConfirmDialog(string action)
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = $"Voulez-vous vraiment {action} ?",
                PrimaryButtonText = "Oui",
                CloseButtonText = "Annuler"
            };

            confirmDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await confirmDialog.ShowAsync();

            return result;
        }

        internal abstract void BtnActionSerie();
    }
}
