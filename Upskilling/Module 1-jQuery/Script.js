$(document).ready(function () {

    $("#welcomeBtn").click(function () {
        const name = $("#studentName").val().trim();

        if (name === "") {
            $("#message").text("Please enter your name.");
        } else {
            $("#message").text("Welcome, " + name + "!");
        }
    });

    $("#loadBtn").click(function () {

        const courses = [
            "C# Programming",
            "Angular",
            "SQL"
        ];

        $("#courseList").empty();

        $.each(courses, function (index, course) {
            $("#courseList").append(
                $("<li>").text(course)
            );
        });
    });

    $("#title").hover(
        function () {
            $(this).css("color", "blue");
        },
        function () {
            $(this).css("color", "black");
        }
    );

});