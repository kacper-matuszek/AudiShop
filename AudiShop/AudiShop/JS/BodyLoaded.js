function SetHeightToAnotherEl()
{
    var _heightEl = document.getElementsByClassName('LayoutHeader')[0].clientHeight;
                
    var _heightToAnotherEl = _heightEl + 300; 
                
    document.getElementsByClassName('Wallpaper')[0].style.height = _heightToAnotherEl + 'px';
}