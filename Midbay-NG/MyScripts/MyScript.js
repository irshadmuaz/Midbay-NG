$(function () {
    $("#toggler").click(function () {
       
        $(this).css("display", "none");
        $("#navlist").animate({ width: "170px" }, 200);
    })
    $("#navlist i").click(function () {
        $("#navlist").css("width", "0");
        $("#toggler").css("display", "block");
        
    })
})