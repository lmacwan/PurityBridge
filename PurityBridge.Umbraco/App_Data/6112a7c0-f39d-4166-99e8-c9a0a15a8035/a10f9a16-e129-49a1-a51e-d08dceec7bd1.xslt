<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
  <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:atom="http://www.w3.org/2005/Atom"
  xmlns:yt="http://gdata.youtube.com/schemas/2007"
  xmlns:media="http://search.yahoo.com/mrss/"
  xmlns:uTube.XSLT="urn:uTube.XSLT"
  exclude-result-prefixes="msxml umbraco.library atom yt media uTube.XSLT">

  <xsl:output method="xml" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>

  <xsl:template match="/">

    <!-- YouTube URL or VideoID -->
    <xsl:variable name="uTubeVideo"       select="/macro/uTubeVideo" />                         
    
    <!-- Don't do anything unless we have a value in uTubeVideo -->
    <xsl:if test="/macro/uTubeVideo">
      <xsl:variable name="uTubeVideoID"   select="uTube.XSLT:GetVideoId($uTubeVideo)" />          <!-- Video ID from YouTube URL -->
      <xsl:variable name="uTubeXML"       select="uTube.XSLT:GetVideoData($uTubeVideoID, 60)"/>   <!-- 1 minute Cache -->
      <xsl:variable name="uTubeRatio"     select="uTube.XSLT:GetAspectRatio($uTubeVideoID)"/>     <!-- Gets Aspect ratio of video (widescreen or standard)-->

      <!-- Video Width -->
      <xsl:variable name="uTubeWidth">
        <xsl:choose>
          <!-- If the Width is not set, then check if Height is available -->
          <xsl:when test="not(/macro/uTubeWidth) and /macro/uTubeHeight">
            <!-- Use the Height to get the Width -->
            <xsl:value-of select="uTube.XSLT:GetVideoWidth(/macro/uTubeHeight, $uTubeRatio)" />
          </xsl:when>
          <!-- If the Width is set, use it! -->
          <xsl:when test="/macro/uTubeWidth">
            <xsl:value-of select="/macro/uTubeWidth" />
          </xsl:when>
          <!-- Otherwise fall back on a default value -->
          <xsl:otherwise>
            <xsl:value-of select="number(480)" />
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <!-- Video Height -->
      <xsl:variable name="uTubeHeight">
        <xsl:choose>
          <!-- If the Height is not set -->
          <xsl:when test="not(/macro/uTubeHeight)">
            <!-- Then use the Width to get the Height -->
            <xsl:value-of select="uTube.XSLT:GetVideoHeight($uTubeWidth, $uTubeRatio)" />
          </xsl:when>
          <xsl:otherwise>
            <!-- Otherwise use the user-defined value -->
            <xsl:value-of select="/macro/uTubeHeight" />
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>


      <!-- I don't like inline styles but we need to -->
      <div class="youTubePlayer" style="height:{$uTubeHeight}px; width:{$uTubeWidth}px;">
        <xsl:choose>
          <xsl:when test="uTube.XSLT:AllowEmbed($uTubeVideoID) = true()">
            <!-- Video is allowed to be embedded -->
            <div id="{concat('ytPlayerAPI-',$uTubeVideoID)}">
              <p>You need Flash version 8 and JS enabled to view the video</p>
            </div>

            <!-- SWFObject call to Embed Chromless player -->
            <script type="text/javascript">
              //SWF Embedd
              var flashVars   = {video_id : "<xsl:value-of select="$uTubeVideoID"/>", playerapiid: "<xsl:value-of select="concat('ytPlayerAPI-',$uTubeVideoID)" />" }
              var params      = { allowScriptAccess: "always", wmode: "transparent" };
              var atts        = { id: "<xsl:value-of select="concat('ytPlayerAPI-',$uTubeVideoID)" />" };
              swfobject.embedSWF("http://www.youtube.com/apiplayer?enablejsapi=1&amp;version=3&amp;playerapiid=<xsl:value-of select="concat('ytPlayerAPI-',$uTubeVideoID)" />","<xsl:value-of select="concat('ytPlayerAPI-',$uTubeVideoID)" />", "<xsl:value-of select="$uTubeWidth" />", "<xsl:value-of select="$uTubeHeight"/>", "8", null, flashVars, params, atts);
            </script>

            <!-- Controls -->
            <div class="muteControl mute">&nbsp;</div>
            <div class="controlDiv">&nbsp;</div>
            <div class="progressBar">
              <div class="elapsed">
                <xsl:comment></xsl:comment>
              </div>
            </div>
          </xsl:when>
          <xsl:otherwise>
            <!-- Video Not Allowed to be embedded -->
            <p>This video does not allow it to be embedded.</p>
          </xsl:otherwise>
        </xsl:choose>
      </div>
    </xsl:if>

  </xsl:template>
</xsl:stylesheet>