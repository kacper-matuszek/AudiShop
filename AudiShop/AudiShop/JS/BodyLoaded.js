function SetHeightToAnotherEl()
{
    var _heightEl = document.getElementsByClassName('LayoutHeader')[0].clientHeight;
                
    var _heightToAnotherEl = _heightEl + 300; 
                
    document.getElementsByClassName('Wallpaper')[0].style.height = _heightToAnotherEl + 'px';
}

function expandMenu() {
    var element = document.getElementsByClassName("arrow")[0];

    if (element.classList.contains("fa-arrow-down")) {
        element.classList.remove("fa-arrow-down");
        element.classList.add("fa-arrow-up");
        return;
    }

    element.classList.remove("fa-arrow-up");
    element.classList.add("fa-arrow-down");
}

$(document).ready(function () {
    $(".arrow").click(function () {
        $(".VerticalContent").toggleClass("slide-out");
        $(".VerticalContent").toggleClass("slide-in");
    });
});