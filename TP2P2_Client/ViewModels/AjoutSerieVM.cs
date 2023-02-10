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
using TP2P2_Client.Models;
using TP2P2_Client.Service;

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
            //WSService service = new WSService("https://apiseriesjulsil.azurewebsites.net");

            if (string.IsNullOrEmpty(SerieToAdd.Titre))
            {
                ShowAsync("Erreur", "Le titre doit être renseigné !", true);
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Resume))
            {
                ShowAsync("Erreur", "Le resumé doit être renseigné !", true);
                return; 
            } else if (SerieToAdd.Anneecreation== 0)
            {
                ShowAsync("Erreur", "L'année doit être renseignée !", true);
                return;
            } else if (SerieToAdd.Nbepisodes== 0)
            {
                ShowAsync("Erreur", "Le nombre d'épisodes doit être renseigné !", true);
                return;
            } else if (serieToAdd.Nbsaisons== 0)
            {
                ShowAsync("Erreur", "Le nombre de saisons doit être renseigné !", true);
                return;
            } else if (string.IsNullOrEmpty(SerieToAdd.Network))
            {
                ShowAsync("Erreur", "La chaine doit être renseignée !", true);
                return;
            }

            var request = await ObjWSService.PostSerieAsync(SerieToAdd);

            if(request.IsSuccessStatusCode)
            {
                ShowAsync("Succès !", $"La série \"{SerieToAdd.Titre}\" a bien été ajoutée", true);
                SerieToAdd = new Serie();
            } else
            {
                ShowAsync("Erreur !", "Votre requête n'a pu aboutir", true);
            }
        }
    }
}
