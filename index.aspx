<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Quiz_Project.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link  rel="stylesheet" href="new/css/login.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  
    <title>Registration</title>
</head>

    <style>
    body, h1 {
        font-family: "Raleway", sans-serif;
    }

    body, html {
        height: 100%;
        color:black !important;
    }

    .bgimg {
        background-image: url('/Images/intro-bg.jpg');
        min-height: 100%;
        background-position: center;
        background-size: cover;
        color:black !important;
    }
</style>
<body>
    <form id="form1" class="bgimg" runat="server">

     <div class="wrapper fadeInDown">
          <div id="formContent">
            <!-- Tabs Titles -->

            <!-- Icon -->
            <div class="fadeIn first">
                <br />
              <h3>Register</h3>
            </div>

            <!-- Login Form -->
            
               <%-- Username --%>
                 <asp:TextBox ID="txtname" class="fadeIn second" placeholder="Username" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ControlToValidate="txtname"></asp:RequiredFieldValidator>
               
              

              <%-- Email --%>
               <asp:TextBox ID="txtmail" class="fadeIn second" runat="server" placeholder="Email"></asp:TextBox><br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtmail"></asp:RegularExpressionValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmail"></asp:RequiredFieldValidator>
                <%--<asp:Label ID="lblpass" runat="server" Text="Password"></asp:Label>--%>
                
              
              <%-- Password --%>
              <asp:TextBox ID="txtpass" class="fadeIn third" runat="server" TextMode="Password" placeholder="Password" ></asp:TextBox><br />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
             
              
              <%-- Confirm Password --%>
               <asp:TextBox ID="confirm" class="fadeIn third"  runat="server" TextMode="Password"  placeholder="Confirm Password" ></asp:TextBox><br />
         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesn't match " ValueToCompare="txtpass" ControlToValidate="confirm" ControlToCompare="txtpass"></asp:CompareValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password is required" ControlToValidate="confirm" ></asp:RequiredFieldValidator>


              <%-- Submit Button --%>
                <asp:Button ID="submit"  class="fadeIn fourth" runat="server" Text="Submit" OnClick="submit_Click"  />


            <!-- Remind Passowrd -->
            <div id="formFooter">
              <a class="underlineHover" href="login.aspx">Already have an account?</a>
                 <a class="underlineHover" href="Home.aspx">Back</a>
            </div>

          </div>
        </div>
    </form>
</body>
</html>
