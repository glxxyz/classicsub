using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestDesignerCSLibrary
{
    public class GDIPath
    {
        static public bool MeasureGraphicsPath(
            System.Drawing.Graphics graphics,
            System.Drawing.Drawing2D.GraphicsPath graphicsPath,
            ref float fPixelsWidth,
            ref float fPixelsHeight)
        {
	        if(graphicsPath.PathData.Points.Length<=0)
		        return false;

	        float fHighestX = graphicsPath.PathData.Points[0].X;
	        float fHighestY = graphicsPath.PathData.Points[0].Y;
	        float fLowestX = graphicsPath.PathData.Points[0].X;
	        float fLowestY = graphicsPath.PathData.Points[0].Y;
            int length = graphicsPath.PathData.Points.Length;
            PointF[] points = graphicsPath.PathData.Points;
	        for(int i=1; i<length; ++i)
	        {
                if (points[i].X < fLowestX)
                    fLowestX = points[i].X;
                if (points[i].Y < fLowestY)
                    fLowestY = points[i].Y;
                if (points[i].X > fHighestX)
                    fHighestX = points[i].X;
                if (points[i].Y > fHighestY)
                    fHighestY = points[i].Y;
	        }

	        // Hack!
	        if(fLowestX<0.0f)
		        fLowestX = -fLowestX;
	        else
		        fLowestX = 0.0f;

	        if(fLowestY<0.0f)
		        fLowestY = -fLowestY;
	        else
		        fLowestY = 0.0f;

	        bool b = ConvertToPixels(
		        graphics,
		        fLowestX + fHighestX - fPixelsWidth,
		        fLowestY + fHighestY - fPixelsHeight,
		        ref fPixelsWidth,
		        ref fPixelsHeight );

	        return b;
        }

        static public bool MeasureGraphicsPathRealHeight(
            System.Drawing.Graphics graphics,
            System.Drawing.Drawing2D.GraphicsPath graphicsPath,
            ref float fPixelsWidth,
            ref float fPixelsHeight)
        {
            if (graphicsPath.PathData.Points.Length <= 0)
                return false;

            float fHighestX = graphicsPath.PathData.Points[0].X;
            float fHighestY = graphicsPath.PathData.Points[0].Y;
            float fLowestX = graphicsPath.PathData.Points[0].X;
            float fLowestY = graphicsPath.PathData.Points[0].Y;
            int length = graphicsPath.PathData.Points.Length;
            PointF[] points = graphicsPath.PathData.Points;
            for (int i = 1; i < length; ++i)
            {
                if (points[i].X < fLowestX)
                    fLowestX = points[i].X;
                if (points[i].Y < fLowestY)
                    fLowestY = points[i].Y;
                if (points[i].X > fHighestX)
                    fHighestX = points[i].X;
                if (points[i].Y > fHighestY)
                    fHighestY = points[i].Y;
            }

            bool b = ConvertToPixels(
                graphics,
                fLowestX + fHighestX - fPixelsWidth,
                fLowestY + fHighestY - fPixelsHeight,
                ref fPixelsWidth,
                ref fPixelsHeight);

            return b;
        }

        static public bool ConvertToPixels(
            System.Drawing.Graphics graphics,
            float fSrcWidth,
            float fSrcHeight,
            ref float fDestWidth,
            ref float fDestHeight)
        {
            GraphicsUnit unit = graphics.PageUnit;
	        float fDpiX = graphics.DpiX;
	        float fDpiY = graphics.DpiY;

	        if(unit==GraphicsUnit.World)
		        return false; // dunno how to convert

	        if(unit==GraphicsUnit.Display||unit==GraphicsUnit.Pixel)
	        {
		        fDestWidth = fSrcWidth;
		        fDestHeight = fSrcHeight;
		        return true;
	        }

	        if(unit==GraphicsUnit.Point)
	        {
		        fDestWidth = 1.0f/72.0f * fDpiX * fSrcWidth;
		        fDestHeight = 1.0f/72.0f * fDpiY * fSrcHeight;
		        return true;
	        }

	        if(unit==GraphicsUnit.Inch)
	        {
		        fDestWidth = fDpiX * fSrcWidth;
		        fDestHeight = fDpiY * fSrcHeight;
		        return true;
	        }

	        if(unit==GraphicsUnit.Document)
	        {
			    fDestWidth = 1.0f/300.0f * fDpiX * fSrcWidth;
			    fDestHeight = 1.0f/300.0f * fDpiY * fSrcHeight;
		        return true;
	        }

	        if(unit==GraphicsUnit.Millimeter)
	        {
			    fDestWidth = 1.0f/25.4f * fDpiX * fSrcWidth;
			    fDestHeight = 1.0f/25.4f * fDpiY * fSrcHeight;
		        return true;
	        }

	        return false;
        }
    }
}
