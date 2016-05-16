/// <reference path="app.js" />

var dashboardViewModel = function () {
    self = this;
    ko.BaseViewModel.call(self);

    this.userProfilesUri = '/api/historypoints/';
    this.recentHistoryEvents = ko.observable(); //represent an array object with all points inside. No VM was necessary
    this.pets = ko.observableArray();
    this.deseases = ko.observableArray();
    this.profile = ko.observable();

    // Initial ViewModel Load
    this.loadRecentEvents = function() {
        self.ajaxHelper(self.apiUrl + 'recent', 'GET').done(function (data) {
            // extract usefull data like Title, Latitude, Longitude for now here
            self.recentHistoryEvents(data);
        });
    };

    this.addNewEvent = function (eventData, successCallback, failCallback) {
        ///<summary>Adds new HistoryPoint to database</summary>
        ///<param name='eventData'>the DTO object</param>
        ///<param name='successCallback'>method to call in success</param>
        ///<param name='failCallback'>method to call in fail</param>
        self.ajaxHelper(self.apiUrl, 'POST', eventData)
            .done(function (data) {
                self.loadRecentEvents();
                if (successCallback != null) {
                    successCallback();
                }
            })
            .fail(function (data) {
                if (failCallback != null) {
                    failCallback();
                }
            });
    }

    function loadProfilePets(id) {
        self.ajaxHelper('/api/userprofiles/' + id + '/pets', 'GET').done(function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    self.pets.push(data[i]);
                }
            }
        });
    }

    function loadDeseases() {
        self.ajaxHelper('/api/deseases/', 'GET').done(function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    self.deseases.push(data[i]);
                }
            }
        });
    }

    // Initialize Here
    this.apiUrl = '/api/historypoints/';
    loadDeseases();
    loadProfilePets(1);
    
};
