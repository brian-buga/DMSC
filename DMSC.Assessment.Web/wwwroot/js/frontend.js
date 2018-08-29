
jQuery(document).ready(function ($) {
   
    $(document).on("click", "#like", function (e)
    {
        e.preventDefault();        
       
        var ajaxPost = $.post($("#createUrl").attr("data-createUrl"), { articleId: $(this).attr("data-articleId") });

        ajaxPost.done(function (data)
        {
            $("#like span").text(data);          
        });

        ajaxPost.fail(function (data) {
            console.log(data);
        });
    });
});