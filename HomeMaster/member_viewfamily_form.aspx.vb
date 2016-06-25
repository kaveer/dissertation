Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_viewfamily_form
    Inherits System.Web.UI.Page
    Dim Vfamily_ID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_data_gridview_active_mem()
            bind_data_gridview_deactive_mem()
            bond_data_gridview_isactive()
        End If
        
    End Sub

    '######################################### BIND DATA TO GRIDVIEW #####################################################################
    Private Sub bind_data_gridview_active_mem()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select user_id as [Ref no], username as [Members] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy') as [Date of birth] , family_status as [Status] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'active' order by username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_active_member.DataSource = dt
        GridView_active_member.DataBind()
        con.Close()
    End Sub
    Private Sub bind_data_gridview_deactive_mem()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select user_id as [Ref no], username as [Members] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy') as [Date of birth] , family_status as [Status] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'deactive' order by username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactivat_member.DataSource = dt
        GridView_deactivat_member.DataBind()
        con.Close()

    End Sub
    Private Sub bond_data_gridview_isactive()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select user_id as [Ref no], username as [Members] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy')  as [Date of birth] , family_status as [Status] , is_activated as [online activation] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'active' and is_activated = 'no' order by username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_is_online_active.DataSource = dt
        GridView_is_online_active.DataBind()
        con.Close()
    End Sub
    '######################################### END OF BIND DATA TO GRIDVIEW #####################################################################

    '################################################ THEME SETUP #######################################################################
    Private Sub member_viewfamily_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

  
    '################################################ END OF THEME SETUP #######################################################################

    '#################################################### MAKE ALL GRIDVIEW SELECTABLE #######################################################
    Private Sub GridView_active_member_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_active_member.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_active_member, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_active_member_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_active_member.SelectedIndexChanged
        For Each row As GridViewRow In GridView_active_member.Rows
            If row.RowIndex = GridView_active_member.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

   
    Private Sub GridView_deactivat_member_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_deactivat_member.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_deactivat_member, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_deactivat_member_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_deactivat_member.SelectedIndexChanged
        For Each row As GridViewRow In GridView_deactivat_member.Rows
            If row.RowIndex = GridView_deactivat_member.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '#################################################### END OF MAKE ALL GRIDVIEW SELECTABLE #######################################################

    '####################################################### DEACTIVATE MEMBER ######################################################################
    Private Sub btn_deactivate_Click(sender As Object, e As EventArgs) Handles btn_deactivate.Click
        If GridView_active_member.SelectedIndex = -1 Then
            lbl_validation_active_mem.Text = "  Select a member to delete"
        ElseIf GridView_active_member.Rows.Count = 0 Then
            lbl_validation_active_mem.Text = "No active members"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from user_tbl  as u inner join family_tbl as f on f.family_id = u.family_id where user_id= @userID and username = @username "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@userID", CInt(GridView_active_member.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@username", GridView_active_member.SelectedRow.Cells(1).Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                Vfamily_ID = CInt(reader("family_id"))
            End If
            con.Close()
            deactive_mem()
            bind_data_gridview_active_mem()
            bind_data_gridview_deactive_mem()
            bond_data_gridview_isactive()
            GridView_active_member.SelectedIndex = -1
        End If
    End Sub
    Private Sub deactive_mem()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = " update family_tbl set family_status = 'deactive' where family_id = @familyID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", Vfamily_ID)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '####################################################### END OF DEACTIVATE MEMBER ######################################################################

    '###################################################### SEARCH ACTIVE MEMBERS ##################################################################
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If txtbx_search_mem.Text = "" Then
            lbl_validation_active_mem.Text = "enter member detail to search"
        Else
            search_function()
        End If
    End Sub
    Private Sub search_function()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "  select user_id as [Ref no], username as [Members] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy') as [Date of birth] , family_status as [Status] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'active' and (username like '%' + @search + '%' or name like '%' + @search + '%' or surname like '%' + @search + '%') order by username  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@search", txtbx_search_mem.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_active_member.DataSource = dt
        GridView_active_member.DataBind()
        con.Close()
    End Sub
    '###################################################### END OF SEARCH ACTIVE MEMBERS ##################################################################

    '############################################# ACTIVATE MEMBER #####################################################################
    Private Sub btn_active_mem_Click(sender As Object, e As EventArgs) Handles btn_active_mem.Click
        If GridView_deactivat_member.SelectedIndex = -1 Then
            lbl_validate_deactive.Text = "  Select a member to activate"
        ElseIf GridView_deactivat_member.Rows.Count = 0 Then
            lbl_validate_deactive.Text = "No deactive members"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from user_tbl  as u inner join family_tbl as f on f.family_id = u.family_id where user_id= @userID and username = @username "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@userID", CInt(GridView_deactivat_member.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@username", GridView_deactivat_member.SelectedRow.Cells(1).Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                Vfamily_ID = CInt(reader("family_id"))
            End If
            con.Close()
            activate_mem()
            bind_data_gridview_deactive_mem()
            bind_data_gridview_active_mem()
            bond_data_gridview_isactive()
            GridView_deactivat_member.SelectedIndex = -1
        End If
    End Sub
    Private Sub activate_mem()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = " update family_tbl set family_status = 'active' where family_id = @familyID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", Vfamily_ID)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '############################################# END OF ACTIVATE MEMBER #####################################################################

    '############################################### SEARCH DEACTIVE MEMBERS ############################################################
    Private Sub btn_search_deactive_Click(sender As Object, e As EventArgs) Handles btn_search_deactive.Click
        If txtbx_search_deactive.Text = "" Then
            lbl_validate_deactive.Text = "enter member detail to search"
        Else
            search_deactive_mem()
        End If
    End Sub
    Private Sub search_deactive_mem()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "  select user_id as [Ref no], username as [Member] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy') as [Date of birth] , family_status as [Status] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'deactive' and (username like '%' + @search + '%' or name like '%' + @search + '%' or surname like '%' + @search + '%') order by username  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@search", txtbx_search_deactive.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactivat_member.DataSource = dt
        GridView_deactivat_member.DataBind()
        con.Close()
    End Sub
    '############################################### END OF SEARCH DEACTIVE MEMBERS ############################################################

    '################################################### SEARCH IS ONLINE ACTIVATED MEMBER ####################################################
    Private Sub btn_search_isactive_Click(sender As Object, e As EventArgs) Handles btn_search_isactive.Click
        If txtbx_search_isactive.Text = "" Then
            lbl_validate_isactive.Text = "enter member detail to search"
        Else
            search_is_online_active_mem()
        End If
    End Sub
    Private Sub search_is_online_active_mem()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "  select user_id as [Ref no], username as [Member] , name as [Name] , surname as [Surname] , gender as [Gender] ,  FORMAT(dob , 'dd/MM/yyyy')  as [Date of birth] , family_status as [Status] , is_activated as [online activation] , family_type as [Relationship] , email_address as [email asddress] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id inner join email_tbl as e on e.family_id = f.family_id where not f.family_id = @familyID and family_status = 'active' and is_activated = 'no' and (username like '%' + @search + '%' or name like '%' + @search + '%' or surname like '%' + @search + '%') order by username  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@search", txtbx_search_isactive.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_is_online_active.DataSource = dt
        GridView_is_online_active.DataBind()
        con.Close()
    End Sub
    '################################################### END OF SEARCH IS ONLINE ACTIVATED MEMBER ####################################################

    '#################################################### PAGING FOR GRIDVIEW #############################################################################
    Private Sub GridView_active_member_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_active_member.PageIndexChanging
        GridView_active_member.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_active_mem()
    End Sub
    Private Sub GridView_deactivat_member_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_deactivat_member.PageIndexChanging
        GridView_deactivat_member.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_deactive_mem()
    End Sub
    Private Sub GridView_is_online_active_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_is_online_active.PageIndexChanging
        GridView_is_online_active.PageIndex = e.NewPageIndex
        Me.bond_data_gridview_isactive()
    End Sub
    '#################################################### END OF PAGING FOR GRIDVIEW #############################################################################
End Class