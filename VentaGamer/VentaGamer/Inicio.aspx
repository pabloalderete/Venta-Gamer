<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VentaGamer.Inicio" %>

<asp:Content ID="Titulo" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Inicio</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <section class="content container-fluid my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Listado de Productos</h3>
            </div>
        </div>
        <div class="row ">
            <asp:Repeater ID="rptProductos" runat="server">
                <ItemTemplate>
                    <div class="col-sm-2 mb-4">
                        <div class="card card-producto text-center">
                            <div class="img-producto-container">
                                <asp:Image ID="imgProducto" CssClass="img-producto" ImageUrl='<%# Eval("Imagen_Pr") %>' runat="server" />
                            </div>
                            <div class="card-body d-flex flex-column mt-auto">
                                <h6 class="card-title fw-bold"><%# Eval("Nombre_Pr") %></h6>
                                <p class="card-text"><%# Eval("Descripcion_Pr") %></p>
                                <p class="d-flex card-text text-primary fw-bold justify-content-center mt-auto">$<%# Eval("Precio_Pr") %></p>
                                <asp:LinkButton ID="lnkAgregarCarrito" CssClass="btn btn-primary mt-auto mb-2" OnClientClick='<%# Eval("IdProducto_Pr", "return AgregarProducto({0})") %>' OnClick="lnkAgregarCarrito_Click" runat="server">Agregar al Carrito</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="idProducto" runat="server" ClientIDMode="Static" />
        </div>
        <div class="row">
            <nav class="d-flex justify-content-center align-items-center" aria-label="Page navigation">
                <ul class="pagination">
                    <li ID="liPrevious" runat="server" class="page-item">
                        <asp:LinkButton ID="lnkPrevious" OnClick="lnkPrevious_Click" CssClass="page-link" runat="server">Anterior</asp:LinkButton>
                    </li>
                        <asp:Repeater ID="rptPagination" runat="server" OnItemCommand="rptPagination_ItemCommand">
                            <ItemTemplate>
                                <li ID="liPageNumber" ClientIDMode="Predictable" class='<%# Container.ItemIndex == Convert.ToInt32(ViewState["PageNumber"]) ? "page-item active" : "page-item" %>' runat="server">
                                    <asp:LinkButton ID="lnkPage" CssClass="page-link" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server">
                                        <%# Convert.ToInt32(Container.DataItem) + 1 %>  
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    <li ID="liNext" runat="server" class="page-item">
                        <asp:LinkButton ID="lnkNext" OnClick="lnkNext_Click" CssClass="page-link" runat="server">Siguiente</asp:LinkButton>
                    </li>
                </ul>
            </nav>
        </div>
    </section>

    <%-- Modal --%>
    <div class="modal fade" id="msjeProductoEnCarrito" tabindex="-1" aria-labelledby="msjeProductoEnCarrito" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="msjeProductoEnCarritoLabel">Oops</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    El producto ya se encuentra en el carrito.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Volver</button>
                    <asp:LinkButton ID="lnkConfirmarVaciar" CssClass="btn btn-primary" runat="server">Confirmar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="msjeInicioSesion" tabindex="-1" aria-labelledby="msjeInicioSesion" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="msjeInicioSesionLabel">Atención!</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Debe iniciar sesión para agregar productos al carrito.
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server">Volver</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>

    <script type="text/javascript">

        function AgregarProducto(idProducto) {
            const element = document.getElementById("<%= idProducto.ClientID %>");

            element.value = idProducto;

            return true;
        }

        function msjeProductoEnCarrito() {
            const modal = new bootstrap.Modal(document.getElementById("msjeProductoEnCarrito"));

            modal.show();

            return false;
        }

        function msjeInicioSesion() {
            const modal = new bootstrap.Modal(document.getElementById("msjeInicioSesion"));

            modal.show();

            console.log("msjeInicioSesion()")

            return false;
        }

    </script>
</asp:Content>
