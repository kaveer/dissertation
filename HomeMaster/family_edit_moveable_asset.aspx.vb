Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class family_edit_moveable_asset
    Inherits System.Web.UI.Page

    Dim Vlocation_id As Integer
    Dim Vcategory_id As Integer
    Dim Vpurchase_method_id As Integer
    Dim Vitem_name As String
    Dim Vretailer As String
    Dim Vcurrent_value As Decimal
    Dim Vpurchase_cost As Decimal
    Dim Vpurchase_date As String
    Dim Vquantity As Integer
    Dim Vmake As String
    Dim Vmodel As String
    Dim Vserial_num As String
    Dim Vwarranty As Integer
    Dim Vnote As String
    Dim Vfamily_id As Integer

    Shared random As New Random()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_to_gridview_preview_asset()
        End If
        bind_location_ddl()
        bind_category_ddl()
        bind_purchase_method_ddl()
    End Sub

    '################################## THEME SETUP #########################################################################
    Private Sub family_edit_moveable_asset_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #################################################################


    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' order by desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_view_active_preview_assets.DataSource = dt
        GridView_view_active_preview_assets.DataBind()
        con.Close()
    End Sub
    Private Sub bind_active_detailview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name as [Name] , m_retailer as [Retailer] , m_current_value as [Current value] ,  m_purchase_cost as [Purchase method] , FORMAT(m_purchase_date , 'dd/MM/yyyy')  as [Purchase date] , m_quantity as [Quantity] , m_make as [Make] , m_model as [Model] , m_serial_num as [Serial no] , m_warrenty_period as [Warrenty period] , m_note as [Note] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' and m_asset_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_active_asset.DataSource = dt
        DetailsView_active_asset.DataBind()
        con.Close()
    End Sub
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    '#################################### MAKE GRIDVIEW SELECTABLE ##################################################################
    Private Sub GridView_view_active_preview_assets_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_view_active_preview_assets.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_view_active_preview_assets, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_view_active_preview_assets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_view_active_preview_assets.SelectedIndexChanged
        For Each row As GridViewRow In GridView_view_active_preview_assets.Rows
            If row.RowIndex = GridView_view_active_preview_assets.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_active_detailview()
        displayImg()
        Panel_view_img.Visible = True
    End Sub
    '#################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################

    '######################################### DISPLAY IMAGE TO REPEATER ###################################################################
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id where p.m_asset_id = @ID and  pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater1.DataSource = myReader
        Repeater1.DataBind()
    End Sub
    '######################################### END OF DISPLAY IMAGE TO REPEATER ###################################################################

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

    '########################################## TRANSFER DATA TO VARIABLES #####################################################
    Private Sub get_data_to_variables()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from moveable_asset_tbl where m_asset_id = @id"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", GridView_view_active_preview_assets.SelectedRow.Cells(0).Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vlocation_id = CInt(reader2("m_loction_id"))
            Vcategory_id = CInt(reader2("m_category_id"))
            Vpurchase_method_id = CInt(reader2("m_purchase_method_id"))
            Vitem_name = reader2("m_item_name")
            Vretailer = reader2("m_retailer")
            Vcurrent_value = CDec(reader2("m_current_value"))
            Vpurchase_cost = CDec(reader2("m_purchase_cost"))
            Vpurchase_date = reader2("m_purchase_date")
            Vquantity = CInt(reader2("m_quantity"))
            Vmake = reader2("m_make")
            Vmodel = reader2("m_model")
            Vserial_num = reader2("m_serial_num")
            Vwarranty = CInt(reader2("m_warrenty_period"))
            Vnote = reader2("m_note")
            Vfamily_id = CInt(reader2("family_id"))
            con2.Close()
        End If
    End Sub
    '########################################## END OF TRANSFER DATA TO VARIABLES #####################################################

    '############################################# UPDATE MOVEABLE ASSET ##############################################################
    Private Sub btn_update_asset_Click(sender As Object, e As EventArgs) Handles btn_update_asset.Click
        If GridView_view_active_preview_assets.SelectedIndex = -1 Then
            lbl_validation.Text = "select insurance to update"
        ElseIf validation_current_value.IsValid = True And validation_purchase_cost.IsValid = True And validation_purchase_date.IsValid = True And validation_quantity.IsValid = True And validation_warranty.IsValid = True Then
            get_data_to_variables()

            If Not ddl_select_category.SelectedItem.Text = "--Select type--" Then
                check_category()
            End If
            If Not ddl_select_location.SelectedItem.Text = "--Select type--" Then
                check_location()
            End If
            If Not ddl_select_purchase_mathod.SelectedItem.Text = "--Select type--" Then
                check_purchase_method()
            End If
            If txtbx_item_name.Text = "" Then
                txtbx_item_name.Text = Vitem_name
            End If
            If txtbx_retailer.Text = "" Then
                txtbx_retailer.Text = Vretailer
            End If
            If txtbx_current_value.Text = "" Then
                txtbx_current_value.Text = CStr(Vcurrent_value)
            End If
            If txtbx_purchase_cost.Text = "" Then
                txtbx_purchase_cost.Text = CStr(Vpurchase_cost)
            End If
            If txtbx_purchase_date.Text = "" Then
                txtbx_purchase_date.Text = Vpurchase_date
            End If
            If txtbx_quantity.Text = "" Then
                txtbx_quantity.Text = CStr(Vquantity)
            End If
            If txtbx_make.Text = "" Then
                txtbx_make.Text = Vmake
            End If
            If txtbx_model.Text = "" Then
                txtbx_model.Text = Vmodel
            End If
            If txtbx_serial_num.Text = "" Then
                txtbx_serial_num.Text = Vserial_num
            End If
            If txtbx_warranty_period.Text = "" Then
                txtbx_warranty_period.Text = CStr(Vwarranty)
            End If
            If txtbx_notes.Text = "" Then
                txtbx_notes.Text = Vnote
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update moveable_asset_tbl set m_item_name = @name , m_retailer = @retail , m_current_value = @currVal , m_purchase_cost = @cost , m_purchase_date = convert(date,@date,103) , m_quantity = @quan , m_make = @make , m_model = @model , m_serial_num = @serial , m_warrenty_period = @warranty , m_note = @note , m_loction_id = @location , m_category_id = @cat , m_purchase_method_id = @purM where m_asset_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_item_name.Text)
            sqlCmd1.Parameters.AddWithValue("@retail", txtbx_retailer.Text)
            sqlCmd1.Parameters.AddWithValue("@currVal", CDec(txtbx_current_value.Text))
            sqlCmd1.Parameters.AddWithValue("@cost", CDec(txtbx_purchase_cost.Text))
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_purchase_date.Text)
            sqlCmd1.Parameters.AddWithValue("@quan", CInt(txtbx_quantity.Text))
            sqlCmd1.Parameters.AddWithValue("@make", txtbx_make.Text)
            sqlCmd1.Parameters.AddWithValue("@model", txtbx_model.Text)
            sqlCmd1.Parameters.AddWithValue("@serial", txtbx_serial_num.Text)
            sqlCmd1.Parameters.AddWithValue("@warranty", CInt(txtbx_warranty_period.Text))
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_notes.Text)
            sqlCmd1.Parameters.AddWithValue("@location", Vlocation_id)
            sqlCmd1.Parameters.AddWithValue("@cat", Vcategory_id)
            sqlCmd1.Parameters.AddWithValue("@purM", Vpurchase_method_id)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_preview_asset()
            bind_active_detailview()

        End If
    End Sub
    '############################################# END OF UPDATE MOVEABLE ASSET ##############################################################

    '############################################# OPEN GALLERY IN EDIT MODE #################################################################
    Private Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        If e.CommandName = "open_gallery" Then
            Panel_open_gallery.Visible = True
            bind_gridview_img()
        End If
    End Sub
    Private Sub bind_gridview_img()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select  m_photo_id , picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id where p.m_asset_id = @ID and  pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        GridView_open_gallery.DataSource = myReader
        GridView_open_gallery.DataBind()

    End Sub
    '############################################# OPEN GALLERY IN EDIT MODE #################################################################

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
                    Dim sql1 = "insert into moveable_asset_photo_tbl(picUrl , pic_status ,  m_asset_id) values (@Path, 'active' , @id)"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/moveableAsset/" + genrate_num1 + "_" + fileName)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation_photo_gallery.Text = "File successfully uploaded and save insurance"
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation_photo_gallery.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        displayImg()
                        bind_gridview_img()
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

    '########################################## DELETE PHOTO #######################################################################################
    Private Sub btn_delete_photo_Click(sender As Object, e As EventArgs) Handles btn_delete_photo.Click
        For Each row As GridViewRow In GridView_open_gallery.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked = True Then
                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "update moveable_asset_photo_tbl set pic_status = 'deactive' where m_photo_id = @id"
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@id", CInt(row.Cells(1).Text))
                    con1.Open()
                    sqlCmd1.ExecuteNonQuery()
                    con1.Close()
                    bind_gridview_img()
                    displayImg()
                End If
            End If
        Next
    End Sub
    '########################################## END OF DELETE PHOTO #######################################################################################

    '############################################ PAGING FOR GRIDVIEW #################################################################
    Private Sub GridView_view_active_preview_assets_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_view_active_preview_assets.PageIndexChanging
        GridView_view_active_preview_assets.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
   
    '############################################ END OF PAGING FOR GRIDVIEW #################################################################


    Private Sub btn_close_gallery_Click(sender As Object, e As EventArgs) Handles btn_close_gallery.Click
        Panel_open_gallery.Visible = False
    End Sub
End Class