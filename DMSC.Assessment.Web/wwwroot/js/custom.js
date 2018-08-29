
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

    $(document).on("click", "#like", function (e)
    {
        e.preventDefault();

        alert($(this).attr("data-articleId"));
       
        var ajaxPost = $.post($("#createUrl").attr("data-createUrl"), { id: $(this).attr("data-articleId") });

        ajaxPost.done(function (data) {
            console.log(data);
        });

        ajaxPost.fail(function (data) {
            console.log(data);
        });
    });
});