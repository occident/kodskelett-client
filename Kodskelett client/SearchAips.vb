Imports Kodskelett_library

Module SearchAips

	''' <summary>
	''' This example will give you all the Aips inside Diarieförda ärenden 2009 – 2013 folder on iipax
	''' These are the mandatory parameters that need to be included in order for this to work
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function SearchAipObject() As SSA.SearchAips
		'--- The object that will be returned
		Dim oSearchAipResponse As New SSA.SearchAipsResponse

		Dim oSearchAip As New SSA.SearchAips
		Dim oQuery(0) As SSA.Query
		Dim oSearchCondition(0) As SSA.SearchCondition
		Dim oSearchConditionValue(0) As String

		oSearchAip.callerId = "EServiceArchiveSearch"

		oSearchCondition(0) = New SSA.SearchCondition
		oSearchCondition(0).Attribute = "created_by"
		oSearchCondition(0).Operator = SSA.Operator.MATCHES
		oSearchConditionValue(0) = "*"
		oSearchCondition(0).Value = oSearchConditionValue

		'--- Set up the SearchRootPath
		Dim strSearchRootPath(0) As String
		strSearchRootPath(0) = "|Stockholms Stad|Stockholm Vatten AB|Stockholm Vatten AB|Diarieförda ärenden 2009 – 2013"
		oSearchAip.SearchRootPath = strSearchRootPath

		oQuery(0) = New SSA.Query
		oQuery(0).type = SSA.QueryType.DESCENDANT
		oQuery(0).SearchCondition = oSearchCondition
		oSearchAip.Query = oQuery

		Return oSearchAip
	End Function

End Module
