(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // if AMD loader is available, register as an anonymous module.
        define(['jquery', 'fuelux/combobox'], factory);
    } else {
        // OR use browser globals if AMD is not present
        factory(jQuery);
    }
}(function ($) {

    // -- END UMD WRAPPER PREFACE --

    // -- BEGIN MODULE CODE HERE --

    
    $.fn.extend($.fn.combobox.Constructor.prototype, {
        // adding methods
        awesomeNewMethod: function () { },

        // overriding methods
        someExistingMethod: function () { }
    });

    

    // -- BEGIN UMD WRAPPER AFTERWORD --
}));
// -- END UMD WRAPPER AFTERWORD --