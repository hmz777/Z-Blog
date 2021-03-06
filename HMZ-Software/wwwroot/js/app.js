﻿$(document).ready(function () {
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

    $(document).on("click", "button[data-tab]", function () {
        let id = $(this).attr("data-tab");
        $("button[data-tab]").removeClass("active");
        $("ul[data-tabtarget]").removeClass("active");

        $(this).addClass("active");
        $(`ul[data-tabtarget=${id}]`).eq(0).addClass("active");
    });

    $(document).scroll(function () {
        if ($(this).scrollTop() > 0) {
            $(".Navigation").addClass("scrolled");
        } else {
            $(".Navigation").removeClass("scrolled");
        }
    });

    // topbar.config({
    //     autoRun: true,
    //     barThickness: 5,
    //     barColors: {
    //         '0': 'rgba(5, 56, 107, .7)',
    //         '.3': 'rgba(5, 56, 107, .7)',
    //         '1.0': 'rgba(5, 56, 107, .7)'
    //     },
    //     shadowBlur: 5,
    //     shadowColor: 'rgba(0, 0, 0, .5)',
    //     className: 'topbar',
    // });

    AOS.init({
        startEvent: 'DOMContentLoaded',
        once: true,
        duration: 700
    });

});

var observer, ObserverOptions, ObserverCallback, viewerJs;

//#region Blazor Helpers

window.BlazorHelpers = {

    ScrollTo: function (x, y) {
        window.scroll(x, y);
    },

    ScrollElementIntoView: function (id) {
        document.getElementById(id).scrollIntoView({ behavior: 'smooth' });
    },

    ObserveElement: function (blazorComponentInstance, root, rootMargin, threshold, target, methodIdentifier) {

        try {
            if (observer == null || ObserverOptions == null || ObserverCallback == null) {

                ObserverOptions = {
                    root: document.querySelector(root),
                    rootMargin: rootMargin,
                    threshold: threshold
                };

                ObserverCallback = function (entries, observer) {
                    blazorComponentInstance.invokeMethodAsync(methodIdentifier, { isIntersecting: entries[0].isIntersecting, elementId: entries[0].target.id });
                };

                observer = new IntersectionObserver(ObserverCallback, ObserverOptions);
            }

            observer.observe(document.querySelector(target));

            return true;

        } catch (e) {
            console.log(e);
            return false;
        }
    },

    DisposeOfObservableElement: function (target) {
        if (observer == null)
            return;

        observer.unobserve(document.querySelector(target));
        observer.disconnect();
        observer, ObserverOptions, ObserverCallback = null;
    },

    FocusElement: function (target) {
        document.querySelector(target).focus();
    },

    EmptyClicksHandler: function (SideNavReference) {

        $(document).on("click", function (e) {

            let ele = $(e.target);

            if (ele.parent().hasClass("input-wrapper")) {
                $(".input-wrapper").removeClass("input-wrapper--active");
                ele.parent().addClass("input-wrapper--active");
            }
            else {
                $(".input-wrapper").removeClass("input-wrapper--active");
            }

            if (ele.parents(".side-nav,.nav-toggler").length == 0 && !ele.hasClass("nav-toggler")) {
                SideNavReference.invokeMethodAsync("Hide");
            }
            else {
                if (ele.hasClass("nav-link") || ele.parent().hasClass("nav-link")) {
                    SideNavReference.invokeMethodAsync("Hide");
                }
            }

            e.stopPropagation();
        });
    },

    InitializeJsLibs: function () {
        Prism.highlightAllUnder(document.querySelector(".post-body"));

        viewerJs = new Viewer(document.querySelector(".post-body"), {
            navbar: true,
            toolbar: false,
            movable: true
        });
    },

    DestroyJsLibs: function () {
        if (viewerJs != null)
            viewerJs.destroy();
    },

    TopBarShow: function () { topbar.show(); },
    TopBarHide: function () { topbar.hide(); },

    SetTitle: function (title) {
        if (title.length != 0) {
            document.title = "Hamzi Alsheikh - Portfolio & Blog | " + title;
        }
        else {
            document.title = "Hamzi Alsheikh - Portfolio & Blog";
        }
        
    }
};
//#endregion