<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AddImageSlider.aspx.cs" Inherits="Admin_AddImageSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!----->


    <div class="grid-form">
        <div class="grid-form1">
            <h3 id="forms-example" class="">Basic Form</h3>
           
                <div class="form-group">
                   <asp:FileUpload ID="FileUploadNewSliderImg" runat="server" />
                                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" Text="" />
                </div>
               
                
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-default" OnClick="btnSubmit_Click" />
            
        </div>
        <!----->

        <!---->

        <!---->



        <!---->
        
    </div>


</asp:Content>

