using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Models;

namespace TP2P2_Client.ViewModels
{
    public class RUD : SerieVM
    {
        private Serie qSerie;

        public Serie QSerie
        {
            get { return qSerie; }
            set { 
                qSerie = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand DelBtn { get; }
        public RelayCommand EditBtn { get; }

        internal override async void BtnActionSerie()
        {
            var request = await ObjWSService.GetSerieAsync(Query);

            if (request == null)
            {
                ShowAsync("Erreur", "Ressource introuvable", true);
            } else
            {
                ShowAsync("Chargement", "Les données sont en train d'être chargées", true);
                QSerie = request;
            }
        }

        private int query;

        public RUD()
        {
            QSerie = new Serie();
            DelBtn = new RelayCommand(DelAction);
            EditBtn = new RelayCommand(EditAction);
        }

        public int Query
        {
            get { return query; }
            set { query = value; }
        }

        private async void DelAction()
        {
            ContentDialogResult result = await ConfirmDialog("supprimer");

            if (result == ContentDialogResult.Primary)
            {
                var request = await ObjWSService.DeleteSerieAsync(QSerie.Serieid);

                if(request.IsSuccessStatusCode)
                {
                    ShowAsync("Succès", $"La série n°{QSerie.Serieid} ({QSerie.Titre}) a bien été supprimée", true);
                    QSerie = new Serie();
                } else
                {
                    ShowAsync("Erreur", $"La série n°{QSerie.Serieid} ({QSerie.Titre}) n'a pas été supprimée", true);
                }
            }
        }

        private async void EditAction()
        {
            ContentDialogResult result = await ConfirmDialog("mettre à jour");

            if (result == ContentDialogResult.Primary)
            {
                var request = await ObjWSService.PutSerieAsync(QSerie, QSerie.Serieid);

                if (request.IsSuccessStatusCode)
                {
                    ShowAsync("Succès", $"La série n°{QSerie.Serieid} ({QSerie.Titre}) a bien été mise à jour", true);
                } else
                {
                    ShowAsync("Erreur", $"La série n°{QSerie.Serieid} ({QSerie.Titre}) n'a pas été mise à jour", true);
                }
            }
        }
    }
}
