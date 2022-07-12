<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SeleccionarModificarProducto.aspx.cs" Inherits="VentaGamer.SeleccionarModificarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
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
                        <div class="card card-modificar-producto text-center">
                            <div class="img-producto-container">
                                <asp:Image ID="imgProducto" CssClass="img-producto" ImageUrl='<%# Eval("Imagen_Pr") %>' runat="server" />
                            </div>
                            <div class="card-body d-flex flex-column mt-auto">
                                <h6 class="card-title fw-bold"><%# Eval("Nombre_Pr") %></h6>
                                <p class="card-text"><%# Eval("Descripcion_Pr") %></p>
                                <p class="card-text"><%# Eval("Estado_Pr").ToString() == "True" ? "<span class='text-success fw-bold'>Activo</span>" : "<span class='text-danger fw-bold'>Inactivo</span>" %></p>
                                <p class="d-flex card-text text-primary fw-bold justify-content-center">$<%# Eval("Precio_Pr") %></p>
                                <asp:LinkButton ID="lnkModificarProducto" CssClass="btn btn-primary mt-auto mb-2" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/ModificarProducto.aspx?IdProducto=") + Eval("IdProducto_Pr" )%>'>Modificar</asp:LinkButton>
                                <asp:LinkButton ID="lnkEliminarProducto" CssClass="btn btn-danger mb-2" runat="server" Text="Eliminar" OnClientClick='<%# Eval("IdProducto_Pr", "return ConfirmarEliminar({0})") %>'></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- Hidden Field --%>
            <asp:HiddenField ID="idProducto" runat="server" ClientIDMode="Static" />

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
    <div class="modal fade" id="eliminarProductoModal" tabindex="-1" aria-labelledby="eliminarProductoModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="eliminarProductoModalLabel">Eliminar Producto</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ¿Esta seguro que desea eliminar el producto?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:LinkButton ID="lnkConfirmarEliminar" OnClick="lnkConfirmarEliminar_Click" CssClass="btn btn-danger" runat="server">Confirmar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function ConfirmarEliminar(idProducto) {
            const element = document.getElementById("<%= idProducto.ClientID %>");
            const myModal = new bootstrap.Modal(document.getElementById("eliminarProductoModal"), {});

            element.value = idProducto;
            myModal.show();

            return false;
        }

    </script>
</asp:Content>


