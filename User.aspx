<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Quiz_Project.User" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>User - Dashboard</title>

    <!-- Bootstrap core CSS-->
    <link href="new/css/bootstrap.min.css" rel="stylesheet" />
     <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <link rel="stylesheet" href="new/css/all.css" />
    <link rel="stylesheet" href="new/css/fontawesome.min.css" />
    <link rel="stylesheet" href="new/css/fontawesome.css" />

    <!-- Custom fonts for this template-->
    <link href="new/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Page level plugin CSS-->
    
    <!-- Custom styles for this template-->
    <link href="new/css/sb-admin.css" rel="stylesheet" />
    
</head>
<body id="page-top">
    <form id="form1" runat="server">
         <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

      <a class="navbar-brand mr-1" href="SAdmin.aspx">
          <asp:Label runat="server" ID="lluser" Text=""></asp:Label>
      </a>

      <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" href="#">
        <i class="fas fa-bars"></i>
      </button>

     
    </nav>

    <div id="wrapper">

      <!-- Sidebar -->
      <ul class="sidebar navbar-nav">
        <li class="nav-item active">
          <a class="nav-link" href="SAdmin.aspx">
            <i class="fas fa-fw fa-tachometer-alt"></i>
            <span>Dashboard</span>
          </a>
        </li>
        
        <%--<li class="nav-item">
          <a class="nav-link" href="ShowResult.aspx">
            <i class="fas fa-fw fa-chart-area"></i>
            <span>Show Result</span></a>
        </li>
       --%>
        <li class="nav-item">
          <a class="nav-link" href="logout.aspx">
            <i class="fas fa-fw fa-sign-out-alt"></i>
            <span>Logout</span></a>
        </li>
      </ul>

      <div id="content-wrapper">

        <div class="container-fluid">

          <!-- Breadcrumbs-->
          <ol class="breadcrumb">
            <li class="breadcrumb-item">
              <a href="#">Dashboard</a>
            </li>
            
          </ol>

          <!-- Icon Cards-->
          <div class="row">
           
            <div class="col-xl-3 col-sm-6 mb-3">
              <div class="card text-white bg-warning o-hidden h-100">
                <div class="card-body">
                  <div class="card-body-icon">
                    <i class="fas fa-fw fa-list"></i>
                  </div>
                  <div class="mr-5"> 
                      <asp:Label ID="lbltest" runat="server" Text=""></asp:Label> Available Tests !</div>
                  </div>
                   <a class="card-footer text-white clearfix small z-1" href="#">
                 
                  <span class="float-right">
                   
                  </span>
                </a>
                </div>
                
              </div>
            </div>
          </div>

        <!--Add new test -->
          <div class="card mb-3">
            <div class="card-header">
              <i class="fas fa-chart-area"></i>
              Attempt Test
               
            </div>
            <div class="card-body">
              <div class="row">
                  
                <div class="col-lg-12">
                     
                     
                     <table class="table">
                        <tr>
                             <td>Select Test Name : </td>
                             <td >
                                  <asp:DropDownList ID="DropDownList1" CssClass="btn-outline-dark" runat="server" Height="27px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="320px">
                        
                    </asp:DropDownList>

                             </td>
                            
                            <td>
                                <asp:Button runat="server" ID="btnattempt" CssClass="btn  btn-success" Text="Attempt Test" OnClick="btnattempt_Click" />
                            </td>
                         </tr>

                         
                     </table>
                       
                  
                </div>
                  
                
               
            
          </div>
            </div>
           
          </div>
         





         
       
        <!-- /.container-fluid -->

        <!-- Sticky Footer -->
        <footer class="sticky-footer">
          <div class="container my-auto">
            <div class="copyright text-center my-auto">
              <span>Copyright © Your Website 2018</span>
            </div>
          </div>
        </footer>

      </div>
      <!-- /.content-wrapper -->

    </div>
    <!-- /#wrapper -->

    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
      <i class="fas fa-angle-up"></i>
    </a>

    <!-- Logout Modal-->
   

    <!-- Bootstrap core JavaScript-->
    <script src="new/js/jquery.min.js"></script>
    <script src="new/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="new/js/jquery.easing.min.js"></script>

    <!-- Page level plugin JavaScript-->
    <script src="new/js/Chart.min.js"></script>
    <script src="new/js/jquery.dataTables.js"></script>
    <script src="new/js/dataTables.bootstrap4.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="new/js/sb-admin.min.js"></script>

    <!-- Demo scripts for this page-->
    <script src="new/js/datatables-demo.js"></script>
    <script src="new/js/chart-area-demo.js"></script>

    </form>
</body>
</html>
