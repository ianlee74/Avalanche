window.todoApp = window.todoApp || {};

window.todoApp.datacontext = (function (ko) {

    var datacontext = {
        getAvalanche: getAvalanche,
        saveNewAvalanche: saveNewAvalanche,
        saveChangedAvalanche: saveChangedAvalanche
    };

    return datacontext;

    function getAvalanche(id) {
        return ajaxRequest("get", avalancheUrl(id))
            .done(getSucceeded)
            .fail(getFailed);

        function getSucceeded(data) {
            alert("success!");
        }

        function getFailed() {
            alert("failed!");
        }
    }

    function saveNewAvalanche(avalanche) {
        clearErrorMessage(avalanche);
        return ajaxRequest("post", avalancheUrl(), avalanche)
            .done(function (result) {
                avalanche.id = result.id;
            })
            .fail(function () {
                avalanche.ErrorMessage("Error adding a new avalanche.");
            });
    }

    function saveChangedAvalanche(avalanche) {
        clearErrorMessage(avalanche);
        return ajaxRequest("put", avalancheUrl(avalanche.id), avalanche)
            .fail(function () {
                avalanche.ErrorMessage("Error updating avalanche.");
            });
    }

    // Private
    function clearErrorMessage(entity) { entity.ErrorMessage(null); }
    function ajaxRequest(type, url, data) { // Ajax helper
        var options = {
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: ko.toJSON(data)
        };
        return $.ajax(url, options);
    }
    // routes
    function avalancheUrl(id) { return "http://http://localhost:16133/api/avalanche/" + (id || ""); }

})(ko);