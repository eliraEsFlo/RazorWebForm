using Backend.Infrastructura.ProcedimientosAlmacenados;
using Backend.Infrastructura.Repositorios;
using Backend.Infrastructura.TableServices;
using Core.Entities;
using ServiciosAplicacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MixingWebFormsMVC
{
    public partial class Login : System.Web.UI.Page
    {
        public Login()
        {

        }

        IGlobalServices _services;
        IStoredProcedureRepository _storedProcedures;
        public Login(IGlobalServices services, IStoredProcedureRepository storedProcedures)
        {
            _services = services;
            _storedProcedures = storedProcedures;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NoEsUsuarioText.Text = "Usuario incorrecto o contraseña";
                NoEsUsuarioText.CssClass = "text-danger";
                NoEsUsuarioText.Visible = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios() { 
                NombreUsuario =  NombreUsuarioInput.Text.Trim(),
                Password = PasswordUsuarioInput.Text.Trim()
            };

            string response = _services.ServicioDeAutenticacion.Login(usuario);
            if (response == "no")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "showModal()", true);
                NoEsUsuarioText.Visible = true;
             
                return;
            }

            Usuarios newUsuario = new Usuarios();
            int id = 0;
            new Repository<Usuarios>(new ProgramadoresTable()).GetAll()
                                        .ToList()
                                        .Where(u => u.NombreUsuario == usuario.NombreUsuario).ToList()
                                            .ForEach(user => {
                                                id = user.idUsuario;
                                            });

            newUsuario = _storedProcedures.userStoredProcedures.ObtenerEntidadPorId(id);

            if (newUsuario.DescripcionCredencial == "Admin")
            {
                string template = $"id={newUsuario.idUsuario}&name={newUsuario.NombreUsuario}";
                string page = $"~/AdministradorPages/SubirRequerimiento";
                var jefe = new
                {
                    appRoute = $"{page}.aspx?{template}",
                };
                Cache["Usuario"] = newUsuario.NombreUsuario;
                Response.Redirect(jefe.appRoute);
                return;
            }
           
            if(newUsuario.DescripcionCredencial == "Programador")
            {
                var programador = new
                {
                    appRoute = $"~/ProgramerPages/ProgrammerPanel.aspx?id={newUsuario.idUsuario}",
                };
                Cache["Usuario"] = newUsuario.NombreUsuario;
                Response.Redirect(programador.appRoute);
                return;
            }

        }
    }
}