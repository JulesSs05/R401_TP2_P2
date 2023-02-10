using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TP2P2_Client.Models;

namespace TP2P2_Client.Service
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync();
        Task<HttpResponseMessage> PutSerieAsync(Serie serie, int id);
        Task<HttpResponseMessage> PostSerieAsync(Serie serie);
        Task<HttpResponseMessage> DeleteSerieAsync(int id);
        Task<Serie> GetSerieAsync(int id);

    }
}
