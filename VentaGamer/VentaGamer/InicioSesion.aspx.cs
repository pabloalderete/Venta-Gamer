using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace VentaGamer
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        NegocioUsuario negUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnInicioSesion.UniqueID;

            if(Session["Usuario"] != null)
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Email = txtEmail.Text;
            usuario.Contrasena = txtPassword.Text;

            if (negUsuario.exists(usuario))
            {
                if(!negUsuario.ifValid(usuario)) {
                    return;
                }
                Session["Usuario"] = negUsuario.getLogin(usuario);
                Response.Redirect("~/Inicio.aspx");
            }
        }
    }
}