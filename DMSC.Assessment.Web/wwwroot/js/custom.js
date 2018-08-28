
jQuery(document).ready(function ($)
{
    $("#Published").datepicker({ dateFormat: 'dd/mm/yy' });

    $(document).on("click", ".delete", function (e)
    {
        e.preventDefault();

        var $articleId = $(this).attr("data-articleId");
       
        var ajaxPost = $.post($("#deleteUrl").attr("data-deleteUrl"), { id: $articleId });

        ajaxPost.done(function (data)
        {           
            $("#" + $articleId).remove();             
        }); 

        ajaxPost.fail(function (data) {
            console.log(data);
        }); 
    });
});