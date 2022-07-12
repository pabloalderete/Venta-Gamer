<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="VentaGamer.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Reportes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container reportes my-3">
        <div class="row justify-content-center">
            <div class="col-sm-12 text-center mt-2 mb-3">
                <h3 class="fw-bold">Reportes</h3>
            </div>

            <div class="col-12 col-md-4 card mb-3">
                <div class="card-body">
                    <div class="row g-3">
                        <h5 class="card-title fw-bold" style="min-height: 3rem;">Monto total de ingreso en la empresa</h5>
                        <div class="col mb-3">
                            <label for="txtFechaInicio" class="form-label">Fecha inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col mb-3">
                            <label for="txtFechaFin" class="form-label">Fecha fin:</label>
                            <asp:TextBox ID="txtFechaFin" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="d-flex col-12 justify-content-center">
                            <asp:Button ID="btnGenerarReporte" CssClass="btn btn-primary" Width="200px" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" />
                        </div>
                        <div ID="divMontoIngreso" runat="server" Visible="false" class="col mt-2">
                            <div class="card mx-auto px-3 my-2" style="width: fit-content">
                                <div class="card-body">
                                    <asp:Label ID="lblMontoIngreso" CssClass="fw-bold" Font-Size="32" Text="" runat="server" />
                                </div>
                            </div>
                            <p class="mt-2 text-center">en ventas</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="cold-12 col-md-4 ms-5 card mb-3">
                <div class="card-body">
                    <div class="row g-3">
                        <h5 class="card-title fw-bold" style="min-height: 3rem;">Cantidad total de productos vendidos en la empresa</h5>
                        <div class="col mb-3">
                            <label for="txtFechaInicio_TPV" class="form-label">Fecha inicio:</label>
                            <asp:TextBox ID="txtFechaInicio_TPV" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col mb-3">
                            <label for="txtFechaFin_TPV" class="form-label">Fecha fin:</label>
                            <asp:TextBox ID="txtFechaFin_TPV" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="d-flex col-12 justify-content-center">
                            <asp:Button ID="btnGenerarReporte_TPV" CssClass="btn btn-primary" Width="200px" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_TPV_Click" />
                        </div>
                        <div ID="divProductosVendidos" runat="server" Visible="false" class="col mt-2">
                            <div class="card mx-auto px-3 my-2" style="width: fit-content">
                                <div class="card-body">
                                    <asp:Label ID="lblProductosVendidos" CssClass="fw-bold" Font-Size="32" Text="" runat="server" />
                                </div>
                            </div>
                            <p class="mt-2 text-center">productos vendidos</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
