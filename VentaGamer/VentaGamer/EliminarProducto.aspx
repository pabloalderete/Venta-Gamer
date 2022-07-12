<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EliminarProducto.aspx.cs" Inherits="VentaGamer.EliminarProducto" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Eliminar Producto</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <div class="container my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Eliminar Producto</h3>
            </div>
            <div class="col-sm-6 mb-2">
                <label for="txtNombreProducto" class="col-form-label">Id Producto</label>
                <asp:TextBox ID="txtEliminarProducto"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 my-3">
                <asp:Button ID="btnEliminarProducto" CssClass="btn btn-primary" runat="server" Text="Eliminar Producto" OnClick="btnEliminarProducto_Click" />
            </div>
        </div>
    </div>
</asp:Content>
