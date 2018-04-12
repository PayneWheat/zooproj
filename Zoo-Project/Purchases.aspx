<%@ Page Title="Purchases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductCatalog.aspx.cs" Inherits="ProductCatalog" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Receipt" DataSourceID="ZooDatabase" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Pay_optionLabel" runat="server" Text='<%# Eval("Pay_option") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
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
                        <asp:Label ID="ReceiptLabel1" runat="server" Text='<%# Eval("Receipt") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TimeTextBox" runat="server" Text='<%# Bind("Time") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Pay_optionTextBox" runat="server" Text='<%# Bind("Pay_option") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StoreTextBox" runat="server" Text='<%# Bind("Store") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CustomerTextBox" runat="server" Text='<%# Bind("Customer") %>' />
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
                        <asp:TextBox ID="ReceiptTextBox" runat="server" Text='<%# Bind("Receipt") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TimeTextBox" runat="server" Text='<%# Bind("Time") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Pay_optionTextBox" runat="server" Text='<%# Bind("Pay_option") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="StoreTextBox" runat="server" Text='<%# Bind("Store") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CustomerTextBox" runat="server" Text='<%# Bind("Customer") %>' />
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
                        <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Pay_optionLabel" runat="server" Text='<%# Eval("Pay_option") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
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
                                    <th runat="server">Receipt</th>
                                    <th runat="server">Time</th>
                                    <th runat="server">Amount</th>
                                    <th runat="server">Pay_option</th>
                                    <th runat="server">Date</th>
                                    <th runat="server">Store</th>
                                    <th runat="server">Customer</th>
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
                        <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AmountLabel" runat="server" Text='<%# Eval("Amount") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Pay_optionLabel" runat="server" Text='<%# Eval("Pay_option") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StoreLabel" runat="server" Text='<%# Eval("Store") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CustomerLabel" runat="server" Text='<%# Eval("Customer") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="ZooDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [PURCHASE] WHERE [Receipt] = @Receipt" InsertCommand="INSERT INTO [PURCHASE] ([Receipt], [Time], [Amount], [Pay_option], [Date], [Store], [Customer]) VALUES (@Receipt, @Time, @Amount, @Pay_option, @Date, @Store, @Customer)" SelectCommand="SELECT * FROM [PURCHASE]" UpdateCommand="UPDATE [PURCHASE] SET [Time] = @Time, [Amount] = @Amount, [Pay_option] = @Pay_option, [Date] = @Date, [Store] = @Store, [Customer] = @Customer WHERE [Receipt] = @Receipt">
            <DeleteParameters>
                <asp:Parameter Name="Receipt" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Receipt" Type="Int32" />
                <asp:Parameter DbType="Time" Name="Time" />
                <asp:Parameter Name="Amount" Type="Decimal" />
                <asp:Parameter Name="Pay_option" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Date" />
                <asp:Parameter Name="Store" Type="Int32" />
                <asp:Parameter Name="Customer" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter DbType="Time" Name="Time" />
                <asp:Parameter Name="Amount" Type="Decimal" />
                <asp:Parameter Name="Pay_option" Type="Int32" />
                <asp:Parameter DbType="Date" Name="Date" />
                <asp:Parameter Name="Store" Type="Int32" />
                <asp:Parameter Name="Customer" Type="Int32" />
                <asp:Parameter Name="Receipt" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
<p>
    <asp:ListView ID="ListView2" runat="server" DataKeyNames="Receipt,Product" DataSourceID="Zoo2" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductLabel" runat="server" Text='<%# Eval("Product") %>' />
                </td>
                <td>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                </td>
                <td>
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
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
                    <asp:Label ID="ReceiptLabel1" runat="server" Text='<%# Eval("Receipt") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductLabel1" runat="server" Text='<%# Eval("Product") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                </td>
                <td>
                    <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
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
                    <asp:TextBox ID="ReceiptTextBox" runat="server" Text='<%# Bind("Receipt") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ProductTextBox" runat="server" Text='<%# Bind("Product") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                </td>
                <td>
                    <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
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
                    <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductLabel" runat="server" Text='<%# Eval("Product") %>' />
                </td>
                <td>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                </td>
                <td>
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
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
                                <th runat="server">Receipt</th>
                                <th runat="server">Product</th>
                                <th runat="server">Price</th>
                                <th runat="server">Quantity</th>
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
                    <asp:Label ID="ReceiptLabel" runat="server" Text='<%# Eval("Receipt") %>' />
                </td>
                <td>
                    <asp:Label ID="ProductLabel" runat="server" Text='<%# Eval("Product") %>' />
                </td>
                <td>
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                </td>
                <td>
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Zoo2" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [PURCHASE_INFO] WHERE [Receipt] = @Receipt AND [Product] = @Product" InsertCommand="INSERT INTO [PURCHASE_INFO] ([Receipt], [Product], [Price], [Quantity]) VALUES (@Receipt, @Product, @Price, @Quantity)" SelectCommand="SELECT * FROM [PURCHASE_INFO]" UpdateCommand="UPDATE [PURCHASE_INFO] SET [Price] = @Price, [Quantity] = @Quantity WHERE [Receipt] = @Receipt AND [Product] = @Product">
        <DeleteParameters>
            <asp:Parameter Name="Receipt" Type="Int32" />
            <asp:Parameter Name="Product" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Receipt" Type="Int32" />
            <asp:Parameter Name="Product" Type="Int32" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="Quantity" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Receipt" Type="Int32" />
            <asp:Parameter Name="Product" Type="Int32" />
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
    <asp:SqlDataSource ID="Zoo3" runat="server" ConnectionString="<%$ ConnectionStrings:zooConnectionString %>" DeleteCommand="DELETE FROM [PAY_TYPE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [PAY_TYPE] ([ID], [Name]) VALUES (@ID, @Name)" SelectCommand="SELECT * FROM [PAY_TYPE]" UpdateCommand="UPDATE [PAY_TYPE] SET [Name] = @Name WHERE [ID] = @ID">
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
