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

                RequerimientosGridView.DataSource = _unitOfWork
                                                        .Requerimientos
                                                            .ObtenerRequerimientoPorTipoAsignacion(tipoDeAsignacion);

                RequerimientosGridView.DataBind();

            }
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

            BindGriwView(RequerimientosGridView, r);
        }

        public void BindGriwView(GridView grid, object dataSource)
        {
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        protected void RequerimientosGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            programadoresEnRequerimiento.DataSource = _unitOfWork.Requerimientos.ObtenerTiposRequerimientos();
            programadoresEnRequerimiento.DataBind();
            /*
            string s = "";
            for (int i  = 0; i <  RequerimientosGridView.Rows[e.NewSelectedIndex].Cells.Count; i++)
            {
                s += RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[i].Text;
            }

            mensaje.Text = s;
            */

            //Response.Write("<script>window.open('http://localhost:54713/Brochures/dummy.pdf','_blank');</script>");
            //Response.Write("<script>window.open('http://localhost:54713/Brochures/dummy.pdf','_blank');</script>");

        }

        protected void SearchText_TextChanged(object sender, EventArgs e)
        {
            string d = ModosDeAsignacion.SelectedItem.Value;
            string searched = SearchText.Text.Trim();
            if (searched == "")
            {
                RequerimientosGridView.DataSource = _unitOfWork
              .Requerimientos
                 .ObtenerRequerimientoPorTipoAsignacion(d);
                RequerimientosGridView.DataBind();
                return;
            }

            RequerimientosGridView.DataSource = _unitOfWork
               .Requerimientos
                  .ObtenerRequerimientoPorTipoAsignacion(d)
                    .Where(r => r.idRequerimiento.Contains(searched));

            RequerimientosGridView.DataBind();
        }
    }
}