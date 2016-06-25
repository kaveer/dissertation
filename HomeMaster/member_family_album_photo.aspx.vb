Imports System.Data.SqlClient
Imports System.IO

Public Class member_family_album_photo
    Inherits System.Web.UI.Page

    Shared random As New Random()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_folder_name.Text = Session("album_name") + " " + "folder"
        displayImg()
    End Sub

    '################################## THEME SETUP #########################################################################
    Private Sub member_family_album_photo_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #################################################################

    '######################################### DISPLAY IMAGE TO REPEATER/GRIDVIEW ###################################################################
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = " select * from family_album_photo_tbl where pic_status = 'active' and album_id = @ID "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(Session("album_id")))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater1.DataSource = myReader
        Repeater1.DataBind()
    End Sub
    Private Sub bind_gridview_remove_pic()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = " select * from family_album_photo_tbl where pic_status = 'active' and album_id = @ID "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(Session("album_id")))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        GridView_open_gallery.DataSource = myReader
        GridView_open_gallery.DataBind()
    End Sub
    '######################################### END OF DISPLAY IMAGE TO REPEATER/GRIDVIEW ###################################################################

    '######################################### UPLOAD/DISPLAY IMAGE ######################################################################
    Private Sub btn_upload_pic_Click(sender As Object, e As EventArgs) Handles btn_upload_pic.Click
        If validation_uload_img.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_img.HasFile Then
                Dim fileName As String = FileUpload_img.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    Dim filePath As String = Server.MapPath("~/UploadImages/familyAlbum/" + genrate_num1 + "_" + fileName)
                    FileUpload_img.PostedFile.SaveAs(filePath)
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "insert into family_album_photo_tbl (pic_url , pic_status , album_id ) values (@Path, 'active' , @id)"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/familyAlbum/" + genrate_num1 + "_" + fileName)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(Session("album_id")))
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation_photo_gallery.Text = "File successfully uploaded "
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation_photo_gallery.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        displayImg()
                    End Try
                    Try
                    Catch ex As Exception
                        lbl_validation_photo_gallery.Text = "Unable to upload file"
                    End Try
                Else
                    lbl_validation_photo_gallery.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_img.HasFile = False Then
                lbl_validation_photo_gallery.Text = "select picture to upload"
            End If
        End If
    End Sub
    '######################################### END OF UPLOAD/DISPLAY IMAGE ######################################################################

    Private Sub btn_close_gallery_Click(sender As Object, e As EventArgs) Handles btn_close_gallery.Click
        Panel_open_gallery.Visible = False
    End Sub
    Private Sub btn_remove_photo_Click(sender As Object, e As EventArgs) Handles btn_remove_photo.Click
        bind_gridview_remove_pic()
        Panel_open_gallery.Visible = True
    End Sub

    Private Sub btn_back_album_folder_Click(sender As Object, e As EventArgs) Handles btn_back_album_folder.Click
        Response.Redirect("./member_family_album_folder.aspx")
    End Sub

    '################################# REMOVE PHOTO #############################################################################################
    Private Sub btn_delete_photo_Click(sender As Object, e As EventArgs) Handles btn_delete_photo.Click
        For Each row As GridViewRow In GridView_open_gallery.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked = True Then
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "update family_album_photo_tbl set pic_status = 'deactive' where photo_id = @id"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(row.Cells(1).Text))
                    con1.Open()
                    sqlCmd1.ExecuteNonQuery()
                    con1.Close()
                    Panel_open_gallery.Visible = False
                    displayImg()
                End If
            End If
        Next
    End Sub
    '################################# END OF REMOVE PHOTO #############################################################################################


End Class