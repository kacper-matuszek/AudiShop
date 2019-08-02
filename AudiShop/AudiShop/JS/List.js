$(document).ready(function () {
    ToggleMenu();
});

function ToggleMenu() {
    $(".CollapseContent").hide();
    $(".Collapsable").children("div").addClass("changed");
    $(".Collapsable").on("click", function () {
        $(this).next("div").slideToggle("slow");
        $(this).children("div").toggleClass("changed");
    });
    
}