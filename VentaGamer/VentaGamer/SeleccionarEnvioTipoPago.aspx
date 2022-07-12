<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SeleccionarEnvioTipoPago.aspx.cs" Inherits="VentaGamer.SeleccionarEnvioTipoPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Envio y Tipo de Pago</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container carrito my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center my-2">
                <h3 class="fw-bold">Envio y Tipo de Pago</h3>
            </div>
            <div class="col-sm-12 text-center mt-5">
                        <h3>Modalidad de envio</h3>
                    </div>
                    <div class="d-flex col-12 col-md-9 justify-content-center my-2">
                        <div class="form-check me-4">
                            <input id="chkSucursal" runat="server" class="form-check-input" type="radio" name="tipoEnvio">
                            <label class="form-check-label" for="chkSucursal">
                                Retiro por sucursal
                            </label>
                        </div>
                        <div class="form-check">
                            <input id="chkDomicilio" runat="server" class="form-check-input" type="radio" name="tipoEnvio">
                            <label class="form-check-label" for="chkDomicilio">
                                Envio a domicilio
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 text-center mt-5">
                        <h3>Tipo de pago</h3>
                    </div>
                    <div class="d-flex col-12 col-md-9 justify-content-center my-2">
                        <div class="form-check me-4">
                            <input id="chkContado" runat="server" class="form-check-input" type="radio" name="tipoPago">
                            <label class="form-check-label" for="chkContado">
                                Contado
                            </label>
                        </div>
                        <div class="form-check">
                            <input id="chkTarjeta" runat="server" class="form-check-input" type="radio" name="tipoPago">
                            <label class="form-check-label" for="chkTarjeta">
                                Tarjeta
                            </label>
                        </div>
                    </div>
            <div class="d-flex col-12 col-md-9 justify-content-center my-5">
                <asp:LinkButton ID="lnkSeguirComprando" runat="server" CssClass="btn btn-secondary me-2" PostBackUrl="~/Carrito.aspx">Volver al Carrito</asp:LinkButton>
                <asp:LinkButton ID="lnkFinalizarCompra" runat="server" CssClass="btn btn-primary" OnClick="lnkFinalizarCompra_Click">Finalizar Compra</asp:LinkButton>
            </div>
        </div>
    </section>
</asp:Content>
