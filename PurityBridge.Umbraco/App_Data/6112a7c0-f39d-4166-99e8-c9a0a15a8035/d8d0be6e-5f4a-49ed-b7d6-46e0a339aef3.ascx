<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="post-install.ascx.cs" Inherits="uTube.Core.Umbraco.usercontrols.post_install" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<!-- 
	TODO:
		uTube Logo
-->

<style type="text/css">
    #uTube img.logo { margin:0 0 20px 0; }
    #uTube div.codepress { border:1px solid #ccc !important; }
</style>

<umb:Pane runat="server" ID="Pane1" Text="uTube: Installation Success">
    <div id="uTube">
        <!-- Add YouTube Logo here (WebResource) -->
        <img src="<%= this.GetLogo() %>" alt="uTube" class="logo" />

        <!-- umb:Feedback is OK, but adds extra <p> when using text property -->
        <div class="notice">
            <h3>Installation</h3>
            <p>
                For you to finish the installation of uTube, you will need to manually add the following CSS and JS 
                to the masterpage/s &lt;head&gt; tag where you intend to use the chromeless uTube player on your website.
            </p>
            <p>
                <em>
                    Note that you may already have references to the jQuery & SWFObject libraries, if so then ignore 
                    those references in the following code snippet.
                </em>
            </p>
        </div>

        <umb:CodeArea runat="server" ID="codeSnippet"  CodeBase="HTML" Text="<!-- uTube CSS -->
<link href=&quot;/css/uTube.chromeless.player.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; />

<!-- jQuery, SWFObject & uTube JS -->
<script type=&quot;text/javascript&quot; src=&quot;http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js&quot;></script>
<script type=&quot;text/javascript&quot; src=&quot;http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js&quot;></script>
<script type=&quot;text/javascript&quot; src=&quot;/scripts/uTube/chromeless.player.js&quot;></script>" />

        <h3>Documentation</h3>
        <p>
            For the full documentation on how to install, configure and use the uTube package for Umbraco, please visit the CodePlex project page.<br />
            <a href="http://utube.codeplex.com/documentation" target="_blank">uTube - Documentation (CodePlex)</a>
        </p>
    </div>
</umb:Pane>