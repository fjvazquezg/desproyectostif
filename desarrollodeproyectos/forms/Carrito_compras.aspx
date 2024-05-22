<%@ Page Title="Carrito de Compras Mejorado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito_Compras.aspx.cs" Inherits="desarrollodeproyectos.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="~/Scripts/css/bootstrap.min.css" />
        <!-- Font Awesome CSS -->
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />

        <div style="text-align: center;">
            <asp:Label ID="tituloCarrito" runat="server" CssClass="mb-4 fs-3 text-dark" Font-Size="32px" Font-Bold="true">Carrito de Compras</asp:Label>
        </div>
        <br />
        <asp:Panel ID="panelContenido" runat="server" Visible="true">
            <div class="row">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:GridView ID="GridViewCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered fs-5" OnRowCommand="GridViewCarrito_RowCommand" DataKeyNames="CAR_DET_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Imagen">
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("URLImagen") %>' CssClass="img-fluid" style="max-width: 100px; max-height: 100px;" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NombreProducto" HeaderText="Producto" ItemStyle-CssClass="fw-bold" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="${0:N2}" ItemStyle-CssClass="text-muted" />
                                        <asp:TemplateField HeaderText="Cantidad">
                                            <ItemTemplate>
                                                <div class="d-flex align-items-center justify-content-center">
                                                    <asp:LinkButton ID="btnDecrementar" runat="server" CommandName="Decrementar" CommandArgument='<%# Eval("CAR_DET_ID") %>' CssClass="btn btn-sm btn-outline-secondary me-2">
                                                        <i class="fas fa-minus"></i>
                                                    </asp:LinkButton>
                                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="fs-5"></asp:Label>
                                                    <asp:LinkButton ID="btnIncrementar" runat="server" CommandName="Incrementar" CommandArgument='<%# Eval("CAR_DET_ID") %>' CssClass="btn btn-sm btn-outline-secondary ms-2">
                                                        <i class="fas fa-plus"></i>
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="${0:N2}" ItemStyle-CssClass="fw-bold" />
                                        <asp:TemplateField HeaderText="-">
                                            <ItemTemplate>
                                                <div class="d-flex justify-content-center">
                                                    <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("CAR_DET_ID") %>'>
                                                        <i class="fas fa-trash-alt"></i>
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mt-3 mt-md-0">
                    <div class="card">
                        <div class="card-body text-center">
                            <br />
                            <asp:Label ID="lblTotalPagar" runat="server" CssClass="fs-5 fw-bold text-danger mb-3 d-block">Total a Pagar:</asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="btnPagar" CssClass="btn btn-success w-100 fs-5 mb-3" runat="server" OnClick="btnPagar_Click" Text="Finalizar Compra"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            
        </asp:Panel>

        <div class="row mt-3">  
            <div class="col-md-6">
                <br />
                <asp:LinkButton ID="btnSeguirComprando" CssClass="btn btn-primary d-flex align-items-center justify-content-center w-100 fs-5" runat="server" OnClick="btnRegresar_Click">
                    <i class="fas fa-shopping-cart me-2"></i> Seguir Comprando
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
