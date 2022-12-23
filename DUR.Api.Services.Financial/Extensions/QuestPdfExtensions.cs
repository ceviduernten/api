using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DUR.Api.Services.Financial.Extensions;

internal static class QuestPdfExtensions
{
    private static IContainer Cell(this IContainer container, bool dark, int padding = 6)
    {
        return container
            .PaddingBottom(4)
            .Background(dark ? Colors.Grey.Lighten2 : Colors.White)
            .Padding(padding);
    }

    // displays only text label
    public static void LabelCell(this IContainer container, string text, int padding = 6)
    {
        container.Cell(true, padding).Text(text).FontSize(8);
    }

    // allows to inject any type of content, e.g. image
    public static void ValueCell(this IContainer container, string text, int padding = 6)
    {
        container.Cell(false, padding).Text(text).FontSize(8);
    }

    public static IContainer AllValueCell(this IContainer container)
    {
        return container.Cell(false);
    }

    public static TextSpanDescriptor SectionTitle(this TextSpanDescriptor text)
    {
        return text.FontSize(10).Bold().FontColor(Colors.Black);
    }

    public static TextSpanDescriptor ThinText(this TextSpanDescriptor text)
    {
        return text.Thin().FontSize(9);
    }
}