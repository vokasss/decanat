$(function () {
    $('.add-subject').on('click', function () {
        var u = "/Syllabus/GetSubject",
            el = $(this),
            discdrop = el.parent().find('.disc'),
            profdrop = el.parent().find('.professor');
        $.get(
          u,
          { stitle: discdrop.val(), pid: profdrop.val() },
          function (json) {
              var div = $('<div></div>');
              div.html(discdrop.val() + '      ' + profdrop.text());
              var inp = $('<input type=hidden name=Syllabus value=' + json.id + '>');
              div.insertAfter(el.parent().find('button'));
              inp.insertBefore(el.parent().find('p'));
          });
        return false;
    });

    $('.add-specs').on('click', function () {
        var el = $(this),
            specsdrop = el.parent().find('.specs');

        var div = $('<div></div>');
        div.text(specsdrop.text());
        var inp = $('<input type=hidden name=Speciality value=' + specsdrop.val() + '>');
        div.insertAfter(el.parent().find('button'));
        inp.insertBefore(el.parent().find('p'));
        specsdrop.find('option[value=' + specsdrop.val() + ']').remove();
        if (specsdrop.find('option').size() == 0) {
            el.remove();
            specsdrop.remove();
        }
        return false;
    });

    $('#add-button').on('click', function (e) {
        var form = $('.add');

        var n = form.find('.semester').size();
        var data = new Array(n);
        for (i = 0; i < n; i++)
        {
            var arr = new Array();
            form.find('.semester').eq(i).find('input[type=hidden][name=Syllabus]').each(function () {
                if ($(this).val() != null && $.inArray($(this).val(), arr) == -1)
                    arr.push($(this).val());
            });

            data[i] = arr;
        }

        var specs = new Array();
        $('input[type=hidden][name=Speciality]').each(function () {
            if ($(this).val() != null && $.inArray($(this).val(), specs) == -1)
            specs.push($(this).val());
        });

        $.post(
          form.data('action'),
          {Json : JSON.stringify({ 'Syllabus1': data, 'Specialities': specs })},
        function () {
            location.href = location.host;
        });
        return true;
    });
});