$.views.helpers(
{
    lower: function (val)
    {
        return val.toLowerCase();
    },
    upper: function (val)
    {
        return !val ? "" : val.toUpperCase();
    },
    firstLetterToLowerCase: function (val)
    {
        return !val ? "" : val.firstLetterToLowerCase();
    },
    firstLetterToUpperCase: function (val)
    {
        return !val ? "" : val.firstLetterToUpperCase();
    },
    formatDate: function (val, format)
    {
        return !val ? "" : val.formatDate(format);
    },
    formatMoney: function (val)
    {
        return !val && val != 0 ? "" : val.formatMoney();
    },
    range: function (start, stop)
    {
        return _.range(start, stop);
    },
    isEmpty: function (val)
    {
        return _.isEmpty(val);
    },
    normalize: function (val)
    {
        return !val ? "" : val.replace(" ", "_");
    },
    contains: function (list, val)
    {
        return list ? $.inArray(val, _.isString(list) ? list.split(",") : list) != -1 : false;
    },
    hasEmptyOption: function (listValues)
    {
        return _.some(listValues, function (item) { return item == '' || !item.value; });
    },
    sortBy: function (list, property)
    {
        return _(list).sortBy(function (item) { return item[property]; });
    }
});

$.extend(
{
    render: function (tmplName, data, options)
    {
        if (!_.isString(tmplName))
            throw "tmplName must be a string";

        data = data || {};
        options = options || {};
        
        var templates = options.templates || $.templates;
        var tmpl = templates[tmplName];

        if (options.templates)
        {
            var tuneTemplates = function (parentTmpl)
            {
                if (!parentTmpl.templates)
                {
                    _.each(parentTmpl.tmpls, function (t) { tuneTemplates(t); });
                    parentTmpl.templates = options.templates;
                }
            };

            _.each(options.templates, function (t) { tuneTemplates(t); });
        }

        var createView = function ()
        {
            return {
                ctx: $.views.helpers,
                data: options.parentData,
                views: [],
                tmpl: {},
                _: {}
            };
        }

        return tmpl.render.call(tmpl, data, null, false, _.extend(createView(),
        {
            parent: options.parentData ? createView() : null
        }));
    }
});

$.views.converters(
{
    encodeHtml: function (text)
    {
        if (!_.isString(text))
            return text;

        var result = $.views.converters["html"](text);
        return $.views.converters["newLineToBr"](result);
    },
    newLineToBr: function (text)
    {
        if (!_.isString(text))
            return text;

        return !text ? "" : text.replace(/\r\n/g, "<br/>").
            replace(/\n/g, "<br/>");
    },
    jsonFriendly: function (text)
    {
        if (!_.isString(text))
            return text;

        return !text ? "" : text.replace(/\t/g, " ").
            replace(/\\/g, "\\\\").replace(/"/g, "&#34;").replace(/'/g, "&#39;");
    },
    tableCell: function (text)
    {
        text = $.views.converters["encodeHtml"](text);
        return $.views.converters["jsonFriendly"](text);
    },
    friendlyBool: function (value)
    {
	    if (value === false)
	    	return "No";
	    if (value === true)
	    	return "Yes";

	    return "N/A";
    }
});