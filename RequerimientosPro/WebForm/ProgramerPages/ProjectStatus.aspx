<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectStatus.aspx.cs"
    Inherits="Frontend.ProgramerPages.ProjectStatus" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="accordion" id="accordionExample">



        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="SeguirButton"/>
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

                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" class="form-control"
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
                                    CssClass="form-control btn btn-success" OnClick="SeguirButton_Click" />
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
                <asp:AsyncPostBackTrigger ControlID="SeguirButton" />
            </Triggers>

            <ContentTemplate>

                <div class="card" id="DercasProcess" runat="server">
                    <div class="card-header" id="headingTwo">
                        <h2 class="mb-0">
                            <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                <h5>Dercas y plan de trabajo</h5>

                            </button>
                        </h2>
                    </div>
                    <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                        <div class="card-body">
                            Anim 
     
                        </div>
                    </div>
                  
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>

        <div class="card" runat="server" id="DesarrolloProcess">
            <div class="card-header" id="headingThree">
                <h2 class="mb-0">
                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        <h5>Desarrollo</h5>

                    </button>
                </h2>
            </div>
            <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                <div class="card-body">
                </div>
            </div>
        </div>


        <div class="card" id="EntregaPUProcess" runat="server">
            <div class="card-header" id="entregaPUProcess">
                <h2 class="mb-0">
                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        <h5>Entrega a certificacion</h5>

                    </button>
                </h2>
            </div>
            <div id="collapse4" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                <div class="card-body">
                </div>
            </div>
        </div>

        <div class="card" id="ProduccionProcess" runat="server">
            <div class="card-header" runat="server">
                <h2 class="mb-0">
                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        <h5>Entrega a certificacion</h5>

                    </button>
                </h2>
            </div>
            <div id="collapse5" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                <div class="card-body">
                </div>
            </div>
        </div>

    </div>


</asp:Content>
