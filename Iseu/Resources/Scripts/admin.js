$(function () {
    $('#set-role').on('change', function () {
        var u = $(this).val();
        $.get(u);
        return true;
    });
    
});