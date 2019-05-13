using System.Collections.Generic;
using ASPCoreGroupB.Models;

namespace ASPCoreGroupB.DAL {
    public interface IDosen
    {
        IEnumerable<Dosen> GetAll();
        Dosen GetById(string nik);
        IEnumerable<Dosen> GetAllByNik(string nik);
        IEnumerable<Dosen> GetAllByNama(string nik);
        void Insert(Dosen dsn);
        void Update(Dosen dsn);
        void Delete(string nik);
    }

}