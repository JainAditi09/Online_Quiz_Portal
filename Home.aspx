<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Quiz_Project.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="new/css/home.css"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <script src="new/js/home1.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <title>Test</title>
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
    <form id="form1" runat="server" class="bgimg"  >
          
<header class="header">
    <nav class="navbar navbar-expand-lg fixed-top py-3">
        <div class="container">
            <button type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" class="navbar-toggler navbar-toggler-right"><i class="fa fa-bars"></i></button>
            
            <div id="navbarSupportedContent" class="collapse navbar-collapse">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item active"><a href="#" class="nav-link text-uppercase font-weight-bold">Home <span class="sr-only">(current)</span></a></li>&nbsp;
                    <li class="nav-item " >
                        <div class="dropdown show transparentbar" style="z-index:4" >
                          <a  href="#" class="btn btn-outline-success nav-link text-uppercase font-weight-bold" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="color:white;border:none">
                            Login
                          </a>

                          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink" style="color:black">
                            <a class="dropdown-item  text-uppercase font-weight-bold" href="login.aspx">Admin Login</a>
                            <a class="dropdown-item text-uppercase font-weight-bold" href="login.aspx">User Login</a>
                           
                          </div>
                        </div>
                    </li>&nbsp;
                    <li class="nav-item"><a href="#" class="nav-link text-uppercase font-weight-bold">Contact</a></li>
                </ul>
            </div>
        </div>
    </nav>
</header>


    <!-- For demo purpose -->
        <div class="container">
            <div class="pt-5 text-white">
        
                
        
            </div>
        </div>
         <div class="w3-display-middle">
            <h2 class="w3-jumbo w3-animate-top">Online Placement Test</h2>
            <hr class="w3-border-grey" style="margin: auto; width: 40%">
             <%--<asp:Button ID="Button1" class="btn btn-outline-success btn-lg btn-center" runat="server" Text="Enter Test" OnClick="Button1_Click" />--%>
              <%--<button type="button" class="btn btn-outline-success btn-lg btn-center"><a href="login.aspx" style="color:antiquewhite;text-decoration: none;"><strong>Enter Test</strong></a></button>--%>
        </div>
       
    </form>
</body>
</html>
