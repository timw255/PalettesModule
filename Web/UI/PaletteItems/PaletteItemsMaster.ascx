<%@ Control Language="C#" %>

<style type="text/css">
.k-loading-mask { visibility: hidden; }
.dmDescription{padding:10px; display:inline-block;}
.dmDescription span { font-size:.8em;}
.sfLarge{width:200px !important;}
.sfTitleCol{padding-right:40px !important;}
</style>
<!-- no paletteItems created screen -->
<div id="paletteItemsDecisionScreen" style="display:none;" class="sfEmptyList">
    <p class="sfMessage sfMsgNeutral sfMsgVisible"><asp:Literal ID="noPaletteItemsCreatedLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, NoPaletteItemsCreatedMessage %>'></asp:Literal></p>
    <ol class="sfWhatsNext">
        <li class="sfCreateItem">
            <a id="createPaletteItemDecisionScreen">
                <asp:Literal ID="createAPaletteItemLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, CreateAPaletteItem %>'></asp:Literal>
                <span class="sfDecisionIcon"></span>
            </a>
        </li>
    </ol>
</div>

<!-- paletteItems grid -->
<table id="paletteItemsGrid" class="rgTopOffset rgMasterTable" style="display: none;">
        <thead>
        <tr>
            <th class="sfCheckBoxCol">
                <input type="checkbox" id="checkAllCheckbox" name="checkAllCheckbox" value="" />
            </th>
            <th class="sfTitleCol" colspan="13">
                <asp:Literal ID="paletteItemHeader" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemTitleLabel %>'></asp:Literal>
            </th>
            <th class="sfMoreActions sfLast">
                <asp:Literal ID="actionsHeader" runat="server" Text='<%$Resources:PaletteModuleResources, ActionsLabel %>'></asp:Literal>
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td colspan="15">
            </td>
        </tr>
    </tbody>
    <tfoot>
        <tr class="rgPager">
            <td class="rgPagerCell NumericPages" colspan="15">
                <div class="rgWrap rgNumPart">
                    <div id="pagesWrapper">
                    </div>
                </div>
            </td>
        </tr>
    </tfoot>
</table>
<!-- paletteItems grid row template -->
<script id="paletteItemsRowTemplate" type="text/x-kendo-template" style="display: none;">
    <tr>
        <td class="sfCheckBoxCol">
            <input type="checkbox" data-command="check" data-id="#= Id #" value=""/>
        </td>
        <td class="sfTitleCol">
            <a class="sfEditButton sfItemTitle sfactive" data-command="edit" data-id="#= Id #">
                <strong>#= Title #</strong>                
            </a>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Dark1 #;">
                <strong><asp:Literal ID="dark1Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark1Label %>'></asp:Literal></strong>
                <br />#= Dark1 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Dark2 #;">
    <strong><asp:Literal ID="dark2Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark2Label %>'></asp:Literal></strong>
    <br />#= Dark2 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Light1 #;"><strong> <asp:Literal ID="light1Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight1Label %>'></asp:Literal></strong><br />#= Light1 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Light2 #;"><strong> <asp:Literal ID="light2Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight2Label %>'></asp:Literal></strong><br />#= Light2 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent1 #;"><strong><asp:Literal ID="accent1Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent1Label %>'></asp:Literal></strong><br />#= Accent1 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent2 #;"><strong><asp:Literal ID="accent2Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent2Label %>'></asp:Literal></strong><br />#= Accent2 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent3 #;"><strong><asp:Literal ID="accent3Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent3Label %>'></asp:Literal></strong><br />#= Accent3 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent4 #;"><strong><asp:Literal ID="accent4Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent4Label %>'></asp:Literal></strong><br />#= Accent4 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent5 #;"><strong><asp:Literal ID="accent5Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent5Label %>'></asp:Literal></strong><br />#= Accent5 #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Accent6 #;"><strong><asp:Literal ID="accent6Header" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent6Label %>'></asp:Literal></strong><br /><span>#= Accent6 #</span> </div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= Hyperlink #;"><strong><asp:Literal ID="hyperlinkHeader" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemHyperlinkLabel %>'></asp:Literal></strong><br />#= Hyperlink #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription" style="border:solid 2px #= FollowedHyperlink #;"><strong>  <asp:Literal ID="followedHyperlinkHeader" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemFollowedHyperlinkLabel %>'></asp:Literal></strong><br />#= FollowedHyperlink #</div>
        </td>
        <td class="sfMoreActions sfLast">
            <ul class="sfActionsMenu">
                <li class="sfFirst sfLast">
                    #= ActionsLabel #
                    <ul>
                        <li>
                            <a class="sfDeleteItm" data-command="delete" data-id="#= Id #">
                                #= DeleteLabel #
                            </a>
                        </li>   
                    </ul>
                <li>
            </ul>
        </td>
    </tr>
</script>
<!-- END paletteItems grid row template -->

<div id="deletePaletteItemConfirmationDialog" class="sfSelectorDialog">
    <p>
        <asp:Literal ID="deletePaletteItemConfirmationLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, DeletePaletteItemConfirmationMessage %>'/>
    </p>
    <div class="sfButtonArea">
        <a id="confirmPaletteItemDeleteButton" class="sfLinkBtn sfDelete">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="deletePaletteItemButtonLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, YesDeleteThisItemButton %>'/>
            </span>
        </a>
        <a id="cancelDeletePaletteItemButton" class="sfCancel">
            <asp:Literal ID="cancelDeleteLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, CancelLabel %>'/>
        </a>
    </div>
</div>

<div id="batchDeletePaletteItemConfirmationDialog" class="sfSelectorDialog">
    <p>
        <span id="batchDeletePaletteItemCountLabel"></span>
        <span id="batchDeletePaletteItemConfirmationSpan">
            <asp:Literal ID="batchDeletePaletteItemConfirmationLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, BatchDeleteConfirmationMessage %>'/>
        </span>
    </p>
    <div class="sfButtonArea">
        <a id="confirmPaletteItemBatchDeleteButton" class="sfLinkBtn sfDelete">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="batchDeletePaletteItemButtonLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, YesDeleteTheseItemsButton %>'/>
            </span>
        </a>
        <a id="cancelBatchDeletePaletteItemButton" class="sfCancel">
            <asp:Literal ID="cancelBatchDeleteLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, CancelLabel %>'/>
        </a>
    </div>
</div>

<div id="paletteItemCustomSortingDialog" class="sfSelectorDialog">
    <h1><asp:literal ID="customSortingDialogHeader" runat="server" Text="<%$Resources:PaletteModuleResources, CustomSortingDialogHeader%>" /></h1>
    <div class="sfSortingCondition">
        <div class="sfSortRules">
            <label class="sfTxtLbl" for="customSortingPaletteItemPropertiesDropDownList">
                <asp:Literal ID="sortByLiteral" runat="server" Text="<%$Resources:PaletteModuleResources, SortByLabel%>" />
            </label>
			<div class="sfDropdownList sfInlineBlock sfAlignTop">
				<input id="customSortingPaletteItemPropertiesDropDownList" class="valid" />
			</div>
            <div class="sfInlineBlock">
                <ol class="sfRadioList">
                    <li>
                        <input id="ascendingRadioButton" type="radio" value="ASC" name="customSortingOrder" checked="checked">
                        <label for="ascendingRadioButton">Ascending</label>
                    </li>
                    <li>
                        <input id="descendingRadioButton" type="radio" value="DESC" name="customSortingOrder">
                        <label for="descendingRadioButton">Descending</label>
                    </li>
                </ol>
            </div>
        </div>
    </div>

    <div class="sfButtonArea sfSelectorBtns">
        <a ID="saveCustomSortingButton" Class="sfLinkBtn sfSave">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="saveCustomSortingLiteral" runat="server" Text="<%$Resources:PaletteModuleResources, SaveLabel %>" />
            </span>
        </a>
        <asp:Literal ID="orLiteral" runat="server" Text="<%$Resources:PaletteModuleResources, OrLabel%>" />
        <a ID="cancelCustomSortingButton" Class="sfCancel">
            <asp:Literal ID="cancelCustomSortingLiteral" runat="server" Text="<%$Resources:PaletteModuleResources, CancelLabel %>" />
        </a>
    </div>
</div>