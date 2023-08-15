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
        SingleRoom = 1,

        [Description("Quarto Duplo")]
        DoubleRoom = 2,

        [Description("Quarto Twin")]
        TwinRoom = 3,

        [Description("Suite")]
        Suite = 4,

        [Description("Quarto família")]
        FamilyRoom = 5,
    }
}
