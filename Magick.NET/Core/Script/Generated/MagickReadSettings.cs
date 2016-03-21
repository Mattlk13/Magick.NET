//=================================================================================================
// Copyright 2013-2016 Dirk Lemstra <https://magick.codeplex.com/>
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
  public sealed partial class MagickScript
  {
    [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
    private void ExecuteMagickReadSettings(XmlElement element, MagickReadSettings readSettings)
    {
      switch(element.Name[0])
      {
        case 'b':
        {
          switch(element.Name[1])
          {
            case 'a':
            {
              ExecuteBackgroundColor(element, readSettings);
              return;
            }
            case 'o':
            {
              ExecuteBorderColor(element, readSettings);
              return;
            }
          }
          break;
        }
        case 'c':
        {
          switch(element.Name[2])
          {
            case 'l':
            {
              switch(element.Name[5])
              {
                case 'S':
                {
                  ExecuteColorSpace(element, readSettings);
                  return;
                }
                case 'T':
                {
                  ExecuteColorType(element, readSettings);
                  return;
                }
              }
              break;
            }
            case 'm':
            {
              ExecuteCompressionMethod(element, readSettings);
              return;
            }
          }
          break;
        }
        case 'd':
        {
          switch(element.Name[2])
          {
            case 'b':
            {
              ExecuteDebug(element, readSettings);
              return;
            }
            case 'f':
            {
              ExecuteDefines(element, readSettings);
              return;
            }
            case 'n':
            {
              ExecuteDensity(element, readSettings);
              return;
            }
          }
          break;
        }
        case 'e':
        {
          ExecuteEndian(element, readSettings);
          return;
        }
        case 'f':
        {
          switch(element.Name[1])
          {
            case 'i':
            {
              switch(element.Name[4])
              {
                case 'C':
                {
                  ExecuteFillColor(element, readSettings);
                  return;
                }
                case 'P':
                {
                  ExecuteFillPattern(element, readSettings);
                  return;
                }
                case 'R':
                {
                  ExecuteFillRule(element, readSettings);
                  return;
                }
              }
              break;
            }
            case 'o':
            {
              switch(element.Name[2])
              {
                case 'n':
                {
                  if (element.Name.Length == 4)
                  {
                    ExecuteFont(element, readSettings);
                    return;
                  }
                  switch(element.Name[4])
                  {
                    case 'F':
                    {
                      ExecuteFontFamily(element, readSettings);
                      return;
                    }
                    case 'P':
                    {
                      ExecuteFontPointsize(element, readSettings);
                      return;
                    }
                    case 'S':
                    {
                      ExecuteFontStyle(element, readSettings);
                      return;
                    }
                    case 'W':
                    {
                      ExecuteFontWeight(element, readSettings);
                      return;
                    }
                  }
                  break;
                }
                case 'r':
                {
                  ExecuteFormat(element, readSettings);
                  return;
                }
              }
              break;
            }
            case 'r':
            {
              switch(element.Name[5])
              {
                case 'C':
                {
                  ExecuteFrameCount(element, readSettings);
                  return;
                }
                case 'I':
                {
                  ExecuteFrameIndex(element, readSettings);
                  return;
                }
              }
              break;
            }
          }
          break;
        }
        case 'h':
        {
          ExecuteHeight(element, readSettings);
          return;
        }
        case 'p':
        {
          switch(element.Name[1])
          {
            case 'a':
            {
              ExecutePage(element, readSettings);
              return;
            }
            case 'i':
            {
              ExecutePixelStorage(element, readSettings);
              return;
            }
          }
          break;
        }
        case 's':
        {
          switch(element.Name[1])
          {
            case 't':
            {
              switch(element.Name[6])
              {
                case 'A':
                {
                  ExecuteStrokeAntiAlias(element, readSettings);
                  return;
                }
                case 'C':
                {
                  ExecuteStrokeColor(element, readSettings);
                  return;
                }
                case 'D':
                {
                  switch(element.Name[10])
                  {
                    case 'A':
                    {
                      ExecuteStrokeDashArray(element, readSettings);
                      return;
                    }
                    case 'O':
                    {
                      ExecuteStrokeDashOffset(element, readSettings);
                      return;
                    }
                  }
                  break;
                }
                case 'L':
                {
                  switch(element.Name[10])
                  {
                    case 'C':
                    {
                      ExecuteStrokeLineCap(element, readSettings);
                      return;
                    }
                    case 'J':
                    {
                      ExecuteStrokeLineJoin(element, readSettings);
                      return;
                    }
                  }
                  break;
                }
                case 'M':
                {
                  ExecuteStrokeMiterLimit(element, readSettings);
                  return;
                }
                case 'P':
                {
                  ExecuteStrokePattern(element, readSettings);
                  return;
                }
                case 'W':
                {
                  ExecuteStrokeWidth(element, readSettings);
                  return;
                }
              }
              break;
            }
            case 'e':
            {
              if (element.Name.Length == 9)
              {
                ExecuteSetDefine(element, readSettings);
                return;
              }
              if (element.Name.Length == 10)
              {
                ExecuteSetDefines(element, readSettings);
                return;
              }
              break;
            }
          }
          break;
        }
        case 't':
        {
          switch(element.Name[4])
          {
            case 'A':
            {
              ExecuteTextAntiAlias(element, readSettings);
              return;
            }
            case 'D':
            {
              ExecuteTextDirection(element, readSettings);
              return;
            }
            case 'E':
            {
              ExecuteTextEncoding(element, readSettings);
              return;
            }
            case 'G':
            {
              ExecuteTextGravity(element, readSettings);
              return;
            }
            case 'I':
            {
              switch(element.Name[9])
              {
                case 'l':
                {
                  ExecuteTextInterlineSpacing(element, readSettings);
                  return;
                }
                case 'w':
                {
                  ExecuteTextInterwordSpacing(element, readSettings);
                  return;
                }
              }
              break;
            }
            case 'K':
            {
              ExecuteTextKerning(element, readSettings);
              return;
            }
            case 'U':
            {
              ExecuteTextUnderColor(element, readSettings);
              return;
            }
          }
          break;
        }
        case 'u':
        {
          ExecuteUseMonochrome(element, readSettings);
          return;
        }
        case 'v':
        {
          ExecuteVerbose(element, readSettings);
          return;
        }
        case 'w':
        {
          ExecuteWidth(element, readSettings);
          return;
        }
        case 'r':
        {
          ExecuteRemoveDefine(element, readSettings);
          return;
        }
      }
      throw new NotImplementedException(element.Name);
    }
    private void ExecuteBackgroundColor(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.BackgroundColor = Variables.GetValue<MagickColor>(element, "value");
    }
    private void ExecuteBorderColor(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.BorderColor = Variables.GetValue<MagickColor>(element, "value");
    }
    private void ExecuteColorSpace(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.ColorSpace = Variables.GetValue<ColorSpace>(element, "value");
    }
    private void ExecuteColorType(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.ColorType = Variables.GetValue<ColorType>(element, "value");
    }
    private void ExecuteCompressionMethod(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.CompressionMethod = Variables.GetValue<CompressionMethod>(element, "value");
    }
    private void ExecuteDebug(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Debug = Variables.GetValue<Boolean>(element, "value");
    }
    private void ExecuteDefines(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Defines = CreateIReadDefines(element);
    }
    private void ExecuteDensity(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Density = Variables.GetValue<Density>(element, "value");
    }
    private void ExecuteEndian(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Endian = Variables.GetValue<Endian>(element, "value");
    }
    private void ExecuteFillColor(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FillColor = Variables.GetValue<MagickColor>(element, "value");
    }
    private void ExecuteFillPattern(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FillPattern = CreateMagickImage(element);
    }
    private void ExecuteFillRule(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FillRule = Variables.GetValue<FillRule>(element, "value");
    }
    private void ExecuteFont(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Font = Variables.GetValue<String>(element, "value");
    }
    private void ExecuteFontFamily(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FontFamily = Variables.GetValue<String>(element, "value");
    }
    private void ExecuteFontPointsize(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FontPointsize = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteFontStyle(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FontStyle = Variables.GetValue<FontStyleType>(element, "value");
    }
    private void ExecuteFontWeight(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FontWeight = Variables.GetValue<FontWeight>(element, "value");
    }
    private void ExecuteFormat(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Format = Variables.GetValue<MagickFormat>(element, "value");
    }
    private void ExecuteFrameCount(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FrameCount = Variables.GetValue<Nullable<Int32>>(element, "value");
    }
    private void ExecuteFrameIndex(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.FrameIndex = Variables.GetValue<Nullable<Int32>>(element, "value");
    }
    private void ExecuteHeight(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Height = Variables.GetValue<Nullable<Int32>>(element, "value");
    }
    private void ExecutePage(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Page = Variables.GetValue<MagickGeometry>(element, "value");
    }
    private void ExecutePixelStorage(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.PixelStorage = CreatePixelStorageSettings(element[""]);
    }
    private void ExecuteStrokeAntiAlias(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeAntiAlias = Variables.GetValue<Boolean>(element, "value");
    }
    private void ExecuteStrokeColor(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeColor = Variables.GetValue<MagickColor>(element, "value");
    }
    private void ExecuteStrokeDashArray(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeDashArray = Variables.GetDoubleArray(element);
    }
    private void ExecuteStrokeDashOffset(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeDashOffset = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteStrokeLineCap(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeLineCap = Variables.GetValue<LineCap>(element, "value");
    }
    private void ExecuteStrokeLineJoin(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeLineJoin = Variables.GetValue<LineJoin>(element, "value");
    }
    private void ExecuteStrokeMiterLimit(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeMiterLimit = Variables.GetValue<Int32>(element, "value");
    }
    private void ExecuteStrokePattern(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokePattern = CreateMagickImage(element);
    }
    private void ExecuteStrokeWidth(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.StrokeWidth = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteTextAntiAlias(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextAntiAlias = Variables.GetValue<Boolean>(element, "value");
    }
    private void ExecuteTextDirection(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextDirection = Variables.GetValue<TextDirection>(element, "value");
    }
    private void ExecuteTextEncoding(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextEncoding = Variables.GetValue<Encoding>(element, "value");
    }
    private void ExecuteTextGravity(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextGravity = Variables.GetValue<Gravity>(element, "value");
    }
    private void ExecuteTextInterlineSpacing(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextInterlineSpacing = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteTextInterwordSpacing(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextInterwordSpacing = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteTextKerning(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextKerning = Variables.GetValue<double>(element, "value");
    }
    private void ExecuteTextUnderColor(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.TextUnderColor = Variables.GetValue<MagickColor>(element, "value");
    }
    private void ExecuteUseMonochrome(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.UseMonochrome = Variables.GetValue<Boolean>(element, "value");
    }
    private void ExecuteVerbose(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Verbose = Variables.GetValue<Boolean>(element, "value");
    }
    private void ExecuteWidth(XmlElement element, MagickReadSettings readSettings)
    {
      readSettings.Width = Variables.GetValue<Nullable<Int32>>(element, "value");
    }
    private void ExecuteRemoveDefine(XmlElement element, MagickReadSettings readSettings)
    {
      MagickFormat format_ = Variables.GetValue<MagickFormat>(element, "format");
      String name_ = Variables.GetValue<String>(element, "name");
      readSettings.RemoveDefine(format_, name_);
    }
    private void ExecuteSetDefine(XmlElement element, MagickReadSettings readSettings)
    {
      Hashtable arguments = new Hashtable();
      foreach (XmlAttribute attribute in element.Attributes)
      {
        if (attribute.Name == "flag")
          arguments["flag"] = Variables.GetValue<Boolean>(attribute);
        else if (attribute.Name == "format")
          arguments["format"] = Variables.GetValue<MagickFormat>(attribute);
        else if (attribute.Name == "name")
          arguments["name"] = Variables.GetValue<String>(attribute);
        else if (attribute.Name == "value")
          arguments["value"] = Variables.GetValue<String>(attribute);
      }
      if (OnlyContains(arguments, "format", "name", "flag"))
        readSettings.SetDefine((MagickFormat)arguments["format"], (String)arguments["name"], (Boolean)arguments["flag"]);
      else if (OnlyContains(arguments, "format", "name", "value"))
        readSettings.SetDefine((MagickFormat)arguments["format"], (String)arguments["name"], (String)arguments["value"]);
      else
        throw new ArgumentException("Invalid argument combination for 'setDefine', allowed combinations are: [format, name, flag] [format, name, value]");
    }
    private void ExecuteSetDefines(XmlElement element, MagickReadSettings readSettings)
    {
      IDefines defines_ = CreateIDefines(element["defines"]);
      readSettings.SetDefines(defines_);
    }
  }
}
