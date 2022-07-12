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
    public partial class Registro : System.Web.UI.Page
    {
        NegocioProvincia negProvincia = new NegocioProvincia();
        NegocioLocalidad negLocalidad = new NegocioLocalidad();
        NegocioUsuario negUsuario = new NegocioUsuario();

        private void cargarProvincias()
        {
            ddlProvincias.DataSource = negProvincia.getProvincias();
            ddlProvincias.DataTextField = "Provincia_Prv";
            ddlProvincias.DataValueField = "IdProvincia_Prv";
            ddlProvincias.DataBind();
        }

        private void cargarLocalidades()
        {
            if(ddlProvincias.SelectedValue.ToString() == "-- Seleccionar Provincia --")
            {
                ddlLocalidades.Enabled = false;
            }
            else
            {
                ddlLocalidades.Enabled = true;
            }

            Localidad localidad = new Localidad();
            if(ddlProvincias.SelectedValue.ToString() != "-- Seleccionar Provincia --")
            {
                localidad.Provincia.Id = Convert.ToInt32(ddlProvincias.SelectedValue);
            }

            ddlLocalidades.DataSource = negLocalidad.getLocalidadProvincias(localidad);
            ddlLocalidades.DataTextField = "Localidad_Lo";
            ddlLocalidades.DataValueField = "IdLocalidad_Lo";
            ddlLocalidades.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProvincias();
            cargarLocalidades();
        }

        protected void lnkRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Dni = txtDni.Text;
            usuario.Provincia.Id = Convert.ToInt32(ddlProvincias.SelectedValue);
            usuario.Localidad.Id = Convert.ToInt32(ddlLocalidades.SelectedValue); ;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.Contrasena = txtContrasena.Text;
            usuario.Direccion = txtDireccion.Text;
            usuario.Telefono = txtTelefono.Text;

            if (Page.IsValid)
            {
                if (negUsuario.setRegistro(usuario))
                {
                    lblMensajeAccionTitle.Text = "Accion exitosa";
                    lblMensajeAccion.Text = "El usuario se creo correctamente";

                }
                else
                {
                    lblMensajeAccionTitle.Text = "Accion fallo";
                    lblMensajeAccion.Text = "El usuario fallo en crearse";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmostrarMensajeAccion", "mostrarMensajeAccion()", true);
            }
        }

        protected void cuvTxtContrasena_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Verifica si el tamaño de la contraseña es 6 o mas caracteres
            bool sizeIsValid = false;
            int size = txtContrasena.Text.Trim().Length;

            if(size >= 6)
            {
                sizeIsValid = true;
            }

            if (sizeIsValid)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void lnkAceptarRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioSesion.aspx");
        }

        protected void cvTxtEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = txtEmail.Text.ToLower().Trim();
            DataTable tablaUsuarios = negUsuario.getUsuarios();
            bool existe = false;

            foreach(DataRow dr in tablaUsuarios.Rows)
            {
                if(email == dr["Email_Us"].ToString().ToLower().Trim())
                {
                    existe = true;
                }
            }

            if(existe == true)
            {
                args.IsValid = false;
                
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cv2txtDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string dni = txtDni.Text.Trim();
            DataTable tablaUsuarios = negUsuario.getUsuarios();
            bool existe = false;

            foreach (DataRow dr in tablaUsuarios.Rows)
            {
                if (dni == dr["Dni_Us"].ToString().Trim())
                {
                    existe = true;
                }
            }

            if (existe == true)
            {
                args.IsValid = false;

            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtContrasena.Attributes.Add("value", txtContrasena.Text);
            txtConfirmarContrasena.Attributes.Add("value", txtConfirmarContrasena.Text);
            cargarLocalidades();
        }
    }
}