<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarCategoria.aspx.cs" Inherits="VentaGamer.ModificarCategoria" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Modificar Categoria</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Agregar Categoria</h3>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtNombreCategoria" class="col-form-label">Nombre</label>
                <asp:TextBox ID="txtNombreCategoria" CssClass="form-control" runat="server"></asp:TextBox>
                <small>
                    <asp:RequiredFieldValidator ID="rfvTxtNombreCategoria" Display="Dynamic" runat="server" Text="El nombre no puede estar vacio." ControlToValidate="txtNombreCategoria" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

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
                <div class="row">
                    <label for="imgActualProducto" class="col-form-label">Imagen actual</label>
                    <div class="col-sm-2 mb-2">
                        <asp:Image ID="imgActualProducto" CssClass="img-thumbnail" Height="100px" Width="100px" runat="server" />
                    </div>
                    <div class="col mb-2">
                        <%--<label for="fuImagenProducto" class="col-form-label">Imagen</label>--%>
                        <asp:FileUpload ID="fuImagenCategoria" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlEstadoCategoria" class="col-form-label">Estado</label>
                <asp:DropDownList ID="ddlEstadoCategoria" CssClass="form-select" runat="server">
                    <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    <asp:ListItem Value="true">Activo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-12 my-3">
                <asp:LinkButton ID="btnCancelarModificacion" CssClass="btn btn-secondary me-2" PostBackUrl="~/SeleccionarModificarCategoria.aspx" runat="server">Cancelar</asp:LinkButton>
                <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-primary" runat="server" Text="Modificar Categoria" OnClick="btnModificarCategoria_Click" ValidationGroup="1" />
            </div>
        </div>
    </div>
</asp:Content>
