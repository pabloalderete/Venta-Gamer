<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregadoACarrito.aspx.cs" Inherits="VentaGamer.AgregadoACarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Agregado a Carrito</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container carrito my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Producto agregado al Carrito de Compras</h3>
            </div>
            <div id="vaciarCarrito" visible="false" class="d-flex col-12 col-md-9 my-4 justify-content-end" runat="server">
                <asp:LinkButton ID="lnkVaciarCarrito" CssClass="btn btn-primary" Text="Vaciar Carrito" OnClientClick="return mensajeConfirmacion()" runat="server" />
            </div>
            <asp:Label ID="lblRptCarritoVacio" CssClass="text-center my-2" runat="server" Visible="false" Text="No hay productos en el carrito" />
            <%-- Repeater --%>
            <asp:Repeater ID="rptAgregadoACarrito" runat="server">
                <ItemTemplate>
                    <div class="card col-12 col-md-9 mb-3 p-3">
                        <div class="row g-0">
                            <div class="col-12 col-md-3">
                                <asp:Image ID="imgProducto" CssClass="img-fluid rounded-start" ImageUrl='<%# Eval("Imagen_Pr") %>' runat="server" />
                            </div>
                            <div class="col-6 col-md-6 px-md-3 py-md-3">
                                <div class="card-body">
                                    <h5 class="card-title fw-bold"><%# Eval("Nombre_Pr") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion_Pr") %></p>
                                    <p class="card-text fw-bold text-primary">$<%# Eval("Precio_Pr") %></p>
                                    <p class="card-text"><small class="text-muted">Agregado hace 3 minutos</small></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- End Repeater --%>
            <div class="d-flex col-12 col-md-9 justify-content-end my-2">
                <asp:LinkButton ID="lnkSeguirComprando" runat="server" CssClass="btn btn-primary me-2" PostBackUrl="~/Inicio.aspx">Seguir Comprando</asp:LinkButton>
                <asp:LinkButton ID="lnkVerCarrito" runat="server" CssClass="btn btn-secondary" PostBackUrl="~/Carrito.aspx">Ver Carrito</asp:LinkButton>
            </div>
        </div>
    </section>
</asp:Content>
