namespace("customers.create");
customers.create.CreateModel = Backbone.Model.extend({
    url: function() {
        return this.createUrl;
    },

    initialize: function(url) {
        this.createUrl = url;
    },

    isValid: function () {
        return this.get("Name") && this.get("Surname") && this.get("PhoneNumber");
    }
});