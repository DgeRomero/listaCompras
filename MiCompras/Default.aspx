﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiCompras.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row mt-5 mb-5">
        <div class="col-3">
            <asp:TextBox CssClass="form-control" ID="txtArticulo" runat="server" />
        </div>
        <div class="col-3">
            <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
        </div>

    </div>
    <div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="dvgLista" DataKeyNames="Id"
                    CssClass="table table-bordered table-hover" AutoGenerateColumns="false"
                    OnRowEditing="dvgLista_RowEditing"
                    OnRowCommand="dvgLista_RowCommand"
                    OnRowUpdating="dvgLista_RowUpdating"
                    OnRowCancelingEdit="dvgLista_RowCancelingEdit"
                   
            >
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label Text='<% #Eval("Nombre") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox Text='<%# Eval("Nombre") %>' ID="txtNombre" runat="server" CssClass="form-control"/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripion">
                            <ItemTemplate>
                                <asp:Label Text='<% #Eval("Descripcion") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescripcion" Text='<% #Eval("Descripcion") %>' runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Label Text='<% #Eval("Cantidad") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCantidad" Text='<% #Eval("Cantidad") %>' TextMode="Number" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<% #Eval("Precio") %>'  runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" Text='<% #Eval("Precio") %>' TextMode="Number"  runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" ShowCancelButton="true" UpdateText="Guardar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-success " />
                        <asp:ButtonField  ButtonType="Button" CommandName="btnEliminar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-danger" Text="Eliminar"  />
                       
                    </Columns>

                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
