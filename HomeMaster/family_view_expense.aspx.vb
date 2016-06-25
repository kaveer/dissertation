Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_view_expense
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            view_by_category()
        End If
        bind_data_gridview_all_expense()
    End Sub

    '################################################# THEME SETUP ###################################################################
    Private Sub family_view_expense_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################

    '########################################### BIND TO DROPDOWNLIST ##################################################################
    Private Sub view_by_date()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select FORMAT(finance_date , 'dd/MM/yyyy') as [date created] , finance_amount from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID and finance_date between DATEADD( MM , -1 , GETDATE()) and GETDATE()     "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "date created"
        Chart_view_expense.Series("Series2").YValueMembers = "finance_amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    Private Sub view_by_category()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "finance_category"
        Chart_view_expense.Series("Series2").YValueMembers = "finance_amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    Private Sub view_by_mean_payment()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  finance_payment_mean,sum( finance_amount ) as [amount] from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID group by finance_payment_mean "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "finance_payment_mean"
        Chart_view_expense.Series("Series2").YValueMembers = "amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    Private Sub ddl_select_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_select_type.SelectedIndexChanged
        If ddl_select_type.SelectedIndex = 0 Then
            view_by_category()
        ElseIf ddl_select_type.SelectedIndex = 1 Then
            view_by_date()
        ElseIf ddl_select_type.SelectedIndex = 2 Then
            view_by_mean_payment()
        End If
    End Sub
    '########################################### END OF BIND TO DROPDOWNLIST ##################################################################

    '############################################## SEARCH WITH DATE BETWEEN ##############################################################
    Private Sub btn_display_chart_Click(sender As Object, e As EventArgs) Handles btn_display_chart.Click
        If txtbx_from_date.Text = "" Then
            lbl_validation.Text = "Enter starting date"
        ElseIf txtbx_to_date.Text = "" Then
            lbl_validation.Text = "enter finishing date"
        ElseIf validation_fromdate.IsValid = True And validation_todate.IsValid = True Then
            If ddl_select_type.SelectedIndex = 0 Then
                view_category_with_datebtwn()
            ElseIf ddl_select_type.SelectedIndex = 1 Then
                view_date_with_datebtwn()
            ElseIf ddl_select_type.SelectedIndex = 2 Then
                view_mean_payment_datebtwn()
            End If
        End If

    End Sub
    Private Sub view_category_with_datebtwn()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID and finance_date between convert(date,@frmdate,103) and convert(date,@todate,103)  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@frmdate", txtbx_from_date.Text)
        sqlCmd.Parameters.AddWithValue("@todate", txtbx_to_date.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "finance_category"
        Chart_view_expense.Series("Series2").YValueMembers = "finance_amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    Private Sub view_date_with_datebtwn()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select FORMAT(finance_date , 'dd/MM/yyyy') as [date created] , finance_amount from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID and finance_date between convert(date,@frmdate,103) and convert(date,@todate,103)   "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@frmdate", txtbx_from_date.Text)
        sqlCmd.Parameters.AddWithValue("@todate", txtbx_to_date.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "date created"
        Chart_view_expense.Series("Series2").YValueMembers = "finance_amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    Private Sub view_mean_payment_datebtwn()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  finance_payment_mean,sum( finance_amount ) as [amount] from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID and finance_date between convert(date,@frmdate,103) and convert(date,@todate,103)  group by finance_payment_mean "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@frmdate", txtbx_from_date.Text)
        sqlCmd.Parameters.AddWithValue("@todate", txtbx_to_date.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "finance_payment_mean"
        Chart_view_expense.Series("Series2").YValueMembers = "amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
        con.Close()
    End Sub
    '############################################## END OF SEARCH WITH DATE BETWEEN ##############################################################

    '############################################### MAKE GRIDVIEW SELECTABLE ###################################################################
    Private Sub GridView_all_expense_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_all_expense.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_all_expense, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_all_expense_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_all_expense.SelectedIndexChanged
        For Each row As GridViewRow In GridView_all_expense.Rows
            If row.RowIndex = GridView_all_expense.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '############################################### END OF MAKE GRIDVIEW SELECTABLE ###################################################################

    '################################################# BIND DATA TO GRIDVIEW ########################################################################
    Private Sub bind_data_gridview_all_expense()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select finance_id as [ref no] , finance_name as [expense] , finance_type as [type] , finance_amount as [amount], finance_category as [category] , FORMAT(finance_date , 'dd/MM/yyyy') as [date] , finance_note as [note] , finance_payment_mean as [payment method]  from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID order by finance_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_all_expense.DataSource = dt
        GridView_all_expense.DataBind()
        con.Close()
    End Sub
    '################################################# END OF BIND DATA TO GRIDVIEW ########################################################################

    '################################################## REMOVE EXPENSES #####################################################################################
    Private Sub btn_remove_expense_Click(sender As Object, e As EventArgs) Handles btn_remove_expense.Click
        If GridView_all_expense.SelectedIndex = -1 Then
            lbl_validation_remove.Text = "select expense to remove"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update finance_tbl set finance_status = 'deactive' where finance_id = @cat"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", CInt(GridView_all_expense.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_data_gridview_all_expense()
            lbl_validation_remove.Text = "expense removed"
            GridView_all_expense.SelectedIndex = -1
            Response.Redirect("./family_view_expense.aspx")
        End If
    End Sub
    '################################################## END OF REMOVE EXPENSES #####################################################################################

    '################################################## PAGING ####################################################################################################
    Private Sub GridView_all_expense_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_all_expense.PageIndexChanging
        GridView_all_expense.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_all_expense()
    End Sub
    '################################################## PAGING ####################################################################################################

End Class