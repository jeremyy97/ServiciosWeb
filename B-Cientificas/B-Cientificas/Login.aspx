<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="B_Cientificas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row justify-content-center">

                <div class="col-xl-6 col-lg-6 col-lg-6">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">

                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Ingresar</h1>
                                        </div>
                                        <form class="user">
                                            <div class="form-group">
                                                <asp:TextBox class="form-control form-control-user" ID="txtUsuario"  placeholder="Usuario" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox class="form-control form-control-user" placeholder="Contraseña" ID="txtPassword" runat="server"></asp:TextBox>
                                            </div>
                                            <asp:Button class="btn btn-primary btn-user btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                            <div>
                                                <br></br>
                                                <div class="container" align="center">
                                                  
                                                </div>
                                            </div>
                                            <hr />
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
