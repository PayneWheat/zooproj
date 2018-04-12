<%@ Page Title="Animals" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.
    </h2>
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
                    <asp:Label ID="SpeciesLabel" runat="server" Text='<%# Eval("Species") %>' />
                </td>
                <td>
                    <asp:Label ID="TaxologyLabel" runat="server" Text='<%# Eval("Taxology") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_LocationLabel" runat="server" Text='<%# Eval("[Birth Location]") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_DateLabel" runat="server" Text='<%# Eval("[Birth Date]") %>' />
                </td>
                <td>
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                </td>
                <td>
                    <asp:Label ID="Status_dateLabel" runat="server" Text='<%# Eval("Status_date") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("Height") %>' />
                </td>
                <td>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Eval("Weight") %>' />
                </td>
                <td>
                    <asp:Label ID="HealthLabel" runat="server" Text='<%# Eval("Health") %>' />
                </td>
                <td>
                    <asp:Label ID="Health_dateLabel" runat="server" Text='<%# Eval("Health_date") %>' />
                </td>
                <td>
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
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
                    <asp:TextBox ID="SpeciesTextBox" runat="server" Text='<%# Bind("Species") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TaxologyTextBox" runat="server" Text='<%# Bind("Taxology") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Birth_LocationTextBox" runat="server" Text='<%# Bind("[Birth Location]") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Birth_DateTextBox" runat="server" Text='<%# Bind("[Birth Date]") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Status_dateTextBox" runat="server" Text='<%# Bind("Status_date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HeightTextBox" runat="server" Text='<%# Bind("Height") %>' />
                </td>
                <td>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HealthTextBox" runat="server" Text='<%# Bind("Health") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Health_dateTextBox" runat="server" Text='<%# Bind("Health_date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AttractionTextBox" runat="server" Text='<%# Bind("Attraction") %>' />
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
                    <asp:TextBox ID="SpeciesTextBox" runat="server" Text='<%# Bind("Species") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TaxologyTextBox" runat="server" Text='<%# Bind("Taxology") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Birth_LocationTextBox" runat="server" Text='<%# Bind("[Birth Location]") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Birth_DateTextBox" runat="server" Text='<%# Bind("[Birth Date]") %>' />
                </td>
                <td>
                    <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Status_dateTextBox" runat="server" Text='<%# Bind("Status_date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HeightTextBox" runat="server" Text='<%# Bind("Height") %>' />
                </td>
                <td>
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HealthTextBox" runat="server" Text='<%# Bind("Health") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Health_dateTextBox" runat="server" Text='<%# Bind("Health_date") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AttractionTextBox" runat="server" Text='<%# Bind("Attraction") %>' />
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
                    <asp:Label ID="SpeciesLabel" runat="server" Text='<%# Eval("Species") %>' />
                </td>
                <td>
                    <asp:Label ID="TaxologyLabel" runat="server" Text='<%# Eval("Taxology") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_LocationLabel" runat="server" Text='<%# Eval("[Birth Location]") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_DateLabel" runat="server" Text='<%# Eval("[Birth Date]") %>' />
                </td>
                <td>
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                </td>
                <td>
                    <asp:Label ID="Status_dateLabel" runat="server" Text='<%# Eval("Status_date") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("Height") %>' />
                </td>
                <td>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Eval("Weight") %>' />
                </td>
                <td>
                    <asp:Label ID="HealthLabel" runat="server" Text='<%# Eval("Health") %>' />
                </td>
                <td>
                    <asp:Label ID="Health_dateLabel" runat="server" Text='<%# Eval("Health_date") %>' />
                </td>
                <td>
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
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
                                <th runat="server">Species</th>
                                <th runat="server">Taxology</th>
                                <th runat="server">Birth Location</th>
                                <th runat="server">Birth Date</th>
                                <th runat="server">Status</th>
                                <th runat="server">Status_date</th>
                                <th runat="server">Gender</th>
                                <th runat="server">Height</th>
                                <th runat="server">Weight</th>
                                <th runat="server">Health</th>
                                <th runat="server">Health_date</th>
                                <th runat="server">Attraction</th>
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
                    <asp:Label ID="SpeciesLabel" runat="server" Text='<%# Eval("Species") %>' />
                </td>
                <td>
                    <asp:Label ID="TaxologyLabel" runat="server" Text='<%# Eval("Taxology") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_LocationLabel" runat="server" Text='<%# Eval("[Birth Location]") %>' />
                </td>
                <td>
                    <asp:Label ID="Birth_DateLabel" runat="server" Text='<%# Eval("[Birth Date]") %>' />
                </td>
                <td>
                    <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                </td>
                <td>
                    <asp:Label ID="Status_dateLabel" runat="server" Text='<%# Eval("Status_date") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("Height") %>' />
                </td>
                <td>
                    <asp:Label ID="WeightLabel" runat="server" Text='<%# Eval("Weight") %>' />
                </td>
                <td>
                    <asp:Label ID="HealthLabel" runat="server" Text='<%# Eval("Health") %>' />
                </td>
                <td>
                    <asp:Label ID="Health_dateLabel" runat="server" Text='<%# Eval("Health_date") %>' />
                </td>
                <td>
                    <asp:Label ID="AttractionLabel" runat="server" Text='<%# Eval("Attraction") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ZooDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [ANIMAL] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ANIMAL] ([ID], [Name], [Species], [Taxology], [Birth Location], [Birth Date], [Status], [Status_date], [Gender], [Height], [Weight], [Health], [Health_date], [Attraction]) VALUES (@ID, @Name, @Species, @Taxology, @Birth_Location, @Birth_Date, @Status, @Status_date, @Gender, @Height, @Weight, @Health, @Health_date, @Attraction)" SelectCommand="SELECT * FROM [ANIMAL]" UpdateCommand="UPDATE [ANIMAL] SET [Name] = @Name, [Species] = @Species, [Taxology] = @Taxology, [Birth Location] = @Birth_Location, [Birth Date] = @Birth_Date, [Status] = @Status, [Status_date] = @Status_date, [Gender] = @Gender, [Height] = @Height, [Weight] = @Weight, [Health] = @Health, [Health_date] = @Health_date, [Attraction] = @Attraction WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Species" Type="String" />
                <asp:Parameter Name="Taxology" Type="String" />
                <asp:Parameter Name="Birth_Location" Type="String" />
                <asp:Parameter DbType="Date" Name="Birth_Date" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter DbType="Date" Name="Status_date" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="Height" Type="Decimal" />
                <asp:Parameter Name="Weight" Type="Decimal" />
                <asp:Parameter Name="Health" Type="String" />
                <asp:Parameter DbType="Date" Name="Health_date" />
                <asp:Parameter Name="Attraction" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Species" Type="String" />
                <asp:Parameter Name="Taxology" Type="String" />
                <asp:Parameter Name="Birth_Location" Type="String" />
                <asp:Parameter DbType="Date" Name="Birth_Date" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter DbType="Date" Name="Status_date" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="Height" Type="Decimal" />
                <asp:Parameter Name="Weight" Type="Decimal" />
                <asp:Parameter Name="Health" Type="String" />
                <asp:Parameter DbType="Date" Name="Health_date" />
                <asp:Parameter Name="Attraction" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </asp:Content>
