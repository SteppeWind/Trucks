function redirect(url)
{
    $(window).trigger("redirect");
    window.location.href = url;
}

function downloadFile(url)
{
    window.location.href = url;
}

function reload()
{
    $(window).trigger("redirect");
    window.location.reload();
}

function reloadOpener()
{
    if (window.opener)
        window.opener.location.reload();
}

if (!Array.prototype.add)
{
    Array.prototype.add = function (obj)
    {
        this.push(obj);
    };
}

if (!Array.prototype.remove)
{
    Array.prototype.remove = function (obj)
    {
        var index = this.indexOf(obj);
        if (index > -1)
            this.splice(index, 1);
    };
}

if (!String.prototype.contains)
{
    String.prototype.contains = function (str)
    {
        return this.indexOf(str) !== -1;
    };
}

if (!String.prototype.startsWith)
{
    String.prototype.startsWith = function (str)
    {
        return this.substr(0, str.length) === str;
    };
}

if (!String.prototype.endsWith)
{
    String.prototype.endsWith = function (str)
    {
        if (this.length < str.length)
            return false;

        return this.substr(this.length - str.length) === str;
    };
}

String.prototype.shortenText = function (maxLength)
{
    return this.length <= maxLength ? this : this.substring(0, maxLength) + " ...";
};

String.prototype.asBool = function ()
{
    return this.toLowerCase() == 'true';
};

String.prototype.asInt = function ()
{
    return parseInt(this);
};

/* 
 override default parseInt to fix the below:
 older browsers will result parseInt("010") as 8, because older versions of ECMAScript (older than ECMAScript 5),
 uses the octal radix (8) as default when the string begins with "0". In ECMAScript 5, the default is the decimal radix (10).
*/
var _parseIntOriginal = window.parseInt;
window.parseInt = function (val, radix)
{
    return radix ? _parseIntOriginal(val, radix) : _parseIntOriginal(val, 10);
};

String.prototype.formatDate = function (format)
{
    format = (format || "{d}").toLowerCase();

    var dateFormat = appConfig.dateFormat.toUpperCase();
    var timeFormat = "hh:mm A";
    var dateTimeFormat = dateFormat + " " + timeFormat;

    if (_.contains(["{d}", "{date}", "date"], format))
        format = dateFormat;
    else if (_.contains(["{dt}", "{datetime}", "datetime"], format))
        format = dateTimeFormat;
    else if (_.contains(["{t}", "{time}", "time"], format))
        format = timeFormat;

    format = format.replace("a", "A"); // force AM/PM format

    var isoDate = moment(this.substr(0, 19), moment.ISO_8601); // cut off a timezone from a date value, because the value is in correct time-zone already
    if (isoDate.isValid())
        return isoDate.format(format);

    var date = moment(this, dateTimeFormat);
    if (date.isValid())
        return date.format(format);

    throw "Invalid date value '" + this.toString() + "'.";
};

String.prototype.formatMoney = function ()
{
    return this.asInt().formatMoney();
};

String.prototype.firstLetterToUpperCase = function ()
{
    return this.slice(0, 1).toUpperCase() + this.slice(1);
};

String.prototype.firstLetterToLowerCase = function ()
{
    return this.slice(0, 1).toLowerCase() + this.slice(1);
};

String.prototype.splitUpperCase = function ()
{
    return this.split(/(?=[A-Z])/).join(" ");
};

String.prototype.withoutHtml = function ()
{
    var tempDiv = document.createElement("div");
    tempDiv.innerHTML = this;
    return tempDiv.textContent || tempDiv.innerText || "";
};

String.prototype.removeSpaces = function ()
{
    return this.replace(/\s+/g, '');
};

Date.prototype.toServerDate = function ()
{
    return (this.getMonth() + 1) + '/' +
        this.getDate() + '/' +
        this.getFullYear() + ' ' +
        this.getHours() + ':' +
        this.getMinutes() + ':' +
        this.getSeconds() + '.' +
        this.getMilliseconds();
};

// Extend the default Number object with a formatMoney() method:
// usage: someVar.formatMoney(decimalPlaces, symbol, thousandsSeparator, decimalSeparator)
// defaults: (2, "$", ",", ".")
Number.prototype.formatMoney = function (places, symbol, thousand, decimal)
{
    places = !isNaN(places = Math.abs(places)) ? places : 2;
    symbol = symbol !== undefined ? symbol : (appConfig.currencySymbol || "$");
    thousand = thousand || ",";
    decimal = decimal || ".";
    var number = this,
        negative = number < 0 ? "-" : "",
        i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
        j = (j = i.length) > 3 ? j % 3 : 0;
    return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
};

function canCloseWindow()
{
    return window.opener != null;
}

function include(file)
{
    var script = document.createElement('script');
    script.src = file;
    script.type = 'text/javascript';
    document.getElementsByTagName('head').item(0).appendChild(script);
}

function getFunctionByName(name)
{
    if (!name)
        return undefined;

    // function was already resolved before
    if (_.isFunction(name))
        return name;

    var context = window;
    var namespaces = name.split(".");
    var func = namespaces.pop();

    for (var i = 0; i < namespaces.length; i++)
    {
        context = context[namespaces[i]];
    }

    return context[func];
}

function callFunction(func)
{
    if (!func)
        return undefined;

    var args = _.without(arguments, func);
    var call = function (f, on)
    {
        if (!f) return undefined;

        if (!_.isFunction(f))
            throw error('Couldn\'t resolve function ' + f.toString());

        return f.apply(on, args);
    };

    if (_.isString(func))
    {
        var lastCallResult;
        _.each(func.split(","), function (v)
        {
            if (!v) return;

            var on = v.indexOf(".") != -1 ? getFunctionByName(v.substring(0, v.lastIndexOf("."))) : null;
            lastCallResult = call(getFunctionByName(v), on);
        });

        return lastCallResult;
    }
    else
        return call(func);
}

var namespace = function (name, container)
{
    var ns = name.split('.');
    container = container || window;

    var i, len;
    for (i = 0, len = ns.length; i < len; i++)
    {
        container = container[ns[i]] = container[ns[i]] || {};
    }

    return container;
};

// https://github.com/angular/angular.js/blob/v1.3.14/src/ngSanitize/sanitize.js#L435
/**
 * Escapes all potentially dangerous characters, so that the
 * resulting string can be safely inserted into attribute or
 * element text.
 * @param value
 * @returns {string} escaped text
 */
function htmlEncode(value)
{
    if (!value)
        return "";

    // match everything outside of normal chars and " (quote character)
    var nonAlphanumericRegexp = /([^\#-~| |!])/g;
    var surrogatePairRegexp = /[\uD800-\uDBFF][\uDC00-\uDFFF]/g;

    return value
        .replace(/&/g, "&amp;")
        .replace(surrogatePairRegexp, function (str)
        {
            var hi = str.charCodeAt(0);
            var low = str.charCodeAt(1);
            return "&#" + (((hi - 0xD800) * 0x400) + (low - 0xDC00) + 0x10000) + ";";
        })
        .replace(nonAlphanumericRegexp, function (str)
        {
            return "&#" + str.charCodeAt(0) + ";";
        })
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;");
}

/**
 * decodes all entities into regular string
 * @param value
 * @returns {string} A string with decoded entities.
 */
function htmlDecode(value)
{
    if (!value)
        return "";

    var hiddenPre = document.createElement("pre");
    hiddenPre.innerHTML = value.replace(/</g, "&lt;");

    // innerText depends on styling as it doesn't display hidden elements.
    // Therefore, it's better to use textContent not to cause unnecessary reflows.
    return hiddenPre.textContent;
}

function generateImagePreviewUrl(imageUrl, width, height)
{
    return sprintf("https://img.secure-platform.com/Home/Resize/?url=%s&width=%d&height=%d&color=white", encodeURIComponent(imageUrl), width, height);
}