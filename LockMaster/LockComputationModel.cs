using System;
using System.Collections.Generic;

namespace LockMaster
{
	public class LockComputationModel
	{
		public int? FirstNotchPosition { get; set; }

		public int? SecondNotchPosition { get; set; }

		public double? ThirdNotchPosition { get; set; }

		public int? SolutionFirstValue
		{
			get
			{
				if (!ThirdNotchPosition.HasValue)
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(Math.Ceiling(ThirdNotchPosition.Value + 5) % 40);
				}
			}
		}

		public List<int> SolutionSecondValues
		{
			get
			{
				if(!SolutionFirstValue.HasValue)
				{
					return null;
				}

				List<int> _secondSolutionDigits = new List<int>();
				int mod = SolutionFirstValue.Value % 4;
				for (var i = 0; i < 10; i++)
				{
					var tmp = ((mod + 2) % 4) + (4 * i);
					if (!SelectedSolutionThirdDigitIndex.HasValue
						|| ((SolutionThirdValues[SelectedSolutionThirdDigitIndex.Value - 1] + 2) % 40 != tmp
						&& (SolutionThirdValues[SelectedSolutionThirdDigitIndex.Value - 1] - 2) % 40 != tmp))
					{
						_secondSolutionDigits.Add(tmp);
					}
				}
				return _secondSolutionDigits;
			}
		}

		public List<int> SolutionThirdValues
		{
			get
			{
				if (!FirstNotchPosition.HasValue || !SecondNotchPosition.HasValue || !SolutionFirstValue.HasValue)
				{
					return null;
				}
				List<int> _thirdSolutionDigits = new List<int>();
				int mod = SolutionFirstValue.Value % 4;
				for (int i = 0; i < 4; i++)
				{
					if (((10 * i) + FirstNotchPosition) % 4 == mod)
						_thirdSolutionDigits.Add((10 * i) + FirstNotchPosition.Value);

					if (((10 * i) + SecondNotchPosition) % 4 == mod)
						_thirdSolutionDigits.Add((10 * i) + SecondNotchPosition.Value);
				}
				return _thirdSolutionDigits;
			}
		}

		public int? SelectedSolutionThirdDigitIndex { get; set; }
	}
}
