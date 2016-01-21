<%@ Control Language="C#" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="PaletteModule" Assembly="PaletteModule" Namespace="PaletteModule.Web.UI.PaletteItems" %>
<%@ Import Namespace="PaletteModule" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile Name="Styles/DatePicker.css" />
    <sitefinity:ResourceFile Name="Styles/Grid.css" />
    <sitefinity:ResourceFile Name="Styles/ListView.css" />
    <sitefinity:ResourceFile Name="Styles/MaxWindow.css" />
    <sitefinity:ResourceFile Name="Styles/MenuMoreActions.css" />
    <sitefinity:ResourceFile Name="Styles/Tabstrip.css" />
    <sitefinity:ResourceFile Name="Styles/Window.css" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.JSON2.js" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_default_min.css" Static="True" />
    <sitefinity:ResourceFile Name="PaletteModule.Web.Resources.CustomStylesKendoUIView.css" AssemblyInfo="PaletteModule.PaletteModuleClass, PaletteModule" Static="True" />
</sitefinity:ResourceLinks>
<h1 class="sfBreadCrumb">
    <asp:Literal runat="server" Text='PaletteModule'/>
</h1>
<div class="sfMain sfClearfix">
    <div class="sfContent">
        <!-- toolbar -->
        <div id="toolbar" class="sfAllToolsWrapper">
            <div class="sfAllTools">
                <ul class="sfActions">
                    <li class="sfMainAction">
                        <a id="createUserPaletteItem" class="sfLinkBtn sfSave">
                            <span class="sfLinkBtnIn">
                                <asp:Literal ID="createAPaletteItem" runat="server" Text='<%$Resources:PaletteModuleResources, CreateAPaletteItem %>'/>
                            </span>
                        </a>
                    </li>
                    <li class="sfGroupBtn">
                        <a id="deleteUserPaletteItems" class="sfLinkBtn sfDisabledLinkBtn">
                            <span class="sfLinkBtnIn">
                                <asp:Literal ID="deleteUserPaletteItemsLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, DeleteLabel %>'/>
                            </span>
                        </a>
                    </li>
                    <li class="sfQuickSort sfNoMasterViews sfDropdownList">
                        <asp:Literal ID="SortLiteral" runat="server" Text='<%$Resources:PaletteModuleResources, SortLabel %>'/>
                        <input id="sortingDropDownList" />
                    </li>
                </ul>
            </div>
        </div>

        <!-- main area -->
        <div class="sfWorkArea" id="workArea">
            <div id="paletteItemsMasterView">
                <PaletteModule:PaletteItemsMaster id="PaletteItemsMaster" runat="server" />
            </div>
            <div id="paletteItemsDetailWindow" class="sfDialog sfFormDialog k-sitefinity">
                <PaletteModule:PaletteItemsDetail id="PaletteItemsDetail" runat="server" />
            </div>
        </div>
    </div>
</div>

<input id="paletteItemsServiceUrlHidden" type="hidden" value="<%= VirtualPathUtility.ToAbsolute("~/" + PaletteModuleClass.PaletteItemsWebServiceUrl)  %>" />
