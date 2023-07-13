using Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum ERoomType
    {
        [Description("Quarto Individual")]
        SingleRoom,

        [Description("Quarto Duplo")]
        DoubleRoom,

        [Description("Quarto Twin")]
        TwinRoom,

        [Description("Suite")]
        Suite,

        [Description("Quarto família")]
        FamilyRoom,
    }
}
