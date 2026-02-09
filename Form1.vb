Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dlg As New OpenFileDialog()

        ToolStripStatusLabel1.Text = "Idle..."

        dlg.Title = "Select a PDF file"
        dlg.Filter = "PDF Files (*.pdf)|*.pdf"
        dlg.Multiselect = False

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim selectedPdf As String = dlg.FileName

            txtSourcePDF.Text = selectedPdf
            txtDestinationPDF.Text = Mid(selectedPdf, 1, Len(selectedPdf) - 4) & "_.pdf"
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ToolStripStatusLabel1.Text = "Working..."
        CropBottomToText(txtSourcePDF.Text, txtDestinationPDF.Text, 28.35F)
        ToolStripStatusLabel1.Text = "Done"
    End Sub

    Private Sub txtSourcePDF_DragDrop(sender As Object, e As DragEventArgs) Handles txtSourcePDF.DragDrop

        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        ' Example: put first file name into the textbox
        If files.Length > 0 Then
            txtSourcePDF.Text = files(0)   ' full path: C:\folder\file.txt
        End If

    End Sub

    Private Sub txtSourcePDF_DragEnter(sender As Object, e As DragEventArgs) Handles txtSourcePDF.DragEnter


        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

            ' Allow only if exactly 1 file AND it ends with .pdf
            If files.Length = 1 AndAlso
               IO.Path.GetExtension(files(0)).ToLower() = ".pdf" Then

                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If


    End Sub

    Private Sub ListViewFiles_DragEnter(sender As Object, e As DragEventArgs) Handles ListViewFiles.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub ListViewFiles_DragDrop(sender As Object, e As DragEventArgs) Handles ListViewFiles.DragDrop
        Dim dropped As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

        Dim includeSubfolders As Boolean = True
        Dim resolvedPaths As New List(Of String)

        For Each p In dropped
            If IO.Path.GetExtension(p).Equals(".lnk", StringComparison.OrdinalIgnoreCase) Then
                Dim target As String = ResolveShortcut(p)
                If Not String.IsNullOrEmpty(target) Then
                    resolvedPaths.Add(target)
                End If
            Else
                resolvedPaths.Add(p)
            End If
        Next

        ' Get PDFs from resolved paths (files or folders)
        Dim pdfs As IEnumerable(Of String) = GetPdfFilesFromPaths(resolvedPaths, includeSubfolders)

        AddPdfsToListView(pdfs)
    End Sub

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click

        Dim fileArray As String() = ListViewFiles.Items.Cast(Of ListViewItem)().Select(Function(item) item.SubItems(1).Text).ToArray()
        MergePdfs(txtOutputFolder.Text & "\MergedResult.pdf", fileArray)
    End Sub

    Private Sub btnCropMerge_Click(sender As Object, e As EventArgs) Handles btnCropMerge.Click
        Dim fileArray As String() = ListViewFiles.Items.Cast(Of ListViewItem)().Select(Function(item) item.SubItems(1).Text).ToArray()
        CropAllAndMerge(sourceFiles:=fileArray, outputFolder:=txtOutputFolder.Text, mergedFileName:="MergedResult.pdf", cropValue:=28.35F)
    End Sub


    Private Function ResolveShortcut(path As String) As String
        Try
            Dim shell = New IWshRuntimeLibrary.WshShell()
            Dim lnk = CType(shell.CreateShortcut(path), IWshRuntimeLibrary.IWshShortcut)
            Return lnk.TargetPath
        Catch
            Return Nothing
        End Try
    End Function

    Private Function GetPdfFilesFromPaths(paths As IEnumerable(Of String), includeSubfolders As Boolean) As IEnumerable(Of String)
        Dim result As New List(Of String)

        For Each p In paths
            If IO.File.Exists(p) Then
                ' Single file
                If IsPdf(p) Then result.Add(p)
            ElseIf IO.Directory.Exists(p) Then
                ' Folder: enumerate PDFs (optionally recursive)
                Dim searchOption = If(includeSubfolders, IO.SearchOption.AllDirectories, IO.SearchOption.TopDirectoryOnly)
                Try
                    Dim files = IO.Directory.EnumerateFiles(p, "*.pdf", searchOption)
                    result.AddRange(files)
                Catch ex As UnauthorizedAccessException
                    ' Skip protected folders
                Catch ex As Exception
                    ' Log or show a message if needed
                End Try
            End If
        Next

        Return result.Distinct(StringComparer.OrdinalIgnoreCase) ' de-dupe by path
    End Function

    Private Function IsPdf(path As String) As Boolean
        Return String.Equals(IO.Path.GetExtension(path), ".pdf", StringComparison.OrdinalIgnoreCase)
    End Function


    Private Sub AddPdfsToListView(pdfPaths As IEnumerable(Of String))
        ' Build a hash set of existing paths to prevent duplicates
        Dim existing As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each it As ListViewItem In ListViewFiles.Items
            Dim existingPath As String =
                If(it.SubItems.Count > 1, it.SubItems(1).Text, TryCast(it.Tag, String))
            If Not String.IsNullOrEmpty(existingPath) Then existing.Add(existingPath)
        Next

        ' Batch update to avoid flicker
        ListViewFiles.BeginUpdate()
        Try
            For Each fullPath In pdfPaths
                If Not existing.Contains(fullPath) Then
                    Dim fileName As String = IO.Path.GetFileName(fullPath)
                    Dim item As New ListViewItem(fileName)
                    item.SubItems.Add(fullPath)   ' keep path in column 1
                    ' Or: item.Tag = fullPath     ' if you prefer storing in Tag
                    ListViewFiles.Items.Add(item)
                    existing.Add(fullPath)
                End If
            Next
        Finally
            ListViewFiles.EndUpdate()
        End Try
    End Sub

    Private Sub mnuRemoveFromList_Click(sender As Object, e As EventArgs) Handles mnuRemoveFromList.Click
        If ListViewFiles.SelectedItems.Count = 0 Then Return

        ' Copy to array to avoid modifying the collection while iterating
        Dim toRemove = ListViewFiles.SelectedItems.Cast(Of ListViewItem)().ToArray()

        ListViewFiles.BeginUpdate()
        Try
            For Each it In toRemove
                it.Remove()
            Next
        Finally
            ListViewFiles.EndUpdate()
        End Try
    End Sub

    Private Sub btnSelectFolder_Click(sender As Object, e As EventArgs) Handles btnSelectFolder.Click

        Dim dlg As New FolderBrowserDialog()

        dlg.Description = "Select a folder"
        dlg.ShowNewFolderButton = True   ' optional

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim selectedFolder As String = dlg.SelectedPath
            txtOutputFolder.Text = selectedFolder
        End If

    End Sub

    Private Sub txtOutputFolder_DragDrop(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragDrop

        Dim paths = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If paths.Length = 1 Then
            Dim p = ResolveFolderTarget(paths(0))
            If Not String.IsNullOrEmpty(p) Then
                txtOutputFolder.Text = p
            End If
        End If

    End Sub

    Private Sub txtOutputFolder_DragEnter(sender As Object, e As DragEventArgs) Handles txtOutputFolder.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim paths = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If paths.Length = 1 AndAlso IsFolderOrShortcutToFolder(paths(0)) Then
                e.Effect = DragDropEffects.Copy   ' allow drop
            Else
                e.Effect = DragDropEffects.None   ' reject
            End If
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Function IsFolderOrShortcutToFolder(path As String) As Boolean
        If IO.Directory.Exists(path) Then Return True

        If IO.Path.GetExtension(path).Equals(".lnk", StringComparison.OrdinalIgnoreCase) Then
            Dim target = ResolveShortcut(path)
            If Not String.IsNullOrEmpty(target) AndAlso IO.Directory.Exists(target) Then Return True
        End If

        Return False
    End Function

    Private Function ResolveFolderTarget(path As String) As String
        If IO.Directory.Exists(path) Then Return path

        If IO.Path.GetExtension(path).Equals(".lnk", StringComparison.OrdinalIgnoreCase) Then
            Dim target = ResolveShortcut(path)
            If IO.Directory.Exists(target) Then Return target
        End If

        Return Nothing
    End Function

    Private Sub CropAllAndMerge(sourceFiles As String(),
                            outputFolder As String,
                            mergedFileName As String,
                            cropValue As Single)

        ' Make use output exists
        If Not IO.Directory.Exists(outputFolder) Then
            IO.Directory.CreateDirectory(outputFolder)
        End If

        ' Create temp folder cropped versions
        Dim tempFolder As String = IO.Path.Combine(outputFolder, "_tempCropped")
        If Not IO.Directory.Exists(tempFolder) Then
            IO.Directory.CreateDirectory(tempFolder)
        End If

        Dim croppedFiles As New List(Of String)

        Try
            ' Crop
            For Each src As String In sourceFiles
                Dim croppedPath As String = IO.Path.Combine(
                    tempFolder,
                    IO.Path.GetFileNameWithoutExtension(src) & "_cropped.pdf")
                ToolStripStatusLabel1.Text = "Cropping: " & System.IO.Path.GetFileName(src)
                CropBottomToText(src, croppedPath, cropValue)
                croppedFiles.Add(croppedPath)
                ToolStripStatusLabel1.Text = "Cropping: done"
            Next
            ' Merge
            Dim finalOutput As String = IO.Path.Combine(outputFolder, mergedFileName)
            ToolStripStatusLabel1.Text = "Merging all files ..."
            MergePdfs(finalOutput, croppedFiles.ToArray())
            ToolStripStatusLabel1.Text = "Done"

        Finally
            ' cleanup
            Try
                Directory.Delete(tempFolder, recursive:=True)
            Catch
                ' do nothing
            End Try
        End Try

    End Sub


End Class
