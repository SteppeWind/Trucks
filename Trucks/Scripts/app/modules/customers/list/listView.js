namespace("customers.list");
customers.list.ListView = Backbone.View.extend({
    el: "#customersList",

    events: {
        "click a.delete": "onDeleteClicked"
    },

    initialize: function(options) {
        _.extend(this, options);
    },

    render: function() {
        this.buildTable();
    },

    onDeleteClicked: function (e) {
        var customerId = e.target.getAttribute("id");
        var deleteCustomerUrl = this.deleteCustomerUrl;

        if (customerId === null) {
            customerId = e.target.parentNode.getAttribute("id");
        }

        var customersTable = this.$("#customersTable");
        $.ajax({
            type: "POST",
            url: deleteCustomerUrl,
            data: { id: customerId },
            success: function () {
                $(customersTable).DataTable().row("tr:has(a[id='" + customerId + "'])").remove().draw(false);
            }
        });
    },

    buildTable: function () {
        var selectCustomerUrl = this.selectCustomerUrl;

        this.$("#customersTable").DataTable({
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
            data: this.customers,            
            columns:
            [
                { title: "Name", data: "Name" },
                { title: "Surname", data: "Surname" },
                { title: "Phone", data: "PhoneNumber" },
                { title: "Total #Order", data: "TotalOrderCount", width: "7%" },
                { title: "Complete #Order", data: "CompleteOrderCount", width: "7%" },
                { title: "Incomplete #Order", data: "IncompleteOrderCount", width: "7%" },
                {
                    title: "Action",
                    data: "Id",
                    className: "nowrap",
                    render: function(data) {
                        return "<a class='btn btn-info' href='" + selectCustomerUrl.replace("{{:id}}", data) + "'><i class='fa fa-info-circle'></i></a>  <a href='javascript:void(0)' id='" + data + "' class='delete btn btn-danger'><i class='fa fa-remove'></i></button>";
                    }
                }
            ]
        });
    }
});