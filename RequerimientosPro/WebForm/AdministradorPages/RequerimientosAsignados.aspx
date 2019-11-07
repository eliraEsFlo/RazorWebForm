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
                                <asp:Label Text="Buscar" runat="server" ID="Label3" CssClass="form-control" />
                                <asp:TextBox Text="" runat="server" ID="SearchText" CssClass="form-control" 
                                    AutoPostBack="true"
                                    OnTextChanged="SearchText_TextChanged" onkeyup="doPostBack(this);"/>

                            </div>

                        </div>

                        <div class="col-3">

                            <div class="form-group">
                                <asp:Label Text="Modo de asignacion" runat="server" ID="tddd" />
                                <asp:DropDownList ID="ModosDeAsignacion"
                                    runat="server"
                                    CssClass="custom-select form-control"
                                    AutoPostBack="True"
                                    OnTextChanged="ModosDeAsignacion_TextChanged">
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>Equipo</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="col-3">
                            <div class="form-group">
                                <asp:Label Text="Filtrar por programador" runat="server" ID="Label1" />
                                <asp:DropDownList ID="DropDownList1"
                                    runat="server"
                                    CssClass="custom-select form-control"
                                    AutoPostBack="True"
                                    OnTextChanged="ModosDeAsignacion_TextChanged">
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>Equipo</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="col-3">
                            <div class="form-group">
                                <asp:Label Text="Filtrar por estado" runat="server" ID="Label2" />
                                <asp:DropDownList ID="DropDownList2"
                                    runat="server"
                                    CssClass="custom-select form-control"
                                    AutoPostBack="True"
                                    OnTextChanged="ModosDeAsignacion_TextChanged">
                                    <asp:ListItem>Individual</asp:ListItem>
                                    <asp:ListItem>Equipo</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>

                </div>

                <div style="overflow-x: scroll; width: 100%;">



                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="SearchText"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        <ContentTemplate>

                            <asp:GridView ID="RequerimientosGridView" runat="server"
                                BackColor="White" BorderStyle="None"
                                CellPadding="0" OnSelectedIndexChanging="RequerimientosGridView_SelectedIndexChanging"
                                CssClass="table table-bordered table-condensed" EnableTheming="False" ClientIDMode="Predictable" ForeColor="Black">
                                <Columns>

                                    <asp:CommandField ShowSelectButton="True" SelectText="Ver" ControlStyle-Width="100px">
                                        <ControlStyle Width="100px"></ControlStyle>
                                    </asp:CommandField>
                                </Columns>

                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RequerimientosGridView"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        <ContentTemplate>

                            <asp:GridView runat="server" ID="programadoresEnRequerimiento"></asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>




                </div>

            </div>
        </div>

    </div>

    <div class="row" id="botones">

        <div class="col-4  col-sm-2 col-md-2 col-lg-2">
            <asp:Label ID="mensaje" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="col-2 col-sm-4 col-md-4 col-lg-4">
        </div>


    </div>

</asp:Content>
