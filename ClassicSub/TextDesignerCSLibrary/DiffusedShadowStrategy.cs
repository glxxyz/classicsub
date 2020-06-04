using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestDesignerCSLibrary
{
    class DiffusedShadowStrategy : ITextStrategy
    {
	    public DiffusedShadowStrategy()
        {
            m_nThickness=8;
            m_bOutlinetext = false;
            m_brushText = null;
            m_bClrText = true;
        }
        ~DiffusedShadowStrategy()
        {

        }

	    public void Init(
		    System.Drawing.Color clrText, 
		    System.Drawing.Color clrOutline, 
		    int nThickness,
		    bool bOutlinetext)
        {
            m_clrText = clrText;
            m_bClrText = true;
            m_clrOutline = clrOutline;
            m_nThickness = nThickness;
            m_bOutlinetext = bOutlinetext;
        }

        public void Init(
            System.Drawing.Brush brushText, 
            System.Drawing.Color clrOutline,
            int nThickness,
            bool bOutlinetext)
        {
            m_brushText = brushText;
            m_bClrText = false;
            m_clrOutline = clrOutline;
            m_nThickness = nThickness;
            m_bOutlinetext = bOutlinetext;
        }

        public bool DrawString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int fontSize,
            string strText,
            System.Drawing.Point ptDraw,
            System.Drawing.StringFormat strFormat)
        {
	        GraphicsPath path = new GraphicsPath();
	        path.AddString(strText, fontFamily, (int)fontStyle, fontSize, ptDraw, strFormat);

            for (int i = 1; i <= m_nThickness; ++i)
            {
                Pen pen = new Pen(m_clrOutline, i);
                pen.LineJoin = LineJoin.Round;
                graphics.DrawPath(pen, path);
            }

            if (m_bOutlinetext == false)
            {
                for (int i = 1; i <= m_nThickness; ++i)
                {
                    if (m_bClrText)
                    {
                        SolidBrush brush = new SolidBrush(m_clrText);
                        graphics.FillPath(brush, path);
                    }
                    else
                        graphics.FillPath(m_brushText, path);
                }
            }
            else
            {
                if (m_bClrText)
                {
                    SolidBrush brush = new SolidBrush(m_clrText);
                    graphics.FillPath(brush, path);
                }
                else
                    graphics.FillPath(m_brushText, path);
            }
            
	        return true;
        }


        public bool DrawString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int fontSize,
            string strText,
            System.Drawing.Rectangle rtDraw,
            System.Drawing.StringFormat strFormat)
        {
	        GraphicsPath path = new GraphicsPath();
	        path.AddString(strText, fontFamily, (int)fontStyle, fontSize, rtDraw, strFormat);

            for (int i = 1; i <= m_nThickness; ++i)
            {
                Pen pen = new Pen(m_clrOutline, i);
                pen.LineJoin = LineJoin.Round;
                graphics.DrawPath(pen, path);
            }

	        if(m_bOutlinetext==false)
	        {
		        for(int i=1; i<=m_nThickness; ++i)
		        {
                    if (m_bClrText)
                    {
                        SolidBrush brush = new SolidBrush(m_clrText);
                        graphics.FillPath(brush, path);
                    }
                    else
                        graphics.FillPath(m_brushText, path);
                }
	        }
	        else
	        {
                if (m_bClrText)
                {
                    SolidBrush brush = new SolidBrush(m_clrText);
                    graphics.FillPath(brush, path);
                }
                else
                    graphics.FillPath(m_brushText, path);
            }

	        return true;
        }


        public bool MeasureString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int fontSize,
            string strText,
            System.Drawing.Point ptDraw,
            System.Drawing.StringFormat strFormat,
            ref float fDestWidth,
            ref float fDestHeight)
        {
            GraphicsPath path = new GraphicsPath();
	        path.AddString(strText, fontFamily, (int)fontStyle, fontSize, ptDraw, strFormat);

	        fDestWidth= ptDraw.X;
	        fDestHeight= ptDraw.Y;
	        bool b = GDIPath.MeasureGraphicsPath(graphics, path, ref fDestWidth, ref fDestHeight);

	        if(false==b)
		        return false;

	        float pixelThick = 0.0f;
            float pixelThick2 = 0.0f;
            b = GDIPath.ConvertToPixels(graphics, m_nThickness, 0.0f, ref pixelThick, ref pixelThick2);

	        if(false==b)
		        return false;

	        fDestWidth += pixelThick;
	        fDestHeight += pixelThick;

	        return true;
        }

        public bool MeasureString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int fontSize,
            string strText,
            System.Drawing.Rectangle rtDraw,
            System.Drawing.StringFormat strFormat,
            ref float fDestWidth,
            ref float fDestHeight)
        {
            GraphicsPath path = new GraphicsPath();
	        path.AddString(strText, fontFamily, (int)fontStyle, fontSize, rtDraw, strFormat);

	        fDestWidth= rtDraw.Width;
	        fDestHeight= rtDraw.Height;
            bool b = GDIPath.MeasureGraphicsPath(graphics, path, ref fDestWidth, ref fDestHeight);

	        if(false==b)
		        return false;

	        float pixelThick = 0.0f;
            float pixelThick2 = 0.0f;
            b = GDIPath.ConvertToPixels(graphics, m_nThickness, 0.0f, ref pixelThick, ref pixelThick2);

	        if(false==b)
		        return false;

	        fDestWidth += pixelThick;
	        fDestHeight += pixelThick;

	        return true;
        }


	    protected System.Drawing.Color m_clrText;
	    protected System.Drawing.Color m_clrOutline;
	    protected int m_nThickness;
        protected bool m_bOutlinetext;
        protected System.Drawing.Brush m_brushText;
        protected bool m_bClrText;
    }
}
