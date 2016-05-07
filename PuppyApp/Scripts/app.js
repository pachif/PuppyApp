﻿/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="knockout-3.4.0.js" />

(function (ko, ok) {
    ko.BaseViewModel = function () {
        var self = this;

        this.apiUrl = 'api/default';
        self.newItem = ko.observable();
        self.error = ko.observable();
        self.items = ko.observableArray();
        self.dirtyItems = ko.computed(function () {
            return self.items().filter(function (item) {
                return item.dirtyFlag.isDirty();
            });
        });
        self.isDirty = ko.computed(function () {
            return self.dirtyItems().length > 0;
        });
        
        self.ajaxHelper = function (uri, method, data) {
            self.error(''); // Clear error message
            return $.ajax({
                type: method,
                url: uri,
                dataType: 'json',
                contentType: 'application/json',
                data: data ? JSON.stringify(data) : null
            }).fail(function (jqXHR, textStatus, errorThrown) {
                self.error(errorThrown);
            });
        }
    };

}(ko));

var profileViewModel = function () {
    self = this;
    ko.BaseViewModel.call(self); // for base inheritance

    this.profiles = ko.observableArray();

    this.newProfile = {
        Id : ko.observable(),
        Name: ko.observable(),
        AddressLatitude: ko.observable(),
        AddressLongitude: ko.observable(),
        Photo : ko.observable()
    };

    this.addProfile = function (formElement) {
        var profile = {
            Id: self.newProfile.Id(),
            Name: self.newProfile.Name(),
            AddressLatitude: self.newProfile.AddressLatitude(),
            AddressLongitude: self.newProfile.AddressLongitude(),
            Photo: self.newProfile.Photo()
        };

        self.ajaxHelper(self.apiUrl, 'POST', book).done(function (item) {
            self.profiles.push(item);
        });
    };
    // Initialize Here
    this.apiUrl = '/api/userprofiles/';
    self.newItem(this.newProfile);
};

//$.extend(baseViewModel, profileViewModel);

//ko.applyBindings(new profileViewModel());