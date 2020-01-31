<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="flash"/>
  <xsl:template match="AdMenuTop">
    <xsl:choose>
      <xsl:when test="$flash='SWF'"> 
        <object border="0" width="100%" height="120" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="100%" height="120" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" alt="quảng cáo"  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdCenter">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="490" height="90" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="490" height="90" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" width="980" height="90" border="0" alt=""  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdBottom">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="100%" height="120" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="100%" height="120" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" alt="quảng cáo"  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <xsl:template match="AdLeftTop">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="679" height="90" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="679" height="90" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" width="679" border="0" alt=""  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdRightTop">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="100%" height="150" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="100%" height="150" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" border="0" alt="quảng cáo"  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdRightCenter">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="100%" height="150" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="100%" height="150" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" alt="quảng cáo"  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdRightBottom">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="100%" height="150" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="150%" height="150" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" border="0" alt="quảng cáo"  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <xsl:template match="AdSlide">
    <xsl:choose>
      <xsl:when test="$flash='SWF'">
        <object border="0" width="100%" height="300" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">
          <param name="movie" value="@_Banner_@" />
          <param name="AllowScriptAccess" value="always" />
          <param name="quality" value="High" />
          <param name="wmode" value="transparent" />
          <param value="allowscale" name="true" />
          <embed width="100%" height="300" src="@_Banner_@" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" play="true" loop="true" wmode="transparent" allowscriptaccess="always" />
        </object>
      </xsl:when>
      <xsl:otherwise>
        <img src="@_Banner_@" width="114" border="0" alt=""  />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
</xsl:stylesheet>