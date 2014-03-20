Public Class Constants

  Public Enum EnumContactSource
    Kimberly = 1
    Morgan = 2
    ScrapeAnthingGoes = 3
    ScrapeBDSNMistresses = 4
    ScrapeFetish = 5
    ScrapeBDSM = 6
    ScrapeHome = 7
    ScrapeOther = 8
    ScrapeCouples = 9
    ScrapeEnEspanol = 10
    ScrapeFantasy = 11
    ScrapeFetishFemDomes = 12
    ScrapeFetishSubmissiveWomen = 13
    ScrapeFetishFootandShoe = 14
    ScrapeFetishFinDom = 15
    ScrapeFetishFeminization = 16
    ScrapeFetishSmoking = 17
    ScrapeFetishLingerieAndStockings = 18
    ScrapeFetishLeatherAndLatex = 19
    ScrapeFetishSpanking = 20
    ScrapeBDSMSubWomen = 21
    ScrapeFantasyRolePlaying = 22
    ScrapeFantasyOther = 23
    ScrapeFantasyGirlsNextDoor = 24
    ScrapeFantasyKinkyWives = 25
    ScrapeLesbianBisexual = 26
    ScrapeFantasyAnythingGoes = 27
    ScrapeMen = 28
    ScrapeMenMenHomeAlone = 29
    ScrapeMenFantasy = 30
    ScrapeMenBDSM = 31
    ScrapeMenCam = 32
    ScrapeMenAnythingGoes = 33
    ScrapeMenMultiples = 34
    ScrapeMenOther = 35
    ScrapeMenEnEspanol = 36
    ScrapeMenFantasyAnythingGoes = 37
    ScrapeMenFantasyGuyNextDoor = 38
    ScrapeMenFantasyJocks = 39
    ScrapeMenFantasyOther = 40
    ScrapeMenFantasyRolePlaying = 41
    ScrapeMenBDSMMasters = 42
    ScrapeMenBDSMSubMales = 43
    ScrapeMenBDSMFeetShoes = 44
    ScrapeMenBDSMFinDom = 45
    ScrapeMenBDSMLeather = 46
    ScrapeMenCamMenHomeAlone = 47
    ScrapeMenCamCouples = 48
    ScrapeMenCamMaster = 49
    ScrapeTransGen = 50
    ScrapeTransGenCrossDress = 51
    ScrapeTransGenTransSex = 52
    ScrapeTransGenTransv = 53
    ScrapeTransGenAnythingGoes = 54
    ScrapeTransGenFetish = 55
    ScrapeTransGenPhoneWithCam = 56
    ScrapeTransGenFetishBDSM = 57
    ScrapeTransGenFetishDommes = 58
    ScrapeTransGenFetishFemin = 59
    ScrapeTransGenFetishFinanDom = 60
    ScrapeTransGenFetishMistress = 61
    ScrapeTransGenFetishRolePlay = 62
    ScrapeTransGenFetishSpanking = 63
    ScrapeTransGenFetishSubmissive = 64
    ScrapeHomeAlone = 65
    ScrapeHomeAloneSex = 66
    ScrapeHomeAloneOralSex = 67
    ScrapeHomeAloneMature = 68
    ScrapeHomeAloneAnalSex = 69
    ScrapeHomeAloneSexToys = 70
    ScrapeHomeAloneBBW = 71
    ScrapeHomeAloneHouseWives = 72
    ScrapeHomeAloneLatina = 73
    ScrapeHomeAloneEbony = 74
    ScrapeHomeAloneAsian = 75
    ScrapeMenHomeAloneGay = 76
    ScrapeMenHomeAloneBiSexual = 77
    ScrapeMenHomeAloneStraight = 78
  End Enum

  Public Const MAIN_PAGE As String = "www.niteflirt.com"

  Public Shared Function CSVToDataTable(ByVal CSV As String) As DataTable

    Dim tbl As New DataTable()

    Try

      Dim arrCSV As String() = CSV.Split(",")
      For i As Integer = 0 To arrCSV.Length - 1
        If arrCSV(i) <> "" Then
          tbl.Rows.Add(New Object() {arrCSV(i)})
        End If
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return tbl

  End Function

  Public Shared Function ToCsv(Of T)(source As IEnumerable(Of T)) As String

    Try

      If source Is Nothing Then
        Throw New ArgumentNullException("source")
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return String.Join(",", source.[Select](Function(s) s.ToString()).ToArray())
  End Function


End Class
