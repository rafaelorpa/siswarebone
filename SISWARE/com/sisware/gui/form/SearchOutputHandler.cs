using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sisware.gui.form
{
    public interface SearchOutputHandler
    {
        void searchOutputButtonEdit(int outputCode);
        void searchOutputButtonCancel();
    }
}