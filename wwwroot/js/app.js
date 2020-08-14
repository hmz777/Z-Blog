$(document).ready(function () {
    $('a[href*="#"]')
        .not('[href="#"]')
        .not('[href="#0"]')
        .not('[role="tab"]')
        .click(function (event) {
            if (
                location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
                &&
                location.hostname == this.hostname
            ) {
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');

                if (target.length) {

                    event.preventDefault();
                    $('html, body').animate({
                        scrollTop: target.offset().top
                    }, 1000, function () {

                        var $target = $(target);
                        $target.focus();
                        if ($target.is(":focus")) {
                            return false;
                        } else {
                            $target.attr('tabindex', '-1');
                            $target.focus();
                        };
                    });
                }
            }
        });


    $("button[data-tab]").click(function () {
        let id = $(this).attr("data-tab");

        $("button[data-tab]").removeClass("active");
        $("tech-content").children().removeClass("active");

        $(this).addClass("active");
        $("tech-content").children(`li[id=${id}]`).eq(0).addClass("active");
    });
});