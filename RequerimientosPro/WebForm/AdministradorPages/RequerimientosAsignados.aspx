<%@ Page Title="" Language="C#"
    MasterPageFile="~/AdminNestedPage.master"
    AutoEventWireup="true"
    CodeBehind="RequerimientosAsignados.aspx.cs"
    Inherits="Frontend.AdministradorPages.RequerimientosAsignados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminBody" runat="server">

    <div class="row">
        <div class="col-12">


            <div class="form-group">
                <div class="container-fluid">


                    <div class="row">
                        <div class="col-3">
                            <div class="form-group">
                                <h3>
                                    <asp:Label Text="Tipo requerimiento" runat="server" ID="Label1" /></h3>
                                <asp:DropDownList ID="TipoRequerimientos"
                                    runat="server"
                                    CssClass="custom-select form-control" 
                                    
                                    AutoPostBack="true">
                                    <asp:ListItem>Incidencia</asp:ListItem>
                                    <asp:ListItem>Proyecto</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>

                    <div class="row">

                        <div class="col-3">
                            <div class="form-group">
                                <asp:Label Text="Buscar por No. Requerimiento" runat="server" ID="Label3" />
                                <asp:TextBox Text="" runat="server" ID="SearchText" CssClass="form-control"
                                    AutoPostBack="true" placeholder="Buscar..."
                                    OnTextChanged="SearchText_TextChanged" onkeyup="doPostBack(this);" />

                            </div>

                        </div>

                        <div class="col-3">

                            <div class="form-group">
                                <asp:Label Text="Modo de asignacion" runat="server" ID="tddd" />
                                <asp:DropDownList ID="ModosDeAsignacion"
                                    runat="server"
                                    CssClass="custom-select form-control" OnTextChanged="ModosDeAsignacion_TextChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>Equipo</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>


                        <div class="col-3">
                            <div class="form-group">
                                <asp:Label Text="Filtrar por estado" runat="server" ID="Label2" />
                                <asp:DropDownList ID="EstadosRequerimientos"
                                    runat="server"
                                    CssClass="custom-select form-control"
                                    AutoPostBack="True"
                                    DataValueField="idEstadoRequerimiento"
                                    DataTextField="NombreEstado" OnTextChanged="EstadosRequerimientos_TextChanged">
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>

                </div>

                <div style="overflow-x: scroll; width: 100%;">



                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="SearchText"></asp:AsyncPostBackTrigger>

                            <asp:AsyncPostBackTrigger ControlID="TipoRequerimientos"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="ModosDeAsignacion"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="EstadosRequerimientos"></asp:AsyncPostBackTrigger>

                        </Triggers>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TipoRequerimientos"></asp:AsyncPostBackTrigger>
                        </Triggers>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ModosDeAsignacion"></asp:AsyncPostBackTrigger>
                        </Triggers>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="EstadosRequerimientos"></asp:AsyncPostBackTrigger>
                        </Triggers>


                        <ContentTemplate>

                            <div class="table-responsive" style="overflow-y: scroll; height: 200px;">
                                <h2><asp:Label Text="Requerimientos asignados" ID="idLabel" runat="server"/></h2>
                                <asp:GridView ID="RequerimientosGridView" runat="server"
                                    CellPadding="0" OnSelectedIndexChanging="RequerimientosGridView_SelectedIndexChanging"
                                    CssClass="table table-hover table-bordered table-condensed">
                                    <Columns>

                                        <asp:CommandField ShowSelectButton="True" SelectText="Ver" ControlStyle-Width="100px">
                                            <ControlStyle Width="100px"></ControlStyle>
                                        </asp:CommandField>
                                    </Columns>

                                    <SelectedRowStyle BackColor="#99FF66" BorderStyle="Solid" />

                                </asp:GridView>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RequerimientosGridView"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        <ContentTemplate>

                            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#pills-home" 
                                        role="tab" aria-controls="pills-home" aria-selected="true">Programdores encargados</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#pills-profile"
                                        role="tab" aria-controls="pills-profile" aria-selected="false">Permisos requeridos</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="pills-contact-tab" data-toggle="pill" href="#pills-contact" 
                                        role="tab" aria-controls="pills-contact" aria-selected="false">Procesos a seguir</a>
                                </li>

                              
                            </ul>
                            <div class="tab-content" id="pills-tabContent">
                                <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                        <asp:GridView runat="server" ID="programadoresEnRequerimiento"></asp:GridView> 
                                </div>
                                <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                                        <asp:GridView runat="server" ID="PermisosGridView"></asp:GridView> 
                                </div>
                                <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">Procesos</div>
                            </div>





                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>

            </div>
        </div>

    </div>

    <div class="row" id="botones">

        <div class="col-4  col-sm-2 col-md-2 col-lg-2">
        </div>

        <div class="col-2 col-sm-4 col-md-4 col-lg-4">
        </div>


    </div>

</asp:Content>
