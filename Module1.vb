Imports MySql.Data.MySqlClient

Module Module1
    Public ServerString As String = "Server=localhost; port=3306;username=root;password=; database=student"
    Public conn As MySqlConnection = New MySqlConnection(ServerString)
    Public myreader As MySqlDataReader
    Public cmd As MySqlCommand = New MySqlCommand

    Public Sub query_execute(ByVal sql As String)
        Try
            cmd.CommandText = sql
            cmd.Connection = conn
            conn.Open()
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try
        conn.Close()

    End Sub

    Public Sub loadgv(ByRef dgv As GridView, ByRef sql As String)
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        da.SelectCommand = New MySqlCommand(sql, conn)
        da.Fill(ds)
        conn.Close()
        dgv.DataSource = ds.Tables(0)
    End Sub
End Module
