Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_add_repay_insur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_select_insur()
    End Sub

    '############################################# THEME SETUP ############################################################
    Private Sub member_add_repay_insur_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ############################################################

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
    End Sub
    '############################################## END OF MAKE GRIDVIEW SELECTABLE ##############################################################

    '########################################## CALCULATION REMAIN AMOUNT ####################################################################
    Private Sub txtbx_amount_paid_TextChanged(sender As Object, e As EventArgs) Handles txtbx_amount_paid.TextChanged
        If txtbx_total_amount.Text = "" Then
            txtbx_total_amount.Text = 0
        ElseIf txtbx_amount_paid.Text = "" Then
            txtbx_amount_paid.Text = 0
        End If
        txtbx_amount_remain.Text = CStr(CDec(txtbx_total_amount.Text) - CDec(txtbx_amount_paid.Text))
    End Sub
    '########################################## END OF CALCULATION REMAIN AMOUNT ####################################################################

    '########################################### ADD INSURANCE REPAYMENT #######################################################
    Private Sub btn_save_repayment_Click(sender As Object, e As EventArgs) Handles btn_save_repayment.Click
        If GridView_select_insurance.SelectedIndex = -1 Then
            lbl_validation.Text = "select insurance to add repayment "
        ElseIf txtbx_total_amount.Text = "" Then
            lbl_validation.Text = "enter total amount"
        ElseIf txtbx_amount_paid.Text = "" Then
            lbl_validation.Text = "enter paid amount "

        ElseIf validation_due_date.IsValid = True And validation_total_amount.IsValid = True And validation_amount_paid.IsValid = True And validation_amount_remain.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into insurance_pay_tbl(policy_id , inur_pay_status , due_date , amount_paid , total_amount ,amount_remain , insur_expense_status , insur_repay_status ) values (@policy_id , 'paid' , convert(date,@dueDate,103) , @amtpid , @ttlamt , @amtremain , 'notadded' , 'active' )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@policy_id", CInt(GridView_select_insurance.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@dueDate", txtbx_due_date.Text)
            sqlCmd1.Parameters.AddWithValue("@amtpid", txtbx_amount_paid.Text)
            sqlCmd1.Parameters.AddWithValue("@ttlamt", txtbx_total_amount.Text)
            sqlCmd1.Parameters.AddWithValue("@amtremain", txtbx_amount_remain.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation.Text = "repayment added"
            GridView_select_insurance.SelectedIndex = -1
        End If
    End Sub
    '########################################### END OF ADD INSURANCE REPAYMENT #######################################################

    '################################################ PAGING FOR GRIDVIEW #####################################################################
    Private Sub GridView_select_insurance_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_insurance.PageIndexChanging
        GridView_select_insurance.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_select_insur()
    End Sub
    '################################################ PAGING FOR GRIDVIEW #####################################################################

    Private Sub btn_view_repayment_Click(sender As Object, e As EventArgs) Handles btn_view_repayment.Click
        Response.Redirect("./member_view_repayment.aspx")
    End Sub
End Class