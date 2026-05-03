using Domain;

namespace Interfaces
    
{
    public interface IZawodnikRepository
    {

        Task<IEnumerable<Zawodnik>> GetAll();
        Task<Zawodnik> GetById(int id);
        void Add(Zawodnik zawodnik);
        void Update(Zawodnik zawodnik);
        void Delete(int id);
    }
}
