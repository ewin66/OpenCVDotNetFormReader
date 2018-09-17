using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;

namespace OpenCV.Net.Auto
{
    public static class MatrixAnalyzer
    {
        public GridAnalyzer(string fileName)
        {
            Mat src = imread(filename);

            // Check if image is loaded fine
            if (!src.data)
                cerr << "Problem loading image!!!" << endl;

            //    // Show source image
            //    imshow("src", src);

            // resizing for practical reasons
            Mat rsz;
            Size size = new Size(800, 900);
            resize(src, rsz, size);

            imshow("rsz", rsz);

            // Transform source image to gray if it is not
            Mat gray;

            if (rsz.channels() == 3)
            {
                cvtColor(rsz, gray, CV_BGR2GRAY);
            }
            else
            {
                gray = rsz;
            }

            // Show gray image
            imshow("gray", gray);

            // Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol
            Mat bw;
            adaptiveThreshold(~gray, bw, 255, CV_ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);

            // Show binary image
            imshow("binary", bw);

            // Create the images that will use to extract the horizonta and vertical lines
            Mat horizontal = bw.clone();
            Mat vertical = bw.clone();

            int scale = 15; // play with this variable in order to increase/decrease the amount of lines to be detected

            // Specify size on horizontal axis
            int horizontalsize = horizontal.cols / scale;

            // Create structure element for extracting horizontal lines through morphology operations
            Mat horizontalStructure = getStructuringElement(MORPH_RECT, Size(horizontalsize, 1));

            // Apply morphology operations
            erode(horizontal, horizontal, horizontalStructure, Point(-1, -1));
            dilate(horizontal, horizontal, horizontalStructure, Point(-1, -1));
            //    dilate(horizontal, horizontal, horizontalStructure, Point(-1, -1)); // expand horizontal lines

            // Show extracted horizontal lines
            imshow("horizontal", horizontal);

            // Specify size on vertical axis
            int verticalsize = vertical.rows / scale;

            // Create structure element for extracting vertical lines through morphology operations
            Mat verticalStructure = getStructuringElement(MORPH_RECT, Size(1, verticalsize));

            // Apply morphology operations
            erode(vertical, vertical, verticalStructure, Point(-1, -1));
            dilate(vertical, vertical, verticalStructure, Point(-1, -1));
            //    dilate(vertical, vertical, verticalStructure, Point(-1, -1)); // expand vertical lines

            // Show extracted vertical lines
            imshow("vertical", vertical);


            // create a mask which includes the tables
            Mat mask = horizontal + vertical;
            imshow("mask", mask);

            // find the joints between the lines of the tables, we will use this information in order to descriminate tables from pictures (tables will contain more than 4 joints while a picture only 4 (i.e. at the corners))
            Mat joints;
            bitwise_and(horizontal, vertical, joints);
            imshow("joints", joints);


      			// Find external contours from the mask, which most probably will belong to tables or to images
      			List<Vec4i> hierarchy = new List<Vec4i>();
      			List<List<cv.Point>> contours = new List<List<cv.Point>>();
      			cv.findContours(mask, contours, hierarchy, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_SIMPLE, Point(0, 0));

      			List<List<Point>> contours_poly = new List<List<Point>>(contours.Count);
      			List<Rect> boundRect = new List<Rect>(contours.Count);
      			List<Mat> rois = new List<Mat>();

      			for (uint i = 0; i < contours.Count; i++)
      			{
      				// find the area of each contour
      				double area = contourArea(contours[i]);
      				// filter individual lines of blobs that might exist and they do not represent a table
      				if (area < 100) // value is randomly chosen, you will need to find that by yourself with trial and error procedure
      				{
      					continue;
      				}
      			}



        }
    }
}
