Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports Microsoft.SqlServer.Server
Imports Microsoft.SqlServer.Server.SqlMetaData


Public Class DataAccess

#Region "Selects"

  Public Shared Function PopulateWebAddresses() As List(Of SearchAddressLink)

    Dim List As New List(Of SearchAddressLink)
    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetSearchPages", sc)
          command.CommandType = CommandType.StoredProcedure
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(New SearchAddressLink(reader(0), reader(1), reader(2)))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function

  Public Shared Function PopulateFlirtLinks() As List(Of String)

    Dim List As New List(Of String)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetFlirtLinks", sc)
          command.CommandType = CommandType.StoredProcedure
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(reader(0))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function

  Public Shared Function PopulateProfiles() As List(Of NFProfile)

    Dim List As New List(Of NFProfile)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetProfiles", sc)
          command.CommandType = CommandType.StoredProcedure
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(New NFProfile(reader(0), Convert.ToString(reader(1))))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function


  Public Shared Function PopulateSavedEmails(ByVal Profile_FK As Integer) As List(Of SavedEmail)


        Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
    Dim List As New List(Of SavedEmail)

    Try

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetEmails", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Profile_PK", Profile_FK))
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(New SavedEmail(reader(0), reader(1), Convert.ToString(reader(2)), Convert.ToString(reader(3)), Convert.ToString(reader(4))))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function

  Public Shared Function PopulateEmailContactsSingleEmail(ByVal Categories As List(Of String), ByVal LastFeedbackDate As Date, NumberOfContacts As Integer,
                                                          AdditionalTestContact As String, ByVal EmailSent_FK As Integer) As String

    Dim res As String = String.Empty

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Dim List As New List(Of String)
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)} 'Convert List to IDataReader

      For Each cat As String In Categories
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat)
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ExtractContactsForEmailSingle", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@EmailSent_FK", EmailSent_FK))
          command.Parameters.Add(New SqlParameter("@LastFeedbackDate", LastFeedbackDate))
          command.Parameters.Add(New SqlParameter("@NumberOfContacts", NumberOfContacts))
          command.Parameters.Add(New SqlParameter("@AdditionalTestContact", AdditionalTestContact))
          command.Parameters.Add("@Categories", SqlDbType.Structured)
          command.Parameters("@Categories").Direction = ParameterDirection.Input
          command.Parameters("@Categories").TypeName = "string_list"
          command.Parameters("@Categories").Value = ListToSend
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            res = reader(0)
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return res

  End Function

  ' Public Shared Function PopulateEmailContactsMultipleEmail(ByVal Categories As List(Of String)) As List(Of String)

  Public Shared Function PopulateEmailContactsMultipleEmail(ByVal Categories As List(Of String), ByVal LastFeedbackDate As Date, NumberOfContacts As Integer,
                                                       AdditionalTestContact As String, ByVal EmailSent_FK As Integer) As List(Of String)

    Dim List As New List(Of String)

    Try


            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      'Convert List to IDataReader
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)}

      For Each cat As String In Categories
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat)
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ExtractContactsForEmailMultiple", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@EmailSent_FK", EmailSent_FK))
          command.Parameters.Add(New SqlParameter("@LastFeedbackDate", LastFeedbackDate))
          command.Parameters.Add(New SqlParameter("@NumberOfContacts", NumberOfContacts))
          command.Parameters.Add(New SqlParameter("@AdditionalTestContact", AdditionalTestContact))
          command.Parameters.Add("@Categories", SqlDbType.Structured)
          command.Parameters("@Categories").Direction = ParameterDirection.Input
          command.Parameters("@Categories").TypeName = "string_list"
          command.Parameters("@Categories").Value = ListToSend
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(reader(0))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function

  Public Shared Function PopulateCategories() As DataSet

    Dim ds As New DataSet()

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetCategories", sc)
          command.CommandType = CommandType.StoredProcedure
          Dim adp As New SqlDataAdapter(command)
          adp.Fill(ds)
        End Using
        sc.Close()
      End Using

      'Create a colum to select rows
      ds.Tables(0).Columns.Add(New DataColumn("Select", System.Type.GetType("System.Boolean")))
      ds.Tables(0).Columns("Select").ReadOnly = False
      ds.Tables(0).Columns("Select").DefaultValue = False
      ds.Tables(0).Columns("Select").SetOrdinal(0)

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return ds

  End Function


  Public Shared Function PopulateSelectedCategories(ByVal Profile_FK As Integer) As List(Of String)

    Dim List As New List(Of String)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetSelectedCategories", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Profile_FK", Profile_FK))
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(reader(0))
          End While
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function

  Public Shared Function PopulateSetting() As Setting

    Dim List As New List(Of Setting)
    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("GetSetting", sc)
          command.CommandType = CommandType.StoredProcedure
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            List.Add(New Setting(reader(0), reader(1), reader(2), reader(3), reader(4), reader(5), reader(6), reader(7)))
          End While
          reader.Close()
        End Using
        sc.Close()
      End Using

      Dim i As Integer = 0
      For Each Setting In List
        If i > 0 Then
          Exit For
        End If
        Return Setting
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Function

#End Region

#Region "Imports"


  Public Shared Sub InsertContacts(ByVal UserName As ContactInfo)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using sCmnd As New SqlCommand("[dbo].[tmpContactImportInsert]", sc)
          sCmnd.CommandType = CommandType.StoredProcedure
          sCmnd.Parameters.Add(New SqlParameter("@ContactName", UserName.ContactName))
          sCmnd.Parameters.Add(New SqlParameter("@FeedbackDate", UserName.FeedbackDate))
          sCmnd.Parameters.Add(New SqlParameter("@FlirtName", UserName.FlirtName))
          sCmnd.Parameters.Add(New SqlParameter("@FlirtLink", UserName.FlirtLink))
          sCmnd.ExecuteNonQuery()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  Public Shared Sub ImportToDatabase(Source As Integer)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using sCmnd As New SqlCommand("[dbo].[ImportContactsFromScrape]", sc)
          sCmnd.CommandType = CommandType.StoredProcedure
          sCmnd.Parameters.Add(New SqlParameter("@CategoryType_PK", Source))
          sCmnd.ExecuteNonQuery()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  Public Shared Function UpdateSelectedCategories(ByVal Profile_PK As Integer, ByVal Categories As List(Of String)) As String

    Dim res As String = String.Empty

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Dim List As New List(Of String)
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)} 'Convert List to IDataReader

      For Each cat As String In Categories
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat)
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("UpdateSelectedCategories", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Profile_FK", Profile_PK))
          command.Parameters.Add("@Categories", SqlDbType.Structured)
          command.Parameters("@Categories").Direction = ParameterDirection.Input
          command.Parameters("@Categories").TypeName = "string_list"
          command.Parameters("@Categories").Value = ListToSend
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          reader.Close()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return res

  End Function



  Public Shared Function SaveEmail(ByVal Action As String, ByVal Email_PK As Integer, ByVal Profile_FK As Integer, ByVal Subject As String, ByVal Body As String, _
                                   ByVal EstimatedValue As Decimal) As Integer

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("iudProfileEmails", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Action", Action))
          command.Parameters.Add(New SqlParameter("@Email_PK", Email_PK))
          command.Parameters.Add(New SqlParameter("@Profile_FK", Profile_FK))
          command.Parameters.Add(New SqlParameter("@Subject", Subject))
          command.Parameters.Add(New SqlParameter("@Body", Body))
          command.Parameters.Add(New SqlParameter("@EstimatedValue", EstimatedValue))
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            Return reader(0)
          End While
        End Using
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return 0
  End Function

  Public Shared Function ImportContactsNF(ByVal Contacts As DataTable, ByVal Profile_FK As Integer, ByVal Status As String)

    Dim List As New List(Of String)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      'Convert List to IDataReader
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)}

      For Each cat As DataRow In Contacts.Rows
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat(0))
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ImportContactsFromNF", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Profile_PK", Profile_FK))
          command.Parameters.Add(New SqlParameter("@Status", Status))
          command.Parameters.Add("@Con", SqlDbType.Structured)
          command.Parameters("@Con").Direction = ParameterDirection.Input
          command.Parameters("@Con").TypeName = "string_list"
          command.Parameters("@Con").Value = ListToSend
          command.ExecuteNonQuery()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List

  End Function


  Public Shared Function ImportInactiveContactsFromEmailSend(ByVal InactiveContacts As List(Of String)) As String

    Dim res As String = String.Empty

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"
      Dim List As New List(Of String)
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)} 'Convert List to IDataReader

      For Each cat As String In InactiveContacts
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat)
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ImportInactiveContactsFromEmailSend", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add("@InactiveContacts", SqlDbType.Structured)
          command.Parameters("@InactiveContacts").Direction = ParameterDirection.Input
          command.Parameters("@InactiveContacts").TypeName = "string_list"
          command.Parameters("@InactiveContacts").Value = ListToSend
          command.ExecuteNonQuery()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return res

  End Function

  Public Shared Sub InsertContactEmail(ByVal Email_FK As Integer, ByVal ContactsSent As List(Of String))

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      Dim str As String = String.Empty
      Dim List As New List(Of String)
      Dim ListToSend As New List(Of SqlDataRecord)
      Dim tvp_definition As SqlMetaData() = {New SqlMetaData("Col1", SqlDbType.NVarChar, 255)} 'Convert List to IDataReader

      For Each cat As String In ContactsSent
        Dim rec As SqlDataRecord = New SqlDataRecord(tvp_definition)
        rec.SetString(0, cat)
        ListToSend.Add(rec)
      Next

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ImportContactEmail", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@EmailSent_FK", Email_FK))
          command.Parameters.Add("@ContactsSent", SqlDbType.Structured)
          command.Parameters("@ContactsSent").Direction = ParameterDirection.Input
          command.Parameters("@ContactsSent").TypeName = "string_list"
          command.Parameters("@ContactsSent").Value = ListToSend
          command.ExecuteNonQuery()
        End Using
        sc.Close()
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub


  Public Shared Sub InsertEmailActivity(ByVal Email_FK As Integer, ByVal TotalNumberOfContacts As Integer, ByVal TotalNumberOfInactiveContacts As Integer, ByVal TotalNumnberOfContactsSent As Integer)

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("ImportEmailActivity", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@EmailSent_FK", Email_FK))
          command.Parameters.Add(New SqlParameter("@TotalNumberOfContacts", TotalNumberOfContacts))
          command.Parameters.Add(New SqlParameter("@TotalNumberOfInactiveContacts", TotalNumberOfInactiveContacts))
          command.Parameters.Add(New SqlParameter("@TotalNumnberOfContactsSent", TotalNumnberOfContactsSent))
          command.ExecuteNonQuery()
        End Using
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  Public Shared Function SaveSetting(setting As Setting) As Integer

    Try

            Dim connstring As String = "data source=LAP1\SQLEXPRESS;initial catalog=NF;integrated security=True;multipleactiveresultsets=True"

      Using sc As New SqlConnection(connstring)
        sc.Open()
        Using command As New SqlClient.SqlCommand("UpdateSetting", sc)
          command.CommandType = CommandType.StoredProcedure
          command.Parameters.Add(New SqlParameter("@Setting_PK", setting.Setting_PK))
          command.Parameters.Add(New SqlParameter("@LastFeedBackDate", setting.LastFeedbackDate))
          command.Parameters.Add(New SqlParameter("@NoOfEmailsToSend", setting.NumberOfContactsToSendTo))
          command.Parameters.Add(New SqlParameter("@OneEmail", setting.SingleEmail))
          command.Parameters.Add(New SqlParameter("@NoContactsPerEmail", setting.NumberOfContactsPerEmail))
          command.Parameters.Add(New SqlParameter("@AdditionalTestContact", setting.AdditionalTestContact))
          command.Parameters.Add(New SqlParameter("@NFUserName", setting.NFUserName))
          command.Parameters.Add(New SqlParameter("@NFPassword", setting.NFPassword))
          Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
          While reader.Read
            Return reader(0)
          End While
        End Using
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return 0
  End Function

#End Region

#Region "To File"

  Public Shared Sub WritePageEventLog(ByVal SearchAddLink As SearchAddressLink, PageNumber As Integer)
    Try

      Dim today As DateTime = Now
      Using writer As StreamWriter = New StreamWriter(Environment.CurrentDirectory & "EventLog.txt", True)
        writer.WriteLine(SearchAddLink.Address & ", Page " & PageNumber & "is complete and submitted to database " & today & vbCrLf)
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  Public Shared Sub WriteFlirtEventLog(ByVal Item As String, PageNumber As Integer)
    Try

      Dim today As DateTime = Now
      Using writer As StreamWriter = New StreamWriter(Environment.CurrentDirectory & "EventLog.txt", True)
        writer.WriteLine(Item & " has been searched, " & PageNumber & " feedback pages have been searched " & today & vbCrLf)
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

#End Region


End Class
