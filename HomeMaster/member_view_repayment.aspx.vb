Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_view_repayment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_select_insur()
    End Sub

    '############################################# THEME SETUP #########################################################
    Private Sub member_view_repayment_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP #########################################################

    '############################################## BIND DATA TO GRIDVIEW ################################################### 
    Private Sub bind_to_gridview_select_insur()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select p.policy_id as [ref no] , policy_name as [policy name] , company_name as [company name] , insurance_type as [insurance type] , type as [cover type] from insurance_policy_tbl as p inner join insurance_type_tbl as t on p.type_id = t.type_id inner join insurance_company_tbl as c on p.company_id = c.company_id inner join insurance_coverage_tbl as cov on cov.cover_id = p.cover_id inner join coverage_type_tbl as ct on ct.cov_type_id = cov.cov_type_id inner join cover_detail_tbl as cd on cd.cov_detail_id = cov.cov_detail_id where family_id = @familyID and policy_status = 'active' and cov_status = 'active'"
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
    Private Sub bind_gridview_repay_histry()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select FORMAT(due_date , 'dd/MM/yyyy')   as [Due date] , total_amount as [Total amount] , amount_paid as [amount paid] ,amount_remain as [amount remain] from insurance_pay_tbl where policy_id = @policy_id and insur_repay_status='active'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@policy_id", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_repay_history.DataSource = dt
        GridView_repay_history.DataBind()
        con.Close()
    End Sub
    '############################################## END OF BIND DATA TO GRIDVIEW ################################################### 

    '############################################## MAKE GRIDVIEW SELECTABLE ##############################################################
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
        bind_gridview_repay_histry()
    End Sub
    '############################################## END OF MAKE GRIDVIEW SELECTABLE ##############################################################

    '############################################## PAGING IN GRIDVIEW ###########################################################################
    Private Sub GridView_select_insurance_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_insurance.PageIndexChanging
        GridView_select_insurance.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_select_insur()
    End Sub
    Private Sub GridView_repay_history_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_repay_history.PageIndexChanging
        GridView_repay_history.PageIndex = e.NewPageIndex
        Me.bind_gridview_repay_histry()
    End Sub
    '############################################## END OF PAGING IN GRIDVIEW ###########################################################################
End Class