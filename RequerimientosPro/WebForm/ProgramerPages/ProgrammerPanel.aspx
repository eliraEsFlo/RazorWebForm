<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramerPage.master"
    AutoEventWireup="true" CodeBehind="ProgrammerPanel.aspx.cs"
    Inherits="Frontend.ProgramerPages.ProgrammerPanel" %>


<asp:Content ID="con" ContentPlaceHolderID="logoutButton" runat="server">
    <asp:HyperLink ID="userLogout" runat="server">
                                     <i class="fas fa-arrow-left"></i>
                                        dato
                                </asp:HyperLink>
</asp:Content>

<asp:Content ID="ProyectosContent" ContentPlaceHolderID="BodyProgrammer" runat="server">


    <fieldset>
        <legend>Administrar proyectos</legend>


        <div class="container-fluid">
            <div class="row">
                <div class="col-3">
                    <div class="form-group">
                        
                            <h5>IdProgramador</h5>
                            <asp:Label ID="idProgramador" runat="server"
                                Text="idProgramador" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-3">
                    <div class="form-group">
                            <h5>Programador</h5>
                            <asp:Label ID="NombreProgramador" runat="server"
                                Text="Nombre" CssClass="form-control" />
                    </div>
                </div>

            </div>

        </div>


        <ul class="nav nav-pills mb-6" id="pills-tab" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="pills-home-tab"
                    data-toggle="pill" href="#pills-home" role="tab"
                    aria-controls="pills-home" aria-selected="true">Equipo</a>
            </li>


            <li class="nav-item">

                <a class="nav-link" id="pills-profile-tab"
                    data-toggle="pill" href="#pills-profile"
                    role="tab" aria-controls="pills-profile"
                    aria-selected="false">Individual</a>
            </li>
        </ul>

        <div class="tab-content" id="pills-tabContent">
            <div class="tab-pane fade show active"
                id="pills-home"
                role="tabpanel"
                aria-labelledby="pills-home-tab">
      
            
                <asp:GridView ID="ProyectosEnEquipo" runat="server"   CssClass="table table-bordered table-condensed" 
                 
                    OnSelectedIndexChanged="ProyectosEnEquipo_SelectedIndexChanged" AutoGenerateSelectButton="True">
                    <%--<Columns>

                                    
                       <asp:CommandField ShowSelectButton="True" SelectText="Ver" ControlStyle-Width="100px">
                                        <ControlStyle Width="100px"></ControlStyle>
                                    </asp:CommandField>
                                </Columns>--%>

                </asp:GridView>
  
            </div>
            <div class="tab-pane fade" id="pills-profile"
                role="tabpanel" aria-labelledby="pills-profile-tab">
                <asp:GridView ID="ProyectosIndividuales" runat="server"></asp:GridView>
            </div>

        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="boton" />
            </Triggers>
            <ContentTemplate>
            </ContentTemplate>

        </asp:UpdatePanel>
    </fieldset>

    <asp:Button ID="boton" runat="server" Text="data" OnClick="boton_Click" />


    <%--<div class="bs-example">
        <button type="button" class="btn btn-primary show-toast">Show Toast</button>

        <div class="toast" id="myToast"
            style="position: absolute; top: 100px; right: 0;">
            <div class="toast-header">
                <strong class="mr-auto"><i class="fa fa-grav"></i>We miss you!</strong>
                <small>11 mins ago</small>
                <button type="button" class="ml-2 mb-1 close"
                    data-dismiss="toast">
                    <i class="fas fa-window-close"></i>
                </button>
            </div>
            <div class="toast-body">
                <div>It's been a long t. <a href="#">Click here!</a></div>
            </div>
        </div>
    </div>--%>

</asp:Content>
