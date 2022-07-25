<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApiV5.WebPages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br/><br/>

                         <form  action="#" method="post" novalidate="novalidate" id="form1" >
                             <div>
                                <div >
                                   
                                  <asp:TextBox  name="username" value="" id="Email" placeholder="Email" runat="server"></asp:TextBox>
                                </div>

                                <div>
                                    <input type="password"  id="password" name="password" value=""
                                        placeholder="Password" runat="server">
      
                                </div>

                                <div >
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button>

                                 </div>
                                 </div>
                            </form>
</asp:Content>
