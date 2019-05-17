using System;
using Business.RecipientSelections.Exceptions;
using Business.RecipientSelections.Validators;
using NUnit.Framework;

namespace Business.Test
{
    [TestFixture]
    public class SelectionTest
    {
        private string[] patternList = new string[]
            {
                "SheetNameWithoutSpacesSingleCell!A1",
                "'Sheet Name With Spaces Single Cell'!B4",
                "OnlyTheSheetNameWithoutQuotes",
                "'SheetNameWithQuotesNoSpaces'",
                "'Sheet Name With Quotes And Spaces'",
                "'Long Sheet Name With Spaces and Range'!B3:B5",
                "SheetNameWithoutSpacesWithRanges!B2:B5"
            };

        [Test]
        public void PatternTest()
        {
            SheetNameRule sheetNameRule = new SheetNameRule();
            Assert.That(() => 
                sheetNameRule.Validate(
                    new RecipientSelections.Commands.AddRecipientsSelections() {
                        SheetSelections = patternList
                    }), Throws.Nothing
            );
        }

        [Test]
        public void NameTest()
        {
            SheetTypeRule sheetNameRule = new SheetTypeRule();
            Assert.That(() =>
                sheetNameRule.Validate(
                    new RecipientSelections.Commands.AddRecipientsSelections()
                    {
                        SheetSelections = patternList
                    }), Throws.TypeOf<SheetNameNotAllowedException>()
            );
        }
    }
}
