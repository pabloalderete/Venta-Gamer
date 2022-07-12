<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="VentaGamer.AgregarCategoria" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Agregar Categoria</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Agregar Categoria</h3>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtNombreCategoria" class="col-form-label">Nombre</label>
                <asp:TextBox ID="txtNombreCategoria" ClientIDMode="Static" CssClass="form-control" runat="server" CustomSize="15"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtNombreCategoria" runat="server" Display="Dynamic" Text="El nombre no puede estar vacio." ControlToValidate="txtNombreCategoria" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtNombreCategoria" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtNombreCategoria" Text="Maximo 15 caracteres." OnServerValidate="cuvTxtNombreCategoria_ServerValidate" CustomControlName="txtNombreCategoria" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtDescripcionCategoria" class="col-form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcionCategoria" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtDescripcionCategoria" Display="Dynamic" runat="server" Text="La descripcion no puede estar vacia." ControlToValidate="txtDescripcionCategoria" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    <asp:CustomValidator ID="cuvTxtDescripcionCategoria" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtDescripcionCategoria" Text="Maximo 100 caracteres." OnServerValidate="cuvTxtDescripcionCategoria_ServerValidate" CustomControlName="txtDescripcionCategoria" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="fuImagenCategoria" class="col-form-label">Imagen</label>
                <asp:FileUpload ID="fuImagenCategoria" CssClass="form-control" runat="server" />
                <small>
                    <asp:RequiredFieldValidator ID="rfvFuImagenCategoria" runat="server" Text="La imagen no puede estar vacia." ControlToValidate="fuImagenCategoria" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlEstadoCategoria" class="col-form-label">Estado</label>
                <asp:DropDownList ID="ddlEstadoCategoria" CssClass="form-select" runat="server">
                    <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    <asp:ListItem Value="true">Activo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-12 my-3">
                <asp:LinkButton ID="btnCancelarAgregado" CssClass="btn btn-secondary me-2" PostBackUrl="~/Inicio.aspx" runat="server">Cancelar</asp:LinkButton>
                <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-primary" runat="server" Text="Agregar Categoria" OnClick="btnAgregarCategoria_Click" ValidationGroup="1" />
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

        function cuvCharLength_ClientValidate(source, arguments) {
            const control = source.getAttribute("CustomControlName")
            const element = document.getElementById(control)
            const size = Number(element.getAttribute("CustomSize"))

            if (element.value.length > size) {
                arguments.IsValid = true
            }
            else {
                arguments.IsValid = false
            }
        }
    </script>
</asp:Content>
