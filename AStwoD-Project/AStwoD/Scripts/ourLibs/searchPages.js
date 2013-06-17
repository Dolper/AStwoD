$      $(function () {

    $("#search").keyup(function () {
        $("#resSearch").empty();
        var title = $("#search").val();

        $.ajax({
            type: "POST",
            url: "@Url.Action("Search")",
            data: { "Title": title },
        cache: false,
        success: function (response) {
            console.log(typeof (response));
            if (typeof (response) === 'object') {
                for (var i in response) {
                    // if (pages[i] != response[i].Title) {
                    //    pages[i] = response[i].Title;
                    $("#resSearch").prepend("<li><a href=" + response[i].LabelForURL + ">" + response[i].Title + "</a></li>");
                    // }

                }
            }
        }
    });
    return false;
});
});