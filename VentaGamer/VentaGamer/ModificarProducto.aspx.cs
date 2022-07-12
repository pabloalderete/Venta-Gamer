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
    public partial class ModificarProducto : System.Web.UI.Page
    {
        NegocioProducto negProducto = new NegocioProducto();
        NegocioCategoria negCategoria = new NegocioCategoria();
        NegocioMarca negMarca = new NegocioMarca();
        static Producto producto = null;

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
                int id = Convert.ToInt32(Request.Params["IdProducto"]);
                producto = new Producto(id);
                DataTable tablaProducto = negProducto.getProducto(producto);
                producto.llenar(tablaProducto);

                //Cargar categorias
                ddlCategoria.DataSource = negCategoria.getCategorias();
                ddlCategoria.DataTextField = "Nombre_Ca";
                ddlCategoria.DataValueField = "IdCategoria_Ca";
                ddlCategoria.SelectedValue = producto.Categoria.Id.ToString();
                ddlCategoria.DataBind();

                //Cargar Marcas
                ddlMarca.DataSource = negMarca.getMarcas();
                ddlMarca.DataTextField = "Nombre_Ma";
                ddlMarca.DataValueField = "IdMarca_Ma";
                ddlMarca.SelectedValue = producto.Marca.Id.ToString();
                ddlMarca.DataBind();

                txtNombreProducto.Text = producto.Nombre;
                txtDescripcionProducto.Text = producto.Descripcion;
                txtPrecioProducto.Text = producto.Precio.ToString();
                txtStockProducto.Text = producto.Stock.ToString();
                ddlEstadoProducto.SelectedValue = producto.Estado.ToString().ToLower();
                imgActualProducto.ImageUrl = producto.Imagen;
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

        protected void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                producto.Categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
                producto.Marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
                producto.Nombre = txtNombreProducto.Text;
                producto.Descripcion = txtDescripcionProducto.Text;
                producto.Precio = Convert.ToDecimal(txtPrecioProducto.Text);
                producto.Stock = Convert.ToInt32(txtStockProducto.Text);
                producto.Estado = Convert.ToBoolean(ddlEstadoProducto.SelectedValue);

                if (fuImagenProducto.HasFile)
                {
                    string rutaImagen = Server.MapPath(producto.Imagen);
                    string ext = Path.GetExtension(fuImagenProducto.FileName).ToLower();
                    int tam = fuImagenProducto.PostedFile.ContentLength;

                    if ((ext == ".png" || ext == ".jpg" || ext == ".jpeg") && tam <= 2097152)
                    {
                        if (File.Exists(rutaImagen))
                        {
                            File.Delete(rutaImagen);
                        }

                        producto.Imagen = $"~/Imagenes/Producto_{producto.Id}{ext}";
                        fuImagenProducto.SaveAs(Server.MapPath($"~/Imagenes/Producto_{producto.Id}{ext}"));
                    }
                }

                if (negProducto.updateProducto(producto))
                {
                    lblMensaje.Text = "El producto se actualizo correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No se pudo actualizar el producto.";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeModificar", "msjeModificar()", true);
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