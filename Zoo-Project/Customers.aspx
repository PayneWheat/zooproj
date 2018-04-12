<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>
        
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="ZooDB" InsertItemPosition="LastItem">
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
                        <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StreetAddressLabel" runat="server" Text='<%# Eval("StreetAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityAddressLabel" runat="server" Text='<%# Eval("CityAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ZipAddressLabel" runat="server" Text='<%# Eval("ZipAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StateAddressLabel" runat="server" Text='<%# Eval("StateAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MembershipTypeLabel" runat="server" Text='<%# Eval("MembershipType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExpirationDateLabel" runat="server" Text='<%# Eval("ExpirationDate") %>' />
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
                        <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MnameTextBox" runat="server" Text='<%# Bind("Mname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StreetAddressTextBox" runat="server" Text='<%# Bind("StreetAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CityAddressTextBox" runat="server" Text='<%# Bind("CityAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ZipAddressTextBox" runat="server" Text='<%# Bind("ZipAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StateAddressTextBox" runat="server" Text='<%# Bind("StateAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MembershipTypeTextBox" runat="server" Text='<%# Bind("MembershipType") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ExpirationDateTextBox" runat="server" Text='<%# Bind("ExpirationDate") %>' />
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
                        <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MnameTextBox" runat="server" Text='<%# Bind("Mname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StreetAddressTextBox" runat="server" Text='<%# Bind("StreetAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CityAddressTextBox" runat="server" Text='<%# Bind("CityAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ZipAddressTextBox" runat="server" Text='<%# Bind("ZipAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StateAddressTextBox" runat="server" Text='<%# Bind("StateAddress") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MembershipTypeTextBox" runat="server" Text='<%# Bind("MembershipType") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ExpirationDateTextBox" runat="server" Text='<%# Bind("ExpirationDate") %>' />
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
                        <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StreetAddressLabel" runat="server" Text='<%# Eval("StreetAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityAddressLabel" runat="server" Text='<%# Eval("CityAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ZipAddressLabel" runat="server" Text='<%# Eval("ZipAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StateAddressLabel" runat="server" Text='<%# Eval("StateAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MembershipTypeLabel" runat="server" Text='<%# Eval("MembershipType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExpirationDateLabel" runat="server" Text='<%# Eval("ExpirationDate") %>' />
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
                                    <th runat="server">Fname</th>
                                    <th runat="server">Mname</th>
                                    <th runat="server">Lname</th>
                                    <th runat="server">StreetAddress</th>
                                    <th runat="server">CityAddress</th>
                                    <th runat="server">ZipAddress</th>
                                    <th runat="server">StateAddress</th>
                                    <th runat="server">Phone</th>
                                    <th runat="server">Email</th>
                                    <th runat="server">MembershipType</th>
                                    <th runat="server">ExpirationDate</th>
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
                        <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StreetAddressLabel" runat="server" Text='<%# Eval("StreetAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityAddressLabel" runat="server" Text='<%# Eval("CityAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ZipAddressLabel" runat="server" Text='<%# Eval("ZipAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StateAddressLabel" runat="server" Text='<%# Eval("StateAddress") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MembershipTypeLabel" runat="server" Text='<%# Eval("MembershipType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ExpirationDateLabel" runat="server" Text='<%# Eval("ExpirationDate") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ZooDB" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [CUSTOMER] WHERE [ID] = @ID" InsertCommand="INSERT INTO [CUSTOMER] ([ID], [Fname], [Mname], [Lname], [StreetAddress], [CityAddress], [ZipAddress], [StateAddress], [Phone], [Email], [MembershipType], [ExpirationDate]) VALUES (@ID, @Fname, @Mname, @Lname, @StreetAddress, @CityAddress, @ZipAddress, @StateAddress, @Phone, @Email, @MembershipType, @ExpirationDate)" SelectCommand="SELECT * FROM [CUSTOMER]" UpdateCommand="UPDATE [CUSTOMER] SET [Fname] = @Fname, [Mname] = @Mname, [Lname] = @Lname, [StreetAddress] = @StreetAddress, [CityAddress] = @CityAddress, [ZipAddress] = @ZipAddress, [StateAddress] = @StateAddress, [Phone] = @Phone, [Email] = @Email, [MembershipType] = @MembershipType, [ExpirationDate] = @ExpirationDate WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Fname" Type="String" />
                <asp:Parameter Name="Mname" Type="String" />
                <asp:Parameter Name="Lname" Type="String" />
                <asp:Parameter Name="StreetAddress" Type="String" />
                <asp:Parameter Name="CityAddress" Type="String" />
                <asp:Parameter Name="ZipAddress" Type="Int32" />
                <asp:Parameter Name="StateAddress" Type="String" />
                <asp:Parameter Name="Phone" Type="Int64" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="MembershipType" Type="Int32" />
                <asp:Parameter DbType="Date" Name="ExpirationDate" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Fname" Type="String" />
                <asp:Parameter Name="Mname" Type="String" />
                <asp:Parameter Name="Lname" Type="String" />
                <asp:Parameter Name="StreetAddress" Type="String" />
                <asp:Parameter Name="CityAddress" Type="String" />
                <asp:Parameter Name="ZipAddress" Type="Int32" />
                <asp:Parameter Name="StateAddress" Type="String" />
                <asp:Parameter Name="Phone" Type="Int64" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="MembershipType" Type="Int32" />
                <asp:Parameter DbType="Date" Name="ExpirationDate" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
    </p>
<p>
        
    <asp:ListView ID="ListView2" runat="server" DataKeyNames="ID" DataSourceID="Zoo2" InsertItemPosition="LastItem">
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
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Zoo2" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [MEMBERSHIP_TYPE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [MEMBERSHIP_TYPE] ([ID], [Name]) VALUES (@ID, @Name)" SelectCommand="SELECT * FROM [MEMBERSHIP_TYPE]" UpdateCommand="UPDATE [MEMBERSHIP_TYPE] SET [Name] = @Name WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        
    </p>
<p>
        
    &nbsp;</p>
   
</asp:Content>
