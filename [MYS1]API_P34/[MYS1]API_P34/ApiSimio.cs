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
            //this.principal();
            this.crearEntradaSalida();
            this.Mesas();
            this.Barras();
            this.Atencion();
            this.nodos();
            this.tiemposAtencion();
            this.rutas();
            //CREACION MODELO
            SimioProjectFactory.SaveProject(proyectoApi, rutafinal, out warnings);
            MessageBox.Show("El proyecto Simio ha sido generado");
            Console.WriteLine("Modelo Creado");

        }


        public void crearEntradaSalida()
        {
            intelligentObjects.CreateObject("Source", new FacilityLocation(-5.75, 0, -1));
            intelligentObjects.CreateObject("Sink", new FacilityLocation(47.5, 0, -1));

            model.Facility.IntelligentObjects["Source1"].ObjectName = "Entrada";
            model.Facility.IntelligentObjects["Sink1"].ObjectName = "Salida";
        }

        public void Mesas()
        {
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 16));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 20));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 24));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 28));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 32));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 36));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 40));
            intelligentObjects.CreateObject("Server", new FacilityLocation(9, 0, 44));
            intelligentObjects.CreateObject("Server", new FacilityLocation(38, 0, 16));
            intelligentObjects.CreateObject("Server", new FacilityLocation(38, 0, 20));

            model.Facility.IntelligentObjects["Server1"].ObjectName = "Mesa1";
            model.Facility.IntelligentObjects["Server2"].ObjectName = "Mesa2";
            model.Facility.IntelligentObjects["Server3"].ObjectName = "Mesa3";
            model.Facility.IntelligentObjects["Server4"].ObjectName = "Mesa4";
            model.Facility.IntelligentObjects["Server5"].ObjectName = "Mesa5";
            model.Facility.IntelligentObjects["Server6"].ObjectName = "Mesa6";
            model.Facility.IntelligentObjects["Server7"].ObjectName = "Mesa7";
            model.Facility.IntelligentObjects["Server8"].ObjectName = "Mesa8";
            model.Facility.IntelligentObjects["Server9"].ObjectName = "Mesa9";
            model.Facility.IntelligentObjects["Server10"].ObjectName = "Mesa10";

        }

        public void Barras()
        {
            intelligentObjects.CreateObject("Server", new FacilityLocation(8.5, 0, -12));
            intelligentObjects.CreateObject("Server", new FacilityLocation(37, 0, -5.5));
            intelligentObjects.CreateObject("Server", new FacilityLocation(34.5, 0, -12));

            model.Facility.IntelligentObjects["Server1"].ObjectName = "LateralI";
            model.Facility.IntelligentObjects["Server2"].ObjectName = "BarraEnfrente";
            model.Facility.IntelligentObjects["Server3"].ObjectName = "LateralD";

        }

        public void Atencion()
        {
            intelligentObjects.CreateObject("Server", new FacilityLocation(1.75, 0, -1));
            intelligentObjects.CreateObject("Server", new FacilityLocation(8.5, 0, -5));
            intelligentObjects.CreateObject("Server", new FacilityLocation(15.5, 0, -1));

            model.Facility.IntelligentObjects["Server1"].ObjectName = "Caja";
            model.Facility.IntelligentObjects["Server2"].ObjectName = "Almacen";
            model.Facility.IntelligentObjects["Server3"].ObjectName = "Entrega";

        }

        public void nodos()
        {
            //Basic 7
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(19, 0, 28));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(47, 0, 28));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(47, 0, 18));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(46.25, 0, -12));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(46.25, 0, -17));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(10, 0, -17));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(7, 0, -8.5));
            intelligentObjects.CreateObject("BasicNode", new FacilityLocation(16, 0, -12));

            //Transfer 5
            intelligentObjects.CreateObject("TransferNode", new FacilityLocation(22.5, 0, -1));
            intelligentObjects.CreateObject("TransferNode", new FacilityLocation(22.5, 0, -12));
            intelligentObjects.CreateObject("TransferNode", new FacilityLocation(28, 0, -5.5));
            intelligentObjects.CreateObject("TransferNode", new FacilityLocation(31.5, 0, 9.5));
            intelligentObjects.CreateObject("TransferNode", new FacilityLocation(0.5, 0, 9.5));

            model.Facility.IntelligentObjects["TransferNode1"].ObjectName = "Tn";
            model.Facility.IntelligentObjects["TransferNode2"].ObjectName = "BarrasLaterales";
            model.Facility.IntelligentObjects["TransferNode3"].ObjectName = "BarraFront";
            model.Facility.IntelligentObjects["TransferNode4"].ObjectName = "Mesas910";
            model.Facility.IntelligentObjects["TransferNode5"].ObjectName = "Mesas18";

        }

        public void tiemposAtencion()
        {
            #region Mesas
            model.Facility.IntelligentObjects["Mesa1"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa1"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa2"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa2"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa3"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa3"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa4"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa4"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa5"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa5"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa6"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa6"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa7"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa7"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa8"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa8"].Properties["InitialCapacity"].Value = "3";

            model.Facility.IntelligentObjects["Mesa9"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa9"].Properties["InitialCapacity"].Value = "5";

            model.Facility.IntelligentObjects["Mesa10"].Properties["ProcessingTime"].Value = "Random.Triangular(8,16,24)";
            model.Facility.IntelligentObjects["Mesa10"].Properties["InitialCapacity"].Value = "5";
            #endregion

            #region barras
            model.Facility.IntelligentObjects["LateralI"].Properties["ProcessingTime"].Value = "Random.Triangular(3,5,8)";
            model.Facility.IntelligentObjects["LateralI"].Properties["InitialCapacity"].Value = "8";

            model.Facility.IntelligentObjects["BarraEnfrente"].Properties["ProcessingTime"].Value = "Random.Triangular(3,5,8)";
            model.Facility.IntelligentObjects["BarraEnfrente"].Properties["InitialCapacity"].Value = "4";

            model.Facility.IntelligentObjects["LateralD"].Properties["ProcessingTime"].Value = "Random.Triangular(3,5,8)";
            model.Facility.IntelligentObjects["LateralD"].Properties["InitialCapacity"].Value = "8";
            #endregion

            #region atencion
            model.Facility.IntelligentObjects["Caja"].Properties["ProcessingTime"].Value = "Random.Uniform(0.58333,2.5)"; //Pasar a segundo 35 105

            model.Facility.IntelligentObjects["Almacen"].Properties["ProcessingTime"].Value = "Random.Uniform(0.0166667,0.02083333)"; //Pasar a segundo 1 1.25

            model.Facility.IntelligentObjects["Entrega"].Properties["ProcessingTime"].Value = "0";

            model.Facility.IntelligentObjects["Entrada"].Properties["InterarrivalTime"].Value = "Random.Uniform(1.2,1.8)";
            #endregion
        }

        public void rutas()
        {
            //Entrada-Caja-Almacen-Entrega
            intelligentObjects.CreateLink("Conveyor", ((IFixedObject)model.Facility.IntelligentObjects["Entrada"]).Nodes[0], ((IFixedObject)model.Facility.IntelligentObjects["Caja"]).Nodes[0], null);
            intelligentObjects.CreateLink("Conveyor", ((IFixedObject)model.Facility.IntelligentObjects["Caja"]).Nodes[1], ((IFixedObject)model.Facility.IntelligentObjects["Almacen"]).Nodes[0], null);
            intelligentObjects.CreateLink("Conveyor", ((IFixedObject)model.Facility.IntelligentObjects["Almacen"]).Nodes[1], ((IFixedObject)model.Facility.IntelligentObjects["Entrega"]).Nodes[0], null);
            intelligentObjects.CreateLink("Conveyor", ((IFixedObject)model.Facility.IntelligentObjects["Entrega"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["Tn"]), null);

            intelligentObjects.CreateLink("TimePath", ((INodeObject)model.Facility.IntelligentObjects["Tn"]), ((IFixedObject)model.Facility.IntelligentObjects["Salida"]).Nodes[0], null);
            intelligentObjects.CreateLink("TimePath", ((INodeObject)model.Facility.IntelligentObjects["Tn"]), ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), null);
            intelligentObjects.CreateLink("TimePath", ((INodeObject)model.Facility.IntelligentObjects["Tn"]), ((INodeObject)model.Facility.IntelligentObjects["Mesas910"]), null);


            intelligentObjects.CreateLink("Conveyor", ((INodeObject)model.Facility.IntelligentObjects["Tn"]), ((INodeObject)model.Facility.IntelligentObjects["BarrasLaterales"]), null);
            intelligentObjects.CreateLink("Conveyor", ((INodeObject)model.Facility.IntelligentObjects["Tn"]), ((INodeObject)model.Facility.IntelligentObjects["BarraFront"]), null);

            #region mesas
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa1"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa2"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa3"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa4"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa5"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa6"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa7"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas18"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa8"]).Nodes[0], null);

            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas910"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa9"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["Mesas910"]), ((IFixedObject)model.Facility.IntelligentObjects["Mesa10"]).Nodes[0], null);

            // Mesas a basic node
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa1"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa2"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa3"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa4"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa5"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa6"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa7"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa8"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), null);

            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode1"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode2"]), null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode2"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode3"]), null);

            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa9"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode3"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["Mesa10"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode3"]), null);

            intelligentObjects.CreateLink("TimePath", ((INodeObject)model.Facility.IntelligentObjects["BasicNode3"]), ((IFixedObject)model.Facility.IntelligentObjects["Salida"]).Nodes[0], null);
            #endregion

            #region barraFront
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BarraFront"]), ((IFixedObject)model.Facility.IntelligentObjects["BarraEnfrente"]).Nodes[0], null);
            intelligentObjects.CreateLink("TimePath", ((IFixedObject)model.Facility.IntelligentObjects["BarraEnfrente"]).Nodes[1], ((IFixedObject)model.Facility.IntelligentObjects["Salida"]).Nodes[0], null);
            #endregion

            #region barrasLaterales
            intelligentObjects.CreateLink("TimePath", ((INodeObject)model.Facility.IntelligentObjects["BasicNode4"]), ((IFixedObject)model.Facility.IntelligentObjects["Salida"]).Nodes[0], null);

            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode5"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode4"]), null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode6"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode5"]), null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BarrasLaterales"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode8"]), null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode8"]), ((INodeObject)model.Facility.IntelligentObjects["BasicNode7"]), null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BarrasLaterales"]), ((IFixedObject)model.Facility.IntelligentObjects["LateralD"]).Nodes[0], null);
            intelligentObjects.CreateLink("Path", ((INodeObject)model.Facility.IntelligentObjects["BasicNode7"]), ((IFixedObject)model.Facility.IntelligentObjects["LateralI"]).Nodes[0], null);

            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["LateralI"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode6"]), null);
            intelligentObjects.CreateLink("Path", ((IFixedObject)model.Facility.IntelligentObjects["LateralD"]).Nodes[1], ((INodeObject)model.Facility.IntelligentObjects["BasicNode4"]), null);

            #endregion

            intelligentObjects.CreateObject("ModelEntity", new FacilityLocation(-7.5, 0, -3));

            // Llegada-Caja
            model.Facility.IntelligentObjects["Conveyor1"].Properties["DrawnToScale"].Value = "False";
            model.Facility.IntelligentObjects["Conveyor1"].Properties["LogicalLength"].Value = "8";
            // Caja-Entrega
            model.Facility.IntelligentObjects["Conveyor2"].Properties["DrawnToScale"].Value = "False";
            model.Facility.IntelligentObjects["Conveyor2"].Properties["LogicalLength"].Value = "6";
            //Entrega-Salida
            model.Facility.IntelligentObjects["TimePath2"].Properties["SelectionWeight"].Value = "0.5";
            model.Facility.IntelligentObjects["TimePath2"].Properties["TravelTime"].Value = "0.25"; //seg
            //Entrega-Mesas 1 -8
            model.Facility.IntelligentObjects["TimePath3"].Properties["SelectionWeight"].Value = "0.25";
            model.Facility.IntelligentObjects["TimePath3"].Properties["TravelTime"].Value = "0.11667"; //seg            
            //Entrega Mesas 9- 10
            model.Facility.IntelligentObjects["TimePath4"].Properties["SelectionWeight"].Value = "0.08";
            model.Facility.IntelligentObjects["TimePath4"].Properties["TravelTime"].Value = "0.16667"; //seg
            //Entrega - Laterales
            model.Facility.IntelligentObjects["Conveyor5"].Properties["SelectionWeight"].Value = "0.10";
            model.Facility.IntelligentObjects["Conveyor5"].Properties["DrawnToScale"].Value = "False";
            model.Facility.IntelligentObjects["Conveyor5"].Properties["LogicalLength"].Value = "10";
            //Entrega - Frontal
            model.Facility.IntelligentObjects["Conveyor6"].Properties["SelectionWeight"].Value = "0.07";
            model.Facility.IntelligentObjects["Conveyor6"].Properties["DrawnToScale"].Value = "False";
            model.Facility.IntelligentObjects["Conveyor6"].Properties["LogicalLength"].Value = "5";
            // Mesas - salida
            model.Facility.IntelligentObjects["TimePath5"].Properties["TravelTime"].Value = "0.416667"; //seg
            model.Facility.IntelligentObjects["TimePath6"].Properties["TravelTime"].Value = "0.416667"; //seg
            model.Facility.IntelligentObjects["TimePath7"].Properties["TravelTime"].Value = "0.416667"; //seg
            model.Facility.IntelligentObjects["Path26"].Properties["SelectionWeight"].Value = "0.5";
            model.Facility.IntelligentObjects["Path28"].Properties["SelectionWeight"].Value = "0.5";

            //Cliente
            model.Facility.IntelligentObjects["ModelEntity1"].ObjectName = "Cliente";
            model.Facility.IntelligentObjects["Entrada"].Properties["EntityType"].Value = "Cliente";

        }
    }
}
