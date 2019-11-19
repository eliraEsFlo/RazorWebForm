using Backend.Infrastructura;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.AdministradorPages
{
    public partial class EquipoProgramadores : System.Web.UI.Page
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public EquipoProgramadores() { }
        public EquipoProgramadores(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RequerimientosGridView.DataSource = _unitOfWork.Programadores.GetAll();
                RequerimientosGridView.DataBind();
            }
        }

        protected void ModosDeAsignacion_TextChanged(object sender, EventArgs e)
        {

            BindGriwView(RequerimientosGridView, _unitOfWork.Programadores.GetAll());
        }

        public void BindGriwView(GridView grid, object dataSource)
        {
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        protected void RequerimientosGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = Int32.Parse(RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[1].Text);
            var data = _unitOfWork.Requerimientos.ObtenerProyectosPorIdProgramador(index);
            if (0 == data.Count)
            {
                mensajeGrid.Visible = true;
                mensajeGrid.Text = "no hay nada";
                return;
            }
            mensajeGrid.Visible = false;
            idGrid.DataSource = data;
            idGrid.DataBind();
            /*
            string s = "";
            for (int i  = 0; i <  RequerimientosGridView.Rows[e.NewSelectedIndex].Cells.Count; i++)
            {
                s += RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[i].Text;
            }

            mensaje.Text = s;
            */

        }

        protected void SearchText_TextChanged(object sender, EventArgs e)
        {

            string searched = SearchText.Text.Trim();


            RequerimientosGridView.DataSource = _unitOfWork.Programadores.GetAll()
                    .Where(r => r.NombreUsuario.Contains(searched));

            RequerimientosGridView.DataBind();
        }
    }
}