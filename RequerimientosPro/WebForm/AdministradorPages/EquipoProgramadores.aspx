<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNestedPage.master" AutoEventWireup="true" CodeBehind="EquipoProgramadores.aspx.cs" Inherits="Frontend.AdministradorPages.EquipoProgramadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminBody" runat="server">

    <div class="row">
        <div class="col-12">


            <div class="form-group">

                <div class="col-3">

                    <asp:DropDownList ID="ModosDeAsignacion"
                        runat="server"
                        CssClass="custom-select"
                        AutoPostBack="True"
                        OnTextChanged="ModosDeAsignacion_TextChanged">
                        <asp:ListItem>Individual</asp:ListItem>
                        <asp:ListItem>Equipo</asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div style="overflow-x: scroll; width: 100%;">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RequerimientosGridView"></asp:AsyncPostBackTrigger>
                        </Triggers>
                        <ContentTemplate>

                            <asp:GridView ID="RequerimientosGridView" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="0"
                                GridLines="Horizontal" OnSelectedIndexChanging="RequerimientosGridView_SelectedIndexChanging"
                                Caption="Info" CssClass="table-danger" EnableTheming="False" ClientIDMode="Predictable" ForeColor="Black">
                                <Columns>

                                    <asp:CommandField ShowSelectButton="True" SelectText="Ver" ControlStyle-Width="100px">
                                        <ControlStyle Width="100px"></ControlStyle>
                                    </asp:CommandField>

                                     <asp:TemplateField HeaderText="EstaActivo">

                                   <%-- <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("Estado") %>' />
                                    </ItemTemplate>--%>
                                </asp:TemplateField>

                                </Columns>

                            </asp:GridView>

                            <asp:GridView runat="server" ID="idGrid"></asp:GridView>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ModalContent" runat="server">


</asp:Content>
