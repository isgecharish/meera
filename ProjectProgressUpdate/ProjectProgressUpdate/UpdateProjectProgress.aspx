<%@ Page Title="" Language="C#" MasterPageFile="~/mstInner.Master" AutoEventWireup="true" CodeBehind="UpdateProjectProgress.aspx.cs" Inherits="ProjectProgressUpdate.UpdateProjectProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/bootstrap-datetimepicker.js"></script>
    <script src="scripts/bootstrap-datetimepicker.min.js"></script>
    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script>
        $(function () {
            //  var date = new Date();                         for hide back date
            //  date.setDate(date.getDate());

            $(".txtDate").datetimepicker({
                // startDate: date,                             for hide back date
                format: "dd-mm-yyyy",
                autoclose: true,
                linkFormat: 'yyyy-mm-dd',
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,
                daysOfWeekDisabled: "0",
                //daysOfWeekHighlighted: "6",
                beforeShowDay: function (date) {
                    // Always available
                    return [true, 'available', null];
                }
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center; font-size:16px; font-weight:bold" class="col-lg-12">Project Progress Update</div>
    <div class="col-lg-12" style="margin-top:30px">
        <div class="row" style="margin-top:0px">
            <div class="col-sm-4">
                <label>Activity</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtActivity" Enabled="false" />
            </div>
            <div class="col-sm-4">
                <label>Description</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescription" Enabled="false" />
            </div>
        </div>

        <div class="row" style="margin-top:10px">
            <div class="col-sm-4">
                <label>Scheduled Start Date</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtScheduledStartDate" Enabled="false" />
            </div>
            <div class="col-sm-4">
                <label>Scheduled Finish Date</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtScheduledFinishDate" Enabled="false" />
            </div>
        </div>

        <div class="row" style="margin-top:10px">
            <div class="col-sm-4">
                <label>Actual Start Date</label>
                <asp:TextBox runat="server" CssClass="form-control txtDate" ID="txtActualStartDate" />
            </div>
            <div class="col-sm-4">
                <label>Actual Finish Date</label>
                <asp:TextBox runat="server" CssClass="form-control txtDate" ID="txtActualFinishDate" />
            </div>
        </div>

        <div style="margin-top: 20px; float: right" class="col-sm-8">
            <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn" Text="Update" />
        </div>
    </div>
</asp:Content>
