<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SeleccionarModificarCategoria.aspx.cs" Inherits="VentaGamer.SeleccionarModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Seleccionar Categoria a Modificar</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="content container-fluid my-3">
        <div class="row">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Listado de Categorias</h3>
            </div>
        </div>
        <div class="row ">
            <asp:Repeater ID="rptCategorias" runat="server">
                <ItemTemplate>
                    <div class="col-sm-2 mb-4">
                        <div class="card card-categoria text-center">
                            <div class="img-producto-container">
                                <asp:Image ID="imgProducto" CssClass="img-producto" ImageUrl='<%# Eval("Imagen_Ca") %>' runat="server" />
                            </div>
                            <div class="card-body d-flex flex-column mt-auto">
                                <h6 class="card-title fw-bold"><%# Eval("Nombre_Ca") %></h6>
                                <p class="card-text"><%# Eval("Descripcion_Ca") %></p>
                                <p class="card-text"><%# Eval("Estado_Ca").ToString() == "True" ? "<span class='text-success fw-bold'>Activo</span>" : "<span class='text-danger fw-bold'>Inactivo</span>" %></p>
                                <asp:LinkButton ID="lnkModificarCategoria" CssClass="btn btn-primary mt-auto mb-2" runat="server" PostBackUrl='<%# Page.ResolveUrl("~/ModificarCategoria.aspx?IdCategoria=") + Eval("IdCategoria_Ca")%>'>Modificar</asp:LinkButton>
                                <asp:LinkButton ID="lnkEliminarCategoria" CssClass="btn btn-danger mb-2" runat="server" Text="Eliminar" OnClientClick='<%# Eval("IdCategoria_Ca", "return ConfirmarEliminar({0})") %>'></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- Hidden Field --%>
            <asp:HiddenField ID="hiddenIdCategoria" runat="server" ClientIDMode="Static" />

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
    <div class="modal fade" id="eliminarCategoriaModal" tabindex="-1" aria-labelledby="eliminarCategoriaModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="eliminarCategoriaModalLabel">Eliminar Categoria</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ¿Esta seguro que desea eliminar la Categoria?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:LinkButton ID="lnkConfirmarEliminar" OnClick="lnkConfirmarEliminar_Click" CssClass="btn btn-danger" runat="server">Confirmar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function ConfirmarEliminar(idCategoria) {
            const element = document.getElementById("<%= hiddenIdCategoria.ClientID %>");
            const myModal = new bootstrap.Modal(document.getElementById("eliminarCategoriaModal"), {});

            element.value = idCategoria;
            myModal.show();

            return false;
        }

    </script>
</asp:Content>


