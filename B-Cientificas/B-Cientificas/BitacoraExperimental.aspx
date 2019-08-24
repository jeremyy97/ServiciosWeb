<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="BitacoraExperimental.aspx.cs" Inherits="B_Cientificas.BitacoraExperimental" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel class="card" ID="Panel1" runat="server">
            <fieldset>
                <legend>Bitacora Experimental</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de experimentos</label>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Proyecto:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlProyectos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlProyectos_SelectedIndexChanged">
                                        <asp:ListItem Value="-8">Seleccione un proyecto</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Codigo del proyecto:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCodProyecto" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCodProyecto" runat="server" ControlToValidate="txtCodProyecto" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Codigo del experimento:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCodExperimento" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>Datos del responsable</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">
                                Nombre del responsable:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlResponsables" runat="server" class="form-control">
                                        <asp:ListItem Value="-8">Seleccione un responsable</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="rama">
                                Firma del responsable</label> </td>
                            <td>
                                <asp:Image ID="imgFirmaResponsable" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Nombre del experimento:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Duración del proyecto:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Calendar ID="fechaInicio" runat="server"></asp:Calendar>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Calendar ID="fechaFinal" runat="server"></asp:Calendar>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Muestra 1:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Muestra 2:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra2" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Muestra 3:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra3" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Muestra 4:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra4" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Muestra 5:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra5" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Objetivo GENERAL:
                                </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:TextBox ID="txtObjGen" runat="server" Height="198px" TextMode="MultiLine" Width="403px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Objetivos Específicos:
                                </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:TextBox ID="txtObjEsp" runat="server" Height="198px" TextMode="MultiLine" Width="403px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Equipo utilizado:
                                </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:TextBox ID="txtEquipoUsado" runat="server" Height="198px" TextMode="MultiLine" Width="403px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Procedimientos:
                                </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:TextBox ID="txtProcedimientos" runat="server" Height="198px" TextMode="MultiLine" Width="403px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Firma del testigo:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlFirmaTestigos" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="-8">Seleccione Firma</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Nombre del testigo:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlUsuariosTestigos" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="-8">Seleccione Testigo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Firma del testigo:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Image ID="imgFirma" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar Experimento" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" OnClick="btnLimpiar_Click" Text="Limpiar" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    <div class="card">
                        <div class="form-group">
                            <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" Text="Actualizar Tabla" />
                        </div>
                        <asp:GridView ID="gvExperimentos" runat="server" CellPadding="4" class="table" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                </div>
                <br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
            </fieldset>
        </asp:Panel>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>
</asp:Content>
