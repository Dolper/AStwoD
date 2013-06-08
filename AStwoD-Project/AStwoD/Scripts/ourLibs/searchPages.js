$(function () {
    $("#search").keyup(function () {
        var search = $("#search").val();
        $.ajax({
            type: "POST",
            url: "pages",
            data: { "search": search },
            cache: false,
            success: function (response) {
                var html;
                console.log(response);
                for (var i = 0; i < response.length; i++) {
                    if (response[i] != undefined)
                        html += "<li>" + response[i].Title + "</li>";
                }
                $("#resSearch").html(html);
            }
        });
        return false;
    });
});