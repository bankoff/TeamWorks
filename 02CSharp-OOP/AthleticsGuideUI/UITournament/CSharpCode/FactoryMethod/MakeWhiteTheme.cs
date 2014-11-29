using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode.FactoryMethod
{
    class MakeWhiteTheme : Make
    {
        public override Theme MakeTheme()
        {
            //Theme(string backgrounColour, string fontColour)
            Theme theme = new WhiteTheme("White", "DarkGreen");

            return theme;
        }
    }
}
