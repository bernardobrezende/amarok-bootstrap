if (!amarok.bootstrap.web.home) amarok.bootstrap.web.home = {};

amarok.bootstrap.web.home.init = function () {
    $.get('http://localhost:7000/api/v1/features', function (data) {
        // after fetch features from server we bind them with knockoutjs
        ko.applyBindings(new amarok.bootstrap.web.home.model(data));
    })
    .fail(function (error) {
        console.log(error);
    });
}

// Home View model implementation
amarok.bootstrap.web.home.model = function (serverFeatures) {
    var self = this;

    self.features = ko.observableArray(
        ko.utils.arrayMap(serverFeatures, function (f) {
            var feature = new Object();
            feature.Name = f.Name;
            feature.IsActive = f.IsActive;
            return feature;
        })
    );
};