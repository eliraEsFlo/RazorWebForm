<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MixingWebFormsMVC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <link href="~/Content/bootswatch/lumen/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>


    <header>
        <nav class="navbar navbar-expand-lg badge-warning " style="background: #BC008D;">
            <a class="navbar-brand text-light" href="#">SmartRequire</a>

        </nav>
    </header>

    <div class="container">
        <div class="row"></div>
        <div class="row">

            <div class="container-fluid h-100">
                <div class="row justify-content-center align-items-center h-100">
                    <div class="col col-sm-6 col-md-6 col-lg-4 col-xl-3">


                        <form id="form1" runat="server">

                            <h4 class="text-center">Inciar sesion.</h4>
                            <hr />
                            <asp:Label ID="NoEsUsuarioText" runat="server" Text="Label"></asp:Label>

                            <div class="form-group">

                                <asp:TextBox ID="NombreUsuarioInput" placeholder="Usuario" runat="server"
                                    CssClass="form-control form-control-lg">

                                </asp:TextBox>

                                <asp:RequiredFieldValidator ID="validadorNombreUsuario" CssClass="text-danger"
                                    ControlToValidate="NombreUsuarioInput"
                                    runat="server" ErrorMessage="Usaurio requerido"></asp:RequiredFieldValidator>
                            </div>



                            <div class="form-group">

                                <asp:TextBox ID="PasswordUsuarioInput" runat="server" TextMode="Password"
                                    CssClass="form-control form-control-lg" placeholder="Contraseña">

                                </asp:TextBox>

                                <asp:RequiredFieldValidator ID="validarPassword" CssClass="text-danger"
                                    ControlToValidate="PasswordUsuarioInput"
                                    runat="server" ErrorMessage="Password requerido"></asp:RequiredFieldValidator>
                            </div>


                            <div class="form-group">
                                <asp:Button ID="LoginButton" data-targe="#myModal"
                                    runat="server" Text="Ingresar"
                                    CssClass="btn-lg btn-block btn btn-outline-success" OnClick="LoginButton_Click" 
                                   />
                            </div>


                        </form>
                    </div>
                </div>
            </div>
        </div>


    </div>

</body>
</html>
