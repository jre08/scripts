﻿// https://github.com/nick-buhro/Translit/tree/master/NickBuhro.Translit

/*
The MIT License (MIT)

Copyright (c) 2016 Nicholas Buhro

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;

/// <summary>
/// Slavik language with cyrillic alphabet.
/// </summary>
public enum Language
{
	/// <summary>
	/// Unknown language. Most common rules will be used for transliteration.
	/// </summary>
	Unknown,

	/// <summary>
	/// Russain language.
	/// </summary>
	Russian,

	/// <summary>
	/// Belorussian language.
	/// </summary>
	Belorussian,

	/// <summary>
	/// Ukranian language.
	/// </summary>
	Ukrainian,

	/// <summary>
	/// Bulgarian language.
	/// </summary>
	Bulgarian,

	/// <summary>
	/// Macedonian language.
	/// </summary>
	Macedonian
}

/// <summary>
///  Cyrillic-latin transliteration (support only slavik languages) by GOST 7.79-2000 (ISO 9).
/// </summary>
public static class Transliteration
{	
	/// <summary>
	/// Transliterate cyrillic string to latin.
	/// </summary>
	/// <param name="cyrillicSource">Source string.</param>
	/// <param name="language">Specify it to determine correct transliteration rules (it can be a little bit different for languages).</param>
	/// <returns>Transliterated string.</returns>
	public static string CyrillicToLatin(string cyrillicSource, Language language = Language.Unknown)
	{
		if (string.IsNullOrEmpty(cyrillicSource))
				return cyrillicSource;

		switch (language)
		{
				case Language.Unknown:
				case Language.Russian:
					return CyrillicToLatinRussian(cyrillicSource);
				case Language.Belorussian:
					return CyrillicToLatinBelorussian(cyrillicSource);
				case Language.Ukrainian:
					return CyrillicToLatinUkrainian(cyrillicSource);
				case Language.Bulgarian:
					return CyrillicToLatinBulgarian(cyrillicSource);
				case Language.Macedonian:
					return CyrillicToLatinMacedonian(cyrillicSource);
		}

		throw new NotSupportedException();
	}

	/// <summary>
	/// Transliterate latin string to cyrillic.
	/// </summary>
	/// <param name="latinSource">Source string.</param>
	/// <param name="language">Specify it to determine correct transliteration rules (it can be a little bit different for languages).</param>
	/// <returns>Cyrillic string.</returns>
	public static string LatinToCyrillic(string latinSource, Language language = Language.Unknown)
	{
		if (string.IsNullOrEmpty(latinSource))
				return latinSource;

		switch (language)
		{
				case Language.Unknown:
				case Language.Russian:
					return LatinToCyrillicRussian(latinSource);
				case Language.Belorussian:
					return LatinToCyrillicBelorussian(latinSource);
				case Language.Ukrainian:
					return LatinToCyrillicUkrainian(latinSource);
				case Language.Bulgarian:
					return LatinToCyrillicBulgarian(latinSource);
				case Language.Macedonian:
					return LatinToCyrillicMacedonian(latinSource);
		}

		throw new NotSupportedException();
	}

	private struct CustomStringBuilder
	{
		private readonly char[] _array;
		private int _index;

		public CustomStringBuilder(int capacity)
		{
				_array = new char[capacity];
				_index = 0;
		}

		public void Append(char c)
		{
				_array[_index++] = c;
		}

		public override string ToString()
		{
				return new string(_array, 0, _index);
		}
	}

	private static string CyrillicToLatinRussian(string text)
	{
		var sb = new CustomStringBuilder(text.Length * 3);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case 'Ё':
									sb.Append('Y');
									sb.Append('o');
									break;
								case 'А':
									sb.Append('A');
									break;
								case 'Б':
									sb.Append('B');
									break;
								case 'В':
									sb.Append('V');
									break;
								case 'Г':
									sb.Append('G');
									break;
								case 'Д':
									sb.Append('D');
									break;
								case 'Е':
									sb.Append('E');
									break;
								case 'Ж':
									sb.Append('Z');
									sb.Append('h');
									break;
								case 'З':
									sb.Append('Z');
									break;
								case 'И':
									sb.Append('I');
									break;
								case 'Й':
									sb.Append('J');
									break;
								case 'К':
									sb.Append('K');
									break;
								case 'Л':
									sb.Append('L');
									break;
								case 'М':
									sb.Append('M');
									break;
								case 'Н':
									sb.Append('N');
									break;
								case 'О':
									sb.Append('O');
									break;
								case 'П':
									sb.Append('P');
									break;
								case 'Р':
									sb.Append('R');
									break;
								case 'С':
									sb.Append('S');
									break;
								case 'Т':
									sb.Append('T');
									break;
								case 'У':
									sb.Append('U');
									break;
								case 'Ф':
									sb.Append('F');
									break;
								case 'Х':
									sb.Append('X');
									break;
								case 'Ц':
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('h');
									break;
								case 'Ш':
									sb.Append('S');
									sb.Append('h');
									break;
								case 'Щ':
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									break;
								case 'Ъ':
									sb.Append('`');
									sb.Append('`');
									break;
								case 'Ы':
									sb.Append('Y');
									sb.Append('`');
									break;
								case 'Ь':
									sb.Append('`');
									break;
								case 'Э':
									sb.Append('E');
									sb.Append('`');
									break;
								case 'Ю':
									sb.Append('Y');
									sb.Append('u');
									break;
								case 'Я':
									sb.Append('Y');
									sb.Append('a');
									break;
								case 'а':
									sb.Append('a');
									break;
								case 'б':
									sb.Append('b');
									break;
								case 'в':
									sb.Append('v');
									break;
								case 'г':
									sb.Append('g');
									break;
								case 'д':
									sb.Append('d');
									break;
								case 'е':
									sb.Append('e');
									break;
								case 'ж':
									sb.Append('z');
									sb.Append('h');
									break;
								case 'з':
									sb.Append('z');
									break;
								case 'и':
									sb.Append('i');
									break;
								case 'й':
									sb.Append('j');
									break;
								case 'к':
									sb.Append('k');
									break;
								case 'л':
									sb.Append('l');
									break;
								case 'м':
									sb.Append('m');
									break;
								case 'н':
									sb.Append('n');
									break;
								case 'о':
									sb.Append('o');
									break;
								case 'п':
									sb.Append('p');
									break;
								case 'р':
									sb.Append('r');
									break;
								case 'с':
									sb.Append('s');
									break;
								case 'т':
									sb.Append('t');
									break;
								case 'у':
									sb.Append('u');
									break;
								case 'ф':
									sb.Append('f');
									break;
								case 'х':
									sb.Append('x');
									break;
								case 'ц':
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('h');
									break;
								case 'ш':
									sb.Append('s');
									sb.Append('h');
									break;
								case 'щ':
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									break;
								case 'ъ':
									sb.Append('`');
									sb.Append('`');
									break;
								case 'ы':
									sb.Append('y');
									sb.Append('`');
									break;
								case 'ь':
									sb.Append('`');
									break;
								case 'э':
									sb.Append('e');
									sb.Append('`');
									break;
								case 'ю':
									sb.Append('y');
									sb.Append('u');
									break;
								case 'я':
									sb.Append('y');
									sb.Append('a');
									break;
								case 'ё':
									sb.Append('y');
									sb.Append('o');
									break;
								case 'Ѣ':
									sb.Append('Y');
									sb.Append('e');
									break;
								case 'ѣ':
									sb.Append('y');
									sb.Append('e');
									break;
								case 'Ѳ':
									sb.Append('F');
									sb.Append('h');
									break;
								case 'ѳ':
									sb.Append('f');
									sb.Append('h');
									break;
								case 'Ѵ':
									sb.Append('Y');
									sb.Append('h');
									break;
								case 'ѵ':
									sb.Append('y');
									sb.Append('h');
									break;
								case '’':
									sb.Append('\'');
									break;
								case '№':
									sb.Append('#');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "ц"
						switch (c)
						{
								case 'Ё':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('c');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('c');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('c');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('c');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('c');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('c');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('c');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('c');
									sb.Append('z');
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ъ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ы':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Э':
									sb.Append('c');
									sb.Append('E');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('c');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('c');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('c');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('c');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('c');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('c');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('c');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('c');
									sb.Append('z');
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ъ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ы':
									sb.Append('c');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'э':
									sb.Append('c');
									sb.Append('e');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('c');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('c');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'ё':
									sb.Append('c');
									sb.Append('y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'Ѣ':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ѣ':
									sb.Append('c');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ѳ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѳ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ѵ':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѵ':
									sb.Append('c');
									sb.Append('y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('c');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('c');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('c');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "Ц"
						switch (c)
						{
								case 'Ё':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('C');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('C');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('C');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('C');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('C');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('C');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('C');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('C');
									sb.Append('z');
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ъ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ы':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Э':
									sb.Append('C');
									sb.Append('E');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('C');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('C');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('C');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('C');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('C');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('C');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('C');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('C');
									sb.Append('z');
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ъ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ы':
									sb.Append('C');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'э':
									sb.Append('C');
									sb.Append('e');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('C');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('C');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'ё':
									sb.Append('C');
									sb.Append('y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'Ѣ':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ѣ':
									sb.Append('C');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ѳ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѳ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ѵ':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѵ':
									sb.Append('C');
									sb.Append('y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('C');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('C');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('C');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "ц"
					sb.Append('c');
					sb.Append('z');
					break;
				case 2: // "Ц"
					sb.Append('C');
					sb.Append('z');
					break;
		}
		return sb.ToString();
	}

	private static string LatinToCyrillicRussian(string text)
	{
		var sb = new CustomStringBuilder(text.Length);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case '#':
									sb.Append('№');
									break;
								case '\'':
									sb.Append('’');
									break;
								case 'A':
									sb.Append('А');
									break;
								case 'B':
									sb.Append('Б');
									break;
								case 'C':
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('Д');
									break;
								case 'E':
									state = 5;  // "E"
									break;
								case 'F':
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('Г');
									break;
								case 'I':
									sb.Append('И');
									break;
								case 'J':
									sb.Append('Й');
									break;
								case 'K':
									sb.Append('К');
									break;
								case 'L':
									sb.Append('Л');
									break;
								case 'M':
									sb.Append('М');
									break;
								case 'N':
									sb.Append('Н');
									break;
								case 'O':
									sb.Append('О');
									break;
								case 'P':
									sb.Append('П');
									break;
								case 'R':
									sb.Append('Р');
									break;
								case 'S':
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Т');
									break;
								case 'U':
									sb.Append('У');
									break;
								case 'V':
									sb.Append('В');
									break;
								case 'X':
									sb.Append('Х');
									break;
								case 'Y':
									state = 11; // "Y"
									break;
								case 'Z':
									state = 13; // "Z"
									break;
								case '`':
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('а');
									break;
								case 'b':
									sb.Append('б');
									break;
								case 'c':
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('д');
									break;
								case 'e':
									state = 4;  // "e"
									break;
								case 'f':
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('г');
									break;
								case 'i':
									sb.Append('и');
									break;
								case 'j':
									sb.Append('й');
									break;
								case 'k':
									sb.Append('к');
									break;
								case 'l':
									sb.Append('л');
									break;
								case 'm':
									sb.Append('м');
									break;
								case 'n':
									sb.Append('н');
									break;
								case 'o':
									sb.Append('о');
									break;
								case 'p':
									sb.Append('п');
									break;
								case 'r':
									sb.Append('р');
									break;
								case 's':
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('т');
									break;
								case 'u':
									sb.Append('у');
									break;
								case 'v':
									sb.Append('в');
									break;
								case 'x':
									sb.Append('х');
									break;
								case 'y':
									state = 10; // "y"
									break;
								case 'z':
									state = 12; // "z"
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "`"
						switch (c)
						{
								case '#':
									sb.Append('ь');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ь');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ь');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ь');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ь');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('ь');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ь');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('ь');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('ь');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ь');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ь');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ь');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ь');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ь');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ь');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ь');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ь');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ь');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ь');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('ь');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ь');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ь');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ь');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ь');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('ь');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('ъ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ь');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ь');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ь');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('ь');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ь');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('ь');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('ь');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ь');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ь');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ь');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ь');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ь');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ь');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ь');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ь');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ь');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ь');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('ь');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ь');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ь');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ь');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ь');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('ь');
									state = 12; // "z"
									break;
								default:
									sb.Append('ь');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "c"
						switch (c)
						{
								case '#':
									sb.Append('ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ц');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ц');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('ц');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ц');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ц');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('ц');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('ц');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ц');
									break;
								case 'd':
									sb.Append('ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ц');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('ц');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('ц');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ц');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ц');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 3: // "C"
						switch (c)
						{
								case '#':
									sb.Append('Ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ц');
									break;
								case 'D':
									sb.Append('Ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ц');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('Ц');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('Ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ц');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ц');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('Ц');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('Ц');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('Ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ц');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('Ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ц');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('Ц');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('Ц');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ц');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('Ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ц');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('Ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('Ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 4: // "e"
						switch (c)
						{
								case '#':
									sb.Append('е');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('е');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('е');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('е');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('е');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('е');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('е');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('е');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('е');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('е');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('е');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('е');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('е');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('е');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('е');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('е');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('е');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('е');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('е');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('е');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('е');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('е');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('е');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('е');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('е');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('э');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('е');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('е');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('е');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('е');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('е');
									break;
								case 'f':
									sb.Append('е');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('е');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('е');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('е');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('е');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('е');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('е');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('е');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('е');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('е');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('е');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('е');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('е');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('е');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('е');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('е');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('е');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('е');
									state = 12; // "z"
									break;
								default:
									sb.Append('е');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 5: // "E"
						switch (c)
						{
								case '#':
									sb.Append('Е');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Е');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Е');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Е');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Е');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('Е');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Е');
									break;
								case 'F':
									sb.Append('Е');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('Е');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Е');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Е');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Е');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Е');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Е');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Е');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Е');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Е');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Е');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Е');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Е');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Е');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Е');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Е');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Е');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('Е');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('Э');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Е');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Е');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Е');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('Е');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Е');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('Е');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('Е');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Е');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Е');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Е');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Е');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Е');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Е');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Е');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Е');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Е');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Е');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('Е');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Е');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Е');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Е');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Е');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('Е');
									state = 12; // "z"
									break;
								default:
									sb.Append('Е');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 6: // "f"
						switch (c)
						{
								case '#':
									sb.Append('ф');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ф');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ф');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ф');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ф');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('ф');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ф');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('ф');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('ф');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ф');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ф');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ф');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ф');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ф');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ф');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ф');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ф');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ф');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ф');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('ф');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ф');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ф');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ф');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ф');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('ф');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('ф');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('ф');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ф');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ф');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('ф');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ф');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('ф');
									break;
								case 'g':
									sb.Append('ф');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ѳ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ф');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ф');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ф');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ф');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ф');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ф');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ф');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ф');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ф');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ф');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('ф');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ф');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ф');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ф');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ф');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('ф');
									state = 12; // "z"
									break;
								default:
									sb.Append('ф');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 7: // "F"
						switch (c)
						{
								case '#':
									sb.Append('Ф');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ф');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ф');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ф');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ф');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('Ф');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ф');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('Ф');
									break;
								case 'G':
									sb.Append('Ф');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ф');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ф');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ф');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ф');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ф');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ф');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ф');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ф');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ф');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ф');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Ф');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ф');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ф');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ф');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ф');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('Ф');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('Ф');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('Ф');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ф');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ф');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('Ф');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ф');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('Ф');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('Ф');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ѳ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ф');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ф');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ф');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ф');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ф');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ф');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ф');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ф');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ф');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ф');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('Ф');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ф');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ф');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ф');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ф');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('Ф');
									state = 12; // "z"
									break;
								default:
									sb.Append('Ф');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 8: // "s"
						switch (c)
						{
								case '#':
									sb.Append('с');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('с');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('с');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('с');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('с');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('с');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('с');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('с');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('с');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('с');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('с');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('с');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('с');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('с');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('с');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('с');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('с');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('с');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('с');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('с');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('с');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('с');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('с');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('с');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('с');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('с');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('с');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('с');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('с');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('с');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('с');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('с');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('с');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									state = 14; // "sh"
									break;
								case 'i':
									sb.Append('с');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('с');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('с');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('с');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('с');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('с');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('с');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('с');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('с');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('с');
									break;
								case 't':
									sb.Append('с');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('с');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('с');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('с');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('с');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('с');
									state = 12; // "z"
									break;
								default:
									sb.Append('с');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 9: // "S"
						switch (c)
						{
								case '#':
									sb.Append('С');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('С');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('С');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('С');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('С');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('С');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('С');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('С');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('С');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('С');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('С');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('С');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('С');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('С');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('С');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('С');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('С');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('С');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('С');
									break;
								case 'T':
									sb.Append('С');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('С');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('С');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('С');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('С');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('С');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('С');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('С');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('С');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('С');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('С');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('С');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('С');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('С');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									state = 15; // "Sh"
									break;
								case 'i':
									sb.Append('С');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('С');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('С');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('С');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('С');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('С');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('С');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('С');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('С');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('С');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('С');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('С');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('С');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('С');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('С');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('С');
									state = 12; // "z"
									break;
								default:
									sb.Append('С');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 10:    // "y"
						switch (c)
						{
								case '#':
									sb.Append('y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('y');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('y');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('y');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('y');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('y');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('y');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('y');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('ы');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('y');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ѣ');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('y');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ѵ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('y');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ё');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('y');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('y');
									break;
								case 'z':
									sb.Append('y');
									state = 12; // "z"
									break;
								default:
									sb.Append('y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 11:    // "Y"
						switch (c)
						{
								case '#':
									sb.Append('Y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Y');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('Y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Y');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('Y');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('Y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Y');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Y');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Y');
									break;
								case 'Z':
									sb.Append('Y');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('Ы');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Y');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('Y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ѣ');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Y');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('Y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ѵ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Y');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ё');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Y');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('Y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Y');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('Y');
									state = 12; // "z"
									break;
								default:
									sb.Append('Y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 12:    // "z"
						switch (c)
						{
								case '#':
									sb.Append('з');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('з');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('з');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('з');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('з');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('з');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('з');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('з');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('з');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('з');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('з');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('з');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('з');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('з');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('з');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('з');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('з');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('з');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('з');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('з');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('з');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('з');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('з');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('з');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('з');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('з');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('з');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('з');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('з');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('з');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('з');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('з');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('з');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('з');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('з');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('з');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('з');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('з');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('з');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('з');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('з');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('з');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('з');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('з');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('з');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('з');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('з');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('з');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('з');
									break;
								default:
									sb.Append('з');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 13:    // "Z"
						switch (c)
						{
								case '#':
									sb.Append('З');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('З');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('З');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('З');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('З');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('З');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('З');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('З');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('З');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('З');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('З');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('З');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('З');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('З');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('З');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('З');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('З');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('З');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('З');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('З');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('З');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('З');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('З');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('З');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('З');
									break;
								case '`':
									sb.Append('З');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('З');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('З');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('З');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('З');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('З');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('З');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('З');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('З');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('З');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('З');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('З');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('З');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('З');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('З');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('З');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('З');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('З');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('З');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('З');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('З');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('З');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('З');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('З');
									state = 12; // "z"
									break;
								default:
									sb.Append('З');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 14:    // "sh"
						switch (c)
						{
								case '#':
									sb.Append('ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ш');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ш');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ш');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('ш');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ш');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ш');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ш');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('ш');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('ш');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('ш');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ш');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ш');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('ш');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('ш');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('щ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ш');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ш');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('ш');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ш');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('ш');
									state = 12; // "z"
									break;
								default:
									sb.Append('ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 15:    // "Sh"
						switch (c)
						{
								case '#':
									sb.Append('Ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ш');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ш');
									state = 3;  // "C"
									break;
								case 'D':
									sb.Append('Ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ш');
									state = 5;  // "E"
									break;
								case 'F':
									sb.Append('Ш');
									state = 7;  // "F"
									break;
								case 'G':
									sb.Append('Ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ш');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ш');
									state = 9;  // "S"
									break;
								case 'T':
									sb.Append('Ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ш');
									state = 11; // "Y"
									break;
								case 'Z':
									sb.Append('Ш');
									state = 13; // "Z"
									break;
								case '`':
									sb.Append('Ш');
									state = 1;  // "`"
									break;
								case 'a':
									sb.Append('Ш');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ш');
									state = 2;  // "c"
									break;
								case 'd':
									sb.Append('Ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ш');
									state = 4;  // "e"
									break;
								case 'f':
									sb.Append('Ш');
									state = 6;  // "f"
									break;
								case 'g':
									sb.Append('Ш');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Щ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ш');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ш');
									state = 8;  // "s"
									break;
								case 't':
									sb.Append('Ш');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ш');
									state = 10; // "y"
									break;
								case 'z':
									sb.Append('Ш');
									state = 12; // "z"
									break;
								default:
									sb.Append('Ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "`"
					sb.Append('ь');
					break;
				case 2: // "c"
					sb.Append('ц');
					break;
				case 3: // "C"
					sb.Append('Ц');
					break;
				case 4: // "e"
					sb.Append('е');
					break;
				case 5: // "E"
					sb.Append('Е');
					break;
				case 6: // "f"
					sb.Append('ф');
					break;
				case 7: // "F"
					sb.Append('Ф');
					break;
				case 8: // "s"
					sb.Append('с');
					break;
				case 9: // "S"
					sb.Append('С');
					break;
				case 10:    // "y"
					sb.Append('y');
					break;
				case 11:    // "Y"
					sb.Append('Y');
					break;
				case 12:    // "z"
					sb.Append('з');
					break;
				case 13:    // "Z"
					sb.Append('З');
					break;
				case 14:    // "sh"
					sb.Append('ш');
					break;
				case 15:    // "Sh"
					sb.Append('Ш');
					break;
		}
		return sb.ToString();
	}

	private static string CyrillicToLatinBelorussian(string text)
	{
		var sb = new CustomStringBuilder(text.Length * 3);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case 'Ё':
									sb.Append('Y');
									sb.Append('o');
									break;
								case 'Ў':
									sb.Append('U');
									sb.Append('`');
									break;
								case 'А':
									sb.Append('A');
									break;
								case 'Б':
									sb.Append('B');
									break;
								case 'В':
									sb.Append('V');
									break;
								case 'Г':
									sb.Append('H');
									break;
								case 'Д':
									sb.Append('D');
									break;
								case 'Е':
									sb.Append('E');
									break;
								case 'Ж':
									sb.Append('Z');
									sb.Append('h');
									break;
								case 'З':
									sb.Append('Z');
									break;
								case 'Й':
									sb.Append('J');
									break;
								case 'К':
									sb.Append('K');
									break;
								case 'Л':
									sb.Append('L');
									break;
								case 'М':
									sb.Append('M');
									break;
								case 'Н':
									sb.Append('N');
									break;
								case 'О':
									sb.Append('O');
									break;
								case 'П':
									sb.Append('P');
									break;
								case 'Р':
									sb.Append('R');
									break;
								case 'С':
									sb.Append('S');
									break;
								case 'Т':
									sb.Append('T');
									break;
								case 'У':
									sb.Append('U');
									break;
								case 'Ф':
									sb.Append('F');
									break;
								case 'Х':
									sb.Append('X');
									break;
								case 'Ц':
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('h');
									break;
								case 'Ш':
									sb.Append('S');
									sb.Append('h');
									break;
								case 'Ы':
									sb.Append('Y');
									sb.Append('`');
									break;
								case 'Ь':
									sb.Append('`');
									break;
								case 'Э':
									sb.Append('E');
									sb.Append('`');
									break;
								case 'Ю':
									sb.Append('Y');
									sb.Append('u');
									break;
								case 'Я':
									sb.Append('Y');
									sb.Append('a');
									break;
								case 'а':
									sb.Append('a');
									break;
								case 'б':
									sb.Append('b');
									break;
								case 'в':
									sb.Append('v');
									break;
								case 'г':
									sb.Append('h');
									break;
								case 'д':
									sb.Append('d');
									break;
								case 'е':
									sb.Append('e');
									break;
								case 'ж':
									sb.Append('z');
									sb.Append('h');
									break;
								case 'з':
									sb.Append('z');
									break;
								case 'й':
									sb.Append('j');
									break;
								case 'к':
									sb.Append('k');
									break;
								case 'л':
									sb.Append('l');
									break;
								case 'м':
									sb.Append('m');
									break;
								case 'н':
									sb.Append('n');
									break;
								case 'о':
									sb.Append('o');
									break;
								case 'п':
									sb.Append('p');
									break;
								case 'р':
									sb.Append('r');
									break;
								case 'с':
									sb.Append('s');
									break;
								case 'т':
									sb.Append('t');
									break;
								case 'у':
									sb.Append('u');
									break;
								case 'ф':
									sb.Append('f');
									break;
								case 'х':
									sb.Append('x');
									break;
								case 'ц':
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('h');
									break;
								case 'ш':
									sb.Append('s');
									sb.Append('h');
									break;
								case 'ы':
									sb.Append('y');
									sb.Append('`');
									break;
								case 'ь':
									sb.Append('`');
									break;
								case 'э':
									sb.Append('e');
									sb.Append('`');
									break;
								case 'ю':
									sb.Append('y');
									sb.Append('u');
									break;
								case 'я':
									sb.Append('y');
									sb.Append('a');
									break;
								case 'ё':
									sb.Append('y');
									sb.Append('o');
									break;
								case 'ў':
									sb.Append('u');
									sb.Append('`');
									break;
								case '’':
									sb.Append('\'');
									break;
								case '№':
									sb.Append('#');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "ц"
						switch (c)
						{
								case 'Ё':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'Ў':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('c');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('H');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('c');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('c');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('c');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('c');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('c');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('c');
									sb.Append('z');
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ы':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Э':
									sb.Append('c');
									sb.Append('E');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('c');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('c');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('c');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('c');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('c');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('c');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('c');
									sb.Append('z');
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ы':
									sb.Append('c');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'э':
									sb.Append('c');
									sb.Append('e');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('c');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('c');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'ё':
									sb.Append('c');
									sb.Append('y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'ў':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									sb.Append('`');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('c');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('c');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('c');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "Ц"
						switch (c)
						{
								case 'Ё':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'Ў':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('C');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('H');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('C');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('C');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('C');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('C');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('C');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('C');
									sb.Append('z');
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ы':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Э':
									sb.Append('C');
									sb.Append('E');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('C');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('C');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('C');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('C');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('C');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('C');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('C');
									sb.Append('z');
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ы':
									sb.Append('C');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'э':
									sb.Append('C');
									sb.Append('e');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('C');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('C');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'ё':
									sb.Append('C');
									sb.Append('y');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'ў':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									sb.Append('`');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('C');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('C');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('C');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "ц"
					sb.Append('c');
					sb.Append('z');
					break;
				case 2: // "Ц"
					sb.Append('C');
					sb.Append('z');
					break;
		}
		return sb.ToString();
	}

	private static string LatinToCyrillicBelorussian(string text)
	{
		var sb = new CustomStringBuilder(text.Length);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case '#':
									sb.Append('№');
									break;
								case '\'':
									sb.Append('’');
									break;
								case 'A':
									sb.Append('А');
									break;
								case 'B':
									sb.Append('Б');
									break;
								case 'C':
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Д');
									break;
								case 'E':
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('Ф');
									break;
								case 'H':
									sb.Append('Г');
									break;
								case 'I':
									sb.Append('I');
									break;
								case 'J':
									sb.Append('Й');
									break;
								case 'K':
									sb.Append('К');
									break;
								case 'L':
									sb.Append('Л');
									break;
								case 'M':
									sb.Append('М');
									break;
								case 'N':
									sb.Append('Н');
									break;
								case 'O':
									sb.Append('О');
									break;
								case 'P':
									sb.Append('П');
									break;
								case 'R':
									sb.Append('Р');
									break;
								case 'S':
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Т');
									break;
								case 'U':
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('В');
									break;
								case 'X':
									sb.Append('Х');
									break;
								case 'Y':
									state = 10; // "Y"
									break;
								case 'Z':
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ь');
									break;
								case 'a':
									sb.Append('а');
									break;
								case 'b':
									sb.Append('б');
									break;
								case 'c':
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('д');
									break;
								case 'e':
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('ф');
									break;
								case 'h':
									sb.Append('г');
									break;
								case 'i':
									sb.Append('i');
									break;
								case 'j':
									sb.Append('й');
									break;
								case 'k':
									sb.Append('к');
									break;
								case 'l':
									sb.Append('л');
									break;
								case 'm':
									sb.Append('м');
									break;
								case 'n':
									sb.Append('н');
									break;
								case 'o':
									sb.Append('о');
									break;
								case 'p':
									sb.Append('п');
									break;
								case 'r':
									sb.Append('р');
									break;
								case 's':
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('т');
									break;
								case 'u':
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('в');
									break;
								case 'x':
									sb.Append('х');
									break;
								case 'y':
									state = 9;  // "y"
									break;
								case 'z':
									state = 11; // "z"
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "c"
						switch (c)
						{
								case '#':
									sb.Append('ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ц');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ц');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ц');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ц');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ц');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ц');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('ц');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ц');
									break;
								case 'd':
									sb.Append('ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ц');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ц');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ц');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ц');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ц');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "C"
						switch (c)
						{
								case '#':
									sb.Append('Ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ц');
									break;
								case 'D':
									sb.Append('Ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ц');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('Ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('Ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ц');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ц');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ц');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('Ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ц');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('Ц');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ц');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ц');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('Ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ц');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ц');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ц');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('Ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ц');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('Ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 3: // "e"
						switch (c)
						{
								case '#':
									sb.Append('е');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('е');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('е');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('е');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('е');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('е');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('е');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('е');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('е');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('е');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('е');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('е');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('е');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('е');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('е');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('е');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('е');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('е');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('е');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('е');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('е');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('е');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('е');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('е');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('е');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('э');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('е');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('е');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('е');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('е');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('е');
									break;
								case 'f':
									sb.Append('е');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('е');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('е');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('е');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('е');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('е');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('е');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('е');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('е');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('е');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('е');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('е');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('е');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('е');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('е');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('е');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('е');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('е');
									state = 11; // "z"
									break;
								default:
									sb.Append('е');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 4: // "E"
						switch (c)
						{
								case '#':
									sb.Append('Е');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Е');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Е');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Е');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Е');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Е');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Е');
									break;
								case 'F':
									sb.Append('Е');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('Е');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Е');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Е');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Е');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Е');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Е');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Е');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Е');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Е');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Е');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Е');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Е');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Е');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('Е');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Е');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Е');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('Е');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Э');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Е');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Е');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Е');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Е');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Е');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('Е');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Е');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Е');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Е');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Е');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Е');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Е');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Е');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Е');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Е');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Е');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Е');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Е');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Е');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('Е');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Е');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Е');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Е');
									state = 11; // "z"
									break;
								default:
									sb.Append('Е');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 5: // "s"
						switch (c)
						{
								case '#':
									sb.Append('с');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('с');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('с');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('с');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('с');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('с');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('с');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('с');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('с');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('с');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('с');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('с');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('с');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('с');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('с');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('с');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('с');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('с');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('с');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('с');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('с');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('с');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('с');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('с');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('с');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('с');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('с');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('с');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('с');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('с');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('с');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('с');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ш');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('с');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('с');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('с');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('с');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('с');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('с');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('с');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('с');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('с');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('с');
									break;
								case 't':
									sb.Append('с');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('с');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('с');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('с');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('с');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('с');
									state = 11; // "z"
									break;
								default:
									sb.Append('с');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 6: // "S"
						switch (c)
						{
								case '#':
									sb.Append('С');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('С');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('С');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('С');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('С');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('С');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('С');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('С');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('С');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('С');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('С');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('С');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('С');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('С');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('С');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('С');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('С');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('С');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('С');
									break;
								case 'T':
									sb.Append('С');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('С');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('С');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('С');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('С');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('С');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('С');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('С');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('С');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('С');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('С');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('С');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('С');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ш');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('С');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('С');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('С');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('С');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('С');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('С');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('С');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('С');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('С');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('С');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('С');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('С');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('С');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('С');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('С');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('С');
									state = 11; // "z"
									break;
								default:
									sb.Append('С');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 7: // "u"
						switch (c)
						{
								case '#':
									sb.Append('у');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('у');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('у');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('у');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('у');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('у');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('у');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('у');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('у');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('у');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('у');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('у');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('у');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('у');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('у');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('у');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('у');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('у');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('у');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('у');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('у');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('у');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('у');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('у');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('у');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ў');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('у');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('у');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('у');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('у');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('у');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('у');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('у');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('у');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('у');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('у');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('у');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('у');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('у');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('у');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('у');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('у');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('у');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('у');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('у');
									break;
								case 'v':
									sb.Append('у');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('у');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('у');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('у');
									state = 11; // "z"
									break;
								default:
									sb.Append('у');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 8: // "U"
						switch (c)
						{
								case '#':
									sb.Append('У');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('У');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('У');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('У');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('У');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('У');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('У');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('У');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('У');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('У');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('У');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('У');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('У');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('У');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('У');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('У');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('У');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('У');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('У');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('У');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('У');
									break;
								case 'V':
									sb.Append('У');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('У');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('У');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('У');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ў');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('У');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('У');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('У');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('У');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('У');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('У');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('У');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('У');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('У');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('У');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('У');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('У');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('У');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('У');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('У');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('У');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('У');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('У');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('У');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('У');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('У');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('У');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('У');
									state = 11; // "z"
									break;
								default:
									sb.Append('У');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 9: // "y"
						switch (c)
						{
								case '#':
									sb.Append('y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('y');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('y');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('y');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('y');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('y');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('y');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('y');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('y');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ы');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('y');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('y');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('y');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ё');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('y');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('y');
									break;
								case 'z':
									sb.Append('y');
									state = 11; // "z"
									break;
								default:
									sb.Append('y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 10:    // "Y"
						switch (c)
						{
								case '#':
									sb.Append('Y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Y');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Y');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('Y');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('Y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Y');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Y');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Y');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('Y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Y');
									break;
								case 'Z':
									sb.Append('Y');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ы');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Y');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Y');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('Y');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ё');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Y');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Y');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Y');
									state = 11; // "z"
									break;
								default:
									sb.Append('Y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 11:    // "z"
						switch (c)
						{
								case '#':
									sb.Append('з');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('з');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('з');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('з');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('з');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('з');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('з');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('з');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('з');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('з');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('з');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('з');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('з');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('з');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('з');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('з');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('з');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('з');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('з');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('з');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('з');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('з');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('з');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('з');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('з');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('з');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('з');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('з');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('з');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('з');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('з');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('з');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('з');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('з');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('з');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('з');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('з');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('з');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('з');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('з');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('з');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('з');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('з');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('з');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('з');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('з');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('з');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('з');
									break;
								default:
									sb.Append('з');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 12:    // "Z"
						switch (c)
						{
								case '#':
									sb.Append('З');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('З');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('З');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('З');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('З');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('З');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('З');
									state = 4;  // "E"
									break;
								case 'F':
									sb.Append('З');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'H':
									sb.Append('З');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('З');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('З');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('З');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('З');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('З');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('З');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('З');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('З');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('З');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('З');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('З');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('З');
									state = 8;  // "U"
									break;
								case 'V':
									sb.Append('З');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('З');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('З');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('З');
									break;
								case '`':
									sb.Append('З');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('З');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('З');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('З');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('З');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('З');
									state = 3;  // "e"
									break;
								case 'f':
									sb.Append('З');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('З');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('З');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('З');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('З');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('З');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('З');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('З');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('З');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('З');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('З');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('З');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('З');
									state = 7;  // "u"
									break;
								case 'v':
									sb.Append('З');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('З');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('З');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('З');
									state = 11; // "z"
									break;
								default:
									sb.Append('З');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "c"
					sb.Append('ц');
					break;
				case 2: // "C"
					sb.Append('Ц');
					break;
				case 3: // "e"
					sb.Append('е');
					break;
				case 4: // "E"
					sb.Append('Е');
					break;
				case 5: // "s"
					sb.Append('с');
					break;
				case 6: // "S"
					sb.Append('С');
					break;
				case 7: // "u"
					sb.Append('у');
					break;
				case 8: // "U"
					sb.Append('У');
					break;
				case 9: // "y"
					sb.Append('y');
					break;
				case 10:    // "Y"
					sb.Append('Y');
					break;
				case 11:    // "z"
					sb.Append('з');
					break;
				case 12:    // "Z"
					sb.Append('З');
					break;
		}
		return sb.ToString();
	}

	private static string CyrillicToLatinUkrainian(string text)
	{
		var sb = new CustomStringBuilder(text.Length * 3);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case 'Є':
									sb.Append('Y');
									sb.Append('e');
									break;
								case 'Ї':
									sb.Append('Y');
									sb.Append('i');
									break;
								case 'А':
									sb.Append('A');
									break;
								case 'Б':
									sb.Append('B');
									break;
								case 'В':
									sb.Append('V');
									break;
								case 'Г':
									sb.Append('H');
									break;
								case 'Д':
									sb.Append('D');
									break;
								case 'Е':
									sb.Append('E');
									break;
								case 'Ж':
									sb.Append('Z');
									sb.Append('h');
									break;
								case 'З':
									sb.Append('Z');
									break;
								case 'И':
									sb.Append('Y');
									sb.Append('`');
									break;
								case 'Й':
									sb.Append('J');
									break;
								case 'К':
									sb.Append('K');
									break;
								case 'Л':
									sb.Append('L');
									break;
								case 'М':
									sb.Append('M');
									break;
								case 'Н':
									sb.Append('N');
									break;
								case 'О':
									sb.Append('O');
									break;
								case 'П':
									sb.Append('P');
									break;
								case 'Р':
									sb.Append('R');
									break;
								case 'С':
									sb.Append('S');
									break;
								case 'Т':
									sb.Append('T');
									break;
								case 'У':
									sb.Append('U');
									break;
								case 'Ф':
									sb.Append('F');
									break;
								case 'Х':
									sb.Append('X');
									break;
								case 'Ц':
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('h');
									break;
								case 'Ш':
									sb.Append('S');
									sb.Append('h');
									break;
								case 'Щ':
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									break;
								case 'Ь':
									sb.Append('`');
									break;
								case 'Ю':
									sb.Append('Y');
									sb.Append('u');
									break;
								case 'Я':
									sb.Append('Y');
									sb.Append('a');
									break;
								case 'а':
									sb.Append('a');
									break;
								case 'б':
									sb.Append('b');
									break;
								case 'в':
									sb.Append('v');
									break;
								case 'г':
									sb.Append('h');
									break;
								case 'д':
									sb.Append('d');
									break;
								case 'е':
									sb.Append('e');
									break;
								case 'ж':
									sb.Append('z');
									sb.Append('h');
									break;
								case 'з':
									sb.Append('z');
									break;
								case 'и':
									sb.Append('y');
									sb.Append('`');
									break;
								case 'й':
									sb.Append('j');
									break;
								case 'к':
									sb.Append('k');
									break;
								case 'л':
									sb.Append('l');
									break;
								case 'м':
									sb.Append('m');
									break;
								case 'н':
									sb.Append('n');
									break;
								case 'о':
									sb.Append('o');
									break;
								case 'п':
									sb.Append('p');
									break;
								case 'р':
									sb.Append('r');
									break;
								case 'с':
									sb.Append('s');
									break;
								case 'т':
									sb.Append('t');
									break;
								case 'у':
									sb.Append('u');
									break;
								case 'ф':
									sb.Append('f');
									break;
								case 'х':
									sb.Append('x');
									break;
								case 'ц':
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('h');
									break;
								case 'ш':
									sb.Append('s');
									sb.Append('h');
									break;
								case 'щ':
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									break;
								case 'ь':
									sb.Append('`');
									break;
								case 'ю':
									sb.Append('y');
									sb.Append('u');
									break;
								case 'я':
									sb.Append('y');
									sb.Append('a');
									break;
								case 'є':
									sb.Append('y');
									sb.Append('e');
									break;
								case 'ї':
									sb.Append('y');
									sb.Append('i');
									break;
								case 'Ґ':
									sb.Append('G');
									sb.Append('`');
									break;
								case 'ґ':
									sb.Append('g');
									sb.Append('`');
									break;
								case '’':
									sb.Append('\'');
									break;
								case '№':
									sb.Append('#');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "ц"
						switch (c)
						{
								case 'Є':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ї':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('c');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('H');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('c');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('c');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('c');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('c');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('c');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('c');
									sb.Append('z');
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('c');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('c');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('c');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('c');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('c');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('c');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('c');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('c');
									sb.Append('z');
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('c');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('c');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'є':
									sb.Append('c');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ї':
									sb.Append('c');
									sb.Append('y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'Ґ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('G');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ґ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('g');
									sb.Append('`');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('c');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('c');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('c');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "Ц"
						switch (c)
						{
								case 'Є':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ї':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('C');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('H');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('C');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('C');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('C');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('C');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('C');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('C');
									sb.Append('z');
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('C');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('C');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('C');
									sb.Append('y');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('C');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('C');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('C');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('C');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('C');
									sb.Append('z');
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('C');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('C');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'є':
									sb.Append('C');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ї':
									sb.Append('C');
									sb.Append('y');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'Ґ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('G');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ґ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('g');
									sb.Append('`');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('C');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('C');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('C');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "ц"
					sb.Append('c');
					sb.Append('z');
					break;
				case 2: // "Ц"
					sb.Append('C');
					sb.Append('z');
					break;
		}
		return sb.ToString();
	}

	private static string LatinToCyrillicUkrainian(string text)
	{
		var sb = new CustomStringBuilder(text.Length);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case '#':
									sb.Append('№');
									break;
								case '\'':
									sb.Append('’');
									break;
								case 'A':
									sb.Append('А');
									break;
								case 'B':
									sb.Append('Б');
									break;
								case 'C':
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Д');
									break;
								case 'E':
									sb.Append('Е');
									break;
								case 'F':
									sb.Append('Ф');
									break;
								case 'G':
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('Г');
									break;
								case 'I':
									sb.Append('I');
									break;
								case 'J':
									sb.Append('Й');
									break;
								case 'K':
									sb.Append('К');
									break;
								case 'L':
									sb.Append('Л');
									break;
								case 'M':
									sb.Append('М');
									break;
								case 'N':
									sb.Append('Н');
									break;
								case 'O':
									sb.Append('О');
									break;
								case 'P':
									sb.Append('П');
									break;
								case 'R':
									sb.Append('Р');
									break;
								case 'S':
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Т');
									break;
								case 'U':
									sb.Append('У');
									break;
								case 'V':
									sb.Append('В');
									break;
								case 'X':
									sb.Append('Х');
									break;
								case 'Y':
									state = 8;  // "Y"
									break;
								case 'Z':
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('ь');
									break;
								case 'a':
									sb.Append('а');
									break;
								case 'b':
									sb.Append('б');
									break;
								case 'c':
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('д');
									break;
								case 'e':
									sb.Append('е');
									break;
								case 'f':
									sb.Append('ф');
									break;
								case 'g':
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('г');
									break;
								case 'i':
									sb.Append('i');
									break;
								case 'j':
									sb.Append('й');
									break;
								case 'k':
									sb.Append('к');
									break;
								case 'l':
									sb.Append('л');
									break;
								case 'm':
									sb.Append('м');
									break;
								case 'n':
									sb.Append('н');
									break;
								case 'o':
									sb.Append('о');
									break;
								case 'p':
									sb.Append('п');
									break;
								case 'r':
									sb.Append('р');
									break;
								case 's':
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('т');
									break;
								case 'u':
									sb.Append('у');
									break;
								case 'v':
									sb.Append('в');
									break;
								case 'x':
									sb.Append('х');
									break;
								case 'y':
									state = 7;  // "y"
									break;
								case 'z':
									state = 9;  // "z"
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "c"
						switch (c)
						{
								case '#':
									sb.Append('ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ц');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('ц');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ц');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ц');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ц');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('ц');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ц');
									break;
								case 'd':
									sb.Append('ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('ц');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ц');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ц');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ц');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "C"
						switch (c)
						{
								case '#':
									sb.Append('Ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ц');
									break;
								case 'D':
									sb.Append('Ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Ц');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('Ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ц');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ц');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ц');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('Ц');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('Ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ц');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Ц');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('Ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ц');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ц');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ц');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('Ц');
									state = 0;  // ""
									break;
								default:
									sb.Append('Ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 3: // "g"
						switch (c)
						{
								case '#':
									sb.Append('g');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('g');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('g');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('g');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('g');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('g');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('g');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('g');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('g');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('g');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('g');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('g');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('g');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('g');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('g');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('g');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('g');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('g');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('g');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('g');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('g');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('g');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('g');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('g');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('g');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('g');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('ґ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('g');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('g');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('g');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('g');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('g');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('g');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('g');
									break;
								case 'h':
									sb.Append('g');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('g');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('g');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('g');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('g');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('g');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('g');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('g');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('g');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('g');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('g');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('g');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('g');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('g');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('g');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('g');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('g');
									state = 9;  // "z"
									break;
								default:
									sb.Append('g');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 4: // "G"
						switch (c)
						{
								case '#':
									sb.Append('G');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('G');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('G');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('G');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('G');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('G');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('G');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('G');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('G');
									break;
								case 'H':
									sb.Append('G');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('G');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('G');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('G');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('G');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('G');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('G');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('G');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('G');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('G');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('G');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('G');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('G');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('G');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('G');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('G');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('G');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('Ґ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('G');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('G');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('G');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('G');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('G');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('G');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('G');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('G');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('G');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('G');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('G');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('G');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('G');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('G');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('G');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('G');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('G');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('G');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('G');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('G');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('G');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('G');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('G');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('G');
									state = 9;  // "z"
									break;
								default:
									sb.Append('G');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 5: // "s"
						switch (c)
						{
								case '#':
									sb.Append('с');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('с');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('с');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('с');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('с');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('с');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('с');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('с');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('с');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('с');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('с');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('с');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('с');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('с');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('с');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('с');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('с');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('с');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('с');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('с');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('с');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('с');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('с');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('с');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('с');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('с');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('с');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('с');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('с');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('с');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('с');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('с');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('с');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('с');
									state = 3;  // "g"
									break;
								case 'h':
									state = 11; // "sh"
									break;
								case 'i':
									sb.Append('с');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('с');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('с');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('с');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('с');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('с');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('с');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('с');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('с');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('с');
									break;
								case 't':
									sb.Append('с');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('с');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('с');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('с');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('с');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('с');
									state = 9;  // "z"
									break;
								default:
									sb.Append('с');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 6: // "S"
						switch (c)
						{
								case '#':
									sb.Append('С');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('С');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('С');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('С');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('С');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('С');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('С');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('С');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('С');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('С');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('С');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('С');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('С');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('С');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('С');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('С');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('С');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('С');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('С');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('С');
									break;
								case 'T':
									sb.Append('С');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('С');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('С');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('С');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('С');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('С');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('С');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('С');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('С');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('С');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('С');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('С');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('С');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('С');
									state = 3;  // "g"
									break;
								case 'h':
									state = 12; // "Sh"
									break;
								case 'i':
									sb.Append('С');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('С');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('С');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('С');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('С');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('С');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('С');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('С');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('С');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('С');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('С');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('С');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('С');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('С');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('С');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('С');
									state = 9;  // "z"
									break;
								default:
									sb.Append('С');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 7: // "y"
						switch (c)
						{
								case '#':
									sb.Append('y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('y');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('y');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('y');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('y');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('y');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('y');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('y');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('y');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('y');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('є');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('y');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('y');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ї');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('y');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('y');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('y');
									break;
								case 'z':
									sb.Append('y');
									state = 9;  // "z"
									break;
								default:
									sb.Append('y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 8: // "Y"
						switch (c)
						{
								case '#':
									sb.Append('Y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Y');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Y');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Y');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Y');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Y');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('Y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Y');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Y');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Y');
									break;
								case 'Z':
									sb.Append('Y');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Y');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Є');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Y');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Y');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('Y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ї');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Y');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Y');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Y');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('Y');
									state = 9;  // "z"
									break;
								default:
									sb.Append('Y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 9: // "z"
						switch (c)
						{
								case '#':
									sb.Append('з');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('з');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('з');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('з');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('з');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('з');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('з');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('з');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('з');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('з');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('з');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('з');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('з');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('з');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('з');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('з');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('з');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('з');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('з');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('з');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('з');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('з');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('з');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('з');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('з');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('з');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('з');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('з');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('з');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('з');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('з');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('з');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('з');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('з');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('з');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('з');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('з');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('з');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('з');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('з');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('з');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('з');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('з');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('з');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('з');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('з');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('з');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('з');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('з');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('з');
									break;
								default:
									sb.Append('з');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 10:    // "Z"
						switch (c)
						{
								case '#':
									sb.Append('З');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('З');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('З');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('З');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('З');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('З');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('З');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('З');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('З');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('З');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('З');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('З');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('З');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('З');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('З');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('З');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('З');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('З');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('З');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('З');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('З');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('З');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('З');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('З');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('З');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('З');
									break;
								case '`':
									sb.Append('З');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('З');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('З');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('З');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('З');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('З');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('З');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('З');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('Ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('З');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('З');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('З');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('З');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('З');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('З');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('З');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('З');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('З');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('З');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('З');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('З');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('З');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('З');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('З');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('З');
									state = 9;  // "z"
									break;
								default:
									sb.Append('З');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 11:    // "sh"
						switch (c)
						{
								case '#':
									sb.Append('ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ш');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ш');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ш');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ш');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('ш');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ш');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ш');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ш');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('ш');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('ш');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ш');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ш');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ш');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ш');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('ш');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('щ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ш');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ш');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('ш');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ш');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('ш');
									state = 9;  // "z"
									break;
								default:
									sb.Append('ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 12:    // "Sh"
						switch (c)
						{
								case '#':
									sb.Append('Ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ш');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ш');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ш');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ш');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Ш');
									state = 4;  // "G"
									break;
								case 'H':
									sb.Append('Ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ш');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ш');
									state = 6;  // "S"
									break;
								case 'T':
									sb.Append('Ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ш');
									state = 8;  // "Y"
									break;
								case 'Z':
									sb.Append('Ш');
									state = 10; // "Z"
									break;
								case '`':
									sb.Append('Ш');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ш');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ш');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ш');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ш');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Ш');
									state = 3;  // "g"
									break;
								case 'h':
									sb.Append('Щ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ш');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ш');
									state = 5;  // "s"
									break;
								case 't':
									sb.Append('Ш');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ш');
									state = 7;  // "y"
									break;
								case 'z':
									sb.Append('Ш');
									state = 9;  // "z"
									break;
								default:
									sb.Append('Ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "c"
					sb.Append('ц');
					break;
				case 2: // "C"
					sb.Append('Ц');
					break;
				case 3: // "g"
					sb.Append('g');
					break;
				case 4: // "G"
					sb.Append('G');
					break;
				case 5: // "s"
					sb.Append('с');
					break;
				case 6: // "S"
					sb.Append('С');
					break;
				case 7: // "y"
					sb.Append('y');
					break;
				case 8: // "Y"
					sb.Append('Y');
					break;
				case 9: // "z"
					sb.Append('з');
					break;
				case 10:    // "Z"
					sb.Append('З');
					break;
				case 11:    // "sh"
					sb.Append('ш');
					break;
				case 12:    // "Sh"
					sb.Append('Ш');
					break;
		}
		return sb.ToString();
	}

	private static string CyrillicToLatinBulgarian(string text)
	{
		var sb = new CustomStringBuilder(text.Length * 3);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case 'А':
									sb.Append('A');
									break;
								case 'Б':
									sb.Append('B');
									break;
								case 'В':
									sb.Append('V');
									break;
								case 'Г':
									sb.Append('G');
									break;
								case 'Д':
									sb.Append('D');
									break;
								case 'Е':
									sb.Append('E');
									break;
								case 'Ж':
									sb.Append('Z');
									sb.Append('h');
									break;
								case 'З':
									sb.Append('Z');
									break;
								case 'И':
									sb.Append('I');
									break;
								case 'Й':
									sb.Append('J');
									break;
								case 'К':
									sb.Append('K');
									break;
								case 'Л':
									sb.Append('L');
									break;
								case 'М':
									sb.Append('M');
									break;
								case 'Н':
									sb.Append('N');
									break;
								case 'О':
									sb.Append('O');
									break;
								case 'П':
									sb.Append('P');
									break;
								case 'Р':
									sb.Append('R');
									break;
								case 'С':
									sb.Append('S');
									break;
								case 'Т':
									sb.Append('T');
									break;
								case 'У':
									sb.Append('U');
									break;
								case 'Ф':
									sb.Append('F');
									break;
								case 'Х':
									sb.Append('X');
									break;
								case 'Ц':
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('h');
									break;
								case 'Ш':
									sb.Append('S');
									sb.Append('h');
									break;
								case 'Щ':
									sb.Append('S');
									sb.Append('h');
									sb.Append('t');
									break;
								case 'Ъ':
									sb.Append('A');
									sb.Append('`');
									break;
								case 'Ь':
									sb.Append('`');
									break;
								case 'Ю':
									sb.Append('Y');
									sb.Append('u');
									break;
								case 'Я':
									sb.Append('Y');
									sb.Append('a');
									break;
								case 'а':
									sb.Append('a');
									break;
								case 'б':
									sb.Append('b');
									break;
								case 'в':
									sb.Append('v');
									break;
								case 'г':
									sb.Append('g');
									break;
								case 'д':
									sb.Append('d');
									break;
								case 'е':
									sb.Append('e');
									break;
								case 'ж':
									sb.Append('z');
									sb.Append('h');
									break;
								case 'з':
									sb.Append('z');
									break;
								case 'и':
									sb.Append('i');
									break;
								case 'й':
									sb.Append('j');
									break;
								case 'к':
									sb.Append('k');
									break;
								case 'л':
									sb.Append('l');
									break;
								case 'м':
									sb.Append('m');
									break;
								case 'н':
									sb.Append('n');
									break;
								case 'о':
									sb.Append('o');
									break;
								case 'п':
									sb.Append('p');
									break;
								case 'р':
									sb.Append('r');
									break;
								case 'с':
									sb.Append('s');
									break;
								case 'т':
									sb.Append('t');
									break;
								case 'у':
									sb.Append('u');
									break;
								case 'ф':
									sb.Append('f');
									break;
								case 'х':
									sb.Append('x');
									break;
								case 'ц':
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('h');
									break;
								case 'ш':
									sb.Append('s');
									sb.Append('h');
									break;
								case 'щ':
									sb.Append('s');
									sb.Append('h');
									sb.Append('t');
									break;
								case 'ъ':
									sb.Append('a');
									sb.Append('`');
									break;
								case 'ь':
									sb.Append('`');
									break;
								case 'ю':
									sb.Append('y');
									sb.Append('u');
									break;
								case 'я':
									sb.Append('y');
									sb.Append('a');
									break;
								case 'Ѣ':
									sb.Append('Y');
									sb.Append('e');
									break;
								case 'ѣ':
									sb.Append('y');
									sb.Append('e');
									break;
								case 'Ѫ':
									sb.Append('О');
									sb.Append('`');
									break;
								case 'ѫ':
									sb.Append('о');
									sb.Append('`');
									break;
								case 'Ѳ':
									sb.Append('F');
									sb.Append('h');
									break;
								case 'ѳ':
									sb.Append('f');
									sb.Append('h');
									break;
								case 'Ѵ':
									sb.Append('Y');
									sb.Append('h');
									break;
								case 'ѵ':
									sb.Append('y');
									sb.Append('h');
									break;
								case '’':
									sb.Append('\'');
									break;
								case '№':
									sb.Append('#');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "ц"
						switch (c)
						{
								case 'А':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('c');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('c');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('c');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('c');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('c');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('c');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('c');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('c');
									sb.Append('z');
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'Ъ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('c');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('c');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('c');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('c');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('c');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('c');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('c');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('c');
									sb.Append('z');
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'ъ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('c');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('c');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('c');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'Ѣ':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ѣ':
									sb.Append('c');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ѫ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('О');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ѫ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('о');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ѳ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѳ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ѵ':
									sb.Append('c');
									sb.Append('Y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѵ':
									sb.Append('c');
									sb.Append('y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('c');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('c');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('c');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "Ц"
						switch (c)
						{
								case 'А':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('C');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('C');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('C');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'Й':
									sb.Append('C');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('C');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('N');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('C');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('C');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('C');
									sb.Append('z');
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'Ъ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ю':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'Я':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('C');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('C');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('C');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'й':
									sb.Append('C');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('C');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('n');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('C');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('C');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('C');
									sb.Append('z');
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'щ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'ъ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ь':
									sb.Append('C');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ю':
									sb.Append('C');
									sb.Append('y');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'я':
									sb.Append('C');
									sb.Append('y');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'Ѣ':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ѣ':
									sb.Append('C');
									sb.Append('y');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'Ѫ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('О');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ѫ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('о');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ѳ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѳ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ѵ':
									sb.Append('C');
									sb.Append('Y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѵ':
									sb.Append('C');
									sb.Append('y');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('C');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('C');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('C');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "ц"
					sb.Append('c');
					sb.Append('z');
					break;
				case 2: // "Ц"
					sb.Append('C');
					sb.Append('z');
					break;
		}
		return sb.ToString();
	}

	private static string LatinToCyrillicBulgarian(string text)
	{
		var sb = new CustomStringBuilder(text.Length);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case '#':
									sb.Append('№');
									break;
								case '\'':
									sb.Append('’');
									break;
								case 'A':
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('Б');
									break;
								case 'C':
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('Д');
									break;
								case 'E':
									sb.Append('Е');
									break;
								case 'F':
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('Г');
									break;
								case 'I':
									sb.Append('И');
									break;
								case 'J':
									sb.Append('Й');
									break;
								case 'K':
									sb.Append('К');
									break;
								case 'L':
									sb.Append('Л');
									break;
								case 'M':
									sb.Append('М');
									break;
								case 'N':
									sb.Append('Н');
									break;
								case 'O':
									sb.Append('О');
									break;
								case 'P':
									sb.Append('П');
									break;
								case 'R':
									sb.Append('Р');
									break;
								case 'S':
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('Т');
									break;
								case 'U':
									sb.Append('У');
									break;
								case 'V':
									sb.Append('В');
									break;
								case 'X':
									sb.Append('Х');
									break;
								case 'Y':
									state = 10; // "Y"
									break;
								case 'Z':
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ь');
									break;
								case 'a':
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('б');
									break;
								case 'c':
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('д');
									break;
								case 'e':
									sb.Append('е');
									break;
								case 'f':
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('г');
									break;
								case 'i':
									sb.Append('и');
									break;
								case 'j':
									sb.Append('й');
									break;
								case 'k':
									sb.Append('к');
									break;
								case 'l':
									sb.Append('л');
									break;
								case 'm':
									sb.Append('м');
									break;
								case 'n':
									sb.Append('н');
									break;
								case 'o':
									sb.Append('о');
									break;
								case 'p':
									sb.Append('п');
									break;
								case 'r':
									sb.Append('р');
									break;
								case 's':
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('т');
									break;
								case 'u':
									sb.Append('у');
									break;
								case 'v':
									sb.Append('в');
									break;
								case 'x':
									sb.Append('х');
									break;
								case 'y':
									state = 9;  // "y"
									break;
								case 'z':
									state = 11; // "z"
									break;
								case 'О':
									state = 14; // "О"
									break;
								case 'о':
									state = 13; // "о"
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "a"
						switch (c)
						{
								case '#':
									sb.Append('а');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('а');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('а');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('а');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('а');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('а');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('а');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('а');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('а');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('а');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('а');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('а');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('а');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('а');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('а');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('а');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('а');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('а');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('а');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('а');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('а');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('а');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('а');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('а');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('а');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ъ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('а');
									break;
								case 'b':
									sb.Append('а');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('а');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('а');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('а');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('а');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('а');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('а');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('а');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('а');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('а');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('а');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('а');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('а');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('а');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('а');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('а');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('а');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('а');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('а');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('а');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('а');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('а');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('а');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('а');
									state = 13; // "о"
									break;
								default:
									sb.Append('а');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "A"
						switch (c)
						{
								case '#':
									sb.Append('А');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('А');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('А');
									break;
								case 'B':
									sb.Append('А');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('А');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('А');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('А');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('А');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('А');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('А');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('А');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('А');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('А');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('А');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('А');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('А');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('А');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('А');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('А');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('А');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('А');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('А');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('А');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('А');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('А');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ъ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('А');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('А');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('А');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('А');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('А');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('А');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('А');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('А');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('А');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('А');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('А');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('А');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('А');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('А');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('А');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('А');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('А');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('А');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('А');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('А');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('А');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('А');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('А');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('А');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('А');
									state = 13; // "о"
									break;
								default:
									sb.Append('А');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 3: // "c"
						switch (c)
						{
								case '#':
									sb.Append('ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ц');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ц');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ц');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ц');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ц');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('ц');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ц');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ц');
									break;
								case 'd':
									sb.Append('ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ц');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('ц');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ц');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ц');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('ц');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('ц');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('ц');
									state = 13; // "о"
									break;
								default:
									sb.Append('ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 4: // "C"
						switch (c)
						{
								case '#':
									sb.Append('Ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ц');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('Ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ц');
									break;
								case 'D':
									sb.Append('Ц');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ц');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('Ц');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ц');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ц');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ц');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ц');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('Ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ц');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('Ц');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ц');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ц');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('Ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ц');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('Ц');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ц');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('Ц');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ц');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ц');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ц');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ц');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('Ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ц');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Ц');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('Ц');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('Ц');
									state = 13; // "о"
									break;
								default:
									sb.Append('Ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 5: // "f"
						switch (c)
						{
								case '#':
									sb.Append('ф');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ф');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ф');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('ф');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ф');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('ф');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ф');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ф');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('ф');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ф');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ф');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ф');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ф');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ф');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ф');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ф');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ф');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ф');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ф');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('ф');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ф');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ф');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ф');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ф');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('ф');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ф');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ф');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('ф');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ф');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('ф');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ф');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ф');
									break;
								case 'g':
									sb.Append('ф');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ѳ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ф');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ф');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ф');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ф');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ф');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ф');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ф');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ф');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ф');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ф');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('ф');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ф');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ф');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ф');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ф');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('ф');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('ф');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('ф');
									state = 13; // "о"
									break;
								default:
									sb.Append('ф');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 6: // "F"
						switch (c)
						{
								case '#':
									sb.Append('Ф');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ф');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ф');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('Ф');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ф');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('Ф');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ф');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ф');
									break;
								case 'G':
									sb.Append('Ф');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ф');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ф');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ф');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ф');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ф');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ф');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ф');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ф');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ф');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ф');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('Ф');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ф');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ф');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ф');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ф');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('Ф');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ф');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ф');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('Ф');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ф');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('Ф');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ф');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ф');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('Ф');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ѳ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ф');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ф');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ф');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ф');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ф');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ф');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ф');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ф');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ф');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ф');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('Ф');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ф');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ф');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ф');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ф');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Ф');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('Ф');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('Ф');
									state = 13; // "о"
									break;
								default:
									sb.Append('Ф');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 7: // "s"
						switch (c)
						{
								case '#':
									sb.Append('с');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('с');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('с');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('с');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('с');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('с');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('с');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('с');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('с');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('с');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('с');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('с');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('с');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('с');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('с');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('с');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('с');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('с');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('с');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('с');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('с');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('с');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('с');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('с');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('с');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('с');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('с');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('с');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('с');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('с');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('с');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('с');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('с');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									state = 15; // "sh"
									break;
								case 'i':
									sb.Append('с');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('с');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('с');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('с');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('с');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('с');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('с');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('с');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('с');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('с');
									break;
								case 't':
									sb.Append('с');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('с');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('с');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('с');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('с');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('с');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('с');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('с');
									state = 13; // "о"
									break;
								default:
									sb.Append('с');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 8: // "S"
						switch (c)
						{
								case '#':
									sb.Append('С');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('С');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('С');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('С');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('С');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('С');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('С');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('С');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('С');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('С');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('С');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('С');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('С');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('С');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('С');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('С');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('С');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('С');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('С');
									break;
								case 'T':
									sb.Append('С');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('С');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('С');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('С');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('С');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('С');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('С');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('С');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('С');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('С');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('С');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('С');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('С');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('С');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									state = 16; // "Sh"
									break;
								case 'i':
									sb.Append('С');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('С');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('С');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('С');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('С');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('С');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('С');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('С');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('С');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('С');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('С');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('С');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('С');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('С');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('С');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('С');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('С');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('С');
									state = 13; // "о"
									break;
								default:
									sb.Append('С');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 9: // "y"
						switch (c)
						{
								case '#':
									sb.Append('y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('y');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('y');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('y');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('y');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('y');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('y');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('y');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('y');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('y');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('y');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ѣ');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('y');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ѵ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('y');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('y');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('y');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('y');
									break;
								case 'z':
									sb.Append('y');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('y');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('y');
									state = 13; // "о"
									break;
								default:
									sb.Append('y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 10:    // "Y"
						switch (c)
						{
								case '#':
									sb.Append('Y');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Y');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Y');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('Y');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Y');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('Y');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Y');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Y');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('Y');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Y');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Y');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Y');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Y');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Y');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Y');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Y');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Y');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Y');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Y');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('Y');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Y');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Y');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Y');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Y');
									break;
								case 'Z':
									sb.Append('Y');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Y');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Я');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Y');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Y');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('Y');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ѣ');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Y');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('Y');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ѵ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Y');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Y');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Y');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Y');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Y');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Y');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Y');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Y');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Y');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Y');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('Y');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ю');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Y');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Y');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Y');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Y');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('Y');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('Y');
									state = 13; // "о"
									break;
								default:
									sb.Append('Y');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 11:    // "z"
						switch (c)
						{
								case '#':
									sb.Append('з');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('з');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('з');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('з');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('з');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('з');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('з');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('з');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('з');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('з');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('з');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('з');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('з');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('з');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('з');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('з');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('з');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('з');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('з');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('з');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('з');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('з');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('з');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('з');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('з');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('з');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('з');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('з');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('з');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('з');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('з');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('з');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('з');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('з');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('з');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('з');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('з');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('з');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('з');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('з');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('з');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('з');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('з');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('з');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('з');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('з');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('з');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('з');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('з');
									break;
								case 'О':
									sb.Append('з');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('з');
									state = 13; // "о"
									break;
								default:
									sb.Append('з');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 12:    // "Z"
						switch (c)
						{
								case '#':
									sb.Append('З');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('З');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('З');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('З');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('З');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('З');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('З');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('З');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('З');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('З');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('З');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('З');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('З');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('З');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('З');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('З');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('З');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('З');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('З');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('З');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('З');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('З');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('З');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('З');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('З');
									break;
								case '`':
									sb.Append('З');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('З');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('З');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('З');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('З');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('З');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('З');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('З');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'h':
									sb.Append('Ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('З');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('З');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('З');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('З');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('З');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('З');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('З');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('З');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('З');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('З');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('З');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('З');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('З');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('З');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('З');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('З');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('З');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('З');
									state = 13; // "о"
									break;
								default:
									sb.Append('З');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 13:    // "о"
						switch (c)
						{
								case '#':
									sb.Append('о');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('о');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('о');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('о');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('о');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('о');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('о');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('о');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('о');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('о');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('о');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('о');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('о');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('о');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('о');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('о');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('о');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('о');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('о');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('о');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('о');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('о');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('о');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('о');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('о');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ѫ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('о');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('о');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('о');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('о');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('о');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('о');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('о');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('о');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('о');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('о');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('о');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('о');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('о');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('о');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('о');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('о');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('о');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('о');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('о');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('о');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('о');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('о');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('о');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('о');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('о');
									break;
								default:
									sb.Append('о');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 14:    // "О"
						switch (c)
						{
								case '#':
									sb.Append('О');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('О');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('О');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('О');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('О');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('О');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('О');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('О');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('О');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('О');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('О');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('О');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('О');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('О');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('О');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('О');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('О');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('О');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('О');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('О');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('О');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('О');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('О');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('О');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('О');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ѫ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('О');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('О');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('О');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('О');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('О');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('О');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('О');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('О');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('О');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('О');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('О');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('О');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('О');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('О');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('О');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('О');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('О');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('О');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('О');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('О');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('О');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('О');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('О');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('О');
									break;
								case 'о':
									sb.Append('О');
									state = 13; // "о"
									break;
								default:
									sb.Append('О');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 15:    // "sh"
						switch (c)
						{
								case '#':
									sb.Append('ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ш');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ш');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('ш');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ш');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('ш');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ш');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('ш');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('ш');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('ш');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('ш');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ш');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('ш');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ш');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('ш');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ш');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ш');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('щ');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('ш');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('ш');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('ш');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('ш');
									state = 13; // "о"
									break;
								default:
									sb.Append('ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 16:    // "Sh"
						switch (c)
						{
								case '#':
									sb.Append('Ш');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ш');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ш');
									state = 2;  // "A"
									break;
								case 'B':
									sb.Append('Ш');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ш');
									state = 4;  // "C"
									break;
								case 'D':
									sb.Append('Ш');
									sb.Append('Д');
									state = 0;  // ""
									break;
								case 'E':
									sb.Append('Ш');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ш');
									state = 6;  // "F"
									break;
								case 'G':
									sb.Append('Ш');
									sb.Append('Г');
									state = 0;  // ""
									break;
								case 'I':
									sb.Append('Ш');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ш');
									sb.Append('Й');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ш');
									sb.Append('К');
									state = 0;  // ""
									break;
								case 'L':
									sb.Append('Ш');
									sb.Append('Л');
									state = 0;  // ""
									break;
								case 'M':
									sb.Append('Ш');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ш');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'O':
									sb.Append('Ш');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ш');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ш');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ш');
									state = 8;  // "S"
									break;
								case 'T':
									sb.Append('Ш');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ш');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ш');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ш');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Y':
									sb.Append('Ш');
									state = 10; // "Y"
									break;
								case 'Z':
									sb.Append('Ш');
									state = 12; // "Z"
									break;
								case '`':
									sb.Append('Ш');
									sb.Append('ь');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Ш');
									state = 1;  // "a"
									break;
								case 'b':
									sb.Append('Ш');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ш');
									state = 3;  // "c"
									break;
								case 'd':
									sb.Append('Ш');
									sb.Append('д');
									state = 0;  // ""
									break;
								case 'e':
									sb.Append('Ш');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ш');
									state = 5;  // "f"
									break;
								case 'g':
									sb.Append('Ш');
									sb.Append('г');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ш');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ш');
									sb.Append('й');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ш');
									sb.Append('к');
									state = 0;  // ""
									break;
								case 'l':
									sb.Append('Ш');
									sb.Append('л');
									state = 0;  // ""
									break;
								case 'm':
									sb.Append('Ш');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ш');
									sb.Append('н');
									state = 0;  // ""
									break;
								case 'o':
									sb.Append('Ш');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ш');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ш');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ш');
									state = 7;  // "s"
									break;
								case 't':
									sb.Append('Щ');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ш');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ш');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ш');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'y':
									sb.Append('Ш');
									state = 9;  // "y"
									break;
								case 'z':
									sb.Append('Ш');
									state = 11; // "z"
									break;
								case 'О':
									sb.Append('Ш');
									state = 14; // "О"
									break;
								case 'о':
									sb.Append('Ш');
									state = 13; // "о"
									break;
								default:
									sb.Append('Ш');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "a"
					sb.Append('а');
					break;
				case 2: // "A"
					sb.Append('А');
					break;
				case 3: // "c"
					sb.Append('ц');
					break;
				case 4: // "C"
					sb.Append('Ц');
					break;
				case 5: // "f"
					sb.Append('ф');
					break;
				case 6: // "F"
					sb.Append('Ф');
					break;
				case 7: // "s"
					sb.Append('с');
					break;
				case 8: // "S"
					sb.Append('С');
					break;
				case 9: // "y"
					sb.Append('y');
					break;
				case 10:    // "Y"
					sb.Append('Y');
					break;
				case 11:    // "z"
					sb.Append('з');
					break;
				case 12:    // "Z"
					sb.Append('З');
					break;
				case 13:    // "о"
					sb.Append('о');
					break;
				case 14:    // "О"
					sb.Append('О');
					break;
				case 15:    // "sh"
					sb.Append('ш');
					break;
				case 16:    // "Sh"
					sb.Append('Ш');
					break;
		}
		return sb.ToString();
	}

	private static string CyrillicToLatinMacedonian(string text)
	{
		var sb = new CustomStringBuilder(text.Length * 3);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case 'S':
									sb.Append('Z');
									sb.Append('`');
									break;
								case 's':
									sb.Append('z');
									sb.Append('`');
									break;
								case 'Ѓ':
									sb.Append('G');
									sb.Append('`');
									break;
								case 'Љ':
									sb.Append('L');
									sb.Append('`');
									break;
								case 'Њ':
									sb.Append('N');
									sb.Append('`');
									break;
								case 'Ќ':
									sb.Append('K');
									sb.Append('`');
									break;
								case 'Џ':
									sb.Append('D');
									sb.Append('h');
									break;
								case 'А':
									sb.Append('A');
									break;
								case 'Б':
									sb.Append('B');
									break;
								case 'В':
									sb.Append('V');
									break;
								case 'Г':
									sb.Append('G');
									break;
								case 'Д':
									sb.Append('D');
									break;
								case 'Е':
									sb.Append('E');
									break;
								case 'Ж':
									sb.Append('Z');
									sb.Append('h');
									break;
								case 'З':
									sb.Append('Z');
									break;
								case 'И':
									sb.Append('I');
									break;
								case 'К':
									sb.Append('K');
									break;
								case 'Л':
									sb.Append('L');
									break;
								case 'М':
									sb.Append('M');
									break;
								case 'Н':
									sb.Append('П');
									break;
								case 'О':
									sb.Append('O');
									break;
								case 'П':
									sb.Append('P');
									break;
								case 'Р':
									sb.Append('R');
									break;
								case 'С':
									sb.Append('S');
									break;
								case 'Т':
									sb.Append('T');
									break;
								case 'У':
									sb.Append('U');
									break;
								case 'Ф':
									sb.Append('F');
									break;
								case 'Х':
									sb.Append('X');
									break;
								case 'Ц':
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('h');
									break;
								case 'Ш':
									sb.Append('S');
									sb.Append('h');
									break;
								case 'а':
									sb.Append('a');
									break;
								case 'б':
									sb.Append('b');
									break;
								case 'в':
									sb.Append('v');
									break;
								case 'г':
									sb.Append('g');
									break;
								case 'д':
									sb.Append('d');
									break;
								case 'е':
									sb.Append('e');
									break;
								case 'ж':
									sb.Append('z');
									sb.Append('h');
									break;
								case 'з':
									sb.Append('z');
									break;
								case 'и':
									sb.Append('i');
									break;
								case 'к':
									sb.Append('k');
									break;
								case 'л':
									sb.Append('l');
									break;
								case 'м':
									sb.Append('m');
									break;
								case 'н':
									sb.Append('п');
									break;
								case 'о':
									sb.Append('o');
									break;
								case 'п':
									sb.Append('p');
									break;
								case 'р':
									sb.Append('r');
									break;
								case 'с':
									sb.Append('s');
									break;
								case 'т':
									sb.Append('t');
									break;
								case 'у':
									sb.Append('u');
									break;
								case 'ф':
									sb.Append('f');
									break;
								case 'х':
									sb.Append('x');
									break;
								case 'ц':
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('h');
									break;
								case 'ш':
									sb.Append('s');
									sb.Append('h');
									break;
								case 'ѓ':
									sb.Append('g');
									sb.Append('`');
									break;
								case 'љ':
									sb.Append('l');
									sb.Append('`');
									break;
								case 'њ':
									sb.Append('n');
									sb.Append('`');
									break;
								case 'ќ':
									sb.Append('k');
									sb.Append('`');
									break;
								case 'џ':
									sb.Append('d');
									sb.Append('h');
									break;
								case '’':
									sb.Append('\'');
									break;
								case '№':
									sb.Append('#');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "ц"
						switch (c)
						{
								case 'S':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ѓ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('G');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Љ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Њ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('N');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ќ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Џ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('c');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('c');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('c');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('c');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('c');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('c');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('c');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('c');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('c');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('c');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('c');
									sb.Append('z');
									state = 2;  // "Ц"
									break;
								case 'Ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('c');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('c');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('c');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('c');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('c');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('c');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('c');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('c');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('c');
									sb.Append('z');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('c');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('c');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('c');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('c');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('c');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('c');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('c');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('c');
									sb.Append('z');
									break;
								case 'ч':
									sb.Append('c');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('c');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѓ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('g');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'љ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('l');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'њ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('n');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ќ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('k');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'џ':
									sb.Append('c');
									sb.Append('z');
									sb.Append('d');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('c');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('c');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('c');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "Ц"
						switch (c)
						{
								case 'S':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ѓ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('G');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Љ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Њ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('N');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Ќ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'Џ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'А':
									sb.Append('C');
									sb.Append('z');
									sb.Append('A');
									state = 0;  // ""
									break;
								case 'Б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('B');
									state = 0;  // ""
									break;
								case 'В':
									sb.Append('C');
									sb.Append('z');
									sb.Append('V');
									state = 0;  // ""
									break;
								case 'Г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('G');
									state = 0;  // ""
									break;
								case 'Д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('D');
									state = 0;  // ""
									break;
								case 'Е':
									sb.Append('C');
									sb.Append('E');
									state = 0;  // ""
									break;
								case 'Ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'З':
									sb.Append('C');
									sb.Append('z');
									sb.Append('Z');
									state = 0;  // ""
									break;
								case 'И':
									sb.Append('C');
									sb.Append('I');
									state = 0;  // ""
									break;
								case 'К':
									sb.Append('C');
									sb.Append('z');
									sb.Append('K');
									state = 0;  // ""
									break;
								case 'Л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('L');
									state = 0;  // ""
									break;
								case 'М':
									sb.Append('C');
									sb.Append('z');
									sb.Append('M');
									state = 0;  // ""
									break;
								case 'Н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'О':
									sb.Append('C');
									sb.Append('z');
									sb.Append('O');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('C');
									sb.Append('z');
									sb.Append('P');
									state = 0;  // ""
									break;
								case 'Р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('R');
									state = 0;  // ""
									break;
								case 'С':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'Т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('T');
									state = 0;  // ""
									break;
								case 'У':
									sb.Append('C');
									sb.Append('z');
									sb.Append('U');
									state = 0;  // ""
									break;
								case 'Ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('F');
									state = 0;  // ""
									break;
								case 'Х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('X');
									state = 0;  // ""
									break;
								case 'Ц':
									sb.Append('C');
									sb.Append('z');
									break;
								case 'Ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('C');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'Ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('S');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'а':
									sb.Append('C');
									sb.Append('z');
									sb.Append('a');
									state = 0;  // ""
									break;
								case 'б':
									sb.Append('C');
									sb.Append('z');
									sb.Append('b');
									state = 0;  // ""
									break;
								case 'в':
									sb.Append('C');
									sb.Append('z');
									sb.Append('v');
									state = 0;  // ""
									break;
								case 'г':
									sb.Append('C');
									sb.Append('z');
									sb.Append('g');
									state = 0;  // ""
									break;
								case 'д':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									state = 0;  // ""
									break;
								case 'е':
									sb.Append('C');
									sb.Append('e');
									state = 0;  // ""
									break;
								case 'ж':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'з':
									sb.Append('C');
									sb.Append('z');
									sb.Append('z');
									state = 0;  // ""
									break;
								case 'и':
									sb.Append('C');
									sb.Append('i');
									state = 0;  // ""
									break;
								case 'к':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									state = 0;  // ""
									break;
								case 'л':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									state = 0;  // ""
									break;
								case 'м':
									sb.Append('C');
									sb.Append('z');
									sb.Append('m');
									state = 0;  // ""
									break;
								case 'н':
									sb.Append('C');
									sb.Append('z');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'о':
									sb.Append('C');
									sb.Append('z');
									sb.Append('o');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('C');
									sb.Append('z');
									sb.Append('p');
									state = 0;  // ""
									break;
								case 'р':
									sb.Append('C');
									sb.Append('z');
									sb.Append('r');
									state = 0;  // ""
									break;
								case 'с':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'т':
									sb.Append('C');
									sb.Append('z');
									sb.Append('t');
									state = 0;  // ""
									break;
								case 'у':
									sb.Append('C');
									sb.Append('z');
									sb.Append('u');
									state = 0;  // ""
									break;
								case 'ф':
									sb.Append('C');
									sb.Append('z');
									sb.Append('f');
									state = 0;  // ""
									break;
								case 'х':
									sb.Append('C');
									sb.Append('z');
									sb.Append('x');
									state = 0;  // ""
									break;
								case 'ц':
									sb.Append('C');
									sb.Append('z');
									state = 1;  // "ц"
									break;
								case 'ч':
									sb.Append('C');
									sb.Append('z');
									sb.Append('c');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ш':
									sb.Append('C');
									sb.Append('z');
									sb.Append('s');
									sb.Append('h');
									state = 0;  // ""
									break;
								case 'ѓ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('g');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'љ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('l');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'њ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('n');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'ќ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('k');
									sb.Append('`');
									state = 0;  // ""
									break;
								case 'џ':
									sb.Append('C');
									sb.Append('z');
									sb.Append('d');
									sb.Append('h');
									state = 0;  // ""
									break;
								case '’':
									sb.Append('C');
									sb.Append('z');
									sb.Append('\'');
									state = 0;  // ""
									break;
								case '№':
									sb.Append('C');
									sb.Append('z');
									sb.Append('#');
									state = 0;  // ""
									break;
								default:
									sb.Append('C');
									sb.Append('z');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "ц"
					sb.Append('c');
					sb.Append('z');
					break;
				case 2: // "Ц"
					sb.Append('C');
					sb.Append('z');
					break;
		}
		return sb.ToString();
	}

	private static string LatinToCyrillicMacedonian(string text)
	{
		var sb = new CustomStringBuilder(text.Length);

		var state = 0;
		for (var i = 0; i < text.Length; i++)
		{
				var c = text[i];
				switch (state)
				{
					case 0: // ""
						switch (c)
						{
								case '#':
									sb.Append('№');
									break;
								case '\'':
									sb.Append('’');
									break;
								case 'A':
									sb.Append('А');
									break;
								case 'B':
									sb.Append('Б');
									break;
								case 'C':
									state = 2;  // "C"
									break;
								case 'D':
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('Е');
									break;
								case 'F':
									sb.Append('Ф');
									break;
								case 'G':
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('И');
									break;
								case 'J':
									sb.Append('J');
									break;
								case 'K':
									state = 8;  // "K"
									break;
								case 'L':
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('М');
									break;
								case 'N':
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('О');
									break;
								case 'P':
									sb.Append('П');
									break;
								case 'R':
									sb.Append('Р');
									break;
								case 'S':
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('Т');
									break;
								case 'U':
									sb.Append('У');
									break;
								case 'V':
									sb.Append('В');
									break;
								case 'X':
									sb.Append('Х');
									break;
								case 'Z':
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('а');
									break;
								case 'b':
									sb.Append('б');
									break;
								case 'c':
									state = 1;  // "c"
									break;
								case 'd':
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('е');
									break;
								case 'f':
									sb.Append('ф');
									break;
								case 'g':
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('и');
									break;
								case 'j':
									sb.Append('j');
									break;
								case 'k':
									state = 7;  // "k"
									break;
								case 'l':
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('м');
									break;
								case 'n':
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('о');
									break;
								case 'p':
									sb.Append('п');
									break;
								case 'r':
									sb.Append('р');
									break;
								case 's':
									state = 13; // "s"
									break;
								case 't':
									sb.Append('т');
									break;
								case 'u':
									sb.Append('у');
									break;
								case 'v':
									sb.Append('в');
									break;
								case 'x':
									sb.Append('х');
									break;
								case 'z':
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('Н');
									break;
								case 'п':
									sb.Append('н');
									break;
								default:
									sb.Append(c);
									break;
						}
						break;
					case 1: // "c"
						switch (c)
						{
								case '#':
									sb.Append('ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('ц');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('ц');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('ц');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('ц');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('ц');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('ц');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('ц');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('ц');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('ц');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('ц');
									break;
								case 'd':
									sb.Append('ц');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('ц');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('ц');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('ц');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('ц');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('ц');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('ц');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('ц');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 2: // "C"
						switch (c)
						{
								case '#':
									sb.Append('Ц');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Ц');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Ц');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Ц');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Ц');
									break;
								case 'D':
									sb.Append('Ц');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('Ц');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Ц');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Ц');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('Ц');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Ц');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Ц');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('Ц');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('Ц');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Ц');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('Ц');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Ц');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Ц');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Ц');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('Ц');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Ц');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Ц');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Ц');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('Ц');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('Ц');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Ц');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Ц');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Ц');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('Ц');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Ц');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Ц');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('Ч');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Ц');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Ц');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Ц');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('Ц');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('Ц');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Ц');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('Ц');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Ц');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Ц');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Ц');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('Ц');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Ц');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Ц');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Ц');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('Ц');
									state = 0;  // ""
									break;
								case 'П':
									sb.Append('Ц');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('Ц');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('Ц');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 3: // "d"
						switch (c)
						{
								case '#':
									sb.Append('д');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('д');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('д');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('д');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('д');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('д');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('д');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('д');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('д');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('д');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('д');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('д');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('д');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('д');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('д');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('д');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('д');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('д');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('д');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('д');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('д');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('д');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('д');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('д');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('д');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('д');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('д');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('д');
									break;
								case 'e':
									sb.Append('д');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('д');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('д');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('џ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('д');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('д');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('д');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('д');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('д');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('д');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('д');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('д');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('д');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('д');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('д');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('д');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('д');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('д');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('д');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('д');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('д');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('д');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 4: // "D"
						switch (c)
						{
								case '#':
									sb.Append('Д');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Д');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Д');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Д');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Д');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Д');
									break;
								case 'E':
									sb.Append('Д');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Д');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Д');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('Д');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Д');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Д');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('Д');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('Д');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Д');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('Д');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Д');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Д');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Д');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('Д');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Д');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Д');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Д');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('Д');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('Д');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Д');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Д');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Д');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('Д');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Д');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Д');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('Џ');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('Д');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Д');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Д');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('Д');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('Д');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Д');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('Д');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Д');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Д');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Д');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('Д');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Д');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Д');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Д');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('Д');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('Д');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('Д');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('Д');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 5: // "g"
						switch (c)
						{
								case '#':
									sb.Append('г');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('г');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('г');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('г');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('г');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('г');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('г');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('г');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('г');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('г');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('г');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('г');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('г');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('г');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('г');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('г');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('г');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('г');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('г');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('г');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('г');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('г');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('г');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('г');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('ѓ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('г');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('г');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('г');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('г');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('г');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('г');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('г');
									break;
								case 'i':
									sb.Append('г');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('г');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('г');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('г');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('г');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('г');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('г');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('г');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('г');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('г');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('г');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('г');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('г');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('г');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('г');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('г');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('г');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('г');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 6: // "G"
						switch (c)
						{
								case '#':
									sb.Append('Г');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Г');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Г');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Г');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Г');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Г');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('Г');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Г');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Г');
									break;
								case 'I':
									sb.Append('Г');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Г');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Г');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('Г');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('Г');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Г');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('Г');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Г');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Г');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Г');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('Г');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Г');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Г');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Г');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('Г');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('Ѓ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Г');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Г');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Г');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Г');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('Г');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Г');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Г');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('Г');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Г');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Г');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('Г');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('Г');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Г');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('Г');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Г');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Г');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Г');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('Г');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Г');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Г');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Г');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('Г');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('Г');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('Г');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('Г');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 7: // "k"
						switch (c)
						{
								case '#':
									sb.Append('к');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('к');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('к');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('к');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('к');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('к');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('к');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('к');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('к');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('к');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('к');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('к');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('к');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('к');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('к');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('к');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('к');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('к');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('к');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('к');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('к');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('к');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('к');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('к');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('ќ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('к');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('к');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('к');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('к');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('к');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('к');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('к');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('к');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('к');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('к');
									break;
								case 'l':
									sb.Append('к');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('к');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('к');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('к');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('к');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('к');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('к');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('к');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('к');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('к');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('к');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('к');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('к');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('к');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('к');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 8: // "K"
						switch (c)
						{
								case '#':
									sb.Append('К');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('К');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('К');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('К');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('К');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('К');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('К');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('К');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('К');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('К');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('К');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('К');
									break;
								case 'L':
									sb.Append('К');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('К');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('К');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('К');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('К');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('К');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('К');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('К');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('К');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('К');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('К');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('К');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('Ќ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('К');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('К');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('К');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('К');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('К');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('К');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('К');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('К');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('К');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('К');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('К');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('К');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('К');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('К');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('К');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('К');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('К');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('К');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('К');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('К');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('К');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('К');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('К');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('К');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('К');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 9: // "l"
						switch (c)
						{
								case '#':
									sb.Append('л');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('л');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('л');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('л');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('л');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('л');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('л');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('л');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('л');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('л');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('л');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('л');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('л');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('л');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('л');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('л');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('л');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('л');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('л');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('л');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('л');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('л');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('л');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('л');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('љ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('л');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('л');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('л');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('л');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('л');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('л');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('л');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('л');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('л');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('л');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('л');
									break;
								case 'm':
									sb.Append('л');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('л');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('л');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('л');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('л');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('л');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('л');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('л');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('л');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('л');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('л');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('л');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('л');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('л');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 10:    // "L"
						switch (c)
						{
								case '#':
									sb.Append('Л');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('Л');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('Л');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('Л');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('Л');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('Л');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('Л');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('Л');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('Л');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('Л');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('Л');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('Л');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('Л');
									break;
								case 'M':
									sb.Append('Л');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('Л');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('Л');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('Л');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('Л');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('Л');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('Л');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('Л');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('Л');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('Л');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('Л');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('Љ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('Л');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('Л');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('Л');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('Л');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('Л');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('Л');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('Л');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('Л');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('Л');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('Л');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('Л');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('Л');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('Л');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('Л');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('Л');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('Л');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('Л');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('Л');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('Л');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('Л');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('Л');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('Л');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('Л');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('Л');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('Л');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 11:    // "n"
						switch (c)
						{
								case '#':
									sb.Append('n');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('n');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('n');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('n');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('n');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('n');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('n');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('n');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('n');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('n');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('n');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('n');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('n');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('n');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('n');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('n');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('n');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('n');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('n');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('n');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('n');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('n');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('n');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('n');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('њ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('n');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('n');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('n');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('n');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('n');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('n');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('n');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('n');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('n');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('n');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('n');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('n');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('n');
									break;
								case 'o':
									sb.Append('n');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('n');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('n');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('n');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('n');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('n');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('n');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('n');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('n');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('n');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('n');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('n');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 12:    // "N"
						switch (c)
						{
								case '#':
									sb.Append('N');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('N');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('N');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('N');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('N');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('N');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('N');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('N');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('N');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('N');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('N');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('N');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('N');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('N');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('N');
									break;
								case 'O':
									sb.Append('N');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('N');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('N');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('N');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('N');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('N');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('N');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('N');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('N');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('Њ');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('N');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('N');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('N');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('N');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('N');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('N');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('N');
									state = 5;  // "g"
									break;
								case 'i':
									sb.Append('N');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('N');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('N');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('N');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('N');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('N');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('N');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('N');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('N');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('N');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('N');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('N');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('N');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('N');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('N');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('N');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('N');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('N');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 13:    // "s"
						switch (c)
						{
								case '#':
									sb.Append('с');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('с');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('с');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('с');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('с');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('с');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('с');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('с');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('с');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('с');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('с');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('с');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('с');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('с');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('с');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('с');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('с');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('с');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('с');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('с');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('с');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('с');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('с');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('с');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('с');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('с');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('с');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('с');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('с');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('с');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('с');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('ш');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('с');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('с');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('с');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('с');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('с');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('с');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('с');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('с');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('с');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('с');
									break;
								case 't':
									sb.Append('с');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('с');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('с');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('с');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('с');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('с');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('с');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('с');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 14:    // "S"
						switch (c)
						{
								case '#':
									sb.Append('С');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('С');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('С');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('С');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('С');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('С');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('С');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('С');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('С');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('С');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('С');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('С');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('С');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('С');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('С');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('С');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('С');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('С');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('С');
									break;
								case 'T':
									sb.Append('С');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('С');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('С');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('С');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('С');
									state = 16; // "Z"
									break;
								case 'a':
									sb.Append('С');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('С');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('С');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('С');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('С');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('С');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('С');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('Ш');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('С');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('С');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('С');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('С');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('С');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('С');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('С');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('С');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('С');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('С');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('С');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('С');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('С');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('С');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('С');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('С');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('С');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('С');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 15:    // "z"
						switch (c)
						{
								case '#':
									sb.Append('з');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('з');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('з');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('з');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('з');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('з');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('з');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('з');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('з');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('з');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('з');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('з');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('з');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('з');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('з');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('з');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('з');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('з');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('з');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('з');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('з');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('з');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('з');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('з');
									state = 16; // "Z"
									break;
								case '`':
									sb.Append('s');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('з');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('з');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('з');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('з');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('з');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('з');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('з');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('з');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('з');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('з');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('з');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('з');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('з');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('з');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('з');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('з');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('з');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('з');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('з');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('з');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('з');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('з');
									break;
								case 'П':
									sb.Append('з');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('з');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('з');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
					case 16:    // "Z"
						switch (c)
						{
								case '#':
									sb.Append('З');
									sb.Append('№');
									state = 0;  // ""
									break;
								case '\'':
									sb.Append('З');
									sb.Append('’');
									state = 0;  // ""
									break;
								case 'A':
									sb.Append('З');
									sb.Append('А');
									state = 0;  // ""
									break;
								case 'B':
									sb.Append('З');
									sb.Append('Б');
									state = 0;  // ""
									break;
								case 'C':
									sb.Append('З');
									state = 2;  // "C"
									break;
								case 'D':
									sb.Append('З');
									state = 4;  // "D"
									break;
								case 'E':
									sb.Append('З');
									sb.Append('Е');
									state = 0;  // ""
									break;
								case 'F':
									sb.Append('З');
									sb.Append('Ф');
									state = 0;  // ""
									break;
								case 'G':
									sb.Append('З');
									state = 6;  // "G"
									break;
								case 'I':
									sb.Append('З');
									sb.Append('И');
									state = 0;  // ""
									break;
								case 'J':
									sb.Append('З');
									sb.Append('J');
									state = 0;  // ""
									break;
								case 'K':
									sb.Append('З');
									state = 8;  // "K"
									break;
								case 'L':
									sb.Append('З');
									state = 10; // "L"
									break;
								case 'M':
									sb.Append('З');
									sb.Append('М');
									state = 0;  // ""
									break;
								case 'N':
									sb.Append('З');
									state = 12; // "N"
									break;
								case 'O':
									sb.Append('З');
									sb.Append('О');
									state = 0;  // ""
									break;
								case 'P':
									sb.Append('З');
									sb.Append('П');
									state = 0;  // ""
									break;
								case 'R':
									sb.Append('З');
									sb.Append('Р');
									state = 0;  // ""
									break;
								case 'S':
									sb.Append('З');
									state = 14; // "S"
									break;
								case 'T':
									sb.Append('З');
									sb.Append('Т');
									state = 0;  // ""
									break;
								case 'U':
									sb.Append('З');
									sb.Append('У');
									state = 0;  // ""
									break;
								case 'V':
									sb.Append('З');
									sb.Append('В');
									state = 0;  // ""
									break;
								case 'X':
									sb.Append('З');
									sb.Append('Х');
									state = 0;  // ""
									break;
								case 'Z':
									sb.Append('З');
									break;
								case '`':
									sb.Append('S');
									state = 0;  // ""
									break;
								case 'a':
									sb.Append('З');
									sb.Append('а');
									state = 0;  // ""
									break;
								case 'b':
									sb.Append('З');
									sb.Append('б');
									state = 0;  // ""
									break;
								case 'c':
									sb.Append('З');
									state = 1;  // "c"
									break;
								case 'd':
									sb.Append('З');
									state = 3;  // "d"
									break;
								case 'e':
									sb.Append('З');
									sb.Append('е');
									state = 0;  // ""
									break;
								case 'f':
									sb.Append('З');
									sb.Append('ф');
									state = 0;  // ""
									break;
								case 'g':
									sb.Append('З');
									state = 5;  // "g"
									break;
								case 'h':
									sb.Append('Ж');
									state = 0;  // ""
									break;
								case 'i':
									sb.Append('З');
									sb.Append('и');
									state = 0;  // ""
									break;
								case 'j':
									sb.Append('З');
									sb.Append('j');
									state = 0;  // ""
									break;
								case 'k':
									sb.Append('З');
									state = 7;  // "k"
									break;
								case 'l':
									sb.Append('З');
									state = 9;  // "l"
									break;
								case 'm':
									sb.Append('З');
									sb.Append('м');
									state = 0;  // ""
									break;
								case 'n':
									sb.Append('З');
									state = 11; // "n"
									break;
								case 'o':
									sb.Append('З');
									sb.Append('о');
									state = 0;  // ""
									break;
								case 'p':
									sb.Append('З');
									sb.Append('п');
									state = 0;  // ""
									break;
								case 'r':
									sb.Append('З');
									sb.Append('р');
									state = 0;  // ""
									break;
								case 's':
									sb.Append('З');
									state = 13; // "s"
									break;
								case 't':
									sb.Append('З');
									sb.Append('т');
									state = 0;  // ""
									break;
								case 'u':
									sb.Append('З');
									sb.Append('у');
									state = 0;  // ""
									break;
								case 'v':
									sb.Append('З');
									sb.Append('в');
									state = 0;  // ""
									break;
								case 'x':
									sb.Append('З');
									sb.Append('х');
									state = 0;  // ""
									break;
								case 'z':
									sb.Append('З');
									state = 15; // "z"
									break;
								case 'П':
									sb.Append('З');
									sb.Append('Н');
									state = 0;  // ""
									break;
								case 'п':
									sb.Append('З');
									sb.Append('н');
									state = 0;  // ""
									break;
								default:
									sb.Append('З');
									sb.Append(c);
									state = 0;  // ""
									break;
						}
						break;
				}
		}

		switch (state)
		{
				case 1: // "c"
					sb.Append('ц');
					break;
				case 2: // "C"
					sb.Append('Ц');
					break;
				case 3: // "d"
					sb.Append('д');
					break;
				case 4: // "D"
					sb.Append('Д');
					break;
				case 5: // "g"
					sb.Append('г');
					break;
				case 6: // "G"
					sb.Append('Г');
					break;
				case 7: // "k"
					sb.Append('к');
					break;
				case 8: // "K"
					sb.Append('К');
					break;
				case 9: // "l"
					sb.Append('л');
					break;
				case 10:    // "L"
					sb.Append('Л');
					break;
				case 11:    // "n"
					sb.Append('n');
					break;
				case 12:    // "N"
					sb.Append('N');
					break;
				case 13:    // "s"
					sb.Append('с');
					break;
				case 14:    // "S"
					sb.Append('С');
					break;
				case 15:    // "z"
					sb.Append('з');
					break;
				case 16:    // "Z"
					sb.Append('З');
					break;
		}
		return sb.ToString();
	}
}