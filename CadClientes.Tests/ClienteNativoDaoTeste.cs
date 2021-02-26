using System;
using CadClientes.Dao;
using CadClientes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CadClientes.Tests
{
    [TestClass]
    public class ClienteNativoDaoTeste
    {
        [TestMethod]
        public void InserirCliente_QuandoInserirCliente_DeveRetornarVerdadeiro()
        {
            #region Arrange
            var cliente = new Cliente();
            cliente.Nome = "José Silva";
            cliente.Cpf = "06475714046";
            cliente.DtNascimento = DateTime.Now.AddYears(-20);
            cliente.Sexo = "M";

            var resultadoEsperado = true;
            #endregion

            #region Act
            var resultadoEncontrado = ClienteNativoDao.InserirCliente(cliente);
            #endregion

            #region Assert
            Assert.AreEqual(resultadoEsperado, resultadoEncontrado);
            #endregion
        }

        [TestMethod]
        public void AtualizarCliente_QuandoAtualizarCliente_DeveAlterarNome()
        {
            #region Arrange
            var cliente = new Cliente();
            cliente.Nome = "José Silva";
            cliente.Cpf = "06475714046";
            cliente.DtNascimento = DateTime.Now.AddYears(-20);
            cliente.Sexo = "M";

            ClienteNativoDao.InserirCliente(cliente);

            var listaClientes = ClienteNativoDao.ObterClientes();
            cliente.ClienteId = listaClientes[listaClientes.Count - 1].ClienteId;
            cliente.Nome = "José Pedro Silva";

            var resultadoEsperado = "José Pedro Silva";
            
            #endregion

            #region Act
            ClienteNativoDao.AlterarCliente(cliente);
            #endregion

            #region Assert
            var resultadoEncontrado = ClienteNativoDao.ObterClientesPorId(cliente.ClienteId).Nome;
            Assert.AreEqual(resultadoEsperado, resultadoEncontrado);
            #endregion
        }

        [TestMethod]
        public void ExluirCliente_QuandoExcluirCliente_NaoRetornarNaPesquisa()
        {
            #region Arrange
            var listaClientes = ClienteNativoDao.ObterClientes();
            var clienteId = listaClientes[listaClientes.Count - 1].ClienteId;

            Cliente resultadoEsperado = null;
            #endregion

            #region Act
            ClienteNativoDao.ExcluirCliente(clienteId);
            #endregion

            #region Assert
            var resultadoEncontrado = ClienteNativoDao.ObterClientesPorId(clienteId);
            Assert.AreEqual(resultadoEsperado, resultadoEncontrado);
            #endregion
        }
    }
}
