<%@ Control Language="C#" %>

<fieldset class="sfNewItemForm">
    <a id="backToPaletteItems" href="javascript:void(0);" class="sfBack sfCancelPaletteItemButton">
        <asp:Literal ID="backToMasterLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, BackToLabel %>'></asp:Literal>
    </a>
    <h1>
        <asp:Literal ID="createAPaletteItemLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, CreateAPaletteItem %>'></asp:Literal>
    </h1>
    <div class="sfForm sfFirstForm">
        <ul class="sfFormIn">
            <li class="sfTitleField">
                <label for="paletteItemTitle" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemTitleTitle" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemTitleLabel %>'></asp:Literal>
                </label>
                <input id="paletteItemTitle" type="text" class="sfTxt" />
                <div class="sfExample">
                    <asp:Literal ID="paletteItemTitleDescription" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemTitleDescription %>'></asp:Literal>
                </div>
                <div id="paletteItemTitleValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemTitleEmptyErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemTitleCannotBeEmpty %>'></asp:Literal>
                </div>
                <div id="paletteItemTitleLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemTitleLengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemTitleInvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemDark1" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemDark1Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark1Label %>'></asp:Literal>
                </label>
                <input id="paletteItemDark1" type="text" class="sfTxt" />
                <div id="paletteItemDark1LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemDark1LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark1InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemDark2" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemDark2Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark2Label %>'></asp:Literal>
                </label>
                <input id="paletteItemDark2" type="text" class="sfTxt" />
                <div id="paletteItemDark2LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemDark2LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemDark2InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemLight1" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemLight1Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight1Label %>'></asp:Literal>
                </label>
                <input id="paletteItemLight1" type="text" class="sfTxt" />
                <div id="paletteItemLight1LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemLight1LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight1InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemLight2" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemLight2Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight2Label %>'></asp:Literal>
                </label>
                <input id="paletteItemLight2" type="text" class="sfTxt" />
                <div id="paletteItemLight2LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemLight2LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemLight2InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent1" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent1Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent1Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent1" type="text" class="sfTxt" />
                <div id="paletteItemAccent1LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent1LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent1InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent2" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent2Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent2Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent2" type="text" class="sfTxt" />
                <div id="paletteItemAccent2LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent2LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent2InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent3" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent3Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent3Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent3" type="text" class="sfTxt" />
                <div id="paletteItemAccent3LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent3LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent3InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent4" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent4Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent4Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent4" type="text" class="sfTxt" />
                <div id="paletteItemAccent4LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent4LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent4InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent5" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent5Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent5Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent5" type="text" class="sfTxt" />
                <div id="paletteItemAccent5LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent5LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent5InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemAccent6" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemAccent6Title" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent6Label %>'></asp:Literal>
                </label>
                <input id="paletteItemAccent6" type="text" class="sfTxt" />
                <div id="paletteItemAccent6LengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemAccent6LengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemAccent6InvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemHyperlink" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemHyperlinkTitle" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemHyperlinkLabel %>'></asp:Literal>
                </label>
                <input id="paletteItemHyperlink" type="text" class="sfTxt" />
                <div id="paletteItemHyperlinkLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemHyperlinkLengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemHyperlinkInvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="paletteItemFollowedHyperlink" class="sfTxtLbl">
                    <asp:Literal ID="paletteItemFollowedHyperlinkTitle" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemFollowedHyperlinkLabel %>'></asp:Literal>
                </label>
                <input id="paletteItemFollowedHyperlink" type="text" class="sfTxt" />
                <div id="paletteItemFollowedHyperlinkLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="paletteItemFollowedHyperlinkLengthErrorLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, PaletteItemFollowedHyperlinkInvalidLength %>'></asp:Literal>
                </div>
            </li>

        </ul>
    </div>
        
    <div class="sfButtonArea sfMainFormBtns">
        <a id="savePaletteItemButton" class="sfLinkBtn sfSave">
            <span id="createPaletteItemButtonText" class="sfLinkBtnIn">
                <asp:Literal ID="createPaletteItemButtonLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, CreateThisPaletteItemButton %>' />
            </span>
            <span id="saveChangesPaletteItemButtonText" class="sfLinkBtnIn" style="display:none;">
                <asp:Literal ID="saveChangesPaletteItemButtonLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, SaveChangesLabel %>' />
            </span>
        </a>
        <a id="cancel" class="sfCancel sfCancelPaletteItemButton">
            <asp:Literal ID="cancelLiteral1" runat="server" Text='<%$Resources:PaletteModuleResources, CancelLabel %>' />
        </a>
    </div>
</fieldset>