Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_msg_form
    Inherits System.Web.UI.Page

    Dim Vfamily_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_gripview_recipient()
    End Sub

    '########################################## THEME SETUP #################################################################
    Private Sub member_msg_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '########################################## END OF THEME SETUP #################################################################

    '############################################### BIND DATA TO GRIPVIEW RECIPIENT ###############################################
    Private Sub bind_data_gripview_recipient()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select username as [Contact] from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id where f.family_id <> @familyID and family_status = 'active' order by username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_recipient.DataSource = dt
        GridView_recipient.DataBind()
        con.Close()
    End Sub
    '############################################### END OF BIND DATA TO GRIPVIEW RECIPIENT ########################################

    '################################################ MAKE GRIDVIEW RECIPIENT SELECTABLE ##########################################
    Private Sub GridView_recipient_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_recipient.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_recipient, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_recipient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_recipient.SelectedIndexChanged
        For Each row As GridViewRow In GridView_recipient.Rows
            If row.RowIndex = GridView_recipient.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        txtbx_recipient.Text = GridView_recipient.SelectedRow.Cells(0).Text
        If GridView_recipient.SelectedIndex = -1 Then
            Panel_sent_msg.Visible = False
            Detailview_sent_msgs.Visible = False
            DetailView_inbox_msgs.Visible = False
        Else
            Panel_sent_msg.Visible = True
            Detailview_sent_msgs.Visible = False
            DetailView_inbox_msgs.Visible = False
        End If
    End Sub
    '################################################ END OF MAKE GRIDVIEW RECIPIENT SELECTABLE ##########################################
    
    '################################################### SENT NEW MESSAGE ##############################################################
    Private Sub btn_cancel_msg_Click(sender As Object, e As EventArgs) Handles btn_cancel_msg.Click
        Panel_sent_msg.Visible = False
        GridView_recipient.SelectedIndex = -1
    End Sub
    Private Sub btn_create_msg_Click(sender As Object, e As EventArgs) Handles btn_create_msg.Click
        If GridView_recipient.SelectedIndex = -1 Then
            lbl_validation.Text = "Select a recipient"
            Panel_sent_msg.Visible = False
        Else
            Panel_sent_msg.Visible = True
            Panel_view_inbox_sent_msg.Visible = False
            Detailview_sent_msgs.Visible = False
            DetailView_inbox_msgs.Visible = False
            lbl_validation.Text = ""
        End If
    End Sub
    Private Sub btn_sent_msg_Click(sender As Object, e As EventArgs) Handles btn_sent_msg.Click
        If txtbx_msg_body.Text = "" Then
            lbl_validation.Text = "Empty message please write something to sent"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into messaging_tbl(message_body , date_sent , family_id , sent_to , notif_msg , sent_by) values (@msgbody , @datesent , @famID , @sentTo , 'notify' , @sentby )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@msgbody", txtbx_msg_body.Text)
            sqlCmd1.Parameters.AddWithValue("@datesent", DateAndTime.Now)
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@sentTo", txtbx_recipient.Text)
            sqlCmd1.Parameters.AddWithValue("@sentby", Session("user"))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation.Text = "message sent to :" + " " + txtbx_recipient.Text
            get_family_id()
            update_family_notif()
        End If
    End Sub
    Private Sub get_family_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from user_tbl where username = @username"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@username", txtbx_recipient.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vfamily_id = CInt(reader("family_id"))
            con.Close()
        End If
    End Sub
    Private Sub update_family_notif()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_tbl set noti_status = 'new-notif'  where family_id = @id "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@id", Vfamily_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################### SENT NEW MESSAGE ##############################################################

    '#################################################### VIEW SENT MESSAGES ##########################################################
    Private Sub btn_view_sent_msg_Click(sender As Object, e As EventArgs) Handles btn_view_sent_msg.Click
        If Panel_view_inbox_sent_msg.Visible = False Then
            Panel_sent_msg.Visible = False
            Panel_view_inbox_sent_msg.Visible = True
            DetailView_inbox_msgs.Visible = False
            Detailview_sent_msgs.Visible = True
            detailview_sent_msg()
        ElseIf Panel_view_inbox_sent_msg.Visible = True Then
            DetailView_inbox_msgs.Visible = False
            Detailview_sent_msgs.Visible = True
            detailview_sent_msg()
        End If

    End Sub
    Private Sub detailview_sent_msg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select sent_to as [Recipient] , message_body as [Content] ,  FORMAT(date_sent , 'dd/MM/yyyy') as [Date sent] from messaging_tbl where family_id = @familyID order by date_sent desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Detailview_sent_msgs.DataSource = dt
        Detailview_sent_msgs.DataBind()
        con.Close()
    End Sub
    Private Sub Detailview_sent_msgs_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs) Handles Detailview_sent_msgs.PageIndexChanging
        Detailview_sent_msgs.PageIndex = e.NewPageIndex
        Me.detailview_sent_msg()
    End Sub
    '#################################################### END OF VIEW SENT MESSAGES ##########################################################

    '###################################################### VIEW INBOX MESSAGE #################################################################
    Private Sub btn_inbox_Click(sender As Object, e As EventArgs) Handles btn_inbox.Click
        If Panel_view_inbox_sent_msg.Visible = False Then
            Panel_sent_msg.Visible = False
            Panel_view_inbox_sent_msg.Visible = True
            DetailView_inbox_msgs.Visible = True
            Detailview_sent_msgs.Visible = False
            inbox_msgs()
        ElseIf Panel_view_inbox_sent_msg.Visible = True Then
            Detailview_sent_msgs.Visible = False
            DetailView_inbox_msgs.Visible = True
            inbox_msgs()
        End If

    End Sub
    Private Sub inbox_msgs()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select sent_by as [Sender] , message_body as [Content] ,  FORMAT(date_sent , 'dd/MM/yyyy')  as [Date sent] from messaging_tbl where sent_to = @sender order by date_sent desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@sender", Session("user"))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailView_inbox_msgs.DataSource = dt
        DetailView_inbox_msgs.DataBind()
        con.Close()
    End Sub
    Private Sub DetailView_inbox_msgs_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs) Handles DetailView_inbox_msgs.PageIndexChanging
        DetailView_inbox_msgs.PageIndex = e.NewPageIndex
        Me.inbox_msgs()
    End Sub
    '###################################################### END OF VIEW INBOX MESSAGE #################################################################

    '########################################################## PAGING FOR GRIDVIEW #######################################################################
    Private Sub GridView_recipient_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_recipient.PageIndexChanging
        GridView_recipient.PageIndex = e.NewPageIndex
        Me.bind_data_gripview_recipient()
    End Sub
    '########################################################## END OF PAGING FOR GRIDVIEW #######################################################################
End Class