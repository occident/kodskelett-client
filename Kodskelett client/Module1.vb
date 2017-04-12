Imports Kodskelett_library
Module Module1

	Sub Main()
		'--- Creating the settings Object
		Dim oSettings As New Settings("https://theendpoint.com/Soap/ExternalEarkivDMZ.svc/Soap", "C:\certificate.pfx", "certPassword", "192.168.1.1")

		'--- Creating the client Object
		Dim oClient As New Client(oSettings)

		Console.WriteLine("Executing...")

		Dim oFileResponse As SSA.GetFileContentResponse = oClient.GetFileContentAsObject(123456)
		Dim oFileObject As SSA.File = oFileResponse.File

		Console.WriteLine("The name of the file is:" & oFileObject.DisplayName)

		Dim oFileContent As SSA.Content = oFileObject.Content
		System.IO.File.WriteAllBytes("C:\" & oFileObject.DisplayName, oFileContent.Data())


		Console.WriteLine("Finished the execution")
		Console.ReadLine()

	End Sub

End Module
