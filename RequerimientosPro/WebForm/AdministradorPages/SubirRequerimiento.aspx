<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNestedPage.master" AutoEventWireup="true"
    CodeBehind="SubirRequerimiento.aspx.cs" Inherits="Frontend.AdministradorPages.SubirRequerimiento" %>

<asp:Content ID="requerimientoBody" ContentPlaceHolderID="AdminBody" runat="server">

        <div class="row">
            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">

                <div class="form-group">
                    <asp:Label ID="Label1"
                        runat="server"
                        Text="No requerimiento"
                        CssClass="form-control form-control-lg"
                        Font-Size="Small" />
                    <asp:TextBox ID="NoRequerimientoTextbox"
                        placeholder="No Requerimiento"
                        runat="server"
                        CssClass="form-control " ReadOnly="True" />

                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        CssClass="text-danger"
                        ControlToValidate="NoRequerimientoTextbox"
                        runat="server"
                        ErrorMessage="No Requerimiento requerido" />

                </div>

            </div>

            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">

                <div class="form-group">
                    <asp:Label ID="Label2"
                        runat="server"
                        Text="Area que solicita"
                        CssClass="form-control form-control-lg form-control-sm"
                        Font-Size="Small" />

                    <asp:DropDownList ID="AreasSolicitantesCombobox"
                        runat="server"
                        CssClass="custom-select" DataTextField="NombreArea" DataValueField="idArea">
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        CssClass="text-danger"
                        ControlToValidate="AreasSolicitantesCombobox"
                        runat="server" ErrorMessage="Area requerida">
                    </asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">

                <div class="form-group">
                    <asp:Label ID="Label3"
                        runat="server"
                        Text="Tipo de proyecto"
                        CssClass="form-control form-control-lg"
                        Font-Size="Small"></asp:Label>

                    <asp:DropDownList ID="TiposDeRequerimientosCombobox"
                        runat="server"
                        CssClass="custom-select" DataTextField="NombreTipoRequerimiento" DataValueField="idTipoRequerimiento"
                        AutoPostBack="True" OnSelectedIndexChanged="Data" >
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                        CssClass="text-danger"
                        ControlToValidate="TiposDeRequerimientosCombobox"
                        runat="server"
                        ErrorMessage="Tipo de proyecto requerido" />
                </div>

            </div>

            <div class="col-sm-4 col-md-4 col-lg-4 col-xl-4">

                <div class="form-group">
                    <asp:Label
                        ID="Label4"
                        runat="server"
                        Text="Nombre requerimiento"
                        CssClass="form-control form-control-lg"
                        Font-Size="Small" />

                    <asp:TextBox ID="NombreRequerimientoTextbox"
                        placeholder="Nombre requerimiento"
                        runat="server"
                        CssClass="form-control " />

                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3"
                        CssClass="text-danger"
                        ControlToValidate="NombreRequerimientoTextbox"
                        runat="server"
                        ErrorMessage="Nombre requerimiento requerido" />

                </div>

            </div>

        </div>

        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">

                <div class="form-group">
                    <asp:Label
                        ID="Label5"
                        runat="server"
                        Text="Elije los procesos que no aplican"
                        CssClass="form-control form-control-lg"
                        Font-Size="Small" />

                    <div class="container">
                        <asp:CheckBoxList
                            CssClass="table-responsive"
                            DataTextField="NombreProceso"
                            DataValueField="idProceso"
                            ID="ProcesosCheckboxes"
                            runat="server"
                            RepeatLayout="Flow" RepeatDirection="Horizontal" />
                    </div>

                </div>

            </div>          
            
        </div>

        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">

                <div class="form-group">
                    <asp:Label
                        ID="Label8"
                        runat="server"
                        Text="Permiso de PU que no aplican"
                        CssClass="form-control form-control-lg"
                        Font-Size="Small" />

                    <div class="table-responsive">
                        <asp:CheckBoxList
                            ID="PermisosCheckboxes"
                            runat="server"
                            RepeatLayout="Flow" RepeatDirection="Horizontal"
                            DataTextField="NombrePermiso"
                            DataValueField="idPermisoPU">
                        </asp:CheckBoxList>

                    </div>
                </div>

            </div>
        </div>

        <div class="row">
           

            <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">
                 

                <fieldset class="border p-2">
                   <legend  class="w-auto">Modo de trabajo</legend>
                    <asp:RadioButtonList ID="modoDeTrabajo" runat="server" 
                        AutoPostBack="True" OnSelectedIndexChanged="modoDeTrabajo_SelectedIndexChanged" 
                        RepeatDirection="Horizontal" >
                        <asp:ListItem Value="1" >Equipo</asp:ListItem>
                        <asp:ListItem Value="2">Individual</asp:ListItem>

                     </asp:RadioButtonList>



                     <div class="container-fluid">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label
                                        ID="Label6"
                                        runat="server"
                                        Text="Lider"
                                        CssClass="form-control form-control-lg"
                                        Font-Size="Small" />

                                    <asp:DropDownList
                                        ID="LideresCombobox"
                                        runat="server"
                                        CssClass="custom-select" DataTextField="NombreUsuario" DataValueField="idUsuario">
                                    </asp:DropDownList>
                                    <asp:Button
                                        ID="AgregarLiderButton"
                                        runat="server"
                                        Text="Agregar"
                                        CssClass="btn btn-outline-warning btn-block" OnClick="SetEquipoLider" />

                                    <h4 class="modal-title">
                                        <asp:Label ID="liderWarning" runat="server" Text = "" />
                                    </h4>
                              
                                </div>
                            </div>

                            <div class="col-6">

                                <div class="form-group">
                                    <asp:Label
                                        ID="Label7"
                                        runat="server"
                                        Text="Programadores"
                                        CssClass="form-control form-control-lg"
                                        Font-Size="Small" />

                                    <asp:DropDownList
                                        ID="ProgramadoresCombobox"
                                        runat="server"
                                        CssClass="custom-select" DataTextField="NombreUsuario" DataValueField="idUsuario" />

                                    <asp:Button
                                        ID="AgregarProgramadorButton"
                                        runat="server"
                                        Text="Agregar"
                                        CssClass="btn btn-outline-warning btn-block" OnClick="AddTempProgrammerData" />

                                    <h4 class="modal-title">
                                        <asp:Label ID="programmerWarning" runat="server" Text="" />
                                    </h4>
                               
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">

                                <asp:GridView ID="ProgramadoresGridView" runat="server" DataKeyNames="idUsuario"
                                    AutoGenerateDeleteButton="true" OnRowDeleting="DeleteTempProgrammersData" CssClass="table">
                                </asp:GridView>

                            </div>
                        </div>
                     </div>
                </fieldset>

            </div>



            <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">
                <div class="form-group">
                    <asp:Label
                        ID="Label10"
                        runat="server"
                        Text="Ruta de archivo: "
                        CssClass="form-control form-control-lg"
                        Font-Size="Small" />


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

                        <Triggers>
                            <asp:PostBackTrigger ControlID="UploadButton" />
                        </Triggers>

                        <ContentTemplate>
                            <asp:FileUpload ID="RutaRequerimientoFileUpload" runat="server" />
                        </ContentTemplate>

                    </asp:UpdatePanel>

                    <asp:Button ID="UploadButton" runat="server" Text="Subir" OnClick="uploadButton_Click" />
                    <asp:Label ID="estadoTexto" runat="server" Text=""></asp:Label>

                </div>
            </div>

        </div>

        <div class="row" id="botones">
            <div class="col-4  col-sm-2 col-md-2 col-lg-2"></div>
            <div class="col-2 col-sm-4 col-md-4 col-lg-4">

                <asp:Button
                    ID="LimpiarButton"
                    runat="server"
                    Text="Limpiar"
                    CssClass="btn btn-outline-danger btn-block "
                    OnClick="ClearControls" />
            </div>

            <div class="col-2 col-sm-4 col-md-4 col-lg-4">
                <asp:Button
                    ID="AsignarButton"
                    runat="server"
                    Text="Asignar"
                    CssClass="btn btn-outline-success btn-block" OnClick="AgregarRequerimientoEvent" />
            </div>

            <div class="col-2 col-sm-2 col-md-2 col-lg-2"></div>
        </div>

</asp:Content>
