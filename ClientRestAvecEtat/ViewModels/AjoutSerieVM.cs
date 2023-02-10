using ClientRestAvecEtat.Models;
using ClientRestAvecEtat.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TP2P2_Client.ViewModels
{
    public class AjoutSerieVM : SerieVM
    {
        public AjoutSerieVM() 
        {
            SerieToAdd = new Serie();
        }

        private Serie serieToAdd;

        public Serie SerieToAdd
        {
            get { return serieToAdd; }
            set { 
                serieToAdd = value;
                OnPropertyChanged();
            }
        }

        internal override async void BtnActionSerie()
        {
            WSService service = new WSService("https://apiseriesjulsil.azurewebsites.net");

            if (string.IsNullOrEmpty(SerieToAdd.Titre))
            {
                await ShowAsync("Erreur", "Le titre doit être renseigné !", true);
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Resume))
            {
                await ShowAsync("Erreur", "Le resumé doit être renseigné !", true);
                return; 
            } else if (SerieToAdd.Anneecreation== 0)
            {
                await ShowAsync("Erreur", "L'année doit être renseignée !", true);
                return;
            } else if (SerieToAdd.Nbepisodes== 0)
            {
                await ShowAsync("Erreur", "Le nombre d'épisodes doit être renseigné !", true);
                return;
            } else if (serieToAdd.Nbsaisons== 0)
            {
                await ShowAsync("Erreur", "Le nombre de saisons doit être renseigné !", true);
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Network))
            {
                await ShowAsync("Erreur", "La chaine doit être renseignée !", true);
                return;
            }

            var request = await service.PostSerieAsync(SerieToAdd);

            if(request.IsSuccessStatusCode)
            {
                await ShowAsync("Succès !", $"La série \"{SerieToAdd.Titre}\" a bien été ajoutée", true);
                SerieToAdd = new Serie();
            } else
            {
                await ShowAsync("Erreur !", "Votre requête n'a pu aboutir", true);
            }
        }
    }
}
