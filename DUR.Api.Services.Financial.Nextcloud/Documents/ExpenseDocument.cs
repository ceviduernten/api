using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DUR.Api.Entities.Financial;
using DUR.Api.Services.Financial.Extensions;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DUR.Api.Services.Financial.Documents;

public class ExpenseDocument : IDocument
{
    private readonly Expense _expense;

    public ExpenseDocument(Expense expense)
    {
        _expense = expense;
    }

    public DocumentMetadata GetMetadata()
    {
        return DocumentMetadata.Default;
    }

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(40);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
    }

    private void ComposePersonalDetails(IContainer container)
    {
        container.MinimalBox()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(150);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();

                table.Cell().LabelCell("Vor- und Nachname");
                table.Cell().ColumnSpan(3).ValueCell(_expense.FirstName + " " + _expense.LastName);
                table.Cell().LabelCell("Strasse");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Street);
                table.Cell().LabelCell("PLZ und Ort");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Place);
            });
    }

    private void ComposeFinanceInstitueData(IContainer container)
    {
        container.MinimalBox()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(150);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();

                table.Cell().LabelCell("Zahlungsmodus");
                table.Cell().ColumnSpan(3).ValueCell("Bank");
                table.Cell().LabelCell("Name der Bank");
                table.Cell().ColumnSpan(3).ValueCell(_expense.NameOfBank);
                table.Cell().LabelCell("Konto-Nr. (IBAN)");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Iban);
                table.Cell().LabelCell("Kontoinhaber/in");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Owner);
            });
    }

    private void ComposeExpenseInformation(IContainer container)
    {
        container.MinimalBox()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(150);
                    columns.RelativeColumn();
                    columns.ConstantColumn(100);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();

                table.Cell().LabelCell("Arbeitsgebiet");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Section);
                table.Cell().LabelCell("Betrag");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Amount);
                table.Cell().LabelCell("Kurze Beschreibung");
                table.Cell().ColumnSpan(3).ValueCell(_expense.Description);
            });
    }

    private void ComposeFinancialDepartmentInformation(IContainer container)
    {
        container.MinimalBox()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(75);
                    columns.ConstantColumn(75);
                });

                table.ExtendLastCellsToTableBottom();

                table.Cell().LabelCell("Konto-Nr.", 2);
                table.Cell().PaddingLeft(4).LabelCell("Beleg-Nr.", 2);
                table.Cell().PaddingLeft(4).LabelCell("Bez.", 2);
                table.Cell().Border(0.25f).BorderColor(Colors.Grey.Medium).ValueCell("");
                table.Cell().PaddingLeft(4).Border(0.25f).BorderColor(Colors.Grey.Medium).ValueCell("");
                table.Cell().PaddingLeft(4).Border(0.25f).BorderColor(Colors.Grey.Medium).ValueCell("");
            });
    }

    private void ComposeSignature(IContainer container)
    {
        container.PaddingTop(4).MinimalBox()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(150);
                    columns.RelativeColumn();
                });

                table.ExtendLastCellsToTableBottom();

                table.Cell().LabelCell("Unterschrift");
                var base64Data = Regex.Match(_expense.Signature, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var stream = new MemoryStream(Convert.FromBase64String(base64Data));
                table.Cell().ColumnSpan(1).AllValueCell().ScaleToFit().Height(50).Image(stream, ImageScaling.FitHeight);
            });
    }

    private void ComposeCreatorInformation(IContainer container)
    {
        container.Column(c =>
        {
            c.Item().Row(row =>
            {
                row.RelativeItem().Column(Column =>
                {
                    Column
                        .Item().Text("Meine Angaben sind vollständig und wahrheitsgetreu.")
                        .FontSize(8).Thin().FontColor(Colors.Black);
                });
            });
            c.Item().Element(ComposeSignature);
            c.Item().PaddingLeft(158).Text("online, " + DateTime.Now.ToString("dd.MM.yyyy"))
                .FontSize(8).Thin().FontColor(Colors.Black);
        });
    }

    private void ComposeHeader(IContainer container)
    {
        container.Column(c =>
        {
            c.Item().Row(row =>
            {
                row.RelativeItem().PaddingBottom(36).Element(ComposeFinancialDepartmentInformation);
                row.ConstantItem(100).Width(100).Image(GetLogo());
            });
            c.Item().Row(row =>
            {
                row.RelativeItem().AlignCenter().Column(Column =>
                {
                    Column
                        .Item().Text("SPESENRÜCKERSTATTUNG")
                        .FontSize(24).SemiBold().FontColor(Colors.Black);
                });
            });
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.PaddingVertical(24).Column(column =>
        {
            column.Item().PaddingBottom(8).PaddingTop(8).Text("PERSONALIEN").SectionTitle();
            column.Item().Element(ComposePersonalDetails);
            column.Item().PaddingBottom(8).PaddingTop(8).Text("KONTOANGABEN").SectionTitle();
            column.Item().Element(ComposeFinanceInstitueData);
            column.Item().PaddingBottom(8).PaddingTop(8).Text("AUSGABEN").SectionTitle();
            column.Item().Element(ComposeExpenseInformation);
            column.Item().PaddingTop(16).Element(ComposeCreatorInformation);
        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(Column =>
            {
                Column.Item().Text("INFO").FontSize(12).Bold().FontColor(Colors.Black);
                Column.Item().Text(text =>
                {
                    text.Span(
                            "Rückerstattet wird, was in direktem Zusammenhang mit den Aktivitäten des Cevi Dürnten steht. Die Ausgabenkompetenz liegt im Normalfall bei Fr. 50.00. Höhere Ausgaben müssen durch die Ressortleitung genehmigt werden. Belege und Kassenzettel müssen immer auf die Rückseite geklebt werden und sind in jedem Fall beizulegen. Privatausgaben sind durchzustreichen.")
                        .ThinText();
                });

                Column.Item().AlignCenter().PaddingTop(20).Text(text =>
                {
                    text.Span("Entschädigungsformular einreichen an:").ThinText();
                });
                Column.Item().AlignCenter().Text(text =>
                {
                    text.Span("Patrick Honegger, Bläsistrasse 17, 8049 Zürich").ThinText();
                });
                Column.Item().AlignCenter().Text(text =>
                {
                    text.Span("Bei Fragen: 077 457 30 80 / finanzen@ceviduernten.ch").ThinText();
                });
            });
        });
    }

    private static Stream GetLogo()
    {
        var resourceAssembly = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == "DUR.Api.Settings");
        var logoStream = resourceAssembly!.GetManifestResourceStream("DUR.Api.Settings.Images.Logo_black.png");
        return logoStream;
    }
}