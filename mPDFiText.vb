
Imports iText.Kernel.Geom
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser
Imports iText.Kernel.Pdf.Canvas.Parser.Listener
Imports iText.Kernel.Utils

Module mPDFiText
    Public Sub CropBottomToText(inputPath As String, outputPath As String, Optional padding As Single = 3.0F)

        Using pdf As New PdfDocument(New PdfReader(inputPath), New PdfWriter(outputPath))

            Dim pages = pdf.GetNumberOfPages()
            Dim extraBottom As Single = 28.3465F  ' 1 cm in points to the bottom

            ' Ensure we have andatory meta data AGPLv3
            Dim info = pdf.GetDocumentInfo()
            info.SetTitle("Cropped PDF Document")
            info.SetAuthor("SJL")
            info.SetCreator("iText 9.5.0")
            info.SetSubject("Cropped PDF")
            info.SetKeywords("PDF, iText, Cropped")
            info.SetMoreInfo("Copyright", "© 2026 SJL. Created using iText 9.5.0")

            For p = 1 To pages
                Dim page = pdf.GetPage(p)
                Dim tmf As New TextMarginFinder()
                Dim processor As New PdfCanvasProcessor(tmf)
                processor.ProcessPageContent(page)   ' content stream parsing supported by iText Core 9.x [3](https://javadoc.io/static/com.itextpdf/kernel/7.2.2/com/itextpdf/kernel/pdf/canvas/parser/PdfCanvasProcessor.html)

                Dim textRect = tmf.GetTextRectangle() ' returns all‑text bounding box [2](https://javadoc.io/static/com.itextpdf/kernel/7.2.3/com/itextpdf/kernel/pdf/canvas/parser/listener/TextMarginFinder.html)
                If textRect Is Nothing Then Continue For

                Dim box = If(page.GetCropBox(), page.GetMediaBox())
                Dim newBottom = Math.Max(box.GetBottom(), textRect.GetBottom() - padding)

                newBottom = newBottom - extraBottom
                If newBottom >= box.GetTop() - 1 Then
                    newBottom = box.GetTop() - 1
                End If
                ' Schrink the page to fit the content box new heigt
                Dim newRect As New Rectangle(box.GetLeft(), newBottom, box.GetWidth(), box.GetTop() - newBottom)

                page.SetCropBox(newRect)
                page.SetMediaBox(newRect)
            Next

        End Using

    End Sub

    Sub MergePdfs(outputPath As String, ParamArray inputFiles As String())

        Using destPdf As New PdfDocument(New PdfWriter(outputPath))

            ' Ensure we have andatory meta data AGPLv3
            Dim info = destPdf.GetDocumentInfo()
            info.SetTitle("Merged PDF Document")
            info.SetAuthor("YSJL")
            info.SetCreator("iText 9.5.0")
            info.SetSubject("Merged PDF")
            info.SetKeywords("PDF, iText, Merge")
            info.SetMoreInfo("Copyright", "© 2026 SJL. Created using iText 9.5.0")

            Dim merger As New PdfMerger(destPdf)

            For Each file In inputFiles
                Using srcPdf As New PdfDocument(New PdfReader(file))
                    merger.Merge(srcPdf, 1, srcPdf.GetNumberOfPages())
                End Using
            Next

        End Using

    End Sub

End Module
