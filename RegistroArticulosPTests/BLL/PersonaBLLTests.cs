using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroArticulosP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroArticulosP.Entidades;
using RegistroArticulosP.DALL;


namespace RegistroArticulosP.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Persona persona = new Persona();
            bool paso = false;
            persona.PersonaId = 5;
            persona.Nombre = "Cenia";
            persona.Fecha = DateTime.Now;
            persona.Cedula = "0490000000";
            persona.Direccion = "SPM";
            persona.Telefono = "8490000000";
            paso = PersonaBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
            
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Persona persona = new Persona();
            bool paso = false;
            persona.PersonaId = 5;
            persona.Nombre = "Pedro";
            persona.Fecha = DateTime.Now;
            persona.Cedula = "0490000000";
            persona.Direccion = "PUJ";
            persona.Telefono = "8490000000";
            paso = PersonaBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            int id = 5;
            paso = BLL.PersonaBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Persona persona = new Persona();
            int id = 3;
            persona= BLL.PersonaBLL.Buscar(id);
            Assert.IsNotNull(persona);
        }

        [TestMethod()]
        public void GetListTest()
        {
            
            var list = PersonaBLL.GetList(m => true);
            Assert.IsNotNull(list);
        }
    }
}