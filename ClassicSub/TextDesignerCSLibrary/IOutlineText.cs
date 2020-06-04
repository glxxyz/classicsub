using System;
using System.Collections.Generic;
using System.Text;

namespace TestDesignerCSLibrary
{
    public interface IOutlineText
    {
	void TextGlow(
		System.Drawing.Color clrText, 
		System.Drawing.Color clrOutline, 
		int nThickness);

    void TextGlow(
        System.Drawing.Brush brushText,
        System.Drawing.Color clrOutline,
        int nThickness);
    
    void TextOutline(
		System.Drawing.Color clrText, 
		System.Drawing.Color clrOutline, 
		int nThickness);

    void TextOutline(
        System.Drawing.Brush brushText,
        System.Drawing.Color clrOutline,
        int nThickness);
    
    void TextDblOutline(
		System.Drawing.Color clrText, 
		System.Drawing.Color clrOutline1, 
		System.Drawing.Color clrOutline2, 
		int nThickness1, 
		int nThickness2);

    void TextDblOutline(
        System.Drawing.Brush brushText,
        System.Drawing.Color clrOutline1,
        System.Drawing.Color clrOutline2,
        int nThickness1,
        int nThickness2);
    
    void SetShadowBkgd(System.Drawing.Bitmap pBitmap);

	void SetShadowBkgd(System.Drawing.Color clrBkgd, int nWidth, int nHeight);

	void SetNullShadow();
	
	void EnableShadow(bool bEnable);

	void Shadow(
		System.Drawing.Color color, 
		int nThickness,
		System.Drawing.Point ptOffset);

	bool DrawString(
		System.Drawing.Graphics graphics, 
		System.Drawing.FontFamily fontFamily,
		System.Drawing.FontStyle fontStyle,
		int nfontSize,
		string strText, 
		System.Drawing.Point ptDraw, 
		System.Drawing.StringFormat strFormat);

	bool DrawString(
		System.Drawing.Graphics graphics, 
		System.Drawing.FontFamily fontFamily,
		System.Drawing.FontStyle fontStyle,
		int nfontSize,
		string strText, 
		System.Drawing.Rectangle rtDraw,
		System.Drawing.StringFormat pStrFormat);

	bool MeasureString(
		System.Drawing.Graphics graphics, 
		System.Drawing.FontFamily fontFamily,
		System.Drawing.FontStyle fontStyle,
		int nfontSize,
		string strText, 
		System.Drawing.Point ptDraw, 
		System.Drawing.StringFormat strFormat,
		ref float fDestWidth,
		ref float fDestHeight );

	bool MeasureString(
		System.Drawing.Graphics graphics, 
		System.Drawing.FontFamily fontFamily,
		System.Drawing.FontStyle fontStyle,
		int nfontSize,
		string strText, 
		System.Drawing.Rectangle rtDraw,
		System.Drawing.StringFormat strFormat,
		ref float fDestWidth,
		ref float fDestHeight );

    }
}
