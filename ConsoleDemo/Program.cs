using System;
using System.Diagnostics;
using System.Drawing;

namespace Tesseract.ConsoleDemo
{
    internal class Program
    {
        TesseractEngine engine;


        public static void Main(string[] args)
        {
            string testImagePath;

            if (args.Length > 0)
            { testImagePath = args[0]; }
            else
            { testImagePath = "../../cms_1500_02-12.png"; }

            try
            {
                using (var engine = new TesseractEngine(@"C:\Users\Chris\Documents\GitHub\ComboTessFormSharp\ConsoleDemo\", "eng", EngineMode.TesseractAndCube))
                {
                    var imageFile = System.Drawing.Image.FromFile(testImagePath);
                    if (imageFile.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page) > 1)
                    {
                        using (var imgPages = PixArray.LoadMultiPageTiffFromFile(testImagePath))
                        {
                            int pageNum = 1;
                            foreach (Tesseract.Pix img in imgPages)
                            {
                                processImage(engine, img, testImagePath, pageNum);
                                pageNum++;
                            }
                        }
                    }
                    else
                    {
                        using (var img = Pix.LoadFromFile(testImagePath))
                        {
                            processImage(engine, img, testImagePath, 1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        public static void processImage(Tesseract.TesseractEngine engine , Tesseract.Pix img ,  string testImagePath, int pageNum)
        {
            System.IO.FileInfo mfile = new System.IO.FileInfo(testImagePath);
            string hocrPath = mfile.DirectoryName + "\\" + System.IO.Path.GetFileNameWithoutExtension(testImagePath) + "_p" + pageNum.ToString() + ".xhtml";

            using (var page = engine.Process(img, PageSegMode.AutoOsd))
            {
                page.AnalyseLayout();
                string hocr = page.GetHOCRText(0, true);
                System.IO.File.AppendAllText(hocrPath, hocr);
                var text = page.GetText();
                Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());
                Console.WriteLine("Text (GetText): \r\n{0}", text);
                Console.WriteLine("Text (iterator):");
                using (var iter = page.GetIterator())
                {
                    iter.Begin();
                    do
                    {
                        do
                        {
                            do
                            {
                                do
                                {

                                    if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                    {
                                        Console.WriteLine("<BLOCK>");
                                        Rect currentBlock;
                                        iter.TryGetBoundingBox(PageIteratorLevel.Block, out currentBlock);
                                        Console.WriteLine(iter.BlockType.ToString());
                                        Console.WriteLine("(" + currentBlock.X1.ToString() + "," + currentBlock.Y1.ToString() + ")  (" + currentBlock.X2.ToString() + "," + currentBlock.Y2.ToString() + ")");
                                        Console.WriteLine("");
                                    }

                                    Console.Write(iter.GetText(PageIteratorLevel.Word));
                                    Console.Write(" ");

                                    if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                    {
                                        Console.WriteLine(iter.BlockType.ToString());
                                    }
                                } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                {
                                    Console.WriteLine();
                                }
                            } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                        } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                    } while (iter.Next(PageIteratorLevel.Block));
                }
            }
        }
    }
}