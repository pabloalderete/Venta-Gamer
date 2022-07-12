<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="VentaGamer.AgregarProducto" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Agregar Producto</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Agregar Producto</h3>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlCategoria" class="col-form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" aria-label="Default select example" runat="server"></asp:DropDownList>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlMarca" class="col-form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" aria-label="Default select example" runat="server"></asp:DropDownList>
            </div>

            <div class="col-sm-6 mb-2">
                <label for="txtNombreProducto" class="col-form-label">Nombre</label>
                <asp:TextBox ID="txtNombreProducto" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtNombreProducto" Display="Dynamic" runat="server" Text="El nombre no puede estar vacio." ControlToValidate="txtNombreProducto" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtNombreProducto" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtNombreProducto" Text="Maximo 100 caracteres." OnServerValidate="cuvTxtNombreProducto_ServerValidate" CustomControlName="txtDescripcionCategoria" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtDescripcionProducto" class="col-form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcionProducto" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtDescripcionProducto" Display="Dynamic" runat="server" Text="La descripcion no puede estar vacia." ControlToValidate="txtDescripcionProducto" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtDescripcionProducto" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtDescripcionProducto" Text="Maximo 100 caracteres." OnServerValidate="cuvTxtDescripcionProducto_ServerValidate" CustomControlName="txtDescripcionCategoria" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtPrecioProducto" class="col-form-label">Precio</label>
                <div class="input-group">
                    <span class="input-group-text">$</span>
                    <asp:TextBox ID="txtPrecioProducto" CssClass="form-control" aria-label="Dollar amount (with dot and two decimal places)" runat="server"></asp:TextBox>
                </div>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtPrecioProducto" Display="Dynamic" runat="server" Text="El precio no puede estar vacio." ControlToValidate="txtPrecioProducto" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    <asp:CustomValidator ID="cuvTxtPrecioProducto" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPrecioProducto" Text="Maximo 6 caracteres." OnServerValidate="cuvTxtPrecioProducto_ServerValidate" CustomControlName="txtPrecioProducto" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtStockProducto" class="col-form-label">Stock</label>
                <asp:TextBox ID="txtStockProducto" CssClass="form-control" aria-label="Dollar amount (with dot and two decimal places)" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtStockProducto" Display="Dynamic" runat="server" Text="El stock no puede estar vacio." ControlToValidate="txtStockProducto" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtStockProducto" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtStockProducto" Text="Maximo 4 caracteres." OnServerValidate="cuvTxtStockProducto_ServerValidate" CustomControlName="txtStockProducto" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="fuImagenProducto" class="col-form-label">Imagen</label>
                <asp:FileUpload ID="fuImagenProducto" Display="Dynamic" CssClass="form-control" runat="server" />
                <small>
                    <asp:RequiredFieldValidator ID="rfvFuImagenProducto" runat="server" Text="La imagen no puede estar vacia." ControlToValidate="fuImagenProducto" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlEstadoProducto" class="col-form-label">Estado</label>
                <asp:DropDownList ID="ddlEstadoProducto" CssClass="form-select" runat="server">
                    <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    <asp:ListItem Value="true">Activo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-12 my-3">
                <asp:LinkButton ID="btnCancelarAgregado" CssClass="btn btn-secondary me-2" PostBackUrl="~/Inicio.aspx" runat="server">Cancelar</asp:LinkButton>
                <asp:Button ID="btnAgregarProducto" CssClass="btn btn-primary" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" ValidationGroup="1" />
            </div>
        </div>
    </div>
    <div class="modal fade" id="msjeAgregar" tabindex="-1" aria-labelledby="msjeAgregar" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="msjeAgregarLabel">Atención!</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lnkVolver" OnClick="lnkVolver_Click" CssClass="btn btn-primary" runat="server">Volver</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script>
        function msjeAgregar() {
            const modal = new bootstrap.Modal(document.getElementById("msjeAgregar"));

            modal.show();

            return false;
        }
    </script>
</asp:Content>
