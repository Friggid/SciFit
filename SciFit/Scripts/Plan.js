$(document).ready(function () {
    $(".btn-pref .btn").click(function () {
        console.log('button clickerd');
        $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
        // $(".tab").addClass("active"); // instead of this do the below 
        $(this).removeClass("btn-default").addClass("btn-primary");
    });
});