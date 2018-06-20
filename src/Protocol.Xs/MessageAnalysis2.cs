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
	public class MessageAnalysis2 : Message
	{
		public MessageAnalysis2() : base( MessageType.Analysis2 )
		{
		}
	}
}
