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
    public partial class ModificarMarca : System.Web.UI.Page
    {
        NegocioMarca negMarca = new NegocioMarca();
        static Marca marca = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Convert.ToInt32(Request.Params["IdMarca"]);
                marca = new Marca(id);
                DataTable tablaMarca = negMarca.getMarca(marca);
                marca.llenar(tablaMarca);

                txtNombreMarca.Text = marca.Nombre;
                txtEsloganMarca.Text = marca.Eslogan;
                ddlEstadoMarca.SelectedValue = marca.Estado.ToString().ToLower();
                imgActualProducto.ImageUrl = marca.Imagen;
               
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

        protected void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                marca.Nombre = txtNombreMarca.Text;
                marca.Eslogan = txtEsloganMarca.Text;
                marca.Estado = Convert.ToBoolean(ddlEstadoMarca.SelectedValue);

                if (fuImagenMarca.HasFile)
                {
                    string rutaImagen = Server.MapPath(marca.Imagen);
                    string ext = Path.GetExtension(fuImagenMarca.FileName).ToLower();
                    int tam = fuImagenMarca.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg" || ext == ".jpeg") && tam <= 2097152)
                    {
                        if (File.Exists(rutaImagen))
                        {
                            File.Delete(rutaImagen);
                        }

                        marca.Imagen = $"~/Imagenes/Marca_{marca.Id}{ext}";
                        fuImagenMarca.SaveAs(Server.MapPath($"~/Imagenes/Marca_{marca.Id}{ext}"));
                    }
                }
                negMarca.updateMarca(marca);
            }
        }

        protected void cuvTxtNombreMarca_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtNombreMarca.Text.Trim().Length;

            if (size <= 20)
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

        protected void cuvTxtEsloganMarca_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtEsloganMarca.Text.Trim().Length;

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