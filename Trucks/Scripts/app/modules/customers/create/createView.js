namespace("customers.create");
customers.create.CreateView = Backbone.View.extend({
    el: "#createCustomerModal",

    events: {
        "click button[type='submit']" : "onFormSubmit"
    },

    initialize: function(options) {
        _.extend(this, options);

        this.model = new customers.create.CreateModel(options.createUrl);
    },

    render: function() {
        
    },

    getInput: function (name) {
        return this.$("[name='" + name + "']");
    },

    onFormSubmit: function(e) {
        e.preventDefault();
        var model = this.model;

        var ad = this.$el.toObject();
        this.$el.find("input[type='text']").each(function() {
            model.set(this.name, this.value);
        });

        var self = this;
        if (model.isValid())
            model.save(null, {
                success: function (m, response) {
                    console.log(response);
                    redirect(self.detailsUrl.replace("{{:id}}", response.Id));
                }
            });
        else {
            this.$el.find("input[type='text']").each(function () {
                self.highlightInputError(this.getAttribute("name"));
            });
        }
    },

    onCityChanged: function (e) {
        this.model.set("CityId", $(e.target).val());
    }
});