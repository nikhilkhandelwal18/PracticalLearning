Imports System.Text
Imports System.Xml
Imports System.Web
Imports System.Web.Script.Serialization

Module Module1


    Sub Main()
        ''''''TEST : Nikhil NK
        'Try
        '    Dim MyConnection As System.Data.OleDb.OleDbConnection
        '    Dim DtSet As System.Data.DataSet
        '    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        '    MyConnection = New System.Data.OleDb.OleDbConnection _
        '        ("provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\SystemLog.xlsx';Extended Properties='Excel 12.0;HDR=NO;';")
        '    '("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\SystemLog.xls';Extended Properties='Excel 8.0 Xml;HDR=YES;';")
        '    '("provider=Microsoft.Jet.OLEDB.4.0; Data Source='C:\Users\P10332297\Documents\My Received Files\SystemLog.xlsx'; Extended Properties=Excel 12.0 Xml;")
        '    MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        '        ("select * from [Sheet1$]", MyConnection)
        '    MyCommand.TableMappings.Add("Table", "TestTable")
        '    DtSet = New System.Data.DataSet
        '    MyCommand.Fill(DtSet)
        '    'DataGridView1.DataSource = DtSet.Tables(0)
        '    MyConnection.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        ''''''''''''''

        'Try
        '    Dim xmlFile As XmlReader
        '    xmlFile = XmlReader.Create("C:\new1.xml", New XmlReaderSettings())
        '    Dim ds As New DataSet
        '    ds.ReadXml(xmlFile)
        '    Dim i As Integer
        '    For i = 0 To ds.Tables(0).Rows.Count - 1
        '        MsgBox(ds.Tables(0).Rows(i).Item(1))
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        ''''''''TEST DATA
        'Dim ds As New DataSet
        'Try
        '    'Dim xmlFile As Xml.XmlReader
        '    'xmlFile = Xml.XmlReader.Create("C:\new1.xml", New Xml.XmlReaderSettings())               
        '    'ds.ReadXml(xmlFile)
        '    Dim dt As New DataTable("LOG")
        '    dt.Columns.Add("LOG_TIME", System.Type.GetType("System.DateTime"))
        '    dt.Columns.Add("SEQ", System.Type.GetType("System.Int32"))
        '    dt.Columns.Add("SOURCE", System.Type.GetType("System.String"))
        '    dt.Columns.Add("ID", System.Type.GetType("System.String"))
        '    dt.Columns.Add("ENTRY", System.Type.GetType("System.String"))
        '    dt.Columns.Add("REV_TIME", System.Type.GetType("System.String"))

        '    For index = 1 To 10
        '        Dim dr As DataRow = dt.NewRow
        '        dr("LOG_TIME") = "20/11/2015  16:05:18"
        '        dr("SEQ") = index.ToString()
        '        dr("SOURCE") = "User"
        '        dr("ID") = "SYS"
        '        dr("ENTRY") = "User VCS-DEVJPSCVAS0120360 authenticated from DEVJPSCVAS0120360"
        '        dr("REV_TIME") = "2015-11-20-16-05-18-57918.37"
        '        dt.Rows.Add(dr)
        '    Next
        '    ds.Tables.Add(dt)

        '    LoadDataSet(ds.Tables("LOG"))

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        '''Test Address Parse
        ''Address.Parse("(STREET RECORD)//DRIFT ROAD//WINKFIELD/WINDSOR/", ","c)
        'Address.Parse("(STREET RECORD),,DRIFT ROAD,,WINKFIELD,WINDSOR,, ", ","c)
        '''


        ''Test If Condition
        'Dim alternate As Boolean = True
        'Dim primary As Boolean

        'If alternate Then
        '    primary = False
        '    Console.WriteLine("primary false")
        'Else
        '    primary = True
        '    Console.WriteLine("primary true")
        'End If


        'primary = IIf(alternate, False, True)
        'Console.WriteLine(primary.ToString)
        ''


        ''Convert to JSON
        Dim jsonConvertlist As New List(Of JSONConvert)

        Dim obj1 As New JSONConvert
        obj1.Agency = "Agency1"
        obj1.CountVehicle = 10
        obj1.ResType = "ResType1"

        Dim obj2 As New JSONConvert
        obj2.Agency = "Agency2"
        obj2.CountVehicle = 20
        obj2.ResType = "ResType2"

        Dim obj3 As New JSONConvert
        obj3.Agency = "Agency3"
        obj3.CountVehicle = 30
        obj3.ResType = "ResType3"

        jsonConvertlist.Add(obj1)
        jsonConvertlist.Add(obj2)
        jsonConvertlist.Add(obj3)

        Dim jsonSerialiser = New JavaScriptSerializer()
        Dim json = jsonSerialiser.Serialize(jsonConvertlist)

        '[{"Agency""Agency1","CountVehicle":10,"ResType":"ResType1"},
        ' {"Agency":"Agency2","CountVehicle":20,"ResType":"ResType2"},
        ' {"Agency":"Agency3","CountVehicle":30,"ResType":"ResType3"}]

        '{\"vehicle\" [{\"Agency\":\ "<<agency>>\",\"Type\": \"<<resourceType>>\",\"Count\": \"<<count>>\"},
        '             {\"Agency\":\ "<<agency>>\",\"Type\": \"<<resourceType>>\",\"Count\": \"<<count>>\"}
        '             ]}


        ''

        Console.ReadLine()
    End Sub


    Public Function LoadDataSet(ByVal table As System.Data.DataTable) As Object
        Dim start As DateTime = Now

        'Check arguments
        If table Is Nothing Then
            Throw New ArgumentNullException("table")
        End If

        For i As Integer = 0 To table.Rows.Count - 1

            Dim LogDate As Date? = CType(GetDataField(table.Rows(i), "LOG_TIME", False, GetType(Nullable(Of DateTime))), Nullable(Of DateTime))
            Dim LogTime As Date? = CType(GetDataField(table.Rows(i), "LOG_TIME", False, GetType(Nullable(Of DateTime))), Nullable(Of DateTime))
            Dim Source As String = CType(GetDataField(table.Rows(i), "SOURCE", False), String)
            Dim Id As String = CType(GetDataField(table.Rows(i), "ID", False), String)
            Dim Entry As String = CType(GetDataField(table.Rows(i), "ENTRY", False), String)
            Dim Sequence As Long = CType(GetDataField(table.Rows(i), "SEQ", False), Long)


        Next

        Debug.WriteLine("TOTAL: " & Now.Subtract(start).TotalMilliseconds)
        Return Nothing
    End Function

    Public Function GetDataField(ByVal row As DataRow, ByVal field As String, ByVal validateField As Boolean, Optional ByVal targetType As Type = Nothing) As Object
        Dim result As Object = ""

        If Not validateField OrElse row.Table.Columns.Contains(field) Then
            If Not row(field).Equals(DBNull.Value) Then
                result = row(field)
            Else
                If targetType IsNot Nothing Then
                    If targetType Is GetType(Nullable(Of DateTime)) Then
                        result = Nothing
                    Else
                        result = String.Empty
                    End If
                Else
                    result = String.Empty
                End If

            End If
        End If

        Return result
    End Function



End Module

Public Class Address
    Private _businessName As Object
    Private _buildingName As Object
    Private _buildingNumber As Object
    Private _streetOne As String
    Private _streetTwo As Object
    Private _areaOne As Object
    Private _areaTwo As Object
    Private _postCode As Object

    Public Property BusinessName() As String
        Get
            If _businessName Is Nothing Then
                _businessName = ""
            End If
            Return _businessName.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _businessName = value
        End Set
    End Property

    Public Property BuildingName() As String
        Get
            If _buildingName Is Nothing Then
                _buildingName = ""
            End If
            Return _buildingName.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _buildingName = value
        End Set
    End Property
    Public Property BuildingNumber() As String
        Get
            If _buildingNumber Is Nothing Then
                _buildingNumber = ""
            End If
            Return _buildingNumber.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _buildingNumber = value
        End Set
    End Property
    Public Property StreetOne() As String
        Get
            If _streetOne Is Nothing Then
                _streetOne = ""
            End If
            Return _streetOne.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _streetOne = value
        End Set
    End Property

    Public Property StreetTwo() As String
        Get
            If _streetTwo Is Nothing Then
                _streetTwo = ""
            End If
            Return _streetTwo.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _streetTwo = value
        End Set
    End Property

    Public Property AreaOne() As String
        Get
            If _areaOne Is Nothing Then
                _areaOne = ""
            End If
            Return _areaOne.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _areaOne = value
        End Set
    End Property

    Public Property AreaTwo() As String
        Get
            If _areaTwo Is Nothing Then
                _areaTwo = ""
            End If
            Return _areaTwo.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _areaTwo = value
        End Set
    End Property

    Public Property PostCode() As String
        Get
            If _postCode Is Nothing Then
                _postCode = ""
            End If
            Return _postCode.Replace("!", "")
        End Get
        Set(ByVal value As String)
            _postCode = value
        End Set
    End Property

    Public Shared Sub Parse(ByVal address As String, ByVal delimiter As Char)
        Parse(address, delimiter, "/"c)
    End Sub
    Public Shared Sub Parse(ByVal address As String, ByVal delimiter As Char, ByVal beforeChr As Char)
        Dim data() As String = address.Split(delimiter)
        ReDim Preserve data(7)

        If Not data(0) Is Nothing Then Dim BusinessName = data(0).Trim
        If Not data(1) Is Nothing Then Dim BuildingName = data(1).Trim

        If Not data(2) Is Nothing Then  'Check for street number
            Dim beforeStr As String = ""
            ' get before string
            Dim splitStr As ArrayList = Functions.ToArrayList(data(2).Trim, beforeChr)
            If splitStr.Count > 1 Then
                beforeStr = splitStr(0).ToString  'check for building number, if attached in the before string
                data(2) = splitStr(1).ToString
            Else
                Dim BuildingNumber = String.Empty
            End If

            splitStr = Functions.ToArrayList(data(2), " "c)
            If splitStr.Count > 0 Then
                If IsAStreetNumber(splitStr(0).ToString) Then
                    Dim BuildingNumber = splitStr(0).ToString
                    splitStr = splitStr.GetRange(1, splitStr.Count - 1)
                Else
                    Dim BuildingNumber = String.Empty
                End If
            Else
                Dim BuildingNumber = String.Empty
            End If

            If beforeStr > "" Then
                Dim StreetOne = beforeStr & beforeChr & Functions.ToString(splitStr, " ")
            Else
                Dim StreetOne = Functions.ToString(splitStr, " ")
            End If
        End If

        If Not data(3) Is Nothing Then Dim StreetTwo = data(3).Trim
        If Not data(4) Is Nothing Then Dim AreaOne = data(4).Trim
        If Not data(5) Is Nothing Then Dim AreaTwo = data(5).Trim
        If Not data(6) Is Nothing Then Dim PostCode = data(6).Trim
    End Sub

    Private Shared Function IsAStreetNumber(ByVal value As String) As Boolean
        Dim result As Boolean = False

        If Not value Is Nothing AndAlso value.Length > 0 Then
            If value.Length = 1 AndAlso IsNumeric(value) Then
                result = True
            ElseIf IsNumeric(value.Substring(0, value.Length - 1)) Then
                result = True
            End If

            If Not result Then
                Dim splitStr As ArrayList = Functions.ToArrayList(value, "-"c)

                If splitStr.Count = 2 AndAlso
                    IsNumeric(splitStr(0).ToString.Trim) AndAlso
                    IsNumeric(splitStr(1).ToString.Trim) Then
                    result = True
                End If
            End If
        End If

        Return result
    End Function
End Class
Public Class Functions
    Public Shared Function ToArrayList(ByVal list As String, ByVal delimiter As Char) As ArrayList
        Return ToArrayList(list, delimiter, True)
    End Function

    Public Shared Function ToArrayList(ByVal list As String, ByVal delimiter As Char, ByVal allowBlanks As Boolean) As ArrayList
        Dim result As New ArrayList

        Dim data() As String = list.Split(delimiter)
        For Each s As String In data
            If allowBlanks OrElse s.Trim.Length > 0 Then
                result.Add(s.Trim)
            End If
        Next

        Return result
    End Function

    Public Overloads Shared Function ToString(ByVal list As ArrayList, ByVal delimiter As String) As String
        Return ToString(list, delimiter, 0)
    End Function

    Public Overloads Shared Function ToString(ByVal list As ArrayList, ByVal delimiter As String, ByVal startIndex As Integer) As String
        Return ToString(list, delimiter, startIndex, -1)
    End Function

    Public Overloads Shared Function ToString(ByVal list As ArrayList, ByVal delimiter As String, ByVal startIndex As Integer, ByVal endIndex As Integer) As String
        Dim result As New StringBuilder

        If list.Count >= startIndex Then
            For idx As Integer = startIndex To list.Count - 1
                If idx > -1 OrElse idx < endIndex Then
                    If result.Length > 0 Then
                        result.Append(delimiter)
                    End If
                    result.Append(list(idx).ToString)
                End If
            Next
        End If

        Return result.ToString
    End Function
End Class

Public Class JSONConvert


    Private _Agency As String
    Public Property Agency() As String
        Get
            Return _Agency
        End Get
        Set(ByVal value As String)
            _Agency = value
        End Set
    End Property

    Private _CountVehicle As Int32
    Public Property CountVehicle() As Int32
        Get
            Return _CountVehicle
        End Get
        Set(ByVal value As Int32)
            _CountVehicle = value
        End Set
    End Property

    Private _ResType As String
    Public Property ResType() As String
        Get
            Return _ResType
        End Get
        Set(ByVal value As String)
            _ResType = value
        End Set
    End Property
End Class
