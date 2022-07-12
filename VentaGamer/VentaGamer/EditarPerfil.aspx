<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="VentaGamer.EditarPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    <title>VENTA GAMER | Editar Perfil</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <section class="container my-3">
        <div class="row justify-content-center">
            <div class="col-12">
                <h3 class="mb-3 fw-bold text-center">Editar Perfil</h3>
            </div>
            <div class="col-9">
                <div class="row g-3">
                    <div class="col-sm-6">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" TextMode="SingleLine" CssClass="form-control" runat="server" ValidationGroup="1"></asp:TextBox>
                        <small>
                            <asp:RequiredFieldValidator ID="rfvTxtNombre" runat="server" ForeColor="Red" Text="El nombre no puede estar vacio." ValidationGroup="1" ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>
                        </small>
                    </div>

                    <div class="col-sm-6">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" TextMode="SingleLine" CssClass="form-control" runat="server" ValidationGroup="1"></asp:TextBox>
                        <small>
                            <asp:RequiredFieldValidator ID="rfvTxtApellido" runat="server" ForeColor="Red" Text="El apellido no puede estar vacio." ValidationGroup="1" ControlToValidate="txtApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                        </small>
                    </div>

                    <div class="col-12">
                        <label for="txtDni" class="form-label">DNI</label>
                        <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-12">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-12">
                        <label for="txtContrasena" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtContrasena" ClientIDMode="Static" TextMode="Password" CssClass="form-control" runat="server" ValidationGroup="1" CustomSize="6"></asp:TextBox>
                        <small>
                            <asp:RequiredFieldValidator ID="rfvTxtContrasena" runat="server" ForeColor="Red" Text="La contraseña no puede estar vacia." ValidationGroup="1" ControlToValidate="txtContrasena" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cuvTxtContrasena" runat="server" ForeColor="Red" ControlToValidate="txtContrasena" Text="La contraseña debe tener al menos 6 caracteres." ClientValidationFunction="cuvCharLength_ClientValidate" OnServerValidate="cuvTxtContrasena_ServerValidate" CustomControlName="txtContrasena" ValidationGroup="1" Display="Dynamic"></asp:CustomValidator>
                        </small>
                    </div>

                    <div class="col-12">
                        <label for="txtConfirmarContrasena" class="form-label">Confirmar contraseña</label>
                        <asp:TextBox ID="txtConfirmarContrasena" CssClass="form-control" TextMode="Password" runat="server" ValidationGroup="1"></asp:TextBox>
                        <small>
                            <asp:CompareValidator ID="cvTxtConfirmarContrasena" runat="server" ValidationGroup="1" ControlToCompare="txtContrasena" ControlToValidate="txtConfirmarContrasena" ForeColor="Red" Text="Las contraseñas no coinciden." Display="Dynamic"></asp:CompareValidator>
                        </small>
                    </div>

                    <div class="col-12">
                        <label for="txtDireccion" class="form-label">Direccion</label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" ValidationGroup="1"></asp:TextBox>
                        <small>
                            <asp:RequiredFieldValidator ID="rfvTxtDireccion" runat="server" ForeColor="Red" Text="La direccion no puede estar vacia." ValidationGroup="1" ControlToValidate="txtDireccion" Display="Dynamic"></asp:RequiredFieldValidator>
                        </small>
                    </div>

                    <div class="col-12">
                        <label for="txtTelefono" class="form-label">Telefono</label>
                        <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" ValidationGroup="1"></asp:TextBox>
                        <small>
                            <asp:RequiredFieldValidator ID="rfvTxtTelefono" runat="server" ForeColor="Red" Text="El telefono no puede estar vacio." ValidationGroup="1" ControlToValidate="txtTelefono" Display="Dynamic"></asp:RequiredFieldValidator>
                        </small>
                    </div>

                    <div class="col-12">
                        <label for="imgPerfil" class="form-label">Imagen actual</label>
                        <div>
                            <asp:Image ID="imgPerfil" CssClass="img-thumbnail" Height="100px" Width="100px" runat="server" />
                        </div>
                    </div>

                    <div class="col-12">
                       <label for="fuImagenPerfil" class="form-label">Seleccionar nueva imagen</label>
                        <asp:FileUpload ID="fuImagenPerfil" CssClass="form-control" runat="server" />
                    </div>

                    <div class="col-md-6">
                        <label for="ddlProvincias" class="form-label">Provincia</label>
                        <asp:DropDownList ID="ddlProvincias" CssClass="form-select" runat="server" AutoPostBack="True" AppendDataBoundItems="True" ValidationGroup="1">
                            <asp:ListItem>-- Seleccionar Provincia --</asp:ListItem>
                        </asp:DropDownList>
                        <small>
                            <asp:CompareValidator ID="cvDdlProvincias" runat="server" ForeColor="Red" ValidationGroup="1" ControlToValidate="ddlProvincias" Text="Seleccione una provincia." ValueToCompare="-- Seleccionar Provincia --" Operator="NotEqual" Display="Dynamic"></asp:CompareValidator>
                        </small>
                    </div>

                    <div class="col-md-6">
                        <label for="ddlLocalidades" class="form-label">Localidad</label>
                        <asp:DropDownList ID="ddlLocalidades" CssClass="form-select" runat="server" ValidationGroup="1" Display="Dynamic"></asp:DropDownList>
                    </div>
                </div>

                <hr class="my-4">
                <asp:LinkButton ID="lnkEditarPerfil" CssClass="w-100 btn btn-primary btn-lg" ValidationGroup="1" OnClick="lnkEditarPerfil_Click" runat="server">Guardar Cambios</asp:LinkButton>
            </div>
        </div>
    </section>
    <%-- Modal --%>
    <div class="modal fade" id="mensajeAccion" tabindex="-1" aria-labelledby="vaciarCarritoModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="mensajeAccionLabel">
                        <asp:Label ID="lblMensajeAccionTitle" runat="server" Text=""></asp:Label>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMensajeAccion" runat="server" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="lnkAceptarRegistro" CssClass="btn btn-primary" OnClick="lnkAceptarRegistro_Click" runat="server">Aceptar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>

    <script language="javascript">
        function mostrarMensajeAccion() {
            const modal = new bootstrap.Modal(document.getElementById("mensajeAccion"), {});

            modal.show();

            return false;
        }

        function cuvCharLength_ClientValidate(source, arguments) {
            const control = source.getAttribute("CustomControlName")
            const element = document.getElementById(control)
            const size = Number(element.getAttribute("CustomSize"))

            console.log(typeof control, control, size)

            if (control === "txtDni" && element.value.length <= size) {
                arguments.IsValid = true
            }
            else if (control === "txtContrasena" && element.value.length >= size) {
                arguments.IsValid = true
            }
            else {
                arguments.IsValid = false
            }
        }
    </script>
</asp:Content>
