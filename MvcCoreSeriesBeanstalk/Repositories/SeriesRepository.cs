using Microsoft.EntityFrameworkCore;
using MvcCoreSeriesBeanstalk.Data;
using MvcCoreSeriesBeanstalk.Models;

namespace MvcCoreSeriesBeanstalk.Repositories
{
    public class SeriesRepository
    {
        private SeriesContext context;
        public SeriesRepository(SeriesContext context)
        {
            this.context = context;
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        private async Task<int> GetMaxIdSerieAsync()
        {
            return await this.context.Series
                .MaxAsync(x => x.IdSerie) + 1;
        }

        public async Task InsertSerie(string nombre,string imagen,int year)
        {
            Serie serie = new Serie()
            {
                IdSerie = await this.GetMaxIdSerieAsync(),
                Imagen = imagen,
                Nombre = nombre,
                Year = year
            };
            await this.context.Series.AddAsync(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
