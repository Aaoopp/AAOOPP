<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>We add art into pixels | AOP</title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery-1.11.0.min.js"></script>
    <!-- Custom Theme files -->
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />

    <!-- Custom Theme files -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="application/x-javascript"> 
        addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); 
        function hideURLbar(){ window.scrollTo(0,1); }
    </script>
    <meta name="keywords" content="We Photography Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <!--Google Fonts-->
    <link href='//fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'>
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>
    <!-- start-smoth-scrolling -->
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    <!-- //end-smoth-scrolling -->
    <script src="js/bootstrap.min.js"></script>
    <style>
        .portrait {
            height: 80px;
            width: 30px;
        }
    </style>
    <link rel="stylesheet" href="NivoSlider/themes/default/default.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/light/light.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/dark/dark.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/themes/bar/bar.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="NivoSlider/nivo-slider.css" type="text/css" media="screen" />
    <%--<link rel="stylesheet" href="NivoSlider/demo/style.css" type="text/css" media="screen" />--%>
    <link href="NivoSlider/nivo-slider.css" rel="stylesheet" />



    <script src="NivoSlider/jquery.nivo.slider.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>

</head>
<body>
    <!--header start here-->
    <!-- NAVBAR
		================================================== -->
    <form runat="server">
        <div class="header">
            <div class="fixed-header">
                <div class="navbar-wrapper">
                    <div class="container">
                        
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <!--header end here-->
        <div id="wrapper">
            <div class="slider-wrapper theme-default">
                <div id="slider" class="nivoSlider">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AOPConnectionString %>"
                                SelectCommand="SELECT [Id], [SliderImage] FROM [Slider_Image]"></asp:SqlDataSource>
                            <asp:Repeater ID="RptSlider" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="RptSlider_ItemDataBound">
                                <ItemTemplate>
                                   
                                        <%--<asp:Image ID="imgTeam" runat="server" />--%>
                                        <%--<img src alt="" width="" height="" />--%>
                                      <%--  <asp:HiddenField Value='<%# Eval("id") %>' ID="HiddenFieldSliderid" runat="server" />
                                        <asp:Image ID="imgSlider"  runat="server" />--%>
                                        <%--<asp:Image ID="imgTeam" runat="server" ImageUrl=""~/ShowImage.ashx?id=" + <%#Eval("ID") %>""/>--%>
                                  
                                </ItemTemplate>
                            </asp:Repeater>
                           
                    <img src="NivoSlider/demo/images/toystory.jpg" data-thumb="NivoSlider/demo/images/toystory.jpg" alt="" />
                    <img src="NivoSlider/demo/images/walle.jpg" data-thumb="NivoSlider/demo/images/ganesh2.jpg" alt="" data-transition="slideInLeft" />
                    <img src="NivoSlider/demo/images/nemo.jpg" data-thumb="NivoSlider/demo/images/ganesh2.jpg" alt="" title="#htmlcaption" />
                    <img src="NivoSlider/demo/images/wedding2.jpg" data-thumb="NivoSlider/demo/images/ganesh2.jpg" alt="" />
                    <img src="NivoSlider/demo/images/ganesh2.jpg" data-thumb="NivoSlider/demo/images/ganesh2.jpg" alt="" />
                </div>
                <%--<div id="htmlcaption" class="nivo-html-caption"><strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>. </div>--%>
            </div>
        </div>
        <%--<div >
    <img src="images/ganesh2.jpg"  />
  <%--<div class="container">--%>
        <%--<div class="banner-main" id="home">--%>
        <%--	 <div class="bann-right">
		 	<h1>We are Professional in</h1>
		 	<h2>Photography</h2>
		 	<p>We each try to keep our photo shoots loose and relaxed and geared toward you all having fun together as a family. </p>
		 	<img src="images/ftr-logo.png" alt=""/>
		 </div>
		<div class="clearfix"> </div>
    </div>
  </div>
</div>--%>

        <div class="footer">
            <div class="container">
                <div class="footer-main">
                    <div class="footer-left">
                        <a href="#">
                            <img src="images/ftr-logo.png" alt="" /></a>
                    </div>
                    <div class="footer-right">
                        <p>&copy; 2015 We Photography. All Rights Reserved | Template by <a href="http://w3layouts.com/" target="_blank">W3layouts</a></p>
                    </div>
                </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        /*
                        var defaults = {
                            containerID: 'toTop', // fading element id
                            containerHoverID: 'toTopHover', // fading element hover id
                            scrollSpeed: 1200,
                            easingType: 'linear' 
                        };
                        */

                        $().UItoTop({ easingType: 'easeOutQuart' });

                    });
                </script>
                <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>
            </div>
        </div>
        <!--footer end here-->
    </form>
</body>
</html>


