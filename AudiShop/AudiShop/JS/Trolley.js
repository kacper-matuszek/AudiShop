function RemovingItemFromTrolley() {
    $(".removeModel").click(function () {

        var rowToRemove = $(this).attr("data-id");

        if (rowToRemove != '') {
            $.post("/Trolley/RemoveFromTrolley", { "modelID": rowToRemove }, function (respons) {
                if (respons.CountToRemove == 0) {
                    $("#trolley-row-" + respons.IdPositionRemoving).fadeOut('slow', function () {
                        if (respons.CountPositionsOfTrolley == 0) {
                            $('#trolley-empty-message').removeClass('hidden');
                        }
                    });
                } else {
                    $("#trolley-count-positions-" + respons.IdPositionRemoving).text(respons.CountToRemove);
                }

                if (respons.CountPositionsOfTrolley == 0) {
                    $("#trolley-button-pay").addClass('hidden');
                    $("#TotalPrice").addClass('invisible');
                }

                $("#total-price-value").text(respons.TrolleyTotalPrice);
                $("#trolley-title-count-items").text(respons.CountPositionsOfTrolley);
            });

            return false;
        }
    });
}

$(document).ready(RemovingItemFromTrolley);