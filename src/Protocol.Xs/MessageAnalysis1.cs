/*   sysmex-xs-proto-clr is a Sysmex XS-series data communication protocol implementation
*    Copyright (C) 2018 Denis Rozhkov <denis@rozhkoff.com>
*
*    This program is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 3 of the License, or
*    (at your option) any later version.
*
*    This program is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with this program. If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace Protocol.Xs
{
	public class MessageAnalysis1 : Message
	{
		public string InstrumentId { get; protected set; }
		public string SequenceNo { get; protected set; }
		public string SampleId { get; protected set; }
		public DateTime Date { get; protected set; }
		public string RackNo { get; protected set; }
		public string TubePosition { get; protected set; }
		public SampleNoAttr SampleNoAttr { get; protected set; }
		public AnalysisMode AnalysisMode { get; protected set; }
		public string PatientId { get; protected set; }
		public AnalysisInfoError AnalysisInfoError { get; protected set; }
		public SampleJudgmentInfo SampleJudgmentInfo { get; protected set; }
		public BloodCellDiffData BloodCellDiffData { get; protected set; }
		public BloodCellMorphologicalData BloodCellMorphologicalData { get; protected set; }
		public BloodCellCountData BloodCellCountData { get; protected set; }
		public AnalysisError AnalysisError { get; protected set; }
		public AspirationRelatedError AspirationRelatedError { get; protected set; }
		public OrderInformation OrderInformation { get; protected set; }

		public bool IsWbcAbnormal { get; protected set; }
		public bool IsWbcSuspect { get; protected set; }
		public bool IsRbcAbnormal { get; protected set; }
		public bool IsRbcSuspect { get; protected set; }
		public bool IsPltAbnormal { get; protected set; }
		public bool IsPltSuspect { get; protected set; }

		public UnitInformation UnitInformation { get; protected set; }


		public MessageAnalysis1() : base( MessageType.Analysis1 )
		{
		}

		protected override void Deserialize( string data, ref int index )
		{
			if (data.Length - index < 186)
			{
				throw new Exception( "invalid data" );
			}

			this.InstrumentId = Substring( data, ref index, 16 );
			this.SequenceNo = Substring( data, ref index, 10 );
			Substring( data, ref index, 3 );
			this.SampleId = Substring( data, ref index, 15 );
			this.Date = new DateTime(
				int.Parse( Substring( data, ref index, 4 ) )
				, int.Parse( Substring( data, ref index, 2 ) )
				, int.Parse( Substring( data, ref index, 2 ) )
				, int.Parse( Substring( data, ref index, 2 ) )
				, int.Parse( Substring( data, ref index, 2 ) )
				, 0
				);

			Substring( data, ref index, 2 );
			this.RackNo = Substring( data, ref index, 6 );
			this.TubePosition = Substring( data, ref index, 2 );
			this.SampleNoAttr = (SampleNoAttr)(int.Parse( Substring( data, ref index, 1 ) ));
			this.AnalysisMode = (AnalysisMode)(int.Parse( Substring( data, ref index, 1 ) ));
			this.PatientId = Substring( data, ref index, 16 );
			this.AnalysisInfoError = (AnalysisInfoError)(int.Parse( Substring( data, ref index, 1 ) ));
			this.SampleJudgmentInfo = (SampleJudgmentInfo)(int.Parse( Substring( data, ref index, 1 ) ));
			this.BloodCellDiffData = (BloodCellDiffData)(int.Parse( Substring( data, ref index, 1 ) ));
			this.BloodCellMorphologicalData = (BloodCellMorphologicalData)(int.Parse( Substring( data, ref index, 1 ) ));
			this.BloodCellCountData = (BloodCellCountData)(int.Parse( Substring( data, ref index, 1 ) ));
			this.AnalysisError = (AnalysisError)(int.Parse( Substring( data, ref index, 1 ) ));
			this.AspirationRelatedError = (AspirationRelatedError)(int.Parse( Substring( data, ref index, 1 ) ));
			this.OrderInformation = (OrderInformation)(int.Parse( Substring( data, ref index, 1 ) ));

			this.IsWbcAbnormal = (int.Parse( Substring( data, ref index, 1 ) ) == 1);
			this.IsWbcSuspect = (int.Parse( Substring( data, ref index, 1 ) ) == 1);
			this.IsRbcAbnormal = (int.Parse( Substring( data, ref index, 1 ) ) == 1);
			this.IsRbcSuspect = (int.Parse( Substring( data, ref index, 1 ) ) == 1);
			this.IsPltAbnormal = (int.Parse( Substring( data, ref index, 1 ) ) == 1);
			this.IsPltSuspect = (int.Parse( Substring( data, ref index, 1 ) ) == 1);

			this.UnitInformation = (UnitInformation)(int.Parse( Substring( data, ref index, 1 ) ));
		}
	}
}
