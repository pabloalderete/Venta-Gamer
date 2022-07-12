<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="HistorialDeVentas.aspx.cs" Inherits="VentaGamer.HistorialDeVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Historial de Ventas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container historial-ventas my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Historial de Ventas
                </h3>
            </div>
            <div class="d-flex col-12 col-md-9 justify-content-center my-2">
                <div class="row w-100">
                    <asp:Repeater ID="rptFacturas" OnItemDataBound="rptFacturas_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="card col-12 col-md-12 mb-3 p-3">
                                <div class="row g-0">
                                    <div class="col-12 col-md-8">
                                        <div class="card-body d-flex flex-column">
                                            <%--<h5 class="card-title fw-bold">Factura N° <span id="idFactura" runat="server"><%# Eval("IdFactura_Fa") %></span></h5>
                                            <span class="py-0">Usuario: <%# Eval("Nombre_Us") + " " + Eval("Apellido_Us") %></span>
                                            <sapn class="py-0">Direccion: <%# Eval("Direccion_Us") %></sapn>
                                            <span class="py-0">Fecha: <%# Eval("Fecha_Fa") %></span>
                                            <span class="py-0">Tipo de Pago: <%# Eval("Descripcion_TP") %></span>
                                            <span class="py-0">Estado: <%# Eval("Estado_Fa") %></span>--%>
                                            <h5 class="card-title fw-bold text-center">Factura N° <span id="idFactura" runat="server"><%# Eval("IdFactura_Fa") %></span></h5>
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th scope="col">Usuario</th>
                                                        <th scope="col">Direccion</th>
                                                        <th scope="col">Tipo de Pago</th>
                                                        <th scope="col">Estado</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td scope="row"><%# Eval("Nombre_Us") + " " + Eval("Apellido_Us") %></td>
                                                        <td><%# Eval("Direccion_Us") %></td>
                                                        <td><%# Eval("Descripcion_TP") %></td>
                                                        <td><%# Convert.ToInt32(Eval("Estado_Fa")) == 1 ? "Paga" : "Pendiente" %></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="d-flex col-12 col-md-3 offset-md-1 flex-column px-md-1 text-center justify-content-md-center">
                                        <div class="precio-producto fw-normal fa-2x">
                                            <span class="py-0">$<%# Eval("MontoFinal_Fa") %></span>
                                        </div>
                                        <button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapse<%# Container.ItemIndex %>" aria-expanded="false" aria-controls="collapseExample">
                                            Ver Detalle
                                        </button>
                                    </div>
                                </div>

                                <asp:Repeater ID="rptDetalleFactura" runat="server">
                                    <HeaderTemplate>
                                        <div class="col-12 collapse" id="collapse<%# ((Container.NamingContainer as Repeater).NamingContainer as RepeaterItem).ItemIndex %>">
                                            <div class="card card-body">
                                                <h5 class="card-title fw-bold text-center">Detalle</h5>
                                                <table class="table">
                                                    <thead>
                                                        <tr>
                                                            <th scope="col">#</th>
                                                            <th scope="col">Producto</th>
                                                            <%--<th scope="col">Factura</th>--%>
                                                            <th scope="col">Cantidad</th>
                                                            <th scope="col">Precio</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%# Eval("Nombre_Pr") %></td>
                                            <%--<td><%# Eval("IdFactura_DF") %></td>--%>
                                            <td><%# Eval("Cantidad_DF") %></td>
                                            <td>$<%# Eval("PrecioUnitario_DF") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="row">
            <nav class="d-flex justify-content-center align-items-center" aria-label="Page navigation">
                <ul class="pagination">
                    <li id="liPrevious" runat="server" class="page-item">
                        <asp:LinkButton ID="lnkPrevious" OnClick="lnkPrevious_Click" CssClass="page-link" runat="server">Anterior</asp:LinkButton>
                    </li>
                    <asp:Repeater ID="rptPagination" runat="server" OnItemCommand="rptPagination_ItemCommand">
                        <ItemTemplate>
                            <li id="liPageNumber" clientidmode="Predictable" class='<%# Container.ItemIndex == Convert.ToInt32(ViewState["PageNumber"]) ? "page-item active" : "page-item" %>' runat="server">
                                <asp:LinkButton ID="lnkPage" CssClass="page-link" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server">
                                        <%# Convert.ToInt32(Container.DataItem) + 1 %>  
                                </asp:LinkButton>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li id="liNext" runat="server" class="page-item">
                        <asp:LinkButton ID="lnkNext" OnClick="lnkNext_Click" CssClass="page-link" runat="server">Siguiente</asp:LinkButton>
                    </li>
                </ul>
            </nav>
        </div>
    </section>
    <%--<asp:HiddenField ID="idFactura" runat="server" ClientIDMode="Static" />

    <div class="modal fade" id="verDetalleModal" tabindex="-1" aria-labelledby="verDetalleModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="verDetalleModalLabel">DETALLE DE LA FACTURA N°
                        <asp:Label ID="lblNumeroFactura" runat="server" Text=""></asp:Label></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ...
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="lblMensajito" runat="server" Text=""></asp:Label>

    <script type="text/javascript">

        function VerDetalle(idFactura) {
            const element = document.getElementById("<%= idFactura.ClientID %>");
            const myModal = new bootstrap.Modal(document.getElementById("verDetalleModal"), {});

            element.value = idFactura;
            myModal.show();

            return false;
        }

    </script>--%>
</asp:Content>
