/// <reference path="app.js" />

var ownerViewModel = function () {
    self = this;
    ko.BaseViewModel.call(self);

    self.firstName = ko.observable();
    self.lastName = ko.observable();
    self.UniqueId = ko.observable();
    self.mascotName = ko.observable();
    self.fullName = ko.pureComputed(function () {
        return self.firstName() + ' ' + self.lastName();
    });

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

    // Initialize Here
    this.baseModelUri = '/api/Owner/';
    loadDeseases();
    this.isPetComboDisabed(true);
    loadOwners();
};
