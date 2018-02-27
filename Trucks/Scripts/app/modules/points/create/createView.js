namespace("points.create");
points.create.CreateView = Backbone.View.extend({
    el: "#createPointModal",

    events: {
        "click #save": "onFormSubmit",
        "change #cities select": "onCitySelected",
        "keyup #address input[type='text']": "onAddressChanged",
        "keyup #cities input[type='text']": "onCityChanged",
        "click button[name='Address']": "onLastStepClicked",
        "click button[name='City']": "onFirstStepClicked"
    },

    initialize: function(options) {
        _.extend(this, options);

        this.model = new points.create.CreateModel(options.createUrl);

        var cities = this.$("#cities select");
        _(options.points).each(function(point) {
            cities.append($("<option></option>")
                .attr("value", point.City.Id)
                .text(point.City.Name));
        });
    },

    render: function() {
        
    },

    validateFirstStep: function () {
        var citiesSelector = "#cities";
        
        var alert = this.$(citiesSelector + " div.alert");

        if (this.model.get("CityId") == -1 && !this.model.get("City")) {
            if (alert.length === 0) {
                this.$(citiesSelector).prepend('<div class="alert alert-warning alert-dismissible" role="alert">' +
                    '<button class="close" data-dismiss="alert">&times;</button>' +
                    "Please, choose city or create new." +
                    "</div>");
            } else {
                alert.show();
            }

            return false;
        }

        alert.hide();
        return true;
    },

    validateLastStep: function () {

    },

    onCityChanged: function(e) {
        this.model.set("City", $(e.target).val());
    },

    onCitySelected: function (e) {
        var sdf = 2;
    },

    onAddressChanged: function(e) {
        this.model.set("Address", $(e.target).val());
    },

    onFormSubmit: function () {

    },

    onLastStepClicked: function () {
        if (this.validateFirstStep()) {            
            var addressBtn = this.$("button[name='Address']");
            var cityBtn = this.$("button[name='City']");

            cityBtn.removeClass("btn-primary").addClass("btn-light");
            addressBtn.removeClass("btn-light").addClass("btn-primary");

            this.showAddress();
        }
    },

    onFirstStepClicked: function() {
        var addressBtn = this.$("button[name='Address']");
        var cityBtn = this.$("button[name='City']");

        addressBtn.removeClass("btn-primary").addClass("btn-light");
        cityBtn.removeClass("btn-light").addClass("btn-primary");

        this.showCities();
    },

    showCities: function () {
        this.$("#address").hide();
        this.$("#cities").show();
    },

    showAddress: function () {
        this.$("#cities").hide();
        this.$("#address").show();
    }
});