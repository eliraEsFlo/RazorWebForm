using Backend.Infrastructura;
using Backend.Infrastructura.Entities;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.AdministradorPages
{
    public partial class RequerimientosAsignados : System.Web.UI.Page
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public RequerimientosAsignados()
        {
        }
        public RequerimientosAsignados(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string tipoDeAsignacion = ModosDeAsignacion.SelectedItem.Text;

                BindGridView(RequerimientosGridView, _unitOfWork
                                                         .Requerimientos
                                                             .ObtenerRequerimientoPorTipoAsignacion(tipoDeAsignacion));
                BindControl(EstadosRequerimientos, _unitOfWork.Requerimientos.ObtenerEstadoRequerimiento());

            }
        }

        public void BindControl(ListControl control, object source)
        {
            control.DataSource = source;
            control.DataBind();
        }



        public void BindGridView(GridView grid, object dataSource)
        {
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        protected void RequerimientosGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            string idRequerimiento = RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[1].Text;

            BindGridView(programadoresEnRequerimiento, _unitOfWork.Requerimientos.ObtenerProgramdoresEnRequerimiento(idRequerimiento));
            BindGridView(PermisosGridView, _unitOfWork.Requerimientos.ObtenerPermisosPuRequeridos(idRequerimiento));
            /*
            string s = "";
            for (int i  = 0; i <  RequerimientosGridView.Rows[e.NewSelectedIndex].Cells.Count; i++)
            {
                s += RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[i].Text;
            }

            mensaje.Text = s;
            */

            //Response.Write("<script>window.open('file://10.4.133.25/Compartir/Requerimientos/dummy.pdf,'_blank');</script>");
            //Response.Write("<script>window.open('http://localhost:54713/Brochures/dummy.pdf','_blank');</script>");

        }

        protected void SearchText_TextChanged(object sender, EventArgs e)
        {
            string d = ModosDeAsignacion.SelectedItem.Value;
            string searched = SearchText.Text.Trim();

            RequerimientosGridView.DataSource = _unitOfWork
               .Requerimientos
                  .ObtenerRequerimientoPorTipoAsignacion(d)
                    .Where(r => r.idRequerimiento.Contains(searched));

            RequerimientosGridView.DataBind();
        }

        protected void TipoRequerimientos_TextChanged(object sender, EventArgs e)
        {

            string ModoAsignacion = ModosDeAsignacion.SelectedItem.Value;



            if (TipoRequerimientos.SelectedItem.Text == "Incidencia")
            {
                BindGridView(RequerimientosGridView,
                _unitOfWork.Incidencias.GetAll());
                return;
            }

            BindGridView(RequerimientosGridView, _unitOfWork
               .Requerimientos
                  .ObtenerRequerimientoPorTipoAsignacion(ModoAsignacion));
        }

        protected void ModosDeAsignacion_TextChanged(object sender, EventArgs e)
        {
            string tipoDeAsignacion = ModosDeAsignacion.SelectedItem.Text;

            List<Requerimiento> fromDb = _unitOfWork.Requerimientos.ObtenerRequerimientoPorTipoAsignacion(tipoDeAsignacion).ToList();
            List<RequerimientoViewModel> r = new List<RequerimientoViewModel>();

            fromDb.ForEach(data => {
                r.Add(new RequerimientoViewModel()
                {
                    idRequerimiento = data.idRequerimiento,
                    NombreRequerimiento = data.NombreRequerimiento,
                    NombreArea = data.NombreArea,
                    NombreTipoRequerimiento = data.NombreTipoRequerimiento,
                    FechaAsignacion = data.FechaAsignacion,
                    Prioridad = data.Prioridad,
                    NombreEstado = data.NombreEstado,
                    NombreLider = data.NombreLider
                });
            });

            BindGridView(RequerimientosGridView, r);
        }

        protected void EstadosRequerimientos_TextChanged(object sender, EventArgs e)
        {
            string filtroTipoAsignacion = ModosDeAsignacion.SelectedItem.Text;
            string filtroEstado = EstadosRequerimientos.SelectedItem.Text;

            BindGridView(RequerimientosGridView, _unitOfWork
                                                    .Requerimientos
                                                      .ObtenerRequerimientoPorTipoAsignacion(filtroTipoAsignacion)
                                                        .Where(r => r.NombreEstado.Contains(filtroEstado))
                                                 );
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string filePath = "\\10.4.133.25\\Compartir\\Requerimientos\\dummy.pdf";

            Response.ContentType = "application/pdf";

            Response.WriteFile(filePath);
            Response.Clear();



        }
    }
}