
jQuery(document).ready(function ($)
{
    $("#Published").datepicker({ dateFormat: 'dd/mm/yy' });

    $(document).on("click", ".delete", function (e)
    {
        e.preventDefault();

        var $articleId = $(this).attr("data-articleId");
       
        var promise = $.post($("#deleteUrl").attr("data-deleteUrl"), { id: $articleId });

        promise.done(function (data)
        {           
            $("#" + $articleId).remove();             
        }); 

        promise.fail(function (data) {
            console.log(data);
        }); 
    });
});