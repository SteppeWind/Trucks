namespace("points.list");
points.list.ListView = Backbone.View.extend({
    el: "#poitsList",

    initialize: function(options) {
        _.extend(this, options);

        var data = {
            points: this.points,
            createUrl: this.createUrl
        };

        new points.create.CreateView(data).render();
    },

    render: function() {
        
    },

    buildTable: function() {
        this.$("#poitsTable").DataTable({
            aLengthMenu: [[25, 50, 75, -1], [25, 50, 75, "All"]],
            iDisplayLength: 25,
            language: {
                search: "",
                sLengthMenu: "",
                zeroRecords: "Nothing found. Please change your search term",
                paginate: {
                    "first": "First",
                    "last": "Last",
                    "next": ">>",
                    "previous": "<<"
                }
            },
            data: this.points,
            columns:
            [
                { title: "City", data: "City.Name" },
                { title: "Address", data: "Address" },
                {
                    title: "Action",
                    data: "Id",
                    className: "nowrap",
                    render: function (data) {
                        return "<a class='btn btn-info' href='" + selectPointUrl.replace("{{:id}}", data) + "'><i class='fa fa-info-circle'></i></a>  <a href='javascript:void(0)' id='" + data + "' class='delete btn btn-danger'><i class='fa fa-remove'></i></button>";
                    }
                }
            ]
        });
    }
});