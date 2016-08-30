/// <reference path="app.js" />

var dashboardViewModel = function () {
    self = this;
    ko.BaseViewModel.call(self);

    this.userProfilesUri = '/api/historypoints/';
    this.recentHistoryEvents = ko.observable(); //represent an array object with all points inside. No VM was necessary
    this.isPetComboDisabed = ko.observable(false);
    this.owners = ko.observableArray();
    this.filteredOwners = ko.observableArray();
    this.selectedOwner = ko.observable();
    this.pets = ko.observableArray();
    this.deseases = ko.observableArray();
    this.profile = ko.observable();

    // Initial ViewModel Load
    this.loadRecentEvents = function () {
        self.ajaxHelper(self.apiUrl + 'recent', 'GET').done(function (data) {
            // extract usefull data like Title, Latitude, Longitude for now here
            self.recentHistoryEvents(data);
        });
    };

    this.filterOwners = function (filterText) {
        if (!filterText) {
            return self.owners();
        } else {
            return ko.utils.arrayFilter(self.owners(), function (item) {
                return item.OptionText.to;
            });
        }
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

    this.addNewOwner = function (ownerData, successCallback, failCallback) {
        self.ajaxHelper("/api/owners", 'POST', ownerData)
            .done(function (data) {
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

    function loadDeseases() {
        self.ajaxHelper('/api/deseases/', 'GET').done(function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    self.deseases.push(data[i]);
                }
            }
        });
    }

    this.loadPets = function(id) {
        self.ajaxHelper('/api/owners/' + id + '/pets', 'GET').done(function (data) {
            self.isPetComboDisabed(false);
            self.pets.removeAll();
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    self.pets.push(data[i]);
                }
            }
        });
    }

    function loadOwners() {
        self.ajaxHelper('/api/owners/options', 'GET').done(function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    self.owners.push(data[i]);
                    if (i < 10) {
                        // set initial filtered
                        self.filteredOwners.push(data[i]);
                    }
                }
            }
        });
    }

    // Initialize Here
    this.apiUrl = '/api/historypoints/';
    loadDeseases();
    this.isPetComboDisabed(true);
    loadOwners();
};
