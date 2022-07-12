<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="VentaGamer.AgregarMarca" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Agregar Marca</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Agregar Marca</h3>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtNombreMarca" class="col-form-label">Nombre</label>
                <asp:TextBox ID="txtNombreMarca" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtNombreMarca" Display="Dynamic" runat="server" Text="El nombre no puede estar vacio." ControlToValidate="txtNombreMarca" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtNombreMarca" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtNombreMarca" Text="Maximo 20 caracteres." OnServerValidate="cuvTxtNombreMarca_ServerValidate" CustomControlName="txtNombreMarca" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtEsloganMarca" class="col-form-label">Eslogan</label>
                <asp:TextBox ID="txtEsloganMarca" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtEsloganMarca" Display="Dynamic" runat="server" Text="El eslogan no puede estar vacio." ControlToValidate="txtEsloganMarca" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="cuvTxtEsloganMarca" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEsloganMarca" Text="Maximo 100 caracteres." OnServerValidate="cuvTxtEsloganMarca_ServerValidate" CustomControlName="txtEsloganMarca" ValidationGroup="1"></asp:CustomValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="fuImagenMarca" class="col-form-label">Imagen</label>
                <asp:FileUpload ID="fuImagenMarca" CssClass="form-control" runat="server" />
                <small>
                    <asp:RequiredFieldValidator ID="rfvFuImagenMarca" runat="server" Text="La imagen no puede estar vacia." ControlToValidate="fuImagenMarca" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                </small>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlEstadoMarca" class="col-form-label">Estado</label>
                <asp:DropDownList ID="ddlEstadoMarca" CssClass="form-select" runat="server">
                    <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    <asp:ListItem Value="true">Activo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-12 my-3">
                <asp:LinkButton ID="btnCancelarAgregado" CssClass="btn btn-secondary me-2" PostBackUrl="~/Inicio.aspx" runat="server">Cancelar</asp:LinkButton>
                <asp:Button ID="btnAgregarMarca" CssClass="btn btn-primary" runat="server" Text="Agregar Marca" OnClick="btnAgregarMarca_Click" ValidationGroup="1" />
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
