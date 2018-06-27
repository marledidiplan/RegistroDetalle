using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroArticulosP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using RegistroArticulosP.DALL;
using RegistroArticulosP.Entidades;

namespace RegistroArticulosP.BLL.Tests
{
    [TestClass()]
    public class ArticulosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            ArticulosProductos articulosProductos = new ArticulosProductos();
            bool paso = false;
            articulosProductos.IdArticulos = 5;
            articulosProductos.Descripcion = "Pollo";
            articulosProductos.FechaVencimiento = DateTime.Now;
            articulosProductos.Precio = 50;
            articulosProductos.CantidadCotizada = 20;
            articulosProductos.Existencia = 5;
            paso = ArticulosBLL.Guardar(articulosProductos);
            
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            ArticulosProductos articulosProductos = new ArticulosProductos();
            bool paso = false;
            articulosProductos.IdArticulos = 5;
            articulosProductos.Descripcion = "Kiwi";
            articulosProductos.FechaVencimiento = DateTime.Now;
            articulosProductos.Precio = 50;
            articulosProductos.CantidadCotizada = 100;
            articulosProductos.Existencia = 500;
            paso = ArticulosBLL.Modificar(articulosProductos);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        public void GetListTest()
        {

        }
    }
}