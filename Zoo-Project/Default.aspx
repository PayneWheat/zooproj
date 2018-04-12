<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Group 14</h1>
        <p class="lead">To store information about animals, workers, attractions, gift shops, customers’ details including purchases, earnings at the zoo.</p>
    </div>
    <div>
        <asp:Label ForeColor="#0033cc" ID="Label1" runat="server" Text="Label">ID</asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label">Title</asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Display ID" OnClick="Button1_Click" />
        <br />

        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        <br />
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ZooDatabase">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ZooDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" SelectCommand="SELECT [ID], [Title] FROM [TITLE_TYPE]" DeleteCommand="DELETE FROM [TITLE_TYPE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TITLE_TYPE] ([ID], [Title]) VALUES (@ID, @Title)" UpdateCommand="UPDATE [TITLE_TYPE] SET [Title] = @Title WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
</asp:SqlDataSource>
    
    
<br />
<asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="ZooDatabase" Height="50px" Width="125px">
    <Fields>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>
    
    
</asp:Content>
