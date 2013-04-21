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
});