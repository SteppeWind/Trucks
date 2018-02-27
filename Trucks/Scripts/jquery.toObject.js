/*
custom changes:
1) changed default settings.skipEmpty to false (48)
2) added default settings.emptyToNull to true (49)
3) added parameter settings.emptyToNull to form2js function (88, 93, 98)
4) added custom nodeCallback function for process ASP.NET MVC checkboxes (62-83)
*/

/**
* Copyright (c) 2010 Maxim Vasiliev
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*
* @author Maxim Vasiliev
* Date: 29.06.11
* Time: 20:09
*/

(function ($) {
    /**
    * jQuery wrapper for form2object()
    * Extracts data from child inputs into javascript object
    */
    $.fn.toObject = function (options) {
        var result = [],
            settings = {
                mode: 'first', // what to convert: 'all' or 'first' matched node
                delimiter: ".",
                skipEmpty: false,
                emptyToNull: true,
                nodeCallback: null,
                useIdIfEmptyName: false
            };

        if (options) {
            $.extend(settings, options);
        }

        if (settings.nodeCallback)
            throw 'nodeCallback is not supported!';

        settings.nodeCallback = function (node) {
            if (node.type !== 'checkbox')
                return false;

            if ($(node).val().asBool()) // is ASP.NET MVC checkbox
            {
                var nameSplits = $(node)
                    .attr('name')
                    .split('.');

                var name = _.reduce(nameSplits, function (a, b) {
                    return a.firstLetterToLowerCase() + "." + b.firstLetterToLowerCase();
                })
                    .firstLetterToLowerCase();

                return { name: name, value: node.checked };
            }
            else
                return false;
        }

        switch (settings.mode) {
            case 'first':
                return form2js(this.get(0), settings.delimiter, settings.skipEmpty, settings.emptyToNull, settings.nodeCallback, settings.useIdIfEmptyName);
                break;
            case 'all':
                this.each(function () {
                    result.push(form2js(this, settings.delimiter, settings.skipEmpty, settings.emptyToNull, settings.nodeCallback, settings.useIdIfEmptyName));
                });
                return result;
                break;
            case 'combine':
                return form2js(Array.prototype.slice.call(this), settings.delimiter, settings.skipEmpty, settings.emptyToNull, settings.nodeCallback, settings.useIdIfEmptyName);
                break;
        }
    }

})(jQuery);