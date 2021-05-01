using DUR.Api.Presentation.ResourceModel;
using System;

namespace DUR.Api.Presentation.Interfaces.Presenter
{
    public interface IExportPresenter
    {
        ExportRM<ItemExportRM> GetWholeInventory();
        ExportRM<BoxRM> GetAllBoxes();
        ExportRM<ItemExportRM> GetInventoryByLocation(Guid location);
    }
}