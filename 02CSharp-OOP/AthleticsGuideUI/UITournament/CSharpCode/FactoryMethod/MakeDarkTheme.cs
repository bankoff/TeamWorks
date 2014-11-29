using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode.FactoryMethod
{
    public class MakeDarkTheme : Make
    {
        public override Theme MakeTheme()
        {
            //Theme(string backgrounColour, string fontColour)
            Theme dark = new DarkTheme("#FF2D2D30", "White");

            return dark;
        }
    }
}
