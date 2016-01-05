var PaginationViewModel = (function () {
    var self = this;
    var size = ko.observable(10);
    var ResultNumber = ko.observable(0)
    var totalPages = ko.observable();
    var PageInformationExpert = ko.observableArray();
    var currentPage = ko.observable(1);
    var setTotalPages = function (ResultNumber) {
        if (ResultNumber < 1) {
            totalPages(1);//do something else 
        } else {
            totalPages(Math.ceil(ResultNumber / size()));
        }

    };
    var initialize = function (xhr, callback) {
        ResultNumber(xhr.getResponseHeader("ResultNumber"));
        setTotalPages(xhr.getResponseHeader("ResultNumber"));
        $('#pagination').twbsPagination({
            totalPages: totalPages(),
            visiblePages: 5,
            onPageClick: function (event, page) {
                currentPage(page);
                callback();
            }
        });
    };
    var setRequestHeader = function (xhr) {       
        if (xhr===null)//for the first time of the request
        {
            xhr.setRequestHeader('limit', size() );
            xhr.setRequestHeader('offset', 0)
        } else {
            xhr.setRequestHeader('limit', size() );
            xhr.setRequestHeader('offset', size() * ((currentPage())-1));
        }
        
    };
    return {
        setRequestHeader: setRequestHeader, initialize: initialize
    }
})();