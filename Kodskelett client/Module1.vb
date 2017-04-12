Imports Kodskelett_library
Module Module1

	Sub Main()
		'--- Creating the settings Object
		Dim oSettings As New Settings("https://theendpoint.com/Soap/ExternalEarkivDMZ.svc/Soap", "C:\certificate.pfx", "certPassword", "192.168.1.1")

		'--- Creating the client Object
		Dim oClient As New Client(oSettings)

		Console.WriteLine("Executing...")

		Dim lResult As Long = oClient.CountAips(CountAipsObject()) '--- Method located on SearchAips.vb

		Console.WriteLine("Total amount of Objects: " & lResult)

		Console.WriteLine("Finished the execution")
		Console.ReadLine()

	End Sub

End Module
