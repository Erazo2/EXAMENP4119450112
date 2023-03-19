using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;



namespace EXAMENP4119450112.Controllers
{
    public class LocalizacionController
    {
        readonly SQLiteAsyncConnection _Connection;
        public LocalizacionController(string DBPath)
        {
            _Connection = new SQLiteAsyncConnection(DBPath);
            _Connection.CreateTableAsync<Models.Localizacion>();

        }
        public Task<int> SaveGeo(Models.Localizacion posicion)
        {
            if (posicion.id != 0)
                return _Connection.UpdateAsync(posicion);
            else
                return _Connection.InsertAsync(posicion);
        }

        // READ one
        public Task<Models.Localizacion> GetLocalizaciones(int pid)
        {
            return _Connection.Table<Models.Localizacion>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }


        public Task<List<Models.Localizacion>> GetlistLocalizaciones()
        {
            return _Connection.Table<Models.Localizacion>().ToListAsync();
        }

        public Task<int> DeleteLocalizaciones(Models.Localizacion posicion)
        {
            //delete
            return _Connection.DeleteAsync(posicion);
        }

    }
}
