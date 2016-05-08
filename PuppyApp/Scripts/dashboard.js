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

    this.addNewEvent = function (formElement) {
        var newEvent = self.newItem();

        var historyPoint = {
            Id: 0,
            Title: formElement.eventTitle,
            When: formElement.When,
            PetId: formElement.PetId,
            EventLatitude: formElement.PetId,
            EventLongitude: formElement.EventLongitude
        };

        self.ajaxHelper(self.apiUrl, 'POST', book).done(function (item) {
            alert('Event Saved!');
            self.loadRecentEvents();
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
