<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="MixingWebFormsMVC.AdminPages.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
     <div class="container">
        <div class="row">
            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">

                 <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="No requerimiento"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                      <asp:TextBox ID="NoRequerimiento" placeholder="No Requerimiento" runat="server"  
                                    CssClass="form-control ">
                      </asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" 
                                    ControlToValidate="NoRequerimiento"
                                    runat="server" ErrorMessage="No Requerimiento requerido">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

             <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">

                 <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Area que solicita"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                      
                     <asp:DropDownList ID="AreasSolicitantes" runat="server" CssClass="custom-select"></asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" 
                                    ControlToValidate="AreasSolicitantes"
                                    runat="server" ErrorMessage="Area requerida">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

             <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">

                 <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Tipo de proyecto"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>

                      <asp:DropDownList ID="TiposDeProyectos" runat="server" CssClass="custom-select"></asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" 
                                    ControlToValidate="TiposDeProyectos"
                                    runat="server" ErrorMessage="Tipo de proyecto requerido">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

             <div class="col-sm-4 col-md-4 col-lg-4 col-xl-4">

                 <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Nombre requerimiento"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>

                       <asp:TextBox ID="NombreRequerimiento" placeholder="Nombre requerimiento" runat="server"
                                    CssClass="form-control ">
                      </asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" 
                                    ControlToValidate="NombreRequerimiento"
                                    runat="server" ErrorMessage="Nombre requerimiento requerido">
                    </asp:RequiredFieldValidator>
                    
                 </div>

            </div>        

        </div>

        <div class="row">
            <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">

                 <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Elije los procesos que no aplican"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
              
                        <div class="listaPermisos">
                             <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" ></asp:CheckBoxList>
     
                        </div>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" 
                                    ControlToValidate="NoRequerimiento"
                                    runat="server" ErrorMessage="No Requerimiento requerido">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

             <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">

                 <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Permiso de PU que no aplican"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                   
                      <div class="listaPermisos">
                             <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" ></asp:CheckBoxList>
     
                        </div>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" 
                                    ControlToValidate="NoRequerimiento"
                                    runat="server" ErrorMessage="No Requerimiento requerido">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>
        </div>

         <div class="row">
              <div class="col-sm-6 col-md-3 col-lg-3 col-xl-3">

                 <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Tipo de requerimiento"
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                      
                     <asp:DropDownList ID="TiposDeRequerimientos" runat="server" CssClass="custom-select"></asp:DropDownList>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" 
                                    ControlToValidate="TiposDeRequerimientos"
                                    runat="server" ErrorMessage="Tipo de requerimiento requerido">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

              <div class="col-sm-6 col-md-3 col-lg-3 col-xl-3">

                 <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Asignar a: "
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                      
                     <asp:DropDownList ID="Programadores" runat="server" CssClass="custom-select"></asp:DropDownList>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" 
                                    ControlToValidate="Programadores"
                                    runat="server" ErrorMessage="Debe asignador a alguien">
                    </asp:RequiredFieldValidator>
                 </div>

            </div>

             <div class="col-sm-6 col-md-6 col-lg-6 col-xl-6">
                 <div class="form-group">
                      <asp:Label ID="Label9" runat="server" Text="Ruta de archivo: "
                                    CssClass="form-control form-control-lg" Font-Size="Small"></asp:Label>
                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="custom-file" />
                 </div>
             </div>

         </div>
   
        <div class="row">
            <div class="col-4"></div>
            <div class="col-2">
                <asp:Button ID="Button1" runat="server" Text="Limpiar" CssClass="btn btn-outline-danger btn-block"/>
            </div>
             <div class="col-2">
                <asp:Button ID="Button2" runat="server" Text="Asignar" CssClass="btn btn-outline-success btn-block"/>
            </div>
             <div class="col-4"></div>
        </div>
     </div>

</asp:Content>
