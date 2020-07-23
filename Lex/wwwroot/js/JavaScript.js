$(document).ready(
    function () {

        $("#bb").click(function () {
            $("#bb").remove();
        }

            
        );
        $("#b1").click(function () {
            $("#bb").append("<p> hello </p>")
        });

        $(".cart").mouseenter(function () {

            $(".cart").css("color","#f68b1e");
        });
        $(".cart").mouseleave(function () {

            $(".cart").css("color", "#fff");
        });
    }
  
);