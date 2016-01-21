<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<asp:Label ID="titleLabel" runat="server" CssClass="sfTxtLbl" />
<asp:TextBox ID="fieldBox" runat="server" CssClass="sfTxt" />
<sf:SitefinityLabel id="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel id="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />

