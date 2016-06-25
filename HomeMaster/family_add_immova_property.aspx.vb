Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing

Public Class family_add_immova_property
    Inherits System.Web.UI.Page

    Shared random As New Random()
    Dim Vcategory_id As Integer
    Dim Vpurchase_method_id As Integer
    Dim Vproperty_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_category_ddl()
        bind_purchase_method_ddl()
        If Not IsPostBack Then
            delete_tochange_from_property_pic()
            delete_room_pic()
            delete_room()
        End If
    End Sub

    '######################################### THEME SETUP ##########################################################
    Private Sub family_add_immova_property_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '######################################### END OF THEME SETUP ##########################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from immovable_property_category  ", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_category.DataSource = ds
                ddl_select_category.DataTextField = "i_cat_name"
                ddl_select_category.DataValueField = "i_cat_name"
                ddl_select_category.DataBind()
                ddl_select_category.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_purchase_method_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from immovable_purchase_method_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_purchase_mathod.DataSource = ds
                ddl_select_purchase_mathod.DataTextField = "i_purchase_method"
                ddl_select_purchase_mathod.DataValueField = "i_purchase_method"
                ddl_select_purchase_mathod.DataBind()
                ddl_select_purchase_mathod.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################


    '########################################## SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################
    Private Sub check_category()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_property_category where i_cat_name = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_select_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("i_category_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into immovable_property_category(i_cat_name) values (LOWER(@cat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", ddl_select_category.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_category_id()
        End If
    End Sub
    Private Sub get_category_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_property_category where i_cat_name = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_select_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("i_category_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_purchase_method()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_purchase_method_tbl where i_purchase_method = LOWER(@pm)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@pm", ddl_select_purchase_mathod.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpurchase_method_id = reader2("i_purchase_method_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into immovable_purchase_method_tbl(i_purchase_method) values (LOWER(@pm))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@pm", ddl_select_purchase_mathod.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_purchse_method_id()
        End If
    End Sub
    Private Sub get_purchse_method_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_purchase_method_tbl where i_purchase_method = LOWER(@pm)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@pm", ddl_select_purchase_mathod.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpurchase_method_id = reader2("i_purchase_method_id")
            con2.Close()
        End If
    End Sub
    Private Sub btn_add_category_Click(sender As Object, e As EventArgs) Handles btn_add_category.Click
        If txtbx_add_category.Text = "" Then
            lbl_validation.Text = "enter category to add"
        Else
            ddl_select_category.SelectedItem.Text = txtbx_add_category.Text
        End If
    End Sub
    Private Sub btn_add_purchase_method_Click(sender As Object, e As EventArgs) Handles btn_add_purchase_method.Click
        If txtbx_add_purchase_method.Text = "" Then
            lbl_validation.Text = "enter purchase method to add"
        Else
            ddl_select_purchase_mathod.SelectedItem.Text = txtbx_add_purchase_method.Text
        End If
    End Sub
    '########################################## END OF SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################

    '############################################ ADD ROOM DETAILS ####################################################################
    Private Sub btn_open_panel_room_Click(sender As Object, e As EventArgs) Handles btn_open_panel_room.Click
        Panel_room.Visible = True
        Panel_uploader.Visible = False
    End Sub
    Private Sub btn_add_room_Click(sender As Object, e As EventArgs) Handles btn_add_room.Click
        If txtbx_room_name.Text = "" Then
            lbl_validation_room.Text = "enter room name"
        ElseIf validation_room_length.IsValid = True And validation_room_width.IsValid = True Then
            If txtbx_all_room.Text = "" Then
                txtbx_all_room.Text = txtbx_room_name.Text
            Else
                txtbx_all_room.Text = txtbx_all_room.Text + Environment.NewLine + txtbx_room_name.Text
            End If
            If txtbx_room_length.Text = "" Then
                txtbx_room_length.Text = 0
            End If
            If txtbx_room_width.Text = "" Then
                txtbx_room_width.Text = 0
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into immovable_room(room_name , room_length , room_width , room_note , room_status ) values ( @name , @len , @wid , @note , '@tochange')"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_room_name.Text)
            sqlCmd1.Parameters.AddWithValue("@len", CDec(txtbx_room_length.Text))
            sqlCmd1.Parameters.AddWithValue("@wid", CDec(txtbx_room_width.Text))
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_room_note.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            Panel_room.Visible = False
        End If
    End Sub
    '############################################ END OF ADD ROOM DETAILS ####################################################################

    '########################################### BIND DATA TO GRIDVIEW SELECT ROOM ############################################################
    Private Sub bind_to_gridview_select_room()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " SELECT i_room_id as [ref no] , room_name , room_length , room_width from immovable_room where room_status = '@tochange' "
        Dim sqlCmd As New SqlCommand(sql, con)
        'sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_room.DataSource = dt
        GridView_select_room.DataBind()
        con.Close()
    End Sub
    '########################################### BIND DATA TO GRIDVIEW SELECT ROOM ############################################################

    '############################################## MAKE GRIDVIEW SELECTABLE #############################################################################
    Private Sub GridView_select_room_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_room.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_room, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_room_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_room.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_room.Rows
            If row.RowIndex = GridView_select_room.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next

    End Sub
    '############################################## END OF MAKE GRIDVIEW SELECTABLE #############################################################################

    '########################################### SAVE ROOM PHOTO ############################################################################
    Private Sub btn_open_uploader_Click(sender As Object, e As EventArgs) Handles btn_open_uploader.Click
        Panel_uploader.Visible = True
        Panel_room.Visible = False

        bind_to_gridview_select_room()
    End Sub
    Private Sub btn_upload_pic_Click(sender As Object, e As EventArgs) Handles btn_upload_pic.Click
        If GridView_select_room.SelectedIndex = -1 Then
            lbl_validation_uploader.Text = "select room to upload picture"
        ElseIf GridView_select_room.Rows.Count = 0 Then
            lbl_validation_uploader.Text = "no room to upload picture"
        ElseIf validation_uload_img.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_img.HasFile Then
                Dim fileName As String = FileUpload_img.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    Dim filePath As String = Server.MapPath("~/UploadImages/roomPic/" + genrate_num1 + "_" + fileName)
                    FileUpload_img.PostedFile.SaveAs(filePath)
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "insert into room_photo_tbl(room_picUrl , i_room_id , room_pic_status)  values (@Path, @id , '@tochange')"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/roomPic/" + genrate_num1 + "_" + fileName)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_room.SelectedRow.Cells(0).Text))
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation_uploader.Text = "File successfully uploaded "
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation_uploader.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        displayImg()
                    End Try
                    Try
                    Catch ex As Exception
                        lbl_validation_uploader.Text = "Unable to upload file"
                    End Try
                Else
                    lbl_validation_uploader.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_img.HasFile = False Then
                lbl_validation_uploader.Text = "select picture to upload"
            End If
        End If
    End Sub
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select room_picUrl from room_photo_tbl where i_room_id = @id  "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@id", CInt(GridView_select_room.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_preview_img.DataSource = myReader
        Repeater_preview_img.DataBind()
    End Sub
    Private Sub btn_close_uploader_Click(sender As Object, e As EventArgs) Handles btn_close_uploader.Click
        Panel_uploader.Visible = False
    End Sub
    '########################################### END OF SAVE ROOM PHOTO ############################################################################

    '################################################# SAVE PROPERTY DETAILS ###########################################################################
    Private Sub btn_add_property_Click(sender As Object, e As EventArgs) Handles btn_add_property.Click
        If txtbx_item_name.Text = "" Then
            lbl_validation.Text = "enter name"
        ElseIf ddl_select_category.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select category"
        ElseIf ddl_select_purchase_mathod.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select purchase method"
        ElseIf validation_current_value.IsValid = True And validation_length.IsValid = True And validation_no_room.IsValid = True And validation_purchase_cost.IsValid = True And validation_purchase_date.IsValid = True And validation_width.IsValid = True Then
            check_category()
            check_purchase_method()

            If txtbx_current_value.Text = "" Then
                txtbx_current_value.Text = 0
            End If
            If txtbx_purchase_cost.Text = "" Then
                txtbx_purchase_cost.Text = 0
            End If
            If txtbx_length.Text = "" Then
                txtbx_length.Text = 0
            End If
            If txtbx_width.Text = "" Then
                txtbx_width.Text = 0
            End If
            If txtbx_no_room.Text = "" Then
                txtbx_no_room.Text = 0
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into immovable_property_tbl(i_name , i_location , i_current_value , i_purchase_cost , i_purchase_date  , i_length , i_width  ,i_note , i_status , family_id , i_category_id , i_purchase_method_id , i_no_room , i_expense_status) values (@name , @loc , @curr_val , @pur_cost , convert(date,@pur_date,103) , @len , @wid , @note , '@tochange'  , @famID , @cat_id , @purm_id , @noRoom , 'notadded'  )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
            sqlCmd1.Parameters.AddWithValue("@loc", txtbx_location.Text)
            sqlCmd1.Parameters.AddWithValue("@curr_val", CDec(txtbx_current_value.Text))
            sqlCmd1.Parameters.AddWithValue("@pur_cost", CDec(txtbx_purchase_cost.Text))
            sqlCmd1.Parameters.AddWithValue("@pur_date", txtbx_purchase_date.Text)
            sqlCmd1.Parameters.AddWithValue("@len", CDec(txtbx_length.Text))
            sqlCmd1.Parameters.AddWithValue("@wid", CDec(txtbx_width.Text))
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_notes.Text)
            sqlCmd1.Parameters.AddWithValue("@cat_id", Vcategory_id)
            sqlCmd1.Parameters.AddWithValue("@purm_id", Vpurchase_method_id)
            sqlCmd1.Parameters.AddWithValue("@noRoom", CInt(txtbx_no_room.Text))
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_property_id()
            lbl_validation.Text = "property saved"
        End If
    End Sub
    Private Sub get_property_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_property_tbl where i_status = '@tochange'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vproperty_id = CInt(reader2("i_property_id"))
            con2.Close()
            change_property_status()
            change_pic_property_id()
        End If
    End Sub
    Private Sub change_property_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_property_tbl set i_status = 'active' where i_property_id = @id "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        change_room_property_id()
    End Sub
    Private Sub change_room_property_id()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_room set i_property_id = @id where room_status = '@tochange' "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        change_room_status()
    End Sub
    Private Sub change_room_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_room set room_status = 'active' where i_property_id = @id "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        change_room_pic_status()
    End Sub
    Private Sub change_room_pic_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update room_photo_tbl set room_pic_status = 'active' "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        'sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################# END OF SAVE PROPERTY DETAILS ###########################################################################

    '################################################## UPLOAD PROPERTY PICTURES ######################################################################
    Private Sub btn_upload_property_img_Click(sender As Object, e As EventArgs) Handles btn_upload_property_img.Click
        If validation_property_img.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_prperty_img.HasFile Then
                Dim fileName As String = FileUpload_prperty_img.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    Dim filePath As String = Server.MapPath("~/UploadImages/propertyPic/" + genrate_num1 + "_" + fileName)
                    FileUpload_prperty_img.PostedFile.SaveAs(filePath)
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "insert into immovable_property_photo_tbl(i_picUrl ,i_pic_status ) values (@Path , '@tochange')"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/propertyPic/" + genrate_num1 + "_" + fileName)
                    'sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_room.SelectedRow.Cells(0).Text))
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation_property_img.Text = "File successfully uploaded "
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation_property_img.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        display_property_img()
                    End Try
                    Try
                    Catch ex As Exception
                        lbl_validation_property_img.Text = "Unable to upload file"
                    End Try
                Else
                    lbl_validation_property_img.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_prperty_img.HasFile = False Then
                lbl_validation_property_img.Text = "select picture to upload"
            End If
        End If
    End Sub
    Private Sub display_property_img()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select i_picUrl from immovable_property_photo_tbl where i_pic_status = '@tochange' "
        Dim cmd As New SqlCommand(sql, con)
        'cmd.Parameters.AddWithValue("@id", CInt(GridView_select_room.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_property_img.DataSource = myReader
        Repeater_property_img.DataBind()
    End Sub
    Private Sub change_pic_property_id()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_property_photo_tbl set i_property_id = @id where i_pic_status = '@tochange'"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        change_pic_status()
    End Sub
    Private Sub change_pic_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_property_photo_tbl set i_pic_status = 'active' where i_property_id = @id"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################## END OF UPLOAD PROPERTY PICTURES ######################################################################

    '################################################## CANCEL PROPERTY SAVE ############################################################################
    Private Sub btn_cancel_save_property_Click(sender As Object, e As EventArgs) Handles btn_cancel_save_property.Click
        delete_tochange_from_property_pic()
        delete_room_pic()
        delete_room()
        Response.Redirect("./family_home_form.aspx")
    End Sub
    Private Sub delete_tochange_from_property_pic()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from immovable_property_photo_tbl where i_pic_status = '@tochange'"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        'sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub delete_room_pic()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from room_photo_tbl where room_pic_status='@tochange'"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        'sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub delete_room()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from immovable_room where room_status =  '@tochange'"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        'sqlCmd1.Parameters.AddWithValue("@id", Vproperty_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################## END OF CANCEL PROPERTY SAVE ############################################################################

    '################################################### PAGING FOR GRIDVIEW ########################################################################
    Private Sub GridView_select_room_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_room.PageIndexChanging
        GridView_select_room.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_select_room()
    End Sub
    '################################################### END OF PAGING FOR GRIDVIEW ########################################################################

    Private Sub btn_close_panel_room_Click(sender As Object, e As EventArgs) Handles btn_close_panel_room.Click
        Panel_room.Visible = False
    End Sub
End Class