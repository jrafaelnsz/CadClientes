using CadClientes.Dto;
using CadClientes.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CadClientes.Dao
{
    public class ClienteDao
    {
        public static List<ClienteDto> ObterClientes()
        {
            using (DBModel db = new DBModel())
            {
                return ClienteDto.ConverterLista(db.Cliente.ToList<Cliente>());
            }
        }

        public static Cliente ObterClientesPorId(int id)
        {
            using (DBModel db = new DBModel())
            {
                return db.Cliente.Where(c => c.ClienteId == id).FirstOrDefault<Cliente>();
            }
        }

        public static bool InserirCliente(Cliente cliente)
        {
            using (DBModel db = new DBModel())
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return true;
            }
        }

        public static bool AlterarCliente(Cliente cliente)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public static bool ExcluirCliente(int id)
        {
            using (DBModel db = new DBModel())
            {
                var cliente = db.Cliente.Where(c => c.ClienteId == id).FirstOrDefault<Cliente>();
                db.Cliente.Remove(cliente);
                db.SaveChanges();
                return true;
            }
        }
    }      
}