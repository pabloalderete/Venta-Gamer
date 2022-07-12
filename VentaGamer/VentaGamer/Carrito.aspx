<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Carrito.aspx.cs" Inherits="VentaGamer.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Carrito de Compras</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container carrito my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Carrito de Compras</h3>
            </div>
            <div id="vaciarCarrito" visible="false" class="d-flex col-12 col-md-9 my-4 justify-content-end" runat="server">
                <asp:LinkButton ID="lnkVaciarCarrito" CssClass="btn btn-primary" Text="Vaciar Carrito" OnClientClick="return mensajeConfirmacion()" runat="server" />
            </div>
            <asp:Label ID="lblRptCarritoVacio" CssClass="text-center my-2" runat="server" Visible="false" Text="No hay productos en el carrito" />
            <%-- Repeater --%>
            <asp:Repeater ID="rptCarrito" runat="server">
                <ItemTemplate>
                    <div class="card col-12 col-md-9 mb-3 p-3">
                        <div class="row g-0">
                            <div class="col-12 col-md-3">
                                <asp:Image ID="imgProducto" CssClass="img-fluid rounded-start" ImageUrl='<%# Eval("Imagen") %>' runat="server" />
                            </div>
                            <div class="col-6 col-md-4 px-md-3 py-md-3">
                                <div class="card-body">
                                    <h5 class="card-title fw-bold"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text fw-bold text-primary">
                                        $<asp:Label ID="rptPrecioItem" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        <asp:LinkButton ID="lnkQuitarProducto" CssClass="link-primary" OnClick="lnkQuitarProducto_Click" OnClientClick='<%# "return getIndex(" + Container.ItemIndex + ")" %>' runat="server">
                                            <span class="text-muted">
                                                <small>Quitar producto</small>
                                            </span>
                                        </asp:LinkButton>
                                    </p>
                                </div>
                            </div>
                            <div class="d-flex col-6 col-md-2 flex-column px-md-1 mt-3 py-md-3">
                                <div class="btn-group" role="group">
                                    <asp:LinkButton ID="btnRestarCantidad" runat="server" CssClass="btn bg-transparent text-primary" Style="border: 1px solid #ced4da; border-right: none;" OnClick="btnRestarCantidad_Click" OnClientClick='<%# $"return getIndex({Container.ItemIndex})" %>'>-</asp:LinkButton>
                                    <asp:TextBox ID="txtCantidadProducto" CssClass="form-control rounded-0 text-center txt-cantidad" Style="border-left: none; border-right: none;" placeholder="Cantidad" TextMode="Number" Text='<%# Eval("Cantidad") %>' runat="server" />
                                    <asp:LinkButton ID="btnSumarCantidad" runat="server" CssClass="btn bg-transparent text-primary" Style="border: 1px solid #ced4da; border-left: none;" OnClick="btnSumarCantidad_Click" OnClientClick='<%# $"return getIndex({Container.ItemIndex})" %>'>+</asp:LinkButton>
                                    <asp:Button ID="btnACtualizarCantidad" CssClass="btn-actualizar-cantidad" style="display: none;"  OnClientClick='<%# $"return setCantidad({Container.ItemIndex})" %>' OnClick="btnACtualizarCantidad_Click" runat="server" Text="" />
                                </div>
                            </div>
                            <div class="d-flex col-6 col-md-3 flex-column px-md-1 py-md-3 mt-3 align-items-sm-center">
                                <div class="precio-producto fw-normal fa-2x">
                                    $<asp:Label ID="lblPrecioProducto" runat="server" Text="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- End Repeater --%>
            <div class="d-flex col-12 col-md-9 justify-content-end my-2">
                <asp:Label ID="lblTotalCarrito" CssClass="fa-2x" runat="server" Text=""></asp:Label>
            </div>
            <div class="d-flex col-12 col-md-9 justify-content-end my-2">
                <asp:LinkButton ID="lnkSeguirComprando" runat="server" CssClass="btn btn-primary me-2" PostBackUrl="~/Inicio.aspx">Seguir Comprando</asp:LinkButton>
                <asp:LinkButton ID="lnkContinuarCompra" runat="server" CssClass="btn btn-secondary" PostBackUrl="~/SeleccionarEnvioTipoPago.aspx">Continuar Compra</asp:LinkButton>
            </div>

            <%-- For JavaScript Uses --%>
            <asp:HiddenField ID="rptItemIndex" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="rptItemCantidad" runat="server" ClientIDMode="Static" />
            <%-- /For JavaScript Uses --%>
        </div>
    </section>

    <%-- Modal --%>
    <div class="modal fade" id="vaciarCarritoModal" tabindex="-1" aria-labelledby="vaciarCarritoModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="vaciarCarritoModalLabel">Vaciar Carrito de Compras</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ¿Esta seguro que desea vaciar el Carrito de Compras?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:LinkButton ID="lnkConfirmarVaciar" OnClick="lnkConfirmarVaciar_Click" CssClass="btn btn-primary" runat="server">Confirmar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>

    <script>
        const inputs = document.querySelectorAll(".txt-cantidad");
        const buttons = document.querySelectorAll(".btn-actualizar-cantidad")

        function delay(fn, ms) {
            let timer = 0
            return function (...args) {
                clearTimeout(timer)
                timer = setTimeout(fn.bind(this, ...args), ms || 0)
            }
        }

        inputs.forEach((input, index) => {
            input.addEventListener("keyup", delay(function(e) {
                buttons[index].click()
            }, 1000))
        });


        function mensajeConfirmacion() {
            const myModal = new bootstrap.Modal(document.getElementById("vaciarCarritoModal", {}));
            myModal.show();

            return false;
        }

        function getIndex(index) {
            const element = document.getElementById("<%= rptItemIndex.ClientID %>")

            element.value = index;

            return true;
        }

        function setCantidad(index) {
            const elCantidad = document.getElementById("<%= rptItemCantidad.ClientID %>")
            const elIndex = document.getElementById("<%= rptItemIndex.ClientID %>")
            const cantidad = inputs[index].value;

            elCantidad.value = cantidad;
            elIndex.value = index;

            if (!cantidad) return false

            return true;
        }
    </script>
</asp:Content>
