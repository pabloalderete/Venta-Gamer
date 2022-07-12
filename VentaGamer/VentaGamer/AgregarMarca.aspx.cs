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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        NegocioMarca negMarca = new NegocioMarca();
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

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.Nombre = txtNombreMarca.Text;
            marca.Eslogan = txtEsloganMarca.Text;
            marca.Estado = Convert.ToBoolean(ddlEstadoMarca.SelectedValue);

            if(Page.IsValid)
            {
                if (fuImagenMarca.HasFile)
                {
                    string ext = Path.GetExtension(fuImagenMarca.FileName);
                    ext = ext.ToLower();
                    int tam = fuImagenMarca.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg") && tam <= 2097152)
                    {
                        DataTable marcaMaxId = negMarca.getMaxId();
                        int id = Convert.ToInt32(marcaMaxId.Rows[0]["Maximo"]) + 1;
                        marca.Imagen = $"~/Imagenes/Marca_{marca.Id}{ext}";
                        fuImagenMarca.SaveAs(Server.MapPath($"~/Imagenes/Marca_{marca.Id}{ext}"));
                    }
                }
                else
                {
                    marca.Imagen = "~/Imagenes/No_Image.png";
                }

                if (negMarca.setMarca(marca))
                {
                    lblMensaje.Text = "La marca se agrego correctamente.";
                }
                else
                {
                    lblMensaje.Text = "La marca ya existe.";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeAgregar", "msjeAgregar()", true);
            }
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SeleccionarModificarMarca.aspx");
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