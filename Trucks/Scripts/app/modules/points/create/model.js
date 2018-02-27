namespace("points.create");
points.create.CreateModel = Backbone.Model.extend({
    url: function () {
        return this.createUrl;
    },

    initialize: function (url) {
        this.createUrl = url;
    },

    isValid: function () {
        return (this.get("CityId") !== -1 || this.get("City")) && this.get("Address");
    }
});