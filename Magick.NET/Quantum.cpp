//=================================================================================================
// Copyright 2013 Dirk Lemstra <http://magick.codeplex.com/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in 
// compliance with the License. You may obtain a copy of the License at
//
//   http://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied. See the License for the specific language governing permissions and
// limitations under the License.
//=================================================================================================
#include "Stdafx.h"
#include "Quantum.h"

namespace ImageMagick
{
	//==============================================================================================
	Magick::Quantum Quantum::Convert(Byte value)
	{
		return (Magick::Quantum) (257.0*value);
	}
	//==============================================================================================
	Magick::Quantum Quantum::Convert(double value)
	{
		return MagickCore::ClampToQuantum((Magick::Quantum)value);
	}
	//==============================================================================================
	Magick::Quantum Quantum::Convert(int value)
	{
		return MagickCore::ClampToQuantum((Magick::Quantum)value);
	}
	//==============================================================================================
	Magick::Quantum Quantum::Convert(long value)
	{
		return MagickCore::ClampToQuantum((Magick::Quantum)value);
	}
	//==============================================================================================
	Magick::Quantum Quantum::Convert(Magick::Quantum value)
	{
		return MagickCore::ClampToQuantum(value);
	}
	//==============================================================================================
	Magick::Quantum Quantum::Convert(short value)
	{
		return (Magick::Quantum) (2.0*value);
	}
	//==============================================================================================
	int Quantum::Depth::get()
	{
		return MAGICKCORE_QUANTUM_DEPTH;
	}
	//==============================================================================================
	Magick::Quantum Quantum::Max::get()
	{
		return (Magick::Quantum)QuantumRange;
	}
	//==============================================================================================
}