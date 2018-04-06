<%@ Page Title="" Language="C#" MasterPageFile="~/mstInner.Master" AutoEventWireup="true" CodeBehind="ProjectProgressReport.aspx.cs" Inherits="ProjectProgressUpdate.ProjectProgressReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; font-size: 16px; font-weight: bold">Project Progress Update</div>
    <div style="margin-left: 30px;margin-top:30px" class="col-md-12">
        <div class="col-sm-1">
            <b>Project Code:</b>
        </div>
        <div class="col-sm-2">
            <asp:DropDownList Width="200" CssClass="form-control" runat="server" ID="ddlProject" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <!-- -->
        </div>
         <div class="col-sm-3">
          <asp:Label runat="server" ID="txtProjectName"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Button runat="server" ID="btnShow" OnClick="btnShow_Click" CssClass="btn btn-sm" Text="Display" />
        </div>
    </div>


    <div style="font-size:12px; margin-top:50px" class="col-lg-12">
        <asp:GridView runat="server" CssClass="table table-sm" ID="gvData" AutoGenerateColumns="false" HeaderStyle-BackColor="White" HeaderStyle-Height="30" Width="100%" AllowPaging="true" PageSize="50" OnPageIndexChanging="gvData_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Activity" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%#Eval("t_cact") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%#Eval("t_dsca") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Scheduled Start Date" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%#Convert.ToDateTime(Eval("t_sdst")).ToString("dd-MM-yyyy") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Scheduled Finished Date" ItemStyle-Width="100">
                    <ItemTemplate>
                        <%#Convert.ToDateTime(Eval("t_sdfn")).ToString("dd-MM-yyyy") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Update" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkUpdate" OnClick="lnkUpdate_Click" CommandArgument='<%#Eval("t_cprj") +"&"+ Eval("t_cact") %>'><i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size:18px"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
