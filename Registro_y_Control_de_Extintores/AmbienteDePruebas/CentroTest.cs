using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Registro_y_control_de_extintores;
using Registro_y_control_de_extintores.Controllers;

namespace AmbienteDePruebas
{

    [TestClass]
    public class CentroTest
    {
        [TestMethod]
        public void test()
        {
            // Arrange
            CentroController controller = new CentroController();
            // Act
            ViewResult result = controller.Administrar() as ViewResult;
            // Assert
            
            Assert.IsNotNull(result);

        }
        
    }
}
