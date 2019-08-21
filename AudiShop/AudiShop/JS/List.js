$(document).ready(function () {
    ToggleMenu();
    $(".LayoutCategories").addClass("LayoutList");
    $(function () {
        var setupAutoComplete = function () {
            var $input = $(this);

            var options = {
                source: $input.attr("data-autocomplete-source"),
                select: function (event, ui) {
                    $input = $(this);
                    $input.val(ui.item.label);
                    var $form = $input.parents("form:first");
                    $form.submit();
                }
            };
            $input.autocomplete(options);
        };
        var ajaxSubmit = function () {
            var $form = $(this);

            var settings = {
                data: $(this).serialize(),
                url: $(this).attr("action"),
                type: $(this).attr("method")
            };

            $.ajax(settings).done(function (result) {
                var $targetElement = $($form.data("ajax-target"));
                var $newContent = $(result);
                $($targetElement).replaceWith($newContent);
                $newContent.effect("slide");
            });

            return false;
        };

        $("#search-filter").each(setupAutoComplete);
        $("#search-form").submit(ajaxSubmit);
    });
});
function ToggleMenu() {
    $(".CollapseContent").hide();
    $(".Collapsable").children("div").addClass("changed");
    $(".Collapsable").on("click", function () {
        $(this).next("div").slideToggle("slow");
        $(this).children("div").toggleClass("changed");
    });

}