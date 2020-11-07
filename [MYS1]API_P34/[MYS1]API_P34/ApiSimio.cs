using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//IMPORTS
using SimioAPI;
using Simio.SimioEnums;
using SimioAPI.Extensions;
using SimioAPI.Graphics;
using Simio;
using System.Windows.Forms;

namespace _MYS1_API_P34
{
    class ApiSimio
    {
        private ISimioProject proyectoApi;
        private string rutabase = "[MYS1]ModeloBase_P34.spfx";
        private string rutafinal = "[MYS1]Tienda2_P34.spfx";
        private string[] warnings;
        private IModel model;
        private IIntelligentObjects intelligentObjects;

        public ApiSimio()
        {
            proyectoApi = SimioProjectFactory.LoadProject(rutabase, out warnings);
            model = proyectoApi.Models[1];
            intelligentObjects = model.Facility.IntelligentObjects;
        }

        public void crearModelo()
        {
            this.principal();
            //CREACION MODELO
            SimioProjectFactory.SaveProject(proyectoApi, rutafinal, out warnings);
            MessageBox.Show("El proyecto Simio ha sido generado");
            Console.WriteLine("Modelo Creado");

        }

        public void principal()
        {
            intelligentObjects.CreateObject("Server", new FacilityLocation(0, 0, 0));  //Metropolitana
            intelligentObjects.CreateObject("Server", new FacilityLocation(5, 0, -20));  //Norte
            model.Facility.IntelligentObjects["Server1"].ObjectName = "Metropolitana";
            model.Facility.IntelligentObjects["Server2"].ObjectName = "Norte";
        }
    }
}
