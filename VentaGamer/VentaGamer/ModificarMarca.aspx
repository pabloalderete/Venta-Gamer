<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarMarca.aspx.cs" Inherits="VentaGamer.ModificarMarca" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Modificar Marca</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Modificar Marca</h3>
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
                <div class="row">
                    <label for="imgActualProducto" class="col-form-label">Imagen actual</label>
                    <div class="col-sm-2 mb-2">
                        <asp:Image ID="imgActualProducto" CssClass="img-thumbnail" Height="100px" Width="100px" runat="server" />
                    </div>
                    <div class="col mb-2">
                        <%--<label for="fuImagenProducto" class="col-form-label">Imagen</label>--%>
                        <asp:FileUpload ID="fuImagenMarca" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="ddlEstadoMarca" class="col-form-label">Estado</label>
                <asp:DropDownList ID="ddlEstadoMarca" CssClass="form-select" runat="server">
                    <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    <asp:ListItem Value="true">Activo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-12 my-3">
                <asp:LinkButton ID="btnCancelarModificacion" CssClass="btn btn-secondary me-2" PostBackUrl="~/SeleccionarModificarMarca.aspx" runat="server">Cancelar</asp:LinkButton>
                <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-primary" runat="server" Text="Modificar Categoria" OnClick="btnModificarMarca_Click" ValidationGroup="1" />
            </div>
        </div>
    </div>
</asp:Content>
