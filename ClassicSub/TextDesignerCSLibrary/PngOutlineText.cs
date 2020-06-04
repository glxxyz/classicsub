using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TestDesignerCSLibrary
{
    public class PngOutlineText : IOutlineText
    {
        public PngOutlineText()
        {
            m_pTextStrategy = null;
            m_pTextStrategyMask = null;
            m_pShadowStrategy = null;
            m_pShadowStrategyMask = null;
            m_pFontBodyShadow = null;
            m_pFontBodyShadowMask = null;
            m_pBkgdBitmap = null;
            m_pPngBitmap = null;
            m_clrShadow = System.Drawing.Color.FromArgb(0, 0, 0);
            m_bEnableShadow = false;
            m_bDiffuseShadow = false;
            m_nShadowThickness = 2;
        }
        ~PngOutlineText()
        {
            m_pTextStrategy = null;
            m_pTextStrategyMask = null;
            m_pShadowStrategy = null;
            m_pShadowStrategyMask = null;
            m_pFontBodyShadow = null;
            m_pFontBodyShadowMask = null;
        }

        public void TextGlow(
            System.Drawing.Color clrText,
            System.Drawing.Color clrOutline,
            int nThickness)
        {
	        TextGlowStrategy pStrat = new TextGlowStrategy();
	        pStrat.Init(clrText,clrOutline,nThickness);

	        m_pTextStrategy = pStrat;

	        TextGlowStrategy pStrat2 = new TextGlowStrategy();
	        pStrat2.Init(
		        System.Drawing.Color.FromArgb(clrText.A,255,255,255),
		        System.Drawing.Color.FromArgb(clrOutline.A,255,255,255),
		        nThickness);

	        m_pTextStrategyMask = pStrat2;
        }

        public void TextGlow(
            System.Drawing.Brush brushText,
            System.Drawing.Color clrOutline,
            int nThickness)
        {
            TextGlowStrategy pStrat = new TextGlowStrategy();
            pStrat.Init(brushText, clrOutline, nThickness);

            m_pTextStrategy = pStrat;

            TextGlowStrategy pStrat2 = new TextGlowStrategy();
            pStrat2.Init(
                System.Drawing.Color.FromArgb(255, 255, 255, 255),
                System.Drawing.Color.FromArgb(clrOutline.A, 255, 255, 255),
                nThickness);

            m_pTextStrategyMask = pStrat2;
        }

        public void TextOutline(
            System.Drawing.Color clrText,
            System.Drawing.Color clrOutline,
            int nThickness)
            {
	            TextOutlineStrategy pStrat = new TextOutlineStrategy();
	            pStrat.Init(clrText,clrOutline,nThickness);

	            m_pTextStrategy = pStrat;

	            TextOutlineStrategy pStrat2 = new TextOutlineStrategy();
	            pStrat2.Init(
		            System.Drawing.Color.FromArgb(clrText.A,255,255,255),
                    System.Drawing.Color.FromArgb(clrOutline.A, 255, 255, 255),
		            nThickness);

	            m_pTextStrategyMask = pStrat2;
            }

        public void TextOutline(
            System.Drawing.Brush brushText,
            System.Drawing.Color clrOutline,
            int nThickness)
        {
            TextOutlineStrategy pStrat = new TextOutlineStrategy();
            pStrat.Init(brushText, clrOutline, nThickness);

            m_pTextStrategy = pStrat;

            TextOutlineStrategy pStrat2 = new TextOutlineStrategy();
            pStrat2.Init(
                System.Drawing.Color.FromArgb(255, 255, 255, 255),
                System.Drawing.Color.FromArgb(clrOutline.A, 255, 255, 255),
                nThickness);

            m_pTextStrategyMask = pStrat2;
        }

        public void TextDblOutline(
            System.Drawing.Color clrText,
            System.Drawing.Color clrOutline1,
            System.Drawing.Color clrOutline2,
            int nThickness1,
            int nThickness2)
        {
	        TextDblOutlineStrategy pStrat = new TextDblOutlineStrategy();
	        pStrat.Init(clrText,clrOutline1,clrOutline2,nThickness1,nThickness2);

	        m_pTextStrategy = pStrat;

	        TextDblOutlineStrategy pStrat2 = new TextDblOutlineStrategy();
	        pStrat2.Init(
		        System.Drawing.Color.FromArgb(clrText.A,255,255,255),
                System.Drawing.Color.FromArgb(clrOutline1.A, 255, 255, 255),
                System.Drawing.Color.FromArgb(clrOutline2.A, 255, 255, 255),
		        nThickness1,
		        nThickness2);

	        m_pTextStrategyMask = pStrat2;
        }

        public void TextDblOutline(
            System.Drawing.Brush brushText,
            System.Drawing.Color clrOutline1,
            System.Drawing.Color clrOutline2,
            int nThickness1,
            int nThickness2)
        {
            TextDblOutlineStrategy pStrat = new TextDblOutlineStrategy();
            pStrat.Init(brushText, clrOutline1, clrOutline2, nThickness1, nThickness2);

            m_pTextStrategy = pStrat;

            TextDblOutlineStrategy pStrat2 = new TextDblOutlineStrategy();
            pStrat2.Init(
                System.Drawing.Color.FromArgb(255, 255, 255, 255),
                System.Drawing.Color.FromArgb(clrOutline1.A, 255, 255, 255),
                System.Drawing.Color.FromArgb(clrOutline2.A, 255, 255, 255),
                nThickness1,
                nThickness2);

            m_pTextStrategyMask = pStrat2;
        }

        public void SetShadowBkgd(System.Drawing.Bitmap pBitmap)
        {
	        m_pBkgdBitmap = pBitmap;
        }

        public void SetShadowBkgd(System.Drawing.Color clrBkgd, int nWidth, int nHeight)
        {
	        m_pBkgdBitmap = new System.Drawing.Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);

	        System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(m_pBkgdBitmap);
	        System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(clrBkgd);
	        graphics.FillRectangle(brush, 0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height );
        }

        public void SetNullShadow()
        {
	        m_pFontBodyShadow = null;
	        m_pShadowStrategy = null;
        }

        public void EnableShadow(bool bEnable)
        {
	        m_bEnableShadow = bEnable;
        }

        public void Shadow(
            System.Drawing.Color color,
            int nThickness,
            System.Drawing.Point ptOffset)
        {
	        TextOutlineStrategy pStrat = new TextOutlineStrategy();
	        pStrat.Init(System.Drawing.Color.FromArgb(0,0,0,0),color,nThickness);

	        m_ptShadowOffset = ptOffset;
	        m_pShadowStrategy = pStrat;

	        TextOutlineStrategy pStrat2 = new TextOutlineStrategy();
	        pStrat2.Init(
		        System.Drawing.Color.FromArgb(0,0,0,0),
		        System.Drawing.Color.FromArgb(color.A,255,255,255),
		        nThickness);

	        m_pShadowStrategyMask = pStrat2;

	        m_clrShadow = color;

	        TextOutlineStrategy pFontBodyShadow = new TextOutlineStrategy();
	        pFontBodyShadow.Init(System.Drawing.Color.FromArgb(255,255,255),System.Drawing.Color.FromArgb(0,0,0,0),0);
	        m_pFontBodyShadow = pFontBodyShadow;

	        TextOutlineStrategy pFontBodyShadowMask = new TextOutlineStrategy();
            pFontBodyShadowMask.Init(System.Drawing.Color.FromArgb(color.A, 255, 255, 255), System.Drawing.Color.FromArgb(0, 0, 0, 0), 0);
	        m_pFontBodyShadowMask = pFontBodyShadowMask;
	        m_bDiffuseShadow = false;
        }

        public void DiffusedShadow(
	        System.Drawing.Color color, 
	        int nThickness,
	        System.Drawing.Point ptOffset)
        {
	        DiffusedShadowStrategy pStrat = new DiffusedShadowStrategy();
            pStrat.Init(System.Drawing.Color.FromArgb(0, 0, 0, 0), color, nThickness, false);

	        m_ptShadowOffset = ptOffset;
	        m_pShadowStrategy = pStrat;

	        DiffusedShadowStrategy pStrat2 = new DiffusedShadowStrategy();
	        pStrat2.Init(
		        System.Drawing.Color.FromArgb(0,0,0,0),
		        System.Drawing.Color.FromArgb(color.A,255,255,255),
		        nThickness,
		        true);

	        m_pShadowStrategyMask = pStrat2;

	        m_clrShadow = color;

	        DiffusedShadowStrategy pFontBodyShadow = new DiffusedShadowStrategy();
	        pFontBodyShadow.Init(System.Drawing.Color.FromArgb(255,255,255),System.Drawing.Color.FromArgb(0,0,0,0),nThickness,false);

	        m_pFontBodyShadow = pFontBodyShadow;

	        DiffusedShadowStrategy pFontBodyShadowMask = new DiffusedShadowStrategy();
	        pFontBodyShadowMask.Init(System.Drawing.Color.FromArgb(color.A,255,255,255),System.Drawing.Color.FromArgb(0,0,0,0),
		        nThickness,false);

	        m_pFontBodyShadowMask = pFontBodyShadowMask;
	        m_bDiffuseShadow = true;
	        m_bExtrudeShadow = false;
	        m_nShadowThickness = nThickness;
        }

        public void Extrude(
	        System.Drawing.Color color, 
	        int nThickness,
	        System.Drawing.Point ptOffset)
        {
	        ExtrudeStrategy pStrat = new ExtrudeStrategy();
	        pStrat.Init(System.Drawing.Color.FromArgb(0,0,0,0), color, nThickness, ptOffset.X, ptOffset.Y);

	        m_ptShadowOffset = ptOffset;
	        m_pShadowStrategy = pStrat;

	        ExtrudeStrategy pStrat2 = new ExtrudeStrategy();
	        pStrat2.Init(
		        System.Drawing.Color.FromArgb(0,0,0,0),
		        System.Drawing.Color.FromArgb(color.A,255,255,255),
		        nThickness,
		        ptOffset.X, ptOffset.Y);

	        m_pShadowStrategyMask = pStrat2;

	        m_clrShadow = color;

	        ExtrudeStrategy pFontBodyShadow = new ExtrudeStrategy();
	        pFontBodyShadow.Init(System.Drawing.Color.FromArgb(255,255,255),System.Drawing.Color.FromArgb(0,0,0,0), nThickness, ptOffset.X, ptOffset.Y);

	        m_pFontBodyShadow = pFontBodyShadow;

	        ExtrudeStrategy pFontBodyShadowMask = new ExtrudeStrategy();
	        pFontBodyShadowMask.Init(System.Drawing.Color.FromArgb(color.A,255,255,255), System.Drawing.Color.FromArgb(0,0,0,0), 
		        nThickness, ptOffset.X, ptOffset.Y);

	        m_pFontBodyShadowMask = pFontBodyShadowMask;
	        m_bExtrudeShadow = true;
	        m_bDiffuseShadow = false;
	        m_nShadowThickness = nThickness;
        }

        public void SetPngImage(System.Drawing.Bitmap pBitmap)
        {
	        m_pPngBitmap = pBitmap;
        }

        public System.Drawing.Bitmap GetPngImage()
        {
	        return m_pPngBitmap;
        }
        
        public bool DrawString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int nfontSize,
            string strText,
            System.Drawing.Point ptDraw,
            System.Drawing.StringFormat strFormat)
        {
	        if(graphics==null) return false;

	        System.Drawing.Graphics pGraphicsDrawn=null;
	        System.Drawing.Bitmap pBmpDrawn=null;

	        if(m_bEnableShadow&&m_pBkgdBitmap!=null&&m_pFontBodyShadow!=null&&m_pShadowStrategy!=null&&m_pShadowStrategyMask!=null)
	        {
		        System.Drawing.Graphics pGraphicsMask=null;
		        System.Drawing.Bitmap pBmpMask=null;

		        bool b = RenderTransShadowA( graphics, ref pGraphicsMask, ref pBmpMask, ref pGraphicsDrawn, ref pBmpDrawn);

		        if(!b) return false;

		        b = RenderFontShadow(
			        pGraphicsDrawn,
			        pGraphicsMask,
			        pBmpDrawn,
			        pBmpMask,
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        new System.Drawing.Point(ptDraw.X+m_ptShadowOffset.X, ptDraw.Y+m_ptShadowOffset.Y),
			        strFormat);

		        if(!b) 
		        {
			        pGraphicsMask=null;
			        pGraphicsDrawn=null;
			        pBmpDrawn=null;
			        return false;
		        }

		        b = RenderTransShadowB( graphics, pGraphicsMask, pBmpMask, pGraphicsDrawn, pBmpDrawn);

		        pGraphicsMask=null;
		        pGraphicsDrawn=null;
		        pBmpDrawn=null;

		        if(!b) return false;
	        }

	        if(m_pTextStrategy!=null&&m_pTextStrategyMask!=null)
	        {
		        System.Drawing.Graphics pGraphicsPng = System.Drawing.Graphics.FromImage(m_pPngBitmap);

		        pGraphicsPng.CompositingMode = graphics.CompositingMode;
		        pGraphicsPng.CompositingQuality = graphics.CompositingQuality;
		        pGraphicsPng.InterpolationMode = graphics.InterpolationMode;
		        pGraphicsPng.SmoothingMode = graphics.SmoothingMode;
		        pGraphicsPng.TextRenderingHint = graphics.TextRenderingHint;
		        pGraphicsPng.PageUnit = graphics.PageUnit;
		        pGraphicsPng.PageScale = graphics.PageScale;


		        bool b = m_pTextStrategy.DrawString(
			        pGraphicsPng, 
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat);

		        if(!b)
			        return false;
	        }

	        //pGraphics->DrawImage(m_pPngBitmap,0,0,m_pPngBitmap->GetWidth(),m_pPngBitmap->GetHeight());

	        return true;
        }

        public bool DrawString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int nfontSize,
            string strText,
            System.Drawing.Rectangle rtDraw,
            System.Drawing.StringFormat strFormat)
        {
	        if(graphics==null) return false;

	        System.Drawing.Graphics pGraphicsDrawn=null;
	        System.Drawing.Bitmap pBmpDrawn=null;

	        if(m_bEnableShadow&&m_pBkgdBitmap!=null&&m_pFontBodyShadow!=null&&m_pShadowStrategy!=null&&m_pShadowStrategyMask!=null)
	        {
		        System.Drawing.Graphics pGraphicsMask=null;
		        System.Drawing.Bitmap pBmpMask=null;

		        bool b = RenderTransShadowA( graphics, ref pGraphicsMask, ref pBmpMask, ref pGraphicsDrawn, ref pBmpDrawn);

		        if(!b) return false;

		        b = RenderFontShadow(
			        pGraphicsDrawn,
			        pGraphicsMask,
			        pBmpDrawn,
			        pBmpMask,
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        new Rectangle(rtDraw.X+m_ptShadowOffset.X, rtDraw.Y+m_ptShadowOffset.Y,rtDraw.Width,rtDraw.Height),
			        strFormat);

		        if(!b) 
		        {
			        pGraphicsMask=null;
			        pGraphicsDrawn=null;
			        pBmpDrawn=null;
			        return false;
		        }

		        b = RenderTransShadowB( graphics, pGraphicsMask, pBmpMask, pGraphicsDrawn, pBmpDrawn);

		        pGraphicsMask=null;
		        pGraphicsDrawn=null;
		        pBmpDrawn=null;

		        if(!b) return false;
	        }

	        if(m_pTextStrategy!=null&&m_pTextStrategyMask!=null)
	        {
		        System.Drawing.Graphics pGraphicsPng = System.Drawing.Graphics.FromImage(m_pPngBitmap);

		        pGraphicsPng.CompositingMode = graphics.CompositingMode;
		        pGraphicsPng.CompositingQuality = graphics.CompositingQuality;
		        pGraphicsPng.InterpolationMode = graphics.InterpolationMode;
		        pGraphicsPng.SmoothingMode = graphics.SmoothingMode;
		        pGraphicsPng.TextRenderingHint = graphics.TextRenderingHint;
		        pGraphicsPng.PageUnit = graphics.PageUnit;
		        pGraphicsPng.PageScale = graphics.PageScale;


		        bool b = m_pTextStrategy.DrawString(
			        pGraphicsPng, 
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        rtDraw, 
			        strFormat);

		        if(!b)
			        return false;
	        }

	        //pGraphics->DrawImage(m_pPngBitmap,0,0,m_pPngBitmap->GetWidth(),m_pPngBitmap->GetHeight());

	        return true;
        }


        public bool MeasureString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int nfontSize,
            string strText,
            System.Drawing.Point ptDraw,
            System.Drawing.StringFormat strFormat,
            ref float fDestWidth,
            ref float fDestHeight)
        {
	        float fDestWidth1 = 0.0f;
	        float fDestHeight1 = 0.0f;
	        bool b = m_pTextStrategy.MeasureString(
		        graphics, 
		        fontFamily,
		        fontStyle,
		        nfontSize,
		        strText, 
		        ptDraw, 
		        strFormat,
		        ref fDestWidth1,
		        ref fDestHeight1 );

	        if(!b)
		        return false;

	        float fDestWidth2 = 0.0f;
	        float fDestHeight2 = 0.0f;
	        if(m_bEnableShadow)
	        {
		        b = m_pShadowStrategy.MeasureString(
			        graphics, 
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat,
			        ref fDestWidth2,
			        ref fDestHeight2 );

		        if(b)
		        {
			        float fDestWidth3 = 0.0f;
			        float fDestHeight3 = 0.0f;
			        b = GDIPath.ConvertToPixels(graphics,m_ptShadowOffset.X,m_ptShadowOffset.Y,
				        ref fDestWidth3, ref fDestHeight3);
			        if(b)
			        {
				        fDestWidth2 += fDestWidth3;
				        fDestHeight2 += fDestHeight3;
			        }
		        }
		        else
			        return false;
	        }

	        if(fDestWidth1>fDestWidth2 || fDestHeight1>fDestHeight2)
	        {
		        fDestWidth = fDestWidth1;
		        fDestHeight = fDestHeight1;
	        }
	        else
	        {
		        fDestWidth = fDestWidth2;
		        fDestHeight = fDestHeight2;
	        }

	        return true;
        }

        public bool MeasureString(
            System.Drawing.Graphics graphics,
            System.Drawing.FontFamily fontFamily,
            System.Drawing.FontStyle fontStyle,
            int nfontSize,
            string strText,
            System.Drawing.Rectangle rtDraw,
            System.Drawing.StringFormat strFormat,
            ref float fDestWidth,
            ref float fDestHeight)
        {
	        float fDestWidth1 = 0.0f;
	        float fDestHeight1 = 0.0f;
	        bool b = m_pTextStrategy.MeasureString(
		        graphics, 
		        fontFamily,
		        fontStyle,
		        nfontSize,
		        strText, 
		        rtDraw, 
		        strFormat,
		        ref fDestWidth1,
		        ref fDestHeight1 );

	        if(!b)
		        return false;

	        float fDestWidth2 = 0.0f;
	        float fDestHeight2 = 0.0f;
	        if(m_bEnableShadow)
	        {
		        b = m_pShadowStrategy.MeasureString(
			        graphics, 
			        fontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        rtDraw, 
			        strFormat,
			        ref fDestWidth2,
			        ref fDestHeight2 );

		        if(b)
		        {
			        float fDestWidth3 = 0.0f;
			        float fDestHeight3 = 0.0f;
			        b = GDIPath.ConvertToPixels(graphics,m_ptShadowOffset.X,m_ptShadowOffset.Y,
				        ref fDestWidth3, ref fDestHeight3);
			        if(b)
			        {
				        fDestWidth2 += fDestWidth3;
				        fDestHeight2 += fDestHeight3;
			        }
		        }
		        else
			        return false;
	        }

	        if(fDestWidth1>fDestWidth2 || fDestHeight1>fDestHeight2)
	        {
		        fDestWidth = fDestWidth1;
		        fDestHeight = fDestHeight1;
	        }
	        else
	        {
		        fDestWidth = fDestWidth2;
		        fDestHeight = fDestHeight2;
	        }

	        return true;
        }

        bool RenderTransShadowA(
	        System.Drawing.Graphics pGraphics,
	        ref System.Drawing.Graphics ppGraphicsMask,
	        ref System.Drawing.Bitmap ppBmpMask,
	        ref System.Drawing.Graphics ppGraphicsDrawn,
	        ref System.Drawing.Bitmap ppBmpDrawn)
        {
	        if(pGraphics==null) return false;

            Rectangle rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
	        ppBmpMask = 
		        m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

	        ppGraphicsMask = System.Drawing.Graphics.FromImage(ppBmpMask);
	        System.Drawing.SolidBrush brushBlack = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0,0,0));
	        ppGraphicsMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height );

	        ppGraphicsMask.CompositingMode = pGraphics.CompositingMode;
	        ppGraphicsMask.CompositingQuality = pGraphics.CompositingQuality;
	        ppGraphicsMask.InterpolationMode = pGraphics.InterpolationMode;
	        ppGraphicsMask.SmoothingMode = pGraphics.SmoothingMode;
	        ppGraphicsMask.TextRenderingHint = pGraphics.TextRenderingHint;
	        ppGraphicsMask.PageUnit = pGraphics.PageUnit;
	        ppGraphicsMask.PageScale = pGraphics.PageScale;

	        ppBmpDrawn = 
		        m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

	        ppGraphicsDrawn = System.Drawing.Graphics.FromImage(ppBmpDrawn);
	        System.Drawing.SolidBrush brushWhite = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255,255,255));
	        ppGraphicsDrawn.FillRectangle(brushWhite, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height );

	        ppGraphicsDrawn.CompositingMode=pGraphics.CompositingMode;
	        ppGraphicsDrawn.CompositingQuality=pGraphics.CompositingQuality;
	        ppGraphicsDrawn.InterpolationMode=pGraphics.InterpolationMode;
	        ppGraphicsDrawn.SmoothingMode=pGraphics.SmoothingMode;
	        ppGraphicsDrawn.TextRenderingHint=pGraphics.TextRenderingHint;
	        ppGraphicsDrawn.PageUnit=pGraphics.PageUnit;
	        ppGraphicsDrawn.PageScale=pGraphics.PageScale;

	        return true;
        }

        bool RenderTransShadowB(
	        System.Drawing.Graphics pGraphics,
	        System.Drawing.Graphics pGraphicsMask,
	        System.Drawing.Bitmap pBmpMask,
	        System.Drawing.Graphics pGraphicsDrawn,
	        System.Drawing.Bitmap pBmpDrawn)
        {
	        if(pGraphics==null||pGraphicsMask==null||pBmpMask==null||pGraphicsDrawn==null||pBmpDrawn==null)
		        return false;

            unsafe
            {
                UInt32* pixelsSrc = null;
                UInt32* pixelsDest = null;
                UInt32* pixelsMask = null;
                UInt32* pixelsDrawn = null;

                BitmapData bitmapDataDest = new BitmapData();
                BitmapData bitmapDataMask = new BitmapData();
                BitmapData bitmapDataDrawn = new BitmapData();
                Rectangle rect = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

                m_pPngBitmap.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataDest);

                pBmpMask.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataMask);

                pBmpDrawn.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataDrawn);

                // Write to the temporary buffer provided by LockBits.
                pixelsDest = (UInt32*)bitmapDataDest.Scan0;
                pixelsMask = (UInt32*)bitmapDataMask.Scan0;
                pixelsDrawn = (UInt32*)bitmapDataDrawn.Scan0;

                if (pixelsDest == null || pixelsMask == null || pixelsDrawn == null)
                {
                    return false;
                }

                UInt32 col = 0;
                int stride = bitmapDataDest.Stride >> 2;
                for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
                {
                    for (col = 0; col < bitmapDataDest.Width; ++col)
                    {
                        UInt32 index = (UInt32)(row * stride + col);
                        Byte nAlpha = (Byte)(pixelsMask[index] & 0xff);
                        if (nAlpha > 0)
                        {
                            UInt32 nDrawn = (UInt32)
                                (nAlpha << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
                            nDrawn &= 0x00ffffff;
                            pixelsDest[index] = (UInt32)((UInt32)nDrawn | (UInt32)(nAlpha << 24));
                        }
                    }
                }

                pBmpDrawn.UnlockBits(bitmapDataDrawn);
                pBmpMask.UnlockBits(bitmapDataMask);
                m_pPngBitmap.UnlockBits(bitmapDataDest);

                pBmpMask = null;
            }
	        return true;
        }

        bool RenderFontShadow(	
	        System.Drawing.Graphics pGraphicsDrawn, 
	        System.Drawing.Graphics pGraphicsMask,
	        System.Drawing.Bitmap pBitmapDrawn,
	        System.Drawing.Bitmap pBitmapMask,
	        System.Drawing.FontFamily pFontFamily,
	        System.Drawing.FontStyle fontStyle,
	        int nfontSize,
	        string strText, 
	        System.Drawing.Point ptDraw, 
	        System.Drawing.StringFormat strFormat)
        {
	        if(pGraphicsDrawn == null || pGraphicsMask == null || pBitmapDrawn == null || pBitmapMask == null) return false;

            Rectangle rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
	        System.Drawing.Bitmap pBitmapShadowMask =
                m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

	        System.Drawing.Graphics pGraphicsShadowMask = System.Drawing.Graphics.FromImage(pBitmapShadowMask);
	        System.Drawing.SolidBrush brushBlack = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0,0,0));
	        pGraphicsShadowMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height );

	        pGraphicsShadowMask.CompositingMode = pGraphicsDrawn.CompositingMode;
	        pGraphicsShadowMask.CompositingQuality = pGraphicsDrawn.CompositingQuality;
	        pGraphicsShadowMask.InterpolationMode = pGraphicsDrawn.InterpolationMode;
	        pGraphicsShadowMask.SmoothingMode = pGraphicsDrawn.SmoothingMode;
	        pGraphicsShadowMask.TextRenderingHint = pGraphicsDrawn.TextRenderingHint;
	        pGraphicsShadowMask.PageUnit = pGraphicsDrawn.PageUnit;
	        pGraphicsShadowMask.PageScale = pGraphicsDrawn.PageScale;

	        bool b = false;

	        b = m_pFontBodyShadowMask.DrawString(
			        pGraphicsMask, 
			        pFontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat);

	        if(!b) return false;

	        b = m_pShadowStrategyMask.DrawString(		
			        pGraphicsShadowMask, 
			        pFontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat);

	        if(!b) return false;

	        b = m_pFontBodyShadow.DrawString(
			        pGraphicsDrawn, 
			        pFontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat);

	        if(!b) return false;

	        b = m_pShadowStrategy.DrawString(		
			        pGraphicsDrawn, 
			        pFontFamily,
			        fontStyle,
			        nfontSize,
			        strText, 
			        ptDraw, 
			        strFormat);

	        if(!b) return false;

            unsafe
            {
	        UInt32* pixelsDest = null;
	        UInt32* pixelsMask = null;
	        UInt32* pixelsShadowMask = null;

	        BitmapData bitmapDataDest = new BitmapData();
	        BitmapData bitmapDataMask = new BitmapData();
	        BitmapData bitmapDataShadowMask = new BitmapData();
	        Rectangle rect = new Rectangle(0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height );

	        pBitmapDrawn.LockBits(
		        rect,
		        ImageLockMode.WriteOnly,
		        PixelFormat.Format32bppArgb,
		        bitmapDataDest );

	        pBitmapMask.LockBits(
		        rect,
		        ImageLockMode.WriteOnly,
		        PixelFormat.Format32bppArgb,
		        bitmapDataMask );

	        pBitmapShadowMask.LockBits(
		        rect,
		        ImageLockMode.WriteOnly,
		        PixelFormat.Format32bppArgb,
		        bitmapDataShadowMask );

	        pixelsDest = (UInt32*)(bitmapDataDest.Scan0);
	        pixelsMask = (UInt32*)(bitmapDataMask.Scan0);
	        pixelsShadowMask = (UInt32*)(bitmapDataShadowMask.Scan0);

	        if( pixelsDest == null || pixelsMask == null || pixelsShadowMask == null )
		        return false;

	        UInt32 col = 0;
	        int stride = bitmapDataDest.Stride >> 2;
	        for(UInt32 row = 0; row < bitmapDataDest.Height; ++row)
	        {
		        for(col = 0; col < bitmapDataDest.Width; ++col)
		        {
			        UInt32 index = (UInt32)(row * stride + col);
			        Byte nAlpha = (Byte)(pixelsMask[index] & 0xff);
			        Byte nAlphaShadow = (Byte)(pixelsShadowMask[index] & 0xff);
			        if(nAlpha>0&&nAlpha>nAlphaShadow)
			        {
				        pixelsDest[index] = (UInt32) (0xff << 24 | m_clrShadow.R<<16 | m_clrShadow.G<<8 | m_clrShadow.B);
			        }
			        else if(nAlphaShadow>0)
			        {
				        pixelsDest[index] = (UInt32) (0xff << 24 | m_clrShadow.R<<16 | m_clrShadow.G<<8 | m_clrShadow.B);
				        pixelsMask[index] = pixelsShadowMask[index];
			        }
		        }
	        }

	        pBitmapShadowMask.UnlockBits(bitmapDataShadowMask);
	        pBitmapMask.UnlockBits(bitmapDataMask);
	        pBitmapDrawn.UnlockBits(bitmapDataDest);

	        pGraphicsShadowMask = null;
	        pBitmapShadowMask = null;
            }

	        return true;
        }

        bool RenderFontShadow(
            System.Drawing.Graphics pGraphicsDrawn,
            System.Drawing.Graphics pGraphicsMask,
            System.Drawing.Bitmap pBitmapDrawn,
            System.Drawing.Bitmap pBitmapMask,
            System.Drawing.FontFamily pFontFamily,
            System.Drawing.FontStyle fontStyle,
            int nfontSize,
            string strText,
            System.Drawing.Rectangle rtDraw,
            System.Drawing.StringFormat strFormat)
        {
            if (pGraphicsDrawn == null || pGraphicsMask == null || pBitmapDrawn == null || pBitmapMask == null) return false;

            Rectangle rectbmp = new Rectangle(0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);
            System.Drawing.Bitmap pBitmapShadowMask =
                m_pPngBitmap.Clone(rectbmp, PixelFormat.Format32bppArgb);

            System.Drawing.Graphics pGraphicsShadowMask = System.Drawing.Graphics.FromImage(pBitmapShadowMask);
            System.Drawing.SolidBrush brushBlack = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0));
            pGraphicsShadowMask.FillRectangle(brushBlack, 0, 0, m_pPngBitmap.Width, m_pPngBitmap.Height);

            pGraphicsShadowMask.CompositingMode = pGraphicsDrawn.CompositingMode;
            pGraphicsShadowMask.CompositingQuality = pGraphicsDrawn.CompositingQuality;
            pGraphicsShadowMask.InterpolationMode = pGraphicsDrawn.InterpolationMode;
            pGraphicsShadowMask.SmoothingMode = pGraphicsDrawn.SmoothingMode;
            pGraphicsShadowMask.TextRenderingHint = pGraphicsDrawn.TextRenderingHint;
            pGraphicsShadowMask.PageUnit = pGraphicsDrawn.PageUnit;
            pGraphicsShadowMask.PageScale = pGraphicsDrawn.PageScale;

            bool b = false;

            b = m_pFontBodyShadowMask.DrawString(
                    pGraphicsMask,
                    pFontFamily,
                    fontStyle,
                    nfontSize,
                    strText,
                    rtDraw,
                    strFormat);

            if (!b) return false;

            b = m_pShadowStrategyMask.DrawString(
                    pGraphicsShadowMask,
                    pFontFamily,
                    fontStyle,
                    nfontSize,
                    strText,
                    rtDraw,
                    strFormat);

            if (!b) return false;

            b = m_pFontBodyShadow.DrawString(
                    pGraphicsDrawn,
                    pFontFamily,
                    fontStyle,
                    nfontSize,
                    strText,
                    rtDraw,
                    strFormat);

            if (!b) return false;

            b = m_pShadowStrategy.DrawString(
                    pGraphicsDrawn,
                    pFontFamily,
                    fontStyle,
                    nfontSize,
                    strText,
                    rtDraw,
                    strFormat);

            if (!b) return false;

            unsafe
            {
                UInt32* pixelsDest = null;
                UInt32* pixelsMask = null;
                UInt32* pixelsShadowMask = null;

                BitmapData bitmapDataDest = new BitmapData();
                BitmapData bitmapDataMask = new BitmapData();
                BitmapData bitmapDataShadowMask = new BitmapData();
                Rectangle rect = new Rectangle(0, 0, m_pBkgdBitmap.Width, m_pBkgdBitmap.Height);

                pBitmapDrawn.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataDest);

                pBitmapMask.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataMask);

                pBitmapShadowMask.LockBits(
                    rect,
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb,
                    bitmapDataShadowMask);

                pixelsDest = (UInt32*)(bitmapDataDest.Scan0);
                pixelsMask = (UInt32*)(bitmapDataMask.Scan0);
                pixelsShadowMask = (UInt32*)(bitmapDataShadowMask.Scan0);

                if (pixelsDest == null || pixelsMask == null || pixelsShadowMask == null)
                    return false;

                UInt32 col = 0;
                int stride = bitmapDataDest.Stride >> 2;
                for (UInt32 row = 0; row < bitmapDataDest.Height; ++row)
                {
                    for (col = 0; col < bitmapDataDest.Width; ++col)
                    {
                        UInt32 index = (UInt32)(row * stride + col);
                        Byte nAlpha = (Byte)(pixelsMask[index] & 0xff);
                        Byte nAlphaShadow = (Byte)(pixelsShadowMask[index] & 0xff);
                        if (nAlpha > 0 && nAlpha > nAlphaShadow)
                        {
                            pixelsDest[index] = (UInt32) (0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
                        }
                        else if (nAlphaShadow > 0)
                        {
                            pixelsDest[index] = (UInt32) (0xff << 24 | m_clrShadow.R << 16 | m_clrShadow.G << 8 | m_clrShadow.B);
                            pixelsMask[index] = pixelsShadowMask[index];
                        }
                    }
                }

                pBitmapShadowMask.UnlockBits(bitmapDataShadowMask);
                pBitmapMask.UnlockBits(bitmapDataMask);
                pBitmapDrawn.UnlockBits(bitmapDataDest);

                pGraphicsShadowMask = null;
                pBitmapShadowMask = null;
            }

            return true;
        }

        UInt32 Alphablend(UInt32 dest, UInt32 source, Byte nAlpha)
        {
            if (0 == nAlpha)
                return dest;

            if (255 == nAlpha)
                return source;

            Byte nInvAlpha = (Byte)(~nAlpha);

            Byte nSrcRed = (Byte)((source & 0xff0000) >> 16);
            Byte nSrcGreen = (Byte)((source & 0xff00) >> 8);
            Byte nSrcBlue = (Byte)((source & 0xff));

            Byte nDestRed = (Byte)((dest & 0xff0000) >> 16);
            Byte nDestGreen = (Byte)((dest & 0xff00) >> 8);
            Byte nDestBlue = (Byte)(dest & 0xff);

            Byte nRed = (Byte)((nSrcRed * nAlpha + nDestRed * nInvAlpha) >> 8);
            Byte nGreen = (Byte)((nSrcGreen * nAlpha + nDestGreen * nInvAlpha) >> 8);
            Byte nBlue = (Byte)((nSrcBlue * nAlpha + nDestBlue * nInvAlpha) >> 8);

            return (UInt32)(0xff000000 | (UInt32)(nRed << 16) | (UInt32)(nGreen << 8) | nBlue);
        }

        protected ITextStrategy m_pTextStrategy;
        protected ITextStrategy m_pTextStrategyMask;
        protected ITextStrategy m_pShadowStrategy;
        protected ITextStrategy m_pShadowStrategyMask;
        protected ITextStrategy m_pFontBodyShadow;
        protected ITextStrategy m_pFontBodyShadowMask;
        protected System.Drawing.Point m_ptShadowOffset;
        protected System.Drawing.Color m_clrShadow;
        protected System.Drawing.Bitmap m_pBkgdBitmap;
        protected System.Drawing.Bitmap m_pPngBitmap;
        protected bool m_bEnableShadow;
        protected bool m_bDiffuseShadow;
        protected int m_nShadowThickness;
        protected bool m_bExtrudeShadow;


    }
}
