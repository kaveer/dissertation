Imports System.Data.SqlClient
Imports System.IO

Public Class member_add_insurance
    Inherits System.Web.UI.Page

    Shared random As New Random()
    Dim Vinsurance_type_id As Integer
    Dim Vcover_type_id As Integer
    Dim Vcover_detail_id As Integer
    Dim Vcompany_id As Integer
    Dim Vcover_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_insurance_type_ddl()
        bind_cover_type_ddl()
    End Sub

    '######################################### THEME SETUP ##########################################################
    Private Sub member_add_insurance_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '######################################### END OF THEME SETUP ##########################################################

    '######################################### NAVIGATION ##########################################################
    Private Sub btn_next_to_policy_Click(sender As Object, e As EventArgs) Handles btn_next_to_policy.Click
        If txtbx_company_name.Text = "" Then
            lbl_validation_view1.Text = "Enter company name"
        ElseIf validation_email.IsValid = True And validation_fax.IsValid = True And validation_phn_fix.IsValid = True And validation_phn_ptb.IsValid = True And validation_town.IsValid = True And validation_country.IsValid = True Then
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub
    Private Sub btn_prev_to_company_Click(sender As Object, e As EventArgs) Handles btn_prev_to_company.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub btn_next_to_cover_Click(sender As Object, e As EventArgs) Handles btn_next_to_cover.Click
        If ddl_insurance_type.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "Select insurance type"

        ElseIf ddl_insurance_type.SelectedItem.Text = "--Select type--" Then
            lbl_validation_view2.Text = "Select insurance type"
        ElseIf txtbx_policy_name.Text = "" Then
            lbl_validation_view2.Text = "Enter policy name"
        ElseIf txtbx_policy_number.Text = "" Then
            lbl_validation_view2.Text = "Enter policy number"
        ElseIf ddl_insurance_type.SelectedItem.Text = "auto insurance" And validation_effec_date.IsValid = True And validation_expiry_date.IsValid = True Then
            MultiView1.ActiveViewIndex = 2
            Panel_vehicle_cover.Visible = True
        ElseIf validation_effec_date.IsValid = True And validation_expiry_date.IsValid = True Then
            MultiView1.ActiveViewIndex = 2
            Panel_vehicle_cover.Visible = False
        Else
            Panel_vehicle_cover.Visible = False
        End If
    End Sub
    Private Sub btn_prev_policy_Click(sender As Object, e As EventArgs) Handles btn_prev_policy.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    '######################################### END OF NAVIGATION ######################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_insurance_type_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from insurance_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_insurance_type.DataSource = ds
                ddl_insurance_type.DataTextField = "insurance_type"
                ddl_insurance_type.DataValueField = "insurance_type"
                ddl_insurance_type.DataBind()
                ddl_insurance_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_cover_type_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from coverage_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_cover_type.DataSource = ds
                ddl_cover_type.DataTextField = "type"
                ddl_cover_type.DataValueField = "type"
                ddl_cover_type.DataBind()
                ddl_cover_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################

    '########################################## SAVE INSURANCE DETAIL ###########################################################
    Private Sub btn_save_insurance_Click(sender As Object, e As EventArgs) Handles btn_save_insurance.Click
        If ddl_cover_type.SelectedItem.Text = "--Select type--" Then
            lbl_validation_view3.Text = "Select cover type"
        ElseIf txtbx_insured_obj_person.Text = "" Then
            lbl_validation_view3.Text = "enter insured person or object"
        ElseIf txtbx_beneficiary.Text = "" Then
            lbl_validation_view3.Text = "enter beneficiary"
        ElseIf txtbx_cover_fees.Text = "" Then
            lbl_validation_view3.Text = "enter cover fees"
        ElseIf txtbx_amount_beneficiary.Text = "" Then
            lbl_validation_view3.Text = "enter amount"
        ElseIf validation_cover_fees.IsValid = True And validation_doc_fees.IsValid = True And validation_agent_com.IsValid = True And validation_upload_pic.IsValid = True And validation_amount_beneficiary.IsValid = True Then
            check_insurance_type()
            check_cover_type()
            insert_cover_detail()
            insert_company_detail()
            insert_insurance_cover()
            insert_policy_tbl()
        End If
    End Sub
    Private Sub check_insurance_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from insurance_type_tbl where insurance_type = LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_insurance_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vinsurance_type_id = reader2("type_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into insurance_type_tbl(insurance_type) values (LOWER(@type))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@type", ddl_insurance_type.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_insurance_type_id()
        End If
    End Sub
    Private Sub get_insurance_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from insurance_type_tbl where insurance_type = LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_insurance_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vinsurance_type_id = reader2("type_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_cover_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from coverage_type_tbl where type =LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_cover_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcover_type_id = reader2("cov_type_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into coverage_type_tbl(type) values (LOWER(@type))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@type", ddl_cover_type.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_cover_type_id()
        End If
    End Sub
    Private Sub get_cover_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from coverage_type_tbl where type =LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_cover_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcover_type_id = reader2("cov_type_id")
            con2.Close()
        End If

    End Sub
    '########################################## END OF SAVE INSURANCE DETAIL ###########################################################

    '########################################## INSERT COVER DETAIL WITH PICTURE ###########################################################
    Private Sub insert_cover_detail()
        Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
        If FileUpload_picture.HasFile Then
            Dim fileName As String = FileUpload_picture.PostedFile.FileName
            Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
            Dim extensionsAllowed As String() = {".jpg", ".png"}
            If extensionsAllowed.Contains(fileExtension) Then
                Dim filePath As String = Server.MapPath("~/UploadImages/insurancePic/" + genrate_num1 + "_" + fileName)
                FileUpload_picture.PostedFile.SaveAs(filePath)
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "insert into cover_detail_tbl(reg_mark , manufacturer , serial_num , insured_obj_prsn , cov_description , beneficiary , amount , picUrl) values (@reg_no , LOWER(@manu) , @serial , '@tochange' , @descrip , LOWER(@benefi) , @amt , @Path )"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/insurancePic/" + genrate_num1 + "_" + fileName)
                sqlCmd1.Parameters.AddWithValue("@reg_no", txtbx_reg_num.Text)
                sqlCmd1.Parameters.AddWithValue("@manu", txtbx_manufacturer.Text)
                sqlCmd1.Parameters.AddWithValue("@serial", txtbx_serial_num.Text)
                sqlCmd1.Parameters.AddWithValue("@descrip", txtbx_cover_descri.Text)
                sqlCmd1.Parameters.AddWithValue("@benefi", txtbx_beneficiary.Text)
                sqlCmd1.Parameters.AddWithValue("@amt", CDec(txtbx_amount_beneficiary.Text))
                sqlCmd1.CommandType = CommandType.Text
                lbl_validation_view3.Text = "File successfully uploaded and save insurance"
                Try
                    con1.Open()
                    sqlCmd1.ExecuteNonQuery()
                Catch ex As Exception
                    lbl_validation_view3.Text = "Unable to insert file data in database"
                Finally
                    con1.Close()
                    get_detail_cover_id()
                    displayImg()
                End Try
                Try
                Catch ex As Exception
                    lbl_validation_view3.Text = "Unable to upload file"
                End Try
            Else
                lbl_validation_view3.Text = "File extension " + fileExtension + " is not allowed"
            End If
        ElseIf FileUpload_picture.HasFile = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into cover_detail_tbl(reg_mark , manufacturer , serial_num , insured_obj_prsn , cov_description , beneficiary , amount ) values (@reg_no , LOWER(@manu) , @serial , '@tochange' , @descrip , LOWER(@benefi) , @amt  )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@reg_no", txtbx_reg_num.Text)
            sqlCmd1.Parameters.AddWithValue("@manu", txtbx_manufacturer.Text)
            sqlCmd1.Parameters.AddWithValue("@serial", txtbx_serial_num.Text)
            sqlCmd1.Parameters.AddWithValue("@descrip", txtbx_cover_descri.Text)
            sqlCmd1.Parameters.AddWithValue("@benefi", txtbx_beneficiary.Text)
            sqlCmd1.Parameters.AddWithValue("@amt", CDec(txtbx_amount_beneficiary.Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view3.Text = "insurance data save without picture"
            get_detail_cover_id()
        End If
    End Sub
    Private Sub get_detail_cover_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from cover_detail_tbl where insured_obj_prsn = '@tochange'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcover_detail_id = reader2("cov_detail_id")
            con2.Close()
        End If
        change_back()
    End Sub
    Private Sub change_back()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update cover_detail_tbl set insured_obj_prsn = LOWER(@insured) where cov_detail_id = @covID  "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@insured", txtbx_insured_obj_person.Text)
        sqlCmd1.Parameters.AddWithValue("@covID", Vcover_detail_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        'Label1.Text = CStr(Vinsurance_type_id)
        'Label2.Text = CStr(Vcover_type_id)
        'Label3.Text = CStr(Vcover_detail_id)
    End Sub
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "SELECT picUrl FROM cover_detail_tbl where cov_detail_id = @ID"
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", Vcover_detail_id)
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_diaplay_pic.DataSource = myReader
        Repeater_diaplay_pic.DataBind()
    End Sub
    '########################################## END OF INSERT COVER DETAIL WITH PICTURE #####################################################

    '############################################# INSERT INTO COMPANY TABLE ##############################################################
    Private Sub insert_company_detail()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into insurance_company_tbl(company_name , phone_num , com_website , description , mobile_num , street , town , country , branch_of , com_email , company_fax) values ( '@tochange' , @phnenum , @website , @descrip , @ptb , LOWER(@street) , LOWER(@town) , LOWER(@country) , LOWER(@branch) , @mail , @fax)"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@phnenum", txtbx_company_phn_fix.Text)
        sqlCmd1.Parameters.AddWithValue("@website", txtbx_website.Text)
        sqlCmd1.Parameters.AddWithValue("@descrip", txtbx_compnay_description.Text)
        sqlCmd1.Parameters.AddWithValue("@ptb", txtbx_company_phne_ptb.Text)
        sqlCmd1.Parameters.AddWithValue("@street", txtbx_comapny_street.Text)
        sqlCmd1.Parameters.AddWithValue("@town", txtbx_company_town.Text)
        sqlCmd1.Parameters.AddWithValue("@country", txtbx_company_country.Text)
        sqlCmd1.Parameters.AddWithValue("@branch", txtbx_branch_of.Text)
        sqlCmd1.Parameters.AddWithValue("@mail", txtbx_company_email.Text)
        sqlCmd1.Parameters.AddWithValue("@fax", txtbx_fax.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        get_company_id()
    End Sub
    Private Sub get_company_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from insurance_company_tbl where company_name = '@tochange'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcompany_id = reader2("company_id")
            con2.Close()
            change_back_company_name()
        End If
    End Sub
    Private Sub change_back_company_name()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update insurance_company_tbl set company_name = @comName where company_id = @comID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@comName", txtbx_company_name.Text)
        sqlCmd1.Parameters.AddWithValue("@comID", Vcompany_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '############################################# END OF INSERT INTO COMPANY TABLE ##############################################################

    '############################################### INSERT INTO INSURANCE COVERAGE TABLE #########################################
    Private Sub insert_insurance_cover()
        If txtbx_doc_fees.Text = "" Then
            txtbx_doc_fees.Text = 0
        End If
        If txtbx_agent_commission.Text = "" Then
            txtbx_agent_commission.Text = 0
        End If
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into insurance_coverage_tbl(cov_status , cov_fees , document_fees , agent_commission , cov_type_id , cov_detail_id) values ('@tochange' , @covfees , @docfees , @agent , @covtype_ID , @cov_detail_id )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@covfees", txtbx_cover_fees.Text)
        sqlCmd1.Parameters.AddWithValue("@docfees", txtbx_doc_fees.Text)
        sqlCmd1.Parameters.AddWithValue("@agent", txtbx_agent_commission.Text)
        sqlCmd1.Parameters.AddWithValue("@covtype_ID", Vcover_type_id)
        sqlCmd1.Parameters.AddWithValue("@cov_detail_id", Vcover_detail_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        get_cover_id()
    End Sub
    Private Sub get_cover_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from insurance_coverage_tbl where cov_status = '@tochange'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcover_id = reader2("cover_id")
            con2.Close()
            change_back_status()
        End If
    End Sub
    Private Sub change_back_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update insurance_coverage_tbl set cov_status = 'active' where cover_id = @coverID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@coverID", Vcover_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '############################################### END OF INSERT INTO INSURANCE COVERAGE TABLE #########################################

    '################################################## INSERT INTO INSURANCE POLICY TABLE ################################################
    Private Sub insert_policy_tbl()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into insurance_policy_tbl(family_id , policy_status , policy_name , policy_description , effective_date , expiry_date , company_id , type_id , policy_num , cover_id) values (@fam_ID , 'active' , LOWER(@name) , @des , convert(date,@effDate,103) , convert(date,@expDate,103) , @comp_id , @typeID , @policyNUM , @cover_id )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@fam_ID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@name", txtbx_policy_name.Text)
        sqlCmd1.Parameters.AddWithValue("@des", txtxbx_policy_description.Text)
        sqlCmd1.Parameters.AddWithValue("@effDate", txtbx_policy_effec_date.Text)
        sqlCmd1.Parameters.AddWithValue("@expDate", txtbx_policy_expiry_date.Text)
        sqlCmd1.Parameters.AddWithValue("@comp_id", Vcompany_id)
        sqlCmd1.Parameters.AddWithValue("@typeID", Vinsurance_type_id)
        sqlCmd1.Parameters.AddWithValue("@policyNUM", txtbx_policy_number.Text)
        sqlCmd1.Parameters.AddWithValue("@cover_id", Vcover_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################## END OF INSERT INTO INSURANCE POLICY TABLE ################################################

    Private Sub btn_add_insurance_type_Click(sender As Object, e As EventArgs) Handles btn_add_insurance_type.Click
        If btn_add_insurance_type.Text = "" Then
            lbl_validation_view2.Text = "enter new type to add"
        Else
            ddl_insurance_type.SelectedItem.Text = txtbx_add_insurance_type.Text
        End If
    End Sub
    Private Sub btn_add_cover_type_Click(sender As Object, e As EventArgs) Handles btn_add_cover_type.Click
        If btn_add_cover_type.Text = "" Then
            lbl_validation_view3.Text = "enter cover type"
        Else
            ddl_cover_type.SelectedItem.Text = txtbx_add_cover_type.Text
        End If
    End Sub
End Class