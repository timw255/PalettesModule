$(document).ready(function () {
    var webServiceUrl = $('#paletteItemsServiceUrlHidden').val();
    
    var itemsCountPerPage = 50;
    var sortExpression = "DateCreated DESC";
    var itemsTotalCount;
    var isLastPageDeleted;

    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: webServiceUrl + "?sortExpression=" + sortExpression + "&take=" + itemsCountPerPage,
                dataType: "json",
				cache: false,
            }
        },
        schema: {
            model: {
                id: "Id"
            },
            data: function (result) {
                itemsTotalCount = result.TotalCount;
                var items = result.Items;

                /* all items from the last page were deleted so the data source must be refreshed */
                isLastPageDeleted = (items.length == 0 && itemsTotalCount != 0);

                return items;
            }
        },
        change: function (e) {
            if (isLastPageDeleted) {
                /* refresh the data source */
                paletteItemsMasterView.set_skip((paletteItemsMasterView.get_currentPage() - 2) * paletteItemsMasterView.get_itemsCountPerPage());
                paletteItemsMasterView.get_dataSource().read();
                return;
            }
            paletteItemsMasterView.refreshPager(itemsTotalCount);
        }
    });

    var paletteItemsDetailView = new PaletteItemsDetail($("#paletteItemsDetailWindow"), dataSource, webServiceUrl);
    var paletteItemsMasterView = new PaletteItemsMaster(paletteItemsDetailView, dataSource, itemsCountPerPage, webServiceUrl);
    paletteItemsMasterView.set_sortExpression(sortExpression);

    jQuery("body").addClass("sfNoSidebar");

    $("#createUserPaletteItem").click(function () {
        paletteItemsDetailView.show();
    });

    $("#createPaletteItemDecisionScreen").click(function () {
        paletteItemsDetailView.show();
    });

    $(".sfCancelPaletteItemButton").click(function () {
        paletteItemsDetailView.close();
    });

    $("#savePaletteItemButton").click(function () {
        paletteItemsDetailView.save();
    });
});