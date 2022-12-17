using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sisware.dao;

namespace com.sisware.logic
{
    
    
    public class BackUpLogic
    {
        private BackUpDAO operation = new BackUpDAO();

        public void Export(string file )
        {
            operation.Export(file);
        }

        public void Import(string file)
        {
            operation.Import(file);
        }

        public bool TableClean(string tabelName)
        {
            return operation.TableClean(tabelName);
        }

        public bool CopyInventoryTable()
        {
            return operation.CopyInventoryTable();
        }
    }
}
