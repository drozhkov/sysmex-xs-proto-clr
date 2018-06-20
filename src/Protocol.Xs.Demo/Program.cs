using System;

namespace Protocol.Xs.Demo
{
	class Program
	{
		static void Main( string[] args )
		{
			try
			{
				string data = "\x02" + @"D1U  XS-1000i^653020000000037000             2820180618161400      00012452136         01010000010000000000000000000000000000000000000000000000000000000000000000000000XS-1000^05342311^65302" + "\x03";
				var message = Message.Deserialize( data );

				Console.WriteLine( message.Type );

				if (message.Type == MessageType.Analysis1)
				{
					MessageAnalysis1 a1 = message as MessageAnalysis1;

					Console.WriteLine( a1.InstrumentId );
					Console.WriteLine( a1.SequenceNo );
					Console.WriteLine( a1.Date );
					Console.WriteLine( a1.AnalysisMode );
					Console.WriteLine( a1.PatientId );
					Console.WriteLine( a1.UnitInformation );
				}
			}
			catch (Exception x)
			{
				Console.Error.WriteLine( x );
			}
		}
	}
}
