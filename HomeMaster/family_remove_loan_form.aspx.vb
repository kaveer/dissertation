Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_remove_loan_form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_gridview_select_loan()
        bind_data_to_gridview_deactivated_loan()
    End Sub

    '###################################################### THEME SETUP ##################################################################
    Private Sub family_remove_loan_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '###################################################### END OF THEME SETUP ##################################################################

    '##################################### BIND DATA TO GRIDVIEW #################################################################
    Private Sub bind_data_gridview_select_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select transaction_id as [ref no] ,loan_name as [Loan name] ,type as [Loan type], amount_given as [Total amount] , interest_rate as [Interest rate] , FORMAT(date_taken , 'dd/MM/yyyy')  as [Date taken] , loan_status as [Loan status] , name as [Lender name] , lender_type as [Lender type] from loan_tbl as l inner join loan_type_tbl as lt on lt.loan_type_id = l.loan_type_id inner join lender_tbl as len on len.lender_id = l.lender_id inner join lender_type_tbl as lent on len.type_id = lent.type_id where loan_status = 'active' and family_id = @familyID order by transaction_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_loan.DataSource = dt
        GridView_select_loan.DataBind()
        con.Close()
    End Sub
    Private Sub bind_data_to_gridview_deactivated_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select transaction_id as [ref no] ,loan_name as [Loan name] ,type as [loan type], amount_given as [Total amount] , interest_rate as [Interest rate] , FORMAT(date_taken , 'dd/MM/yyyy')  as [Date taken], loan_status as [Loan status] , name as [Lender name] , lender_type as [Lender type] from loan_tbl as l inner join loan_type_tbl as lt on lt.loan_type_id = l.loan_type_id inner join lender_tbl as len on len.lender_id = l.lender_id inner join lender_type_tbl as lent on len.type_id = lent.type_id where loan_status = 'deactive' and family_id = @familyID  order by transaction_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactivated_loan.DataSource = dt
        GridView_deactivated_loan.DataBind()
        con.Close()
    End Sub
    '##################################### END OF BIND DATA TO GRIDVIEW #################################################################

    '######################################## MAKE GRIDVIEW SELECT LOAN SELECTABLE ###################################################################
    Private Sub GridView_select_loan_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_loan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_loan, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_loan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_loan.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_loan.Rows
            If row.RowIndex = GridView_select_loan.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '######################################## END OF MAKE GRIDVIEW SELECT LOAN SELECTABLE ###################################################################

    '####################################### DEACTIVATE LOAN #########################################################################
    Private Sub btn_deactive_loan_Click(sender As Object, e As EventArgs) Handles btn_deactive_loan.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_active.Text = "select loan to deactivate"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_active.Text = "no loan"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set loan_status = 'deactive' where family_id = @familyID and transaction_id= @tran "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@tran", GridView_select_loan.SelectedRow.Cells(0).Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_data_gridview_select_loan()
            bind_data_to_gridview_deactivated_loan()
            GridView_select_loan.SelectedIndex = -1
        End If
    End Sub
    '####################################### END OF DEACTIVATE LOAN #########################################################################

    '######################################## MAKE GRIDVIEW DEACTIVATE SELECTABLE ###################################################################
    Private Sub GridView_deactivated_loan_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_deactivated_loan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_deactivated_loan, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_deactivated_loan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_deactivated_loan.SelectedIndexChanged
        For Each row As GridViewRow In GridView_deactivated_loan.Rows
            If row.RowIndex = GridView_deactivated_loan.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '######################################## END OF MAKE GRIDVIEW DEACTIVATE SELECTABLE ###################################################################

    '############################################ REACTIVATE LOAN ################################################################################################
    Private Sub btn_reactivate_loan_Click(sender As Object, e As EventArgs) Handles btn_reactivate_loan.Click
        If GridView_deactivated_loan.SelectedIndex = -1 Then
            lbl_validation_deactive.Text = "select loan to reactivate"
        ElseIf GridView_deactivated_loan.Rows.Count = 0 Then
            lbl_validation_deactive.Text = "no loan to reactivate"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set loan_status = 'active' where family_id = @familyID and transaction_id= @tran "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@tran", GridView_deactivated_loan.SelectedRow.Cells(0).Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_data_gridview_select_loan()
            bind_data_to_gridview_deactivated_loan()
            GridView_deactivated_loan.SelectedIndex = -1
        End If
    End Sub
    '############################################ END OF REACTIVATE LOAN ################################################################################################

    '############################################ PAGING IN GRIDVIEW ###############################################################################
    Private Sub GridView_select_loan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_loan.PageIndexChanging
        GridView_select_loan.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_select_loan()
    End Sub
    Private Sub GridView_deactivated_loan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_deactivated_loan.PageIndexChanging
        GridView_deactivated_loan.PageIndex = e.NewPageIndex
        Me.bind_data_to_gridview_deactivated_loan()
    End Sub
    '############################################ PAGING IN GRIDVIEW ###############################################################################

End Class