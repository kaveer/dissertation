Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_view_insurance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_select_insur()
        bind_gridview_deactive_insurance()
    End Sub

    '###################################### THEME SETUP ##################################################################
    Private Sub family_view_insurance_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '###################################### END OF THEME SETUP ##################################################################

    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub

    '######################################### BIND DATA TO GRIDVIEW/DETAILVIEW ##########################################################
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
    Private Sub bind_detailview_company()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select company_name as [company name] , c.description as [Description] ,phone_num as [Phone number] , mobile_num as [Mobile number] , company_fax as [Fax] , street as [Street] , town as [Town] , country as [Country] , branch_of as [Branch of] , com_website as [Website] , com_email as [Email] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active' and p.policy_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_company_detail.DataSource = dt
        DetailsView_company_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_detailview_policy()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select policy_num as [policy number] , policy_name as [Name] , policy_description as [Description] , insurance_type as [Insurance type] ,  FORMAT(effective_date , 'dd/MM/yyyy')  as [Effective date] , FORMAT(expiry_date , 'dd/MM/yyyy')  as [Expiry date] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active' and p.policy_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_policy.DataSource = dt
        DetailsView_policy.DataBind()
        con.Close()
    End Sub
    Private Sub bind_detail_cover()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select type as [cover type] , cd.cov_description as [Description] , reg_mark as [ Registration marl] , manufacturer , serial_num as [ Serial number] , insured_obj_prsn as [Insured] , beneficiary , amount , cov_fees as [Cover fees] , document_fees as [Document fees] , agent_commission as [Agent commission] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active' and p.policy_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_cover.DataSource = dt
        DetailsView_cover.DataBind()
        con.Close()
        bind_pic()
    End Sub
    Private Sub bind_pic()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select picUrl from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active' and p.policy_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Repeater_image.DataSource = dt
        Repeater_image.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_deactive_insurance()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select p.policy_id as [ref no] , policy_name as [Policy name] , company_name as [Company name] , insurance_type as [Insurance type] , type as [Cover type] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'deactive' order by policy_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactive_insurance.DataSource = dt
        GridView_deactive_insurance.DataBind()
        con.Close()
    End Sub

    
    '######################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ##########################################################

    '########################################## MAKE GRIDVIEW SELECTABLE ##############################################################################
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
        bind_detailview_company()
        bind_detailview_policy()
        bind_detail_cover()
    End Sub

  
    Private Sub GridView_deactive_insurance_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_deactive_insurance.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_deactive_insurance, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_deactive_insurance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_deactive_insurance.SelectedIndexChanged
        For Each row As GridViewRow In GridView_deactive_insurance.Rows
            If row.RowIndex = GridView_deactive_insurance.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '########################################## END OF MAKE GRIDVIEW SELECTABLE ##############################################################################

    '################################################### ACTIVATE AND DEACTIVATE INSURANCE #################################################################
    Private Sub btn_remove_insurance_Click(sender As Object, e As EventArgs) Handles btn_remove_insurance.Click
        If GridView_select_insurance.SelectedIndex = -1 Then
            lbl_validaiton.Text = "select insurace to deactivate"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update insurance_policy_tbl set policy_status = 'deactive' where policy_id = @policy_id and family_id = @fami_ID "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@policy_id", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@fami_ID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_select_insur()
            bind_gridview_deactive_insurance()
            'bind_gridview_deactive_insurance()
            'bind_detailview_company()
            'bind_detailview_policy()
            'bind_detail_cover()
            'bind_pic()
            GridView_select_insurance.SelectedIndex = -1
        End If
    End Sub
    Private Sub btn_reactive_Click(sender As Object, e As EventArgs) Handles btn_reactive.Click
        If GridView_deactive_insurance.SelectedIndex = -1 Then
            lbl_validation2.Text = "Select insurance to reactivate"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update insurance_policy_tbl set policy_status = 'active' where policy_id = @policy_id and family_id = @fami_ID "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@policy_id", CInt(GridView_deactive_insurance.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@fami_ID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_select_insur()
            bind_gridview_deactive_insurance()
            GridView_deactive_insurance.SelectedIndex = -1
        End If
    End Sub
    '################################################### END OF ACTIVATE AND DEACTIVATE INSURANCE #################################################################

    Private Sub btn_edit_insurance_Click(sender As Object, e As EventArgs) Handles btn_edit_insurance.Click
        Response.Redirect("./family_edit_insurance.aspx")
    End Sub

    '######################################################### PAGING IN GRIDVIEW ##########################################################################
    Private Sub GridView_select_insurance_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_insurance.PageIndexChanging
        GridView_select_insurance.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_select_insur()
    End Sub
    Private Sub GridView_deactive_insurance_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_deactive_insurance.PageIndexChanging
        GridView_deactive_insurance.PageIndex = e.NewPageIndex
        Me.bind_gridview_deactive_insurance()
    End Sub
    '######################################################### END OF PAGING IN GRIDVIEW ##########################################################################
End Class