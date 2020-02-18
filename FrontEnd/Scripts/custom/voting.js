$(document).ready(function () {
    $('.btn-upvote').on('click', function (e) {
        var parent = $(e.target).closest('.list-group-item');
        var score = parent.find('.score');
        var id = parent.data('id');
        var button = $(e.target).closest('.btn-upvote');

        $.post('/Submissions/UpVote/?id=' + id)
            .done(function (data) {
                console.log(score);
                score.html(data);

                button.removeClass('btn-light');
                button.addClass('btn-success');
            });
    });

    $('.btn-downvote').on('click', function (e) {
        var parent = $(e.target).closest('.list-group-item');
        var score = parent.find('.score');
        var id = parent.data('id');
        var button = $(e.target).closest('.btn-downvote');

        $.post('/Submissions/DownVote/?id=' + id)
            .done(function (data) {
                score.html(data);

                button.removeClass('btn-light');
                button.addClass('btn-success');
            });
    });
});