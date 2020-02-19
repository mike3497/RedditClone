$(document).ready(function () {
    $('.btn-upvote').on('click', function (e) {
        var parent = $(e.target).closest('.list-group-item');
        var score = parent.find('.score');
        var id = parent.data('id');
        var upVoteButton = parent.find('.btn-upvote');
        var downVoteButton = parent.find('.btn-downvote');

        $.post('/Submissions/UpVote/?id=' + id)
            .done(function (data) {
                score.html(data);

                upVoteButton.removeClass('btn-light');
                upVoteButton.addClass('btn-success');

                downVoteButton.attr("disabled", true);
            });
    });

    $('.btn-downvote').on('click', function (e) {
        var parent = $(e.target).closest('.list-group-item');
        var score = parent.find('.score');
        var id = parent.data('id');
        var upVoteButton = parent.find('.btn-upvote');
        var downVoteButton = parent.find('.btn-downvote');

        $.post('/Submissions/DownVote/?id=' + id)
            .done(function (data) {
                score.html(data);

                downVoteButton.removeClass('btn-light');
                downVoteButton.addClass('btn-success');

                upVoteButton.attr("disabled", true);
            });
    });
});