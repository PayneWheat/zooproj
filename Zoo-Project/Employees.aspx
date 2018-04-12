<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="ZooDatabase" GroupItemCount="3" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <td runat="server" style="">ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />Fname:
                    <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    <br />Mname:
                    <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    <br />Lname:
                    <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    <br />Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />Hire_Date:
                    <asp:Label ID="Hire_DateLabel" runat="server" Text='<%# Eval("Hire_Date") %>' />
                    <br />Street:
                    <asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                    <br />City:
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    <br />Zip:
                    <asp:Label ID="ZipLabel" runat="server" Text='<%# Eval("Zip") %>' />
                    <br />State:
                    <asp:Label ID="StateLabel" runat="server" Text='<%# Eval("State") %>' />
                    <br />Email:
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    <br />Phone#:
                    <asp:Label ID="Phone_Label" runat="server" Text='<%# Eval("[Phone#]") %>' />
                    <br />Gender:
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                    <br />Store:
                    <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    <br />Attraction:
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <br /></td>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <td runat="server" style="">ID:
                    <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    <br />Fname:
                    <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
                    <br />Mname:
                    <asp:TextBox ID="MnameTextBox" runat="server" Text='<%# Bind("Mname") %>' />
                    <br />Lname:
                    <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
                    <br />Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />Hire_Date:
                    <asp:TextBox ID="Hire_DateTextBox" runat="server" Text='<%# Bind("Hire_Date") %>' />
                    <br />Street:
                    <asp:TextBox ID="StreetTextBox" runat="server" Text='<%# Bind("Street") %>' />
                    <br />City:
                    <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                    <br />Zip:
                    <asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>' />
                    <br />State:
                    <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>' />
                    <br />Email:
                    <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    <br />Phone#:
                    <asp:TextBox ID="Phone_TextBox" runat="server" Text='<%# Bind("[Phone#]") %>' />
                    <br />Gender:
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                    <br />Store:
                    <asp:TextBox ID="StoreTextBox" runat="server" Text='<%# Bind("Store") %>' />
                    <br />Attraction:
                    <asp:TextBox ID="AttractionTextBox" runat="server" Text='<%# Bind("Attraction") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    <br /></td>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
<td runat="server" />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <InsertItemTemplate>
                <td runat="server" style="">ID:
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    <br />Fname:
                    <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
                    <br />Mname:
                    <asp:TextBox ID="MnameTextBox" runat="server" Text='<%# Bind("Mname") %>' />
                    <br />Lname:
                    <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
                    <br />Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />Hire_Date:
                    <asp:TextBox ID="Hire_DateTextBox" runat="server" Text='<%# Bind("Hire_Date") %>' />
                    <br />Street:
                    <asp:TextBox ID="StreetTextBox" runat="server" Text='<%# Bind("Street") %>' />
                    <br />City:
                    <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                    <br />Zip:
                    <asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>' />
                    <br />State:
                    <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>' />
                    <br />Email:
                    <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    <br />Phone#:
                    <asp:TextBox ID="Phone_TextBox" runat="server" Text='<%# Bind("[Phone#]") %>' />
                    <br />Gender:
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                    <br />Store:
                    <asp:TextBox ID="StoreTextBox" runat="server" Text='<%# Bind("Store") %>' />
                    <br />Attraction:
                    <asp:TextBox ID="AttractionTextBox" runat="server" Text='<%# Bind("Attraction") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    <br /></td>
            </InsertItemTemplate>
            <ItemTemplate>
                <td runat="server" style="">ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />Fname:
                    <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    <br />Mname:
                    <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    <br />Lname:
                    <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    <br />Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />Hire_Date:
                    <asp:Label ID="Hire_DateLabel" runat="server" Text='<%# Eval("Hire_Date") %>' />
                    <br />Street:
                    <asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                    <br />City:
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    <br />Zip:
                    <asp:Label ID="ZipLabel" runat="server" Text='<%# Eval("Zip") %>' />
                    <br />State:
                    <asp:Label ID="StateLabel" runat="server" Text='<%# Eval("State") %>' />
                    <br />Email:
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    <br />Phone#:
                    <asp:Label ID="Phone_Label" runat="server" Text='<%# Eval("[Phone#]") %>' />
                    <br />Gender:
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                    <br />Store:
                    <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    <br />Attraction:
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <br /></td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="groupPlaceholder" runat="server">
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
                <td runat="server" style="">ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />Fname:
                    <asp:Label ID="FnameLabel" runat="server" Text='<%# Eval("Fname") %>' />
                    <br />Mname:
                    <asp:Label ID="MnameLabel" runat="server" Text='<%# Eval("Mname") %>' />
                    <br />Lname:
                    <asp:Label ID="LnameLabel" runat="server" Text='<%# Eval("Lname") %>' />
                    <br />Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />Hire_Date:
                    <asp:Label ID="Hire_DateLabel" runat="server" Text='<%# Eval("Hire_Date") %>' />
                    <br />Street:
                    <asp:Label ID="StreetLabel" runat="server" Text='<%# Eval("Street") %>' />
                    <br />City:
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    <br />Zip:
                    <asp:Label ID="ZipLabel" runat="server" Text='<%# Eval("Zip") %>' />
                    <br />State:
                    <asp:Label ID="StateLabel" runat="server" Text='<%# Eval("State") %>' />
                    <br />Email:
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    <br />Phone#:
                    <asp:Label ID="Phone_Label" runat="server" Text='<%# Eval("[Phone#]") %>' />
                    <br />Gender:
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                    <br />Store:
                    <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    <br />Attraction:
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <br /></td>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ZooDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [EMPLOYEE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [EMPLOYEE] ([ID], [Fname], [Mname], [Lname], [Title], [Hire_Date], [Street], [City], [Zip], [State], [Email], [Phone#], [Gender], [Store], [Attraction]) VALUES (@ID, @Fname, @Mname, @Lname, @Title, @Hire_Date, @Street, @City, @Zip, @State, @Email, @column1, @Gender, @Store, @Attraction)" SelectCommand="SELECT * FROM [EMPLOYEE]" UpdateCommand="UPDATE [EMPLOYEE] SET [Fname] = @Fname, [Mname] = @Mname, [Lname] = @Lname, [Title] = @Title, [Hire_Date] = @Hire_Date, [Street] = @Street, [City] = @City, [Zip] = @Zip, [State] = @State, [Email] = @Email, [Phone#] = @column1, [Gender] = @Gender, [Store] = @Store, [Attraction] = @Attraction WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Fname" Type="String" />
                <asp:Parameter Name="Mname" Type="String" />
                <asp:Parameter Name="Lname" Type="String" />
                <asp:Parameter Name="Title" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Hire_Date" />
                <asp:Parameter Name="Street" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="column1" Type="Int32" />
                <asp:Parameter Name="Gender" Type="Int32" />
                <asp:Parameter Name="Store" Type="Int32" />
                <asp:Parameter Name="Attraction" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Fname" Type="String" />
                <asp:Parameter Name="Mname" Type="String" />
                <asp:Parameter Name="Lname" Type="String" />
                <asp:Parameter Name="Title" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Hire_Date" />
                <asp:Parameter Name="Street" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="column1" Type="Int32" />
                <asp:Parameter Name="Gender" Type="Int32" />
                <asp:Parameter Name="Store" Type="Int32" />
                <asp:Parameter Name="Attraction" Type="Int32" />
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
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ID_newLabel" runat="server" Text='<%# Eval("ID_new") %>' />
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
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ID_newLabel1" runat="server" Text='<%# Eval("ID_new") %>' />
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
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td>&nbsp;</td>
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
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ID_newLabel" runat="server" Text='<%# Eval("ID_new") %>' />
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
                                    <th runat="server">Title</th>
                                    <th runat="server">ID_new</th>
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
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ID_newLabel" runat="server" Text='<%# Eval("ID_new") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="Zoo2" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [TITLE_TYPE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TITLE_TYPE] ([ID], [Title]) VALUES (@ID, @Title)" SelectCommand="SELECT * FROM [TITLE_TYPE]" UpdateCommand="UPDATE [TITLE_TYPE] SET [Title] = @Title, [ID_new] = @ID_new WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Title" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="ID_new" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:ListView ID="ListView3" runat="server" DataKeyNames="ID" DataSourceID="Zoo3" InsertItemPosition="LastItem">
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
        <asp:SqlDataSource ID="Zoo3" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [GENDER_TYPE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [GENDER_TYPE] ([ID], [Name]) VALUES (@ID, @Name)" SelectCommand="SELECT * FROM [GENDER_TYPE]" UpdateCommand="UPDATE [GENDER_TYPE] SET [Name] = @Name WHERE [ID] = @ID">
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
   
</asp:Content>

