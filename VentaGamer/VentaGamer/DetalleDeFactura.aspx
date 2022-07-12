<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="DetalleDeFactura.aspx.cs" Inherits="VentaGamer.DetalleDeFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Detalle de Factura</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container carrito my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">
                    <asp:Label ID="lblNumeroFactura" Text="" runat="server" />
                </h3>
            </div>
            <div class="d-flex col-12 col-md-9 justify-content-center my-2">

                <asp:Repeater ID="rptDetalleFactura" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Producto</th>
                                    <th scope="col">Cantidad</th>
                                    <th scope="col">Precio</th>
                                    <th scope="col">Total</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th><%# Convert.ToInt32(Container.ItemIndex) + 1 %></th>
                            <td><%# Eval("Nombre_Pr") %></td>
                            <td><%# Eval("Cantidad_DF") %></td>
                            <td>$<%# Eval("PrecioUnitario_DF") %></td>
                            <td>$<%# Convert.ToDecimal(Eval("PrecioUnitario_DF")) * Convert.ToDecimal(Eval("Cantidad_DF")) %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="d-flex col-12 col-md-9 justify-content-center my-5">
                <asp:LinkButton ID="lnkFinalizarCompra" runat="server" CssClass="btn btn-primary" OnClick="lnkFinalizarCompra_Click">Volver al Inicio</asp:LinkButton>
            </div>
        </div>
    </section>
</asp:Content>
