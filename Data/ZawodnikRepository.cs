using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ZawodnikRepository : IZawodnikRepository
    {

        private DbPZPN db=new DbPZPN();

        public async void Add(Zawodnik zawodnik)
        {
            if (zawodnik != null)
            {
                db.Zawodnicy.Add(zawodnik);
                await db.SaveChangesAsync();
            }
        }

        public async void Delete(int id)
        {
           
            var studObj =await db.Zawodnicy.FindAsync(id);
            if (studObj != null)
            {
                db.Zawodnicy.Remove(studObj);
               await db.SaveChangesAsync();
            }
        
        }
        
        public async Task<IEnumerable<Zawodnik>> GetAll()
        {
            return await db.Zawodnicy.FromSqlRaw("EXEC [dbo].[PobierzWolno]").ToListAsync();
        }

        public async Task<Zawodnik> GetById(int id)
        {
            return await db.Zawodnicy.FindAsync(id);
        }

        public async void Update(Zawodnik zawodnik)
        {
            var zawodnikFind =await this.GetById(zawodnik.ZawodnikId);
            if (zawodnikFind != null)
            {
                zawodnikFind.imie = zawodnik.imie;
                zawodnikFind.kondycja = zawodnik.kondycja;
                zawodnikFind.czyKontuzja = zawodnik.czyKontuzja;
                zawodnikFind.nrKoszulki = zawodnik.nrKoszulki;
                await db.SaveChangesAsync();
            }
        }
    }
}
