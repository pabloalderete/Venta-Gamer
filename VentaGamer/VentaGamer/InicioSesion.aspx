<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="VentaGamer.InicioSesion" %>

<asp:Content ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Inicio Sesión</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="Contenido" runat="server">
    <style>
        /*.form-signin {
            max-width: 330px;
            padding: 15px;
            height: 600px;
        }*/

        .form-signin .form-floating:focus-within {
            z-index: 2;
        }

        .form-signin input[type="email"] {
            margin-bottom: -1px;
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
        }

        .form-signin input[type="password"] {
            margin-bottom: 10px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }
    </style>
    <section class="inicio-sesion container form-signin my-5">
        <div class="row justify-content-center gx-0">
            <div class="col-12 col-md-4 card">
                <div class="row gx-0">
                    <div class="col-md-12 card-body text-center">
                        <h3 class="fw-bold text-center my-5">Inicio Sesión</h3>
                        <div class="col-12 col-md-8 form-floating mx-auto">
                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                            <label for="txtEmail">Email</label>
                        </div>
                        <div class="col-12 col-md-8 form-floating mx-auto">
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                            <label for="txtPassword">Contraseña</label>
                        </div>
                        <div class="text-center my-5">
                            <asp:Button ID="btnInicioSesion" CssClass="btn btn-primary my-2" runat="server" Text="Iniciar Sesión" OnClick="btnInicioSesion_Click" />
                        </div>
                    </div>
                    <div class="col-12 card-footer text-muted">
                        <div class="mb-2 ms-1 text-center mt-1">
                            <asp:HyperLink ID="lnkCrearCuenta" runat="server" NavigateUrl="~/Registro.aspx">Registrarse</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
