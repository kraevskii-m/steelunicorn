using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace SteelUnicorn
{
    public class Layer
    {
        public void ChangeLayer(LayerTableRecord layerTableRecord) //Changing current layer
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;
            Editor editor = document.Editor;

            Transaction transaction = document.TransactionManager.StartTransaction();

            using (transaction)
            {
                LayerTable layerTable = (LayerTable)transaction.GetObject(database.LayerTableId, OpenMode.ForRead);

                if (layerTable.Has(layerTableRecord.Name))
                {
                    database.Clayer = layerTable[layerTableRecord.Name];
                }

                else
                {
                    layerTable.UpgradeOpen();
                    ObjectId layerTableId = layerTable.Add(layerTableRecord);
                    transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
                    database.Clayer = layerTableId;
                }
                
                transaction.Commit();
                editor.Regen();
            }
        }

        public ObjectId GetCurrentLayer()
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database database = document.Database;

            return database.Clayer;
        }

        public LayerTableRecord CreateLayer(string name, Color color, LineWeight weight, ObjectId linetype) //TODO temporary
        {
            LayerTableRecord layer = new LayerTableRecord
            {
                Name = name,
                Color = color,
                LineWeight = weight, LinetypeObjectId = linetype
            };
            return layer;
        }
    }
}