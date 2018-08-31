
jQuery(document).ready(function ($) {
   
    $(document).on("click", "#like", function (e)
    {
        e.preventDefault();        
       
        var _target = $.post($("#createUrl").attr("data-createUrl"), { articleId: $(this).attr("data-articleId") });

        _target.done(function (data)
        {
            $("#like span").text(data);          
        });

        _target.fail(function (data) {
            console.log(data);
        });
    });
});