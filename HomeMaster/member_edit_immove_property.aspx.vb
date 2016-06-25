Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class member_edit_immove_property
    Inherits System.Web.UI.Page

    Shared random As New Random()
    Dim Vname As String
    Dim Vlocation As String
    Dim Vcurrent_value As Decimal
    Dim Vpurchase_cost As Decimal
    Dim Vpurchase_date As String
    Dim Vlength As Decimal
    Dim Vwidth As Decimal
    Dim Vnote As String
    Dim Vroom_no As Integer
    Dim Vcategory_id As Integer
    Dim Vpurchase_method_id As Integer
    Dim Vproperty_id As Integer

    Dim Vroom_name As String
    Dim Vroom_note As String
    Dim Vroom_length As Decimal
    Dim Vroom_width As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_preview_asset()
        bind_category_ddl()
        bind_purchase_method_ddl()
    End Sub

    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub

    '######################################### THEME SETUP ##########################################################
    Private Sub member_edit_immove_property_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '######################################### END OF THEME SETUP ##########################################################

    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  i_property_id as [ref no] , i_name as [Name] , i_cat_name as [Category] , i_purchase_method as [Purchase method] from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'active' order by i_property_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_active_immov.DataSource = dt
        GridView_active_immov.DataBind()
        con.Close()
    End Sub
    Private Sub bind_active_property_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_name as [Name] , i_location as [location] , i_current_value as [Current value] , i_purchase_cost as [Purchase cost] ,  FORMAT(i_purchase_date , 'dd/MM/yyyy') as [Purchase date]   , i_length as [Length] , i_width as [Width] , i_note as [Note] , i_cat_name as [Category]  , i_purchase_method as [Purchase method]  from immovable_property_tbl as i inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id = p.i_purchase_method_id where i_property_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_property_detail.DataSource = dt
        DetailsView_property_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_to_gridview_room_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_room_id as [ref no] , room_name  as [Room], room_length as [length] , room_width as [Width] , room_note as [Note] from immovable_room as r inner join immovable_property_tbl as p on r.i_property_id = p.i_property_id where r.i_property_id = @id and room_status='active' order by i_room_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_room_detail.DataSource = dt
        GridView_room_detail.DataBind()
        con.Close()
    End Sub
    Private Sub display_property_img_to_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select i_photo_id , i_picUrl from immovable_property_photo_tbl where i_property_id = @ID and i_pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        GridView_open_gallery.DataSource = myReader
        GridView_open_gallery.DataBind()
    End Sub
    Private Sub display_room_img_to_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select room_pic_id , room_picUrl from room_photo_tbl where i_room_id = @ID and room_pic_status = 'active'"
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_room_detail.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        GridView_room_photo.DataSource = myReader
        GridView_room_photo.DataBind()
    End Sub

    
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    '#################################### MAKE GRIDVIEW SELECTABLE ##################################################################
    Private Sub GridView_active_immov_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_active_immov.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_active_immov, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_active_immov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_active_immov.SelectedIndexChanged
        For Each row As GridViewRow In GridView_active_immov.Rows
            If row.RowIndex = GridView_active_immov.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_active_property_detail()
        'displayImg()
        bind_to_gridview_room_detail()
        display_property_img_to_gridview()
    End Sub
    Private Sub GridView_room_detail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_room_detail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_room_detail, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_room_detail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_room_detail.SelectedIndexChanged
        For Each row As GridViewRow In GridView_room_detail.Rows
            If row.RowIndex = GridView_room_detail.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        'dispaly_room_img()
        display_room_img_to_gridview()
    End Sub
    '#################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################


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
            lbl_validation_view1.Text = "enter category to add"
        Else
            ddl_select_category.SelectedItem.Text = txtbx_add_category.Text
        End If
    End Sub
    Private Sub btn_add_purchase_method_Click(sender As Object, e As EventArgs) Handles btn_add_purchase_method.Click
        If txtbx_add_purchase_method.Text = "" Then
            lbl_validation_view1.Text = "enter purchase method to add"
        Else
            ddl_select_purchase_mathod.SelectedItem.Text = txtbx_add_purchase_method.Text
        End If
    End Sub
    '########################################## END OF SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################

    '############################################# UPDATE PROPERTY/ROOM DETAIL ###########################################################
    Private Sub btn_update_property_Click(sender As Object, e As EventArgs) Handles btn_update_property.Click
        If GridView_active_immov.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select property to update"
        ElseIf validation_current_value.IsValid = True And validation_length.IsValid = True And validation_no_room.IsValid = True And validation_purchase_cost.IsValid = True And validation_purchase_date.IsValid = True And validation_width.IsValid = True Then
            get_data_to_varibles()
            If Not ddl_select_category.SelectedItem.Text = "--Select type--" Then
                check_category()
            End If
            If Not ddl_select_purchase_mathod.SelectedItem.Text = "--Select type--" Then
                check_purchase_method()
            End If
            If txtbx_item_name.Text = "" Then
                txtbx_item_name.Text = Vname
            End If
            If txtbx_location.Text = "" Then
                txtbx_location.Text = Vlocation
            End If
            If txtbx_current_value.Text = "" Then
                txtbx_current_value.Text = Vcurrent_value
            End If
            If txtbx_purchase_cost.Text = "" Then
                txtbx_purchase_cost.Text = CStr(Vpurchase_cost)
            End If
            If txtbx_purchase_date.Text = "" Then
                txtbx_purchase_date.Text = Vpurchase_date
            End If
            If txtbx_length.Text = "" Then
                txtbx_length.Text = CStr(Vlength)
            End If
            If txtbx_width.Text = "" Then
                txtbx_width.Text = CStr(Vwidth)
            End If
            If txtbx_notes.Text = "" Then
                txtbx_notes.Text = Vnote
            End If
            If txtbx_no_room.Text = "" Then
                txtbx_no_room.Text = CStr(Vroom_no)
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update immovable_property_tbl set i_name = @name, i_location = @loc , i_current_value = @curVal , i_purchase_cost = @cost , i_purchase_date = convert(date,@date,103) , i_length = @len , i_width = @wid , i_note = @note , i_category_id = @cat , i_purchase_method_id = @purM , i_no_room = @roomNo where i_property_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
            sqlCmd1.Parameters.AddWithValue("@loc", txtbx_location.Text)
            sqlCmd1.Parameters.AddWithValue("@curVal", CDec(txtbx_current_value.Text))
            sqlCmd1.Parameters.AddWithValue("@cost", CDec(txtbx_purchase_cost.Text))
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_purchase_date.Text)
            sqlCmd1.Parameters.AddWithValue("@len", CDec(txtbx_length.Text))
            sqlCmd1.Parameters.AddWithValue("@wid", CDec(txtbx_width.Text))
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_notes.Text)
            sqlCmd1.Parameters.AddWithValue("@cat", Vcategory_id)
            sqlCmd1.Parameters.AddWithValue("@purM", Vpurchase_method_id)
            sqlCmd1.Parameters.AddWithValue("@roomNo", CInt(txtbx_no_room.Text))
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "property updated"
            txtbx_item_name.Text = ""
            txtbx_location.Text = ""
            txtbx_current_value.Text = ""
            txtbx_purchase_cost.Text = ""
            txtbx_purchase_date.Text = ""
            txtbx_length.Text = ""
            txtbx_width.Text = ""
            txtbx_notes.Text = ""
            txtbx_no_room.Text = ""
            bind_to_gridview_preview_asset()
            bind_active_property_detail()
            GridView_active_immov.SelectedIndex = -1
        End If
    End Sub
    Private Sub btn_update_room_detail_Click(sender As Object, e As EventArgs) Handles btn_update_room_detail.Click
        If GridView_active_immov.SelectedIndex = -1 Then
            lbl_validation_room.Text = "select property to update"
        ElseIf GridView_room_detail.SelectedIndex = -1 Then
            lbl_validation_room.Text = "select room to update"
        ElseIf validation_room_length.IsValid = True And validation_room_width.IsValid = True Then
            get_data_from_property_room()
            If txtbx_room_name.Text = "" Then
                txtbx_room_name.Text = Vroom_name
            End If
            If txtbx_room_note.Text = "" Then
                txtbx_room_note.Text = Vroom_note
            End If
            If txtbx_room_length.Text = "" Then
                txtbx_room_length.Text = CStr(Vroom_length)
            End If
            If txtbx_room_width.Text = "" Then
                txtbx_room_width.Text = CStr(Vroom_width)
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update immovable_room set room_name = @name , room_note = @note ,room_length = @len , room_width = @wid where i_room_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_room_name.Text)
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_room_note.Text)
            sqlCmd1.Parameters.AddWithValue("@len", CDec(txtbx_room_length.Text))
            sqlCmd1.Parameters.AddWithValue("@wid", CDec(txtbx_room_width.Text))
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_room_detail.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_room_detail()
            txtbx_room_name.Text = ""
            txtbx_room_note.Text = ""
            txtbx_room_length.Text = ""
            txtbx_room_width.Text = ""
            lbl_validation_room.Text = "room updated"
            GridView_room_detail.SelectedIndex = -1
        End If
    End Sub
    '############################################# END OF UPDATE PROPERTY/ROOM DETAIL ###########################################################

    '############################################# TRANSFER DETAIL TO VARIABLES ##############################################################
    Private Sub get_data_to_varibles()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_property_tbl where i_property_id = @id "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vname = reader2("i_name")
            Vlocation = reader2("i_location")
            Vcurrent_value = CDec(reader2("i_current_value"))
            Vpurchase_cost = CDec(reader2("i_purchase_cost"))
            Vpurchase_date = reader2("i_purchase_date")
            Vlength = CDec(reader2("i_length"))
            Vwidth = CDec(reader2("i_width"))
            Vnote = reader2("i_note")
            Vcategory_id = CInt(reader2("i_category_id"))
            Vpurchase_method_id = CInt(reader2("i_purchase_method_id"))
            Vroom_no = CInt(reader2("i_no_room"))
            con2.Close()
        End If
    End Sub
    Private Sub get_data_from_property_room()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from immovable_room where i_room_id = @id "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", CInt(GridView_room_detail.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vroom_name = reader2("room_name")
            Vroom_note = reader2("room_note")
            Vroom_length = CDec(reader2("room_length"))
            Vroom_width = CDec(reader2("room_width"))
            con2.Close()
        End If
    End Sub
    '############################################# END OF TRANSFER DETAIL TO VARIABLES ##############################################################

    '########################################## DELETE PHOTO #######################################################################################
    Private Sub btn_delete_photo_Click(sender As Object, e As EventArgs) Handles btn_delete_photo.Click
        For Each row As GridViewRow In GridView_open_gallery.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked = True Then
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "update immovable_property_photo_tbl set i_pic_status = 'deactive' where i_photo_id =  @id"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(row.Cells(1).Text))
                    con1.Open()
                    sqlCmd1.ExecuteNonQuery()
                    con1.Close()
                    display_property_img_to_gridview()
                End If
            End If
        Next
    End Sub
    Private Sub btn_delete_room_img_Click(sender As Object, e As EventArgs) Handles btn_delete_room_img.Click
        For Each row As GridViewRow In GridView_room_photo.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked = True Then
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "update room_photo_tbl set room_pic_status = 'deactive' where room_pic_id =   @id"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(row.Cells(1).Text))
                    con1.Open()
                    sqlCmd1.ExecuteNonQuery()
                    con1.Close()
                    display_room_img_to_gridview()
                End If
            End If
        Next
    End Sub
    '########################################## END OF DELETE PHOTO #######################################################################################

   

    '######################################### UPLOAD/DISPLAY IMAGE ######################################################################
    Private Sub btn_upload_pic_Click(sender As Object, e As EventArgs) Handles btn_upload_pic.Click
        If validation_uload_img.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_img.HasFile Then
                Dim fileName As String = FileUpload_img.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    If GridView_active_immov.SelectedIndex = -1 Then
                        lbl_validation_photo_gallery.Text = "Select property to upload picture"
                    ElseIf GridView_active_immov.Rows.Count = 0 Then
                        lbl_validation_photo_gallery.Text = "no property to upload picture"
                    Else
                        Dim filePath As String = Server.MapPath("~/UploadImages/propertyPic/" + genrate_num1 + "_" + fileName)
                        FileUpload_img.PostedFile.SaveAs(filePath)
                        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                        Dim sql1 = "insert into immovable_property_photo_tbl(i_picUrl , i_pic_status , i_property_id) values (@Path, 'active' , @id)"
                        Dim sqlCmd1 As New SqlCommand(sql1, con1)
                        sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/propertyPic/" + genrate_num1 + "_" + fileName)
                        sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
                        sqlCmd1.CommandType = CommandType.Text
                        lbl_validation_photo_gallery.Text = "File successfully uploaded "
                        Try
                            con1.Open()
                            sqlCmd1.ExecuteNonQuery()
                        Catch ex As Exception
                            lbl_validation_photo_gallery.Text = "Unable to insert file data in database"
                        Finally
                            con1.Close()
                            display_property_img_to_gridview()
                        End Try
                        Try
                        Catch ex As Exception
                            lbl_validation_photo_gallery.Text = "Unable to upload file"
                        End Try
                    End If                
                Else
                    lbl_validation_photo_gallery.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_img.HasFile = False Then
                lbl_validation_photo_gallery.Text = "select picture to upload"
            End If
        End If
    End Sub
    Private Sub btn_upload_room_img_Click(sender As Object, e As EventArgs) Handles btn_upload_room_img.Click
        If validation_room_photo.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_room_photo.HasFile Then
                If GridView_room_detail.SelectedIndex = -1 Then
                    lbl_validation_room_img.Text = "select room to upload file"
                ElseIf GridView_room_detail.Rows.Count = 0 Then
                    lbl_validation_room_img.Text = "no room to upload file"
                Else
                    Dim fileName As String = FileUpload_room_photo.PostedFile.FileName
                    Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                    Dim extensionsAllowed As String() = {".jpg", ".png"}
                    If extensionsAllowed.Contains(fileExtension) Then
                        Dim filePath As String = Server.MapPath("~/UploadImages/roomPic/" + genrate_num1 + "_" + fileName)
                        FileUpload_room_photo.PostedFile.SaveAs(filePath)
                        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                        Dim sql1 = "insert into room_photo_tbl(room_picUrl , room_pic_status , i_room_id)  values (@Path, 'active' , @id)"
                        Dim sqlCmd1 As New SqlCommand(sql1, con1)
                        sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/roomPic/" + genrate_num1 + "_" + fileName)
                        sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_room_detail.SelectedRow.Cells(0).Text))
                        sqlCmd1.CommandType = CommandType.Text
                        lbl_validation_room_img.Text = "File successfully uploaded "
                        Try
                            con1.Open()
                            sqlCmd1.ExecuteNonQuery()
                        Catch ex As Exception
                            lbl_validation_room_img.Text = "Unable to insert file data in database"
                        Finally
                            con1.Close()
                            display_room_img_to_gridview()
                        End Try
                        Try
                        Catch ex As Exception
                            lbl_validation_room_img.Text = "Unable to upload file"
                        End Try
                    Else
                        lbl_validation_room_img.Text = "File extension " + fileExtension + " is not allowed"
                    End If
                End If
               
            ElseIf FileUpload_room_photo.HasFile = False Then
                lbl_validation_room_img.Text = "select picture to upload"
            End If
        End If
    End Sub
    '######################################### END OF UPLOAD/DISPLAY IMAGE ######################################################################

    '########################################## PAGING IN GRIDVIEW #############################################################################
    Private Sub GridView_active_immov_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_active_immov.PageIndexChanging
        GridView_active_immov.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
    Private Sub GridView_room_photo_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_room_photo.PageIndexChanging
        GridView_room_detail.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_room_detail()
    End Sub
    '########################################## END OF PAGING IN GRIDVIEW #############################################################################
   
End Class