function RemovingItemFromTrolley() {
    $(".removeModel").click(function () {

        var rowToRemove = $(this).attr("data-id");

        if (rowToRemove !== '') {
            $.post("/Trolley/RemoveFromTrolley", { "modelID": rowToRemove }, function (respons) {
                if (respons.CountToRemove === 0) {
                    $("#trolley-row-" + respons.IdPositionRemoving).slideUp('slow', function () {
                        if (respons.CountPositionsOfTrolley === 0) {
                            $('#trolley-empty-message').removeClass('hidden');
                            $("#TotalPrice").css({ "display": "none" });
                            $("#trolley-button-pay").css({ "display": "none" });
                        }
                    });
                } else {
                    $("#trolley-count-positions-" + respons.IdPositionRemoving).text(respons.CountToRemove);
                }

                if (respons.CountPositionsOfTrolley === 0) {
                    $("#trolley-button-pay").addClass('hidden');
                   // $("#TotalPrice").addClass('invisible');
                }

                $("#total-price-value").text(respons.TrolleyTotalPriceString);
                $("#trolley-title-count-items").text(respons.CountPositionsOfTrolley);
            });

            return false;
        }
    });
}

$(document).ready(RemovingItemFromTrolley);