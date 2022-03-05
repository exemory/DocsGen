using Core.Exceptions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Service.Models
{
    internal class WordTemplate : IDisposable
    {
        private readonly WordprocessingDocument _document;

        public static void CheckTemplateFile(Stream fileStream)
        {
            try
            {
                WordprocessingDocument.Open(fileStream, false);
            }
            catch (FileFormatException e)
            {
                throw new TemplateException("Template file is invalid.", e);
            }
        }
        
        public WordTemplate(Stream fileStream)
        {
            _document = WordprocessingDocument.Open(fileStream, true);
        }
        
        public void Fill(Dictionary<string, object?> replacements)
        {
            foreach (var (key, value) in replacements)
            {
                Replace(key, value?.ToString() ?? string.Empty);
            }
        }

        private void Replace(string oldPhrase, string newPhrase)
        {
            var document = _document.MainDocumentPart?.Document;

            if (document == null)
            {
                throw new TemplateException("Template file is invalid.");
            }

            foreach (var paragraph in document.Descendants<Paragraph>())
            {
                var paragraphText = paragraph.InnerText;

                var index = 0;
                Dictionary<int, string> matches = new();

                while ((index = paragraphText.IndexOf(oldPhrase, index, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    matches.Add(index, paragraphText.Substring(index, oldPhrase.Length));
                    index += oldPhrase.Length;
                }

                index = 0;
                var symbolsToDel = 0;

                foreach (var text in paragraph.Descendants<Text>())
                {
                    if (symbolsToDel > 0)
                    {
                        if (text.Text.Length <= symbolsToDel)
                        {
                            symbolsToDel -= text.Text.Length;
                            text.Remove();
                            continue;
                        }

                        text.Text = text.Text.Remove(0, symbolsToDel);
                        symbolsToDel = 0;
                    }

                    var newIndex = index + text.Text.Length;
                    KeyValuePair<int, string> match;

                    while (matches.Count > 0 && (match = matches.First()).Key < index + text.Text.Length)
                    {
                        var startIndex = match.Key - index;

                        symbolsToDel = Math.Max(oldPhrase.Length - (text.Text.Length - startIndex), 0);

                        var phrase = newPhrase;

                        if (match.Value.All(c => !char.IsLetter(c) || char.IsLower(c))) phrase = newPhrase.ToLower();
                        else if (match.Value.All(c => !char.IsLetter(c) || char.IsUpper(c))) phrase = newPhrase.ToUpper();

                        text.Text = text.Text.Remove(startIndex, Math.Min(oldPhrase.Length, text.Text.Length - startIndex)).Insert(startIndex, phrase);

                        index += oldPhrase.Length - newPhrase.Length;

                        matches.Remove(matches.Keys.First());
                    }

                    index = newIndex + symbolsToDel;
                }
            }
        }

        public void Dispose()
        {
            _document.Dispose();
        }
    }
}
