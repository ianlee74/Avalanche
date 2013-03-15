window.todoApp.avalancheListViewModel = (function (ko, datacontext) {
    var avalanches = ko.observableArray(),
        error = ko.observable(),
        addAvalanche = function () {
            var avalanche = datacontext.createAvalanche();            
            datacontext.saveNewAvalanche(avalanche)
                .then(addSucceeded)
                .fail(addFailed);

            function addSucceeded() {
                showAvalanche(avalanche);
            }
            function addFailed() {
                error("Save of new Avalanche failed");
            }
        },
        showAvalanche = function (avalanche) {
            avalanches.unshift(avalanche); // Insert new Avalanche at the front
        },
        deleteAvalanche = function (avalanche) {
            avalanches.remove(avalanche);
            datacontext.deleteAvalanche(avalanche)
                .fail(deleteFailed);

            function deleteFailed() {
                showAvalanche(avalanche); // re-show the restored list
            }
        };

    datacontext.getAvalanches(avalanches, error); // load Avalanches

    return {
        avalanches: avalanches,
        error: error,
        addAvalanche: addAvalanche,
        deleteAvalanche: deleteAvalanche
    };

})(ko, todoApp.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.todoApp.avalancheListViewModel);
