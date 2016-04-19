var profileViewModel = function () {
    var self = this;
    self.profiles = ko.observableArray();
    self.error = ko.observable();

    self.newProfile = {
        Id : ko.observable(),
        Name: ko.observable(),
        AddressLatitude: ko.observable(),
        AddressLongitude: ko.observable(),
        Photo : ko.observable()
    }


    var userProfilesUri = '/api/userprofiles/';

    function ajaxHelper(uri, method, data) {
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

    this.addProfile = function (formElement) {
        var profile = {
            Id: self.newProfile.Id(),
            Name: self.newProfile.Name(),
            AddressLatitude: self.newProfile.AddressLatitude(),
            AddressLongitude: self.newProfile.AddressLongitude(),
            Photo: self.newProfile.Photo()
        };

        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.profiles.push(item);
        });
    };
};

ko.applyBindings(new profileViewModel());