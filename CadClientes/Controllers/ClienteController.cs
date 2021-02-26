using System.Web.Mvc;
using CadClientes.Dao;
using CadClientes.Models;

namespace CadClientes.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarClientes()
        {
            return Json(new { data = ClienteNativoDao.ObterClientes() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult IncluirOuEditar(int id = 0)
        {
            return (id == 0) ? View(new Cliente()) : View(ClienteNativoDao.ObterClientesPorId(id));
        }

        [HttpPost]
        public ActionResult IncluirOuEditar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    ClienteNativoDao.InserirCliente(cliente);
                    return Json(new { succsess = true, message = "Registro inserido com sucesso" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ClienteNativoDao.AlterarCliente(cliente);
                    return Json(new { succsess = true, message = "Registro atualizado com sucesso" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.Exception ex)
            {
                return Json(new { succsess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            try
            {
                ClienteNativoDao.ExcluirCliente(Id);
                return Json(new { succsess = true, message = "Registro removido com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { succsess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}