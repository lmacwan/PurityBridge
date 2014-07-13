<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:uTube.XSLT="urn:uTube.XSLT"
  exclude-result-prefixes="msxml umbraco.library uTube.XSLT">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>
  
<xsl:template match="/">

  <!-- Get Media item from mediaID macro parameter -->  
  <xsl:variable name="mediaID" select="/macro/mediaID" />

  <!--
  <xsl:copy-of select="$mediaID" />
  <mediaID>
    <uTubeVideo id="1076" version="90520f7f-6274-41f8-8c51-62c6b663b653" parentID="1072" level="2" writerID="0" nodeType="1070" 
                template="0" sortOrder="1" createDate="2010-10-12T16:34:31" updateDate="2010-10-12T16:34:31" nodeName="Testy Video" 
                urlName="testyvideo" writerName="Administrator" nodeTypeAlias="uTubeVideo" path="-1,1072,1076">
      <uploader>nM24B40QkyY</uploader>
      <uTubeVideoTitle>Test of Chromless player</uTubeVideoTitle>
      <uTubeVideoDescription>I am the description of the video</uTubeVideoDescription>
      <uTubeKeywords>test, warren, chromeless, uTube</uTubeKeywords>
      <uTubePrivateVideo>0</uTubePrivateVideo>
    </uTubeVideo>
  </mediaID>
  -->
  
  <!-- Check we have a mediaID -->  
  <xsl:if test="$mediaID !=''">
    <!-- Video ID from media item -->
    <xsl:variable name="uTubeVideoID" select="uTube.XSLT:GetVideoId($mediaID//uploader)" />
    
    <xsl:variable name="macro">
      <![CDATA[<?UMBRACO_MACRO macroAlias="uTube.ChromelessPlayer" uTubeVideo="]]><xsl:value-of select="$uTubeVideoID"/><![CDATA[" uTubeWidth="]]><xsl:value-of select="/macro/uTubeWidth"/><![CDATA[" uTubeHeight="]]><xsl:value-of select="/macro/uTubeHeight"/><![CDATA["></?UMBRACO_MACRO>]]>
    </xsl:variable>
    
    <!-- Render the chromeless player macro -->
    <xsl:value-of select="umbraco.library:RenderMacroContent($macro, $currentPage/@id)" disable-output-escaping="yes"/>
  </xsl:if>  

</xsl:template>

</xsl:stylesheet>