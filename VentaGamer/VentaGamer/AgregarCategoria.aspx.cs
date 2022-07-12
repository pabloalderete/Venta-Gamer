using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using System.IO;

namespace VentaGamer
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        NegocioCategoria negCategoria = new NegocioCategoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null) // Usuario logueado
            {
                bool permiso = Convert.ToBoolean(((DataTable)Session["Usuario"]).Rows[0]["Permiso_Us"]);
                if (!permiso)
                {
                    Response.Redirect("~/Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = txtNombreCategoria.Text;
            categoria.Descripcion = txtDescripcionCategoria.Text;
            categoria.Estado = Convert.ToBoolean(ddlEstadoCategoria.SelectedValue);

            if (Page.IsValid)
            {
                if (fuImagenCategoria.HasFile)
                {
                    string ext = Path.GetExtension(fuImagenCategoria.FileName);
                    ext = ext.ToLower();
                    int tam = fuImagenCategoria.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg" || ext == ".jpeg") && tam <= 2097152)
                    {
                        DataTable categoriaMaxId = negCategoria.getMaxId();
                        int id = Convert.ToInt32(categoriaMaxId.Rows[0]["Maximo"]) + 1;
                        categoria.Imagen = $"~/Imagenes/Categoria_{id}{ext}";
                        fuImagenCategoria.SaveAs(Server.MapPath($"~/Imagenes/Categoria_{id}{ext}"));
                    }
                }

                if (negCategoria.setCategoria(categoria))
                {
                    lblMensaje.Text = "La categoria se agrego correctamente.";
                }
                else
                {
                    lblMensaje.Text = "La categoria ya existe.";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeAgregar", "msjeAgregar()", true);
            }
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SeleccionarModificarCategoria.aspx");
        }

        protected void cuvTxtNombreCategoria_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtNombreCategoria.Text.Trim().Length;

            if (size <= 15)
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

        protected void cuvTxtDescripcionCategoria_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtDescripcionCategoria.Text.Trim().Length;

            if (size <= 100)
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
    }
}