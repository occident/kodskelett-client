Imports Kodskelett_library
Module Module1

	Sub Main()
		'--- Creating the settings Object
		Dim oSettings As New Settings("https://theendpoint.com/Soap/ExternalEarkivDMZ.svc/Soap", "C:\certificate.pfx", "certPassword", "192.168.1.1")

		'--- Enable advanced log file to see what exactly happens on the background
		oSettings.advancedLog = True

		'--- Creating a custom logger file
		Dim oExecutionResults As New Logger("C:\Output", "execution.txt")

		'--- Creating the client Object
		Dim oClient As New Client(oSettings, oExecutionResults)

		Console.WriteLine("Executing...")

		Dim oResponseObject As SSA.ArchiveObject = oClient.GetAipAsObject(123456).ArchiveObject

		oExecutionResults.Log("Display Name:" & oResponseObject.DisplayName)
		oExecutionResults.Log("Object type:" & oResponseObject.ObjectType)

		oExecutionResults.Log("The items of this object are: ")
		For Each i In oResponseObject.Items
			oExecutionResults.Log("Display Name:" & i.DisplayName)
			oExecutionResults.Log("Object type:" & i.ObjectType)
		Next

		Console.WriteLine("Finished the execution")
		Console.ReadLine()

	End Sub

End Module
