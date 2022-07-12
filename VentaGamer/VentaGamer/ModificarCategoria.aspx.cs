using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Globalization;
using System.IO;

namespace VentaGamer
{
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        NegocioCategoria negCategoria = new NegocioCategoria();
        static Categoria categoria = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Convert.ToInt32(Request.Params["IdCategoria"]);
                categoria = new Categoria(id);
                DataTable tablaCategoria = negCategoria.getCategoria(categoria);
                categoria.llenar(tablaCategoria);

                txtNombreCategoria.Text = categoria.Nombre;
                txtDescripcionCategoria.Text = categoria.Descripcion;
                ddlEstadoCategoria.SelectedValue = categoria.Estado.ToString().ToLower();
                imgActualProducto.ImageUrl = categoria.Imagen;
            }

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

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                categoria.Nombre = txtNombreCategoria.Text;
                categoria.Descripcion = txtDescripcionCategoria.Text;
                categoria.Estado = Convert.ToBoolean(ddlEstadoCategoria.SelectedValue);

                if (fuImagenCategoria.HasFile)
                {
                    string rutaImagen = Server.MapPath(categoria.Imagen);
                    string ext = Path.GetExtension(fuImagenCategoria.FileName).ToLower();
                    int tam = fuImagenCategoria.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg" || ext == ".jpeg") && tam <= 2097152)
                    {
                        if (File.Exists(rutaImagen))
                        {
                            File.Delete(rutaImagen);
                        }

                        categoria.Imagen = $"~/Imagenes/Categoria_{categoria.Id}{ext}";
                        fuImagenCategoria.SaveAs(Server.MapPath($"~/Imagenes/Categoria_{categoria.Id}{ext}"));
                    }
                }

                negCategoria.updateCategoria(categoria);
            }
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