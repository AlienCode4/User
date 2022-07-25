<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="CheckEmail.aspx.cs" Inherits="WebApiV5.WebPages.CheckEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       
                     <div class="container">

         <div    class="box">

                <form action="" class="box">
                    <br />  

                    <section class="checko d ut_area section_padding">
    <div class="container">
        
        <div class="billing_details">
        <div class="row">
             <h2>Choose User Email </h2>
            <div class="col-lg-8">
               
           
                     
                          <asp:Label runat="server" Text="" ID="ErrorLAbel"></asp:Label><br>
                        <br>
            <form class="row contact_form" class=" user-card" method="post" novalidate="novalidate"  id="myformIn"  >
                
                <input type="text" class="form-control" id="emailC" runat="server" name="address2" placeholder="New Email" />
                 <input type="text" class="form-control" id="password" runat="server" name="address2" placeholder="Password" />
                <input type="text" class="form-control" id="password2" runat="server" name="address2" placeholder="Confem Password" />

                </div>
                 
                <asp:Button ID="CheckoutEmail" runat="server" Text="Register" OnClick="btnCheckoutEmail_Click" />
                 </form>
            </div>
            </div>
        </div>
        </div>
    </div>
    </section>
                </form>
     </div>
                
    
</asp:Content>
