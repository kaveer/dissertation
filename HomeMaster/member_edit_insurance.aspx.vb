Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO


Public Class member_edit_insurance
    Inherits System.Web.UI.Page

    Shared random As New Random()

    Dim Vcompany_id As Integer
    Dim Vcompany_name As String
    Dim Vphone_fix As Integer
    Dim Vphone_mobile As Integer
    Dim Vcompany_website As String
    Dim Vcompany_descrip As String
    Dim Vcompany_street As String
    Dim Vcompany_town As String
    Dim Vcompany_country As String
    Dim VCompany_branchOf As String
    Dim Vcompany_email As String
    Dim Vcompany_fax As Integer

    Dim Vpolicy_id As Integer
    Dim Vpolicy_name As String
    Dim Vpolicy_description As String
    Dim Veffective_date As String
    Dim Vexpiry_date As String
    Dim Vinsurance_type_id As Integer
    Dim Vpolicy_num As String

    Dim Vcover_type_id As Integer
    Dim Vcover_id As Integer
    Dim Vcover_fees As Decimal
    Dim Vcover_doc As Decimal
    Dim Vcover_agent_com As Decimal
    Dim Vcover_detail_id As Integer
    Dim Vcover_reg_mark As String
    Dim Vcover_manufacturer As String
    Dim Vcover_serial_num As String
    Dim Vcover_insured_obj As String
    Dim Vcover_descrip As String
    Dim Vcover_benefiary As String
    Dim Vcover_amount As Decimal

    Dim Vrepay_due_date As String
    Dim Vamount_paid As Decimal
    Dim Vtotal_amount As Decimal
    Dim Vamount_remain As Decimal



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_select_insur()
        bind_insurance_type_ddl()
        bind_cover_type_ddl()

     
    End Sub

    '###################################### THEME SETUP ###############################################################
    Private Sub member_edit_insurance_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '####################################### END OF THEME SETUP #########################################################

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

    '############################################ GET INSURANCE/COVER TYPE ID ################################################
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
    '############################################ END OF GET INSURANCE/COVER TYPE ID ################################################

    '########################################## BIND DATA TO GRIDVIEW  ######################################
    Private Sub bind_to_gridview_select_insur()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select p.policy_id as [ref no] , policy_name as [Policy name] , company_name as [Company name] , insurance_type as [Insurance type] , type as [Cover type] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active' order by policy_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_insurance.DataSource = dt
        GridView_select_insurance.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_company_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select company_name as [Name], description , com_email as [Email] , phone_num as [Phone number] , branch_of as [Branch of] , mobile_num as [Mobile number] , company_fax as [Fax] , street , town , country  from insurance_company_tbl as c inner join insurance_policy_tbl as p  on p.company_id = c.company_id where policy_id = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_company_detail.DataSource = dt
        GridView_company_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_policy()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select policy_name as [name] , policy_num as [Policy number] , policy_description as [Description] , FORMAT(effective_date , 'dd/MM/yyyy')  as [Effective date] , FORMAT(expiry_date , 'dd/MM/yyyy')  as [Expiry date] from insurance_policy_tbl where policy_id = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_policy.DataSource = dt
        GridView_policy.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_cover()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select cov_fees as [Cover fees] , document_fees as [Document fees] , agent_commission as [commission] , type , reg_mark as [Mark], manufacturer ,serial_num as [Serial no] , insured_obj_prsn as [Insured] , cov_description as [Description] , beneficiary , amount  from insurance_coverage_tbl as c inner join coverage_type_tbl as t on t.cov_type_id = c.cov_type_id inner join cover_detail_tbl as d on c.cov_detail_id =d.cov_detail_id inner join insurance_policy_tbl as p on c.cover_id = p.cover_id where policy_id = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_cover_detail.DataSource = dt
        GridView_cover_detail.DataBind()
        con.Close()
        bind_gridview_preview_img()
    End Sub
    Private Sub bind_gridview_preview_img()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select picUrl from insurance_coverage_tbl as c inner join coverage_type_tbl as t on t.cov_type_id = c.cov_type_id inner join cover_detail_tbl as d on c.cov_detail_id =d.cov_detail_id inner join insurance_policy_tbl as p on c.cover_id = p.cover_id where policy_id = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        gridview_preview_img.DataSource = dt
        gridview_preview_img.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_repayment()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select payment_id as [ref], FORMAT(due_date , 'dd/MM/yyyy') as [Due date]  , total_amount as [Total amount] , amount_paid as [Amount paid], amount_remain as [Amount remaining] from insurance_pay_tbl as p inner join insurance_policy_tbl as i on i.policy_id = p.policy_id where i.policy_id  = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_repayment.DataSource = dt
        GridView_repayment.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_edit_cover_img()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select picUrl from insurance_coverage_tbl as c inner join coverage_type_tbl as t on t.cov_type_id = c.cov_type_id inner join cover_detail_tbl as d on c.cov_detail_id =d.cov_detail_id inner join insurance_policy_tbl as p on c.cover_id = p.cover_id where policy_id = @policyID and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_edit_cover_img.DataSource = dt
        GridView_edit_cover_img.DataBind()
        con.Close()
    End Sub

    
    '########################################## END OF BIND DATA TO GRIDVIEW  ######################################

    '############################################ MAKE GRIDVIEW SELECTABLE ################################################################
    Private Sub GridView_select_insurance_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_insurance.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_insurance, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_insurance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_insurance.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_insurance.Rows
            If row.RowIndex = GridView_select_insurance.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_gridview_company_detail()
        bind_gridview_policy()
        bind_gridview_cover()
        bind_gridview_repayment()


    End Sub

  
    Private Sub GridView_repayment_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_repayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_repayment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_repayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_repayment.SelectedIndexChanged
        For Each row As GridViewRow In GridView_repayment.Rows
            If row.RowIndex = GridView_repayment.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub gridview_preview_img_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gridview_preview_img.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gridview_preview_img, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub gridview_preview_img_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridview_preview_img.SelectedIndexChanged
        For Each row As GridViewRow In gridview_preview_img.Rows
            If row.RowIndex = gridview_preview_img.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        Panel_edit_cover_img.Visible = True
        bind_gridview_edit_cover_img()
    End Sub
    '############################################ END OF MAKE GRIDVIEW SELECTABLE ################################################################

    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub

    '############################################### TRANSFER FROM DB TO VARIABLES ###############################################################
    Private Sub get_all_info_all_tbl()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from insurance_policy_tbl as pol inner join insurance_company_tbl as com on com.company_id = pol.company_id inner join insurance_type_tbl as typ on typ.type_id = pol.type_id inner join insurance_coverage_tbl as cov on cov.cover_id = pol.cover_id inner join cover_detail_tbl as del on cov.cov_detail_id = del.cov_detail_id inner join coverage_type_tbl as cot on cot.cov_type_id = cov.cov_type_id where policy_id = @policyID and family_id = @familyID  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@policyID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vcompany_id = CInt(reader("company_id"))
            Vphone_fix = CInt(reader("phone_num"))
            Vphone_mobile = CInt(reader("mobile_num"))
            Vcompany_name = reader("company_name")
            Vcompany_website = reader("com_website")
            Vcompany_descrip = reader("description")
            Vcompany_street = reader("street")
            Vcompany_town = reader("town")
            Vcompany_country = reader("country")
            VCompany_branchOf = reader("branch_of")
            Vcompany_email = reader("com_email")
            Vcompany_fax = CInt(reader("company_fax"))

            Vpolicy_id = CInt(reader("policy_id"))
            Vpolicy_name = reader("policy_name")
            Vpolicy_description = reader("policy_description")
            Veffective_date = CStr(reader("effective_date"))
            Vexpiry_date = CStr(reader("expiry_date"))
            Vinsurance_type_id = CInt(reader("type_id"))
            Vpolicy_num = reader("policy_num")

            Vcover_id = CInt(reader("cover_id"))
            Vcover_fees = CDec(reader("cov_fees"))
            Vcover_doc = CDec(reader("document_fees"))
            Vcover_agent_com = CDec(reader("agent_commission"))
            Vcover_type_id = CInt(reader("cov_type_id"))

            Vcover_detail_id = CInt(reader("cov_detail_id"))
            Vcover_reg_mark = reader("reg_mark")
            Vcover_manufacturer = reader("manufacturer")
            Vcover_serial_num = reader("serial_num")
            Vcover_insured_obj = reader("insured_obj_prsn")
            Vcover_descrip = reader("cov_description")
            Vcover_benefiary = reader("beneficiary")
            Vcover_amount = reader("amount")
        End If
    End Sub
    Private Sub repay_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from insurance_pay_tbl where payment_id = @repay_id  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@repay_id", CInt(GridView_repayment.SelectedRow.Cells(0).Text))
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vrepay_due_date = CStr(reader("due_date"))
            Vamount_paid = CDec(reader("amount_paid"))
            Vtotal_amount = CDec(reader("total_amount"))
            Vamount_remain = CDec(reader("amount_remain"))
        End If
    End Sub
    '############################################### END OF TRANSFER FROM DB TO VARIABLES ###############################################################

    '############################################## UPDATE INSURANCE ############################################################################
    Private Sub btn_update_comapny_Click(sender As Object, e As EventArgs) Handles btn_update_comapny.Click
        If GridView_select_insurance.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select an insurance to update"
        ElseIf validation_country.IsValid = True And validation_email.IsValid = True And validation_fax.IsValid = True And validation_phn_fix.IsValid = True And validation_phn_ptb.IsValid = True And validation_town.IsValid = True Then
            get_all_info_all_tbl()
            If txtbx_company_phn_fix.Text = "" Then
                txtbx_company_phn_fix.Text = Vphone_fix
            End If
            If txtbx_company_phne_ptb.Text = "" Then
                txtbx_company_phne_ptb.Text = Vphone_mobile
            End If
            If txtbx_company_name.Text = "" Then
                txtbx_company_name.Text = Vcompany_name
            End If
            If txtbx_website.Text = "" Then
                txtbx_website.Text = Vcompany_website
            End If
            If txtbx_compnay_description.Text = "" Then
                txtbx_compnay_description.Text = Vcompany_descrip
            End If
            If txtbx_comapny_street.Text = "" Then
                txtbx_comapny_street.Text = Vcompany_street
            End If
            If txtbx_company_town.Text = "" Then
                txtbx_company_town.Text = Vcompany_town
            End If
            If txtbx_company_country.Text = "" Then
                txtbx_company_country.Text = Vcompany_country
            End If
            If txtbx_branch_of.Text = "" Then
                txtbx_branch_of.Text = VCompany_branchOf
            End If
            If txtbx_company_email.Text = "" Then
                txtbx_company_email.Text = Vcompany_email
            End If
            If txtbx_fax.Text = "" Then
                txtbx_fax.Text = Vcompany_fax
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update insurance_company_tbl set company_name = @name , phone_num = @fix , com_website = @web , description = @descrip ,mobile_num = @ptb ,street = @street ,town = @town , country =@country ,branch_of = @br ,com_email = @email , company_fax = @fax where company_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_company_name.Text)
            sqlCmd1.Parameters.AddWithValue("@fix", CInt(txtbx_company_phn_fix.Text))
            sqlCmd1.Parameters.AddWithValue("@web", txtbx_website.Text)
            sqlCmd1.Parameters.AddWithValue("@descrip", txtbx_compnay_description.Text)
            sqlCmd1.Parameters.AddWithValue("@ptb", CInt(txtbx_company_phne_ptb.Text))
            sqlCmd1.Parameters.AddWithValue("@street", txtbx_comapny_street.Text)
            sqlCmd1.Parameters.AddWithValue("@town", txtbx_company_town.Text)
            sqlCmd1.Parameters.AddWithValue("@country", txtbx_company_country.Text)
            sqlCmd1.Parameters.AddWithValue("@br", txtbx_branch_of.Text)
            sqlCmd1.Parameters.AddWithValue("@email", txtbx_company_email.Text)
            sqlCmd1.Parameters.AddWithValue("@fax", CInt(txtbx_fax.Text))
            sqlCmd1.Parameters.AddWithValue("@id", Vcompany_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "Company details updated"
            bind_gridview_company_detail()
        End If
    End Sub
    Private Sub btn_update_policy_Click(sender As Object, e As EventArgs) Handles btn_update_policy.Click
        If GridView_select_insurance.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select insurance to update"
        ElseIf validation_effec_date.IsValid = True And validation_expiry_date.IsValid = True Then
            get_all_info_all_tbl()
            If Not ddl_insurance_type.SelectedItem.Text = "--Select type--" Then
                check_insurance_type()
            End If
            If txtbx_policy_name.Text = "" Then
                txtbx_policy_name.Text = Vpolicy_name
            End If
            If txtxbx_policy_description.Text = "" Then
                txtxbx_policy_description.Text = Vpolicy_description
            End If
            If txtbx_policy_effec_date.Text = "" Then
                txtbx_policy_effec_date.Text = Veffective_date
            End If
            If txtbx_policy_expiry_date.Text = "" Then
                txtbx_policy_expiry_date.Text = Vexpiry_date
            End If
            If txtbx_policy_number.Text = "" Then
                txtbx_policy_number.Text = Vpolicy_num
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " UPDATE insurance_policy_tbl set policy_name = @name , policy_description = @descrip , effective_date = convert(date,@effec,103) , expiry_date = convert(date,@exp,103) , type_id = @type , policy_num = @num where policy_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_policy_name.Text)
            sqlCmd1.Parameters.AddWithValue("@descrip", txtxbx_policy_description.Text)
            sqlCmd1.Parameters.AddWithValue("@effec", txtbx_policy_effec_date.Text)
            sqlCmd1.Parameters.AddWithValue("@exp", txtbx_policy_expiry_date.Text)
            sqlCmd1.Parameters.AddWithValue("@type", Vinsurance_type_id)
            sqlCmd1.Parameters.AddWithValue("@num", txtbx_policy_number.Text)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(Vpolicy_id))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = "policy details updated"
            bind_gridview_policy()
        End If
    End Sub
    Private Sub btn_add_insurance_type_Click(sender As Object, e As EventArgs) Handles btn_add_insurance_type.Click
        ddl_insurance_type.SelectedItem.Text = txtbx_add_insurance_type.Text
    End Sub
    Private Sub btn_add_cover_type_Click(sender As Object, e As EventArgs) Handles btn_add_cover_type.Click
        If btn_add_cover_type.Text = "" Then
            lbl_validation_view3.Text = "enter cover type"
        Else
            ddl_cover_type.SelectedItem.Text = txtbx_add_cover_type.Text
        End If
    End Sub
    Private Sub btn_update_cover_Click(sender As Object, e As EventArgs) Handles btn_update_cover.Click
        If GridView_select_insurance.SelectedIndex = -1 Then
            lbl_validation_view3.Text = "select insurance to update"
        ElseIf validation_amount_beneficiary.IsValid = True And validation_cover_fees.IsValid = True And validation_doc_fees.IsValid = True And validation_agent_com.IsValid = True Then
            get_all_info_all_tbl()
            If Not ddl_cover_type.SelectedItem.Text = "--Select type--" Then
                check_cover_type()
            End If
            If txtbx_cover_descri.Text = "" Then
                txtbx_cover_descri.Text = Vcover_descrip
            End If
            If txtbx_insured_obj_person.Text = "" Then
                txtbx_insured_obj_person.Text = Vcover_insured_obj
            End If
            If txtbx_beneficiary.Text = "" Then
                txtbx_beneficiary.Text = Vcover_benefiary
            End If
            If txtbx_amount_beneficiary.Text = "" Then
                txtbx_amount_beneficiary.Text = CStr(Vcover_amount)
            End If
            If txtbx_cover_fees.Text = "" Then
                txtbx_cover_fees.Text = CStr(Vcover_fees)
            End If
            If txtbx_doc_fees.Text = "" Then
                txtbx_doc_fees.Text = CStr(Vcover_doc)
            End If
            If txtbx_agent_commission.Text = "" Then
                txtbx_agent_commission.Text = CStr(Vcover_agent_com)
            End If
            If txtbx_reg_num.Text = "" Then
                txtbx_reg_num.Text = Vcover_reg_mark
            End If
            If txtbx_manufacturer.Text = "" Then
                txtbx_manufacturer.Text = Vcover_manufacturer
            End If
            If txtbx_serial_num.Text = "" Then
                txtbx_serial_num.Text = Vcover_serial_num
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update insurance_coverage_tbl set cov_fees = @covfee , document_fees = @docfee , agent_commission = @agent , cov_type_id = @type where cover_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@covfee", CDec(txtbx_cover_fees.Text))
            sqlCmd1.Parameters.AddWithValue("@docfee", CDec(txtbx_doc_fees.Text))
            sqlCmd1.Parameters.AddWithValue("@agent", CDec(txtbx_agent_commission.Text))
            sqlCmd1.Parameters.AddWithValue("@type", Vcover_type_id)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(Vcover_id))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            update_cover_detail()
        End If
    End Sub
    Private Sub update_cover_detail()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = " update cover_detail_tbl set reg_mark = @reg ,manufacturer = @manu , serial_num = @serial , insured_obj_prsn = @insured ,cov_description = @des , beneficiary = @bene , amount = @amt where cov_detail_id  = @id "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@reg", txtbx_reg_num.Text)
        sqlCmd1.Parameters.AddWithValue("@manu", txtbx_manufacturer.Text)
        sqlCmd1.Parameters.AddWithValue("@serial", txtbx_serial_num.Text)
        sqlCmd1.Parameters.AddWithValue("@insured", txtbx_insured_obj_person.Text)
        sqlCmd1.Parameters.AddWithValue("@des", txtbx_cover_descri.Text)
        sqlCmd1.Parameters.AddWithValue("@bene", txtbx_beneficiary.Text)
        sqlCmd1.Parameters.AddWithValue("@amt", CDec(txtbx_amount_beneficiary.Text))
        sqlCmd1.Parameters.AddWithValue("@id", CInt(Vcover_detail_id))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        lbl_validation_view3.Text = "cover updated"
        bind_gridview_cover()
    End Sub
    Private Sub btn_update_repayment_Click(sender As Object, e As EventArgs) Handles btn_update_repayment.Click
        If GridView_repayment.SelectedIndex = -1 Then
            lbl_validation_view4.Text = "select a repayment to update"
        ElseIf validation_due_date.IsValid = True And validation_total_amount.IsValid = True And validation_amount_paid.IsValid = True And validation_amount_remain.IsValid = True Then
            repay_detail()
            If txtbx_due_date.Text = "" Then
                txtbx_due_date.Text = Vrepay_due_date
            End If
            If txtbx_total_amount.Text = "" Then
                txtbx_total_amount.Text = Vtotal_amount
            End If
            If txtbx_amount_paid.Text = "" Then
                txtbx_amount_paid.Text = Vamount_paid
            End If
            If txtbx_amount_remain.Text = "" Then
                txtbx_amount_remain.Text = Vamount_remain
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update insurance_pay_tbl set due_date = convert(date, @dateD ,103)  , amount_paid =  @paid ,total_amount = @ttl ,amount_remain = @remain  where payment_id = @ID "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@dateD", txtbx_due_date.Text)
            sqlCmd1.Parameters.AddWithValue("@paid", CDec(txtbx_amount_paid.Text))
            sqlCmd1.Parameters.AddWithValue("@ttl", CDec(txtbx_total_amount.Text))
            sqlCmd1.Parameters.AddWithValue("@remain", CDec(txtbx_amount_remain.Text))
            sqlCmd1.Parameters.AddWithValue("@ID", CInt(GridView_repayment.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view4.Text = "repayment updated"
            GridView_repayment.SelectedIndex = -1
            bind_gridview_repayment()
        End If
    End Sub
    '############################################## END OG UPDATE INSURANCE ############################################################################

    '############################################## UPDATE/DELETE COVER IMAGE ONLY ###################################################################
    Private Sub btn_upload_cover_img_Click(sender As Object, e As EventArgs) Handles btn_upload_cover_img.Click
        If rexp.IsValid = True Then
            Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
            If FileUpload_picture.HasFile Then

                Dim fileName As String = FileUpload_picture.PostedFile.FileName
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()
                Dim extensionsAllowed As String() = {".jpg", ".png"}
                If extensionsAllowed.Contains(fileExtension) Then
                    get_all_info_all_tbl()
                    Dim filePath As String = Server.MapPath("~/UploadImages/insurancePic/" + genrate_num1 + "_" + fileName)
                    FileUpload_picture.PostedFile.SaveAs(filePath)

                    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql1 = "update cover_detail_tbl set picUrl = @Path where cov_detail_id = @id "
                    Dim sqlCmd1 As New SqlCommand(sql1, con1)
                    sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/insurancePic/" + genrate_num1 + "_" + fileName)
                    sqlCmd1.Parameters.AddWithValue("@id", Vcover_detail_id)
                    sqlCmd1.CommandType = CommandType.Text
                    lbl_validation_upload.Text = "File successfully uploaded and save insurance"
                    Try
                        con1.Open()
                        sqlCmd1.ExecuteNonQuery()
                    Catch ex As Exception
                        lbl_validation_upload.Text = "Unable to insert file data in database"
                    Finally
                        con1.Close()
                        bind_gridview_preview_img()
                        bind_gridview_edit_cover_img()
                        Panel_edit_cover_img.Visible = False
                    End Try
                    Try
                    Catch ex As Exception
                        lbl_validation_upload.Text = "Unable to upload file"
                    End Try
                Else
                    lbl_validation_upload.Text = "File extension " + fileExtension + " is not allowed"
                End If
            ElseIf FileUpload_picture.HasFile = False Then
                get_all_info_all_tbl()
                lbl_validation_upload.Text = "no image to upload"
            End If
        End If
    End Sub
    '############################################## END OF UPDATE/DELETE COVER IMAGE ONLY ###################################################################

    Private Sub btn_close_panel_view_img_Click(sender As Object, e As EventArgs) Handles btn_close_panel_view_img.Click
        Panel_edit_cover_img.Visible = False
    End Sub

    '################################################ PAGING IN GRIDVIEW ################################################################################
    Private Sub GridView_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_repayment.PageIndexChanging
        GridView_repayment.PageIndex = e.NewPageIndex
        Me.bind_gridview_repayment()
    End Sub
    Private Sub GridView_select_insurance_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_insurance.PageIndexChanging
        GridView_select_insurance.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_select_insur()
    End Sub
    '################################################ END OF PAGING IN GRIDVIEW ################################################################################
End Class


     

  