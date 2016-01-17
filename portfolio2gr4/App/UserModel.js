var UserModel = (function () {

    var getByUrl = function (Url, callback_success, callback_error) {

        $.ajax({
            url: Url,
            type: 'GET',
            dataType: 'json',
            success: callback_success,
            error: callback_error
            //beforeSend: null   ,can be used to add header and authentication
        });
    };
    var getById = function (userID, callback_success, callback_error) {
        $.ajax({
            url: "/api/users/" + userID,
            type: 'GET',
            dataType: 'json',
            success: callback_success,
            error: callback_error
            //beforeSend: null   ,can be used to add header and authentication
        });
    };
    var getHistories = function (userID, callback) {
        $.ajax({
            url: "/api/user/histories/" + userID,
            type: 'GET',
            dataType: 'json',
            success: callback,
            error: function () { alert('boo!'); },//for testing purpose
            //beforeSend: PaginationViewModel.setRequestHeader
        });
    }
    var getAnnotations = function (userID, callback) {
        $.ajax({
            url: "/api/user/annotations/" + userID,
            type: 'GET',
            dataType: 'json',
            success: callback,
            error: function () { alert('boo!'); },//for testing purpose
            //beforeSend: PaginationViewModel.setRequestHeader
        });
    }
    var addAnnotation = function (userID, QuestionID, callback) {
        bootbox.dialog({
            title: "Add Annotation",
            message:'<div class="row">  ' +
	                    '<div class="col-md-12"> ' +
                            '<form class="form-horizontal"> ' +
					        '<div class="form-group"> ' +
					            '<label class="col-md-4 control-label" for="name">Content</label> ' +
						            '<div class="col-md-4"> ' +
						            '<textarea id="content" name="content" type="text" placeholder="Please add your annotation here" class="form-control" /> ' +
						            '</div> ' +
					        '</div>' +
                            '</form>' +
	                    '</div>' +
                     '</div>',
            buttons: {
                success: {
                    label: "Save",
                    className: "btn-success",
                    callback: function () {
                        var Content = $('#content').val();
                        var Annotation = {
                            'Body': $('#content').val(),
                            'PostId': QuestionID,
                            'UserId': userID
                        };
                        $.ajax({
                            type: "POST",
                            url: "api/Annotations/",
                            data: Annotation,
                            success: callback,
                            dataType: 'json'
                        });
                    }
                }
            }
        }
        );


    }
    var addHistory = function (History, callback) {
        $.ajax({
            type: "POST",
            url: "api/Historys/",
            data: History,
            success: callback,
            dataType: text
        });
    }
    var getUsers_short = function (callback) {
        $.ajax({
            url: "/api/users/",
            type: 'GET',
            dataType: 'json',
            success: callback,
            error: function () { alert('boo!'); },//for testing purpose
            beforeSend: PaginationViewModel.setRequestHeader
        });
    }
    var user_short_template;
    var userFull_template;
    return { getById: getById, getByUrl: getByUrl, user_short_template: user_short_template, getUsers_short: getUsers_short, getHistories: getHistories, getAnnotations: getAnnotations, userFull_template: userFull_template, addAnnotation: addAnnotation };
})();

