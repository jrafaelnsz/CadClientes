using CadClientes.Dto;
using CadClientes.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace CadClientes.Dao
{
    public class ClienteNativoDao
    {
        public static List<ClienteDto> ObterClientes()
        {
            using (DBModel db = new DBModel())
            {

                var result = db.Cliente.SqlQuery("Select * From Cliente").ToList<Cliente>(); ;
                return ClienteDto.ConverterLista(result);
            }
        }

        public static Cliente ObterClientesPorId(int id)
        {
            using (DBModel db = new DBModel())
            {
                var query = "Select * From Cliente Where ClienteId = @id";
                var result = db.Cliente.SqlQuery(query, new SqlParameter("@id", id)).FirstOrDefault<Cliente>();
                return db.Cliente.Where(c => c.ClienteId == id).FirstOrDefault<Cliente>();
            }
        }

        public static bool InserirCliente(Cliente cliente)
        {
            using (DBModel db = new DBModel())
            {

                var query = @"Insert Into Cliente (Nome, Cpf, DtNascimento, Sexo) Values(@Nome, @Cpf, @DtNascimento, @Sexo)";
                int nInseridas = db.Database.ExecuteSqlCommand(query,
                                                                    new SqlParameter("@Nome", cliente.Nome),
                                                                    new SqlParameter("@Cpf", cliente.Cpf),
                                                                    new SqlParameter("@DtNascimento", cliente.DtNascimento),
                                                                    new SqlParameter("@Sexo", cliente.Sexo));
                return (nInseridas > 0);
            }
        }

        public static bool AlterarCliente(Cliente cliente)
        {
            using (DBModel db = new DBModel())
            {
                var query = @"Update Cliente Set Nome = @Nome, Cpf = @Cpf, DtNascimento = @DtNascimento, Sexo = @Sexo Where ClienteId = @Id";
                int nAtualizadas = db.Database.ExecuteSqlCommand(query,
                                                                    new SqlParameter("@Nome", cliente.Nome),
                                                                    new SqlParameter("@Cpf", cliente.Cpf),
                                                                    new SqlParameter("@DtNascimento", cliente.DtNascimento),
                                                                    new SqlParameter("@Sexo", cliente.Sexo),
                                                                    new SqlParameter("@Id", cliente.ClienteId));
                return (nAtualizadas > 0);
            }
        }

        public static bool ExcluirCliente(int id)
        {
            using (DBModel db = new DBModel())
            {
                var query = @"Delete From Cliente Where ClienteId = @Id";
                int nRemovidas = db.Database.ExecuteSqlCommand(query, new SqlParameter("@Id", id));
                return (nRemovidas > 0);
            }
        }
    }
}
