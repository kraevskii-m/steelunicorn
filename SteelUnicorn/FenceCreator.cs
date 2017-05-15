using System.Collections.Generic;
using System.Windows;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace SteelUnicorn
{
    public class FenceCreator
    {
        private Database _database;
        private Document _document;

        public void SelectPolyline()
        {
            _document = Application.DocumentManager.MdiActiveDocument;
            _database = _document.Database;

            //using (Transaction transaction = _document.TransactionManager.StartTransaction()) //TODO ???
            //{
            PromptSelectionResult selectionResult = _document.Editor.GetSelection();

            if (selectionResult.Status == PromptStatus.OK)
            {
                SelectionSet selectionSet = selectionResult.Value;

                foreach (Polyline pl in selectionSet) //Only polylines in special layout
                {
                    if (pl != null && pl.Layer == "КМ-ОСИ")
                    {
                        /*
                        List<Point2d> points = new List<Point2d>();

                        for (int j = 0; j < pl.NumberOfVertices; j++)
                        {
                            Point2d pt = pl.GetPoint2dAt(j);
                            points.Add(pt);
                        }
                        */
                        MessageBox.Show("it works");
                    }
                }
            }
            //transaction.Commit();
            //}
        }
    }
}