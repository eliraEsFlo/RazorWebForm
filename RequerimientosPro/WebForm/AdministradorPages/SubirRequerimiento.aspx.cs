using Backend.Infrastructura;
using Backend.Infrastructura.Entities;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace Frontend.AdministradorPages
{
    public partial class SubirRequerimiento : System.Web.UI.Page
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public SubirRequerimiento()
        {
           
        }


        private static List<Programadores> programadoresEnMemoria = new List<Programadores>();
        public SubirRequerimiento(IUnitOfWork unitOfWork)
        {
          
            _unitOfWork = unitOfWork;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
             
                SetDataControls();
                BindDataInCache();
               
            }

        }

     
        public void ClearControls(object sender, EventArgs evt)
        {

            NoRequerimientoTextbox.Text = String.Empty;
            AreasSolicitantesCombobox.Items.Clear();
            TiposDeRequerimientosCombobox.Items.Clear();
            NombreRequerimientoTextbox.Text = String.Empty;

            ProcesosCheckboxes.Items.Clear();
            PermisosCheckboxes.Items.Clear();

            RutaRequerimientoFileUpload.Dispose();
        }




        public void SetDataControls()
        {

            liderWarning.Text = "El lider ya existe"; liderWarning.Visible = false;

            programmerWarning.Text = "El usuario ya existe"; programmerWarning.Visible = false;

            InitBindData();
            CambiarEstadoModoTrabajo(lider:false,programador:false);
            InitRequerimientosValues();
            InitComboboxes(ProcesosCheckboxes.Items);
            InitComboboxes(PermisosCheckboxes.Items);
        }


        public void BindData(ListControl control,  object dataSource)
        {
            control.DataSource = dataSource;
            control.DataBind();
        }

        public void BindGriwView(GridView grid, object dataSource)
        {
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        public void InitBindData()
        {
        
            BindData(ProcesosCheckboxes, _unitOfWork.Requerimientos.ObtenerProcesos());

            BindData(PermisosCheckboxes, _unitOfWork.Requerimientos.ObtenerPermisosDePU());

            BindData(AreasSolicitantesCombobox, _unitOfWork.Requerimientos.ObtenerAreas());

            BindData(TiposDeRequerimientosCombobox, _unitOfWork.Requerimientos.ObtenerTiposRequerimientos());
        }

        public void CambiarEstadoModoTrabajo(bool lider, bool programador)
        {
            LideresCombobox.Enabled = lider;
            ProgramadoresCombobox.Enabled = programador;
            AgregarLiderButton.Visible = lider;
            AgregarProgramadorButton.Visible = programador;
        }

        public void InitComboboxes(ListItemCollection listcontrol)
        {
            foreach(ListItem item in listcontrol)
            {
                item.Selected = true;
            }
        }

        protected void BindDataInCache()
        {

            BindGriwView(ProgramadoresGridView, programadoresEnMemoria);
            string nombreStructura = nameof(programadoresEnMemoria);
            if (Cache[nombreStructura] == null)
            {

                Cache.Add(nombreStructura, programadoresEnMemoria, null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 60),
                    System.Web.Caching.CacheItemPriority.Default, null);
            }
            else
                programadoresEnMemoria = (List<Programadores>)Cache[nombreStructura];

        }

        protected void SetEquipoLider(object sender, EventArgs e)
        {
            var item = LideresCombobox.SelectedItem;
            int programmerId = Int32.Parse(item.Value) ;
            string name = item.Text;
            Programadores programadorLider = new Programadores()
            {
                idUsuario = programmerId,
                NombreUsuario = name,
                tipoUsuario = "lider"
            };

            IEnumerable<Programadores> programadoresTemporales = _unitOfWork
                .Requerimientos
                .ObtenerProgramadoresConId()
                .Where(p => p.idUsuario != programmerId);

            bool elLiderYaExiste = programadoresEnMemoria
                .ToList()
                .Exists(p => p.idUsuario == programmerId);

            if(elLiderYaExiste)
            {
                liderWarning.Visible = true;
                return;
            }

            liderWarning.Visible = false ;
            programmerWarning.Visible = false;
            Programadores programador = programadoresEnMemoria.FirstOrDefault(p => p.tipoUsuario == "lider");

            programadoresEnMemoria.Remove(programador);
            AddProgramador(programadorLider);

            BindData(ProgramadoresCombobox, programadoresTemporales.ToList());
        }

        protected void DeleteTempProgrammersData(object sender, GridViewDeleteEventArgs e)
        {
          
            string itemIndex = ProgramadoresGridView.DataKeys[e.RowIndex].Value.ToString();
            int index = Int32.Parse(itemIndex) - 1;
            programadoresEnMemoria.RemoveAt(index);
            BindDataInCache();
        }

    
        public void AddProgramador(Programadores programador)
        {
            programadoresEnMemoria.Add(programador);
            BindDataInCache();
        }

        protected void AddTempProgrammerData(object sender, EventArgs e)
        {
            Programadores programador = new Programadores()
            {
                idUsuario =  Int32.Parse(ProgramadoresCombobox.SelectedItem.Value),
                NombreUsuario = ProgramadoresCombobox.SelectedItem.Text,
                tipoUsuario = "programador"
            };

            bool elProgramadorExiste = programadoresEnMemoria.Exists(p => p.idUsuario == programador.idUsuario);
            if (elProgramadorExiste)
            {
                programmerWarning.Visible = true; 
                return;
            }

            programmerWarning.Visible = false;
            liderWarning.Visible = false;
            AddProgramador(programador);
        }

        protected void Data(object sender, EventArgs e)
        {
            InitRequerimientosValues();
        }

        protected void InitRequerimientosValues()
        {
            string incidencia = "Incidencia";
            if (TiposDeRequerimientosCombobox.SelectedItem.Text == incidencia)
            {
                AreasSolicitantesCombobox.SelectedIndex = 3;
                AreasSolicitantesCombobox.Enabled = false;
                NoRequerimientoTextbox.Text = _unitOfWork.Requerimientos.ObtenerUltimoIdDeIndidencia();
                return;
            }
            AreasSolicitantesCombobox.Enabled = true;
            NoRequerimientoTextbox.Text = _unitOfWork.Requerimientos.ObtenerUltimoIdDeRequerimiento();
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

            SavePdfFile();
           
        }

        public void SavePdfFile() {
            if (RutaRequerimientoFileUpload.HasFile)
            {
                if (RutaRequerimientoFileUpload.HasFile == false)
                {
                    estadoTexto.Text = "Por favor seleciona un archivo...";
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    string FileName = RutaRequerimientoFileUpload.FileName;
                    int fileLength = RutaRequerimientoFileUpload.FileBytes.Length;
                    stringBuilder.Append($"Archivo subido: {FileName}");
                    stringBuilder.Append($"<br /> Tamaño (in bytes): {fileLength}:NO<br />");
                    stringBuilder.Append($"Tipo: { RutaRequerimientoFileUpload.PostedFile.ContentType}");
                    estadoTexto.Text =  stringBuilder.ToString();

                    //Save the file
                    string filePath = Server.MapPath("~/Brochures/" + RutaRequerimientoFileUpload.FileName);
                    RutaRequerimientoFileUpload.SaveAs(filePath);
                    //string serverRoute = $"\\\\10.4.133.40\\Compartir\\AtencionRequerimientos\\Requerimientos{FileName}";
                    //RutaRequerimientoFileUpload.SaveAs(serverRoute);
                }

            }
        }

        protected void AgregarRequerimientoEvent(object sender, EventArgs e)
        {
            List<ListItem> procesosSelecionados = ProcesosCheckboxes.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList();

            List<ListItem> permisosSelecionados = PermisosCheckboxes.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList();

            List<PermisosPorRequerimiento> permisos = new List<PermisosPorRequerimiento>();
            permisosSelecionados
                .ForEach(p =>
                {
                    permisos.Add(new PermisosPorRequerimiento()
                    {    idPermisoPU = Int32.Parse(p.Value),
                         EstadoPermiso = false
                    });
                });

            List<ProcesosPorRequerimiento> procesos = new List<ProcesosPorRequerimiento>();
            procesosSelecionados
                .ForEach(p =>
                {
                    procesos.Add(new ProcesosPorRequerimiento()
                    {
                        idProceso = Int32.Parse(p.Value),
                        EstadoProceso = p.Selected
                    }) ;
                });


           int sinEmpezar = 1;

            Requerimientos requerimiento = new Requerimientos()
            {
                idRequerimiento = NoRequerimientoTextbox.Text,
                NombreRequerimiento = NombreRequerimientoTextbox.Text,
                RutaRequerimiento = $"~/Brochures/{RutaRequerimientoFileUpload.FileName}",
                idArea = Int32.Parse(AreasSolicitantesCombobox.SelectedItem.Value),
                idTipoRequerimiento = Int32.Parse(TiposDeRequerimientosCombobox.SelectedItem.Value),
                idEstadoRequerimiento = sinEmpezar,
                Prioridad = "Alta",
                idUsuario = modoDeTrabajo.SelectedItem.Text == "Individual" ? Int32.Parse(ProgramadoresCombobox.SelectedItem.Value) : 0,
                idLiderProyecto = modoDeTrabajo.SelectedItem.Text == "Equipo" ? Int32.Parse(LideresCombobox.SelectedItem.Value) : 0,
                PermisosPorRequerimiento = permisos,
                ProcesosPorRequerimiento = procesos
            };

           bool Ok =  _unitOfWork.Requerimientos.InsertarRequerimiento(requerimiento);

            if (Ok)
            {
                programmerWarning.Text = "Se inserto";
                programmerWarning.Visible = true;
            }
        }


        protected void modoDeTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = modoDeTrabajo.SelectedItem;
            if(item.Text == "Individual")
            {
                programadoresEnMemoria.Clear();
                BindDataInCache();
                BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

                CambiarEstadoModoTrabajo(false, true);
                BindData(LideresCombobox, new List<Programadores>());
                BindData(ProgramadoresCombobox,_unitOfWork.Requerimientos.ObtenerProgramadoresConId());

            }

            if(item.Text == "Equipo")
            {
                programadoresEnMemoria.Clear();
                BindDataInCache();
                BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

                BindData(ProgramadoresCombobox, new List<Programadores>());
                CambiarEstadoModoTrabajo(true,true);
                BindData(LideresCombobox, _unitOfWork.Requerimientos.ObtenerProgramadoresConId());

            }
        }
    }
}