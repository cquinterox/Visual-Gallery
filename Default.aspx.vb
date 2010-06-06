Imports System.IO
Imports System.Drawing
Imports Microsoft.VisualBasic

' Web application developeed by Cesar Quinteros 2009
' http://www.quinterox.com

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("img") <> Nothing Then
            Call makeThumbs()
        Else
            Call bindImages()
        End If
    End Sub
    Public Sub bindImages()
        'Local address for image directory, you shouldn't have to change this unless you change the folder name
        Dim imgLocDir As String = Server.MapPath("images") & "\"
        Dim imgImgDir As String = "images/"
        Dim imgArray As String()
        Dim imgFileLoc As String = ""

        Dim imgCurrent As System.Drawing.Image

        imgArray = Directory.GetFiles(imgLocDir)
        Me.ul_images.InnerHtml = vbCrLf
        For Each imgFileLoc In imgArray
            imgCurrent = System.Drawing.Image.FromFile(imgFileLoc)
            imgFileLoc = Replace(imgFileLoc, imgLocDir, imgImgDir)
            Me.ul_images.InnerHtml &= tagImg(imgFileLoc)
        Next
        Me.ul_images.InnerHtml &= "     "
        Me.ul_images.DataBind()
    End Sub
    Public Function tagImg(ByVal image As String) As String
        Return String.Format(vbTab & "<li><a href=""{0}"" onclick=""init.showImage('{0}'); return false;""><img src=""Default.aspx?img={0}"" alt='{0}'></img></a></li>" & vbCrLf, image)
    End Function
    Public Sub makeThumbs()
        Try
            Dim objImage As Image = System.Drawing.Image.FromFile(Server.MapPath(Request.QueryString("img")))
            Dim shtHeight As Short = 0
            Dim objThumbnail As System.Drawing.Bitmap

            shtHeight = objImage.Height / (objImage.Width / 150)
            objThumbnail = objImage.GetThumbnailImage(150, shtHeight, Nothing, System.IntPtr.Zero)
            objImage.Dispose()

            Dim objSquareFrame As New Drawing.Bitmap(100, 100)
            objSquareFrame.SetResolution(CType(72, Short), CType(72, Short))

            Dim objNewThumb As Drawing.Graphics = Drawing.Graphics.FromImage(objSquareFrame)

            objNewThumb.DrawImage(objThumbnail, New Rectangle(0, 0, objSquareFrame.Width, objSquareFrame.Height), 0, 0, objSquareFrame.Width, objSquareFrame.Height, Drawing.GraphicsUnit.Pixel)

            objNewThumb.Dispose()

            Response.ContentType = "image/jpeg"
            Response.Expires = 3600
            objSquareFrame.Save(Response.OutputStream, Imaging.ImageFormat.Jpeg)
            objImage.Dispose()
            objThumbnail.Dispose()
        Catch
        End Try
    End Sub
End Class
