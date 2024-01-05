<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQRCode._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/jquery.min.js"></script>
    <script>
        //Them anh
        function ClickInputFile(Id) {
            document.getElementById('fupload' + Id).click();
        }
        function readfiles(Id, files) {

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                url: "/FileUpload.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    alert(result);
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });
        }
    </script>

    <div class="jumbotron">
        <h1>APP</h1>
        <p class="lead">Thêm ảnh lưu trữ biên dịch mã QRCode</p>
        <p><a href="javascript:void(0);" onclick="ClickInputFile('tongthe');" class="btn btn-primary btn-lg">&nbsp;THÊM HÌNH ẢNH</a></p>
        <input name="fuploadtongthe" id="fuploadtongthe" type="file" multiple="" class="item3" style="display: none" onchange="readfiles('tongthe',this.files)">
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Xóa dữ liệu làm lại</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <asp:Button runat="server" ID="btnXoa" OnClick="btnXoa_Click" CssClass="btn btn-default" Text="Xóa dữ liệu hôm nay" OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
            </p>
        </div>
        
    </div>

 
</asp:Content>
