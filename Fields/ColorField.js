Type.registerNamespace("PalettesModule.Fields");

PalettesModule.Fields.ColorField = function (element) {
    PalettesModule.Fields.ColorField.initializeBase(this, [element]);
    this._element = element;
    this._labelElement = null;
    this._colorPickerElement = null;
}

PalettesModule.Fields.ColorField.prototype = {
    initialize: function () {
        /* Here you can attach to events or do other initialization */      
        PalettesModule.Fields.ColorField.callBaseMethod(this, "initialize");
    },

    dispose: function () {
        /*  this is the place to unbind/dispose the event handlers created in the initialize method */   
        PalettesModule.Fields.ColorField.callBaseMethod(this, "dispose");
    },

    /* --------------------------------- public methods ---------------------------------- */

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _getColorValue: function(){
        if (this._colorPickerElement) {
            return this._colorPickerElement.get_selectedColor();
        }
        return null;
    },

    _clearColorPicker: function () {
        if (this._colorPickerElement != null) {
            this._colorPickerElement.set_selectedColor("#ffffff");
        }
    },    

    /* --------------------------------- properties -------------------------------------- */
    get_value: function () {    
        var val = this._getColorValue();
        return val;
    },

    set_value: function (value) {
        this._clearColorPicker();
        if (value !== undefined && value != null && this._colorPickerElement != null) {
            this._colorPickerElement.set_selectedColor(value);
        }
        this._value = value;
    },
    
    get_colorPickerElement: function () {
        return this._colorPickerElement;
    },

    set_colorPickerElement: function (value) {
        this._colorPickerElement = value;
    }    
};

PalettesModule.Fields.ColorField.registerClass("PalettesModule.Fields.ColorField", Telerik.Sitefinity.Web.UI.Fields.FieldControl);