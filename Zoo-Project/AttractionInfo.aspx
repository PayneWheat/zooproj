<%@ Page Title="Attraction Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AttractionInfo.aspx.cs" Inherits="AttractionInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="ZooDatabase" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="Open_closedCheckBox" runat="server" Checked='<%# Eval("Open_closed") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="Open_closed_dateLabel" runat="server" Text='<%# Eval("Open_closed_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ManagerLabel" runat="server" Text='<%# Eval("Manager") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Manager_dateLabel" runat="server" Text='<%# Eval("Manager_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="Open_closedCheckBox" runat="server" Checked='<%# Bind("Open_closed") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Open_closed_dateTextBox" runat="server" Text='<%# Bind("Open_closed_date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ManagerTextBox" runat="server" Text='<%# Bind("Manager") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Manager_dateTextBox" runat="server" Text='<%# Bind("Manager_date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="Open_closedCheckBox" runat="server" Checked='<%# Bind("Open_closed") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Open_closed_dateTextBox" runat="server" Text='<%# Bind("Open_closed_date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ManagerTextBox" runat="server" Text='<%# Bind("Manager") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Manager_dateTextBox" runat="server" Text='<%# Bind("Manager_date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="Open_closedCheckBox" runat="server" Checked='<%# Eval("Open_closed") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="Open_closed_dateLabel" runat="server" Text='<%# Eval("Open_closed_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ManagerLabel" runat="server" Text='<%# Eval("Manager") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Manager_dateLabel" runat="server" Text='<%# Eval("Manager_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">ID</th>
                                    <th runat="server">Name</th>
                                    <th runat="server">Open_closed</th>
                                    <th runat="server">Open_closed_date</th>
                                    <th runat="server">Manager</th>
                                    <th runat="server">Manager_date</th>
                                    <th runat="server">Description</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="Open_closedCheckBox" runat="server" Checked='<%# Eval("Open_closed") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="Open_closed_dateLabel" runat="server" Text='<%# Eval("Open_closed_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ManagerLabel" runat="server" Text='<%# Eval("Manager") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Manager_dateLabel" runat="server" Text='<%# Eval("Manager_date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ZooDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [ATTRACTION] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ATTRACTION] ([ID], [Name], [Open_closed], [Open_closed_date], [Manager], [Manager_date], [Description]) VALUES (@ID, @Name, @Open_closed, @Open_closed_date, @Manager, @Manager_date, @Description)" SelectCommand="SELECT * FROM [ATTRACTION]" UpdateCommand="UPDATE [ATTRACTION] SET [Name] = @Name, [Open_closed] = @Open_closed, [Open_closed_date] = @Open_closed_date, [Manager] = @Manager, [Manager_date] = @Manager_date, [Description] = @Description WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Open_closed" Type="Boolean" />
                <asp:Parameter DbType="Date" Name="Open_closed_date" />
                <asp:Parameter Name="Manager" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Manager_date" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Open_closed" Type="Boolean" />
                <asp:Parameter DbType="Date" Name="Open_closed_date" />
                <asp:Parameter Name="Manager" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Manager_date" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>&nbsp;</p>
</asp:Content>