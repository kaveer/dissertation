Imports System.Data.SqlClient
Imports System.IO

Public Class member_add_move_asset
    Inherits System.Web.UI.Page

    Shared random As New Random()
    Dim Vlocation_id As Integer
    Dim Vcategory_id As Integer
    Dim Vpurchase_method_id As Integer
    Dim Vasset_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_location_ddl()
        bind_category_ddl()
        bind_purchase_method_ddl()
    End Sub

    '######################################### THEME SETUP ##########################################################
    Private Sub member_add_move_asset_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '######################################### END OF THEME SETUP ##########################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_location_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from moveable_asset_location_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_location.DataSource = ds
                ddl_select_location.DataTextField = "m_location"
                ddl_select_location.DataValueField = "m_location"
                ddl_select_location.DataBind()
                ddl_select_location.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from moveable_asset_category_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_category.DataSource = ds
                ddl_select_category.DataTextField = "m_category"
                ddl_select_category.DataValueField = "m_category"
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
                Dim cmd As New SqlCommand("select * from moveable_asset_purch_mtd_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_purchase_mathod.DataSource = ds
                ddl_select_purchase_mathod.DataTextField = "purchase_method"
                ddl_select_purchase_mathod.DataValueField = "purchase_method"
                ddl_select_purchase_mathod.DataBind()
                ddl_select_purchase_mathod.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################

    '########################################## SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################
    Private Sub check_location()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_location_tbl where m_location = LOWER(@loc)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@loc", ddl_select_location.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vlocation_id = reader2("m_loction_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into moveable_asset_location_tbl(m_location) values (LOWER(@loc))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@loc", ddl_select_location.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_location_id()
        End If
    End Sub
    Private Sub get_location_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_location_tbl where m_location = LOWER(@loc)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@loc", ddl_select_location.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vlocation_id = reader2("m_loction_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_category()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_category_tbl where m_category = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_select_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("m_category_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into moveable_asset_category_tbl(m_category) values (LOWER(@cat))"
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
        Dim sql2 = "select * from moveable_asset_category_tbl where m_category = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_select_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("m_category_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_purchase_method()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_purch_mtd_tbl where purchase_method = LOWER(@pm)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@pm", ddl_select_purchase_mathod.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpurchase_method_id = reader2("m_purchase_method_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into moveable_asset_purch_mtd_tbl(purchase_method) values (LOWER(@pm))"
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
        Dim sql2 = "select * from moveable_asset_purch_mtd_tbl where purchase_method = LOWER(@pm)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@pm", ddl_select_purchase_mathod.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpurchase_method_id = reader2("m_purchase_method_id")
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
    Private Sub btn_add_location_Click(sender As Object, e As EventArgs) Handles btn_add_location.Click
        If txtbx_add_location.Text = "" Then
            lbl_validation.Text = "enter location to add"
        Else
            ddl_select_location.SelectedItem.Text = txtbx_add_location.Text
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

    '############################################ SAVE MOVEABLE ASSET INFORMATION ###################################################
    Private Sub btn_save_move_asset_Click(sender As Object, e As EventArgs) Handles btn_save_move_asset.Click
        If txtbx_current_value.Text = "" Then
            txtbx_current_value.Text = 0
        End If
        If txtbx_purchase_cost.Text = "" Then
            txtbx_purchase_cost.Text = 0
        End If
        If ddl_select_category.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "Select category"
        ElseIf ddl_select_location.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select location"
        ElseIf ddl_select_purchase_mathod.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select purchase method"
        ElseIf txtbx_item_name.Text = "" Then
            lbl_validation.Text = "enter name"
        ElseIf validation_current_value.IsValid = True And validation_purchase_cost.IsValid = True And validation_purchase_date.IsValid = True And validation_quantity.IsValid = True And validation_warranty.IsValid = True Then
            check_location()
            check_category()
            check_purchase_method()

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into moveable_asset_tbl(m_item_name , m_retailer , m_current_value , m_purchase_cost , m_purchase_date , m_quantity , m_make , m_model , m_serial_num , m_warrenty_period , m_note , m_status , m_loction_id , m_category_id , family_id , m_purchase_method_id , m_expense_status) values ('@tochange' , @retail , @cur_value , @purCost , convert(date,@date,103)  , @quantity , @make , @model , @serial , @warranty , @note , 'active' , @location , @category , @famID , @purM , 'notadded' )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@retail", txtbx_retailer.Text)
            sqlCmd1.Parameters.AddWithValue("@cur_value", CDec(txtbx_current_value.Text))
            sqlCmd1.Parameters.AddWithValue("@purCost", CDec(txtbx_purchase_cost.Text))
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_purchase_date.Text)
            sqlCmd1.Parameters.AddWithValue("@quantity", txtbx_quantity.Text)
            sqlCmd1.Parameters.AddWithValue("@make", txtbx_make.Text)
            sqlCmd1.Parameters.AddWithValue("@model", txtbx_model.Text)
            sqlCmd1.Parameters.AddWithValue("@serial", txtbx_serial_num.Text)
            sqlCmd1.Parameters.AddWithValue("@warranty", txtbx_warranty_period.Text)
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_notes.Text)
            sqlCmd1.Parameters.AddWithValue("@location", Vlocation_id)
            sqlCmd1.Parameters.AddWithValue("@category", Vcategory_id)
            sqlCmd1.Parameters.AddWithValue("@purM", Vpurchase_method_id)
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_asset_id()
            lbl_validation.Text = "new asset saved"
        End If
    End Sub
    Private Sub get_asset_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_tbl where m_item_name = '@tochange'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vasset_id = CInt(reader2("m_asset_id"))
            con2.Close()
            change_asset_name()
        End If
    End Sub
    Private Sub change_asset_name()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update moveable_asset_tbl set m_item_name = @name where m_asset_id = @id"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
        sqlCmd1.Parameters.AddWithValue("@id", Vasset_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        add_asset_id_to_img()
    End Sub
    Private Sub add_asset_id_to_img()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update moveable_asset_photo_tbl set m_asset_id = @id where pic_status = '@tochange'"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@id", Vasset_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        change_pic_status()
    End Sub
    Private Sub change_pic_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update moveable_asset_photo_tbl set pic_status = 'active' where m_asset_id = @id"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@id", Vasset_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        displayImg_after_save()
    End Sub
    Private Sub displayImg_after_save()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl where m_asset_id = @id and pic_status = 'active'"
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@id", Vasset_id)
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_preview_img.DataSource = myReader
        Repeater_preview_img.DataBind()
    End Sub
    '############################################ SAVE MOVEABLE ASSET INFORMATION ###################################################

    '######################################### UPLOAD/DISPLAY IMAGE ######################################################################
    Private Sub btn_upload_pic_Click(sender As Object, e As EventArgs) Handles btn_upload_pic.Click
        If validation_uload_img.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_img.HasFile Then
                Dim fileName As String = FileUpload_img.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    Dim filePath As String = Server.MapPath("~/UploadImages/moveableAsset/" + genrate_num1 + "_" + fileName)
                    FileUpload_img.PostedFile.SaveAs(filePath)
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "insert into moveable_asset_photo_tbl(picUrl , pic_status) values (@Path, '@tochange')"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/moveableAsset/" + genrate_num1 + "_" + fileName)
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation.Text = "File successfully uploaded "
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        displayImg()
                    End Try
                    Try
                    Catch ex As Exception
                        lbl_validation.Text = "Unable to upload file"
                    End Try
                Else
                    lbl_validation.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_img.HasFile = False Then
                lbl_validation.Text = "select picture to upload"
            End If
        End If
    End Sub
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl where pic_status = '@tochange'  "
        Dim cmd As New SqlCommand(sql, con)
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_preview_img.DataSource = myReader
        Repeater_preview_img.DataBind()
    End Sub
    '######################################### END OF UPLOAD/DISPLAY IMAGE ######################################################################
End Class