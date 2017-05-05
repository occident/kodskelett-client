Imports Kodskelett_library

Module CountAips
	''' <summary>
	''' This example will give you all the number of Aips inside Stockholms Stad's folder on iipax which include an ObjectType of 248_Ärende_v2
	''' These are the mandatory parameters that need to be included in order for this to work
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function CountAipsObject() As SSA.CountAips
		Dim oCountAips As New SSA.CountAips
		Dim oQuery(0) As SSA.Query

		Dim oSearchCondition(0) As SSA.SearchCondition
		Dim oSearchConditionValue(0) As String
		Dim objectType(0) As String
		objectType(0) = "248_Ärende_v2"

		'--- Set up the Query
		oQuery(0) = New SSA.Query
		oQuery(0).ObjectType = objectType
		oQuery(0).type = SSA.QueryType.DESCENDANT
		oQuery(0).typeSpecified = False

		'--- Set up the SearchCondition
		oSearchCondition(0) = New SSA.SearchCondition
		oSearchCondition(0).Attribute = "display_name"
		oSearchCondition(0).Operator = SSA.Operator.MATCHES
		oSearchConditionValue(0) = "Diarieärende*"
		oSearchCondition(0).Value = oSearchConditionValue
		oQuery(0).SearchCondition = oSearchCondition

		'--- Set up the SearchRootPath
		Dim strSearchRootPath(0) As String
		strSearchRootPath(0) = "|Stockholms Stad"
		oCountAips.SearchRootPath = strSearchRootPath


		oCountAips.Query = oQuery
		oCountAips.callerId = "EServiceArchiveSearch"

		Return oCountAips
	End Function
End Module
