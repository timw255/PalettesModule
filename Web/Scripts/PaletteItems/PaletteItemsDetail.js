var PaletteItemsDetail = kendo.Class.extend({

    /* --------------------------------- Construction ------------------------------------ */

    init: function (form, dataSource, webServiceUrl) {
        form.kendoWindow({
            animation: false,
            modal: true,
            visible: false
        });
        form.parent().addClass("sfMaximizedWindow")
        this._formWindow = form.data("kendoWindow");
        this._dataSource = dataSource;
        this._webServiceUrl = webServiceUrl;

        $(this._formElements.dark1).kendoColorPicker();
        $(this._formElements.dark2).kendoColorPicker();
        $(this._formElements.light1).kendoColorPicker();
        $(this._formElements.light2).kendoColorPicker();
        $(this._formElements.accent1).kendoColorPicker();
        $(this._formElements.accent2).kendoColorPicker();
        $(this._formElements.accent3).kendoColorPicker();
        $(this._formElements.accent4).kendoColorPicker();
        $(this._formElements.accent5).kendoColorPicker();
        $(this._formElements.accent6).kendoColorPicker();
        $(this._formElements.hyperlink).kendoColorPicker();
        $(this._formElements.followedHyperlink).kendoColorPicker();
    },

    /* --------------------------------- public methods ---------------------------------- */

    show: function (id) {
        var that = this;
        this.reset();
        this.get_window().open();
        this.get_window().maximize();
        if (id) {
			$.ajax({
                type: 'GET',
                url: this.get_webServiceUrl() + id + "/",
                cache: false,
            }).done(function (data) {
                that.load(data.Item);
            });
            $("#createPaletteItemButtonText").hide();
            $("#saveChangesPaletteItemButtonText").show();
        }
        else {
            $("#createPaletteItemButtonText").show();
            $("#saveChangesPaletteItemButtonText").hide();
        }
    },

    close: function () {
        this.get_window().close();
    },

    load: function (data) {
        $(this._formElements.title).val(data.Title);
        $(this._formElements.dark1).data("kendoColorPicker").value(data.Dark1);
        $(this._formElements.dark2).data("kendoColorPicker").value(data.Dark2);
        $(this._formElements.light1).data("kendoColorPicker").value(data.Light1);
        $(this._formElements.light2).data("kendoColorPicker").value(data.Light2);
        $(this._formElements.accent1).data("kendoColorPicker").value(data.Accent1);
        $(this._formElements.accent2).data("kendoColorPicker").value(data.Accent2);
        $(this._formElements.accent3).data("kendoColorPicker").value(data.Accent3);
        $(this._formElements.accent4).data("kendoColorPicker").value(data.Accent4);
        $(this._formElements.accent5).data("kendoColorPicker").value(data.Accent5);
        $(this._formElements.accent6).data("kendoColorPicker").value(data.Accent6);
        $(this._formElements.hyperlink).data("kendoColorPicker").value(data.Hyperlink);
        $(this._formElements.followedHyperlink).data("kendoColorPicker").value(data.FollowedHyperlink);
        this.set_id(data.Id);
    },

    save: function () {
        if (this.isValid()) {
            var data = this._getFormData();
            var that = this;
            $.ajax({
                type: 'PUT',
                url: that.get_webServiceUrl() + that.get_id() + "/",
                contentType: "application/json",
                processData: false,
                data: JSON.stringify(data),
                success: function (result, args) {
                    that.close();
                    that.get_dataSource().read();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(Telerik.Sitefinity.JSON.parse(jqXHR.responseText).Detail);
                }
            });
        }
    },

    isValid: function () {
        var isValid = true;

        if ($(this._formElements.title).val().length == 0) {
            $(this._formElements.titleValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.titleValidator).hide();
        }
        if ($(this._formElements.title).val().length != 0 && $(this._formElements.title).val().length > 255) {
            $(this._formElements.titleLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.titleLengthValidator).hide();
        }
        if ($(this._formElements.dark1).val().length != 0 && $(this._formElements.dark1).val().length > 255) {
            $(this._formElements.dark1LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.dark1LengthValidator).hide();
        }
        if ($(this._formElements.dark2).val().length != 0 && $(this._formElements.dark2).val().length > 255) {
            $(this._formElements.dark2LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.dark2LengthValidator).hide();
        }
        if ($(this._formElements.light1).val().length != 0 && $(this._formElements.light1).val().length > 255) {
            $(this._formElements.light1LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.light1LengthValidator).hide();
        }
        if ($(this._formElements.light2).val().length != 0 && $(this._formElements.light2).val().length > 255) {
            $(this._formElements.light2LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.light2LengthValidator).hide();
        }
        if ($(this._formElements.accent1).val().length != 0 && $(this._formElements.accent1).val().length > 255) {
            $(this._formElements.accent1LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent1LengthValidator).hide();
        }
        if ($(this._formElements.accent2).val().length != 0 && $(this._formElements.accent2).val().length > 255) {
            $(this._formElements.accent2LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent2LengthValidator).hide();
        }
        if ($(this._formElements.accent3).val().length != 0 && $(this._formElements.accent3).val().length > 255) {
            $(this._formElements.accent3LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent3LengthValidator).hide();
        }
        if ($(this._formElements.accent4).val().length != 0 && $(this._formElements.accent4).val().length > 255) {
            $(this._formElements.accent4LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent4LengthValidator).hide();
        }
        if ($(this._formElements.accent5).val().length != 0 && $(this._formElements.accent5).val().length > 255) {
            $(this._formElements.accent5LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent5LengthValidator).hide();
        }
        if ($(this._formElements.accent6).val().length != 0 && $(this._formElements.accent6).val().length > 255) {
            $(this._formElements.accent6LengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.accent6LengthValidator).hide();
        }
        if ($(this._formElements.hyperlink).val().length != 0 && $(this._formElements.hyperlink).val().length > 255) {
            $(this._formElements.hyperlinkLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.hyperlinkLengthValidator).hide();
        }
        if ($(this._formElements.followedHyperlink).val().length != 0 && $(this._formElements.followedHyperlink).val().length > 255) {
            $(this._formElements.followedHyperlinkLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.followedHyperlinkLengthValidator).hide();
        }

        return isValid;
    },

    reset: function () {
        this.set_id("00000000-0000-0000-0000-000000000000");

        $(this._formElements.title).val("");
        $(this._formElements.titleValidator).hide();
        $(this._formElements.titleLengthValidator).hide();

        $(this._formElements.dark1).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.dark1LengthValidator).hide();

        $(this._formElements.dark2).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.dark2LengthValidator).hide();

        $(this._formElements.light1).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.light1LengthValidator).hide();

        $(this._formElements.light2).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.light2LengthValidator).hide();

        $(this._formElements.accent1).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent1LengthValidator).hide();

        $(this._formElements.accent2).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent2LengthValidator).hide();

        $(this._formElements.accent3).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent3LengthValidator).hide();

        $(this._formElements.accent4).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent4LengthValidator).hide();

        $(this._formElements.accent5).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent5LengthValidator).hide();

        $(this._formElements.accent6).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.accent6LengthValidator).hide();

        $(this._formElements.hyperlink).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.hyperlinkLengthValidator).hide();

        $(this._formElements.followedHyperlink).data("kendoColorPicker").value("#ffffff");
        $(this._formElements.followedHyperlinkLengthValidator).hide();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _getFormData: function () {
        var data = {
            "Item": {
                "Title": $(this._formElements.title).val(),
                "Dark1": $(this._formElements.dark1).val(),
                "Dark2": $(this._formElements.dark2).val(),
                "Light1": $(this._formElements.light1).val(),
                "Light2": $(this._formElements.light2).val(),
                "Accent1": $(this._formElements.accent1).val(),
                "Accent2": $(this._formElements.accent2).val(),
                "Accent3": $(this._formElements.accent3).val(),
                "Accent4": $(this._formElements.accent4).val(),
                "Accent5": $(this._formElements.accent5).val(),
                "Accent6": $(this._formElements.accent6).val(),
                "Hyperlink": $(this._formElements.hyperlink).val(),
                "FollowedHyperlink": $(this._formElements.followedHyperlink).val()
            }
        };
        return data;
    },

    /* --------------------------------- properties -------------------------------------- */

    get_window: function () {
        return this._formWindow;
    },

    get_dataSource: function () {
        return this._dataSource;
    },

    get_webServiceUrl: function () {
        return this._webServiceUrl;
    },

    get_id: function () {
        return this._id;
    },
    set_id: function (id) {
        this._id = id;
    },

    /* --------------------------------- private fields ---------------------------------- */

    _formElements: {
        title: "#paletteItemTitle",
        titleValidator: "#paletteItemTitleValidator",
        titleLengthValidator: "#paletteItemTitleLengthValidator",
        dark1: "#paletteItemDark1",
        dark1LengthValidator: "#paletteItemDark1LengthValidator",
        dark2: "#paletteItemDark2",
        dark2LengthValidator: "#paletteItemDark2LengthValidator",
        light1: "#paletteItemLight1",
        light1LengthValidator: "#paletteItemLight1LengthValidator",
        light2: "#paletteItemLight2",
        light2LengthValidator: "#paletteItemLight2LengthValidator",
        accent1: "#paletteItemAccent1",
        accent1LengthValidator: "#paletteItemAccent1LengthValidator",
        accent2: "#paletteItemAccent2",
        accent2LengthValidator: "#paletteItemAccent2LengthValidator",
        accent3: "#paletteItemAccent3",
        accent3LengthValidator: "#paletteItemAccent3LengthValidator",
        accent4: "#paletteItemAccent4",
        accent4LengthValidator: "#paletteItemAccent4LengthValidator",
        accent5: "#paletteItemAccent5",
        accent5LengthValidator: "#paletteItemAccent5LengthValidator",
        accent6: "#paletteItemAccent6",
        accent6LengthValidator: "#paletteItemAccent6LengthValidator",
        hyperlink: "#paletteItemHyperlink",
        hyperlinkLengthValidator: "#paletteItemHyperlinkLengthValidator",
        followedHyperlink: "#paletteItemFollowedHyperlink",
        followedHyperlinkLengthValidator: "#paletteItemFollowedHyperlinkLengthValidator"
    },
    _formWindow: null,
    _dataSource: null,
    _webServiceUrl: null,
    _id: "00000000-0000-0000-0000-000000000000"
});