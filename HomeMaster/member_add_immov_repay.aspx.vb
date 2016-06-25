Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_add_immov_repay
    Inherits System.Web.UI.Page

    Dim Vpurchase_cost As Decimal
    Dim Vsum_amount As Decimal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_to_gridview_preview_asset()
    End Sub

    '################################### THEME SETUP #############################################################################
    Private Sub member_add_immov_repay_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #############################################################################


    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  i_property_id as [ref no] , i_name as [Property] , i_cat_name as [Category] , i_purchase_method as [Purchase method] from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'active' "
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
        Dim sql = " select i_name as [Property] , i_location as [Location] , i_current_value as [Current value] , i_purchase_cost as [Purchase cost] , FORMAT(i_purchase_date , 'dd/MM/yyyy') as [Purchase date]   , i_length as [Length] , i_width as [Width] , i_note as [Note] , i_cat_name as [Category] , i_purchase_method as [Purchase method]  from immovable_property_tbl as i inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id = p.i_purchase_method_id where i_property_id = @ID "
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
    Private Sub bind_gridview_repayment()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_repay_id as [Ref no] , i_amount as [Amount] , i_amount_remain as [Amount remaining] , FORMAT(i_repay_date , 'dd/MM/yyyy') as [Repayment date]  from immovable_property_repay where i_property_id = @ID order by i_repay_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_repayment.DataSource = dt
        GridView_repayment.DataBind()
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
        'displayImg()
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
    '#################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################

   

    '####################################### SAVE REPAYMENT ##############################################################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If GridView_view_active_preview_assets.SelectedIndex = -1 Then
            lbl_validation.Text = "select property to add repayment"
        ElseIf validation_amount.IsValid = True And validation_date.IsValid = True And validation_remain.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into immovable_property_repay(i_repay_date , i_amount , i_property_id , i_amount_remain , i_repay_status , i_rep_expn_status ) values (convert(date,@rep_Date,103) , @amt ,  @id , @remain  , 'active' , 'notadded')"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@rep_Date", txtbx_repay_date.Text)
            sqlCmd1.Parameters.AddWithValue("@amt", CDec(txtbx_repay_amount.Text))
            sqlCmd1.Parameters.AddWithValue("@remain", CDec(txtbx_repay_remain.Text))
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_repayment()
            'GridView_view_active_preview_assets.SelectedIndex = -1
            lbl_validation.Text = "new payment added"
        End If
    End Sub
    '####################################### END OF SAVE REPAYMENT ##############################################################################

    '############################################# CALCULATE REMAINDER TO PAY ####################################################################
    Private Sub get_purchase_cost()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select i_purchase_cost from immovable_property_tbl where i_property_id = @id"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpurchase_cost = CDec(reader2("i_purchase_cost"))
            con2.Close()
        End If
    End Sub
    Private Sub get_sum_amount_repay()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select  sum(i_amount) as [total paid] from immovable_property_repay where i_property_id = @id"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            If IsDBNull(reader2("total paid")) Then
                Vsum_amount = 0
            Else
                Vsum_amount = CDec(reader2("total paid"))
                con2.Close()
            End If
        End If
    End Sub
    Private Sub txtbx_repay_amount_TextChanged(sender As Object, e As EventArgs) Handles txtbx_repay_amount.TextChanged
        If GridView_view_active_preview_assets.SelectedIndex = -1 Then
            lbl_validation.Text = "select property to calculate remaining amount"
        ElseIf txtbx_repay_amount.Text = "" Then
            lbl_validation.Text = "enter amount to calculate remainder"
        ElseIf validation_amount.IsValid = True Then
            get_purchase_cost()
            get_sum_amount_repay()
            Dim Vtotal_pay As Decimal
            Vtotal_pay = Vsum_amount + CDec(txtbx_repay_amount.Text)
            txtbx_repay_remain.Text = CStr(Vpurchase_cost - Vtotal_pay)
        End If

    End Sub
    '############################################# END OF CALCULATE REMAINDER TO PAY ####################################################################

    '################################################ REMOVE REPAYMENT #######################################################################
    Private Sub btn_remove_repayment_Click(sender As Object, e As EventArgs) Handles btn_remove_repayment.Click
        If GridView_view_active_preview_assets.SelectedIndex = -1 Then
            lbl_validation.Text = "select property to remove repayment"
        ElseIf GridView_repayment.SelectedIndex = -1 Then
            lbl_validation.Text = "select repayment to remove"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update immovable_property_repay set i_repay_status = 'deactive' where i_repay_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_repayment.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            GridView_repayment.SelectedIndex = -1
            bind_gridview_repayment()
            lbl_validation.Text = "repayment removed"
        End If
    End Sub
    '################################################ END OF REMOVE REPAYMENT #######################################################################

    '############################################## PAGING IN GRIDVIEW ##################################################################################
    Private Sub GridView_view_active_preview_assets_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_view_active_preview_assets.PageIndexChanging
        GridView_view_active_preview_assets.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
    Private Sub GridView_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_repayment.PageIndexChanging
        GridView_repayment.PageIndex = e.NewPageIndex
        Me.bind_gridview_repayment()
    End Sub
    '############################################## END OF PAGING IN GRIDVIEW ##################################################################################
End Class

''######################################### DISPLAY IMAGE TO REPEATER ###################################################################
'Private Sub displayImg()
'    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id where p.m_asset_id = @ID "
'    Dim cmd As New SqlCommand(sql, con)
'    cmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
'    Dim myReader As SqlDataReader
'    con.Open()
'    myReader = cmd.ExecuteReader
'    Repeater1.DataSource = myReader
'    Repeater1.DataBind()
'End Sub
''######################################### END OF DISPLAY IMAGE TO REPEATER ###################################################################