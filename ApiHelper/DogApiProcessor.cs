using ApiHelper.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace ApiHelper
{
    public class DogApiProcessor
    {

        public static async Task<List<string>> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant
            /// //https://dog.ceo/api/breeds/list/all pour la liste de toutes les races de l'Api
            /// message aura les breeds
            /// //https://dog.ceo/api/breed/ [message]/ images / random      Format de requete à utiliser
            /// 
            string url = $"https://dog.ceo/api/breeds/list/all";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    DogBreedsModel result = await response.Content.ReadAsAsync<DogBreedsModel>();

                    var breeds = result.DogBreeds.Keys.ToList();
                    return breeds;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
            
        }
    }

