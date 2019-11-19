<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramerPage.master" AutoEventWireup="true"
    CodeBehind="GestorProyectos.aspx.cs" Inherits="Frontend.ProgramerPages.GestorProyectos" %>


<asp:Content ID="con" ContentPlaceHolderID="logoutButton" runat="server">
    <asp:HyperLink ID="userLogout" runat="server">
                                     <i class="fas fa-arrow-left"></i>
                                        dato
    </asp:HyperLink>
</asp:Content>


<asp:Content ID="content" ContentPlaceHolderID="BodyProgrammer" runat="server">

    <div class="row" id="InfoProyecto">
        <div class="col-4">
            idRequerimiento:
                    <asp:Label ID="idRequerimiento" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-4">
            Nombre proyecto
                       <asp:Label ID="NombreProyecto" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-4">
            <div class="form-group">
                <%--  Ver requerimiento
                       <asp:HyperLink ID="HyperLink1" runat="server" 
                           NavigateUrl="" 
                           Target="_blank">Ver requerimiento</asp:HyperLink>--%>

                <asp:Button
                    ID="AsignarButton"
                    runat="server"
                    Text="Ver requerimiento"
                    CssClass="btn btn-outline-success btn-block" OnClick="AsignarButton_Click" />
            </div>
        </div>
    </div>

    <div class="col-12">
        <div class="accordion" id="accordionExample">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="SeguirButton" />
                </Triggers>

                <ContentTemplate>
                    <div class="card" runat="server" id="AnalisisProcess">
                        <div class="card-header" id="headingOne">
                            <h2 class="mb-0">
                                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne"
                                    aria-expanded="true" aria-controls="collapseOne">
                                    <h5>Análisis</h5>
                                </button>
                            </h2>
                        </div>

                        <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body">

                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label1" runat="server" class="control-label" for="readOnlyInput"
                                                        Text="Fecha de inicio" />

                                                    <asp:TextBox ID="inicioAnalisisDatetimePicker" runat="server" TextMode="Date" class="form-control"
                                                        type="text" placeholder="" ReadOnly="true" />

                                                </fieldset>

                                                <small id="emailHelp" class="form-text text-muted text-success">Elija la fecha de promesa.</small>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label2" runat="server" class="control-label" for="readOnlyInput"
                                                        Text="Fecha de promesa" />

                                                    <asp:TextBox ID="FechaPromesaAnalisis" runat="server" TextMode="Date" class="form-control"
                                                        type="text" placeholder="" />

                                                </fieldset>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label3" runat="server" class="control-label" for="readOnlyInput"
                                                        Text="Fecha de entrega" />

                                                    <asp:TextBox ID="FechaEntregaDatetimePicker" runat="server" TextMode="Date" class="form-control"
                                                        type="text" placeholder="" ReadOnly="true" />

                                                </fieldset>


                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <asp:Button ID="SeguirButton" runat="server" Text="Listo"
                                                CssClass="form-control btn btn-success" OnClick="AvanzarToDercas" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ValidarDercas" />
                </Triggers>

                <ContentTemplate>

                    <div class="card" id="DercasProcess" runat="server">
                        <div class="card-header" id="headingTwo">
                            <h2 class="mb-0">
                                <button
                                    class="btn btn-link collapsed"
                                    type="button"
                                    data-toggle="collapse"
                                    data-target="#collapseTwo"
                                    aria-expanded="false"
                                    aria-controls="collapseTwo">

                                    <h5>Dercas y plan de trabajo</h5>

                                </button>
                            </h2>
                        </div>
                        <div id="collapseTwo"
                            class="collapse"
                            aria-labelledby="headingTwo"
                            data-parent="#accordionExample">

                            <div class="card-body">

                                <div class="container-fluid">

                                    <div class="row">

                                        <div class="col-3">

                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label7"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de inicio" />

                                                    <asp:TextBox ID="TextBox5"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>

                                                <small id="emailHelp"
                                                    class="form-text text-muted text-success">Elija la fecha de promesa.</small>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label8"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de promesa" />

                                                    <asp:TextBox ID="TextBox6"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text" placeholder="" />

                                                </fieldset>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label9"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de entrega" />

                                                    <asp:TextBox ID="TextBox7"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text" placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>


                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <asp:Button ID="ValidarDercas"
                                                runat="server"
                                                Text="Listo"
                                                CssClass="form-control btn btn-success"
                                                OnClick="AvanzarToDesarrollo" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ValidarDesarrollo" />
                </Triggers>

                <ContentTemplate>


                    <div class="card" runat="server" id="DesarrolloProcess">
                        <div class="card-header" id="headingThree">
                            <h2 class="mb-0">
                                <button class="btn btn-link collapsed"
                                    type="button"
                                    data-toggle="collapse"
                                    data-target="#collapseThree"
                                    aria-expanded="false"
                                    aria-controls="collapseThree">

                                    <h5>Desarrollo</h5>
                                </button>
                            </h2>
                        </div>
                        <div id="collapseThree"
                            class="collapse"
                            aria-labelledby="headingThree"
                            data-parent="#accordionExample">

                            <div class="card-body">

                                <div class="container-fluid">

                                    <div class="row">

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label4"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de inicio" />

                                                    <asp:TextBox ID="TextBox2"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>

                                                <small id="emailHelp"
                                                    class="form-text text-muted text-success">Elija la fecha de promesa.</small>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label5"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de promesa" />

                                                    <asp:TextBox ID="TextBox3"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder="" />

                                                </fieldset>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label ID="Label6"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de entrega" />

                                                    <asp:TextBox ID="TextBox4"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>


                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <asp:Button ID="ValidarDesarrollo"
                                                runat="server"
                                                Text="Listo"
                                                CssClass="form-control btn btn-success"
                                                OnClick="AvanzarToCertificacion" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanel4" runat="server">

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ValidarEntregaPU" />
                </Triggers>

                <ContentTemplate>
                    <div class="card" id="EntregaPUProcess" runat="server">
                        <div class="card-header">
                            <h2 class="mb-0">
                                <button class="btn btn-link collapsed"
                                    type="button"
                                    data-toggle="collapse"
                                    data-target="#EntregaToCertificacionCollapse"
                                    aria-expanded="false"
                                    aria-controls="EntregaToCertificacionCollapse">

                                    <h5>Entrega a certificacion</h5>

                                </button>
                            </h2>
                        </div>
                        <div id="EntregaToCertificacionCollapse"
                            class="collapse"
                            aria-labelledby="headingThree"
                            data-parent="#accordionExample">

                            <div class="card-body">
                                <div class="card-body">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-3">
                                                <div class="form-group">

                                                    <fieldset>

                                                        <asp:Label ID="Label10"
                                                            runat="server"
                                                            class="control-label"
                                                            for="readOnlyInput"
                                                            Text="Fecha de inicio" />

                                                        <asp:TextBox ID="TextBox8"
                                                            runat="server"
                                                            TextMode="Date"
                                                            class="form-control"
                                                            type="text"
                                                            placeholder=""
                                                            ReadOnly="true" />

                                                    </fieldset>

                                                    <small id="emailHelp"
                                                        class="form-text text-muted text-success">Elija la fecha de promesa.</small>

                                                </div>

                                            </div>

                                            <div class="col-3">
                                                <div class="form-group">

                                                    <fieldset>

                                                        <asp:Label ID="Label11"
                                                            runat="server"
                                                            class="control-label"
                                                            for="readOnlyInput"
                                                            Text="Fecha de promesa" />

                                                        <asp:TextBox ID="TextBox9"
                                                            runat="server"
                                                            TextMode="Date"
                                                            class="form-control"
                                                            type="text"
                                                            placeholder="" />

                                                    </fieldset>

                                                </div>

                                            </div>

                                            <div class="col-3">
                                                <div class="form-group">

                                                    <fieldset>

                                                        <asp:Label
                                                            ID="Label12"
                                                            runat="server"
                                                            class="control-label"
                                                            for="readOnlyInput"
                                                            Text="Fecha de entrega" />

                                                        <asp:TextBox ID="TextBox10"
                                                            runat="server"
                                                            TextMode="Date"
                                                            class="form-control"
                                                            type="text"
                                                            placeholder=""
                                                            ReadOnly="true" />

                                                    </fieldset>


                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-3">
                                                <asp:Button
                                                    ID="ValidarEntregaPU"
                                                    runat="server"
                                                    Text="Listo"
                                                    CssClass="form-control btn btn-success"
                                                    OnClick="AvanzarAProduccion" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>


            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ValidarProduccionButton" />
                </Triggers>
                <ContentTemplate>
                    <div class="card" id="ProduccionProcess" runat="server">
                        <div class="card-header" runat="server">
                            <h2 class="mb-0">
                                <button
                                    class="btn btn-link collapsed"
                                    type="button"
                                    data-toggle="collapse"
                                    data-target="#EntregaToProduccionCollapse"
                                    aria-expanded="false"
                                    aria-controls="EntregaToProduccionCollapse">
                                    <h5>Entrega a Produccion</h5>

                                </button>
                            </h2>
                        </div>
                        <div id="EntregaToProduccionCollapse"
                            class="collapse"
                            aria-labelledby="headingThree"
                            data-parent="#accordionExample">
                            <div class="card-body">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label
                                                        ID="Label13"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de inicio" />

                                                    <asp:TextBox
                                                        ID="TextBox11"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>

                                                <small id="emailHelp"
                                                    class="form-text text-muted text-success">Elija la fecha de promesa.</small>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label
                                                        ID="Label14"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de promesa" />

                                                    <asp:TextBox
                                                        ID="TextBox12"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder="" />

                                                </fieldset>

                                            </div>

                                        </div>

                                        <div class="col-3">
                                            <div class="form-group">

                                                <fieldset>

                                                    <asp:Label
                                                        ID="Label15"
                                                        runat="server"
                                                        class="control-label"
                                                        for="readOnlyInput"
                                                        Text="Fecha de entrega" />

                                                    <asp:TextBox
                                                        ID="TextBox13"
                                                        runat="server"
                                                        TextMode="Date"
                                                        class="form-control"
                                                        type="text"
                                                        placeholder=""
                                                        ReadOnly="true" />

                                                </fieldset>


                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-3">
                                            <asp:Button
                                                ID="ValidarProduccionButton"
                                                runat="server" Text="Listo"
                                                CssClass="form-control btn btn-success"
                                                OnClick="TerminarProyectoEvent" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
