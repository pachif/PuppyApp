/// <reference path="app.js" />

var dashboardViewModel = function () {
    self = this;
    ko.BaseViewModel.call(self);

    this.userProfilesUri = '/api/historypoints/';
    this.recentHistoryEvents = ko.observable(); //represent an array object with all points inside. No VM was necessary

    // Initial ViewModel Load
    this.loadRecentEvents = function() {
        self.ajaxHelper(self.apiUrl + 'recent', 'GET').done(function (data) {
            // extract usefull data like Title, Latitude, Longitude for now here
            self.recentHistoryEvents(data);
        });
    };

    // Initialize Here
    this.apiUrl = '/api/historypoints/';
};
