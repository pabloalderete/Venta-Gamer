using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Negocio;
using Entidades;

namespace VentaGamer
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        NegocioCategoria negCategoria = new NegocioCategoria();
        NegocioMarca negMarca = new NegocioMarca();
        NegocioProducto negProducto = new NegocioProducto();
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

            if (!IsPostBack)
            {
                ddlCategoria.DataSource = negCategoria.getCategorias();
                ddlCategoria.DataTextField = "Nombre_Ca";
                ddlCategoria.DataValueField = "IdCategoria_Ca";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = negMarca.getMarcas();
                ddlMarca.DataTextField = "Nombre_Ma";
                ddlMarca.DataValueField = "IdMarca_Ma";
                ddlMarca.DataBind();
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
            producto.Marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
            producto.Nombre = txtNombreProducto.Text;
            producto.Descripcion = txtDescripcionProducto.Text;
            producto.Precio = Convert.ToDecimal(txtPrecioProducto.Text);
            producto.Stock = Convert.ToInt32(txtStockProducto.Text);
            producto.Estado = Convert.ToBoolean(ddlEstadoProducto.SelectedValue);



            if(Page.IsValid)
            {
                if (fuImagenProducto.HasFile)
                {
                    string ext = Path.GetExtension(fuImagenProducto.FileName);
                    ext = ext.ToLower();
                    int tam = fuImagenProducto.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg" || ext == ".jpeg") && tam <= 2097152)
                    {
                        DataTable productosMaxId = negProducto.getMaxId();
                        int id = Convert.ToInt32(productosMaxId.Rows[0]["Maximo"]) + 1;
                        producto.Imagen = $"~/Imagenes/Producto_{id}{ext}";
                        fuImagenProducto.SaveAs(Server.MapPath($"~/Imagenes/Producto_{id}{ext}"));
                    }
                }

                if (negProducto.setProducto(producto))
                {
                    lblMensaje.Text = "El producto se agrego correctamente.";
                }
                else
                {
                    lblMensaje.Text = "El producto ya existe.";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeAgregar", "msjeAgregar()", true);
            }
        }

        protected void lnkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SeleccionarModificarProducto.aspx");
        }

        protected void cuvTxtNombreProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtNombreProducto.Text.Trim().Length;

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

        protected void cuvTxtDescripcionProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtDescripcionProducto.Text.Trim().Length;

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

        protected void cuvTxtPrecioProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtPrecioProducto.Text.Trim().Length;

            if (size <= 6)
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

        protected void cuvTxtStockProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtStockProducto.Text.Trim().Length;

            if (size <= 4)
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