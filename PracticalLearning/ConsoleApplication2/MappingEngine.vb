Imports System.Xml

Module MappingEngine
    Sub Main()
        Dim pkt As String = "PSI!CI!<incident_no>!<report_date>!<incident_date>!<FCL_URN>!<MapBookRef>!<stop_datetime>!<patrol_mode>!<type>!<agency>!<status>!<vehicle_count>!<hide_flag>!<alert_level>!<alert_level_text>"

        Dim 

        ''''''SourceField:SourceDataType::DestinationField:DestinationDataType
        Dim m1 As String = "incident_no:int::Incident:Number"
        Dim m2 As String = "street:varchar(255)::Incident.Address:StreetOne"

        Dim xml As String = "<book>
                                <value>incident_no:int::Incident:Number</value>
                                <value>street:varchar(255)::Incident.Address:StreetOne</value>
                            </book>"
        Try
            Dim xmlFile As New System.IO.StringReader(xml)
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1



            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try








    End Sub


    Public Class Incident
        Public Property Number() As String
        Public Property Address() As Address
    End Class

    Public Class Address
        Public Property StreetOne() As String
    End Class


End Module
