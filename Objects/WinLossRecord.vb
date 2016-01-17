Public Structure WinLossRecord
	Public Won As Int32
	Public Lost As Int32
	Public ReadOnly Property Total() As Int32
		Get
			Return Won + Lost
		End Get
	End Property
	Public ReadOnly Property Pct() As Double
		Get
			Return Won / Total
		End Get
	End Property
	Public Overrides Function ToString() As String
		Return String.Format("{0}-{1}", Won, Lost)
	End Function
End Structure
