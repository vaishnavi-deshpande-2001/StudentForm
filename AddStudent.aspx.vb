Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class AddStudent

    Inherits System.Web.UI.Page
    Dim conn As New MySqlConnection("Server=localhost; port=3306;username=root;password=; database=student")
    Dim sql As String
    Dim gender As String
    Private groupBox1 As Object


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        disp_data()
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clear()

    End Sub



    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        ' sert data into the database
        Dim cmd As New MySqlCommand("INSERT INTO  student.student_form (stud_name,stud_fname, stud_mname, stud_dob,stud_gender,stud_address,stud_contact,	stud_standard,stud_class) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox6.Text & "', '" & gender & "','" & TextBox4.Text & "','" & TextBox5.Text & "', '" & DropDownList1.Text & "','" & DropDownList2.Text & "')", conn)

        ' query_execute(sql)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        Clear()
        disp_data()
        MsgBox("Data saved successfully")


    End Sub



    Public Sub disp_data()
        Dim cmd As String
        cmd = "select * from student_form"
        Dim da As New MySqlDataAdapter(cmd, conn)
        Dim ds As New DataSet
        da.Fill(ds)

        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub



    Protected Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        gender = "Male"
    End Sub

    Protected Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        gender = "Female"
    End Sub

    Protected Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        gender = "Not Applicable"
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim index As Integer = e.CommandArgument
        Dim cmdname As String = e.CommandName


        HiddenField1.Value = GridView1.Rows(index).Cells(1).Text


        TextBox1.Text = GridView1.Rows(index).Cells(2).Text
        TextBox2.Text = GridView1.Rows(index).Cells(3).Text
        TextBox3.Text = GridView1.Rows(index).Cells(4).Text
        TextBox6.Text = GridView1.Rows(index).Cells(5).Text
        gender = GridView1.Rows(index).Cells(6).Text
        TextBox4.Text = GridView1.Rows(index).Cells(7).Text
        TextBox5.Text = GridView1.Rows(index).Cells(8).Text
        DropDownList1.Text = GridView1.Rows(index).Cells(9).Text
        DropDownList2.Text = GridView1.Rows(index).Cells(10).Text

    End Sub

  

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        MsgBox("Data Updated Successfully")
        GridView1.DataBind()

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim cmd As New MySqlCommand("update student_form set stud_name='" & TextBox1.Text & "', stud_fname= '" & TextBox2.Text & "',stud_mname='" & TextBox3.Text & "', stud_dob='" & TextBox6.Text & "', stud_gender='" & gender & "',stud_address='" & TextBox4.Text & "', stud_contact='" & TextBox5.Text & "',stud_standard='" & DropDownList1.Text & "', stud_class='" & DropDownList2.Text & "' where id=" & HiddenField1.Value, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            Clear()
            disp_data()
            MsgBox("Data updated successfully ...")
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub Clear()
        TextBox1.Text = String.Empty ' Clear TextBox1
        TextBox2.Text = String.Empty ' Clear TextBox2
        TextBox3.Text = String.Empty ' Clear TextBox3
        TextBox4.Text = String.Empty ' Clear TextBox4
        TextBox5.Text = String.Empty ' Clear TextBox5
        TextBox6.Text = String.Empty ' Clear TextBox6

        RadioButton3.Checked = False

        RadioButton2.Checked = False

        RadioButton4.Checked = False




        DropDownList1.SelectedIndex = -1

        DropDownList2.SelectedIndex = -1

    End Sub
End Class