using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestDesignerCSLibrary
{
    public class ExtrudeStrategy : ITextStrategy
    {
	    public ExtrudeStrategy()
        {
            m_nThickness=2;
            m_brushText = null;
            m_bClrText = true;
        }
        ~ExtrudeStrategy()
        {

        }

	    public void Init(
		    System.Drawing.Color clrText, 
		    System.Drawing.Color clrOutline, 
		    int nThickness,
            int nOffsetX,
        	int nOffsetY )
        {
            m_clrText = clrText;
            m_bClrText = true;
            m_clrOutline = clrOutline;
            m_nThickness = nThickness;
            m_nOffsetX = nOffsetX;
            m_nOffsetY = nOffsetY;
        }

        public void Init(
            System.Drawing.Brush brushText,
            System.Drawing.Color clrOutline,
            int nThickness,
            int nOffsetX,
            int nOffsetY)
        {
            m_brushText = brushText;
            m_bClrText = false;
            m_clrOutline = clrOutline;
            m_nThickness = nThickness;
            m_nOffsetX = nOffsetX;
            m_nOffsetY = nOffsetY;
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
            int nOffset = Math.Abs(m_nOffsetX);
            if (Math.Abs(m_nOffsetX) == Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetX);
            }
            else if (Math.Abs(m_nOffsetX) > Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetY);
            }
            else if (Math.Abs(m_nOffsetX) < Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetX);
            }

	        for(int i=0; i<nOffset; ++i)
	        {
	            GraphicsPath path = new GraphicsPath();
	            path.AddString(strText, fontFamily, (int)fontStyle, fontSize,
			        new Point(ptDraw.X+((i*(-m_nOffsetX))/nOffset),ptDraw.Y+((i*(-m_nOffsetY))/nOffset) ),
			        strFormat);

	            Pen pen = new Pen(m_clrOutline,m_nThickness);
	            pen.LineJoin=LineJoin.Round;
	            graphics.DrawPath(pen, path);

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
            int nOffset = Math.Abs(m_nOffsetX);
            if (Math.Abs(m_nOffsetX) == Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetX);
            }
            else if (Math.Abs(m_nOffsetX) > Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetY);
            }
            else if (Math.Abs(m_nOffsetX) < Math.Abs(m_nOffsetY))
            {
                nOffset = Math.Abs(m_nOffsetX);
            }

            for (int i = 0; i < nOffset; ++i)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddString(strText, fontFamily, (int)fontStyle, fontSize,
                    new Rectangle(rtDraw.X+((i*(-m_nOffsetX))/nOffset), rtDraw.Y+((i*(-m_nOffsetY))/nOffset), 
				        rtDraw.Width, rtDraw.Height),
                    strFormat);

                Pen pen = new Pen(m_clrOutline, m_nThickness);
                pen.LineJoin = LineJoin.Round;
                graphics.DrawPath(pen, path);

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
        protected int m_nOffsetX;
	    protected int m_nOffsetY;
        protected System.Drawing.Brush m_brushText;
        protected bool m_bClrText;
    }
}
