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

namespace Protocol.Xs
{
	public enum MessageType
	{
		Analysis1,
		Analysis2
	}

	public enum SampleNoAttr
	{
		ReadByReader = 4,
		NotReadByReader = 2,
		Other = 0
	}

	public enum AnalysisMode
	{
		Manual = 1,
		Sampler = 2,
		Capillary = 4
	}

	public enum AnalysisInfoError
	{
		None = 0,
		Error = 1
	}

	public enum SampleJudgmentInfo
	{
		Negative = 0,
		Positive = 1,
		Error = 2,
		PositiveAndError = 3,
		QcData = 'Q'
	}

	public enum BloodCellDiffData
	{
		Normal = 0,
		Abnormal = 1
	}

	public enum BloodCellMorphologicalData
	{
		Normal = 0,
		Abnormal = 1
	}

	public enum BloodCellCountData
	{
		Normal = 0,
		Abnormal = 1
	}

	public enum AnalysisError
	{
		None = 0,
		Error = 1
	}

	public enum AspirationRelatedError
	{
		None = 0,
		Error = 1
	}

	public enum OrderInformation
	{
		WithoutOrder = 0,
		ByOrder = 1
	}

	public enum UnitInformation
	{
		Other = 0,
		HollandSi = 1
	}

	public class Message
	{
		public MessageType Type { get; protected set; }


		protected Message( MessageType type )
		{
			this.Type = type;
		}

		protected static string Substring( string s, ref int index, int length )
		{
			var result = s.Substring( index, length );
			index += length;

			return result;
		}

		protected virtual void Deserialize( string data, ref int index )
		{
		}

		public static Message Deserialize( string data )
		{
			Message result = null;

			if (data.Length < 4)
			{
				return result;
			}

			if (data[0] != '\x02')
			{
				return result;
			}

			if (data.IndexOf( '\x03' ) < 0)
			{
				return result;
			}

			switch (data[1])
			{
				case 'D':
					if (data[2] == '1' && data[3] == 'U')
					{
						result = new MessageAnalysis1();
					}
					else if (data[2] == '2' && data[3] == 'U')
					{
						result = new MessageAnalysis2();
					}

					break;
			}

			if (result != null)
			{
				int index = 4;
				result.Deserialize( data, ref index );
			}

			return result;
		}
	}
}
