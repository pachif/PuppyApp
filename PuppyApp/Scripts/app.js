/// <reference path="_references.js" />

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

function getLocation(positionAction) {
    ///<summary>Calls the browser geolocalizations feature</summary>
    ///<param name="positionAction"></param>
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(positionAction);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showAlertMessage(selector, fail, message) {
    var typeMsg = fail ? "danger" : "success";
    var rawHtml = "<div class=\"alert alert-" + typeMsg + " alert-dismissable\">" +
        "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>" +
        "<i class=\"fa fa-info-circle\"></i>  <strong>" + message + "</strong>" +
        "</div>";
    var alertDiv = $(rawHtml);
    var jqueryElement = $(selector);
    jqueryElement.append(alertDiv);
    $('html, body').animate({ scrollTop: 10 }, 'slow');
    alertDiv.fadeOut(3000, function (ev) {
        // On Complete Remove it
        alertDiv.remove();
    });
}

