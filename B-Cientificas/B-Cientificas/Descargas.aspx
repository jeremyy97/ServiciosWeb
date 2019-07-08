<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Descargas.aspx.cs" Inherits="B_Cientificas.Descargas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="">
            <fieldset>
                <legend>Descargas</legend>
            </fieldset>
        </form>
        <form class="card">
            <fieldset>
                <hr class="sidebar-divider" />
                <legend>Filtrar Descargas</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="fechaInicio">Fecha Inicio:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaInicio" placeholder="12/31/2018" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td align="left">
                                &nbsp;
                                <label class="" for="fechaFinal">Fecha Final:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaFinal"  placeholder="12/31/2019" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnConsultar"  class="btn btn-primary"  runat="server" Text="Consultar"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </form>
        <br />
        <asp:Panel ID="panelResultados" runat="server" Visible="true">
            <form class="card">
                <table class="table ">
                    <thead class="thead-dark">
                        <tr>
                            <th># Descarga</th>
                            <th>Fecha y hora</th>
                            <th>Descripcion</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>1/1/2019 11:59</td>
                            <td>Se realizó una descarga...</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>2/1/2019 11:59</td>
                            <td>Se realizó otra descarga...</td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </asp:Panel>
    </div>
</asp:Content>
