<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>

<xsl:param name="CurrentUrl" select="Home"/>

<xsl:template match="xml">
	<table cellspacing="0" cellpadding="0">
		<tr>
			<!-- 
			<td class="debug"><xsl:value-of select="$CurrentUrl"/></td>
			-->
		</tr>
        <xsl:apply-templates select="menu"/>
	</table>
</xsl:template>

<xsl:template name="menu" match="menu">
	<tr>
		<td nowrap="">
			<xsl:attribute name="style">
				text-indent:<xsl:value-of select="10*(count(ancestor::*)-1)"/>;
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="contains($CurrentUrl,@url) or .//menu[contains($CurrentUrl,@url)]">
					<xsl:attribute name="class">selected</xsl:attribute>
					<a href="{@url}"><xsl:value-of select="@text"/></a>
					<xsl:for-each select="menu">
						<xsl:call-template name="menu"/>
					</xsl:for-each>
				</xsl:when>
				<xsl:otherwise>
					<a href="{@url}"><xsl:value-of select="@text"/></a>
				</xsl:otherwise>
			</xsl:choose>
		</td>
	</tr>
</xsl:template>

<xsl:template name="menu_old2" match="menu_old2">
	<tr>
		<td nowrap="">
			<xsl:choose>
				<xsl:when test="contains($CurrentUrl,@url) or .//menu[contains($CurrentUrl,@url)]">
					<xsl:attribute name="class">selected</xsl:attribute> 
					<table cellspacing="0" cellpadding="0">
						<tr><td>
						<a href="{@url}"><xsl:value-of select="@text"/></a>
						<xsl:for-each select="menu">
							<table cellspacing="0" cellpadding="0">
								<tr>
									<td width="12"></td>
									<td>
									<table cellspacing="0" cellpadding="0">
										<tr>
											<td>
											<table cellspacing="0" cellpadding="0">
												<xsl:call-template name="menu"/>
											</table>
											</td>
										</tr>
									</table>
									</td>
								</tr>
							</table>
						</xsl:for-each>
						</td></tr>
					</table>
				</xsl:when>
				<xsl:otherwise>
					<a href="{@url}"><xsl:value-of select="@text"/></a>
				</xsl:otherwise>
			</xsl:choose>
		</td>
	</tr>
</xsl:template>

<xsl:template name="menu_old" match="menu_old">
	<tr>
		<td nowrap="">
			<xsl:if test="contains($CurrentUrl,@url) or .//menu[contains($CurrentUrl,@url)]">
				<xsl:attribute name="class">selected</xsl:attribute> 
			</xsl:if>
			<a href="{@url}"><xsl:value-of select="@text"/>
			</a>
		</td>
	</tr>
	<xsl:if test="contains($CurrentUrl,@url) or .//menu[contains($CurrentUrl,@url)]">
		<xsl:for-each select="menu">
			<tr>
				<td>
				<table border="0" cellspacing="0" cellpadding="0" bordercolor="black">
					<tr>
						<td width="12"></td>
						<td>
						<table border="0" cellspacing="0" cellpadding="0" bordercolor="black">
							<tr>
								<td>
								<table border="0" cellspacing="0" cellpadding="0" bordercolor="black">
									<xsl:call-template name="menu"/>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
		</xsl:for-each>
	</xsl:if>
</xsl:template>

</xsl:stylesheet>
  