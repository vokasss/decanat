$(function () {
    var InitErrorFunction;
    $(".b-modal").on('click', function () {
        var u = $(this).attr('href');
        $.get(
            u,
            function (json) {

                var content = createElement();
                content.append(json.view);
                content.arcticmodal();
                InitErrorFunction = function () {
                    $('#register-submit').on('click', function () {
                        var u = $('#register-form').attr('action');
                        var data = $('#register-form').serializeArray();
                        $.post(
                            u,
                            data,
                            function (json) {
                                if (json.success == 0) {
                                    $.arcticmodal('close');
                                    $('#myId').remove();
                                    var content = createElement();
                                    content.append(json.view);
                                    content.arcticmodal();
                                    InitErrorFunction();
                                }
                                else {
                                    window.location = "/";
                                }
                            }
                        );
                        return false;
                    });
                };
                InitErrorFunction();
            });
        return false;
    });
    var createElement = function () {
        var el = $('<div>', {
            id: 'myId',
            class: 'myClass'
        });
        return el;
    };

    $(document).on('ready', function () {
        var content = createElement();
        content.html($('#modal').val());
        content.css('color', 'azure');
        if (content.html() != "") {
            content.arcticmodal();
        }
    });

    $('.modal').on('click', function () {
        var u = $(this).attr('href');
        $.get(
           u,
           function (json) {
               var content = createElement();
               content.append(json.view);
               content.arcticmodal();
           });
        return false;
    });

    $('.dropdownlist').on('change', function () {
        var value = $(this).val();
        $(this).children().removeAttr('selected');
        $(this).find('option[value=' + value+']').attr('selected', 'selected');
    });
    $('li').on('click', function () {
        $(this).find('input[type=radio]').attr('checked', 'checked');
    });
});