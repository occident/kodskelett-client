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

		'--- Creating the main  Sip object
		Dim oArchiveSip As New SSA.ArchiveSip
		oArchiveSip.producer = "Occident"
		oArchiveSip.system = "MySystemName"


		'--- Creating the ArchiveObject 
		Dim oArchiveObject As New SSA.ArchiveObject
		oArchiveObject.DisplayName = "TheObject displayname"
		oArchiveObject.ObjectType = "ObjectType"

		'--- Adding the attributes of the object
		Dim oAttribute(0) As SSA.NameValue
		oAttribute(0).name = "description"
		Dim aString(0) As String
		aString(0) = "This could be a description"
		oAttribute(0).Value = aString
		'--- Appending the attributes array to the main object
		oArchiveObject.Attribute = oAttribute

		'--- If there is a file as well
		Dim oFile(0) As SSA.File
		oFile(0).DisplayName = "Thefilename.jpg"
		oFile(0).ObjectType = "The file objectType"

		Dim oFileContent As New SSA.Content
		oFileContent.Data = System.IO.File.ReadAllBytes("C:\Thefilename.jpg")
		oFileContent.digest = "SHA123456789"

		'--- Appending the Byte array to the File Object
		oFile(0).Content = oFileContent

		'--- Appending the File item to the ArchiveObject
		oArchiveObject.Items = oFile

		'--- Appending the ArchiveObject to the Sip object
		oArchiveSip.ArchiveObject = oArchiveObject

		oClient.ArchiveSip(oArchiveSip)

		Console.WriteLine("Finished the execution")
		Console.ReadLine()

	End Sub

End Module