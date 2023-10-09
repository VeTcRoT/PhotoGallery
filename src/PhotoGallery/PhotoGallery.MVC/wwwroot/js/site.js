
$(document).ready(function () {

    function imageRatings() {
        $(".image-rating").each(function () {
            var $thumbsUpIcon = $(this).find(".fa-thumbs-up");
            var $thumbsDownIcon = $(this).find(".fa-thumbs-down");
            var $likesCounter = $(this).find(".text-success");
            var $dislikesCounter = $(this).find(".text-danger");

            $thumbsUpIcon.click(function () {
                toggleRating(true, $thumbsUpIcon, $likesCounter, $thumbsDownIcon, $dislikesCounter);
            });

            $thumbsDownIcon.click(function () {
                toggleRating(false, $thumbsDownIcon, $dislikesCounter, $thumbsUpIcon, $likesCounter);
            });
        });
    }

    imageRatings()

    function toggleRating(isLike, $clickedIcon, $counter, $otherIcon, $otherCounter) {
        var userId = $clickedIcon.data("userid");
        var imageId = $clickedIcon.data("imageid");

        var requestData = {
            ImageId: imageId,
            UserId: userId,
            IsLike: isLike
        };

        $.ajax({
            url: '/api/rate',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            success: function () {
                if ($clickedIcon.hasClass("fa-solid")) {
                    $clickedIcon.removeClass("fa-solid").addClass("fa-regular");
                    $counter.text(parseInt($counter.text()) - 1);
                } else {
                    $clickedIcon.removeClass("fa-regular").addClass("fa-solid");
                    $counter.text(parseInt($counter.text()) + 1);
                }

                if ($otherIcon.hasClass("fa-solid")) {
                    $otherIcon.removeClass("fa-solid").addClass("fa-regular");
                    $otherCounter.text(parseInt($otherCounter.text()) - 1);
                }

                console.log("Rating sent successfully!");
            },
            error: function () {
                console.error("Error sending rating.");
            }
        });
    }
});

function openImageModal(e) {
    modalImage.src = e.target.getAttribute('src');

    $('#imageModal').modal('show');
}