Imports System.Data.SqlClient

Public Class family_view_information
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_general_detailview()
        bind_username_detail_view()
        bind_gridview_email()
    End Sub

    Private Sub family_view_information_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_general_detailview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select name , surname , gender , FORMAT(dob , 'dd/MM/yyyy') as [date of birth] from family_tbl where family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_general_info.DataSource = dt
        DetailsView_general_info.DataBind()
        con.Close()
    End Sub
    Private Sub bind_username_detail_view()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select username from user_tbl where family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_username.DataSource = dt
        DetailsView_username.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_email()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select email_address , email_primary from email_tbl where email_status = 'active' and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_email.DataSource = dt
        GridView_email.DataBind()
        con.Close()
    End Sub
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    Private Sub GridView_email_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_email.PageIndexChanging
        GridView_email.PageIndex = e.NewPageIndex
        Me.bind_gridview_email()
    End Sub
End Class