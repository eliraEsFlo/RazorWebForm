using Backend.Infrastructura;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.AdministradorPages
{
    public partial class SubirRequerimiento : System.Web.UI.Page
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public SubirRequerimiento()
        {

        }

        private static List<Usuarios> programadoresEnMemoria = new List<Usuarios>();
        public SubirRequerimiento(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        private bool isLogged { get; set; } = false;
        public void ValidateUserCredentials() {
            if(isLogged == false)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
       


            if (!Page.IsPostBack)
            {
                Session["isLogged"] = isLogged;

               // ValidateUserCredentials();

                SetDataControls();
                BindDataGridViewInChache();

                if (TipoRequerimientoCmbx.SelectedItem.Text == incidencia)
                {
                    modoDeTrabajo.Enabled = false;

                    BindData(ProgramadoresCombobox, _unitOfWork.Requerimientos.ObtenerProgramadoresConId());
                    ProgramadoresCombobox.Enabled = true;
                    return;
                }


                SetUserAccount(); 
            }


        }

        public void SetUserAccount()
        {

            string name = Cache["Usuario"] as string;
         
            userLogout.NavigateUrl = "~/Login.aspx";
            userLogout.CssClass = "text-white";
            userLogout.Text = $"<i class='fas fa-arrow-left'></i> {name}";
        }


        public void ClearControls(object sender, EventArgs evt)
        {

            NoRequerimientoTextbox.Text = _unitOfWork.Requerimientos.ObtenerUltimoIdDeRequerimiento();

            NombreRequerimientoTextbox.Text = String.Empty;

            LideresCombobox.Items.Clear();
            ProgramadoresCombobox.Items.Clear();

            RutaRequerimientoFileUpload.Dispose();

            InitComboboxes(ProcesosCheckboxes.Items);
            InitComboboxes(PermisosCheckboxes.Items);

            programadoresEnMemoria.Clear();
            BindDataGridViewInChache();
            BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

        }

        public void SetDataControls()
        {
            InitBindData();
            CambiarEstadoModoTrabajo(lider: false, programador: false);

            InitComboboxes(ProcesosCheckboxes.Items);
            InitComboboxes(PermisosCheckboxes.Items);
            InitRequerimientosValues();

            liderWarning.Text = "El lider ya existe"; liderWarning.Visible = false;

            programmerWarning.Text = "El usuario ya existe"; programmerWarning.Visible = false;
        }


        public void BindData(ListControl control, object dataSource)
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

            var permisos = _unitOfWork.Requerimientos.ObtenerPermisosDePU();

            BindData(PermisosCheckboxes, permisos);

            BindData(AreasSolicitantesCombobox, _unitOfWork.Requerimientos.ObtenerAreas());

            BindData(TipoRequerimientoCmbx, _unitOfWork.Requerimientos.ObtenerTiposRequerimientos());

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
            foreach (ListItem item in listcontrol)
            {
                item.Selected = true;
            }
        }

        protected void BindDataGridViewInChache()
        {


            string nombreStructura = nameof(programadoresEnMemoria);
            if (Cache[nombreStructura] == null)
            {

                Cache.Add(nombreStructura, programadoresEnMemoria, null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 60),
                    System.Web.Caching.CacheItemPriority.Default, null);
            }
            else
                programadoresEnMemoria = (List<Usuarios>)Cache[nombreStructura];
            BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

        }

        protected void ElegirLiderEquipo(object sender, EventArgs e)
        {
            var item = LideresCombobox.SelectedItem;
            int programmerId = Int32.Parse(item.Value);
            string name = item.Text;
            Usuarios programadorLider = new Usuarios()
            {
                idUsuario = programmerId,
                NombreUsuario = name,
                tipoUsuario = "lider"
            };

            IEnumerable<Usuarios> programadoresTemporales = _unitOfWork
                .Requerimientos
                .ObtenerProgramadoresConId()
                .Where(p => p.idUsuario != programmerId);

            bool elLiderYaExiste = programadoresEnMemoria
                .ToList()
                .Exists(p => p.idUsuario == programmerId);

            if (elLiderYaExiste)
            {
                liderWarning.Visible = true;
                return;
            }

            liderWarning.Visible = false;
            programmerWarning.Visible = false;
            Usuarios programador = programadoresEnMemoria.FirstOrDefault(p => p.tipoUsuario == "lider");

            programadoresEnMemoria.Remove(programador);
            BindDataGridViewInChache();
            BindAddProgramador(programadorLider);
            BindData(ProgramadoresCombobox, programadoresTemporales.ToList());
        }

        protected void DeleteTempProgrammersData(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            programadoresEnMemoria.RemoveAt(index);
            BindGriwView(ProgramadoresGridView, programadoresEnMemoria);
        }


        public void BindAddProgramador(Usuarios programador)
        {
            programadoresEnMemoria.Add(programador);
            BindDataGridViewInChache();
        }

        protected void AddTempProgrammerData(object sender, EventArgs e)
        {
            string idUsuario = ProgramadoresCombobox.SelectedItem.Value;
            Usuarios programador = new Usuarios()
            {
                idUsuario = Int32.Parse(idUsuario),
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
            BindAddProgramador(programador);
        }


        string incidencia;
        protected void InitRequerimientosValues()
        {
            string ultimoNoReq = _unitOfWork.Requerimientos.ObtenerUltimoIdDeIndidencia();

            string tipoRequerimiento = TipoRequerimientoCmbx.SelectedItem.Text;

            if(tipoRequerimiento != null)
            {
                if (tipoRequerimiento == incidencia)
                {
                    AreasSolicitantesCombobox.SelectedIndex = 3;
                    AreasSolicitantesCombobox.Enabled = false;
                    modoDeTrabajo.Enabled = false;
                    ProgramadoresCombobox.Items.Clear();
                    LideresCombobox.Items.Clear();
                    NoRequerimientoTextbox.Text = ultimoNoReq;
                    return;
                }

                AreasSolicitantesCombobox.Enabled = true;
                AreasSolicitantesCombobox.SelectedIndex = 1;
                modoDeTrabajo.Enabled = true;
                NoRequerimientoTextbox.Text = _unitOfWork.Requerimientos.ObtenerUltimoIdDeRequerimiento();
                ProgramadoresCombobox.Items.Clear();
                LideresCombobox.Items.Clear();

            }
            CambiarEstadoModoTrabajo(true, true);
        }


        public void SavePdfFile()
        {
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
                    estadoTexto.Text = stringBuilder.ToString();

                    //Save the file
                    //string filePath = Server.MapPath("~/Brochures/" + RutaRequerimientoFileUpload.FileName);
                    //RutaRequerimientoFileUpload.SaveAs(filePath);

                    RutaRequerimientoFileUpload.SaveAs(GetServerRoute(FileName));
                }

            }
        }

        public string GetServerRoute(string FileName)
        {
            return $"\\\\10.4.133.25\\Compartir\\Requerimientos\\{FileName}";
        }
        protected void AgregarRequerimientoEvent(object sender, EventArgs e)
        {

            if (TipoRequerimientoCmbx.SelectedItem.Text == incidencia)
            {
                modoDeTrabajo.Enabled = false;
                ProgramadoresCombobox.Enabled = true;
                BindData(ProgramadoresCombobox, _unitOfWork.Requerimientos.ObtenerProgramadoresConId());

                IncidenciasProduccion incidencia = new IncidenciasProduccion()
                {

                    idIncidenciaProduccion = NoRequerimientoTextbox.Text,
                    NombreIncidencia = NombreRequerimientoTextbox.Text,
                    DescripcionIncidencia = "",
                    idUsuario = Int32.Parse(ProgramadoresCombobox.SelectedItem.Value)
                };

                bool isQueryDonw = _unitOfWork.Requerimientos.InsertarIncidencia(incidencia);
                if (isQueryDonw)
                {
                    ClearControls(sender, e);
                }
                return;
            }

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
                    {
                        idPermisoPU = Int32.Parse(p.Value),
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
                    });
                });


            int sinEmpezar = 1;

            Requerimientos requerimiento = new Requerimientos()
            {
                idRequerimiento = NoRequerimientoTextbox.Text,
                NombreRequerimiento = NombreRequerimientoTextbox.Text,
                RutaRequerimiento = GetServerRoute(RutaRequerimientoFileUpload.FileName),
                idArea = Int32.Parse(AreasSolicitantesCombobox.SelectedItem.Value),
                idTipoRequerimiento = Int32.Parse(TipoRequerimientoCmbx.SelectedItem.Value),
                idEstadoRequerimiento = sinEmpezar,
                Prioridad = "Alta",
                idUsuario = modoDeTrabajo.SelectedItem.Text == "Individual" ? Int32.Parse(ProgramadoresCombobox.SelectedItem.Value) : 0,
               
            };



            if (modoDeTrabajo.SelectedItem.Text == "Equipo")
            {
                int idLider = _unitOfWork.LideresProyecto.GetAll().LastOrDefault().idLiderProyecto;
                bool insertEquiposQueryIsOk = _unitOfWork
                  .Requerimientos
                    .InsertarEquiposDeTrabajo(idLider, programadoresEnMemoria);
                return;
            }


            bool Ok = _unitOfWork.Requerimientos.InsertarRequerimiento(requerimiento);
            if (Ok)
            {

                SavePdfFile();
                programmerWarning.Text = "Se inserto";
                ClearControls(sender, e);

                programmerWarning.Visible = true;
                return;
            }
        }


        protected void modoDeTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = modoDeTrabajo.SelectedItem;
            if (item.Text == "Individual")
            {
                programadoresEnMemoria.Clear();
                BindDataGridViewInChache();
                BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

                CambiarEstadoModoTrabajo(false, true);
                BindData(LideresCombobox, new List<Usuarios>());
                BindData(ProgramadoresCombobox, _unitOfWork.Requerimientos.ObtenerProgramadoresConId());
                AgregarProgramadorButton.Visible = false;

            }

            if (item.Text == "Equipo")
            {
                programadoresEnMemoria.Clear();
                BindDataGridViewInChache();
                BindGriwView(ProgramadoresGridView, programadoresEnMemoria);

                BindData(ProgramadoresCombobox, new List<Usuarios>());
                CambiarEstadoModoTrabajo(true, true);
                BindData(LideresCombobox, _unitOfWork.Requerimientos.ObtenerProgramadoresConId());

            }
        }


        protected void TipoRequerimientoCmbx_TextChanged(object sender, EventArgs e)
        {
            string ultimoDato = _unitOfWork.Requerimientos.ObtenerUltimoIdDeIndidencia();

            string tipoRequerimiento = TipoRequerimientoCmbx.SelectedItem.Text;

            //variable en escope
            incidencia = "Incidencia";
            if (tipoRequerimiento == incidencia)
            {
                AreasSolicitantesCombobox.SelectedIndex = 3;
                AreasSolicitantesCombobox.Enabled = false;
                modoDeTrabajo.Enabled = false;
                ProgramadoresCombobox.Items.Clear();
                LideresCombobox.Items.Clear();
                NoRequerimientoTextbox.Text = ultimoDato;
                return;
            }

            AreasSolicitantesCombobox.Enabled = true;
            AreasSolicitantesCombobox.SelectedIndex = 1;
            modoDeTrabajo.Enabled = true;
            NoRequerimientoTextbox.Text = _unitOfWork.Requerimientos.ObtenerUltimoIdDeRequerimiento();
            ProgramadoresCombobox.Items.Clear();
            LideresCombobox.Items.Clear();

            CambiarEstadoModoTrabajo(true, true);
        }
    }
}