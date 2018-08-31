
jQuery(document).ready(function ($)
{
    $("#Published").datepicker({ dateFormat: 'dd/mm/yy' });

    $(document).on("click", ".delete", function (e)
    {
        e.preventDefault();

        var $articleId = $(this).attr("data-articleId");
       
        var _target = $.post($("#deleteUrl").attr("data-deleteUrl"), { id: $articleId });

        _target.done(function (data)
        {           
            $("#" + $articleId).remove();             
        }); 

        _target.fail(function (data) {
            console.log(data);
        }); 
    });

    $(document).on("click", "#like", function (e)
    {
        e.preventDefault();
             
        var _target = $.post($("#createUrl").attr("data-createUrl"), { id: $(this).attr("data-articleId") });

        _target.done(function (data) {
            console.log(data);
        });

        _target.fail(function (data) {
            console.log(data);
        });
    });
});