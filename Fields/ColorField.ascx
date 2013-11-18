<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>
<%@ Register Assembly="Telerik.Web.UI" TagPrefix="telerik" Namespace="Telerik.Web.UI" %>

<asp:Label ID="titleLabel" runat="server" CssClass="sfTxtLbl" />
<telerik:RadColorPicker runat="server" ID="fieldColor"
    PaletteModes="All" CssClass="ColorPickerPreview" KeepInScreenBounds="true"
    ShowEmptyColor="false" ShowRecentColors="true" ShowIcon="true">
</telerik:RadColorPicker>
<sf:SitefinityLabel id="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel id="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />

